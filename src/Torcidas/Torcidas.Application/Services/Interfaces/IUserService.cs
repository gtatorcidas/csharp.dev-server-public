using SampSharp.Entities.SAMP;

using Torcidas.Core.DTOs;
using Torcidas.Core.Components;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IUserService
    {

        #region Entity Framework Methods
        UserDTO GetUserByUserName(string username);
        UserDTO CreateUser(UserDTO userDTO);

        #endregion

        #region Handlers

        void DataCommandHandler(UserComponent userComponent);
        void IdentifyComandHandler(UserComponent userComponent, string parametro);
        void KillMeComandHandler(UserComponent userComponent);
        void PrivateMessageCommandHandler(UserComponent userComponent, Player? playerTarget, string mensagem);

        #endregion

    }
}
