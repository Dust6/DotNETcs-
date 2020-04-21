using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageDAL;
using System.Data.SqlClient;
using System.Data;
namespace StudentManageDAL
{
    /// <summary>
    /// 处理考勤表数据库中数据
    /// </summary>
   public  class AttendanceServer
    {
        /// <summary>
        /// 通过班级号查询考勤表
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public List<AttInforExt> GetAttInfors(int cid)
        {
            //string sql = "SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=" + cid + "";  //通过创建的视图表的班级号查询
            string procName = "GetAttByCid";
            SqlParameter[] parameters = { new SqlParameter("@AttCId",System.Data.SqlDbType.Int) };
            parameters[0].Value = cid;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters) ;
            List<AttInforExt> list = DataReadscore(reader);
            return list;
        }
        private List<AttInforExt> DataReadscore(SqlDataReader reader)
        {
            List<AttInforExt> attinfolist = new List<AttInforExt>();
            while (reader.Read())
            {
                attinfolist.Add(new AttInforExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),//学号
                    StudentName = reader["StudentName"].ToString(),//姓名
                    CardNo = Convert.ToInt32(reader["CardNO"]),//考勤号
                    ClassName = reader["ClassName"].ToString(),//班级
                    AUpdateTime = Convert.ToDateTime(reader["AUpdateTime"])//录入时间
                });
            }
            return attinfolist;
        }
        /// <summary>
        /// 根据学号或姓名查询
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<AttInforExt> GetAttinforExts(string target)
        {
            //string sql = string.Format("SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE StudentID LIKE '%{0}%'OR StudentName LIKE'%{0}%'", target);
            string procName = "GETAttendaceBySIdorName";
            SqlParameter[] parameters = { new SqlParameter("@AttStIdorName",System.Data.SqlDbType.Int) };
            parameters[0].Value = target;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters) ;
            List<AttInforExt> list = DataReadscore(reader);
            return list;
        }
        /// <summary>
        /// 添加考勤
        /// </summary>
        /// <param name="attInfor"></param>
        /// <returns></returns>
        public int AddattInfor(Attendance attInfor)
        {
           // string sql = string.Format("INSERT Attendance VALUES ({0},'{1}')",attInfor.CardNo,attInfor.AUpdateTime);
            string procName = "AddAttendace";
            SqlParameter[] parameters = { new SqlParameter("@CardnoId", System.Data.SqlDbType.Int), new SqlParameter("@ADDTime", System.Data.SqlDbType.SmallDateTime) };
            parameters[0].Value = attInfor.CardNo;
            parameters[1].Value = attInfor.AUpdateTime;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 通过班级编号获取考勤表
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DataTable GetAttInByCId(int cid)
        {
            //string sql = "SELECT StudentID,StudentName,CardNO,ClassID,ClassName,AUpdateTime FROM AttInfor WHERE ClassID=" + cid + "";  //通过创建的视图表的班级号查询
            string procName = "SeleAttByCId"; //存储过程名
            SqlParameter[] parameters = {new SqlParameter("@SeAtCId",System.Data.SqlDbType.Int) }; //实例化参数
            parameters[0].Value = cid; //参数赋值
            return DBHelp.SQLHelp.GetDataTableByPROC(procName,parameters);
        }
        /// <summary>
        /// 通过班级编号，查看每个出勤次数
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<AttInforExt> GetAttRateByCId(int cid)
        {
            string procName = "AttRate";
            SqlParameter[] parameters = {new SqlParameter("@AtReclassId",System.Data.SqlDbType.Int) };
            parameters[0].Value = cid;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters); ;
            List<AttInforExt> list = new List<AttInforExt>();
            while (reader.Read())
            {
                list.Add(new AttInforExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),//学号
                    StudentName = reader["StudentName"].ToString(),//姓名
                    CardNo = Convert.ToInt32(reader["CardNO"]),//考勤号
                    AttRate=Convert.ToInt32(reader["AttRate"]), //出勤次数
                });
            };
            return list;
        }
    }
}
