using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.DTO.ConsoleAppHub;
using DBGuard.Shared.DTO.Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpPost]
    public async Task<ActionResult<TableNamesDto>> GetTableNamesAsync(QueryParameters queryParameters)
    {
        return Ok(await _tableService.GetTablesNameAsync(queryParameters));
    }
}