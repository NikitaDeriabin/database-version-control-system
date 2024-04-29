namespace DBGuard.Core.BLL.Interfaces;

public interface ICommitFileService
{
    Task<ICollection<string>> GetBlobIdsByCommitIdAsync(int commitId);
}