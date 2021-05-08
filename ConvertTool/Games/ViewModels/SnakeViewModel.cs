using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using Common.Bases;
using Games.Model;

namespace Games.ViewModels
{
    public class SnakeViewModel:ViewModelBase
    {
        private readonly Timer _timer=new Timer();

        private int _grade;
        public int Grade
        {
            set => SetProperty(ref _grade, value);
            get => _grade;
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

        protected override void RegisterProperties()
        {
            ChessboardRowList = new ObservableCollection<ChessboardRowModel>();
            SnakeList = new ObservableCollection<ChessboardCellModel>();
        }

        protected override void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var row = new ChessboardRowModel();
                for (int j = 0; j < 10; j++)
                {
                    row.CellList.Add(new ChessboardCellModel());
                }
                ChessboardRowList.Add(row);
            }
            SnakeList.Add(ChessboardRowList[0].CellList[0]);
            SnakeList.Add(ChessboardRowList[0].CellList[1]);
            SnakeList.Add(ChessboardRowList[0].CellList[2]);
            HeaderIndexY = 0;
            HeaderIndexX = 2;
            foreach (var item in SnakeList)
            {
                item.CellBackground = "#000000";
            }
            var random = new Random();
            var y = random.Next(0, 10);
            var x=random.Next(0, 10);
            Food = ChessboardRowList[y].CellList[x];
            while (SnakeList.Any(o=>o==Food))
            {
                y = random.Next(0, 10);
                x = random.Next(0, 10);
                Food = ChessboardRowList[y].CellList[x];
            }
            Food.CellBackground = "Green";
            _timer.Interval = 500;
            _timer.Start();
            _timer.Elapsed+=SnakeMove;
        }

        private void SnakeMove(object sender, ElapsedEventArgs e)
        {
            try
            {
                HeaderIndexX++;
                if (HeaderIndexX < 0 || HeaderIndexX >= 10)
                {
                    _timer.Stop();
                    return;
                }
                SnakeList.Add(ChessboardRowList[HeaderIndexY].CellList[HeaderIndexX]);
                ChessboardRowList[HeaderIndexY].CellList[HeaderIndexX].CellBackground = "#000000";
                SnakeList[0].CellBackground = "#FFFFFF";
                SnakeList.RemoveAt(0);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                _timer.Stop();
            }
        }

    }
}