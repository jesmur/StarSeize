using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    /// <summary>
    /// Game form
    /// </summary>
    public partial class Form1 : Form
    {
        // Form variables
        private int health;
        private int score;
        private bool canRestart;

        private Dragon dragon;
        HashSet<Item> items = new HashSet<Item>();

        private Font font = new Font(FontFamily.GenericMonospace, 40);

        // Sound clips
        MciPlayer good = new MciPlayer(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\sounds\good.mp3", "1");
        MciPlayer bad = new MciPlayer(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\sounds\bad.wav", "2");
        MciPlayer theme = new MciPlayer(@"C:\Users\nscc\source\repos\273960-Murray-Jess\MyGameFinal\MyGame\sounds\we're_all_under_the_stars_eric_skiff.mp3", "3");

        /// <summary>
        /// Starting point for game
        /// </summary>
        public Form1()
        {
            // Set initial numbers and start music
            score = 0;
            health = 3;
            canRestart = false;
            theme.PlayLoop();

            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            pbHeart.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Starts timers on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            animationTimer.Enabled = true;
            itemTimer.Enabled = true;

            pbPause.BackColor = Color.Transparent;

            dragon = new Dragon(DisplayRectangle);
        }

        /// <summary>
        /// Draws all objects in game, displays current score and checks for win or loss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            dragon.Draw(e.Graphics);

            foreach (var item in items)
            {
                item.Draw(e.Graphics);
            }
            DisplayScore(e.Graphics);
            CheckGameStatus(e.Graphics);
        }

        /// <summary>
        /// Remove unwanted items, change item coordinates and check for collisions before redrawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            items.RemoveWhere(ItemMissesDragon);
            items.RemoveWhere(ItemCollidesWithDragon);

            foreach (var item in items)
            {
                item.Move();
            }
            foreach (var item in items)
            {
                CheckForCollision(item);
            }
            Invalidate();
        }

        /// <summary>
        /// Waits for keypress to move dragon, pause game or start new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Movement
                case Keys.Up:
                    {
                        dragon.Move(Dragon.Direction.Up);
                        break;
                    }
                case Keys.Down:
                    {
                        dragon.Move(Dragon.Direction.Down);
                        break;
                    }
                case Keys.Left:
                    {
                        dragon.Move(Dragon.Direction.Left);
                        break;
                    }
                case Keys.Right:
                    {
                        dragon.Move(Dragon.Direction.Right);
                        break;
                    }
                // Pause or unpause game
                case Keys.Space:
                    {
                        if (!animationTimer.Enabled)
                        {
                            animationTimer.Start();
                            itemTimer.Start();
                            pbPause.Visible = false;
                        }
                        else if (animationTimer.Enabled)
                        {
                            animationTimer.Stop();
                            itemTimer.Stop();
                            pbPause.Visible = true;
                        }
                        break;
                    }
                // Start new game if game over
                case Keys.Return:
                    {
                        if (canRestart)
                        {
                            animationTimer.Start();
                            itemTimer.Start();
                            score = 0;
                            health = 3;
                            canRestart = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///  Timer to add a new item after a period of time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemTimer_Tick(object sender, EventArgs e)
        {
            items.Add(new Item(DisplayRectangle));
        }

        /// <summary>
        /// Check if item has passed dragon to later remove it from list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ItemMissesDragon(Item item)
        {
            return (item.CurrentX >= DisplayRectangle.Right);
        }

        /// <summary>
        /// Check if item has collided with dragon to later remove it from list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ItemCollidesWithDragon(Item item)
        {
            return (dragon.DisplayArea.IntersectsWith(item.DisplayArea));
        }

        /// <summary>
        /// Checks for collision, plays appropriate sound and modify appropriate status
        /// </summary>
        /// <param name="item">Item object from HashSet</param>
        private void CheckForCollision(Item item)
        {
            if (dragon.DisplayArea.IntersectsWith(item.DisplayArea))
            {
                if (item.ItemNum == 0 || item.ItemNum == 1)
                {
                    bad.PlayFromStart();
                    health -= 1;
                }
                else if (item.ItemNum == 2)
                {
                    good.PlayFromStart();
                    score += 5;
                }
                else if (item.ItemNum == 3)
                {
                    good.PlayFromStart();
                    score += 1;
                }
            }
        }

        /// <summary>
        /// Check the status of the game for win or loss
        /// If win or loss, display appropriate message
        /// </summary>
        /// <param name="graphics"></param>
        private void CheckGameStatus(Graphics graphics)
        {
            // If loss
            if (health == 0)
            {
                // Pause movement
                StopTimers();

                // Allow user to restart
                canRestart = true;

                // Display lose message
                string message = String.Format("\t   You Lost!\nPress 'Enter' to Play Again");
                graphics.DrawString(message, font, Brushes.PaleGoldenrod, 200, 300);

                // Remove all items in current HashSet
                items.Clear();
            }
            // If win
            else if (score >= 20)
            {
                // Pause movement
                StopTimers();

                //Allow user to restart
                canRestart = true;

                // Display win message
                string message = String.Format("\t   You Won!\nPress 'Enter' to Play Again");
                graphics.DrawString(message, font, Brushes.PaleGoldenrod, 200, 300);

                // Remove all items in current HashSet
                items.Clear();
            }
        }

        /// <summary>
        /// Stops animation and item spawn timer
        /// </summary>
        private void StopTimers()
        {
            animationTimer.Stop();
            itemTimer.Stop();
        }

        /// <summary>
        /// Display health and score to user
        /// </summary>
        /// <param name="graphics"></param>
        private void DisplayScore(Graphics graphics)
        {
            // Display current health
            string hpDisplay = String.Format("{0}", health);
            graphics.DrawString(hpDisplay, font, Brushes.PaleGoldenrod, 60, 0);

            // Display running score
            string scoreDisplay = String.Format("Score:{0}", score);
            graphics.DrawString(scoreDisplay, font, Brushes.PaleGoldenrod, 0, 60);

        }
    }
}
