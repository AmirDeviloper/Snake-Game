using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameForm : Form
    {
        private List<Player> _players;
        private Circle food, powerUp, powerDown;

        private void InitilizePlayers()
        {
            _players.Clear();
            _players.Add(new Player(1, new Point(5, 10), Brushes.DarkBlue, Brushes.Blue));
            _players.Add(new Player(2, new Point(10, 5), Brushes.DarkRed, Brushes.Red));
        }
        public GameForm()
        {
            _players = new List<Player>();


            food = new Circle();

            InitializeComponent();

            new Settings();
            InitilizePlayers();

            gameTimer.Interval = 1000 / _players[0].Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();
        }
        private void ResetAllPlayers ()
        {
            foreach (Player player in _players)
                player.PlayerRestart();
        }
        private void StartGame()
        {
            //Set settings to default
            new Settings();

            //Set game speed and start timer
            ResetAllPlayers();

            InitilizePlayers();

            UpdateScores();
            ShowMessage();
            GenerateFood();
        }

        //Generate Random Circle in Game
        private Circle GenerateRandomCircle()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            var random = new Random();
            return new Circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        //Place random food object
        private void GenerateFood()
        {
            food = GenerateRandomCircle();
        }

        private void GeneratePowerUp()
        {
            powerUp = GenerateRandomCircle();
        }

        private void GeneratePowerDown()
        {
            powerDown = GenerateRandomCircle();
        }
        
        private void ChangeDirection(int id, Keys up, Keys dw ,Keys left, Keys right)
        {
            if (Input.KeyPressed(right) && _players[id].direction != Direction.L)
                _players[id].direction = Direction.R;
            else if (Input.KeyPressed(left) && _players[id].direction != Direction.R)
                _players[id].direction = Direction.L;
            else if (Input.KeyPressed(up) && _players[id].direction != Direction.D)
                _players[id].direction = Direction.U;
            else if (Input.KeyPressed(dw) && _players[id].direction != Direction.U)
                _players[id].direction = Direction.D;
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check for Game Over
            if (Settings.GameOver)
            {
                //Check if Enter is pressed
                if (Input.KeyPressed(Keys.Enter))
                    StartGame();
            }

            else
            {
                if (Input.KeyPressed(Keys.Escape) && !Settings.Pause)
                {
                    gameTimer.Stop();
                    pauseTimer.Start();
                    Settings.Pause = true;
                    ShowMessage("بازی متوقف شده است");
                }
                else if (Input.KeyPressed(Keys.X) && !Settings.Pause)
                    GenerateFood();

                // Player 1
                ChangeDirection(0, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
                // Player 2
                ChangeDirection(1, Keys.W, Keys.S, Keys.A, Keys.D);

                MovePlayer();
            }

            pbCanvas.Invalidate();

        }

        private Rectangle CreateObject(Circle obj)
        {
            return new Rectangle(obj.X * Settings.Width,
                                      obj.Y * Settings.Height,
                                      Settings.Width, Settings.Height);
        }
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Set colour of snake

                //Draw snake
                foreach (var player in _players)
                {
                    for (int i = 0; i < player.Snake.Count; i++)
                    {
                        Brush snakeColour;       //Draw head     //Draw Body
                        snakeColour = (i == 0) ? player.HeadColor : player.BodyColor;

                        //Draw snake
                        canvas.FillEllipse(snakeColour, CreateObject(player.Snake[i]));

                        //Draw Food
                        canvas.FillEllipse(Brushes.Red, CreateObject(food));

                        //Draw Power Down
                        if (CheckScore(player, 20))
                        {
                            if (!Settings.PowerDown)
                            {
                                GeneratePowerDown();
                                Settings.PowerDown = true;
                            }

                            canvas.FillEllipse(Brushes.Blue, CreateObject(powerDown));
                        }

                        //Draw Power Up
                        else if (CheckScore(player, 30))
                        {
                            if (!Settings.PowerUp)
                            {
                                GeneratePowerUp();
                                Settings.PowerUp = true;
                            }

                            canvas.FillEllipse(Brushes.Indigo, CreateObject(powerUp));
                        }
                    }
                }
            }
        }
        private bool CheckScore(Player player,int score)
        {
            return player.Score % score == 0 && player.Score > 0;
        }
        

        private bool GetItem(Circle head, Circle item)
        {
            return head.X == item.X && head.Y == item.Y;
        }
        private void MovePlayer()
        {
            foreach (var player in _players)
            {
                for (int i = player.Snake.Count - 1; i >= 0; i--)
                {
                    //Move head
                    if (i == 0)
                    {
                        switch (player.direction)
                        {
                            case Direction.R:
                                player.Snake[i].X++;
                                break;
                            case Direction.L:
                                player.Snake[i].X--;
                                break;
                            case Direction.U:
                                player.Snake[i].Y--;
                                break;
                            case Direction.D:
                                player.Snake[i].Y++;
                                break;
                        }

                        //Get maximum X and Y Pos
                        int maxXPos = pbCanvas.Size.Width / Settings.Width;
                        int maxYPos = pbCanvas.Size.Height / Settings.Height;

                        //Detect collission with game borders.
                        if (player.Snake[i].X < 0 || player.Snake[i].Y < 0 ||
                            player.Snake[i].X >= maxXPos || player.Snake[i].Y >= maxYPos)
                            Die("مار نباید به قاب دور بازی برخورد کنه , بازی رو باختی");

                        //Detect collission with body
                        for (int j = 1; j < player.Snake.Count; j++)
                            if (player.Snake[i].X == player.Snake[j].X && player.Snake[i].Y == player.Snake[j].Y)
                                Die("مار نباید به خودش برخورد کنه , بازی رو باختی");

                        //Detect collision with food piece
                        if (GetItem(player.Snake[0], food))
                            Eat(player.ID);

                        //Detect collision with power Up
                        if (powerUp != null && GetItem(player.Snake[0], powerUp))
                        {
                            ChangeSpeed(player.ID, +3, ref powerUp);
                            Settings.PowerUp = false;
                        }

                        //Detect collision with power Up
                        if (powerDown != null && GetItem(player.Snake[0], powerDown))
                        {
                            ChangeSpeed(player.ID, -2, ref powerDown);
                            Settings.PowerDown = false;
                        }

                    }
                    else
                    {
                        //Move body
                        player.Snake[i].X = player.Snake[i - 1].X;
                        player.Snake[i].Y = player.Snake[i - 1].Y;
                    }
                }
            }
            
        }
        private void ChangeSpeed(int playerID,int speed, ref Circle powerMode)
        {
            if (_players[playerID].Speed + speed <= 0)
                return;

            _players[playerID].Speed += speed;
            gameTimer.Interval = 1000 / _players[playerID].Speed;
            powerMode = null;
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Eat(int playerID)
        {
            //Add circle to body
            int snakeCount = _players[playerID].Snake.Count;
            var circle = new Circle
            {
                X = _players[playerID].Snake[snakeCount - 1].X,
                Y = _players[playerID].Snake[snakeCount - 1].Y
            };
            _players[playerID].GrowUp(circle);

            //Update Score
            _players[playerID].Score += Settings.Points;
            UpdateScores();

            GenerateFood();
        }
        private void ShowMessage(string message = "")
        {
            lblShower.Text = message;
        }
        private void UpdateScores()
        {
            lblScore.Items.Clear();
            foreach (var player in _players)
                lblScore.Items.Add(player.ShowScore());
        }
        private void Die(string howDie)
        {
            Settings.GameOver = true;
            ShowMessage(howDie);
            UpdateScores();
        }

        private void startNewToolStrip_Click(object sender, EventArgs e)
        {
            StartGame();

        }

        private void infoToolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Snake v2.0", "info here");
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            if (Input.KeyPressed(Keys.Space) && Settings.Pause)
            {
                gameTimer.Start();
                pauseTimer.Stop();
                Settings.Pause = false;
                ShowMessage();
            }
        }
    }
}
