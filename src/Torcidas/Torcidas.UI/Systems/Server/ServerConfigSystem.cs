using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems.Server
{
    /// <summary>
    /// Sistema responsável por gerenciar as configurações do servidor.
    /// Este é essencialmente um controlador, a implementação real dos comandos é feita no serviço de configuração do servidor (ServerConfigService).
    /// </summary>
    public class ServerConfigSystem : ISystem
    {
        private readonly IServerConfigService _serverConfigService;

        /// <summary>
        /// Construtor para a classe ServerConfigSystem.
        ///  Este construtor recebe uma instância de IServerConfigService através de injeção de dependência.
        /// </summary>
        /// <param name="serverConfigService">O serviço de configuração do servidor a ser injetado.</param>
        public ServerConfigSystem(IServerConfigService serverConfigService)
        {
            _serverConfigService = serverConfigService;
        }

        /// <summary>
        /// Evento disparado quando um jogador se conecta ao servidor.
        /// </summary>
        /// <param name="player">O player que se conectou.</param>
        
        [Event]
        public void OnGameModeInit() => _serverConfigService.OnGameModeInitHandler();
        
        [Event]
        public void OnPlayerConnect(Player player) => _serverConfigService.OnPlayerConnectHandler(player);
        
        [Timer(1000)]
        public void OneThousandsMsTicker() => _serverConfigService.OneThousandMsTickerHandler();
       

    }
}