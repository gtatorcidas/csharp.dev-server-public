using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI.Systems.User
{
    /// <summary>
    /// Sistema responsável por gerenciar a taxa de quadros por segundo (FPS) dos jogadores.
    /// A implementação real dos comandos é feita no serviço de FPS (FpsService).
    /// </summary>
    public class FpsSystem : ISystem
    {
       
        private readonly IFpsService _fpsService;

        // <summary>
        /// Inicializa uma nova instância da classe FpsSystem.
        /// Este construtor recebe uma instância de IFpsService através de injeção de dependência.
        /// </summary>
        /// <param name="fpsService">O serviço de FPS a ser usado pelo sistema.</param>
        public FpsSystem(IFpsService fpsService)
        {
            _fpsService = fpsService;
        }

        /// <summary>
        /// Manipulador de eventos que é chamado quando um jogador spawna no jogo.
        /// </summary>
        /// <param name="player">O Player que spawnou é passado automaticamente pro método</param>
        [Event]
        
        public void OnPlayerSpawn(Player player) => _fpsService.OnPlayerSpawnHandler(player);

        /// <summary>
        /// Manipulador de eventos que é chamado quando um player é atualizado.
        /// </summary>
        /// <param name="serverConfigComponent">O componente de configuração do servidor, é passado automaticamente pro método.</param>
        [Event]
        public void OnPlayerUpdate(ServerConfigComponent serverConfigComponent) => _fpsService.OnPlayerUpdateHandler(serverConfigComponent);

    }
}
