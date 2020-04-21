using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace StudentManageDAL.DBHelp
{
    class SQLHelp
    {
        /*static string sqlcon = "Serever=127.0.0.1;Database=StudentManageDB;UserID=sa;Pwd=123456;";*/
        static string sqlcon = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString; //配置文件中存储可方便修改
        /// <summary>
        /// 返回受影响数，对表增,删,改
        /// </summary>
        /// <param name="sql">SQL代码</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand(sql,con);
            try
            {

                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                 con.Close();
            }
        }
        /// <summary>
        /// 返回受影响数，对象增，删，改
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">SQL存储过程参数</param>
        /// <returns></returns>
        public static int GETExcuteNonQueryByPROC(string procName, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //调用存储过程
            cmd.CommandType = CommandType.StoredProcedure; //存储过程的名称
            cmd.CommandText = procName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            try
            {

                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 返回单一结果
        /// </summary>
        /// <param name="sql">SQL代码</param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            object excs = cmd.ExecuteScalar();
            con.Close();
            return excs;
        }
        /// <summary>
        /// 返回单一结果，SQL语句中有参数的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static object GETExcuteScalarByPROC(string procName, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //调用存储过程
            cmd.CommandType = CommandType.StoredProcedure; //存储过程的名称
            cmd.CommandText = procName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            try
            {
                object excs = cmd.ExecuteScalar();
                con.Close();
                return excs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查询一张表,每行获取
        /// </summary>
        /// <param name="sql">SQL代码</param>
        /// <returns></returns>
        public static SqlDataReader DataReader(string sql)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand(sql,con);
            try
            {
                con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询一张表,SQL语句有参数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public static SqlDataReader DataReader(string sql,SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand(sql,con);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            try
            {
                con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 查询一张表(每行获取)，SQL语句中有参数的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">SQL存储过程参数</param>
        /// <returns></returns>
        public static SqlDataReader GetDataReaderByPROC(string procName, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //调用存储过程
            cmd.CommandType = CommandType.StoredProcedure; //存储过程的名称
            cmd.CommandText = procName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            try
            {
                con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 查询一张表Datatable
        /// </summary>
        /// <param name="sql">SQL代码</param>
        /// <returns></returns>
        public static DataTable DataTable(string sql)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable tab = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter(cmd);
                sad.Fill(tab);
                return tab;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 查询一张表，SQL语句中有参数的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">SQL存储过程参数</param>
        /// <returns></returns>
        public static DataTable GetDataTableByPROC(string procName, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //调用存储过程
            cmd.CommandType = CommandType.StoredProcedure; //存储过程的名称
            cmd.CommandText = procName;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            DataTable tab = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter(cmd);
                sad.Fill(tab);
                return tab;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 获取多张表Dataset
        /// </summary>
        /// <param name="sql">SQL代码</param>
        /// <returns></returns>
        public static DataSet DataSet(string sql)
        {
                SqlConnection con = new SqlConnection(sqlcon);
                SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                sad.Fill(set);
                return set;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 获取多张表,SQL有参数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public static DataSet DataSet(string sql,SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters!=null)
            {
                cmd.Parameters.AddRange(parameters); //将SQL语句中的所有参数对象接收
            }
            try
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                sad.Fill(set);
                return set;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 处理导入导出
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static int UpdateByTran(List<string> sqlList)
        {
            SqlConnection con = new SqlConnection(sqlcon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                //开启数据库连接
                con.Open();
                //开始执行事务
                cmd.Transaction = con.BeginTransaction();
                int result = 0;
                //遍历事务中的每一条SQL修改代码，保证遍历到的每一条SQL代码都会执行成功，才会执行到Commit，SQL语句中只要有一条SQL代码抛异常则都会进入Catch中
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    //对每条SQL代码的执行结果进行接收
                    result += cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return result;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }
                //throw new Exception("调用事务更新方法时出现异常！"+ex.Message) ;
                return -1;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;
                }
                con.Close();
            }
        }
    }
}
