using DBGuard.Shared.DTO.CommitFile;
using DBGuard.Shared.DTO.SelectedItems;

namespace DBGuard.SqlService.BLL.Interfaces;
public interface ICommitFilesService
{
    Task<ICollection<CommitFileDto>> SaveSelectedFilesAsync(SelectedItemsDto selectedItems);
}
