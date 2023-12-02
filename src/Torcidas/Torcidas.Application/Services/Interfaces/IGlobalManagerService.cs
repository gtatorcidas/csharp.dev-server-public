using SampSharp.Entities.SAMP;

using Torcidas.Core.Components;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IGlobalManagerService
    {
        #region Messages
        void SendPlayerErrorMessage(Player player, string message);
        void SendPlayerServerMessage(Player player, string message);
        void SendPlayerSyntaxMessage(Player player, string message);
        void SendPlayerWarningMessage(Player player, string message);
        void SendPlayerNearByMessage(Player player, float range, Color textColor, string text);
        void SendMessageToAll(Color textColor, string text);

        #endregion

        #region Player Validations

        bool IsPlayerNearByPlayer(Player player, Player targetPlayer, float radius);

        bool CheckPlayerGlobalExecutionTimeAvailability(UserComponent user, double time = 40);

        bool CheckPlayerLocalExecutionTimeAvailability(UserComponent user, double time = 40);


        #endregion
    }
}
