﻿#pragma checksum "D:\SilverlightQLThuebao\SilverlightQLThuebao\Forms\frmlogusers.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CD7AAB2410954F92C01921E3EC2C4681"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
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
    
    
    public partial class frmlogusers : DevExpress.Xpf.Core.DXWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal DevExpress.Xpf.Grid.GridControl grid;
        
        internal DevExpress.Xpf.Grid.GridColumn users;
        
        internal DevExpress.Xpf.Grid.GridColumn ip_address;
        
        internal DevExpress.Xpf.Grid.GridColumn thoi_gian;
        
        internal DevExpress.Xpf.Grid.GridColumn thanhcong;
        
        internal DevExpress.Xpf.Grid.TableView tableView1;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button cmdXoa;
        
        internal DevExpress.Xpf.Editors.TextEdit txttim;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.Button FindButton;
        
        internal DevExpress.Xpf.Editors.CheckEdit chkall;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightQLThuebao;component/Forms/frmlogusers.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.grid = ((DevExpress.Xpf.Grid.GridControl)(this.FindName("grid")));
            this.users = ((DevExpress.Xpf.Grid.GridColumn)(this.FindName("users")));
            this.ip_address = ((DevExpress.Xpf.Grid.GridColumn)(this.FindName("ip_address")));
            this.thoi_gian = ((DevExpress.Xpf.Grid.GridColumn)(this.FindName("thoi_gian")));
            this.thanhcong = ((DevExpress.Xpf.Grid.GridColumn)(this.FindName("thanhcong")));
            this.tableView1 = ((DevExpress.Xpf.Grid.TableView)(this.FindName("tableView1")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.cmdXoa = ((System.Windows.Controls.Button)(this.FindName("cmdXoa")));
            this.txttim = ((DevExpress.Xpf.Editors.TextEdit)(this.FindName("txttim")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.FindButton = ((System.Windows.Controls.Button)(this.FindName("FindButton")));
            this.chkall = ((DevExpress.Xpf.Editors.CheckEdit)(this.FindName("chkall")));
        }
    }
}

