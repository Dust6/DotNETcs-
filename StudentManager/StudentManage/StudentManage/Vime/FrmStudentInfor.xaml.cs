using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentManageModel.ObjExt;//此中含有学生的具体信息类
using Commmon;
using System.IO;
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmStudentInfor.xaml 的交互逻辑
    /// </summary>
    public partial class FrmStudentInfor : Window
    {
        public FrmStudentInfor(StudentExt stu)
        {
            InitializeComponent();
            StuID = stu.StudentID; //获取到当前的学员ID
            this.Title = stu.StudentName + "信息";
            labName.Content = stu.StudentName;
            labGender.Content = stu.Gender;
            labStuID.Content = stu.StudentID;
            labAge.Content = stu.Age;
            labstuBirthday.Content = stu.Birthday.ToString("yyyy-mm-dd");
            labGardNo.Content = stu.CardNO;
            labstuNub.Content = stu.StudentIdNO;
            labstuClass.Content = stu.ClassName;
            labstuPhon.Content = stu.PhoneNumber;
            labstuAddress.Content = stu.StudentAddress;
            //添加照片信息
            if (string.IsNullOrEmpty(stu.StuIMage))
            {
                stuImg.Source = new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute));
            }
            else
            {
                common.BItmapImg image = SerializeObjectTostring.DeserializeObject(stu.StuIMage) as common.BItmapImg;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit(); //初始化
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit(); //结束初始化
                stuImg.Source = bitmap;
            }
        }
        /// <summary>
        /// 用来记录当前的窗体绑定是哪个学员
        /// </summary>
        public int StuID { get; set; }
    }
}
