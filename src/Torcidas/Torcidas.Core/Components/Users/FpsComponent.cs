using System.Diagnostics;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace Torcidas.Core.Components.Users
{
    public class FpsComponent : Component
    {
        public int Fps { get; set; }

        public int LastDrunkLevel { get; set; }

        public PlayerTextDraw FpsTextDraw { get; set; }

        public Stopwatch Timer { get; set; } = new();

        public void SetupFpsTextDraw(PlayerTextDraw fpsTextDraw)
        {

            FpsTextDraw = fpsTextDraw;
            FpsTextDraw.Shadow = 0;
            FpsTextDraw.Outline = 1;
            FpsTextDraw.Proportional = true;
            FpsTextDraw.ForeColor = Color.White;
            FpsTextDraw.Font = TextDrawFont.Pricedown;
            FpsTextDraw.Alignment = TextDrawAlignment.Left;
            FpsTextDraw.LetterSize = new Vector2(0.5, 1.6);

            FpsTextDraw.Show();

        }

        public void RemoveFpsTextDraw()
        {
            FpsTextDraw.Destroy();
        }

        public void HideFpsTextDraw() => FpsTextDraw.Hide();
        
        public void ShowFpsTextDraw() => FpsTextDraw.Show();
        
    }
}
