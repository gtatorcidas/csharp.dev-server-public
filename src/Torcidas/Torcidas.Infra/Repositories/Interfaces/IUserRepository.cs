using Torcidas.Domain.Entities;

namespace Torcidas.Infra.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUserName(string username);
        User CreateUser(User user);
    }
}
