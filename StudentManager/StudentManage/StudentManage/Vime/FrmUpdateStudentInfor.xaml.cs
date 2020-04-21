using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageBLL;
using Commmon;
using System.IO;
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmUpdateStudentInfor.xaml 的交互逻辑
    /// </summary>
    public partial class FrmUpdateStudentInfor : Window
    {
        StudentClassManager stuclass = new StudentClassManager();//处理班级信息数据
        StudentManageBLL.StudentManager students = new StudentManageBLL.StudentManager(); //处理学员信息数据对象
        common.BItmapImg image = null;
        public StudentExt student { get; set; } //学员对象
        public FrmUpdateStudentInfor(StudentExt stu)
        {
            InitializeComponent();
            this.Title = "修改【" + stu.StudentName + "】信息";
            student = stu;
            textName.Text = stu.StudentName; //姓名
            if (stu.Gender=="男")
            {
                radBoy.IsChecked = true;
            } //性别
            else
            {
                radGirl.IsChecked = true;
            }
            dateBirthday.Content= stu.Birthday.ToString("yyyy-MM-dd");//生日
            textAge.Content = stu.Age.ToString(); //年龄
            textGardNo.Text = stu.CardNO; //打卡号
            textstuNub.Text = stu.StudentIdNO; //身份证号
            textstuPhon.Text = stu.PhoneNumber; //手机号
            textstuAddress.Text = stu.StudentAddress;//地址
            //班级
            List<StudentClass> stuclaslist = stuclass.GetClasses();
            combstuClass.ItemsSource = stuclaslist;
            combstuClass.DisplayMemberPath = "ClassName";
            combstuClass.SelectedValuePath = "ClassID";
            combstuClass.SelectedIndex = stu.ClassID-101;
            //照片
            if (string.IsNullOrEmpty(stu.StuIMage))
            {
                stuImg.Source = new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute));
            }
            else
            {
                image = SerializeObjectTostring.DeserializeObject(stu.StuIMage) as common.BItmapImg;
                img.Buffer = image.Buffer;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                stuImg.Source = bitmap;
            }
        }
        public static string imgPath;
        //重新拍照
        private void btnPic_Click(object sender, RoutedEventArgs e)
        {
            FrmStuPicture stuPicture = new FrmStuPicture();
            stuPicture.ShowDialog();
            if (!string.IsNullOrEmpty(imgPath))
            {
                //照片刷新后对新照片进行序列化
                stuImg.Source = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
                img.Buffer = File.ReadAllBytes(imgPath);
            }
        }
        common.BItmapImg img = new common.BItmapImg();
        //重新上传
        private void btnPicgo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            if (fileDialog.ShowDialog()==true)
            {
                string path = fileDialog.FileName;
                stuImg.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                stuImg.Stretch = Stretch.UniformToFill;
                img.Buffer = File.ReadAllBytes(path);
            }
        }
        //确认修改
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfor())
            {
                student.StudentIdNO = textstuNub.Text.Trim();//身份证号
                student.StudentName = textName.Text.Trim();//姓名
                student.Age = Convert.ToInt32(textAge.Content); //年龄
                student.Birthday =Convert.ToDateTime(dateBirthday.Content); //生日
                student.CardNO = textGardNo.Text;//打卡号
                student.ClassID = (int)combstuClass.SelectedValue;//班级号
                student.Gender = (radBoy.IsChecked == true ? "男" : "女"); //性别
                student.PhoneNumber = textstuPhon.Text;//手机号
                student.StudentAddress = (string.IsNullOrEmpty(textstuAddress.Text) ? null : textstuAddress.Text);//地址
                //判断是否重新选择Image
                if (stuImg.Source == new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute)))
                {
                    student.StuIMage = null;
                }
                //判断数据库中的图片是否和当前上传的图片一致
                else
                {
                    //证明未修改图片,目前的图片和原来数据库中的一致
                    if (image != null && img.Buffer == image.Buffer)
                    {
                        student.StuIMage = Commmon.SerializeObjectTostring.SerializeObject(image);
                    }
                    else
                    {
                        student.StuIMage = Commmon.SerializeObjectTostring.SerializeObject(img);
                    }
                }
                if (students.UpdateStudentInfor(student))
                {
                    System.Windows.MessageBox.Show("修改成功！", "提示");
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("修改失败，请稍后再试！", "提示");
                }
            }
        }
        /// <summary>
        /// 判断输入的信息是否合理
        /// </summary>
        /// <returns></returns>
        bool CheckInfor()
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                System.Windows.MessageBox.Show("姓名不能为空！");
                textName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textGardNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                textGardNo.Focus();
                return false;
            }
            /*else if (DataValidate.IsInteger(textGardNo.Text.Trim()))
            {
                System.Windows.MessageBox.Show("打卡号必须为纯数字！");
                textGardNo.Focus();
                return false;
            }*/
            if (string.IsNullOrEmpty(textstuNub.Text))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                textstuNub.Focus();
                return false;
            }
            else if (DataValidate.IsIDcard(textstuNub.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确身份证格式！");
                textstuNub.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textstuPhon.Text))
            {
                System.Windows.MessageBox.Show("手机号不能为空！");
                textstuPhon.Focus();
                return false;
            }
           else if (DataValidate.IsPhonenum(textstuPhon.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确的手机号格式！");
                textstuPhon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textstuAddress.Text))
            {
                System.Windows.MessageBox.Show("地址不能为空！");
                textstuAddress.Focus();
                return false;
            }
            return true;
        }
        //取消修改
        private void btnAbolish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //姓名失去焦点事件
        private void textName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                System.Windows.MessageBox.Show("姓名不能为空");
                textName.Focus();
            }
        }
        //打卡号失去焦点事件
        private void textGardNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textGardNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                textGardNo.Focus();
            }
            /*else if (DataValidate.IsInteger(textGardNo.Text.Trim()))
            {
                System.Windows.MessageBox.Show("打卡号必须为纯数字！");
                textGardNo.Focus();
            }*/
        }
        //身份证号失去焦点事件
        private void textstuNub_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textstuNub.Text.Trim()))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                textstuNub.Focus();
            }
            else if (DataValidate.IsIDcard(textstuNub.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确身份证格式！");
                textstuNub.Focus();
                return;
            }
            else  //在失去焦点后将生日信息和年龄存入相应框
            {
                dateBirthday.Content = Commmon.GetValueBystuIDcard.GetBirthday(textstuNub.Text.Trim()).ToString("yyyy-MM-dd"); //存储生日
                textAge.Content = GetValueBystuIDcard.GetAge(
                   Commmon.GetValueBystuIDcard.GetBirthday(textstuNub.Text.Trim()));
            }
        }
        //手机号失去焦点事件
        private void textstuPhon_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textstuPhon.Text))
            {
                System.Windows.MessageBox.Show("手机号不能为空！");
                textstuPhon.Focus();
            }
            else if (DataValidate.IsPhonenum(textstuPhon.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确的手机号格式！");
                textstuPhon.Focus();
            }
        }
        //地址失去焦点事件
        private void textstuAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textstuAddress.Text))
            {
                System.Windows.MessageBox.Show("地址不能为空！");
                textstuAddress.Focus();
            }
        }
    }
}
