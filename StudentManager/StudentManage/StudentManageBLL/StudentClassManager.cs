using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using StudentManageDAL;
using System.Data;
namespace StudentManageBLL
{
   public class StudentClassManager
    {
          StudentClassServer server = new StudentClassServer();
        /// <summary>
        /// 获取班级表信息
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClasses()
        {
            return server.GetClasses();
        }
        /// <summary>
        /// 通过班级编号，获取此班级学生详细信息
        /// </summary>
        /// <param name="classID">班级编号</param>
        /// <returns></returns>
        public DataTable GetByclIdStuTab(int classID)
        {
            return server.GetStudentTable(classID);
        }
    }
}
