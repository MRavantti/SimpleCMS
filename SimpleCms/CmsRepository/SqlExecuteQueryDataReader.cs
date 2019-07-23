using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsRepository
{
    public class SqlExecuteQueryDataReader
    {
        public IEnumerable<T> ExecuteQuery<T>(string sql, Func<SqlDataReader, T> project)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CmsDatabase"].ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return project(reader);
                        }
                    }
                }
            }
        }
    }
}
