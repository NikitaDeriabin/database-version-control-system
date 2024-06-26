﻿using Microsoft.AspNetCore.Http;

namespace DBGuard.Core.BLL.Interfaces;

public interface IImageService
{
    Task AddAvatarAsync(IFormFile avatar);
    Task DeleteAvatarAsync();
}