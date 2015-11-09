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
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using DevExpress.Xpf.Editors;

namespace SilverlightQLThuebao
{

    public partial class frmnhapuser : ChildWindow
    {
        QLThuebaoDomainContext Listuser = new QLThuebaoDomainContext();     
        int rowMenu,rowHuyen;
        bool m_update;
        string[] m_menu, m_huyen;
        string username_callback,dv;
        FunAndPro callF = new FunAndPro();
        public frmnhapuser(bool capnhat, string mdv, string mhuyen,string mmenu)
        {
            InitializeComponent();           
            m_menu = mmenu.Split(';');          
            m_update = capnhat;
            m_huyen = mhuyen.Split(';');
            dv = mdv;
            EntityQuery<don_vi> Query = Listuser.GetDon_viQuery();
            LoadOperation<don_vi> LoadOp = Listuser.Load(Query, LoadOp_Complete, null);
            EntityQuery<menu> QueryM = Listuser.GetMenusQuery();
            LoadOperation<menu> LoadOpM = Listuser.Load(QueryM.OrderBy(p=>p.id), LoadOpM_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<don_vi> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbhuyen.ItemsSource = lo.Entities;
                this.cmbhuyen.DisplayMember = ("ten_dv").Trim();
                this.cmbhuyen.ValueMember = "ma_dv";

                this.cmbhuyentd.ItemsSource = lo.Entities;
                this.cmbhuyentd.DisplayMember = ("ten_dv").Trim();
                this.cmbhuyentd.ValueMember = "ma_dv";
                if (m_update) // neu cap nhat thi xem coi user do duoc quyen su dung menu nao
                {                   
                    foreach (string s in m_huyen)
                    {
                        foreach (var p in lo.Entities)
                        {
                            if (p.ma_dv.Trim() == s)
                                this.cmbhuyentd.SelectedItems.Add(p);
                        }
                    }
                    for (int i = 0; i < lo.Entities.Count(); i++)
                    {
                        if (lo.Entities.ElementAt(i).ma_dv.Trim() == dv)
                            cmbhuyen.SelectedIndex = i;
                    }
                }
                rowHuyen = lo.Entities.Count(); // de biet duoc so dong trong combobox do items.count luon =0
            }
        }

        void LoadOpM_Complete(LoadOperation<menu> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbmenu.ItemsSource = lo.Entities;
                this.cmbmenu.DisplayMember = ("t_menu").Trim();
                this.cmbmenu.ValueMember = "m_menu";
                if (m_update) // neu cap nhat thi xem coi user do duoc quyen su dung menu nao
                {
                    foreach (string s in m_menu)
                    {
                        foreach (var p in lo.Entities)
                        {
                            if (p.m_menu.Trim() == s)
                                this.cmbmenu.SelectedItems.Add(p);
                        }
                    }
                }
                rowMenu = lo.Entities.Count(); // de biet duoc so dong trong combobox do items.count luon =0
            }
        }
        
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {            
            if (m_update == false) // luu du lieu
            {
                // kiem tra va luu du lieu                 
                EntityQuery<user> Query = Listuser.GetUsersQuery();
                LoadOperation<user> LoadOp = Listuser.Load(Query.Where(p => p.user_name.Trim() == this.txtusername.Text.Trim().ToUpper()), SaveData, null);
               // SaveData1();
            }
            else // cap nhat du lieu
            {               
                EntityQuery<user> Query = Listuser.GetUsersQuery();
                LoadOperation<user> LoadOp = Listuser.Load(Query.Where(p => p.user_name.Trim() == this.txtusername.Text.Trim().ToUpper()), UpdateData, null);
            }

        }

