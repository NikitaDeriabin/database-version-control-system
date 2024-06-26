﻿using DBGuard.Shared.DTO;
using DBGuard.Shared.DTO.DatabaseItem;

namespace DBGuard.SqlService.BLL.Interfaces
{
    public interface IContentDifferenceService
    {
        Task<ICollection<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId, Guid tempBlobId,
            bool isReverse = false);
        Task<ICollection<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId, DbStructureDto oldDbStructure,
            bool isReverse = false, bool isGetOneLineContent = false);
    }
}
