using Common.Enums;
using Games.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Games.Views
{
    /// <summary>
    /// SnakeView.xaml 的交互逻辑
    /// </summary>
    public partial class SnakeView : Window
    {
        public SnakeView()
        {
            InitializeComponent();
        }

        private void SnakeView_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is SnakeViewModel vm)
            {
                switch (vm.GameStatus)
                {
                    case Constants.GameStatus.Init:
                        if (e.Key == Key.Space)
                        {
                            vm.GameStatus = Constants.GameStatus.Running;
                        }
                        break;
                    case Constants.GameStatus.Running:
                        if (e.Key == Key.Space)
                        {
                            vm.GameStatus = Constants.GameStatus.Pause;
                        }
                        else
                        {
                            SnakeMove(e.Key);
                        }
                        break;
                    case Constants.GameStatus.Pause:
                        if (e.Key == Key.Space)
                        {
                            vm.GameStatus = Constants.GameStatus.Running;
                        }
                        break;
                    case Constants.GameStatus.End:
                        if (e.Key == Key.Space)
                        {
                            vm.GameStatus = Constants.GameStatus.Init;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void SnakeMove(Key key)
        {
            if (DataContext is SnakeViewModel vm)
            {
                if (key == Key.Up)
                {
                    if (vm.RunDirection != Constants.SnakeDirection.Down )
                    {
                        vm.NextDirection = Constants.SnakeDirection.Up;
                        if(vm.SnakeMove())return;
                        vm._timer.Stop();
                        vm._timer.Start();
                    }
                }
                else if (key == Key.Down)
                {
                    if (vm.RunDirection != Constants.SnakeDirection.Up)
                    {
                        vm.NextDirection = Constants.SnakeDirection.Down;
                        if (vm.SnakeMove()) return;
                        vm._timer.Stop();
                        vm._timer.Start();
                    }
                }
                else if (key == Key.Left)
                {
                    if (vm.RunDirection != Constants.SnakeDirection.Right)
                    {
                        vm.NextDirection = Constants.SnakeDirection.Left;
                        if (vm.SnakeMove()) return;
                        vm._timer.Stop();
                        vm._timer.Start();
                    }
                }
                else if (key == Key.Right)
                {
                    if (vm.RunDirection != Constants.SnakeDirection.Left)
                    {
                        vm.NextDirection = Constants.SnakeDirection.Right;
                        if (vm.SnakeMove()) return;
                        vm._timer.Stop();
                        vm._timer.Start();
                    }
                }

            }
        }
    }
}
