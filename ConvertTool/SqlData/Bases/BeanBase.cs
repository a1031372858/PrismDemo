using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlData.Bases
{
    public class BeanBase
    {
        public BeanBase()
        {
            UpdateDate=DateTime.Now;
            CreateDate=DateTime.Now;
            UpdateUser = 1;
            CreateUser = 1;
        }
        [Column("update_user")]
        public int UpdateUser { set; get; }
        [Column("update_date")]
        public DateTime UpdateDate { set; get; }
        [Column("create_user")]
        public int CreateUser { set; get; }
        [Column("create_date")]
        public DateTime CreateDate { set; get; }
    }
}