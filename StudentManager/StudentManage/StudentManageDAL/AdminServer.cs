using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using System.Data.SqlClient;
using System.Data;
namespace StudentManageDAL
{
    /// <summary>
    /// 处理管理员数据库中数据
    /// </summary>
    public class AdminServer
    {
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        #region
        //public Admins GetAdmins(Admins adm)
        //{
        //    //1.
        //    //string sql = string.Format("SELECT * FROM Admins WHERE LoginID={0} AND LoginPwd='{1}'",adm.LoginId,adm.LoginPwd);
        //    //上面处理数据存储安全性问题
        //    //2.判断输入的账号
        //    // string sql = string.Format("SELECT *FROM Admins WHERE LoginID={0}", adm.LoginID);
        //    // SqlDataReader reader = DBHelp.SQLHelp.DataReader(sql);
        //    //3. 使用带有参数的SQL语句判断
        //    string sql = string.Format("SELECT * FROM Admins WHERE LoginID=@id AND LoginPwd=@Pwd");  //传入两个参数
        //    SqlParameter[] parameters =  //实例化SQL参数数组
        //    {
        //        new SqlParameter("@id",System.Data.SqlDbType.Int),
        //        new SqlParameter("@Pwd",System.Data.SqlDbType.VarChar,50)
        //    };
        //    parameters[0].Value = adm.LoginID; // 账号参数赋值
        //    parameters[1].Value = adm.LoginPwd;//密码参数赋值
        //    SqlDataReader reader = DBHelp.SQLHelp.DataReader(sql,parameters);
        //    Admins use = null;
        //    while (reader.Read())
        //    {
        //        use = new Admins()
        //        {
        //            AdminName = reader["AdminName"].ToString(),
        //            LoginID = Convert.ToInt32(reader["LoginID"]),
        //            LoginPwd = reader["LoginPwd"].ToString()
        //        };
        //    }
        //        reader.Close();
        //        return use;
        //}
        #endregion

        /// <summary>
        /// 通过SQL中存储过程获取管理员信息
        /// </summary>
        public Admins GetAdmins(Admins adm)
        {
            string procName = "AdminLog";
            SqlParameter[] parameters =  //实例化SQL参数数组
            {
                new SqlParameter("@id",System.Data.SqlDbType.Int),
                new SqlParameter("@Pwd",System.Data.SqlDbType.VarChar,50)
            };
            parameters[0].Value = adm.LoginID; // 账号参数赋值
            parameters[1].Value = adm.LoginPwd;//密码参数赋值
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName, parameters);
            Admins use = null;
            while (reader.Read())
            {
                use = new Admins()
                {
                    AdminName = reader["AdminName"].ToString(),
                    LoginID = Convert.ToInt32(reader["LoginID"]),
                    LoginPwd = reader["LoginPwd"].ToString()
                };
            }
            reader.Close();
            return use;
        }
    }
}
