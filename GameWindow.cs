using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;
using Timer = System.Windows.Forms.Timer;

namespace CatchFishGame
{
    public partial class GameWindow : Form
    {
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        WindowsMediaPlayer fishEffect = new WindowsMediaPlayer();
        WindowsMediaPlayer collectCoin = new WindowsMediaPlayer();
        OleDbConnection con = new OleDbConnection(Properties.Resources.ConnectionString);

        List<string> backgrounds = new List<string>();
        List<Fish> currentFishs = new List<Fish>();
        List<Poop> currentPoops = new List<Poop>();
        List<BonusFish> currentBonusFish = new List<BonusFish>();
        int[] fishSizes = { 60, 65, 70, 75, 80 }; //create variaty of fish size

        Image foreground;
        Image fishicon;
        Image neticon;
        Image clockicon;

        float countDownTime = 30;
        int net = 10;
        int score = 0;
        int extraTime = 0;
        int highScore = 0;
        int tempTime = 0; //set the time for fish respawn
        int spawnTime = 5;

        //create extra bullet  
        int combolimit = 5;
        public int combo = 0; //end of bullet
        Random rand = new Random();

        //create label
        Label lblScore = new Label();
        Label lblAmmo = new Label();
        Label lblTime = new Label();

        //Timer for count down
        Timer GameTimer = new Timer();
        PrivateFontCollection newFont = new PrivateFontCollection();

        //Why not picturebox, picturebox are not that good on transparent and overlapping, however image class does not have any event,exp mouseover
        Image crossHair;
        //create choosing point 
        Point choosingPoint = new Point();
        Point recLoc = new Point(); //relocation point
        bool gameOver = false;
        string Name;
        public GameWindow(string name)
        {
            InitializeComponent();
            SetUpGame();

            Thread insertFish = new Thread(SpawnFish);
            Thread insertBonus = new Thread(SpawnBonusFish);
            Thread insertPoop = new Thread(SpawnPoop);

            insertFish.Start();
            insertPoop.Start();
            insertBonus.Start();

            Name = name;
        }
        //create custom function
        public void SetUpGame()
        {
            backgrounds = Directory.GetFiles("assets/backgrounds", "*.png").ToList();
            this.Height = 600;
            this.Width = 960;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //assign the variable with transparent image
            foreground = Image.FromFile("assets/foreground/foreground.png");
            crossHair = Image.FromFile("assets/crosshair/netcrosshair.png");
            fishicon = Image.FromFile("assets/icon/fishicon.png");
            neticon = Image.FromFile("assets/icon/neticon.png");
            clockicon = Image.FromFile("assets/icon/pixelclock.png");

            SetUpLabel(lblScore);
            SetUpLabel(lblAmmo);
            SetUpLabel(lblTime);

            //Why declare the position here not under the function, because location and text are different 
            lblScore.Location = new Point(60, 520);
            lblAmmo.Location = new Point(800, 510);
            lblTime.Location = new Point(380, 510);

            lblScore.Text = "x0";
            lblAmmo.Text = "10x";
            lblTime.Text = "30.00s Remaining";

            //Add the declared label to the form
            this.Controls.Add(lblScore);
            this.Controls.Add(lblAmmo);
            this.Controls.Add(lblTime);


            //
            GameTimer.Interval = 20;
            GameTimer.Start();
            GameTimer.Tick += GameTimerEvent;

            //To draw the graphic on this form exp fish foreground background
            this.Paint += DrawGraphics;
            this.MouseMove += FormMouseMoveEvent;
            this.Click += FormMouseDownEvent; //to identified click on the fish
            this.FormClosed += OnWindowClosedEvent;

            ReadHighScore();
        }

        private void OnWindowClosedEvent(object sender, FormClosedEventArgs e)
        {
            if (fishEffect != null && backgroundMusic != null)
            {
                fishEffect.controls.stop();
                backgroundMusic.controls.stop();
                collectCoin.controls.stop();

                fishEffect = null;
                backgroundMusic = null;
                collectCoin = null;
                GameTimer.Stop();
                this.Dispose();
            }
            else
            {
                GameTimer.Stop();
                this.Dispose();
            }
        }

