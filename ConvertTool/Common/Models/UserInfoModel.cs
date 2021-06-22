using SqlData.Beans;

namespace Common.Models
{
    public class UserInfoModel
    {
        public UserDetail UserDetail { set; get; }

        public Role Role { set; get; }
    }
}