using Prism.Mvvm;

namespace Games.Model
{
    public class ChessboardCellModel:BindableBase
    {
        private string _cellBackground = "#FFFFFF";
        public string CellBackground
        {
            set => SetProperty(ref _cellBackground, value);
            get => _cellBackground;
        }
    }
}