        private void FormMouseDownEvent(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                foreach (Fish fish in currentFishs)
                {
                    MouseEventArgs mouse = (MouseEventArgs)e;
                    if (mouse.X >= fish.positionX && mouse.Y >= fish.positionY && mouse.X <= fish.positionX + fish.width && mouse.Y <= fish.positionY + fish.height)
                    {
                        fish.isDead = true;
                        score++;
                        combo++;
                    }
                }
                foreach (BonusFish bonusFish in currentBonusFish)
                {
                    MouseEventArgs mouse = (MouseEventArgs)e;
                    if (mouse.X >= bonusFish.positionX && mouse.Y >= bonusFish.positionY && mouse.X <= bonusFish.positionX + bonusFish.width && mouse.Y <= bonusFish.positionY + bonusFish.height)
                    {
                        bonusFish.isDead = true;
                        score = score + 2;
                        countDownTime = countDownTime + 2;
                        extraTime = extraTime + 2;
                        combo++;
                    }
                }
                foreach (Poop poop in currentPoops)
                {
                    MouseEventArgs mouse = (MouseEventArgs)e;
                    if (mouse.X >= poop.positionX && mouse.Y >= poop.positionY && mouse.X <= poop.positionX + poop.width && mouse.Y <= poop.positionY + poop.height)
                    {
                        poop.isDead = true;
                        score -= 1;
                    }
                }
                if (fishEffect != null)
                {
                    fishEffect.controls.play();
                }
                net -= 1;
            }
        }

        private void FormMouseMoveEvent(object sender, MouseEventArgs e)
        {
            recLoc.X = (recLoc.X + e.X) - choosingPoint.X;
            recLoc.Y = (recLoc.Y + e.Y) - choosingPoint.Y;
            choosingPoint = e.Location; //location of the mouse
        }

