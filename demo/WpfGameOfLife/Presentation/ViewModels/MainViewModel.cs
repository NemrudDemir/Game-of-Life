using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GameOfLifeModel;
using WpfGameOfLife.Presentation.Components;
using Point = System.Windows.Point;

namespace WpfGameOfLife.Presentation.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private RenderTargetBitmap _bitmap;
        public RenderTargetBitmap Bitmap { get => _bitmap;
            set {
                _bitmap = value;
                RaisePropertyChangedEvent(nameof(Bitmap));
            }
        }
        private GameRule Rule { get; set; } = new GameRule("23", "3");
        public bool IsStarted { get; set; }
        public int FieldSize { get; set; } = 200;

        public string RuleString
        {
            get => string.Join("/", Rule.AliveRulesString, Rule.DeadRulesString);
            set
            {
                var rules = value.Split('/');
                Rule = new GameRule(rules.FirstOrDefault(), rules.ElementAtOrDefault(1));
            }
        }

        public string FieldSizeString { get; set; } = "200";
        private int _cellsAlive = 0;
        public int CellsAlive { 
            get => _cellsAlive; 
            set {
                _cellsAlive = value;
                RaisePropertyChangedEvent(nameof(CellsAlive));
            }
        }
        private int _generationCount = 0;
        public int GenerationCount {
            get => _generationCount;
            set {
                _generationCount = value;
                RaisePropertyChangedEvent(nameof(GenerationCount));
            }
        }
        public GameOfLife CurrentGame { get; set; }
        public ICommand NextGenCommand => new DelegateCommand(NextGeneration);
        public ICommand NewGameCommand => new DelegateCommand(NewGame);

        public ICommand MouseDownCommand => new DelegateCommand(() => MessageBox.Show("down!"));

        public MainViewModel()
        {
            NewGame();
            Render();
        }

        public void NextGeneration()
        {
            CurrentGame.NextGeneration();
            GenerationCount = CurrentGame.GenerationCount;
            CellsAlive = CurrentGame.Cells.Count();
            Render();
        }

        public void NewGame()
        {
            var rules = RuleString.Split('/');
            if (rules.Length < 2)
            {
                MessageBox.Show("The entered rule is not valid. Example of valid rule: 23/3");
                return;
            }

            FieldSize /= 2;
            IsStarted = false;
            CurrentGame = new GameOfLife(Convert.ToInt32(FieldSizeString), rules[0], rules[1]);
            Bitmap = new RenderTargetBitmap(CurrentGame.FieldSize, CurrentGame.FieldSize, 96, 96, new PixelFormat());
        }

        public void AddCell(int x, int y)
        {
            if (IsStarted) //Cant add cell if "auto" is active
                return;
            CurrentGame.AddCell(x, y);
            CellsAlive = CurrentGame.Cells.Count();
            Render();
        }

        public void RemoveCell(int x, int y)
        {
            if (IsStarted)
                return;
            CurrentGame.RemoveCell(x, y);
            CellsAlive = CurrentGame.Cells.Count();
            Render();
        }

        private void Render()
        {
            var visual = new DrawingVisual();
            using (var context = visual.RenderOpen())
            {
                foreach (var cell in CurrentGame.Cells)
                {
                    context.DrawRectangle(Brushes.Black, null, new Rect(new Point(cell.X, cell.Y), new Size(1,1)));
                }
            }

            Bitmap.Clear();
            Bitmap.Render(visual);
        }
    }
}
