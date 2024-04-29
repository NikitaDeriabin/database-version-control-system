using DBGuard.Shared.DTO.DatabaseItem;

namespace DBGuard.Core.BLL.Interfaces;

public interface ICommitChangesService
{
    Task<List<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId, Guid tempBlobId);
}