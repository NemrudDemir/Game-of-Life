using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GameOfLifeModel;
using WpfGameOfLife.Presentation.ViewModels;

namespace WpfGameOfLife.Presentation.Views
{
    public partial class MainView
    {
        //TODO paint only (changed cells) if needed
        //TODO change to mvvm
        public MainViewModel Model => (MainViewModel) DataContext;

        public MainView()
        {
            InitializeComponent();
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CanvasOperation(e);
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
                CanvasOperation(e);
        }

        private void CanvasOperation(MouseEventArgs e)
        {
            var boxRatio = border.Width / Model.CurrentGame.FieldSize;
            var mPosition = e.GetPosition(image);
            var fieldX = (int)(mPosition.X / boxRatio);
            var fieldY = (int)(mPosition.Y / boxRatio);
            if (e.LeftButton == MouseButtonState.Pressed) {
                Model.AddCell(fieldX, fieldY);
            } else if (e.RightButton == MouseButtonState.Pressed) {
                Model.RemoveCell(fieldX, fieldY);
            }
        }

        private void cnvOutside_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateImageComponent();
        }

        private void UpdateImageComponent()
        {
            border.Width = border.Height = Math.Min(cnvOutside.ActualHeight, cnvOutside.ActualWidth);
        }
    }
}