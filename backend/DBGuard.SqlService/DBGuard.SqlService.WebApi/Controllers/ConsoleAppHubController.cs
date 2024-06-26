﻿using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Core.Common.DTO.Script;
using DBGuard.Shared.DTO.ConsoleAppHub;
using DBGuard.Shared.DTO.Definition;
using DBGuard.Shared.DTO.Function;
using DBGuard.Shared.DTO.Procedure;
using DBGuard.Shared.DTO.Table;
using DBGuard.Shared.DTO.UserDefinedType.DataType;
using DBGuard.Shared.DTO.UserDefinedType.TableType;
using DBGuard.Shared.DTO.View;
using DBGuard.SqlService.BLL.Hubs;
using DBGuard.SqlService.BLL.Interfaces;
using DBGuard.SqlService.BLL.Interfaces.ConsoleAppHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DBGuard.SqlService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsoleAppHubController : ControllerBase
{
    private readonly IHubContext<ConsoleAppHub, IExecuteOnClientSide> _hubContext;
    private readonly IResultObserver _resultObserver;
    private readonly IMapper _mapper;
    private readonly ISqlFormatterService _sqlFormatterService;
    private readonly (Guid queryId, TaskCompletionSource<QueryResultTable> tcs) _queryParameters;

    public ConsoleAppHubController(IHubContext<ConsoleAppHub, IExecuteOnClientSide> hubContext, ISqlFormatterService sqlFormatterService,
        IResultObserver resultObserver, IMapper mapper)
    {
        _hubContext = hubContext;
        _resultObserver = resultObserver;
        _mapper = mapper;
        _sqlFormatterService = sqlFormatterService;
        _queryParameters = RegisterQuery();
    }

    [HttpPost("all-tables-names")]
    public async Task<ActionResult<TableNamesDto>> GetAllTablesNamesAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetAllTablesNamesAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<TableNamesDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("all-stored-procedures-names")]
    public async Task<ActionResult<ProcedureNamesDto>> GetAllStoredProceduresNamesAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetAllStoredProceduresNamesAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<ProcedureNamesDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("stored-procedure-definition")]
    public async Task<ActionResult<RoutineDefinitionDto>> GetStoredProcedureDefinitionAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetStoredProcedureDefinitionAsync(_queryParameters.queryId, queryParameters.FilterSchema,
                queryParameters.FilterName);
        return Ok(_mapper.Map<RoutineDefinitionDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("all-functions-names")]
    public async Task<ActionResult<FunctionNamesDto>> GetAllFunctionsNamesAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetAllFunctionsNamesAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<FunctionNamesDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("function-definition")]
    public async Task<ActionResult<RoutineDefinitionDto>> GetFunctionDefinitionAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetFunctionDefinitionAsync(_queryParameters.queryId, queryParameters.FilterSchema,
                queryParameters.FilterName);
        return Ok(_mapper.Map<RoutineDefinitionDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("all-views-names")]
    public async Task<ActionResult<ViewNamesDto>> GetAllViewsNamesAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetAllViewsNamesAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<ViewNamesDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("view-definition")]
    public async Task<ActionResult<RoutineDefinitionDto>> GetViewDefinitionAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetViewDefinitionAsync(_queryParameters.queryId, queryParameters.FilterSchema, queryParameters.FilterName);
        return Ok(_mapper.Map<RoutineDefinitionDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("table-structure")]
    public async Task<ActionResult<TableStructureDto>> GetTableStructureAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetTableStructureAsync(_queryParameters.queryId,
            queryParameters.FilterSchema, queryParameters.FilterName);
        return Ok(_mapper.Map<TableStructureDto>(await _queryParameters.tcs.Task));
    }

    [HttpPost("table-checks-and-unique-constraints")]
    public async Task<ActionResult<TableConstraintsDto>> GetTableChecksAndUniqueConstraintsAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetTableChecksAndUniqueConstraintsAsync(_queryParameters.queryId, queryParameters.FilterSchema,
                queryParameters.FilterName);
        return Ok(_mapper.Map<TableConstraintsDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("stored-procedures-with-detail")]
    public async Task<ActionResult<ProcedureDetailsDto>> GetStoredProceduresWithDetailAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetStoredProceduresWithDetailAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<ProcedureDetailsDto>(await _queryParameters.tcs.Task));
    }

    [HttpPost("functions-with-detail")]
    public async Task<ActionResult<FunctionDetailsDto>> GetFunctionsWithDetailAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetFunctionsWithDetailAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<FunctionDetailsDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("views-with-detail")]
    public async Task<ActionResult<ViewDetailsDto>> GetViewsWithDetailAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId).GetViewsWithDetailAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<ViewDetailsDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("user-defined-types-with-defaults-and-rules-and-definition")]
    public async Task<ActionResult<UserDefinedDataTypeDetailsDto>> GetUserDefinedTypesWithDefaultsAndRulesAndDefinitionAsync(
        [FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetUserDefinedTypesWithDefaultsAndRulesAndDefinitionAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<UserDefinedDataTypeDetailsDto>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("user-defined-table-types")]
    public async Task<ActionResult<UserDefinedTables>> GetUserDefinedTableTypesAsync([FromBody] QueryParameters queryParameters)
    {
        await _hubContext.Clients.User(queryParameters.ClientId)
            .GetUserDefinedTableTypesAsync(_queryParameters.queryId);
        return Ok(_mapper.Map<UserDefinedTables>(await _queryParameters.tcs.Task));
    }
    
    [HttpPost("db-connect")]
    public async Task<IActionResult> ConnectToDbAsync([FromBody] RemoteConnect remoteConnect)
    {
        await _hubContext.Clients.User(remoteConnect.ClientId)
            .RemoteConnectAsync(_queryParameters.queryId, remoteConnect.DbConnection);
        return Ok(await _queryParameters.tcs.Task);
    }

    [HttpPost("execute-script")]
    public async Task<ActionResult<QueryResultTable>> ExecuteScriptAsync([FromBody] InboundScriptDto inboundScriptDto)
    {
        var formattedScript = _sqlFormatterService.GetFormattedSql(inboundScriptDto.DbEngine, inboundScriptDto.Content!); 
        await _hubContext.Clients.User(inboundScriptDto.ClientId!)
                         .ExecuteScriptAsync(_queryParameters.queryId, formattedScript.Content!);
        
        return Ok(await _queryParameters.tcs.Task);
    }
    
    private (Guid queryId, TaskCompletionSource<QueryResultTable> tcs) RegisterQuery()
    {
        var queryId = Guid.NewGuid();
        var tcs = _resultObserver.Register(queryId);
        return (queryId, tcs);
    }
}