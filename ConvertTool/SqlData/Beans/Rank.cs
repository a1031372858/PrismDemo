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
        public int RankId { set; get; }

        [Column("user_id")]
        public int UserId { set; get; }

        [Column("game_id")]
        public string GameId { set; get; }

        [Column("grade")]
        public string Grade { set; get; }
    }
}