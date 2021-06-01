using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlData.Bases;

namespace SqlData.Beans
{
    [Table("role")]
    public class Role:BeanBase
    {

        [Key]
        [Column("role_id")]
        public int RoleId { set; get; }

        [Column("role_name")]
        public int RoleName { set; get; }
    }
}