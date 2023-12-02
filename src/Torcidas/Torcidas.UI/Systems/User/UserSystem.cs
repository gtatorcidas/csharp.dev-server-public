using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;

using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems.User
{
    /// <summary>
    /// Sistema responsável por gerenciar as ações relacionadas ao usuário.
    /// Este é essencialmente um controlador, a implementação real dos comandos é feita no serviço de usuário (IUserService).
    /// </summary>
    public class UserSystem : ISystem
    {
        #region Properties

        private readonly IUserService _userService;

        #endregion

        #region Constructors

        /// <summary>
        /// Construtor para a classe UserSystem.
        /// Injeta a dependência do serviço de usuário (IUserService).
        /// </summary>
        /// <param name="userService">O serviço de usuário a ser injetado.</param>
        public UserSystem(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Commands
        
        /// <summary>
        /// Comando para exibir os dados da conta do usuário.
        /// </summary>
        /// <param name="user">O usuário que está executando o comando é injetado automaticamente.</param>
        [PlayerCommand("dados")]
        public void DataComand(UserComponent user) => _userService.DataCommandHandler(user);

        /// <summary>
        /// Comando para buscar uma lista de jogadores com base no parâmetro.
        /// </summary>
        /// <param name="user">O usuário que está executando o comando é injetado automaticamente.</param>
        /// <param name="parametro">O parâmetro a ser buscado.</param>
        [PlayerCommand("id")]
        public void IdentifyComand(UserComponent user, string parametro) => _userService.IdentifyComandHandler(user, parametro);

        /// <summary>
        /// Comando para permitir o usuário se matar
        /// </summary>
        /// <param name="user">O usuário que está executando o comando é injetado automaticamente.</param>
        [PlayerCommand("kill")]
        public void KillMeComand(UserComponent user) => _userService.KillMeComandHandler(user);

        /// <summary>
        /// Comando para enviar uma mensagem privada para outro jogador.
        /// </summary>
        /// <param name="user">O usuário que está executando o comando é injetado automaticamente.</param>
        /// <param name="playerId">O ID/Nick do jogador para quem a mensagem será enviada.</param>
        /// <param name="mensagem">A mensagem a ser enviada.</param>
        [PlayerCommand("pm")]
        public void PrivateMessageCommand(UserComponent user, Player playerId, string mensagem) => _userService.PrivateMessageCommandHandler(user, playerTarget: playerId, mensagem);

        #endregion

    }
}
