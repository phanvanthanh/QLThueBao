﻿#pragma checksum "D:\Projects\SilverlightQLThuebao\SilverlightQLThuebao\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "52C002B71AEAD6E70FAC02B9520C6021"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SilverlightQLThuebao {
    
    
    public partial class LoginPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal DevExpress.Xpf.Editors.TextEdit txtusername;
        
        internal DevExpress.Xpf.Editors.PasswordBoxEdit txtpassword;
        
        internal System.Windows.Controls.TextBlock Login;
        
        internal System.Windows.Controls.Button cmdLogin;
        
        internal DevExpress.Xpf.Core.WaitIndicator prg;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightQLThuebao;component/LoginPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtusername = ((DevExpress.Xpf.Editors.TextEdit)(this.FindName("txtusername")));
            this.txtpassword = ((DevExpress.Xpf.Editors.PasswordBoxEdit)(this.FindName("txtpassword")));
            this.Login = ((System.Windows.Controls.TextBlock)(this.FindName("Login")));
            this.cmdLogin = ((System.Windows.Controls.Button)(this.FindName("cmdLogin")));
            this.prg = ((DevExpress.Xpf.Core.WaitIndicator)(this.FindName("prg")));
        }
    }
}

