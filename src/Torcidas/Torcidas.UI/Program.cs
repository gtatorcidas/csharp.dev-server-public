using SampSharp.Core;
using SampSharp.Entities;

namespace Torcidas.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            new GameModeBuilder()
                .RedirectConsoleOutput()
                .UseEcs<Startup>()
                .Run();
        }
    }
}
