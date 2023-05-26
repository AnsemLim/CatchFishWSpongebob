using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace CatchFishGame
{
    public partial class Info : Form
    {
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        List<string> backgrounds = new List<string>();
        PrivateFontCollection newFont = new PrivateFontCollection();

        public Info()
        {
            InitializeComponent();
            LoadAsset();
            Thread setLabel = new Thread(SetLable);
            setLabel.Start();
        }

        public void LoadAsset()
        {
            backgrounds = Directory.GetFiles("assets/backgrounds", "*.png").ToList();
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }
        public void SetLable()
        {
            newFont.AddFontFile("assets/font/Pixel_Font.TTF");
            lblControl.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lblIcon.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lblJellyFish.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lblBonus.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lblPoop.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            btnBack.Font = new Font(newFont.Families[0], 20, FontStyle.Bold);
            lblTips.Font = new Font(newFont.Families[0], 20, FontStyle.Bold);
        }
        public void SetSoundandBackground(bool isMute, int bg)//when is function run need to put in bool and int
        {
            if (!isMute)
            {
                backgroundMusic.URL = "assets/sound/SpongeBobMusic.mp3";
                backgroundMusic.uiMode = "invisible";
                backgroundMusic.settings.volume = 30;
                backgroundMusic.settings.setMode("loop", true);
                backgroundMusic.controls.play();
            }
            else
            {
                backgroundMusic = null;
            }

            this.BackgroundImage = Image.FromFile(backgrounds[bg]); //What even the bg number other screen provide will pass in here
        }

        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            if (backgroundMusic != null)
            {
                backgroundMusic.controls.stop();
                backgroundMusic = null;
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
