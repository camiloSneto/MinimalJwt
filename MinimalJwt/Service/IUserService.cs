using MinimalJwt.Models;

namespace MinimalJwt.Service
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
      
}
