using System.Data;
using System.Data.SqlClient;

namespace TestSystem.Common
{
    public static class SqlHelper
    {
        private static readonly string ConnStr= System.Configuration.ConfigurationManager
            .ConnectionStrings["connectionStr"].ConnectionString;

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);//把SQL语句参数添加到cmd
                    var dataSet = new DataSet();//新建DataSet对象，用于保存查询结果
                    var adapter = new SqlDataAdapter(cmd);//把执行cmd，更新数据结果到adapter对象
                    adapter.Fill(dataSet);//adapter对象的Fill方法把结果添加到DataSet对象中
                    return dataSet.Tables[0];//返回一个查询结果的一个表
                }
            }
        }

        /// <summary>
        /// 执行参数化SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {

            using (var conn = new SqlConnection(ConnStr))//到数据库的连接
            {
                conn.Open();//打开数据库连接
                using (var cmd = conn.CreateCommand())//创建执行对象
                {
                    cmd.CommandText = sql;//给cmd赋值SQL语句
                    cmd.Parameters.AddRange(parameters);//添加SQL语句中的参数
                    return cmd.ExecuteNonQuery();//执行数据库语句并返回受影响的行数
                }
            }
        }
        //执行查询语句返回结果集合的第一行第一列
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))//到数据库的连接
            {
                conn.Open();//打开数据库连接
                using (var cmd = conn.CreateCommand())//创建执行对象
                {
                    cmd.CommandText = sql;//给cmd赋值SQL语句
                    cmd.Parameters.AddRange(parameters);//把SQL语句参数添加到cmd
                    return cmd.ExecuteScalar();//执行查询，返回查询结果的第一行的第一列
                }
            }
        }
    }
}
