using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DBGuard.Core.BLL.Services;

public sealed class CommitFileService : ICommitFileService
{
    private readonly DbGuardCoreContext _context;

    public CommitFileService(DbGuardCoreContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<string>> GetBlobIdsByCommitIdAsync(int commitId)
    {
        return await _context.CommitFiles
            .Where(f => f.CommitId == commitId)
            .Select(r => r.BlobId).ToListAsync();
    }
}