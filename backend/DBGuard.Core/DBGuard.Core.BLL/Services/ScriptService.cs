﻿using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Core.Common.DTO.Script;
using DBGuard.Core.DAL.Context;
using DBGuard.Core.DAL.Entities;
using DBGuard.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public sealed class ScriptService : BaseService, IScriptService
{
    private const string ExecuteScriptRoutePrefix = "/api/ConsoleAppHub/execute-script";
    private const string FormatScriptRoutePrefix = "/api/Script/format";
    private readonly IConfiguration _configuration;
    private readonly IUserIdGetter _userIdGetter;
    private readonly IHttpClientService _httpClientService;

    public ScriptService(DbGuardCoreContext context, IMapper mapper, IHttpClientService httpClientService,
        IConfiguration configuration, IUserIdGetter userIdGetter) : base(context, mapper)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
        _userIdGetter = userIdGetter;
    }

    public async Task<ScriptDto> CreateScriptAsync(CreateScriptDto dto, int authorId)
    {
        var script = _mapper.Map<Script>(dto);
        script.CreatedBy = script.LastUpdatedByUserId = authorId;
        var createdScript = (await _context.Scripts.AddAsync(script)).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<ScriptDto>(createdScript);
    }

    public async Task<ScriptDto> UpdateScriptAsync(ScriptDto dto, int editorId)
    {
        var script = await GetScriptByIdInternalAsync(dto.Id);

        _mapper.Map(dto, script);
        script.LastUpdatedByUserId = editorId;
        var updatedScript = _context.Scripts.Update(script).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<ScriptDto>(updatedScript);
    }

    public async Task<ICollection<ScriptDto>> GetAllScriptsAsync(int projectId)
    {
        var scripts = await _context.Scripts
            .Where(x => x.ProjectId == projectId)
            .ToListAsync();

        return _mapper.Map<List<ScriptDto>>(scripts);
    }

    public async Task DeleteScriptAsync(int scriptId)
    {
        var script = await GetScriptByIdInternalAsync(scriptId);

        _context.Remove(script);
        await _context.SaveChangesAsync();
    }

    public async Task<ScriptContentDto> GetFormattedSqlAsync(InboundScriptDto inboundScriptDto)
    {
        return await _httpClientService.SendAsync<InboundScriptDto, ScriptContentDto>
            ($"{_configuration[SqlServiceUrlSection]}{FormatScriptRoutePrefix}", inboundScriptDto, HttpMethod.Put);
    }

    public async Task<QueryResultTable> ExecuteSqlScriptAsync(InboundScriptDto inboundScriptDto)
    {
        return await _httpClientService.SendAsync<InboundScriptDto, QueryResultTable>
            ($"{_configuration[SqlServiceUrlSection]}{ExecuteScriptRoutePrefix}", inboundScriptDto, HttpMethod.Post);
    }

    private async Task<Script> GetScriptByIdInternalAsync(int scriptId)
    {
        var scriptEntity = await _context.Scripts
            .Include(s => s.Project)
            .ThenInclude(p => p.Users)
            .FirstOrDefaultAsync(s => s.Id == scriptId);

        if (scriptEntity is null || scriptEntity.Project.Users.Any(u => u.Id == _userIdGetter.GetCurrentUserId()))
        {
            throw new EntityNotFoundException();
        }

        return scriptEntity;
    }
}