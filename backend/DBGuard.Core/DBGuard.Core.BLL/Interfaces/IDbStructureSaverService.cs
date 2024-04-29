using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.Interfaces;

public interface IDbStructureSaverService
{
    Task SaveDbStructureToAzureBlobAsync(ChangeRecord changeRecord, Guid clientId);
}