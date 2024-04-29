﻿using DBGuard.Core.DAL.Entities.Common;

namespace DBGuard.Core.DAL.Entities;

public sealed class ProjectDatabase : Entity<int>
{
    public string DbName { get; set; } = string.Empty;
    public string Guid { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}