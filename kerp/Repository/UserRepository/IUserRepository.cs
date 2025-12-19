using kerp.Entities;
using kerp.SystemModel;

namespace kerp.Repository.UserRepository
{
    public interface IUserRepository
    {
        UserLogin? LoginUser(LoginModel model);
        UserLogin? UserRefleshPage(int model);
    }
}
