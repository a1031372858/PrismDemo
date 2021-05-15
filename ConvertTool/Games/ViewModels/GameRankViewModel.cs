using System.Collections.ObjectModel;
using System.Linq;
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
            RankList.Clear();
            var sqlContext = Container.Resolve<PostgreSqlContext>();
            // var list1=sqlContext.Rank.OrderBy(o => o.Grade).Skip(0).Take(20);
           var list2= sqlContext.Rank.Join(sqlContext.UserDetail, o => o.UserId, p => p.UserId, (o, p) => new RankUiModel()
            {
                RankId = o.RankId,
                GameId = o.GameId,
                Grade = o.Grade,
                UserId = o.UserId,
                Username = p.DisplayName,
            }).OrderByDescending(o => o.Grade).Skip(0).Take(20).ToList();

           for (int i = 0; i < list2.Count; i++)
           {
               list2[i].ViewNum = i + 1;
           }
            RankList.AddRange(list2);
        }

    }
}