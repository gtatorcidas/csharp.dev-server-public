using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;
using Torcidas.Domain.Entities;
using Torcidas.Infra.Repositories.Interfaces;
using Torcidas.Application.Services.Interfaces;
using Torcidas.Core.Structs;

namespace Torcidas.Application.Services
{
    public class UserService : IUserService
    {

        #region Properties

        private readonly IUserRepository _userRepository;
        private readonly IGlobalManagerService _globalManagerService;
        private readonly IEntityManager _entityManager;
        private readonly ITimerService _timerService;

        #endregion

        #region Constructors

        public UserService(IUserRepository userRepository, IGlobalManagerService globalManagerService, 
            IEntityManager entityManager, ITimerService timerService)
        {
            _userRepository = userRepository;
            _globalManagerService = globalManagerService;
            _entityManager = entityManager;
            _timerService = timerService;
        }

        #endregion

        #region Entity Framework Methods

        public User GetUserByUserName(string username)
        {
           return _userRepository.GetByUserName(username);
        }

        public User CreateUser(User user)
        {
           return _userRepository.CreateUser(user);
        }

        #endregion

        #region Handlers

        public void DataCommandHandler(UserComponent user)
        {
            var player = user.GetComponent<Player>();

            var fpsComponent = player.GetComponent<FpsComponent>();

            var packetLoss = player.PacketLossPercent;

            var message = $"PING [{player.Ping}] - FPS [{fpsComponent.Fps}] - PacketLoss [{packetLoss:0.##}]";

            _globalManagerService.SendPlayerWarningMessage(player, message);
        }

        public void IdentifyComandHandler(UserComponent user, string parametro)
        {
            var player = user.GetComponent<Player>();

            if (parametro.Length > 24)
            {
                _globalManagerService.SendPlayerErrorMessage(player, MessageStruct.SearchParameterMaxSizeMessage);
                return;
            }

            player.SendClientMessage(Color.Coral, "");
            player.SendClientMessage(Color.Coral, $"Procurando por \"{parametro}\"...");

            var playersResults = _entityManager.GetComponents<UserComponent>().Where(x => x.GetUser().UserName.ToLower().Contains(parametro.ToLower())).ToList();

            for (int i = 0; i < playersResults.Count; i++)
            {
                var playerResult = playersResults[i];

                var playerResultComponent = playersResults[i].GetComponent<Player>();

                if (playerResultComponent.Score > 2)
                {
                    player.SendClientMessage($"{i + 1}. {playerResultComponent.Color}{playerResultComponent.Name} {Color.FromString("26cf0a", ColorFormat.RGB)}(Level {playerResultComponent.Score})");
                }
                else
                {
                    player.SendClientMessage($"{i + 1}. {playerResultComponent.Color}{playerResultComponent.Name} {Color.FromString("f50000", ColorFormat.RGB)}(Level {playerResultComponent.Score})");

                }

            }

            if (playersResults.Count > 0) player.SendClientMessage(Color.Azure, $"Resultado: {playersResults.Count} membro(s) encontrados.");

            else player.SendClientMessage(Color.White, MessageStruct.UserNotFoundWithParameterMessage);

        }

        public void KillMeComandHandler(UserComponent user)
        {
            var player = user.GetComponent<Player>();

            var secondsToSuicide = 5;
            var startPositionX = player.Position.X;
            var startPositionY = player.Position.Y;
            var startPositionZ = player.Position.Z;

            _globalManagerService.SendPlayerServerMessage(player, $"Aguarde sem se mover por {secondsToSuicide} segundos.");

            TimerReference? timer = null;

            timer = _timerService.Start((_) =>
            {
                if (player.Position.X != startPositionX || player.Position.Y != startPositionY || player.Position.Z != startPositionZ)
                {
                    _globalManagerService.SendPlayerErrorMessage(player, MessageStruct.YouMovedMessage);
                }
                else
                {
                    player.Health = 0;

                    player.SendClientMessage("Voce se matou!");

                    // TODO: Send Message for all players in area
                }

                _timerService.Stop(timer);

            }, TimeSpan.FromSeconds(secondsToSuicide));

        }

        public void PrivateMessageCommandHandler(UserComponent user, Player? playerTarget, string mensagem)
        {
            var player = user.GetComponent<Player>();

            if (playerTarget == null)
            {
                _globalManagerService.SendPlayerErrorMessage(player, MessageStruct.UserNotFoundMessage);
                return;
            }

            if (player.Name.Equals(playerTarget.Name))
            {
                _globalManagerService.SendPlayerErrorMessage(player, MessageStruct.ForbiddenToSendMessageToYourselfMessage);
                return;
            }

            player.SendClientMessage(Color.Yellow, $"** Enviado para {Color.LightBlue}{playerTarget.Name}: {Color.Yellow}{mensagem}");
            playerTarget.SendClientMessage(Color.Yellow, $"** Recebido de {Color.LightBlue}{player.Name}: {Color.Yellow}{mensagem}");

        }

        #endregion

    }
}
