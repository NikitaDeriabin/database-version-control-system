using DBGuard.Core.Common.DTO.Auth;
using DBGuard.Core.Common.DTO.Users;

namespace DBGuard.Core.BLL.Interfaces;

public interface IAuthService
{
    Task<AuthUserDto> LoginAsync(UserLoginDto userLoginDto);
    Task<AuthUserDto> RegisterAsync(UserRegisterDto userRegisterDto);
    Task<AuthUserDto> AuthorizeWithGoogleAsync(string googleCredentialsToken);
    Task<RefreshedAccessTokenDto> RefreshTokensAsync(RefreshedAccessTokenDto tokens);
}