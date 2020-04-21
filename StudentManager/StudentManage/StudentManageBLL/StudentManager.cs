using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageDAL;
using System.Data;
namespace StudentManageBLL
{
    public class StudentManager
    {
        StudentServer server = new StudentServer();
        /// <summary>
        /// 获取学生表信息(集合)
        /// </summary>
        /// <param name="cid">学号</param>
        /// <returns></returns>
        public List<StudentExt> GetStudents(int cid)
        {
            return server.GetStudents(cid);
        }
        /// <summary>
        /// 通过部分学号或姓名查询对应信息
        /// </summary>
        /// <param name="target">需查询的参数</param>
        /// <returns></returns>
        public List<StudentExt> GetStudentIDorName(string target)
        {
            return server.GetStudentExts(target);
        }
        /// <summary>
        /// 通过学号获取学员具体信息(个人)
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns></returns>
        public StudentExt GetStudentById(int id)
        {
            return server.GetStudentById(id);
        }
        /// <summary>
        /// 修改学员信息
        /// </summary>
        /// <param name="stu">修改的实体对象</param>
        /// <returns></returns>
        public bool UpdateStudentInfor(StudentExt stu)
        {
            if (server.UpStudent(stu)<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 添加学员信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool AddStudentInfor(StudentExt stu)
        {
            if (server.AddStudent(stu)<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
         /// <summary>
         /// 删除学员信息
         /// </summary>
         /// <param name="stu">学号</param>
         /// <returns></returns>
        public bool DeleteStudentById(int stu)
        {

            if(server.DeleStudent(stu)<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取Excel文件数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByExcel(string path)
        {
            return server.GetStudentByExcel(path);
        }
        /// <summary>
        /// 添加Excel表中的数据到数据库
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
      public int InsertStudent(StudentExt stu)
        {
            if (server.CheckStuID(stu.StudentIdNO)>0)
            {
                return -1;
            }
            return server.InsertStudent(stu);
        }
        /// <summary>
        /// 通过考勤号查询
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public DataTable GetStuByCard(int carid)
        {
            DataTable tab = server.GetStuByCard(carid);
            return tab;
        }
    }
}
