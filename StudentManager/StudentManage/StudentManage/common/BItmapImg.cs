using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentManage.common
{
    /// <summary>
    /// 存储图片序列化后的字符串
    /// </summary>
    [Serializable]
    public class BItmapImg
    {
        public byte[] Buffer { get; set; }
    }
}
