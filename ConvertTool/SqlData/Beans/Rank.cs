using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlData.Bases;

namespace SqlData.Beans
{
    [Table("rank")]
    public class Rank : BeanBase
    {

        [Key]
        [Column("rank_id")]
        public long RankId { set; get; }

        [Column("user_id")]
        public long UserId { set; get; }

        [Column("game_id")]
        public long GameId { set; get; }

        [Column("grade")]
        public int Grade { set; get; }
    }
}