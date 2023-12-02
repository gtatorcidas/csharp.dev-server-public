using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Core.DTOs;

namespace Torcidas.Core.Components
{
    public class UserComponent: Component
    {
        private UserDTO User { get; set; }

        public bool IsLogged { get; set; }

        public bool HasLegacyPassword { get; set; }

        public DateTime GlobalExecutionTimeControl { get; set; }

        public DateTime ExecutionTimeControl { get; set; }

        public DateTime GangExpulsionTime { get; set; }

        public bool HasIndicator {  get; set; }

        public UserComponent(UserDTO user)
        {
            User = user;
            IsLogged = false;
        }

        public UserDTO GetUser()
        {
            return User;
        }

        public void UpdateUserOnComponent(UserDTO user)
        {
            User = user;
        }

        public MessageDialog SetupMessageDialog(string caption, string content, string closeLabel = "Fechar")
        {
            return new MessageDialog(caption, content, closeLabel);
        }

        public ListDialog SetupListInformationsDialog(string caption, string closeLabel = "Fechar")
        {
            return new ListDialog(caption, closeLabel);
        }

    }
}