        private void SaveData(LoadOperation<user> lo)
        {           
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("User " + this.txtusername.Text.Trim().ToUpper() + " đã tồn tại");               
            }
            else
            {             
                string m_username, m_pass, m_hoten, m_dt, menu,huyen;
                bool m_gt, m_sua, m_admin, m_admin119, m_lock;
                m_username = this.txtusername.Text.Trim();
                m_pass = callF.EncrytedString(this.txtpass.Text.Trim());                
                m_hoten = this.txthoten.Text.Trim();
                m_dt = this.txtphone.Text.Trim();
                m_gt = chkgt.IsChecked == true ? true : false;
              //  nhomtd = FunAndPro.GetSelectedKeyValue(cmbmaloai, rowLoai);
                menu = FunAndPro.GetSelectedKeyValue(cmbmenu, rowMenu);
                huyen = FunAndPro.GetSelectedKeyValue(cmbhuyentd, rowHuyen);                              
                m_sua = chkSua.IsChecked == true ? true : false;
                m_admin = chkadmin.IsChecked == true ? true : false;
                m_admin119 = chkadmin119.IsChecked == true ? true : false;
                m_lock = chklock.IsChecked == true ? true : false;

                if (m_username != "" && m_pass != "" && m_hoten != "" && menu != "")
                {
                    user us = new user
                    {
                        user_name = m_username,
                        m_password = m_pass,
                        hoten = m_hoten,
                        namsinh = dngaysinh.DateTime,
                        gioitinh = m_gt,
                        phone = m_dt,                                            
                        sua = m_sua,
                        admin=m_admin,
                        admin119 = m_admin119,          
                        lock_usr=false,
                        lan_dau = true,
                        m_menu = menu,
                        huyen=cmbhuyen.GetKeyValue(cmbhuyen.SelectedIndex).ToString(),
                        huyentd=huyen,
                        themes=0
                    };

                    Listuser.users.Add(us);
                    Listuser.SubmitChanges(OnSubmitCompleted, true);

                    this.txtusername.Text = "";
                    this.txtpass.Text = "";
                    this.txthoten.Text = "";
                    this.txtphone.Text = "";
                    chkgt.IsChecked = false;                  
                    cmbmenu.UnselectAllItems();
                    cmbhuyentd.UnselectAllItems();
                    cmbhuyen.EditValue = null;                    
                    chkSua.IsChecked = false;
                    chkadmin.IsChecked = false;
                    chkadmin119.IsChecked = false;
                    chklock.IsChecked = false;
                    this.txtusername.Focus();
                    username_callback = m_username;
                }
                else
                    MessageBox.Show("Nhập chưa đủ thông tin");
            }
        }
        
        private void UpdateData(LoadOperation<user> lo)
        {           
            if (lo.Entities.Count() > 0)
            {
                string m_username, m_pass, m_hoten, m_dt, menu,huyen;
                bool m_gt, m_sua, m_admin, m_admin119, m_lock;
                m_username = this.txtusername.Text.Trim();
                m_pass = callF.EncrytedString(this.txtpass.Text.Trim());
                m_hoten = this.txthoten.Text.Trim();
                m_dt = this.txtphone.Text.Trim();
                m_gt = chkgt.IsChecked == true ? true : false;
                //  nhomtd = FunAndPro.GetSelectedKeyValue(cmbmaloai, rowLoai);
                menu = FunAndPro.GetSelectedKeyValue(cmbmenu, rowMenu);
                huyen = FunAndPro.GetSelectedKeyValue(cmbhuyentd, rowHuyen); 
                m_sua = chkSua.IsChecked == true ? true : false;
                m_admin = chkadmin.IsChecked == true ? true : false;
                m_admin119 = chkadmin119.IsChecked == true ? true : false;
                m_lock = chklock.IsChecked == true ? true : false;

                if (m_username != "" && m_pass != "" && m_hoten != "" && menu != "")
                {                   
                    lo.Entities.ElementAt(0).m_password = m_pass;
                    lo.Entities.ElementAt(0).hoten = m_hoten;
                    lo.Entities.ElementAt(0).namsinh = dngaysinh.DateTime;
                    lo.Entities.ElementAt(0).gioitinh = m_gt;
                    lo.Entities.ElementAt(0).phone = m_dt;
                    lo.Entities.ElementAt(0).sua = m_sua;
                    lo.Entities.ElementAt(0).admin = m_admin;
                    lo.Entities.ElementAt(0).admin119 = m_admin119;
                    lo.Entities.ElementAt(0).lock_usr = m_lock;
                    lo.Entities.ElementAt(0).m_menu = menu;
                    lo.Entities.ElementAt(0).huyen = cmbhuyen.GetKeyValue(cmbhuyen.SelectedIndex).ToString();
                    lo.Entities.ElementAt(0).huyentd = huyen;
                    if (App.User_name == m_username)
                    {
                        App.ma_huyen = cmbhuyen.GetKeyValue(cmbhuyen.SelectedIndex).ToString();
                        App.nhomtd = huyen;
                    }
                    Listuser.SubmitChanges(OnSubmitCompleted, true);

                    this.txtusername.Text = "";
                    this.txtpass.Text = "";
                    this.txthoten.Text = "";
                    this.txtphone.Text = "";                    
                    chkgt.IsChecked = false;
                    cmbmenu.UnselectAllItems();
                    cmbhuyen.SelectedIndex = -1;
                    cmbhuyentd.UnselectAllItems();                   
                    chkSua.IsChecked = false;
                    chkadmin.IsChecked = false;
                    chkadmin119.IsChecked = false;
                    chklock.IsChecked = false;
                    this.txtusername.Focus();
                    username_callback = m_username;
                }
                else
                MessageBox.Show("Nhập chưa đủ thông tin");                 
            }            
        }

        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            if (m_update)
                this.DialogResult = false;
            else
                MessageBox.Show("Đã thêm user :" + username_callback);
        }       

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {          
           this.DialogResult = false;                      
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmusers fusr = new frmusers();
            fusr.txttim.Text = username_callback;
            fusr.Show();
        }
    }
}

