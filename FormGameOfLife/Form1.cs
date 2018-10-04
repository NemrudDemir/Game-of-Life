using GameOfLifeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGameOfLife
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Bitmap bmp;
        Graphics grph;

        BackgroundWorker worker = new BackgroundWorker();

        bool isStarted;
        private bool IsStarted {
            get {
                return isStarted;
            }
            set {
                isStarted = value;
                //Update buttons
                cmdStart.Enabled = cmdNext.Enabled = !isStarted;
                cmdStop.Enabled = isStarted;
                if (isStarted) {
                    cmdStop.Focus();
                    worker.RunWorkerAsync();
                } else
                    cmdStart.Focus();
            }
        }
        private int AutoInterval;
        private GameOfLife CurrentGame;

        public Form1()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            HiResTimer timer = new HiResTimer();
            timer.Start();
            while (IsStarted) {
                var startTime = timer.ElapsedMilliseconds;
                NextGeneration();
                while (timer.ElapsedMilliseconds - startTime < AutoInterval) ;
            }
        }

        private void cmdNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        public void NewGame()
        {
            IsStarted = false;
            CurrentGame = new GameOfLife((int)numFieldsize.Value, txtRule.Text);
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

        //long interval = (long)TimeSpan.FromSeconds((double)1 / 1000).TotalMilliseconds;
        public void GameLoop()
        {
            var frameTimer = new HiResTimer();
            frameTimer.Start();
            while (this.Created) {
                var startTime = frameTimer.ElapsedMilliseconds;
                RenderCells();
                UpdateStatistic();
                Application.DoEvents();
                //while (timer.ElapsedMilliseconds - startTime < interval) ;
                this.Text = string.Format("Frames: {0}", frameTimer.ElapsedMilliseconds == startTime ? "" : (1000 / (frameTimer.ElapsedMilliseconds - startTime)).ToString());
            }
        }

        private void RenderCells()
        {
            imgGame.Image = new Bitmap(bmp);
            grph.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            var ratio = (float)bmp.Width / CurrentGame.FieldSize;
            foreach (var aliveCell in CurrentGame.Cells)
                grph.FillRectangle(Brushes.Black, aliveCell.X * ratio, aliveCell.Y * ratio, ratio, ratio);
            //var ratio = (float)foregroundBmp.Width / backgroundBmp.Width;
            //if (ratio >= 4) { //draw cell-boxes into the image if the size per box is big enough
            //    var pen = new Pen(Color.FromArgb(30, Color.Gray));
            //    for (int xy = 0; xy < CurrentGame.FieldSize; xy++) {
            //        foregroundGrph.DrawLine(pen, 0, xy * ratio, foregroundBmp.Width, xy * ratio); //horizontal
            //        foregroundGrph.DrawLine(pen, xy * ratio, 0, xy * ratio, foregroundBmp.Height); //vertical
            //    }
            //}
            imgGame.Image = bmp;
        }

        private void imgGame_MouseDown(object sender, MouseEventArgs e)
        {
            addCell(e);
        }

        private void imgGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                return;
            addCell(e);
        }

        private void addCell(MouseEventArgs e)
        {
            if (IsStarted) //Cant add cell if "auto" is active
                return;
            var boxRatio = (double)bmp.Width / CurrentGame.FieldSize;
            int fieldX = (int)(e.X / boxRatio);
            int fieldY = (int)(e.Y / boxRatio);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStarted = false; //stop auto on closing
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
            bmp = new Bitmap(imgGame.Width - 2, imgGame.Height - 2); //subtract 2 for each border-line on the edges
            grph = Graphics.FromImage(bmp);
            grph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            grph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            lblWarning.Text = bmp.Width < CurrentGame.FieldSize ? "Imagesize is too small." : string.Empty;
            RenderCells();
        }

        private void trcAutoSpeed_ValueChanged(object sender, EventArgs e)
        {
            int minimumInterval = 500;
            AutoInterval = minimumInterval - (trcAutoSpeed.Value * minimumInterval / 10);
        }
    }

}
