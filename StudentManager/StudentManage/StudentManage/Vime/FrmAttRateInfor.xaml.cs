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
using StudentManageBLL;
namespace StudentManage.Vime
{
    /// <summary>
    /// FrmAttRateInfor.xaml 的交互逻辑
    /// </summary>
    public partial class FrmAttRateInfor : Window
    {
        AttendaceManager atmanager = new AttendaceManager();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId">班级编号</param>
        /// <param name="className">班级名称</param>
        public FrmAttRateInfor(int classId,string className)
        {
            InitializeComponent();
            this.Title = className + "出勤表";
            smDgScoreLsit.ItemsSource = atmanager.GetAttRateByCId(classId);
        }
    }
}
