using Common.Bases;
using Prism.Commands;

namespace Games.ViewModels
{
    public class GamesViewModel:ViewModelBase
    {
        public DelegateCommand OpenSnakeCommand { set; get; }
        public DelegateCommand OpenGame2Command { set; get; }

        protected override void Init()
        {
            base.Init();
        }

        protected override void RegisterCommands()
        {
            OpenSnakeCommand=new DelegateCommand(OpenSnake);
            OpenGame2Command=new DelegateCommand(OpenGame2);
        }

        private void OpenGame2()
        {
            // DialogService.ShowDialog();
        }

        private void OpenSnake()
        {

        }
    }
}