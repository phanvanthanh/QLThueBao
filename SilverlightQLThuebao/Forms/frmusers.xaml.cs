using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;
using DevExpress.Xpf.Core;


namespace SilverlightQLThuebao
{
    public partial class frmusers : ChildWindow
    {
        QLThuebaoDomainContext users = new QLThuebaoDomainContext();
        FunAndPro callF = new FunAndPro();
        int rowH,rowN;
        public frmusers()
        {
            InitializeComponent();
            dien_dl();      
            //string formattedDate = String.Format("{0:dd/MM/yyyy hh:mm}", namsinh.);
            //e.DisplayText = formattedDate;
            //foreach (var c in grid.Columns)
            //{
            //    if (c.GetType == typeof(DateTime))
            //    {
            //        c.DisplayFormat.FormatString = "G";
            //    }
            //}
        }
        private void dien_dl()
        {
            grid.ShowLoadingPanel = true;
            EntityQuery<user> Query = users.GetUsersQuery();
            LoadOperation<user> LoadOp = users.Load(Query.OrderBy(p => p.huyen),dien_dl1,null);                
        }

        private void dien_dl1(LoadOperation<user> lo)
        {            
            grid.ItemsSource = lo.Entities;           
            grid.ShowLoadingPanel = false;
            rowN = lo.Entities.Count();
            Tim();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {           
           this.DialogResult = false;          
        }

        private void cmdThem_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            frmnhapuser frmnhapuser = new frmnhapuser(false,"", "", "");
            frmnhapuser.Show();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                string usr = grid.GetFocusedRowCellValue(username).ToString().Trim();
                EntityQuery<user> Query = users.GetUsersQuery();
                LoadOperation<user> LoadOp = users.Load(Query.Where(p => p.user_name.Trim() == usr), ResetComplete, null);
            }
            else
                MessageBox.Show("Chọn user cần reset mật khẩu !");
            
        }

        private void ResetComplete(LoadOperation<user> lo)
        {
            string usr= grid.GetFocusedRowCellValue(username).ToString().Trim();
            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).m_password = callF.EncrytedString(usr);
                lo.Entities.ElementAt(0).lan_dau = true;
                users.SubmitChanges();
                MessageBox.Show("Đã reset mật khẩu là tên truy cập cho user : " + usr);
            }
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {
           
            if (grid.GetFocusedRow() != null)
            {
                string usr = grid.GetFocusedRowCellValue(username).ToString().Trim();
                if (usr == App.User_name)
                {
                    MessageBox.Show("Không thể xóa user của chính mình !");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Muốn xóa user " + usr + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {  
                        rowH = grid.View.FocusedRowHandle;                        
                        if (rowH < rowN && rowH > 0)
                        {
                            rowH = rowH - 1;
                        }
                        else
                            rowH = rowH + 1;
                        if (rowH == rowN)
                            rowH = rowH - 1;
                        EntityQuery<user> Query = users.GetUsersQuery();
                        LoadOperation<user> LoadOp = users.Load(Query.Where(p => p.user_name.Trim() == usr), DeleteCompleted, true);                       
                }
                else
                    return;  
            }
            else
                MessageBox.Show("Chọn user cần xóa !");            
        }

        private void DeleteCompleted(LoadOperation<user> lo)
        {
            user bm = lo.Entities.First();
            users.users.Remove(bm);
            users.SubmitChanges(OnSubmitCompleted, null);

            // dien_dl();

        }

        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            dien_dl();
        }

        private void Tim()
        {
            string tim, tim1;
            tim = this.txttim.Text==null ? "": this.txttim.Text.Trim().ToUpper();
            this.txttim.Text = tim;
            
            for (int i = 0; i < grid.VisibleRowCount; i++)
            {
                int rowHandle = grid.GetRowHandleByVisibleIndex(i);
                if (!grid.IsGroupRowHandle(rowHandle))
                {
                    tim1 = grid.GetCellValue(rowHandle, username).ToString().Trim().ToUpper();
                    if (tim1 == tim)
                    {
                        grid.ExpandGroupRow(rowHandle);
                        grid.View.FocusedRowHandle = rowHandle;
                        return;
                    }
                }
            }           
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Tim();
        }

        private void cmdSua_Click(object sender, RoutedEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                this.DialogResult = true;                
                string m_menu = grid.GetFocusedRowCellValue(menu).ToString().Trim();
                string m_huyen = grid.GetFocusedRowCellValue(huyen).ToString().Trim();
                string m_huyentd = grid.GetFocusedRowCellValue(huyentd).ToString().Trim();
                frmnhapuser frmnhapuser = new frmnhapuser(true, m_huyen, m_huyentd, m_menu);
                frmnhapuser.txtusername.Text = grid.GetFocusedRowCellValue(username).ToString().Trim();
                frmnhapuser.txtpass.Text = callF.DecrytedString(grid.GetFocusedRowCellValue(pass).ToString().Trim());
                frmnhapuser.txthoten.Text = grid.GetFocusedRowCellValue(hoten).ToString().Trim();
                frmnhapuser.chkgt.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(gioitinh));
                frmnhapuser.dngaysinh.EditValue = Convert.ToDateTime(grid.GetFocusedRowCellValue(namsinh));
                frmnhapuser.txtphone.Text = grid.GetFocusedRowCellValue(dienthoai) == null ? "" : grid.GetFocusedRowCellValue(dienthoai).ToString().Trim();                
                frmnhapuser.chkSua.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(sua));
                frmnhapuser.chklock.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(lock_usr));
                frmnhapuser.chkadmin.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(admin));
                frmnhapuser.chkadmin119.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(admin119));
                frmnhapuser.txtusername.IsEnabled = false;
                frmnhapuser.Show();
            }
            else
                MessageBox.Show("Chọn user cần sửa thông tin");
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                this.DialogResult = true;
                string m_menu = grid.GetFocusedRowCellValue(menu).ToString().Trim();
                string m_huyen = grid.GetFocusedRowCellValue(huyen).ToString().Trim();
                string m_huyentd = grid.GetFocusedRowCellValue(huyentd).ToString().Trim();
                frmnhapuser frmnhapuser = new frmnhapuser(true, m_huyen, m_huyentd, m_menu);
                frmnhapuser.txtusername.Text = grid.GetFocusedRowCellValue(username).ToString().Trim();
                frmnhapuser.txtpass.Text = callF.DecrytedString(grid.GetFocusedRowCellValue(pass).ToString().Trim());
                frmnhapuser.txthoten.Text = grid.GetFocusedRowCellValue(hoten).ToString().Trim();
                frmnhapuser.chkgt.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(gioitinh));
                frmnhapuser.dngaysinh.EditValue = Convert.ToDateTime(grid.GetFocusedRowCellValue(namsinh));
                frmnhapuser.txtphone.Text = grid.GetFocusedRowCellValue(dienthoai) == null ? "" : grid.GetFocusedRowCellValue(dienthoai).ToString().Trim();
                frmnhapuser.chkSua.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(sua));
                frmnhapuser.chklock.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(lock_usr));
                frmnhapuser.chkadmin.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(admin));
                frmnhapuser.chkadmin119.IsChecked = Convert.ToBoolean(grid.GetFocusedRowCellValue(admin119));
                frmnhapuser.txtusername.IsEnabled = false;
                frmnhapuser.Show();
            }
            else
                MessageBox.Show("Chọn user cần sửa thông tin");
        }
    }
}

