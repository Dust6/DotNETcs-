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
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmAddScore.xaml 的交互逻辑
    /// </summary>
    public partial class FrmAddScore : UserControl
    {
        StudentManager stumanage = new StudentManager();//学生处理数据类对象
        ScoreManager scomanage = new ScoreManager(); //成绩处理数据类型对象
        StudentExt stuexe = null;
        StuCoreExt scoexe = null;
        StuCoreExt scoreexe = new StuCoreExt();
        public FrmAddScore()
        {
            InitializeComponent();
        }
        //输入学号失焦事件
        private void textstuId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textstuId.Text))
            {
                System.Windows.Forms.MessageBox.Show("学号不能为空！！！","提示");
                textstuId.Focus();
            }
            else
            {
                int stuId = Convert.ToInt32(textstuId.Text.Trim());
                //先判断是否存在此学生，再判断是否存在成绩
                 stuexe = stumanage.GetStudentById(stuId); //获取到学生信息
                scoexe = scomanage.GetStudentById(stuId); //获取学生的成绩信息
                //1.判断是否存在此学生，存在的话，再判断是否已经存储成绩
                if (stuexe!=null)
                {
                    //2.判断是否已有成绩
                    if (scoexe==null)  //如果没有成绩
                    {
                        labStuName.Content = stuexe.StudentName; //姓名显示
                        labStuClass.Content = stuexe.ClassName; //学号显示
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("已有成绩，请重新输入！！！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        textstuId.Focus();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("不存在此学生，请重新输入！！！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    textstuId.Focus();
                }

            }
        }
        //C#成绩失焦事件
        private void textCs_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataValidate.IsInteger(textCs.Text.Trim())==false)
            {
                System.Windows.Forms.MessageBox.Show("请输入正确分数！！！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
        }
        //SQL成绩失焦事件
        private void textSQL_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataValidate.IsInteger(textSQL.Text.Trim()) == false)
            {
                System.Windows.Forms.MessageBox.Show("请输入正确分数！！！", "友情提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

        }
        //确认添加
        private void btnAffirm_Click(object sender, RoutedEventArgs e)
        {
            scoreexe.StudentID = Convert.ToInt32(textstuId.Text.Trim());
            scoreexe.CSharp = Convert.ToInt32(textCs.Text.Trim());
            scoreexe.SQLServerDB = Convert.ToInt32(textSQL.Text.Trim());
            scoreexe.ScoreUpdateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            if (scomanage.AddScore(scoreexe))
            {
                System.Windows.Forms.MessageBox.Show("添加成功","提示");
                this.Visibility = Visibility.Hidden; //隐藏窗体
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("添加失败，请稍后再试！！","提示");
            }
        }
        //取消添加
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

    }
}
