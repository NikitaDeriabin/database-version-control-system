﻿using DBGuard.Core.DAL.Enums;

namespace DBGuard.Shared.DTO.ConsoleAppHub;

public class ConnectionString
{
    public string DbName { get; set; } = string.Empty;
        public string? ServerName { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DbEngine DbEngine { get; set; }

        public bool IsLocalhost { get; set; }
        public bool IntegratedSecurity { get; set; }
}