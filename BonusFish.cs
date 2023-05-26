using System.Drawing;
namespace CatchFishGame
{
    class BonusFish : Declare, Interface
    {
        int DeadFishFrame;
        public Image bonusFish;

        public BonusFish()
        {
            limit = rand.Next(150, 200);
            moveLimit = rand.Next(10, 50);
            positionX = rand.Next(20, 900);
            positionY = 300;//hide under the grass and rock

            speedX = rand.Next(-15, 15); //negative mean move to left 
            speedY = 9; //On the begining fish jump to upward and go to the sea
            AnimateFish(speedX);
        }
        public void MoveFish()
        {
            moveLimit -= 1; //reduce by 1

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

            if (isDead) // while the fish dead
            {
                speedX = 0;
                speedY = 10;
                width = 50;
                height = 50;
                DeadFishFrame += 1;

                if (DeadFishFrame < 4)
                {
                    bonusFish = Image.FromFile("assets/DeadFish/DeadBonus" + DeadFishFrame + ".gif");
                }
                else
                {
                    DeadFishFrame = 0;
                }
            }
        }
        public void AnimateFish(int speedX)
        {
            if (frames < 3 && !isDead)
            {
                frames += 1;
                bonusFish = Image.FromFile("assets/BonusFish/BonusFish" + frames + ".gif");
                //bonusFish = Image.FromFile("assets/BonusFish/" + frames + ".gif");

                //if the fish facing left and looking right flipit
                if (speedX < 0)
                {
                    bonusFish.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                else
                {
                    bonusFish.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
            }
            else
            {
                frames = 0;
            }
        }

        public void Deadfish()
        {
            if (bonusFish != null)
            {
                bonusFish.Dispose(); //delete the image from the fish class
                bonusFish = null;
                this.bonusFish = null; //force it release rubbin collector to improve the frame rate of game
            }
        }
    }

}
