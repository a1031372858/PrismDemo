using Npgsql;

namespace Common.Utility
{
    public class SqlUtility
    {
        private const string DataSource = @"PORT=5432;DATABASE=usermanager;HOST=localhost;PASSWORD=666666;USER ID=postgres;";

        public static NpgsqlConnection Connection = new NpgsqlConnection(DataSource);

        static SqlUtility()
        {

            Connection.Open();
        }

        public static NpgsqlDataReader SqlExecute(string sql)
        {
            NpgsqlCommand sqlCommand = new NpgsqlCommand(sql, Connection);
            var result =sqlCommand.ExecuteReader();

            return result;
        }
    }
}