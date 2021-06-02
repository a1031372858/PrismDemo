using System.Collections.ObjectModel;
using Common.Bases;
using Games.Model;

namespace Games.ViewModels
{
    public class CrazyAdventureViewModel:ViewModelBase
    {
        private int _maxX = 40;
        private int _maxY = 10;

        public ObservableCollection<ChessboardRowModel> ChessboardRowList { set; get; }

        protected override void RegisterProperties()
        {
            ChessboardRowList=new ObservableCollection<ChessboardRowModel>();
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
                    }
                    row.CellList.Add(cell);
                }
                ChessboardRowList.Add(row);
            }

            ChessboardRowList[3].CellList[6].CellBackground = "Black";
            ChessboardRowList[4].CellList[6].CellBackground="Black";
            ChessboardRowList[4].CellList[5].CellBackground = "Black";
            ChessboardRowList[4].CellList[7].CellBackground = "Black";
            ChessboardRowList[5].CellList[6].CellBackground = "Black";
            ChessboardRowList[6].CellList[6].CellBackground = "Black";
        }

    }
}