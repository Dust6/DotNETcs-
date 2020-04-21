using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;//序列化命名空间
using System.IO;
namespace Commmon
{
    /// <summary>
    /// 将任意指定对象序列化成字符串
    /// </summary>
   public  class SerializeObjectTostring
    {
        /// <summary>
        /// 将对象序列化字符串
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            BinaryFormatter binary = new BinaryFormatter();//序列化对象
            string rede = string.Empty; //空字符串
            using(MemoryStream stream=new MemoryStream())//创建流对象
            {
                binary.Serialize(stream, obj);//将图像对象序列化存储到stream流中
                byte[] buffer = new byte[stream.Length];
                buffer = stream.ToArray();//将流内容写入数组
                rede = Convert.ToBase64String(buffer);//将转化后的字符赋给字符串
                //另一种写法：
                /* rede = Encoding.UTF8.GetString(buffer, 0, buffer.Length);*/
                stream.Flush();//重写
            }
            return rede;
        }
        /// <summary>
        /// 将字符串反序列化成对象
        /// </summary>
        /// <param name="str">需要反序列化的字符串</param>
        /// <returns></returns>
        public static object DeserializeObject(string str)
        {
            BinaryFormatter binary = new BinaryFormatter();
            byte[] buffer = Convert.FromBase64String(str);
            object obj = null;
            using(MemoryStream stream=new MemoryStream(buffer,0,buffer.Length))
            {
                obj = binary.Deserialize(stream);//将指定的流反序列化为图形
            }
            return obj;
        }
    }
}
