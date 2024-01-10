namespace Torcidas.Core.Utils
{
    public static class TaskUtilities
    {
        public static Task SetTimeout(Action action, int milliseconds)
        {
            return Task.Run(async () =>
            {
                await Task.Delay(milliseconds);
                action();
            });
        }
    }
}
