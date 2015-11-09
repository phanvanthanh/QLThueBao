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

namespace SilverlightQLThuebao
{
    public partial class frmnhapnvcs : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<nhanvien_cs> LoadOp;
        LoadOperation<Mdiaban> LoadOpM;
        int rowMenu;
        string[] m_diaban;
        bool m_update;
        public frmnhapnvcs(bool update, string mdiaban)
        {
            InitializeComponent();
            m_update = update;
            m_diaban = mdiaban.Split(';');    
            if (App.kythuat)
                checkEdit1.IsChecked = true;
            else
                checkEdit1.IsChecked = false;
            checkEdit1.IsEnabled = false;

            if (! m_update)            
                this.txtmanv.Text ="";
            else
                this.txtmanv.IsReadOnly = true;

            EntityQuery<Mdiaban> QueryM = dstb.GetMadiabanTrimQuery();
            LoadOpM = dstb.Load(QueryM.Where(p=>p.ma_huyen==App.ma_huyen).OrderBy(p => p.ten_tuyen), LoadOpM_Complete, null);
        }

        void LoadOpM_Complete(LoadOperation<Mdiaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbdiaban.ItemsSource = lo.Entities;
                this.cmbdiaban.DisplayMember = ("ten_tuyen").Trim();
                this.cmbdiaban.ValueMember = "ma_tuyen";
                if (m_update) // neu cap nhat thi xem coi user do duoc quyen su dung menu nao
                {
                    foreach (string s in m_diaban)
                    {
                        foreach (var p in lo.Entities)
                        {
                            if (p.ma_tuyen.Trim() == s)
                                this.cmbdiaban.SelectedItems.Add(p);
                        }
                    }
                }
                rowMenu = lo.Entities.Count(); // de biet duoc so dong trong combobox do items.count luon =0
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            string ma_nv=this.txtmanv.Text.Trim().ToUpper();
            EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
            LoadOperation<nhanvien_cs> Load = dstb.Load(Query.Where(p => p.ma_nvcs.Trim() != ma_nv && p.ma_huyen == App.ma_huyen),CheckDouble,null);           
        }

        void CheckDouble(LoadOperation<nhanvien_cs> lo)
        {
            string s="";
            if (lo.Entities.Count() > 0 && (App.ma_huyen !="CTH" || App.ma_huyen !="TVH"))
            {
                foreach (var p in cmbdiaban.SelectedItems)
               {
                    string key_firts=p.ToString().Substring(9,p.ToString().Length-9).Trim();
                    string key = ";" + key_firts + ";";
                    
                    for (int j = 0; j < lo.Entities.Count(); j++)     
                    {
                        string mdb = lo.Entities.ElementAt(j).diaban == null ? "" : lo.Entities.ElementAt(j).diaban.ToString();
                        
                        if (mdb.Contains(key) || mdb==key)
                        {
                            for (int i = 0; i < LoadOpM.Entities.Count(); i++)
                            {
                                if (LoadOpM.Entities.ElementAt(i).ma_tuyen.Trim() == key_firts)
                                    s = LoadOpM.Entities.ElementAt(i).ten_tuyen.Trim();
                            }
                            MessageBox.Show("Địa bàn: " + s + " đã được gán cho: " + lo.Entities.ElementAt(j).ten_nv.Trim() + " không thể gán trùng được !");
                            return;
                        }
                    }
                }   
            }

            EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
            if (m_update)
                LoadOp = dstb.Load(Query.Where(p => p.ma_nvcs.Trim() == this.txtmanv.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen && p.kt == App.kythuat), UpdateData, null);
            else
                LoadOp = dstb.Load(Query.Where(p => p.ma_nvcs == this.txtmanv.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), SaveData, null);
            // SaveData1();

        }

       

        private void UpdateData(LoadOperation<nhanvien_cs> lo)
        {
            string m = FunAndPro.GetSelectedKeyValue(cmbdiaban, rowMenu);
            if (m.Length > 0)
                m = ";" + m + ";";
            if (lo.Entities.Count() > 0)
            {   
                lo.Entities.ElementAt(0).ten_nv = txtten.Text.Trim();
                lo.Entities.ElementAt(0).phone = txtphone.Text.Trim();
                lo.Entities.ElementAt(0).diaban = m;

                nhanvien_cs_log apl = new nhanvien_cs_log
                {
                    ma_nvcs = txtmanv.Text.Trim().ToUpper(),
                    ten_nv = this.txtten.Text.Trim(),
                    ma_huyen = App.ma_huyen,
                    kt = checkEdit1.IsChecked,
                    phone = txtphone.Text.Trim(),
                    diaban = m,
                    users = App.User_name,
                    thoi_gian = App.Current_d
                };
                dstb.nhanvien_cs_logs.Add(apl);
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<nhanvien_cs> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã cán bộ " + this.txtmanv.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmanv.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    string m = FunAndPro.GetSelectedKeyValue(cmbdiaban, rowMenu);
                    if (m.Length > 0)
                        m = ";" + m + ";";
                    nhanvien_cs ap = new nhanvien_cs
                    {
                       ma_nvcs = txtmanv.Text.Trim().ToUpper(),
                       ten_nv = this.txtten.Text.Trim(),
                       ma_huyen=App.ma_huyen,
                       kt=checkEdit1.IsChecked,
                       phone=txtphone.Text.Trim(),
                       diaban=m
                    };
                    nhanvien_cs_log apl = new nhanvien_cs_log
                    {
                        ma_nvcs = txtmanv.Text.Trim().ToUpper(),
                        ten_nv = this.txtten.Text.Trim(),
                        ma_huyen = App.ma_huyen,
                        kt = checkEdit1.IsChecked,
                        phone = txtphone.Text.Trim(),
                        diaban = m,
                        users=App.User_name,
                        thoi_gian=App.Current_d
                    };
                    dstb.nhanvien_cs.Add(ap);
                    dstb.nhanvien_cs_logs.Add(apl);
                    dstb.SubmitChanges(OnSubmitCompleted, true);
                }
                else
                    MessageBox.Show("Nhập chưa đủ thông tin hoặc sai qui cách nhập mã cán bộ !");
            }
        }
        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                if (m_update)
                    this.DialogResult = false;
                else
                {
                    MessageBox.Show("Đã thêm nhân viên :" + txtten.Text.Trim());
                    this.txtten.Text = "";
                    this.txtmanv.Text ="";                    
                    this.txtmanv.Focus();
                    this.txtphone.Text = "";
                    //checkEdit1.IsChecked = false;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmnhanviencs frm = new frmnhanviencs();
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }

        private void txtten_LostFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}

