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
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageBLL;
using Commmon;
using System.IO;
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmStuManager.xaml 的交互逻辑
    /// </summary>
    public partial class FrmStuManager : UserControl
    {
        StudentClassManager stucm = new StudentClassManager();//班级对象处理数据
        StudentManageBLL.StudentManager stum = new StudentManager();//处理获取到的学生表信息数据
        //学生对象处理数据
        List<StudentExt> students = null;
        //用来记录当前的选择的学员
        StudentExt selectStu = null;
        public FrmStuManager()
        {
            InitializeComponent();
            List<StudentClass> clas = stucm.GetClasses();//获取到班级信息
            smclassCmb.ItemsSource = clas;
            smclassCmb.DisplayMemberPath = "ClassName";
            smclassCmb.SelectedValuePath = "ClassID";
            smclassCmb.SelectedIndex = 1;//默认为第二项

            students = stum.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }
        //关闭窗口
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden; //隐藏窗体
        }
        //班级名 提交查询
        private void btnSelectByCId_Click(object sender, RoutedEventArgs e)
        {
            if (smclassCmb.SelectedIndex<0)
            {
                MessageBox.Show("请选择班级","提示");
                return;
            }
            students = stum.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));   //获取下拉框选定的班级名
            smDgStudentLsit.ItemsSource = students;//添加班级名对应的学生信息表
        }
        // 学号排序
        private void btnGroupBySid_Click(object sender, RoutedEventArgs e)
        {
            if (smDgStudentLsit.ItemsSource == null)
            {
                return;
            }
            //倒序：从大到小
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new StudentIdDESC(true));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/up.ico", UriKind.RelativeOrAbsolute));//切换向上的图片
                (sender as Button).Tag = "False";
            }
            // 从小到大
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentIdDESC(false)); //Sort()排序方法，默认为升序
                groupBySidImg.Source = new BitmapImage(new Uri("/img/ico/down.ico",UriKind.RelativeOrAbsolute)); //切换到箭头向下图片
                (sender as Button).Tag = "True"; //
            }
            smDgStudentLsit.ItemsSource = null;//清空表
            smDgStudentLsit.ItemsSource = students; //添加表数据
        }
        // 姓名排序
        private void btnGroupBySName_Click(object sender, RoutedEventArgs e)
        {
            if (smDgStudentLsit.ItemsSource == null)
            {
                return;
            }
            if ((sender as Button).Tag.ToString() == "True") //默认为True 即升序
            {
                students.Sort(new StudentNameDESC(true));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/jiang.ico", UriKind.RelativeOrAbsolute));//切换向下图片
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentNameDESC(false));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/ico/sheng.ico", UriKind.RelativeOrAbsolute));//切换向上图片
                (sender as Button).Tag = "True";
            }
            smDgStudentLsit.ItemsSource = null;
            smDgStudentLsit.ItemsSource = students;
        }
        /// <summary>
        /// 学号比较器
        /// </summary>
        class StudentIdDESC : IComparer<StudentExt> //继承Incompare接口
        {
            public StudentIdDESC(bool b)
            {
                B = b;
            }
            public bool B { get; set; }
            public int Compare(StudentExt x, StudentExt y) // 返回数字，正数为升序，负数为倒序排列
            {
                if (B) //升序  即返回正数
                {
                    return x.StudentID.CompareTo(y.StudentID);//第一个对象属性与第二个对象的属性比较
                }
                else//倒序  即返回负数
                {
                    return y.StudentID.CompareTo(x.StudentID);//第二个对象的属性和第一个对象的属性比较
                }
            }
        }
        /// <summary>
        /// 姓名比较器
        /// </summary>
        class StudentNameDESC : IComparer<StudentExt>
        {
            public StudentNameDESC(bool b) //默认为True
            {
                B = b;
            }
            public bool B { get; set; }
            public int Compare(StudentExt x, StudentExt y)
            {
                if (B) //默认为升序
                {
                    return y.StudentName.CompareTo(x.StudentName); //第一个对象的属性与第二个对象的属性比较
                }
                else //倒序
                {
                    return x.StudentName.CompareTo(y.StudentName); //第二个对象的属性和第一个对象的属性比较
                }
            }
        }
        // 学员部分信息查询(模糊查询)
        private void btnSelectBySIN_Click(object sender, RoutedEventArgs e)
        {
            smclassCmb.SelectedIndex = -1;
            string target = mstxtIdorName.Text.Trim(); //部分学号或姓名信息
            List<StudentExt> liststu = stum.GetStudentIDorName(target);//查询的数据表
            if (liststu.Count<0)
            {
               MessageBox.Show("未查找到有个信息！","提示");
                return;
            }
            students = liststu;
            smDgStudentLsit.ItemsSource = null; //清空表格
            smDgStudentLsit.ItemsSource = students;//添加信息
        }
        // 修改学员
        private void btnUpdateStu_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            try
            {
            //检查当前选择的学员，查看详细信息的界面未关闭
            if (IdList.Contains(selectStu.StudentID))
            {
                MessageBox.Show("请关闭正在查看的学员信息");
                return;
            }
            if (selectStu == null)
            {
                MessageBox.Show("请选择要修改的学员！", "提示");
                return;
            }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("请选定学员！");
                return;
            }
            StudentExt objstu = stum.GetStudentById(selectStu.StudentID);
            FrmUpdateStudentInfor updateStudentInfor = new FrmUpdateStudentInfor(objstu);
            updateStudentInfor.ShowDialog();
            //刷新DG中学员信息
            RefreshDG();
        }
        /// <summary>
        /// 刷新DG中的学生信息
        /// </summary>
        private void RefreshDG()
        {
            students = stum.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }
        //删除学员
        private void btnDeleteStu_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (IdList.Contains(selectStu.StudentID))
            {
                MessageBox.Show("请先关闭正在查看的学生信息","提示");
            }
            if (selectStu == null)
            {
                System.Windows.Forms.MessageBox.Show("请选择要删除的学员!","提示");
                return;
            }
            StudentExt student = stum.GetStudentById(selectStu.StudentID);
            if (student!=null)
            {
                System.Windows.Forms.MessageBox.Show("您选择的学员信息已删除","提示");
            }
            MessageBoxResult mbox =MessageBox.Show("您确定要删除【"+ student.StudentName+"】","警告",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (mbox==MessageBoxResult.OK)
            {
                if (stum.DeleteStudentById(student.StudentID))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }
        //导出班级对应的学员exacel表
        private void btnExportStu_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog(); //创建工作簿对象
            fileDialog.Filter = "Excel工作簿(*.xlsx;*.xls)|*.xlsx;*.xls"; //检索格式
            fileDialog.FileName = "学生信息表.xlsx"; //设置工作簿的名称(桌面见到的名称)
            fileDialog.Title = "导出Excel表";
            if (fileDialog.ShowDialog()==true) //如果工作簿的窗体打开
            {
                string path = fileDialog.FileName; //存储的位置
                System.Data.DataTable table = stucm.GetByclIdStuTab((int)smclassCmb.SelectedValue);
                if (table.Rows.Count<=0)
                {
                    System.Windows.Forms.MessageBox.Show("该班级暂无学生信息！","提示");
                    return;
                }
                if (Commmon.DeriveExportTab.ExportStuToExcel(table,path))
                {
                    MessageBox.Show("导出数据完成！","提示");
                }
                else
                {
                   MessageBox.Show("导出数据失败，请稍后再试！","提示");
                }
            }
        }
        //打印信息
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu==null)
            {
               MessageBox.Show("请选择你要打印的学员","提示");
            }
            common.BItmapImg image = null;
            if (string.IsNullOrEmpty(selectStu.StuIMage))
            {
                selectStu.ImgPath = "/img/bg/zwzp.jpg";
            }
            else
            {
                image = SerializeObjectTostring.DeserializeObject(selectStu.StuIMage) as common.BItmapImg;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                long sc = DateTime.Now.Ticks;
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    byte[] buffer = stream.ToArray();
                    File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png", buffer);
                    stream.Close();
                }
                selectStu.ImgPath = AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png";
            }
            Vime.FrmPrintStuInfo frmPrint = new FrmPrintStuInfo("PrintModel.xaml", selectStu);
            frmPrint.ShowInTaskbar = false;
            frmPrint.ShowDialog();
        }
        List<int> IdList = new List<int>(); //存储已经打开的ID
        /// <summary>
        /// 此集合中存储某个学号对应的全部信息和样式
        /// </summary>
        List<FrmStudentInfor> frmListStu = new List<FrmStudentInfor>();
        //学员双击事件，查看详细信息
        private void smDgStudentLsit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //实例化选中的学员
             selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu==null) //未选中，则退出
            {
                return;
            }
            //如果已经打开未关闭时，将此学员对应的窗体顶置显示
            if (IdList.Contains(selectStu.StudentID)) 
            {
                //遍历存储学号对应的样式窗体
                foreach (FrmStudentInfor item in frmListStu)
                { //判断窗体对应的学号与选定一样时
                    if (item.StuID==selectStu.StudentID)
                    {
                        item.Activate();  //调至前台，激活窗体
                    }
                }
            }
            //未打开，即打开新窗体
            else
            {
                StudentExt objStu = stum.GetStudentById(selectStu.StudentID); //获取当前选定的学员对应详细信息
                IdList.Add(selectStu.StudentID);//将选定的学员学号存储到打开的ID中
                Vime.FrmStudentInfor studentInfor = new FrmStudentInfor(objStu); //获取对应的窗体样式对象
                studentInfor.Closing += StudentInfor_Closing;
                //移除关闭的窗体，(第一次打开窗体后，将其关闭，再次选定此学员时无法打开，即需要移除关闭的窗体的数据，重新显示)
                studentInfor.Show(); //显示窗体
            }
        }
        /// <summary>
        /// 移除关闭的窗体对应的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentInfor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int stuID = (sender as FrmStudentInfor).StuID; //当前选定学员ID
            IdList.Remove(stuID); //从存储打开ID集合中清除数据
            foreach (FrmStudentInfor item in frmListStu)
            {
                if (item.StuID==stuID)
                {
                    frmListStu.Remove(item); //将对应的学员信息和样式清除
                    return;
                }
            }
        }
    }
}
