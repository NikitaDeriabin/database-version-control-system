﻿using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.Common.DTO.Script;

public class InboundScriptDto
{
    public string? ClientId { get; set; }
    public int ProjectId { get; set; }
    public DbEngine DbEngine { get; set; }
    public string? Content { get; set; }
}
