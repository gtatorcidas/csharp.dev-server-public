using System.Text;
using SampSharp.Core;
using SampSharp.Entities;

namespace Torcidas.UI
{
    public class Program
    {

        /// <summary>
        /// O ponto de entrada principal para a aplicação.
        /// Este método configura e inicia um GameMode usando um padrão de design Builder.
        /// A saída do console é redirecionada, um sistema de entidades componentes (ECS) é usado com a classe Startup,
        /// e a codificação é definida para Windows-1252.
        /// </summary>
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            new GameModeBuilder()
                .RedirectConsoleOutput()
                .UseEcs<Startup>()
                .UseEncoding(Encoding.GetEncoding(1252))
                .Run();
        }
    }
}
