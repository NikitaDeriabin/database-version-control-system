﻿using System.ComponentModel.DataAnnotations;
using DBGuard.Core.DAL.Entities.Common;
using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.DAL.Entities.JoinEntities;

public sealed class UserProject : Entity<int>
{
    [Required]
    public UserRole UserRole { get; set; }

    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public Project Project { get; set; } = null!;
    public User User { get; set; } = null!;
}