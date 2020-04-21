using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StudentManageModel;
using StudentManageModel.ObjExt;
namespace StudentManageDAL
{
    /// <summary>
    /// 处理学生成绩表数据库中数据
    /// </summary>
    public class ScoreServer
    {
        /// <summary>
        /// 通过学号查询成绩信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns></returns>
        public StuCoreExt GetScoreById(int id)
        {
            string procName = "SeleScoreByStuId";
            SqlParameter[] parameters ={ new SqlParameter("@scoStuId",System.Data.SqlDbType.Int)};
            parameters[0].Value = id;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            StuCoreExt score = null;
            while (reader.Read())
            {
                score=new StuCoreExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    StudentName = reader["StudentName"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    ScoreUpdateTime = Convert.ToDateTime(reader["ScoreUpdateTime"])
                };
            }
            return score;
        }

        /// <summary>
        /// 通过班级名获取对应的成绩数据
        /// </summary>
        /// <param name="cid">班级id</param>
        /// <returns></returns>
        public List<StuCoreExt> GetScore(int cid)
        {
            string procName = "SeleScoreByclassId"; //存储过程名称
            SqlParameter[] parameters = { new SqlParameter("@scoClassId",System.Data.SqlDbType.Int) }; //实例化参数
            parameters[0].Value = cid; //参数赋值
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            List<StuCoreExt> list = DataReadscore(reader);
            return list;
        }
        private List<StuCoreExt> DataReadscore(SqlDataReader reader)
        {
            List<StuCoreExt> scorelist = new List<StuCoreExt>();
            while (reader.Read())
            {
                scorelist.Add(new StuCoreExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    StudentName = reader["StudentName"].ToString(),
                   ClassName = reader["ClassName"].ToString(),
                     CSharp=Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB=Convert.ToInt32(reader["SQLServerDB"]),
                    ScoreUpdateTime=Convert.ToDateTime(reader["ScoreUpdateTime"])
                }) ;
            }
            return scorelist;
        }

        /// <summary>
        /// 通过学号或姓名的部分数据查询
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<StuCoreExt> GetStuscoreExts(string target)
        {
            string procName = "SeleScoreByStIdorname";
            SqlParameter[] parameters = {new SqlParameter("@scoStIdorName",System.Data.SqlDbType.VarChar) };
            parameters[0].Value = target;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            List<StuCoreExt> list = DataReadscore(reader);
            return list;
        }
        /// <summary>
        /// 修改学员成绩
        /// </summary>
        /// <param name="scor">成绩对象</param>
        /// <returns></returns>
        public int UpScore(StuCoreExt scor)
        {
            string procName = "UpSCore";
            SqlParameter[] parameters = {new SqlParameter("@UpCsharp",System.Data.SqlDbType.Int),new SqlParameter("@UpSQL",System.Data.SqlDbType.Int),new SqlParameter("@UpstuId",System.Data.SqlDbType.Int) };
            parameters[0].Value = scor.CSharp;
            parameters[1].Value = scor.SQLServerDB;
            parameters[2].Value = scor.StudentID;

            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 删除学员成绩
        /// </summary>
        /// <param name="sco"></param>
        /// <returns></returns>
        public int DeleScore(int id)
        {
            string procName = "DeleScore";
            SqlParameter[] parameters = { new SqlParameter("@DeStuId",System.Data.SqlDbType.Int)};
            parameters[0].Value = id;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 添加学员成绩
        /// </summary>
        /// <param name="sco"></param>
        /// <returns></returns>
        public int AddScore(StuCoreExt sco)
        {
            string procName = "InScore";
            SqlParameter[] parameters = {new SqlParameter("@InStId",System.Data.SqlDbType.Int),new SqlParameter("@InCshar",System.Data.SqlDbType.Int), new SqlParameter("@InSQL",System.Data.SqlDbType.Int), new SqlParameter("@Intime",System.Data.SqlDbType.Int) };
            parameters[0].Value = sco.StudentID;
            parameters[1].Value = sco.CSharp;
            parameters[2].Value = sco.SQLServerDB;
            parameters[3].Value = sco.ScoreUpdateTime;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 通过班级编号，获取班级对应的学员成绩
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DataTable GetScoreByCId(int cid)
        {
            string procName = "GetScoreCLssByCId";
            SqlParameter[] parameters = { new SqlParameter("@scoreCId",System.Data.SqlDbType.Int) };
            parameters[0].Value = cid;
                return DBHelp.SQLHelp.GetDataTableByPROC(procName,parameters);
        }
    }
}
