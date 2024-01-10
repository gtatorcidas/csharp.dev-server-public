using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;

using Torcidas.Core.Components.Users;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems.Users
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
        /// <param name="userComponent">O usuário que está executando o comando é injetado automaticamente.</param>
        [PlayerCommand("dados")]
        public void DataComand(UserComponent userComponent) => _userService.DataCommandHandlerAsync(userComponent);

        /// <summary>
        /// Comando para buscar uma lista de jogadores com base no parâmetro.
        /// </summary>
        /// <param name="userComponent">O usuário que está executando o comando é injetado automaticamente.</param>
        /// <param name="parametro">O parâmetro a ser buscado.</param>
        [PlayerCommand("id")]
        public void IdentifyComand(UserComponent userComponent, string parametro) => _userService.IdentifyComandHandlerAsync(userComponent, parametro);

        /// <summary>
        /// Comando para permitir o usuário se matar
        /// </summary>
        /// <param name="userComponent">O usuário que está executando o comando é injetado automaticamente.</param>
        [PlayerCommand("kill")]
        public void KillMeComand(UserComponent userComponent) => _userService.KillMeComandHandlerAsync(userComponent);

        /// <summary>
        /// Comando para enviar uma mensagem privada para outro jogador.
        /// </summary>
        /// <param name="userComponent">O usuário que está executando o comando é injetado automaticamente.</param>
        /// <param name="playerId">O ID/Nick do jogador para quem a mensagem será enviada.</param>
        /// <param name="mensagem">A mensagem a ser enviada.</param>
        [PlayerCommand("pm")]
        public void PrivateMessageCommand(UserComponent userComponent, Player playerId, string mensagem) => _userService.PrivateMessageCommandHandlerAsync(userComponent, playerTarget: playerId, mensagem);

        #endregion

    }
}
