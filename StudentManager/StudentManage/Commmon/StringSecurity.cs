using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace Commmon
{
    public sealed class StringSecurity
    {
        /// <summary>
        /// 密钥
        /// </summary>
        static byte[] key = Encoding.UTF8.GetBytes("");
        /// <summary>
        /// 加密向量
        /// </summary>
        static byte[] iv = Encoding.UTF8.GetBytes("");
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DESEncrypt(string str)
        {
            //临时容器
            MemoryStream ms = null;
            //普通数据和加密数据的转换流
            CryptoStream cs = null;
            StreamWriter sw = null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                sw = new StreamWriter(cs);
                sw.Write(str);
                sw.Flush();
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (cs != null)
                {
                    cs.Close();
                }
                if (ms != null)
                {
                    ms.Close();
                }
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DESDecrypt(string str)
        {
            //临时容器
            MemoryStream ms = null;
            //普通数据和加密数据的转换流
            CryptoStream cs = null;
            StreamReader sw = null;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                byte[] data = Convert.FromBase64String(str);
                ms = new MemoryStream(data);
                cs = new CryptoStream(ms, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                sw = new StreamReader(cs);
                return sw.ReadToEnd();
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (cs != null)
                {
                    cs.Close();
                }
                if (ms != null)
                {
                    ms.Close();
                }
            }
        }
    }
}
