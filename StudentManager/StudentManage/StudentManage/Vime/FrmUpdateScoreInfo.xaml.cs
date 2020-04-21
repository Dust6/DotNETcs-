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
using StudentManageModel;
using StudentManageModel.ObjExt;
using StudentManageBLL;
using Commmon;
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmUpdateScoreInfo.xaml 的交互逻辑
    /// </summary>
    public partial class FrmUpdateScoreInfo : Window
    {
        public StuCoreExt score { get; set; }
        ScoreManager scormanage = new ScoreManager();
        public FrmUpdateScoreInfo(StuCoreExt scorexe)
        {
            score = scorexe;
            InitializeComponent();
            labStuName.Content = scorexe.StudentName;
            labStuID.Content = scorexe.StudentID;
            textCsharpScore.Text = scorexe.CSharp.ToString();
            textSqlScore.Text = scorexe.SQLServerDB.ToString();
        }
        //C#分数失焦事件
        private void textCsharpScore_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textCsharpScore.Text))
            {
                System.Windows.MessageBox.Show("请输入课程分数！");
            }
        }
        //SQl分数失焦事件
        private void textSqlScore_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textSqlScore.Text))
            {
                System.Windows.MessageBox.Show("请输入课程分数！");
            }
            /*else if (DataValidate.IsInteger(textSqlScore.Text.Trim()))
            {
                System.Windows.MessageBox.Show("分数必须为纯数字！");
                textSqlScore.Focus();
            }*/
        }
        //确定修改
        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            score.CSharp = Convert.ToInt32(textCsharpScore.Text.Trim());
            score.SQLServerDB = Convert.ToInt32(textSqlScore.Text.Trim());
            if (scormanage.UpScore(score))
            {
                System.Windows.MessageBox.Show("修改成功！", "提示");
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("修改失败，请稍后再试！", "提示");
            }
        }
        //取消修改
        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
