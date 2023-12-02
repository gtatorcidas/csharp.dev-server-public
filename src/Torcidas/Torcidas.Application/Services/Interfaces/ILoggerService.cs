namespace Torcidas.Application.Services.Interfaces
{
    public interface ILoggerService
    {

        void LogParciais(string message);

        void LogCadastros(string prefix, string message);
    }
}
