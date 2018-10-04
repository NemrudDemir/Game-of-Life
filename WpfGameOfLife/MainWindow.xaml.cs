using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GameOfLifeModel;

namespace WpfGameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();

        bool isStarted;
        private bool IsStarted {
            get {
                return isStarted;
            }
            set {
                isStarted = value;
                //Update buttons
                cmdStart.IsEnabled = cmdNext.IsEnabled = !isStarted;
                cmdStop.IsEnabled = isStarted;
                if (isStarted) {
                    cmdStop.Focus();
                    worker.RunWorkerAsync();
                } else
                    cmdStart.Focus();
            }
        }
        private double AutoInterval;
        private GameOfLife CurrentGame;

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            NewGame();
            GameLoop();
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
        
        private void cmdNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
        
        public void NewGame()
        {
            IsStarted = false;
            CurrentGame = new GameOfLife(Convert.ToInt32(txtFieldsize.Text), txtRule.Text);
            UpdateImageComponent();
        }
        
        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            IsStarted = true;
        }

        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {
            IsStarted = false;
        }

        public void GameLoop()
        {
            var frameTimer = new HiResTimer();
            frameTimer.Start();
            while (Application.Current != null) {
                var startTime = frameTimer.ElapsedMilliseconds;
                RenderCells();
                UpdateStatistic();
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                          new Action(delegate { }));
                //while (frameTimer.ElapsedMilliseconds - startTime < 50) ;
                this.Title = string.Format("Frames: {0}", frameTimer.ElapsedMilliseconds == startTime ? "" : (1000 / (frameTimer.ElapsedMilliseconds - startTime)).ToString());
            }
        }

        private void RenderCells()
        {
            canvas.Children.Clear();
            foreach (var aliveCell in CurrentGame.Cells) {
                var rect = new System.Windows.Shapes.Rectangle {
                    Stroke = new SolidColorBrush(Colors.Black),
                    Fill = new SolidColorBrush(Colors.Black),
                    Width = canvas.ActualWidth / CurrentGame.FieldSize,
                    Height = canvas.ActualHeight / CurrentGame.FieldSize
                };
                Canvas.SetLeft(rect, aliveCell.X * canvas.ActualWidth / CurrentGame.FieldSize);
                Canvas.SetTop(rect, aliveCell.Y * canvas.ActualHeight / CurrentGame.FieldSize);
                canvas.Children.Add(rect);
            }
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addCell(e);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
                addCell(e);
        }
        
        private void addCell(MouseEventArgs e)
        {
            if (IsStarted) //Cant add cell if "auto" is active
                return;
            var boxRatio = border.Width / CurrentGame.FieldSize;
            var mPosition = e.GetPosition(canvas);
            int fieldX = (int)(mPosition.X / boxRatio);
            int fieldY = (int)(mPosition.Y / boxRatio);
            if (e.LeftButton == MouseButtonState.Pressed) {
                CurrentGame.AddCell(fieldX, fieldY);
            } else if (e.RightButton == MouseButtonState.Pressed) {
                CurrentGame.RemoveCell(fieldX, fieldY);
            }
            RenderCells(); //TODO
        }

        public void NextGeneration()
        {
            CurrentGame.NextGeneration();
        }

        private void UpdateStatistic()
        {
            lblGeneration.Content = CurrentGame.Generation;
            lblCellsAlive.Content = CurrentGame.Cells.Count();
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    isStarted = false; //stop auto on closing
        //}

        private void canvasOutside_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateImageComponent();
        }

        private void UpdateImageComponent()
        {
            border.Width = border.Height = Math.Min(canvasOutside.ActualHeight, canvasOutside.ActualWidth);
            //lblError.Text = foregroundBmp.Width < CurrentGame.FieldSize ? "Imagesize is too small." : string.Empty;
            if(CurrentGame != null)
                RenderCells();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            NextGeneration();
        }

        private void sldAutoSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int minimumInterval = 500;
            AutoInterval = minimumInterval - (sldAutoSpeed.Value * minimumInterval / 10);
        }
    }
}