﻿#pragma checksum "..\..\..\Vime\FrmUpdateScoreInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9DADB4FC92B9D235D147FAD9712D89BD3AE85EA0432B542E7CF9CC914B0841FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using StudentManage.Vime;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StudentManage.Vime {
    
    
    /// <summary>
    /// FrmUpdateScoreInfo
    /// </summary>
    public partial class FrmUpdateScoreInfo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labStuName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labStuID;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textCsharpScore;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textSqlScore;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCon;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCal;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StudentManage;component/vime/frmupdatescoreinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.labStuName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.labStuID = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.textCsharpScore = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
            this.textCsharpScore.LostFocus += new System.Windows.RoutedEventHandler(this.textCsharpScore_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textSqlScore = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
            this.textSqlScore.LostFocus += new System.Windows.RoutedEventHandler(this.textSqlScore_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCon = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
            this.btnCon.Click += new System.Windows.RoutedEventHandler(this.btnCon_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCal = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\Vime\FrmUpdateScoreInfo.xaml"
            this.btnCal.Click += new System.Windows.RoutedEventHandler(this.btnCal_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

