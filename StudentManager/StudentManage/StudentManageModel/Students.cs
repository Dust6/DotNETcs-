using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
namespace StudentManageModel
{
    /// <summary>
    /// 学生实体对象
    /// </summary>
    [Serializable]
    public class Students
    {
        /// <summary>
        /// 学号
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public  string StudentIdNO { get; set; }
        /// <summary>
        ///考勤号
        /// </summary>
        public string CardNO { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        public string StuIMage { get; set; }
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string StudentAddress { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public int  ClassID { get; set; }
    }
}
