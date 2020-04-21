using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using StudentManageModel.ObjExt;
using System.Data.SqlClient;
using StudentManageDAL;
using System.Data;
using Commmon;
namespace StudentManageDAL
{
    /// <summary>
    /// 处理学生表数据库中数据
    /// </summary>
    public class StudentServer
    {
        /// <summary>
        /// 通过学号查询对应的学生信息(集合)
        /// </summary>
        /// <param name="cid">学号</param>
        /// <returns></returns>
        public List<StudentExt> GetStudents(int cid)
        {
            string procName = "StudentListByCId";
            SqlParameter[] parameters ={new SqlParameter("@CId", System.Data.SqlDbType.Int)};//实例化SQL参数数组
            parameters[0].Value = cid; // 账号参数赋值
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            List<StudentExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }
        /// <summary>
        /// 将获取到的数据添加到StudentExt类中
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<StudentExt> DataReturnObj(SqlDataReader reader)
        {
            List<StudentExt> list = new List<StudentExt>();
            while (reader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNO = reader["CardNO"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentIdNO = reader["StudentIdNO"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StuIMage = reader["StuIMage"].ToString()
                });
            }
            return list;
        }
        
        /// <summary>
        /// 通过部分学号或部分姓名(模糊查询)
        /// </summary>
        /// <param name="target">查询的条件</param>
        /// <returns></returns>
        public List<StudentExt> GetStudentExts(string target)
        {
            string procName = "StudentLike";
            SqlParameter[] parameters={ new SqlParameter("@Like", System.Data.SqlDbType.VarChar)};//参数类型需与从数据库中存储过程类型一致
            parameters[0].Value = target;
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            List<StudentExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }
        /// <summary>
        /// 通过学号查询学员信息(某个人)
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns></returns>
        public StudentExt GetStudentById(int id)
        {
            string procName = "StudentByStId";
            SqlParameter[] parameters = { new SqlParameter("@StId", System.Data.SqlDbType.Int)}; //实例化存储过程参数
            parameters[0].Value = id;//给参数赋值
            SqlDataReader reader = DBHelp.SQLHelp.GetDataReaderByPROC(procName,parameters);
            StudentExt student = null;
            while (reader.Read())
            {
                student = new StudentExt()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNO = reader["CardNO"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentIdNO = reader["StudentIdNO"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StuIMage = reader["StuIMage"].ToString(),
                    ClassID=Convert.ToInt32(reader["ClassID"])
                };
            }
            return student;
        }
        /// <summary>
        /// 修改学员信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int UpStudent(StudentExt stu)
        {
            /*string sql = string.Format("UPDATE Students SET StudentName = '{0}', Gender = '{1}', Birthday = '{2}', StudentIdNO = '{3}', CardNO = '{4}', StuIMage = '{5}', Age ={6},PhoneNumber = '{7}',StudentAddress = '{8}',ClassID ={9} WHERE StudentID = {10}", stu.StudentName, stu.Gender, stu.Birthday, stu.StudentIdNO, stu.CardNO, stu.StuIMage, stu.Age, stu.PhoneNumber, stu.StudentAddress, stu.ClassID, stu.StudentID);*/
            string procName = "UpStudent";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stName",System.Data.SqlDbType.VarChar),
                new SqlParameter("@stGender",System.Data.SqlDbType.Char),
                new SqlParameter("@stBirthdy",System.Data.SqlDbType.SmallDateTime),
                new SqlParameter("@stIDNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@stCardNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@stImage",System.Data.SqlDbType.Text),
                new SqlParameter("@stAge",System.Data.SqlDbType.Int),
                new SqlParameter("@stPhoneNumber",System.Data.SqlDbType.VarChar),
                new SqlParameter("@stAddress",System.Data.SqlDbType.VarChar),
                new SqlParameter("@stClassId",System.Data.SqlDbType.Int),
                new SqlParameter("@stID",System.Data.SqlDbType.Int)
            };
            parameters[0].Value = stu.StudentName;
            parameters[1].Value = stu.Gender;
            parameters[2].Value = stu.Birthday;
            parameters[3].Value = stu.StudentIdNO;
            parameters[4].Value = stu.CardNO;
            parameters[5].Value = stu.StuIMage;
            parameters[6].Value = stu.Age;
            parameters[7].Value = stu.PhoneNumber;
            parameters[8].Value = stu.StudentAddress;
            parameters[9].Value = stu.ClassID;
            parameters[10].Value = stu.StudentID;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <returns></returns>
        public int AddStudent(StudentExt stu)
        {
            /*string sql = string.Format("INSERT INTO Students(StudentName,Gender,Birthday,StudentIdNO,CardNO,StuIMage,Age,PhoneNumber,StudentAddress,ClassID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}', '{7}', '{8}', {9})", stu.StudentName, stu.Gender, stu.Birthday, stu.StudentIdNO, stu.CardNO,stu.StuIMage, stu.Age, stu.PhoneNumber, stu.StudentAddress, stu.ClassID);
            return DBHelp.SQLHelp.ExcuteNonQuery(sql);*/
            string procName = "InStudent";
            SqlParameter[] parameters = {
                new SqlParameter("@StName",System.Data.SqlDbType.VarChar),
                new SqlParameter("@StGender",System.Data.SqlDbType.Char),
                new SqlParameter("@StBirthdy",System.Data.SqlDbType.SmallDateTime),
                new SqlParameter("@StIDNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@StCardNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@StImage",System.Data.SqlDbType.Text),
                new SqlParameter("@StAge",System.Data.SqlDbType.Int),
                new SqlParameter("@stPhoneNumber",System.Data.SqlDbType.VarChar),
                new SqlParameter("@StAddress",System.Data.SqlDbType.VarChar),
                new SqlParameter("@StClassId",System.Data.SqlDbType.Int)
            };
            parameters[0].Value = stu.StudentName;
            parameters[1].Value = stu.Gender;
            parameters[2].Value = stu.Birthday;
            parameters[3].Value = stu.StudentIdNO;
            parameters[4].Value = stu.CardNO;
            parameters[5].Value = stu.StuIMage;
            parameters[6].Value = stu.Age;
            parameters[7].Value = stu.PhoneNumber;
            parameters[8].Value = stu.StudentAddress;
            parameters[9].Value = stu.ClassID;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }

        /// <summary>
        /// 删除学员信息
        /// </summary>
        /// <param name="stuID">学号</param>
        /// <returns></returns>
        public int DeleStudent(int stuID)
        {
            /*string sql ="DELETE FROM Students WHERE StudentID=" + stuID;
            string procName = "DeleStudent";*/
            string procName = "DeleStudent";
            SqlParameter[] parameters = { new SqlParameter("@deSId",System.Data.SqlDbType.Int) };
            parameters[0].Value = stuID;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }

        StudentClassServer classServer = new StudentClassServer();
        /// <summary>
        /// 从Excel文件中获取数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByExcel(string path)
        {
            List<StudentExt> list = new List<StudentExt>();
            string sql= string.Format("select * from [{0}$] ",Commmon.DeriveExportTab.SheetName(path)); //通过SheetName获取到本地Excel工作簿的文件名
            DataSet tabl = Commmon.OleDbHelper.GetDataSet(sql,path);
            DataTable table = tabl.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                list.Add(new StudentExt() {
                    StudentName = row["姓名"].ToString(),
                    Gender = row["性别"].ToString(),
                    Birthday = Convert.ToDateTime(row["生日"]),
                    StudentIdNO = row["身份证号"].ToString(),
                    CardNO = row["打卡号"].ToString(),
                    Age = DateTime.Now.Year - Convert.ToDateTime(row["生日"]).Year,
                    PhoneNumber = row["电话号"].ToString(),
                    StudentAddress = row["地址"].ToString(),
                    ClassName = row["班级"].ToString(),
                    ClassID = classServer.GetCLassIdByName(row["班级"].ToString())
                });
            }
            return list;
        }
        /// <summary>
        /// 添加Excel数据到数据库中
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int InsertStudent(StudentExt stu)
        {
            string procName = "InStuBYExcel";
            SqlParameter[] parameters = { new SqlParameter("@StName",System.Data.SqlDbType.VarChar),
                new SqlParameter("@SteGender",System.Data.SqlDbType.Char),
                new SqlParameter("@SteBirthdy",System.Data.SqlDbType.SmallDateTime),
                new SqlParameter("@SteIDNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@SteCardNO",System.Data.SqlDbType.VarChar),
                new SqlParameter("@SteAge",System.Data.SqlDbType.Int),
                new SqlParameter("@stePhoneNumber",System.Data.SqlDbType.VarChar),
                new SqlParameter("@SteAddress",System.Data.SqlDbType.VarChar),
                new SqlParameter("@SteClassId",System.Data.SqlDbType.Int)
            };
            parameters[0].Value = stu.StudentName;
            parameters[1].Value = stu.Gender;
            parameters[2].Value = stu.Birthday;
            parameters[3].Value = stu.StudentIdNO;
            parameters[4].Value = stu.CardNO;
            parameters[5].Value = stu.Age;
            parameters[6].Value = stu.PhoneNumber;
            parameters[7].Value = stu.StudentAddress;
            parameters[8].Value = stu.ClassID;
            return DBHelp.SQLHelp.GETExcuteNonQueryByPROC(procName,parameters);
        }
        /// <summary>
        /// 通过学号查询Excel数据中的数据检索是否符合要求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CheckStuID(string id)
        {
            string procName = "CheckStuByID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@checkStId",System.Data.SqlDbType.Int)
            };
            parameters[0].Value = id;
            object res = DBHelp.SQLHelp.GETExcuteScalarByPROC(procName,parameters);
            return (int)res;
        }

        /// <summary>
        /// 通过考勤号查询
        /// </summary>
        /// <param name="stexe"></param>
        /// <returns></returns>
        public DataTable GetStuByCard(int stexe)
        {
            string procName = "SeleStuByCard";
            SqlParameter[] parameters = { new SqlParameter("@CardId",System.Data.SqlDbType.Int) };
            parameters[0].Value = stexe;
            DataTable tabl = DBHelp.SQLHelp.GetDataTableByPROC(procName,parameters);
            return tabl;
        }
    }
}
