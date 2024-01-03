using Microsoft.EntityFrameworkCore;

using Torcidas.Infra.Data;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private List<AppDbContext> _contexts = new();
        private IUserRepository _userRepository = null;

        public UnitOfWork(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IUserRepository UserRepository
        {
            get
            {
                var context = _contextFactory.CreateDbContext();
                _contexts.Add(context);
                return _userRepository ?? new UserRepository(context);
            }
        }

        public void Dispose()
        {
            foreach (var context in _contexts)
            {
                context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }

}
