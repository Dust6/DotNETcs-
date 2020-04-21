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
    /// 处理班级表数据库中数据
    /// </summary>
    public class StudentClassServer
    {
        /// <summary>
        /// 获取所有班级表
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClasses()
        {
            string procName = "SeleClass";
            SqlParameter[] parameters = null;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            List<StudentClass> list = new List<StudentClass>();
            while (reader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassID = Convert.ToInt32(reader["ClassID"]),
                    ClassName = reader["ClassName"].ToString()
                }); ;
            }
            reader.Close();
            return list;

        }
        /// <summary>
        /// 通过班级编号查询班级表
        /// </summary>
        /// <param name="classid">班级编号</param>
        /// <returns></returns>
        public DataTable GetStudentTable(int classid)
        {
            string procName = "SeleStuClassBycId";
            SqlParameter[] parameters = { new SqlParameter("@classId",System.Data.SqlDbType.Int)};
            parameters[0].Value = classid;
            return DBHelp.SQLHelp.GetDataTableByPROC(procName,parameters);
        }
        /// <summary>
        /// 通过班级名获取班级号
        /// </summary>
        /// <param name="name">班级名</param>
        /// <returns></returns>
        public int GetCLassIdByName(string name)
        {
            string sql = "SELECT ClassID from StudentClass WHERE ClassName='" + name + "'";
            string procName = "SeleStuClassByCname";
            SqlParameter[] parameters = { new SqlParameter("@className",System.Data.SqlDbType.Int)};
            parameters[0].Value = name;
            object rest = DBHelp.SQLHelp.GETExcuteScalarByPROC(procName,parameters);
            if (rest==null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(rest);
            }
        }
    }
}
