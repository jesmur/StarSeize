using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class for dragon (game protagonist)
    /// </summary>
    public class Dragon
    {
        // Class variables
        private Rectangle canvas;
        private Rectangle displayArea;
        private readonly int width = 200;
        private readonly int height = 95;
        private readonly int yVelocity = 10;
        private readonly int xVelocity = 10;
        public Rectangle DisplayArea { get { return displayArea; } }
        public enum Direction { Up, Down, Left, Right };
        private readonly Image image;

        /// <summary>
        /// Constructor for dragon class
        /// </summary>
        /// <param name="canvas">Display area object</param>
        public Dragon(Rectangle canvas)
        {
            this.canvas = canvas;
            image = Image.FromFile("C:\\Users\\nscc\\Source\\Repos\\273960-Murray-Jess\\MyGameFinal\\MyGame\\image\\green_dragon.gif");

            // Set the initial starting coordinates
            displayArea.Width = width;
            displayArea.Height = height;
            displayArea.Y = (canvas.Height / 2) - (height / 2);
            displayArea.X = canvas.Width - width;

        }

        /// <summary>
        /// Moves dragon horizontally or vertically
        /// </summary>
        /// <param name="direction">Keypress direction</param>
        public void Move(Direction direction)
        {
            if(direction == Direction.Up)
            {
                displayArea.Y = (displayArea.Y <= canvas.Top) ? displayArea.Y = canvas.Top : displayArea.Y -= yVelocity;
            }
            if (direction == Direction.Down)
            {
                int maxValue = canvas.Height - displayArea.Height;
                displayArea.Y = (displayArea.Y >= maxValue) ? displayArea.Y = maxValue : displayArea.Y += yVelocity;
            }
            else if (direction == Direction.Right)
            {
                int maxValue = canvas.Width - displayArea.Width;
                displayArea.X = (displayArea.X >= maxValue) ? displayArea.X = maxValue : displayArea.X += xVelocity;
            }
            else if (direction == Direction.Left)
            {
                int maxValue = canvas.Width - (displayArea.Width * 2);
                displayArea.X = (displayArea.X <= maxValue) ? displayArea.X = maxValue : displayArea.X -= xVelocity;
            }
        }

        /// <summary>
        /// Draw dragon from image
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, displayArea);
        }

    }
}