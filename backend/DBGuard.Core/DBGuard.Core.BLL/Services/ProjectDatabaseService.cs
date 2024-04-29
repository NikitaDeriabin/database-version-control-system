using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Core.Common.DTO.ProjectDatabase;
using DBGuard.Core.DAL.Context;
using DBGuard.Core.DAL.Entities;
using DBGuard.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DBGuard.Core.BLL.Services;

public sealed class ProjectDatabaseService : BaseService, IProjectDatabaseService
{
    public ProjectDatabaseService(DbGuardCoreContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ICollection<ProjectDatabaseDto>> GetAllProjectDbAsync(int projectId)
    {
        return await _context.ProjectDatabases
            .Where(p => p.ProjectId == projectId)
            .ProjectTo<ProjectDatabaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<DatabaseInfoDto> AddNewProjectDatabaseAsync(ProjectDatabaseDto dto)
    {
        var projectDb = _mapper.Map<ProjectDatabase>(dto);

        if (await _context.Projects.FindAsync(dto.ProjectId) is null)
        {
            throw new InvalidProjectException();
        }

        var addedProjectDb = (await _context.ProjectDatabases.AddAsync(projectDb)).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<DatabaseInfoDto>(addedProjectDb);
    }
}