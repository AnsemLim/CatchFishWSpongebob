using System.Drawing;

namespace CatchFishGame
{
    class Poop : Declare, Interface
    {
        string[] poopType = new string[] { "ERRORPOOP", "RAINBOWPOOP", "TOXICPOOP" };
        string chosenPoop;
        int OppsFrame;
        public Image poop;
        public Poop()
        {
            limit = rand.Next(150, 200);
            moveLimit = rand.Next(10, 50);
            positionX = rand.Next(20, 900);
            positionY = 380;//hide under the grass and rock

            speedX = rand.Next(-15, 15); //negative mean move to left 
            speedY = 9; //On the begining fish jump to upward and go to the sea

            chosenPoop = poopType[rand.Next(0, poopType.Length)];
            AnimateFish(speedX);
        }
        public void MoveFish()
        {
            moveLimit -= 1; //reduce by 1 the fish

            if (moveLimit < 0 && !isDead)//while the fish alive
            {

                // if speed x is less than 0 the fish is moving left it will switch it to the right
                if (speedX < 0) //control left and right
                {
                    speedX = rand.Next(5, 10);
                }
                else
                {
                    speedX = rand.Next(-10, -5);//if not move it to the left
                }

                if (speedY < 0 && !isDead) //up and down
                {
                    speedY = rand.Next(5, 10);
                }
                else
                {
                    speedY = rand.Next(-10, -5);
                }
                moveLimit = rand.Next(80, limit);
            }

            if (isDead)
            {
                speedX = 0;
                speedY = 10;
                width = 70;
                height = 70;
                OppsFrame += 1;

                if (OppsFrame < 2)
                {
                    poop = Image.FromFile("assets/opps/opps" + OppsFrame + ".gif");
                }
                else
                {
                    OppsFrame = 0;
                }
            }
        }
        public void AnimateFish(int speedX)
        {
            if (frames < 4 && !isDead)
            {
                frames += 1;

                poop = Image.FromFile("assets/poopslip/" + chosenPoop + frames + ".gif");

                if (speedX < 0)
                {
                    poop.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                else
                {
                    poop.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
            }
            else
            {
                frames = 0;
            }
        }

        public void Deadfish()
        {
            if (poop != null)
            {
                poop.Dispose(); //delete the image from the fish class
                poop = null;
                this.poop = null; //force it release rubbin collector to improve the frame rate of game
            }
        }
    }
}
