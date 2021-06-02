using Common.Bases;
using Games.Views;
using Prism.Commands;
using Prism.Ioc;

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
            Container.Resolve<CrazyAdventureView>().Show();
        }

        private void OpenSnake()
        {
            Container.Resolve<SnakeView>().Show();
        }
    }
}