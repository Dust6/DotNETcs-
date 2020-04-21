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
using StudentManageBLL; //数据访问命名空间
using StudentManageModel; //实体对象命名空间
using Commmon; //通用命名空间
namespace StudentManage
{
    /// <summary>
    /// FrmLogin.xaml 的交互逻辑
    /// </summary>
    public partial class FrmLogin : Window
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //关闭登录窗体
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //最小化窗体
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //登录
        private void btnLoin_Click(object sender, RoutedEventArgs e)
        {
            //数据验证
            if (txtLogID.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "登录提示");
                txtLogID.Focus(); //获取焦点
                return;
            }
            if (DataValidate.IsInteger(txtLogID.Text.Trim()) == false) //Datavalidate存在common问文件下，通过正则表达式判断输入的账号是否为数字
            {
                MessageBox.Show("请输入正确账号！(纯数字格式)", "登录提示");
                txtLogID.Focus();
                return;
            }
            if (txtLogPwd.Password.Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "登录提示");
                txtLogPwd.Focus();
                return;
            }
            //输入的账号密码
            Admins admin = new Admins()
            {
                LoginID = Convert.ToInt32(txtLogID.Text.Trim()), //获取到输入的账号
                LoginPwd = txtLogPwd.Password.Trim() //输入的密码 
            };
            //和后台交互查询，判断登录信息是否正确
            try
            {
                Admins mainuse = new AdminManager().GetAdmins(admin); //通过管理员账号获取到密码
                if (mainuse == null)
                {
                    MessageBox.Show("用户账号不存在！", "提示信息");
                    txtLogID.Focus(); //获取焦点
                }
                else
                {
                    if (mainuse.LoginPwd == txtLogPwd.Password)
                    {
                        //保存登录信息
                        App.CurrentAdmin = mainuse;
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户密码错误！", "提示信息");
                        txtLogPwd.Focus();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("服务器连接异常，登录失败！请检查您的网络！");
            }
        }
    }
}
