using DBGuard.Core.Common.DTO.ProjectDatabase;

namespace DBGuard.Core.BLL.Interfaces;

public interface IProjectDatabaseService
{
    Task<ICollection<ProjectDatabaseDto>> GetAllProjectDbAsync(int projectId);
    Task<DatabaseInfoDto> AddNewProjectDatabaseAsync(ProjectDatabaseDto dto);
}