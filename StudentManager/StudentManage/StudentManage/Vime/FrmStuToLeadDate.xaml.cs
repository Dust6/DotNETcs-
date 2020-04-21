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
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmStuToLeadDate.xaml 的交互逻辑
    /// </summary>
    public partial class FrmStuToLeadDate : UserControl
    {
        public FrmStuToLeadDate()
        {
            InitializeComponent();
        }
        StudentManageBLL.StudentManager stuManager = new StudentManageBLL.StudentManager();//处理学生表数据对象
        List<StudentExt> list = null;//包含学员的所有信息集合

        /// <summary>
        /// 本地选择Excel表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectExcel_Click(object sender, RoutedEventArgs e)
        {
            //将本地选择的Excel表数据获取到保存到Datatable表
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();//创建打开文件的对象
            fileDialog.Filter = "工作簿Excel文件(*.xlsx;*.xls)|*.xlsx;*.xls";//检索文件夹类型
            if (fileDialog.ShowDialog()==true)
            {
                string path = fileDialog.FileName;//获取文件的完整路径
                list = stuManager.GetStudentByExcel(path);//获取数据
                dgStudent.ItemsSource = null;//清空表
                dgStudent.AutoGenerateColumns = false; //自动适应
                dgStudent.ItemsSource = list;
            }
        }
        List<StudentExt> lastlist = new List<StudentExt>();//存储不符合要求的数据
        /// <summary>
        ///上传至服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportData_Click(object sender, RoutedEventArgs e)
        {
            //将DataGrid中的数据添加到数据的表中
            //1.逐个上传若Excel某行有问题可针对这个行数据进行检查
            //2.一次性将Excel中所有数据一键上传
            if (list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int res = stuManager.InsertStudent(list[i]);
                    if (res<=0)
                    {
                        lastlist.Add(list[i]);  
                        continue; //跳出循环，此数据不添加
                    }
                }
                if (lastlist.Count<=0) //判断存储不合格数据集合中是否还有数据
                {
                    dgStudent.ItemsSource = null;
                   MessageBox.Show("所有数据已上传成功！", "温馨提示");
                }
                else
                {
                    dgStudent.ItemsSource = null;
                    dgStudent.ItemsSource = lastlist;//将剩余不合格数据添加到表中
                    MessageBox.Show("未全部上传成功,剩余学员信息不符合规范，请修改！！！","温馨提示");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("当前没有任何数据！", "温馨提示");
            }
        }
    }
}
