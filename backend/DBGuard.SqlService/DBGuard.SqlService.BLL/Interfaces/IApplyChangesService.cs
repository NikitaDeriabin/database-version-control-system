using DBGuard.Shared.DTO;

namespace DBGuard.SqlService.BLL.Interfaces
{
    public interface IApplyChangesService
    {
        Task ApplyChanges(ApplyChangesDto applyChangesDto, int commitId);
    }
}
