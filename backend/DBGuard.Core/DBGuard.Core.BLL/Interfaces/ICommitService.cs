using DBGuard.Core.Common.DTO.Commit;

namespace DBGuard.Core.BLL.Interfaces;

public interface ICommitService
{
    Task<CommitDto> CreateCommitAsync(CreateCommitDto dto);
}
