﻿using System.ComponentModel.DataAnnotations;

namespace DBGuard.Shared.DTO.ConsoleAppHub;

public class QueryParameters
{
    [Required]
    public string ClientId { get; set; } = string.Empty;
    public string FilterSchema { get; set; } = string.Empty;
    public string FilterName { get; set; } = string.Empty;
}