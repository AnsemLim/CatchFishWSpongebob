using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;
namespace CatchFishGame
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        //create global variable
        PrivateFontCollection newFont = new PrivateFontCollection();
        bool isMute = false;
        int backgroundNumber = 1;
        List<string> backgrounds = new List<string>();
        private string text;
        private int len = 0;

        public Form1()
        {
            InitializeComponent();
            LoadAsset();
            ReadHighScore();
        }

        private void LoadAsset()
        {
            newFont.AddFontFile("assets/font/Pixel_Font.TTF");
            lblHighScore.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lblTitle.Font = new Font(newFont.Families[0], 36, FontStyle.Bold);
            btnChange.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            radioButtonOff.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            radioButtonOn.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            btnExit.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            btnInfo.Font = new Font(newFont.Families[0], 24, FontStyle.Regular);
            btnLearderBoard.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            txtPlayer.Font = new Font(newFont.Families[0], 24, FontStyle.Regular);
            //load background image
            backgrounds = Directory.GetFiles("assets/backgrounds", "*.png").ToList();
            this.BackgroundImage = Image.FromFile(backgrounds[backgroundNumber]);

            txtPlayer.Text = "Player1";
            text = lblTitle.Text;
            lblTitle.Text = "";
            timer1.Start();
            lblReminded.Text = "Please enter your nick name";
            lblReminded.Hide();
        }

        private void ReadHighScore()
        {
            string readScore = File.ReadAllText(@"assets/score.txt");
            lblHighScore.Text = "High Score " + readScore;
        }

        private void LoadGameWindowEvent(object sender, EventArgs e)
        {
            String name = txtPlayer.Text;

            if (name == "")
            {
                lblReminded.Show();

            }

            else
            {
                GameWindow GameScreen = new GameWindow(name);
                GameScreen.SetSoundandBackground(isMute, backgroundNumber); //pass the value to another form

                GameScreen.Show();
                lblReminded.Hide();
                this.Hide();
            }
        }

        private void ChangeBackGroundEvent(object sender, EventArgs e)
        {
            backgroundNumber += 1;

            if (backgroundNumber > backgrounds.Count - 1)//once it reach the 7 it back to 0
            {
                backgroundNumber = 0;
            }
            this.BackgroundImage = Image.FromFile(backgrounds[backgroundNumber]);
        }

        private void SoundOffEvent(object sender, EventArgs e)
        {
            isMute = true;

        }

        private void SoundOnEvent(object sender, EventArgs e)
        {
            isMute = false;
        }

        private void LoadHighScoreMove(object sender, MouseEventArgs e)
        {
            ReadHighScore();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                lblTitle.Text = lblTitle.Text + text.ElementAt(len);
                len++;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Info InfoScreen = new Info();
            InfoScreen.SetSoundandBackground(isMute, backgroundNumber);
            InfoScreen.Show();
            this.Hide();
        }

        private void btnLearderBoard_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            result.Show();
            this.Hide();
        }
    }
}

