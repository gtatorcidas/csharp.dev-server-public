using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Domain.Entities;

namespace Torcidas.Core.Components
{

    public class UserSessionProperties {
        public bool IsLogged { get; set; } = false;

        public DateTime GlobalExecutionTimeControl { get; set; }

        public DateTime ExecutionTimeControl { get; set; }
    }

    public class UserComponent: Component
    {
        private User User { get; set; }

        public UserSessionProperties SessionProperties { get; set; } = new();

        public UserComponent(User user)
        {
            User = user;
        }

        public User GetUser()
        {
            return User;
        }

        public void UpdateUserOnComponent(User user)
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
