using System.Collections.ObjectModel;
using Common.Bases;
using Games.Model;
using Prism.Ioc;
using SqlData;

namespace Games.ViewModels
{
    public class GameRankViewModel:ViewModelBase
    {
        private ObservableCollection<RankUiModel> _rankList=new ObservableCollection<RankUiModel>();

        public ObservableCollection<RankUiModel> RankList
        {
            set => SetProperty(ref _rankList, value);
            get => _rankList;
        }

        protected override void Init()
        {
            var sqlContext=Container.Resolve<PostgreSqlContext>();
            if (sqlContext.Database.EnsureCreated())
            {

            }
            else
            {

            }
            
        }

    }
}