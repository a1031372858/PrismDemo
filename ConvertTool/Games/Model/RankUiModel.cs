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
        private long _userId;

        public long UserId
        {
            set => SetProperty(ref _userId, value);
            get => _userId;
        }

        private long _gameId;

        public long GameId
        {
            set => SetProperty(ref _gameId, value);
            get => _gameId;
        }

        private long _rankId;

        public long RankId
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