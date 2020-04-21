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
using System.Windows.Threading;
using System.Configuration;
using System.IO;
namespace StudentManage
{
    /// <summary>
    /// FrmMain.xaml 的交互逻辑
    /// </summary>
    public partial class FrmMain : Window
    {
        public FrmMain()
        {
            InitializeComponent();
            //在打开程序时存储学员图片到files集合
           /* List<string> files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/img/printImg/").ToList();
            if (files.Count > 0) //如果一种相同的图片多余两张
            {
                foreach (string item in files)
                {
                    File.Delete(item); //将多余的图片删除
                }
            }*/


            //程序中必须要有一个主程序，而FrmMain窗体作为主窗体，密码账号验证后进入主窗体
            #region //登录窗体显示 密码验证
            FrmLogin log = new FrmLogin();
            log.ShowDialog();
            if (log.DialogResult!=true)
            {
                Environment.Exit(0);
            }
            #endregion
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
            try
            {
                statusAdminLb.Content = "操作管理员【" + App.CurrentAdmin.AdminName + "】";
                statusVersionLb.Content = "版本号：" + ConfigurationManager.AppSettings["version"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        DispatcherTimer timer = null; //用于改变页面时间的定时器
        //改变时间信息定时器
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; //实例化现在时间对象
            string week = "星期天";
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    week = "星期天";
                    break;
                case DayOfWeek.Monday:
                    week = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    week = "星期四";
                    break;
                case DayOfWeek.Friday:
                    week = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    week = "星期六";
                    break;
                default:
                    break;
            }
            statusTimeLb.Content = string.Format("{0}年{1}月{2}日 {3}:{4}:{5}{6}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, week);
            //设置现在时间
        }
        //关闭窗体
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //最小化窗体
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //修改密码
        private void updatePwd_Click(object sender, RoutedEventArgs e)
        {

        }

        //添加学员
        private void addsMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAddStudentInfor addstu = new Vime.FrmAddStudentInfor();
            Gird_Content.Children.Add(addstu);
        }
        //信息管理
        private void smMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear(); 
            Vime.FrmStuManager frmstudent = new Vime.FrmStuManager(); //实例化用户窗体
            Gird_Content.Children.Add(frmstudent);
        }

        //成绩录入
        private void writesMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAddScore AddScore = new Vime.FrmAddScore();
            Gird_Content.Children.Add(AddScore);
        }
        //成绩分析
        private void checksMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmScoreManager SeleScore = new Vime.FrmScoreManager();
            Gird_Content.Children.Add(SeleScore);
        }

        //考勤查询
        private void queraMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAttendanceManager addAtt = new Vime.FrmAttendanceManager();
            Gird_Content.Children.Add(addAtt);
        }
        //考勤打卡
        private void adakaMenu_Click(object sender, RoutedEventArgs e)
        {
            Vime.FrmAddatInfor att = new Vime.FrmAddatInfor();
            att.ShowDialog();
        }

        //在线帮助(访问官网)
        private void inlinehMenu_Click(object sender, RoutedEventArgs e)
        {
            //第一种查看网址
            /*System.Diagnostics.Process.Start("https://blog.csdn.net/dust__");*/
            //第二种查看网址，将网址存入配置文件App.config中，方便后期修改
            System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["webadd"].ToString());
            //第三种查看网址，创建用户窗体(资源词典)查看网站 不方便使用
            /*Gird_Content.Children.Clear();
            Vime.FrmBorderWeb frweb = new Vime.FrmBorderWeb();
            Gird_Content.Children.Add(frweb);*/
        }
        //联系我们
        private void lianxiadmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请联系QQ: 1223256111","联系我们");
        }
       
        //添加学员
        private void btnAttStu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAddStudentInfor addstu = new Vime.FrmAddStudentInfor();
            Gird_Content.Children.Add(addstu);
        }
        
        //成绩录入
        private void btnAddscore_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAddScore AddScore = new Vime.FrmAddScore();
            Gird_Content.Children.Add(AddScore);
        }
        //成绩分析
        private void btnSco_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmScoreManager SeleScore = new Vime.FrmScoreManager();
            Gird_Content.Children.Add(SeleScore);
        }

        
        //考勤打卡
        private void btnAttClock_Click(object sender, RoutedEventArgs e)
        {
            Vime.FrmAddatInfor att = new Vime.FrmAddatInfor();
            att.ShowDialog();
        }
        //考勤查询
        private void btnSeleAtt_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmAttendanceManager SeleAtt = new Vime.FrmAttendanceManager();
            Gird_Content.Children.Add(SeleAtt);
        }


        //批量导入
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            Vime.FrmStuToLeadDate tolead = new Vime.FrmStuToLeadDate();
            Gird_Content.Children.Add(tolead);
        }
        //设置快捷键
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //esc键 最小化
                if (e.Key == Key.Escape)
                {
                    this.WindowState = WindowState.Minimized;
                }
                //Alt+Q 关闭窗体
                else if ((e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt)) && e.KeyboardDevice.IsKeyDown(Key.Q))
                {
                    this.Close();
                }

                //M键 打开学员管理下拉框
                else if (e.KeyboardDevice.IsKeyDown(Key.M))
                {
                    menuStuMan.IsSubmenuOpen = true;
                }
                //S+A键 添加学员
                else if ( e.KeyboardDevice.IsKeyDown(Key.S)&&e.KeyboardDevice.IsKeyDown(Key.A))
                {
                    btnAttStu_Click(null, null);
                }
                //S+X键 打开学员信息管理
                else if (e.KeyboardDevice.IsKeyDown(Key.S) && e.KeyboardDevice.IsKeyDown(Key.X))
                {
                    smMenu_Click(null, null);
                }

                //J键 打开成绩管理下拉框
                else if (e.Key == Key.J)
                {
                    menuScore.IsSubmenuOpen = true;
                }
                //成绩录入 C+A
                else if (e.KeyboardDevice.IsKeyDown(Key.C)&&e.KeyboardDevice.IsKeyDown(Key.A))
                {
                    writesMenu_Click(null, null);
                }
                //成绩分析 C+S
                else if (e.KeyboardDevice.IsKeyDown(Key.C) && e.KeyboardDevice.IsKeyDown(Key.S))
                {
                    checksMenu_Click(null, null);
                }

                //A键 考勤管理下拉框
                else if (e.Key==Key.A)
                {
                    menuAttandce.IsSubmenuOpen = true;
                }
                //考勤查询 A+S 
                else if (e.KeyboardDevice.IsKeyDown(Key.A) && e.KeyboardDevice.IsKeyDown(Key.S))
                {
                    queraMenu_Click(null, null);
                }
                //考勤打卡 A+C 
                else if (e.KeyboardDevice.IsKeyDown(Key.C) && e.KeyboardDevice.IsKeyDown(Key.C))
                {

                }


                //H键 帮助下拉框
                else if (e.Key==Key.H)
                {
                    menuHelp.IsSubmenuOpen = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
