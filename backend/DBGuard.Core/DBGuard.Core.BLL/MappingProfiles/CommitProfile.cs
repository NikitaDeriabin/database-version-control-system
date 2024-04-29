using AutoMapper;
using DBGuard.Core.Common.DTO.Commit;
using DBGuard.Core.DAL.Entities;
using DBGuard.Shared.DTO.CommitFile;

namespace DBGuard.Core.BLL.MappingProfiles;

public class CommitProfile: Profile
{
    public CommitProfile()
    {
        CreateMap<Commit, CommitDto>();
        CreateMap<CommitFileDto, CommitFile>().ReverseMap();
        CreateMap<CreateCommitDto, Commit>();
    }
}
