using System;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class for non-player collectible items
    /// </summary>
    class Item
    {
        // Class variables
        private Rectangle canvas;
        private Rectangle displayArea;
        private readonly int size = 40;
        private readonly int xVelocity;
        public int CurrentX { get { return displayArea.X; } }
        public int CurrentY { get { return displayArea.Y; } }
        public int Size { get { return size; } }
        public Rectangle DisplayArea { get { return displayArea; } }
        private readonly Image image;
        public int ItemNum;

        // List of images to be used for items
        private Image[] images =
        {
            Image.FromFile(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\image\bomb.png"),
            Image.FromFile(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\image\skull.gif"),
            Image.FromFile(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\image\star.png"),
            Image.FromFile(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\image\star_y.png")
        };

        /// <summary>
        /// Constructor for Item class
        /// </summary>
        /// <param name="canvas">DisplayRectagle fo form</param>
        public Item(Rectangle canvas)
        {
            Random random = new Random();
            this.canvas = canvas;

            // Item height and width
            displayArea.Height = size;
            displayArea.Width = size;

            // Starting point for item
            // Randomize Y location
            displayArea.X = -5;
            displayArea.Y = random.Next(canvas.Height-size);

            // Randomize speed
            xVelocity = random.Next(-60, -20);

            // Random roll to ensure different items spawn
            int alignment = random.Next(0, 10);

            // Bad items
            if (alignment <= 6)
            {
                switch(random.Next(0,2))
                {
                    // bomb
                    case 0:
                    {
                        ItemNum = 0;
                        image = images[ItemNum];
                        break;
                    }
                    // skull
                    case 1:
                    {
                        ItemNum = 1;
                        image = images[ItemNum];
                        break;
                    }
                }
            }
            // Good items
            else
            {
                switch (random.Next(0, 9))
                {
                    // rainbow star
                    case 1:
                        {
                            ItemNum = 2;
                            image = images[2];
                            xVelocity = -60;
                            break;
                        }
                    // regular star
                    default:
                        {
                            ItemNum = 3;
                            image = images[3];
                            break;
                        }
                }
            }
            
        }

        /// <summary>
        /// Modify x axis of item, moves it towards right side of screen depending on speed of item
        /// </summary>
        public void Move()
        {
            displayArea.X -= xVelocity;
        }

        /// <summary>
        /// Draw item from image
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, displayArea);
        }
    }
}
