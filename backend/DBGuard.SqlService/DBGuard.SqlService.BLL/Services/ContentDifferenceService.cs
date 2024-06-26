using System.Text;
using DBGuard.AzureBlobStorage.Interfaces;
using DBGuard.Shared.DTO;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.Function;
using DBGuard.Shared.DTO.Procedure;
using DBGuard.Shared.DTO.Table;
using DBGuard.Shared.DTO.Text;
using DBGuard.Shared.DTO.View;
using DBGuard.Shared.Enums;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Blob = DBGuard.AzureBlobStorage.Models.Blob;

namespace DBGuard.SqlService.BLL.Services;

public class ContentDifferenceService : IContentDifferenceService
{
    private const string UserDbChangesBlobContainerNameSection = "UserDbChangesBlobContainerName";
    private readonly IBlobStorageService _blobStorageService;
    private readonly IConfiguration _configuration;
    private readonly ITextService _textService;

    public ContentDifferenceService(IBlobStorageService blobStorageService, IConfiguration configuration,
        ITextService textService)
    {
        _blobStorageService = blobStorageService;
        _textService = textService;
        _configuration = configuration;
    }

    public async Task<ICollection<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId, Guid tempBlobId, 
        bool isReverse = false)
    {
        var containers = await _blobStorageService.GetContainersByPrefixAsync(commitId.ToString());
        var dbStructure = await GetTempBlobContentAsync(tempBlobId);
        return await GetTextPairFromBlobsAsync(commitId, containers, dbStructure, isReverse, false);
    }

    public async Task<ICollection<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId,
        DbStructureDto oldDbStructure,
        bool isReverse = false, bool isGetOneLineContent = false)
    {
        var containers = await _blobStorageService.GetContainersByPrefixAsync(commitId.ToString());
        return await GetTextPairFromBlobsAsync(commitId, containers, oldDbStructure, isReverse, isGetOneLineContent);
    }

    private async Task<ICollection<DatabaseItemContentCompare>> GetTextPairFromBlobsAsync(int commitId,
        ICollection<string> containers, DbStructureDto dbStructure, bool isReverse, bool isGetOneLineContent)
    {
        var differenceList = new List<DatabaseItemContentCompare>();
        var markedBlobIds = new List<string>();
        
        if (isGetOneLineContent)
        {
            await CompareDbItemsContentAsync(dbStructure.DbTableStructures!, containers, commitId,
                DatabaseItemType.Table, differenceList, markedBlobIds, isReverse);
            
            await CompareDbItemsContentAsync(dbStructure.DbFunctionDetails!.Details, containers, commitId, 
                DatabaseItemType.Function, differenceList, markedBlobIds, isReverse);
          
            await CompareDbItemsContentAsync(dbStructure.DbProcedureDetails!.Details, containers, commitId, 
                DatabaseItemType.StoredProcedure, differenceList, markedBlobIds, isReverse);
        
            await CompareDbItemsContentAsync(dbStructure.DbViewsDetails!.Details, containers, commitId, 
                DatabaseItemType.View, differenceList, markedBlobIds, isReverse);
            
            //
            await CompareUnmarkedBlobsContentAsync<TableStructureDto>(DatabaseItemType.Table, containers, commitId, 
                differenceList, markedBlobIds, isReverse);

            await CompareUnmarkedBlobsContentAsync<FunctionDetailInfo>(DatabaseItemType.Function, containers, commitId,
                differenceList, markedBlobIds, isReverse);
         
            await CompareUnmarkedBlobsContentAsync<ProcedureDetailInfo>(DatabaseItemType.StoredProcedure, containers, 
                commitId, differenceList, markedBlobIds, isReverse);
         
            await CompareUnmarkedBlobsContentAsync<ViewDetailInfo>(DatabaseItemType.View, containers, commitId,
                differenceList, markedBlobIds, isReverse);
            
        }
        else
        {
            await CompareDbItemsDefinitionAsync(dbStructure.DbTableStructures!, containers, commitId,
            DatabaseItemType.Table, differenceList, markedBlobIds, isReverse);
        
        // * Diff for constraints * 
        // foreach (var tableConstraints in dbStructure.DbConstraints!)
        // {
        //     await CompareDbItemsContentAsync(tableConstraints.Constraints, containers, commitId, DatabaseItemType.Constraint, differenceList, markedBlobIds);
        // }

        await CompareDbItemsDefinitionAsync(dbStructure.DbFunctionDetails!.Details, containers, commitId, 
            DatabaseItemType.Function, differenceList, markedBlobIds, isReverse);
          
        await CompareDbItemsDefinitionAsync(dbStructure.DbProcedureDetails!.Details, containers, commitId, 
            DatabaseItemType.StoredProcedure, differenceList, markedBlobIds, isReverse);
        
        await CompareDbItemsDefinitionAsync(dbStructure.DbViewsDetails!.Details, containers, commitId, 
            DatabaseItemType.View, differenceList, markedBlobIds, isReverse);
        
         // * Diff for constraints user defined data type *
         // await CompareDbItemsContentAsync(dbStructure.DbUserDefinedDataTypeDetailsDto.Details, containers, commitId,
         //     DatabaseItemType.UserDefinedDataType, differenceList, markedBlobIds);
         
         // * Diff for user defined table type *
         // await CompareDbItemsContentAsync(dbStructure.DbUserDefinedTableTypeDetailsDto.Tables, containers, commitId, DatabaseItemType.UserDefinedTableType,
         //     differenceList, markedBlobIds);
         
         
         await CompareUnmarkedBlobsDefinitionAsync<TableStructureDto>(DatabaseItemType.Table, containers, commitId, 
             differenceList, markedBlobIds, isReverse);
         
         // * Diff for constraints * 
         // await CompareUnmarkedConstraintBlobsContent(DatabaseItemType.Constraint, containers, commitId, differenceList, markedBlobIds);
        
         await CompareUnmarkedBlobsDefinitionAsync<FunctionDetailInfo>(DatabaseItemType.Function, containers, commitId,
             differenceList, markedBlobIds, isReverse);
         
         await CompareUnmarkedBlobsDefinitionAsync<ProcedureDetailInfo>(DatabaseItemType.StoredProcedure, containers, 
             commitId, differenceList, markedBlobIds, isReverse);
         
         await CompareUnmarkedBlobsDefinitionAsync<ViewDetailInfo>(DatabaseItemType.View, containers, commitId,
             differenceList, markedBlobIds, isReverse);
         
         // * Diff for constraints user defined data type *
         // await CompareUnmarkedBlobsContentAsync<UserDefinedDataTypeDetailInfo>(DatabaseItemType.UserDefinedDataType, 
         //     containers, commitId, differenceList, markedBlobIds);
         
         // * Diff for user defined table type *
         // await CompareUnmarkedBlobsContentAsync<UserDefinedTableDetailsDto>(DatabaseItemType.UserDefinedTableType,
         //     containers, commitId, differenceList, markedBlobIds);
        }
        
        return differenceList;
    }
    
    private async Task CompareDbItemsContentAsync<T>(List<T> dbStructureItemCollection, ICollection<string> containers,
        int commitId, DatabaseItemType itemType, ICollection<DatabaseItemContentCompare> differenceList, 
        ICollection<string> markedBlobIds, bool isReverse) where T : BaseDbItem
    {
        var blobs = await GetBlobsByContainerName(containers, commitId, itemType);
        
        foreach (var dbItem in dbStructureItemCollection)
        {
            var currentBlob = blobs.FirstOrDefault(blob => blob.Id == GetBlobName(dbItem.Schema, dbItem.Name));
            if (currentBlob is null)
            {
                differenceList.Add(GetDbItemDifference(Encoding.UTF8.GetBytes(""), dbItem, 
                    itemType, isReverse));
                continue;
            }
            differenceList.Add(GetDbItemDifference(currentBlob.Content!, dbItem, itemType, isReverse));
            markedBlobIds.Add(currentBlob.Id);
        }
    }
    
     private async Task CompareDbItemsDefinitionAsync<T>(List<T> dbStructureItemCollection,
        ICollection<string> containers, int commitId, DatabaseItemType itemType,
        ICollection<DatabaseItemContentCompare> differenceList,
        ICollection<string> markedBlobIds, bool isReverse) where T: BaseDbItemWithDefinition
     {
         var blobs = await GetBlobsByContainerName(containers, commitId, itemType);
        
        foreach (var dbItem in dbStructureItemCollection)
        {
            var currentBlob = blobs.FirstOrDefault(blob => blob.Id == GetBlobName(dbItem.Schema, dbItem.Name));
            if (currentBlob is null)
            {
                differenceList.Add(GetDbItemDefinitionDifference(Encoding.UTF8.GetBytes(""), dbItem,
                    itemType, isReverse));
                continue;
            }
            differenceList.Add(GetDbItemDefinitionDifference(currentBlob.Content!, dbItem, itemType, isReverse));
            markedBlobIds.Add(currentBlob.Id);
        }
    }
    
     private async Task CompareUnmarkedBlobsContentAsync<T>(DatabaseItemType itemType, ICollection<string> containers, int commitId, List<DatabaseItemContentCompare> differenceList,
        List<string> markedBlobIds, bool isReverse) where T : BaseDbItem
    {
        var blobs = await GetBlobsByContainerName(containers, commitId, itemType);
        var unmarkedBlobs = blobs.Where(blob => !markedBlobIds.Contains(blob.Id));
        
        foreach (var blob in unmarkedBlobs)
        {
            differenceList.Add(GetDbItemDifference<T>(blob.Content!, itemType, isReverse));
        }
    }
    
    private async Task CompareUnmarkedBlobsDefinitionAsync<T>(DatabaseItemType itemType, ICollection<string> containers, int commitId, List<DatabaseItemContentCompare> differenceList,
        List<string> markedBlobIds, bool isReverse) where T : BaseDbItemWithDefinition
    {
        var blobs = await GetBlobsByContainerName(containers, commitId, itemType);
        var unmarkedBlobs = blobs.Where(blob => !markedBlobIds.Contains(blob.Id));
        
        foreach (var blob in unmarkedBlobs)
        {
            differenceList.Add(GetDbItemDefinitionDifference<T>(blob.Content!, itemType, isReverse));
        }
    }

    private async Task CompareUnmarkedConstraintBlobsContent(DatabaseItemType itemType, ICollection<string> containers, int commitId, List<DatabaseItemContentCompare> differenceList,
        ICollection<string> markedBlobIds, bool isReverse)
    {
        var blobs = await GetBlobsByContainerName(containers, commitId, itemType);
        var unmarkedBlobs = blobs.Where(blob => !markedBlobIds.Contains(blob.Id));
        
        foreach (var blob in unmarkedBlobs)
        {
            CheckBlockContentNotNull(blob.Content!);
            
            var jsonString = Encoding.UTF8.GetString(blob.Content!);
            var tableConstraintsDto = JsonConvert.DeserializeObject<TableConstraintsDto>(jsonString)!;
            
            foreach (var constraint in tableConstraintsDto.Constraints)
            {
                var textPair = GetTextPairRequestDtoInstance(JsonConvert.SerializeObject(constraint),
                    string.Empty, isReverse);
                
                differenceList.Add(GetDataBaseItemContentCompareInstance(constraint.Schema, constraint.Name, itemType,
                    textPair));
            }
        }
    }

    private DatabaseItemContentCompare GetDbItemDifference<T>(byte[] blobContent, T dbItem,
        DatabaseItemType itemType, bool isReverse) where T : BaseDbItem
    {
        CheckBlockContentNotNull(blobContent);

        var commitItemContent = DeserializeBlobContent<T>(blobContent);
        var textPair = GetTextPairRequestDtoInstance(JsonConvert.SerializeObject(commitItemContent),
            JsonConvert.SerializeObject(dbItem), isReverse);

        return GetDataBaseItemContentCompareInstance(dbItem.Schema, dbItem.Name, itemType, textPair);
    }
    
    private DatabaseItemContentCompare GetDbItemDifference<T>(byte[] blobContent,
        DatabaseItemType itemType, bool isReverse) 
        where T : BaseDbItem
    {
        CheckBlockContentNotNull(blobContent);
        
        var commitItemContent = DeserializeBlobContent<T>(blobContent);
        var textPair = GetTextPairRequestDtoInstance(JsonConvert.SerializeObject(commitItemContent), 
            string.Empty, isReverse);

        return GetDataBaseItemContentCompareInstance(commitItemContent.Schema, commitItemContent.Name, 
            itemType, textPair);
    }
    
    private DatabaseItemContentCompare GetDbItemDefinitionDifference<T>(byte[] blobContent, T dbItem,
        DatabaseItemType itemType, bool isReverse) where T: BaseDbItemWithDefinition
    {
        CheckBlockContentNotNull(blobContent);

        var commitItemContent = DeserializeBlobContent<T>(blobContent);
        var textPair = GetTextPairRequestDtoInstance(commitItemContent?.Definition, 
            dbItem.Definition, isReverse);

        return GetDataBaseItemContentCompareInstance(dbItem.Schema, dbItem.Name, itemType, textPair);
    }

    private DatabaseItemContentCompare GetDbItemDefinitionDifference<T>(byte[] blobContent, 
        DatabaseItemType itemType, bool isReverse) where T : BaseDbItemWithDefinition
    {
        CheckBlockContentNotNull(blobContent);
        
        var commitItemContent = DeserializeBlobContent<T>(blobContent);
        var textPair = GetTextPairRequestDtoInstance(commitItemContent.Definition, string.Empty, isReverse);

        return GetDataBaseItemContentCompareInstance(commitItemContent.Schema, commitItemContent.Name, 
            itemType, textPair);
    }

    private DatabaseItemContentCompare GetDataBaseItemContentCompareInstance(string schema, string name,
        DatabaseItemType itemType, TextPairRequestDto textPair)
    {
        return new DatabaseItemContentCompare
        {
            SchemaName = schema,
            ItemName = name,
            ItemType = itemType,
            InLineDiff = _textService.GetInlineDiffs(textPair),
            SideBySideDiff = _textService.GetSideBySideDiffs(textPair),
        };
    }

    private TextPairRequestDto GetTextPairRequestDtoInstance(string? oldText, string? newText, bool isReverse)
    {
        if (!isReverse)
        {
            return new TextPairRequestDto
            {
                OldText = CheckContentForNull(oldText),
                NewText = CheckContentForNull(newText),
                IgnoreWhitespace = true
            };
        }
        
        return new TextPairRequestDto
        {
            OldText = CheckContentForNull(newText),
            NewText = CheckContentForNull(oldText),
            IgnoreWhitespace = true
        };
    }
    private static T DeserializeBlobContent<T>(byte[] blobContent) where T : BaseDbItem
    {
        var jsonString = Encoding.UTF8.GetString(blobContent);
        var commitItemContent = JsonConvert.DeserializeObject<T>(jsonString)!;
        return commitItemContent;
    }

    private void CheckBlockContentNotNull(byte[] blobContent)
    {
        if (blobContent is null)
        {
            throw new Exception("Blob Content is empty");
        }
    }

    private async Task<DbStructureDto> GetTempBlobContentAsync(Guid tempBlobId)
    {
        var blob = await _blobStorageService.DownloadAsync(_configuration[UserDbChangesBlobContainerNameSection], tempBlobId.ToString());
        if (blob.Content is not null)
        {
            var jsonString = Encoding.UTF8.GetString(blob.Content);
            return JsonConvert.DeserializeObject<DbStructureDto>(jsonString)!;
        }
        throw new Exception("Blob Content is empty");
    }
    private async Task<ICollection<Blob>> GetBlobsByContainerName(ICollection<string> containers, int commitId,
        DatabaseItemType itemType)
    {
        var dbItemContainer = containers.FirstOrDefault(cont => cont == GetContainerName(commitId, itemType));
         
        if (dbItemContainer is null)
        {
            return new List<Blob>();
        }

        return await _blobStorageService.GetAllBlobsByContainerNameAsync(dbItemContainer);
    }

    private string CheckContentForNull(string? text)
    {
        return text ?? string.Empty;
    }
    
    private string GetContainerName(int commitId, DatabaseItemType itemType) => $"{commitId}-{itemType}".ToLower();

    private string GetBlobName(string schema, string name) => $"{schema}-{name}".ToLower();
}