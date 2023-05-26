using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;

namespace CatchFishGame
{
    internal class Fish: Declare, Interface
    {

        //array of string
        string[] fishType = new string[]{"blue","green","grey","pink","purple","red","yellow"};
        string chosenFish;
        //create limit of Left and Right
        int coinFrames;
        public Image fish;
        public Fish()
        {
            limit = rand.Next(150, 200);
            moveLimit = rand.Next(10, 50);
            positionX = rand.Next(20,800);
            positionY = 380;//hide under the grass and rock

            speedX = rand.Next(-15, 15); //negative mean move to left 
            speedY = rand.Next(7, 15); //On the begining fish jump to upward and go to the sea

            chosenFish = fishType[rand.Next(0, fishType.Length)];
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

            if (isDead) // while the fish dead
            {
                speedX = 0;
                speedY = 10;
                width = 30;
                height = 30;
                coinFrames += 1;

                if (coinFrames < 7)
                {
                    fish = Image.FromFile("assets/coin/coin" +coinFrames +".gif");
                }
                else
                {
                    coinFrames = 0;
                    
                }
            }
        }
        public void AnimateFish(int speedX)
        {
            if (frames < 3 && !isDead)
            {
                frames += 1;

                fish = Image.FromFile("assets/fish/" + chosenFish + frames + ".gif");

                //if the fish facing left and looking right flipit
                if (speedX < 0)
                {
                    fish.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                else
                {
                    fish.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
            }
            else
            {
                frames = 0;
            }
        }

        public void Deadfish()
        {
            if (fish != null)
            {
                fish.Dispose(); //delete the image from the fish class
                fish = null;
                this.fish = null; //force it release rubbish collector to improve the frame rate of game
            }
        }
    }
}
