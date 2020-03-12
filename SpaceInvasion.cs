using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace SpaceInvasion
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] enemyMunition;
        int enemiesMunitionSpeed;

        // picturebox is an array that holds pictures in this case star like dots
        PictureBox[] stars;
        int backgroundspeed;
        int playerSpeed;

        PictureBox[] munitions;
        int MunitionSpeed;

        PictureBox[] enemy;
        int enemiSpeed;

        Random rnd;

        int score;
        int level;
        int dificulty;
        bool pause;
        bool gameIsOver;

        // initiates the form window
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pause = false;
            gameIsOver = false;
            score = 0;
            level = 1;
            dificulty = 9;

            backgroundspeed = 4; // controls speed for stars in the background
            playerSpeed = 4;
            enemiSpeed = 4;
            MunitionSpeed = 20;
            enemiesMunitionSpeed = 4;
            munitions = new PictureBox[3];

            // Load images
            Image munition = Image.FromFile(@"asserts\munition.png");

            Image enemi1 = Image.FromFile("asserts\\E1.png");
            Image enemi2 = Image.FromFile("asserts\\E2.png");
            Image enemi3 = Image.FromFile("asserts\\E3.png");

            Image boss1 = Image.FromFile("asserts\\Boss1.png");
            Image boss2 = Image.FromFile("asserts\\Boss2.png");

            enemy = new PictureBox[10];

            // Initialiase EnemisPictureBoxes
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new PictureBox();
                enemy[i].Size = new Size(30, 30);
                enemy[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemy[i].BorderStyle = BorderStyle.None;
                enemy[i].Visible = false;
                enemy[i].Location = new Point((i + 1) * 30, -50);
                this.Controls.Add(enemy[i]);
                
            }

            enemy[0].Image = boss1;
            enemy[1].Image = enemi2;
            enemy[2].Image = enemi3;
            enemy[3].Image = enemi3;
            enemy[4].Image = enemi1;
            enemy[5].Image = enemi3;
            enemy[6].Image = enemi2;
            enemy[7].Image = enemi3;
            enemy[8].Image = enemi2;
            enemy[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            // Create WMP
            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            // Load all songs
            gameMedia.URL = "songs\\GameSong.mp3";
            shootgMedia.URL = "songs\\shoot.mp3";
            explosion.URL = "songs\\boom.mp3";

            //Setup Songs settings
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootgMedia.settings.volume = 1;
            explosion.settings.volume = 6;

            stars = new PictureBox[15]; // reserve 15 slots
            rnd = new Random(); // instantiate an object that generates random number

            for (int i = 0; i < stars.Length; i++) // length = 10
            {
                // create 10 stars in one compelte iteration
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 600), rnd.Next(-10, 500)); // place stars at random points (X,Y)

                // if the number is ODD, do the following
                if (i%2 == 1)
                {
                    stars[i].Size = new Size(2,2); // controls size of stars W*H
                    stars[i].BackColor = Color.Wheat; // and color
                }
                // if the number is EVEN do the following
                else
                {
                    stars[i].Size = new Size(3, 3); // controls size of stars W*H
                    stars[i].BackColor = Color.DarkGray; // and color
                }

                this.Controls.Add(stars[i]);
            }

            // Enemis Munition
            enemyMunition = new PictureBox[10];

            for (int i = 0; i < enemyMunition.Length; i++)
            {
                enemyMunition[i] = new PictureBox();
                enemyMunition[i].Size = new Size(2, 25);
                enemyMunition[i].Visible = false;
                enemyMunition[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemyMunition[i].Location = new Point(enemy[x].Location.X, enemy[x].Location.Y - 20);
                this.Controls.Add(enemyMunition[i]);
            }
            gameMedia.controls.play();
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length/2; i++) // i = 5
            {
                stars[i].Top += backgroundspeed; // Top - Gets or Sets the distance in pixels

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = 0; i < stars.Length; i++) // i = 10
            {
                stars[i].Top += backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < (this.Width-Player.Width+10))
            {
                Player.Left += playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < (this.Height - Player.Image.Height))
            {
                Player.Top += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label.Location = new Point(137, 100);
                        label.Text = "PAUSED";
                        label.AutoSize = true;
                        label.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;

                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 10, Player.Location.Y - i * 30); // place the munition in the middle of the spacecraft
                }
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemy, enemiSpeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemy[i].Bounds) || munitions[1].Bounds.IntersectsWith(enemy[i].Bounds) || munitions[2].Bounds.IntersectsWith(enemy[i].Bounds))
                {
                    explosion.controls.play();

                    score += 1;
                    scorelbl.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiSpeed <= 10 && enemiesMunitionSpeed <= 10 && dificulty >= 0)
                        {
                            dificulty--;
                            enemiSpeed++;
                            enemiesMunitionSpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver();
                        }
                    }
                    enemy[i].Location = new Point((i + 1) * 50, -100);
                }

                if (Player.Bounds.IntersectsWith(enemy[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            label.Text = "Game Over";
            label.AutoSize = true;
            label.Location = new Point((this.Width / 2) - (label.Width / 2), 50);
            label.Visible = true;
            ReplayBtn.Visible = true;
            ExitBtn.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        // stop Timers
        private void StopTimers()
        {
            MoveBgTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveMunitionTimer.Stop();
            EnemiesMunitionTimer.Stop();
        }

        // Start Timers
        private void StartTimers()
        {
            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();
            MoveMunitionTimer.Start();
            EnemiesMunitionTimer.Start();
        }

        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (enemyMunition.Length - dificulty); i++)
            {
                if (enemyMunition[i].Top < this.Height)
                {
                    enemyMunition[i].Visible = true;
                    enemyMunition[i].Top += enemiesMunitionSpeed;
                    CollisionWithEnemisMunition();
                }
                else
                {
                    enemyMunition[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemyMunition[i].Location = new Point(enemy[x].Location.X + 20, enemy[x].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemisMunition()
        {
            for (int i = 0; i < enemyMunition.Length; i++)
            {
                if (enemyMunition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemyMunition[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver();
                }
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);

            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
        }
    }
}
