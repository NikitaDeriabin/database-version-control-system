using DBGuard.Shared.DTO;

namespace DBGuard.Core.BLL.Interfaces;

public interface IApplyChangesService
{
    Task ApplyChanges(ApplyChangesDto applyChangesDto, int branchId);
}