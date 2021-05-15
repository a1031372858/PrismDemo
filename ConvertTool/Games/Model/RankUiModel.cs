using Prism.Mvvm;

namespace Games.Model
{
    public class RankUiModel:BindableBase
    {

        private int _viewNum;

        public int ViewNum
        {
            set => SetProperty(ref _viewNum, value);
            get => _viewNum;
        }
        private int _userId;

        public int UserId
        {
            set => SetProperty(ref _userId, value);
            get => _userId;
        }

        private int _gameId;

        public int GameId
        {
            set => SetProperty(ref _gameId, value);
            get => _gameId;
        }

        private int _rankId;

        public int RankId
        {
            set => SetProperty(ref _rankId, value);
            get => _rankId;
        }

        private int _grade;

        public int Grade
        {
            set => SetProperty(ref _grade, value);
            get => _grade;
        }

        private string _username;

        public string Username
        {
            set => SetProperty(ref _username, value);
            get => _username;
        }
    }
}