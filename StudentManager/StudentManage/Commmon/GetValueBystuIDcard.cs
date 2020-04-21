using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commmon
{
    /// <summary>
    /// 通过身份证号获取数据
    /// </summary>
    public class GetValueBystuIDcard
    {
        /// <summary>
        /// 通过身份证号码获取生日
        /// </summary>
        /// <param name="Idcard">身份证号码</param>
        /// <returns></returns>
        public static DateTime GetBirthday(string Idcard)
        {
            string date = Idcard.Substring(6, 8);
            string y = date.Substring(0, 4);
            string m = date.Substring(4, 2);
            string d = date.Substring(6, 2);
            string bir = y + "-" + m + "-" + d;
            return Convert.ToDateTime(bir);
        }
        /// <summary>
        /// 通过生日日期获取年龄
        /// </summary>
        /// <param name="birthday">生日日期</param>
        /// <returns></returns>
        public static int GetAge(DateTime birthday)
        {
            return DateTime.Now.Year - birthday.Year;
        }
    }
}
