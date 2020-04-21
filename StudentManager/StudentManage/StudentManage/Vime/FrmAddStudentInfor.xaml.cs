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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Commmon;
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageBLL;
using System.IO;

namespace StudentManage.Vime
{
    /// <summary>
    /// FrmAddStudentInfor.xaml 的交互逻辑
    /// </summary>
    public partial class FrmAddStudentInfor : UserControl
    {
        StudentClassManager stuclass = new StudentClassManager();//处理班级数据的Bll文件下的对象
        StudentManageBLL.StudentManager stuManager = new StudentManageBLL.StudentManager();//处理学生数据的对象
        common.BItmapImg image = null; //设置图片序列化字符串为空
        StudentExt student = new StudentExt();//添加的学员对象
        public FrmAddStudentInfor()
        {
            InitializeComponent();
            //班级
            List<StudentClass> stuclaslist = stuclass.GetClasses();//获取班级表数据
            combstuClass.ItemsSource = stuclaslist;
            combstuClass.DisplayMemberPath = "ClassName";//获取班级名
            combstuClass.SelectedValuePath = "ClassID"; //通过班级获取路径
            combstuClass.SelectedIndex = 0;
            //照片
            if (string.IsNullOrEmpty(student.StuIMage))
            {
                stuImg.Source = new BitmapImage(new Uri("/img/bg/zwzp.jpg", UriKind.RelativeOrAbsolute));
            }
            else
            {
                image = SerializeObjectTostring.DeserializeObject(student.StuIMage) as common.BItmapImg;
                img.Buffer = image.Buffer;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                stuImg.Source = bitmap;
            }
        }
        public static string imgPath;//拍照的图片路径
        //拍照上传图片
        private void btnTakePic_Click(object sender, RoutedEventArgs e)
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
        //本地选取图片
        private void btnLocalPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                stuImg.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                stuImg.Stretch = Stretch.UniformToFill;
                img.Buffer = File.ReadAllBytes(path);
            }
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
        //身份证失去焦点事件
        private void textStuNubIDcard_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textStuNubIDcard.Text.Trim()))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                textStuNubIDcard.Focus();
                return;
            }
           /* else if (DataValidate.IsIDcard(textStuNubIDcard.Text.Trim())==false)
            {
                System.Windows.Forms.MessageBox.Show("请输入正确身份证格式！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }*/
            else  //在失去焦点后将生日信息和年龄存入相应框
            {
                labBirthday.Content = Commmon.GetValueBystuIDcard.GetBirthday(textStuNubIDcard.Text.Trim()).ToString("yyyy-MM-dd"); //存储生日
                labAge.Content = GetValueBystuIDcard.GetAge(
                   Commmon.GetValueBystuIDcard.GetBirthday(textStuNubIDcard.Text.Trim()));
            }
        }
        //考勤号失去焦点事件
        private void textClockNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textClockNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                textClockNo.Focus();
            }
            else if (DataValidate.IsInteger(textClockNo.Text.Trim())==false)
            {
                System.Windows.Forms.MessageBox.Show("考勤号必须为纯数字！","友情提示",System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
        }
        //手机号失去焦点事件
        private void textPhonNumb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textPhonNumb.Text))
            {
                System.Windows.Forms.MessageBox.Show("手机号不能为空！");
                textPhonNumb.Focus();
            }
            /*else if (DataValidate.IsPhonenum(textPhonNumb.Text.Trim())==false)
            {
                System.Windows.Forms.MessageBox.Show("请输入正确的手机号格式！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }*/
        }
        //地址失去焦点事件
        private void textAdderss_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textAdderss.Text))
            {
                System.Windows.Forms.MessageBox.Show("地址不能为空！");
                textAdderss.Focus();
            }
        }
        //确定添加
        private void btnAffirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfor())
            {
                student.StudentIdNO = textStuNubIDcard.Text.Trim();//身份证号
                student.StudentName = textName.Text.Trim();//姓名
                student.Age = (int)labAge.Content; //年龄
                student.Birthday = Convert.ToDateTime(labBirthday.Content); //生日
                student.CardNO = textClockNo.Text;//打卡号
                student.ClassID = (int)combstuClass.SelectedValue;//班级号
                student.Gender = (radBoy.IsChecked == true ? "男" : "女"); //性别
                student.PhoneNumber = textPhonNumb.Text;//手机号
                student.StudentAddress = (string.IsNullOrEmpty(textAdderss.Text) ? null : textAdderss.Text);//地址
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
                if (stuManager.AddStudentInfor(student))
                {
                    System.Windows.MessageBox.Show("添加成功！", "提示");
                    this.Visibility = Visibility.Hidden; //隐藏窗体
                }
                else
                {
                    System.Windows.MessageBox.Show("添加失败，请稍后再试！", "提示");
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
                return false;
            }
            if (string.IsNullOrEmpty(textClockNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(textStuNubIDcard.Text))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                return false;
            }
            else if (DataValidate.IsIDcard(textStuNubIDcard.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确身份证格式！");
                return false;
            }
            if (string.IsNullOrEmpty(textPhonNumb.Text))
            {
                System.Windows.MessageBox.Show("手机号不能为空！");
                return false;
            }
            else if (DataValidate.IsPhonenum(textPhonNumb.Text.Trim()))
            {
                System.Windows.MessageBox.Show("请输入正确的手机号格式！");
                return false;
            }
            if (string.IsNullOrEmpty(textAdderss.Text))
            {
                System.Windows.MessageBox.Show("地址不能为空！");
                return false;
            }
            return true;
        }
        //取消添加
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden; //隐藏窗体
        }
    }
}
