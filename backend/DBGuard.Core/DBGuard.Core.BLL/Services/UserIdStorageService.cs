using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.Exceptions;

namespace DBGuard.Core.BLL.Services;

public class UserIdStorageService : IUserIdGetter, IUserIdSetter
{
    private int _userId;

    public int GetCurrentUserId()
    {
        if (_userId == 0)
        {
            throw new InvalidAccessTokenException();
        }

        return _userId;
    }

    public void SetCurrentUserId(int id)
    {
        _userId = id;
    }
}
