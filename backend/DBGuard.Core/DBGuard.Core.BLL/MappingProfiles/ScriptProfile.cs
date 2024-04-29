using AutoMapper;
using DBGuard.Core.Common.DTO.Script;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class ScriptProfile : Profile
{
    public ScriptProfile()
    {
        CreateMap<Script, CreateScriptDto>()!.ReverseMap();
        CreateMap<Script, ScriptDto>()!.ReverseMap();
    }
}