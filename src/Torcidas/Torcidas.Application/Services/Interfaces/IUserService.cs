using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
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

        void DataCommandHandler(UserComponent userComponent);
        void IdentifyComandHandler(UserComponent userComponent, string parametro);
        void KillMeComandHandler(UserComponent userComponent);
        void PrivateMessageCommandHandler(UserComponent userComponent, Player? playerTarget, string mensagem);

        #endregion

    }
}
