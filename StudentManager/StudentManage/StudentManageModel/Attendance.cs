using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
namespace StudentManageModel
{
    /// <summary>
    /// 考勤表
    /// </summary>
    [Serializable]
    public  class Attendance
    {
       /// <summary>
       /// 打卡编号
       /// </summary>
        public int AID { get; set; }
        /// <summary>
        ///  考勤编号
        /// </summary>
        public int CardNo { get; set; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        public DateTime AUpdateTime { get; set; }
    }
}
