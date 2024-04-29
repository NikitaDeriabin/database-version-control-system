namespace DBGuard.Core.BLL.Interfaces;

public interface IChangeRecordService
{
    Task<Guid> AddChangeRecordAsync(Guid clientId);
}