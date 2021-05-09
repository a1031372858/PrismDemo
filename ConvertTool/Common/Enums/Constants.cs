using static Common.Enums.EnumExtension;

namespace Common.Enums
{
    public class Constants
    {
        public enum LoginViewMode
        {
            [Code("0"),Description("ログイン")]
            Login =0,
            [Code("1"), Description("登録")]
            Register =1,
            [Code("2"), Description("パスワードを変更する")]
            UpdatePsw =2,
        }

        /// <summary>
        /// ゲーム状態
        /// </summary>
        public enum GameStatus
        {
            [Description("初期化")]
            Init=0,
            [Description("運行中")]
            Running,
            [Description("ポーズ")]
            Pause,
            [Description("終了")]
            End,
        }

        public enum SnakeDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}