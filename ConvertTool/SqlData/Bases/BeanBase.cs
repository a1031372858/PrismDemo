using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlData.Bases
{
    public class BeanBase
    {
        [Column("update_user")]
        public string UpdateUser { set; get; }
        [Column("update_date")]
        public DateTime UpdateDate { set; get; }
        [Column("create_user")]
        public string CreateUser { set; get; }
        [Column("create_date")]
        public DateTime CreateDate { set; get; }
    }
}