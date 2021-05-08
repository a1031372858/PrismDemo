using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Games.Model
{
    public class ChessboardRowModel:BindableBase
    {
        public ObservableCollection<ChessboardCellModel> CellList { set; get; } = new ObservableCollection<ChessboardCellModel>();


    }
}