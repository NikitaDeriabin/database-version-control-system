﻿namespace DBGuard.Shared.Enums;

public enum ErrorType
{
    InvalidEmail = 1,
    InvalidUsername,
    InvalidPassword,
    InvalidEmailOrPassword,
    NotFound,
    Internal,
    InvalidToken,
    InvalidBranchName,
    InvalidProject,
    LargeFile,
    InvalidFileFormat,
    RefreshTokenExpired,
    SqlSyntax,
    InvalidQuery,
    QueryExpired,
    HttpRequest,
    InvalidPermission
}