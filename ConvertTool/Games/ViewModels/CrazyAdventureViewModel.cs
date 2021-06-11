using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Common.Bases;
using Games.Model;

namespace Games.ViewModels
{
    public class CrazyAdventureViewModel : ViewModelBase
    {
        public readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _maxX = 40;
        private int _maxY = 10;

        public ObservableCollection<ChessboardRowModel> ChessboardRowList { set; get; }

        public ObservableCollection<ChessboardCellModel> FooterList { set; get; }
        public ObservableCollection<ChessboardCellModel> BodyList { set; get; }
        public ObservableCollection<ChessboardCellModel> RoadList { set; get; }

        protected override void RegisterProperties()
        {
            ChessboardRowList = new ObservableCollection<ChessboardRowModel>();
            FooterList = new ObservableCollection<ChessboardCellModel>();
            BodyList = new ObservableCollection<ChessboardCellModel>();
            RoadList=new ObservableCollection<ChessboardCellModel>();
        }

        protected override void Init()
        {
            for (int i = 0; i < _maxY; i++)
            {
                var row = new ChessboardRowModel();
                for (int j = 0; j < _maxX; j++)
                {
                    var cell = new ChessboardCellModel();
                    if (i == 7)
                    {
                        cell.CellBackground = "Black";
                        RoadList.Add(cell);
                    }
                    row.CellList.Add(cell);
                }
                ChessboardRowList.Add(row);
            }

            ChessboardRowList[3].CellList[6].CellBackground = "Black";
            ChessboardRowList[4].CellList[6].CellBackground = "Black";
            ChessboardRowList[4].CellList[5].CellBackground = "Black";
            ChessboardRowList[4].CellList[7].CellBackground = "Black";
            ChessboardRowList[5].CellList[6].CellBackground = "Black";
            ChessboardRowList[6].CellList[6].CellBackground = "Black";
            BodyList.Add(ChessboardRowList[3].CellList[6]);
            BodyList.Add(ChessboardRowList[4].CellList[6]);
            BodyList.Add(ChessboardRowList[4].CellList[5]);
            BodyList.Add(ChessboardRowList[4].CellList[7]);
            BodyList.Add(ChessboardRowList[5].CellList[6]);
            BodyList.Add(ChessboardRowList[6].CellList[6]);

            _timer.Tick += Move;
            _timer.IsEnabled = true;
            _timer.Interval = new TimeSpan(500000);
            _timer.Start();
        }

        private void Move(object sender, EventArgs e)
        {
            for (int i = 0; i < RoadList.Count - 1; i++)
            {
                RoadList[i].CellBackground = RoadList[i + 1].CellBackground;
            }

            RoadList[RoadList.Count - 1].CellBackground = MakeA();
            index++;
        }

        private int index = 1;

        public string MakeA()
        {
            if (index % 12 == 0|| index % 12 == 1)
            {
                return "White";
            }
            else
            {
                return "Black";
            }

        }
    }
}