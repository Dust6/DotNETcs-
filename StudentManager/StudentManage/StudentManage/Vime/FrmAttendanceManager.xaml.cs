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
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmAttendanceManager.xaml 的交互逻辑
    /// </summary>
    public partial class FrmAttendanceManager : UserControl
    {
        StudentClassManager stuclassManager = new StudentClassManager();//处理班级数据
        AttendaceManager attManager = new AttendaceManager(); //处理考勤数据
        List<AttInforExt> attInfo = null; //考勤表对象
        public FrmAttendanceManager()
        {
            InitializeComponent();
            List<StudentClass> stuclass = stuclassManager.GetClasses(); //获取班级表数据
            smclassCmb.ItemsSource = stuclass;
            smclassCmb.DisplayMemberPath = "ClassName";
            smclassCmb.SelectedValuePath = "ClassID";
            smclassCmb.SelectedIndex = 1;
            attInfo = attManager.GetAttInfors(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgScoreLsit.ItemsSource = attInfo;
        }
        //班级 提交查询
        private void btnSelectByCId_Click(object sender, RoutedEventArgs e)
        {
            if (smclassCmb.SelectedIndex < 0)
            {
                MessageBox.Show("请选择班级", "提示");
                return;
            }
            attInfo = attManager.GetAttInfors(Convert.ToInt32(smclassCmb.SelectedValue));   //获取下拉框选定的班级名
            smDgScoreLsit.ItemsSource = attInfo;//添加班级名对应的成绩表
        }
        //关闭窗体
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        //输入学号/姓名查询
        private void btnSelectBySIN_Click(object sender, RoutedEventArgs e)
        {
            string target = mstxtIdorName.Text.Trim();//输入的学号或姓名
            List<AttInforExt> liststu = attManager.GetAttByStuIDorName(target);//查询的数据表
            if (liststu.Count < 0)
            {
                MessageBox.Show("未查找到有个信息！", "提示");
                return;
            }
            attInfo = liststu;
            smDgScoreLsit.ItemsSource = null; //清空表格
            smDgScoreLsit.ItemsSource = attInfo;//添加信息
        }
        //导出考勤表
        private void btnExportStu_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog(); //创建工作簿对象
            fileDialog.Filter = "Excel工作簿(*.xlsx;*.xls)|*.xlsx;*.xls"; //检索格式
            fileDialog.FileName = "考勤表.xlsx"; //设置工作簿的名称(桌面见到的名称)
            fileDialog.Title = "导出Excel表";
            if (fileDialog.ShowDialog() == true) //如果工作簿的窗体打开
            {
                string path = fileDialog.FileName; //存储的位置
                System.Data.DataTable table = attManager.GetAttByCId((int)smclassCmb.SelectedValue);
                if (table.Rows.Count <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("该班级暂无学生信息！", "提示");
                    return;
                }
                if (Commmon.DeriveExportTab.ExportScoreToExcel(table, path))
                {
                    MessageBox.Show("导出数据完成！", "提示");
                }
                else
                {
                    MessageBox.Show("导出数据失败，请稍后再试！", "提示");
                }
            }
        }
        //打印考勤表
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
        //按照班级，查询出勤次数
        private void btnAttRate_Click(object sender, RoutedEventArgs e)
        {
            int classId =Convert.ToInt32(smclassCmb.SelectedValue); //选中的班级编号
            string className = smclassCmb.Text.Trim();//选中的班级名称
            Vime.FrmAttRateInfor atrate = new FrmAttRateInfor(classId,className);
            atrate.ShowDialog();
        }
    }
}
