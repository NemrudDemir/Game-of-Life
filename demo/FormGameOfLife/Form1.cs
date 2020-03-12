using GameOfLifeModel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGameOfLife
{
    public partial class Form1 : Form
    {
        //TODO paint only (changed cells) if needed
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
                } else
                    cmdStart.Focus();
            }
        }
        private int AutoInterval { get; set; }
        private GameOfLife CurrentGame { get; set; }

        public Form1()
        {
            InitializeComponent();
            NewGame();
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
            UpdateUi();
        }

        private async void cmdStart_Click(object sender, EventArgs e)
        {
            IsStarted = true;
            var timer = new HiResTimer();
            timer.Start();
            while (IsStarted)
            {
                var startTime = timer.ElapsedMilliseconds;
                NextGeneration();
                var timeToSleep = AutoInterval - (int)(timer.ElapsedMilliseconds - startTime);
                if (timeToSleep < 0)
                    timeToSleep = 0;
                await Task.Delay(timeToSleep);
            }
        }

        private void UpdateUi()
        {
            imgGame.Invalidate();
            UpdateStatistic();
            Application.DoEvents();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            IsStarted = false;
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
            var boxRatio = (double)imgGame.Width / CurrentGame.FieldSize;
            var fieldX = (int)(e.X / boxRatio);
            var fieldY = (int)(e.Y / boxRatio);
            if (e.Button == MouseButtons.Left) {
                CurrentGame.AddCell(fieldX, fieldY);
            } else if (e.Button == MouseButtons.Right) {
                CurrentGame.RemoveCell(fieldX, fieldY);
            }

            UpdateUi();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        public void NextGeneration()
        {
            CurrentGame.NextGeneration();
            UpdateUi();
        }

        private void UpdateStatistic()
        {
            lblGeneration.Text = CurrentGame.GenerationCount.ToString();
            lblAliveCells.Text = CurrentGame.Cells.Count().ToString();
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            UpdateImageComponent();
        }

        private void UpdateImageComponent()
        {
            if (CurrentGame == null || Math.Min(panel.Width, panel.Height) < 5)
                return;
            imgGame.Width = imgGame.Height = Math.Min(panel.Width, panel.Height);

            lblWarning.Text = imgGame.Width < CurrentGame.FieldSize ? "Image size is too small." : string.Empty;
        }

        private void trcAutoSpeed_ValueChanged(object sender, EventArgs e)
        {
            const int minimumInterval = 500;
            AutoInterval = minimumInterval - (trcAutoSpeed.Value * minimumInterval / 10);
        }

        private void imgGame_Paint(object sender, PaintEventArgs e)
        {
            if (!(sender is Control control))
                return;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.FillRectangle(Brushes.White, 0, 0, control.Width, control.Height);
            var ratio = (float)control.Width / CurrentGame.FieldSize;
            foreach (var aliveCell in CurrentGame.Cells)
                e.Graphics.FillRectangle(Brushes.Black, aliveCell.X * ratio, aliveCell.Y * ratio, ratio, ratio);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmdStop.PerformClick(); //Stop game loop
        }
    }

}
