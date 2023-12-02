using Torcidas.Infra.Data;
using Torcidas.Domain.Entities;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public User GetByUserName(string username)
        {

           return GetFirstOrDefault(
                predicate: source => source.UserName == username
            );

        }

        public User CreateUser(User user)
        {
            return Insert(user);
        }

       
    }
}
