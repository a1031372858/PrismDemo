using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using Common.Bases;
using Common.Enums;
using Common.Global;
using Common.Utility;
using Games.Model;
using Games.Views;
using Prism.Commands;
using Prism.Ioc;
using SqlData;
using SqlData.Beans;


namespace Games.ViewModels
{
    public class SnakeViewModel : ViewModelBase
    {
        public readonly DispatcherTimer _timer = new DispatcherTimer();

        private int _maxX = 20;

        private int _maxY = 20;
        private int _nextGrade;

        private int _grade;
        public int Grade
        {
            set => SetProperty(ref _grade, value);
            get => _grade;
        }

        private Constants.GameStatus _gameStatus = Constants.GameStatus.Init;
        public Constants.GameStatus GameStatus
        {
            set
            {
                if (value == _gameStatus) return;
                switch (value)
                {
                    case Constants.GameStatus.Init:
                        ReStart();
                        break;
                    case Constants.GameStatus.Running:
                        _timer.Start();
                        break;
                    case Constants.GameStatus.Pause:
                        _timer.Stop();
                        break;
                    case Constants.GameStatus.End:
                        _timer.Stop();
                        break;
                    default:
                        ShowMessage("游戏状态异常");
                        Console.WriteLine(value);
                        return;
                }
                SetProperty(ref _gameStatus, value);
            }
            get => _gameStatus;
        }

        private Constants.SnakeDirection _runDirection;
        public Constants.SnakeDirection RunDirection
        {
            set => SetProperty(ref _runDirection, value);
            get => _runDirection;
        }

        private Constants.SnakeDirection _nextDirection;
        public Constants.SnakeDirection NextDirection
        {
            set => SetProperty(ref _nextDirection, value);
            get => _nextDirection;
        }

        public ObservableCollection<ChessboardRowModel> ChessboardRowList { set; get; }

        private ChessboardCellModel _food;
        public ChessboardCellModel Food
        {
            set => SetProperty(ref _food, value);
            get => _food;
        }
        public ObservableCollection<ChessboardCellModel> SnakeList { set; get; }

        private int _headerIndexX;
        public int HeaderIndexX
        {
            set => SetProperty(ref _headerIndexX, value);
            get => _headerIndexX;
        }

        private int _headerIndexY;
        public int HeaderIndexY
        {
            set => SetProperty(ref _headerIndexY, value);
            get => _headerIndexY;
        }

        public DelegateCommand UploadCommand { set; get; }
        public DelegateCommand ShowRankViewCommand { set; get; }
        public DelegateCommand LoginCommand { set; get; }
        

        protected override void RegisterProperties()
        {
            ChessboardRowList = new ObservableCollection<ChessboardRowModel>();
            SnakeList = new ObservableCollection<ChessboardCellModel>();
        }

        protected override void RegisterCommands()
        {
            UploadCommand = new DelegateCommand(Upload); 
             ShowRankViewCommand = new DelegateCommand(ShowRankView);
        }


        protected override void Init()
        {
            for (int i = 0; i < _maxY; i++)
            {
                var row = new ChessboardRowModel();
                for (int j = 0; j < _maxX; j++)
                {
                    row.CellList.Add(new ChessboardCellModel());
                }
                ChessboardRowList.Add(row);
            }

            _timer.Tick += SnakeMove;
            _timer.IsEnabled = true;
            ReStart();


        }

        public void SnakeMove(object sender, EventArgs e)
        {
            SnakeMove();
        }

        public bool SnakeMove()
        {
            try
            {
                RunDirection = NextDirection;
                switch (RunDirection)
                {
                    case Constants.SnakeDirection.Up:
                        HeaderIndexY--;
                        break;
                    case Constants.SnakeDirection.Down:
                        HeaderIndexY++;
                        break;
                    case Constants.SnakeDirection.Left:
                        HeaderIndexX--;
                        break;
                    case Constants.SnakeDirection.Right:
                        HeaderIndexX++;
                        break;
                    default:
                        break;
                }

                if (HeaderIndexY < 0 || HeaderIndexY >= _maxY ||
                    HeaderIndexX < 0 || HeaderIndexX >= _maxX)
                {
                    _timer.Stop();
                    GameStatus = Constants.GameStatus.End;
                    return false;
                }
                var nextCell = ChessboardRowList[HeaderIndexY].CellList[HeaderIndexX];
                if (SnakeList.Contains(nextCell))
                {
                    _timer.Stop();
                    GameStatus = Constants.GameStatus.End;
                    return false;
                }

                nextCell.CellBackground = "#000000";
                SnakeList.Add(nextCell);
                if (Food != nextCell)
                {
                    SnakeList[0].CellBackground = "#FFFFFF";
                    SnakeList.RemoveAt(0);
                }
                else
                {
                    Grade += _nextGrade;
                    if (SnakeList.Count == 10)
                    {
                        _nextGrade = 150;
                        _timer.Interval = new TimeSpan(3000000);
                    }
                    if (SnakeList.Count == 15)
                    {
                        _nextGrade = 200;
                        _timer.Interval = new TimeSpan(2500000);
                    }
                    if (SnakeList.Count == 20)
                    {
                        _nextGrade = 300;
                        _timer.Interval = new TimeSpan(2000000);
                    }
                    if (SnakeList.Count == 30)
                    {
                        _nextGrade = 500;
                        _timer.Interval = new TimeSpan(1000000);
                    }
                    MakeFood();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                _timer.Stop();
            }

            return true;
        }

        private void ReStart()
        {
            _timer.Stop();
            SnakeList.Clear();
            Grade = 0;
            _nextGrade = 100;
            foreach (var row in ChessboardRowList)
            {
                foreach (var cell in row.CellList)
                {
                    cell.CellBackground = "#FFFFFF";
                }
            }

            RunDirection = Constants.SnakeDirection.Right;
            NextDirection = Constants.SnakeDirection.Right;

            SnakeList.Add(ChessboardRowList[0].CellList[0]);
            SnakeList.Add(ChessboardRowList[0].CellList[1]);
            SnakeList.Add(ChessboardRowList[0].CellList[2]);
            HeaderIndexY = 0;
            HeaderIndexX = 2;
            foreach (var item in SnakeList)
            {
                item.CellBackground = "#000000";
            }


            _timer.Interval = new TimeSpan(4000000);
            MakeFood();
        }

        private void MakeFood()
        {
            var random = new Random();
            var y = random.Next(0, _maxY);
            var x = random.Next(0, _maxX);
            Food = ChessboardRowList[y].CellList[x];

            while (SnakeList.Any(o => o == Food))
            {
                y = random.Next(0, _maxY);
                x = random.Next(0, _maxX);
                Food = ChessboardRowList[y].CellList[x];
            }
            Food.CellBackground = "Green";


        }

        private void Upload()
        {
            if (GlobalData.LoginUser == null)
            {
                ShowMessage("登录失效，请重新登录");
                return;
            }
            var sqlContext = Container.Resolve<PostgreSqlContext>();

            var rankId = 0;
            if (sqlContext.Rank.Any())
            {
                rankId = sqlContext.Rank.Max(o => o.RankId);
            }
            var rank = new Rank()
            {
                RankId = ++rankId,
                Grade = Grade,
                UserId = GlobalData.LoginUser.UserId,
                GameId = 1,
            };
            sqlContext.Rank.Add(rank);
            sqlContext.SaveChangesAsync();
            ShowMessage("上传成功!");
            GameStatus = Constants.GameStatus.Init;
        }


        private void ShowRankView()
        {
            var view =Container.Resolve<GameRankView>();
            view.ShowDialog();
        }
    }


}