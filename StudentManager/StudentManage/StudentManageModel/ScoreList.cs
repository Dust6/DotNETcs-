using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
namespace StudentManageModel
{
    /// <summary>
    /// 成绩实体对象
    /// </summary>
    [Serializable]
    public class ScoreList
    {
        /// <summary>
        /// 成绩表编号
        /// </summary>
        public int ScoreID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// C#成绩
        /// </summary>
        public int CSharp { get; set; }
        /// <summary>
        /// SQLServer成绩
        /// </summary>
        public int SQLServerDB { get; set; }
        /// <summary>
        /// 录入成绩时间
        /// </summary>
        public DateTime  ScoreUpdateTime { get; set; }
    }
}
