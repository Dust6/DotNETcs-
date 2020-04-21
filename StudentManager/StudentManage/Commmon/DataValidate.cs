using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Commmon
{
    /// <summary>
    /// 正则表达式验证
    /// </summary>
   public  class DataValidate
    {

        /// <summary>
        /// 验证正整数
        /// </summary>
        public static bool IsInteger(string str)
        {
            Regex reg = new Regex(@"^[0-9]\d*$");
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="str">需要验证的身份证字符串</param>
        /// <returns></returns>
        public static bool IsIDcard(string str)
        {
            Regex reg = new Regex(@"(^\d{ 15 }$)|(^\d{ 18}$)| (^\d{17}(\d|X|x)$)");
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 电话或手机号验证
        /// </summary>
        /// <param name="str">需要验证的手机号字符串</param>
        /// <returns></returns>
        public static bool IsPhonenum(string str)
        {
            Regex reg = new Regex(@"/^[1](([358][0-9]|[4][37]|[7][01367]))[0-9]{8}$/");
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 日期的验证
        /// </summary>
        /// <param name="str">需要验证的日期字符串</param>
        /// <returns></returns>
        /*public static bool IsValiddate(string str)
        {
            Regex reg = new Regex();
            return reg.IsMatch(str);
        }*/
    }
}
