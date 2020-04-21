using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManageModel.ObjExt
{
    /// <summary>
    /// 此为Student通用类型，包括学生的全部信息
    /// </summary>
    public class StudentExt : Students
    {
        /// <summary>
        /// 班级名属性
        /// </summary>
        public string ClassName { get;set;}
        /// <summary>
        /// 图片的路径地址
        /// </summary>
        public string ImgPath { get; set; }
    }
}
