using SampSharp.Entities;
using System.Globalization;
using SampSharp.Entities.SAMP;

using Torcidas.Core.Utils;

namespace Torcidas.Core.Components.Server
{
    public class ServerHudComponent: Component
    {
        public List<PlayerTextDraw> ServerHudTextDraws { get; } = new();

        private PlayerTextDraw AnnouceTextDraw;
        
        public void SetupBoxTextDraw(PlayerTextDraw textDraw)
        {
            
            textDraw.UseBox = true;
            textDraw.BackColor = 255;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Normal;
            textDraw.TextSize = new Vector2(700, 0);
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.LetterSize = new Vector2(0, -3.333329);
            textDraw.BoxColor = CustomColorsUtils.WhiteTransparent;

            ServerHudTextDraws.Add(textDraw);

        }
        public void SetupDateTimeTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Outline = 1;
            textDraw.BoxColor = 50;
            textDraw.BackColor = 80;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim; 
            textDraw.TextSize = new Vector2(658, 17);
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.LetterSize = new Vector2(0.216664, 0.849999);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupWebsiteTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.BoxColor = 50;
            textDraw.BackColor = 80;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.TextSize = new Vector2(400, 17);
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.LetterSize = new Vector2(0.204163, 0.899999);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupEquipBrandTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.Proportional = true;
            textDraw.BackColor = 0x00000075;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.LetterSize = new Vector2(0.240887, 0.908399);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupBlankTextDraw(PlayerTextDraw textDraw, int foreColor = 0)
        {
            if (foreColor != 0)
            {
                textDraw.ForeColor = foreColor;
            }
            
            textDraw.Outline = 1;
            textDraw.BackColor = 0;
            textDraw.BoxColor = 50;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.TextSize = new Vector2(400, 17);
            textDraw.LetterSize = new Vector2(10.020831, 1);

            ServerHudTextDraws.Add(textDraw);
        }
        
        public void SetupDynamicAnnouncementTextDraw(PlayerTextDraw textDraw)
        {
            AnnouceTextDraw = textDraw;
            AnnouceTextDraw.Outline = 1;
            AnnouceTextDraw.BackColor = 255;
            AnnouceTextDraw.Proportional = true;
            AnnouceTextDraw.ForeColor = 0xFFA500EE;
            AnnouceTextDraw.Font = TextDrawFont.Pricedown;
            AnnouceTextDraw.Alignment = TextDrawAlignment.Left;
            AnnouceTextDraw.TextSize = new Vector2(700, 0);
            AnnouceTextDraw.LetterSize = new Vector2(0.230663, 0.798575);

        }
        public void SetupPaydayTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.TextSize = new Vector2(400, 17);
            textDraw.LetterSize = new Vector2(0.141666, 0.899999);
            textDraw.BackColor = Color.FromInteger(255, ColorFormat.ARGB);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupYearsOldTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.BackColor= 80;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.TextSize = new Vector2(712, 17);
            textDraw.LetterSize = new Vector2(0.204163, 0.899999);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupServerNameTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Outline = 1;
            textDraw.BoxColor = 50;
            textDraw.BackColor = 255;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Pricedown;
            textDraw.Alignment = TextDrawAlignment.Left;
            textDraw.TextSize = new Vector2(690.50, 17);
            textDraw.LetterSize = new Vector2(0.479166, 1.85);
            
            ServerHudTextDraws.Add(textDraw);
        }
        public void SetupPlayersCountTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.BoxColor = 50;
            textDraw.BackColor = 80;
            textDraw.Proportional = true;
            textDraw.Font = TextDrawFont.Slim;
            textDraw.TextSize = new Vector2(658, 232);
            textDraw.Alignment = TextDrawAlignment.Center;
            textDraw.LetterSize = new Vector2(0.216664, 0.849999);
            
            ServerHudTextDraws.Add(textDraw);
        }

        public void SetupPlayerLevelTextDraw(PlayerTextDraw textDraw)
        {
            textDraw.Shadow = 0;
            textDraw.Shadow = 0;
            textDraw.Outline = 1;
            textDraw.BackColor = 64;
            textDraw.Proportional = true;
            textDraw.Alignment = TextDrawAlignment.Center;
            textDraw.LetterSize = new Vector2(0.273988, 1.291535);

            ServerHudTextDraws.Add(textDraw);
        }

        public void ShowServerHudTextDraws()
        {
            ServerHudTextDraws.ForEach(textDraw => textDraw.Show());
            AnnouceTextDraw.Show();
        }

        public void ShowServerHudAnnounceTextDraw() => AnnouceTextDraw.Show();
        
        public void HideServerHudTextDraws() => ServerHudTextDraws.ForEach(textDraw => textDraw.Hide());

        public void RemoveServerHudTextDraws() => ServerHudTextDraws.RemoveAll(textDraw => { textDraw.Destroy(); return true; });
        
        
        public void UpdatePlayerCountTextDrawTicker(int onlinePlayers, int maxPlayers)
        {
            var playerTextDraw = ServerHudTextDraws.First(x => x.Text.Contains("Players:"));

            playerTextDraw.Text = $"Players: {onlinePlayers}/{maxPlayers}";
        }
        
        public void UpdateDateTimeTextDrawTicker()
        {
           var playerTextDraw = ServerHudTextDraws.First(x => DateTime.TryParseExact(x.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _));

            playerTextDraw.Text = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            
        }
        
        public void UpdatePaydayTextDrawTicker(int userPayday)
        {
            var playerTextDraw = ServerHudTextDraws.First(x => x.Text.Contains("Proximo payday em:"));

            var remainingSeconds =  TimeSpan.FromHours(1).TotalSeconds - userPayday;
            
            var timeSpan = TimeSpan.FromSeconds(remainingSeconds);

            playerTextDraw.Text = $"Proximo payday em: {timeSpan.Minutes:00}M {timeSpan.Seconds:00}s";
        }

        public void UpdateLevelTextDrawTicker(int userLevel)
        {
            var playerTextDraw = ServerHudTextDraws.First(x => x.Text.Contains("Level"));

            playerTextDraw.Text = $"Level {userLevel}";

        }
        
    }
}