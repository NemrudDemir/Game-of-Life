using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using GameOfLifeModel;

namespace WpfGameOfLife
{
    public partial class MainWindow
    {
        //TODO paint only (changed cells) if needed
        //TODO change to mvvm
        private BackgroundWorker Worker { get; } = new BackgroundWorker(); //TODO change to async

        bool _isStarted;
        private bool IsStarted {
            get => _isStarted;
            set {
                _isStarted = value;
                //Update buttons
                cmdStart.IsEnabled = cmdNext.IsEnabled = !_isStarted;
                cmdStop.IsEnabled = _isStarted;
                if (_isStarted) {
                    cmdStop.Focus();
                    Worker.RunWorkerAsync();
                } else
                    cmdStart.Focus();
            }
        }
        private double AutoInterval { get; set; }
        private GameOfLife CurrentGame { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Worker.DoWork += Worker_DoWork;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            NewGame();
            GameLoop();
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
        
        private void cmdNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
        
        public void NewGame()
        {
            var rules = txtRule.Text.Split('/');
            if (rules.Length < 2) {
                MessageBox.Show("The entered rule is not valid. Example of valid rule: 23/3");
                return;
            }

            IsStarted = false;
            CurrentGame = new GameOfLife(Convert.ToInt32(txtFieldSize.Text), rules[0], rules[1]);
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
                if (Application.Current.Dispatcher != null)
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                        new Action(delegate { }));
                var elapsed = frameTimer.ElapsedMilliseconds - startTime;
                if(elapsed != 0)
                    Title = $"Frames: {1000 / elapsed}";
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
            AddCell(e);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
                AddCell(e);
        }
        
        private void AddCell(MouseEventArgs e)
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
            lblGeneration.Content = CurrentGame.GenerationCount;
            lblCellsAlive.Content = CurrentGame.Cells.Count();
        }

        private void cnvOutside_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateImageComponent();
        }

        private void UpdateImageComponent()
        {
            border.Width = border.Height = Math.Min(cnvOutside.ActualHeight, cnvOutside.ActualWidth);
            if(CurrentGame != null)
                RenderCells();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            NextGeneration();
        }

        private void sldAutoSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            const int minimumInterval = 500;
            AutoInterval = minimumInterval - (sldAutoSpeed.Value * minimumInterval / 10);
        }
    }
}