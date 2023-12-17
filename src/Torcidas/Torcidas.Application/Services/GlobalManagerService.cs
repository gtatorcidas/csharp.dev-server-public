using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class GlobalManagerService : IGlobalManagerService
    {
        #region Properties
        
        private readonly IEntityManager _entityManager;
        private readonly IWorldService _worldService;
        
        #endregion

        #region Constructor
        public GlobalManagerService(IEntityManager entityManager, IWorldService worldService)
        {
            _entityManager = entityManager;
            _worldService = worldService;
        }
        #endregion

        #region Messages
        public void SendPlayerErrorMessage(Player player, string message)
        {

            var newText = "[ERRO]:{FFFFFF} " + message;
            player.SendClientMessage(Color.Red, newText);

        }

        public void SendPlayerServerMessage(Player player, string message)
        {
            var newText = "[SERVER]:{FFFFFF} " + message;
            player.SendClientMessage(Color.LightBlue, newText);

        }
        
        public void SendPlayerNearByMessage(Player player, float range, Color textColor, string message)
        {
            // UserComponent somente é adicionado para players que possuem conta no banco de dados no momento de conexão no server
            // Dessa forma, recebo uma lista de UserComponent na variável users
            var users = _entityManager.GetComponents<UserComponent>();

            // Filtra os usuários e cria uma nova lista chamada results somente com os jogadores que estão próximos ao jogador enviado através do parâmetro **player**
            var results = users.Where(x => IsPlayerNearByPlayer(player, x.GetComponent<Player>(), range));

            // Percorre esses usuários filtrados manda a mensagem para cada um deles
            foreach(var user in results)
            {
                var targetPlayer = user.GetComponent<Player>();

                targetPlayer.SendClientMessage(textColor, message);
            }

        }

        public void SendPlayerSyntaxMessage(Player player, string message)
        {
            var newText = "[USO CORRETO]:{FFFFFF} " + message;
            player.SendClientMessage(Color.Gray, newText);

        }

        public void SendPlayerWarningMessage(Player player, string message)
        {
            var newText = "[AVISO]: " + message;
            player.SendClientMessage(Color.Yellow, newText);

        }

        public void SendMessageToAll(Color textColor, string message)
        {
            _worldService.SendClientMessage(textColor, message);
        }

        #endregion

        #region Player validations

        public bool IsPlayerNearByPlayer(Player player, Player targetPlayer, float range)
        {

            return player.Interior == targetPlayer.Interior &&
                player.VirtualWorld == targetPlayer.VirtualWorld &&
                player.IsInRangeOfPoint(range, targetPlayer.Position);
        }

        public bool IsPlayerNearByVehicle(Player player, Vehicle targetVehicle, float range)
        {
            return player.VirtualWorld == targetVehicle.VirtualWorld &&
                 player.IsInRangeOfPoint(range, targetVehicle.Position);

        }

        public bool IsPlayerNearByAnyVehicle(Player player, float range)
        {
            // Pego todos os veículos do jogo e recebo uma lista de Vehicle na variável vehicles
            var vehicles = _entityManager.GetComponents<Vehicle>();

            // Filtra essa lista e devolve um booleano true se encontrar algum item da lista que satisfaça a condição o IsInRangeOfPoint
            return vehicles.Any(x => player.IsInRangeOfPoint(range, x.Position));

        }

        public bool CheckPlayerGlobalExecutionTimeAvailability(UserComponent userComponent, double time = 40)
        {
            var player = userComponent.GetComponent<Player>();

            if (!(DateTime.Now - userComponent.SessionProperties.GlobalExecutionTimeControl > TimeSpan.FromSeconds(time)))
            {
                var tempoRestante = (int)(TimeSpan.FromSeconds(time) - (DateTime.Now - userComponent.SessionProperties.ExecutionTimeControl)).TotalSeconds;
                if (tempoRestante == 0) return true;
                SendPlayerServerMessage(player, $"Aguarde {tempoRestante}s para usar este comando.");
                return false;
            }

            userComponent.SessionProperties.GlobalExecutionTimeControl = DateTime.Now;

            return true;
        }

        public bool CheckPlayerLocalExecutionTimeAvailability(UserComponent userComponent, double time = 40)
        {
            var player = userComponent.GetComponent<Player>();

            if (!(DateTime.Now - userComponent.SessionProperties.ExecutionTimeControl > TimeSpan.FromSeconds(time)))
            {
                var tempoRestante = (int)(TimeSpan.FromSeconds(time) - (DateTime.Now - userComponent.SessionProperties.ExecutionTimeControl)).TotalSeconds;
                if (tempoRestante == 0) return true;
                SendPlayerServerMessage(player, $"Aguarde {tempoRestante}s para usar este comando.");
                return false;
            }

            userComponent.SessionProperties.ExecutionTimeControl = DateTime.Now;

            return true;
        }

        #endregion
    }
}
