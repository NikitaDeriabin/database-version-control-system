using AutoMapper;
using DBGuard.Core.DAL.Context;

namespace DBGuard.Core.BLL.Services.Abstract;

public abstract class BaseService
{
    internal const string SqlServiceUrlSection = "SqlServiceUrl";
    private protected readonly DbGuardCoreContext _context;
    private protected readonly IMapper _mapper;

    public BaseService(DbGuardCoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}