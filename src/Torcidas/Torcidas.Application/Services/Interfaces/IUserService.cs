using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Core.Components.Users;
using Torcidas.Domain.Entities;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IUserService
    {

        #region Entity Framework Methods
        User GetUserByUserName(string username);
        User CreateUser(User userDTO);

        #endregion

        #region Handlers

        Task DataCommandHandlerAsync(UserComponent userComponent);
        Task IdentifyComandHandlerAsync(UserComponent userComponent, string parametro);
        Task KillMeComandHandlerAsync(UserComponent userComponent);
        Task PrivateMessageCommandHandlerAsync(UserComponent userComponent, Player? playerTarget, string mensagem);

        #endregion

    }
}
