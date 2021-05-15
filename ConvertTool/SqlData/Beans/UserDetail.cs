using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlData.Bases;

namespace SqlData.Beans
{
    [Table("user_detail")]
    public class UserDetail:BeanBase
    {
        [Key]
        [Column("user_id")]
        public int UserId { set; get; }

        [Column("phone")]
        public string Phone { set; get; }

        [Column("user_password")]
        public string UserPassword { set; get; }
        [Column("display_name")]
        public string DisplayName { set; get; }
        [Column("sex")]
        public string Sex { set; get; }
        [Column("birthday")]
        public DateTime BirthDay { set; get; }

    }
}