        private void DrawGraphics(object sender, PaintEventArgs e)
        {
            foreach (Fish tmpfish in currentFishs)
            {
                e.Graphics.DrawImage(tmpfish.fish, tmpfish.positionX, tmpfish.positionY, tmpfish.width, tmpfish.height);
            }
            foreach (BonusFish tmpbonusFish in currentBonusFish)
            {
                e.Graphics.DrawImage(tmpbonusFish.bonusFish, tmpbonusFish.positionX, tmpbonusFish.positionY, tmpbonusFish.width, tmpbonusFish.height);
            }
            foreach (Poop tmpPoop in currentPoops)
            {
                e.Graphics.DrawImage(tmpPoop.poop, tmpPoop.positionX, tmpPoop.positionY, tmpPoop.width, tmpPoop.height);
            }
            e.Graphics.DrawImage(fishicon, 10, 510, 50, 40);
            e.Graphics.DrawImage(clockicon, 320, 510, 50, 50);
            e.Graphics.DrawImage(neticon, 900, 510, 50, 50);
            e.Graphics.DrawImage(foreground, -15, 270, 980, 230);
            e.Graphics.DrawImage(crossHair, recLoc.X - (crossHair.Width / 2), recLoc.Y - (crossHair.Height / 2));

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {

            countDownTime -= 0.1f; //float
            lblTime.Text = countDownTime.ToString("#.#") + "s Remaining";
            lblScore.Text = "x" + score;
            lblAmmo.Text = net + "x";

            //animate the fish
            foreach (BonusFish bonusFish in currentBonusFish.ToList())
            {
                bonusFish.MoveFish();
                bonusFish.AnimateFish(bonusFish.speedX);

                bonusFish.positionX += bonusFish.speedX;
                if (bonusFish.positionX < 10 || bonusFish.positionX + bonusFish.width > 940 && bonusFish.isDead == false)
                {
                    bonusFish.speedX = -bonusFish.speedX;
                    bonusFish.bonusFish.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                bonusFish.positionY += bonusFish.speedY;
                if (bonusFish.positionY < 10 || bonusFish.positionY + bonusFish.height > 450 && bonusFish.isDead == false)
                {
                    bonusFish.speedY = -bonusFish.speedY;
                }
                if (bonusFish.isDead)
                {
                    if (bonusFish.positionY > 420)
                    {
                        bonusFish.Deadfish();
                        currentBonusFish.Remove(bonusFish);
                        if (collectCoin != null)
                        {
                            collectCoin.controls.play();//play the collect coin sound 
                        }

                    }
                }
            }
            foreach (Fish fish in currentFishs.ToList())
            {
                fish.MoveFish();
                fish.AnimateFish(fish.speedX);

                fish.positionX += fish.speedX;
                //create the left and right border for the fish so it would go out of the border
                if (fish.positionX < 10 || fish.positionX + fish.width > 940 && fish.isDead == false)
                {
                    fish.speedX = -fish.speedX;
                    fish.fish.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                fish.positionY += fish.speedY;
                if (fish.positionY < 15 || fish.positionY + fish.height > 450 && fish.isDead == false)
                {
                    fish.speedY = -fish.speedY;
                }

                if (fish.isDead)
                {
                    if (fish.positionY > 420)
                    {
                        fish.Deadfish();
                        currentFishs.Remove(fish);

                        if (collectCoin != null)
                        {
                            collectCoin.controls.play();//play the collect coin sound 
                        }

                    }
                }
            }
            foreach (Poop poop in currentPoops.ToList())
            {
                poop.MoveFish();
                poop.AnimateFish(poop.speedX);

                poop.positionX += poop.speedX;
                //create the left and right border for the fish so it would go out of the border
                if (poop.positionX < 10 || poop.positionX + poop.width > 940 && poop.isDead == false)
                {
                    poop.speedX = -poop.speedX;
                    poop.poop.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                poop.positionY += poop.speedY;
                if (poop.positionY < 15 || poop.positionY + poop.height > 450 && poop.isDead == false)
                {
                    poop.speedY = -poop.speedY;
                }

                if (poop.isDead)
                {
                    if (poop.positionY > 420)
                    {
                        poop.Deadfish();
                        currentPoops.Remove(poop);

                        if (collectCoin != null)
                        {
                            collectCoin.controls.play();//play the collect coin sound 
                        }

                    }
                }
            }
            if (combo > combolimit)
            {
                net += 5;
                combo = 0;
            }

            if (currentFishs.Count < 15)
            {
                tempTime -= 1;
                if (tempTime < 0)
                {

                    AddFish();
                    tempTime = spawnTime;
                }
            }
            if (currentBonusFish.Count < 1)
            {
                tempTime -= 1;
                if (tempTime < 0)
                {
                    AddBonusFish();
                    tempTime = spawnTime;
                }
            }
            if (currentPoops.Count < 3)//if left than 7 add bew fish
            {
                tempTime -= 1;
                if (tempTime < 0)
                {
                    AddPoop();
                    tempTime = spawnTime;
                }
            }
            //check net
            //check time
            if (countDownTime < 0 || net < 1)
            {
                GameOver();

            }
            this.Invalidate();
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

                fishEffect.URL = "assets/sound/catch_fish_sound.mp3";
                fishEffect.uiMode = "invisible";
                fishEffect.settings.volume = 50;
                fishEffect.controls.stop(); //not playing on the start

                collectCoin.URL = "assets/sound/coin_collect.mp3";
                collectCoin.uiMode = "invisible";
                collectCoin.settings.volume = 50;
                collectCoin.controls.stop();
            }
            else
            {
                backgroundMusic = null;
                fishEffect = null;
                collectCoin = null;
            }
            this.BackgroundImage = Image.FromFile(backgrounds[bg]); //What even the bg number other screen provide will pass in here
        }

        public void AddFish()
        {
            int i = rand.Next(0, fishSizes.Length); //rand bewteen 0 to 80
            Fish newFish = new Fish();
            newFish.width = fishSizes[i];
            newFish.height = newFish.width - 10;
            currentFishs.Add(newFish);
        }
        public void AddBonusFish()
        {
            BonusFish bonusFish = new BonusFish();
            bonusFish.width = 100;
            bonusFish.height = bonusFish.width - 10;
            currentBonusFish.Add(bonusFish);
        }

        public void AddPoop()
        {
            Poop poop = new Poop();
            poop.width = 55;
            poop.height = poop.width - 10;
            currentPoops.Add(poop);
        }

        public void SetUpLabel(Label lbl)
        {
            newFont.AddFontFile("assets/font/Pixel_Font.TTF");
            lbl.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
            lbl.ForeColor = Color.Yellow;
            lbl.BackColor = Color.Transparent;
            lbl.AutoSize = false;
            lbl.Height = 100;
            lbl.Width = 250;
        }

        public void GameOver()//stop the game,check high score, set new high score,
        {
            gameOver = true;
            GameTimer.Stop();

            if ((score > highScore))
            {
                Cursor.Show();
                highScore = score;
                string newScore = highScore.ToString();
                File.WriteAllText(@"assets/score.txt", newScore);
                MessageBox.Show("Woo Hoo! you set a new high Score, its: " + score, "Spongebob says: ");
            }
            else
            {
                Cursor.Show();
                MessageBox.Show("GAME OVER! Your Score: " + score + "Try to beat the score." + highScore, "Spongebob SAYS:");
            }
            con.Open();
            OleDbCommand com1 = con.CreateCommand();
            com1.CommandText = "INSERT INTO [Player]([PlayerName],[Score],[ExtraTime]) VALUES ('" + Name + "','" + score + "','" + extraTime + "')";
            com1.ExecuteNonQuery();
            con.Close();
            Result result = new Result();
            result.Show();
            this.Close();
        }

        public void ReadHighScore()
        {
            string readScore = File.ReadAllText(@"assets/score.txt");
            highScore = int.Parse(readScore); //CONVERT TO INT
        }

        public void SpawnFish()
        {
            for (int i = 0; i < 20; i++) //stable is below 50
            {
                AddFish();
                Thread.Sleep(0);
            }

        }
        public void SpawnBonusFish()
        {
            for (int i = 0; i < 2; i++)
            {
                AddBonusFish();
                Thread.Sleep(0);
            }

        }

        public void SpawnPoop()
        {
            for (int i = 0; i < 3; i++)
            {
                AddPoop();
                Thread.Sleep(0);
            }
        }
    }
}