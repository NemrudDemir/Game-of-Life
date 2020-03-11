using GameOfLifeModel;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormGameOfLife
{
    public partial class Form1 : Form
    {
        //TODO paint only (changed cells) if needed
        private Bitmap Bmp { get; set; }
        private Graphics Graphics { get; set; }
        private BackgroundWorker Worker { get; } = new BackgroundWorker(); //TODO change to async

        private bool _isStarted;
        private bool IsStarted {
            get => _isStarted;
            set {
                _isStarted = value;
                //Update buttons
                cmdStart.Enabled = cmdNext.Enabled = !_isStarted;
                cmdStop.Enabled = _isStarted;
                if (_isStarted) {
                    cmdStop.Focus();
                    Worker.RunWorkerAsync();
                } else
                    cmdStart.Focus();
            }
        }
        private int AutoInterval { get; set; }
        private GameOfLife CurrentGame { get; set; }

        public Form1()
        {
            InitializeComponent();
            Worker.DoWork += Worker_DoWork;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var timer = new HiResTimer();
            timer.Start();
            while (IsStarted) {
                var startTime = timer.ElapsedMilliseconds;
                NextGeneration();
                while (timer.ElapsedMilliseconds - startTime < AutoInterval) { }
            }
        }

        private void cmdNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        public void NewGame()
        {
            var rules = txtRule.Text.Split('/');
            if (rules.Length < 2)
            {
                MessageBox.Show("The entered rule is not valid. Example of valid rule: 23/3");
                return;
            }

            IsStarted = false;
            CurrentGame = new GameOfLife((int)numFieldsize.Value, rules[0], rules[1]);
            UpdateImageComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            IsStarted = true;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            IsStarted = false;
        }

        public void GameLoop()
        {
            var frameTimer = new HiResTimer();
            frameTimer.Start();
            while (Created) {
                var startTime = frameTimer.ElapsedMilliseconds;
                RenderCells();
                UpdateStatistic();
                Application.DoEvents();
                var elapsed = frameTimer.ElapsedMilliseconds - startTime;
                if(elapsed != 0)
                    Text = $"Frames: {1000 / elapsed}";
            }
        }

        private void RenderCells()
        {
            imgGame.Image = new Bitmap(Bmp);
            Graphics.FillRectangle(Brushes.White, 0, 0, Bmp.Width, Bmp.Height);
            var ratio = (float)Bmp.Width / CurrentGame.FieldSize;
            foreach (var aliveCell in CurrentGame.Cells)
                Graphics.FillRectangle(Brushes.Black, aliveCell.X * ratio, aliveCell.Y * ratio, ratio, ratio);
            imgGame.Image = Bmp;
        }

        private void imgGame_MouseDown(object sender, MouseEventArgs e)
        {
            AddCell(e);
        }

        private void imgGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                return;
            AddCell(e);
        }

        private void AddCell(MouseEventArgs e)
        {
            if (IsStarted) //Cant add cell if "auto" is active
                return;
            var boxRatio = (double)Bmp.Width / CurrentGame.FieldSize;
            var fieldX = (int)(e.X / boxRatio);
            var fieldY = (int)(e.Y / boxRatio);
            if (e.Button == MouseButtons.Left) {
                CurrentGame.AddCell(fieldX, fieldY);
            } else if (e.Button == MouseButtons.Right) {
                CurrentGame.RemoveCell(fieldX, fieldY);
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        public void NextGeneration()
        {
            CurrentGame.NextGeneration();
        }

        private void UpdateStatistic()
        {
            lblGeneration.Text = CurrentGame.Generation.ToString();
            lblAliveCells.Text = CurrentGame.Cells.Count().ToString();
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            UpdateImageComponent();
        }

        private void UpdateImageComponent()
        {
            imgGame.Width = imgGame.Height = Math.Min(panel.Width, panel.Height);
            if (Math.Min(panel.Width, panel.Height) < 5)
                return;
            Bmp = new Bitmap(imgGame.Width - 2, imgGame.Height - 2); //subtract 2 for each border-line on the edges
            Graphics = Graphics.FromImage(Bmp);
            Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            lblWarning.Text = Bmp.Width < CurrentGame.FieldSize ? "Image size is too small." : string.Empty;
            RenderCells();
        }

        private void trcAutoSpeed_ValueChanged(object sender, EventArgs e)
        {
            const int minimumInterval = 500;
            AutoInterval = minimumInterval - (trcAutoSpeed.Value * minimumInterval / 10);
        }
    }

}
