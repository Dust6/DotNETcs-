using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
namespace StudentManageModel
{
    /// <summary>
    /// 班级实体对象
    /// </summary>
    [Serializable]
    public class StudentClass
    {
        /// <summary>
        /// 班级编号
        /// </summary>
        public int ClassID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
