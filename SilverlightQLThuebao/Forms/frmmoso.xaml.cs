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
    public partial class frmmoso : ChildWindow
    {
         QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<loaicatmo> LoadOploai;
        public frmmoso()
        {
            InitializeComponent();
            OKButton.IsEnabled = false; 
            EntityQuery<loaicatmo> Query = dstb.GetLoaiCatMoQuery();
            LoadOploai = dstb.Load(Query.OrderBy(p=>p.id), LoadOpL_Complete, null);
        }

        void LoadOpL_Complete(LoadOperation<loaicatmo> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbloai.DisplayMember = ("ten_yc");
                this.cmbloai.ValueMember = "ma_yc";
                this.cmbloai.ItemsSource = lo.Entities;

            }
        }

        private void txtsdt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtsdt.Text.Length == App.len_sdt)
            {
                {
                    EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                    LoadOperation<ds_codinh> LoadOp = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text), LoadOp_Complete, null);

                }
            }
            else
            {
                if (this.txtsdt.Text.Length > 0)
                {
                    MessageBox.Show("Chưa nhập đúng định dạng !");
                    txtsdt.Focus();
                }
            }
        }
        void LoadOp_Complete(LoadOperation<ds_codinh> lo)
        {
            if (lo.Entities.Count() > 0)
            {               
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_dkdb == null ? "" : lo.Entities.ElementAt(0).ten_dkdb.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();                                              
               // enable_control(false);
                OKButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Thuê bao này chưa có trong CSDL !");
                Clear_control();
               // enable_control(true);                
                OKButton.IsEnabled = false;
            }
        }
    

        void Clear_control()
        {
            this.txtsdt.Text = "";
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtdlu.Text = "";
            this.txtshelf.Text = "";
            this.txtslp.Text = "";
            this.txten.Text = "";
            this.txtmod.Text = "";
            this.txtport.Text = "";
            this.txtframe.Text = "";
            this.txtslot.Text = "";
            this.rdomo.IsChecked = true;
            this.cmbloai.SelectedIndex = -1;
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string m_sdt, m_dv;
            bool m_mo;
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            if (txtsdt.Text.Trim() != "" && cmbloai.SelectedIndex >= 0)
            {
                m_sdt = txtsdt.Text.Trim();
                m_dv = cmbloai.GetKeyValue(cmbloai.SelectedIndex).ToString();
                if (rdomo.IsChecked == true)
                    m_mo = false;
                else
                    m_mo = true;
                EntityQuery<cat_mo> Query = dstb.GetCat_moQuery();
                LoadOperation<cat_mo> LoadOp = dstb.Load(Query.Where(p=>p.so_dt==m_sdt && p.ma_yc.Trim()==m_dv && p.mo==m_mo), LoadOp_Complete, null);
            }
            else
                MessageBox.Show("Nhập chưa đủ thông tin");
        }
        void LoadOp_Complete(LoadOperation<cat_mo> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Thuê bao này đã yêu cầu rồi ! đang chờ mở !");
            }
            else
            {
                cat_mo cm = new cat_mo
                {
                    so_dt = txtsdt.Text,
                    ten_dkdb = txttentb.Text.Trim(),
                    ten_dktb = txttendb.Text.Trim(),
                    dc_tbld = txtdcld.Text.Trim(),
                    dia_chitb = txtdctb.Text.Trim(),
                    dlu = txtdlu.Text.Trim() == "" ? 0 : Convert.ToInt32(txtdlu.Text.Trim()),
                    en = txten.Text.Trim() == "" ? 0 : Convert.ToInt32(txten.Text.Trim()),
                    frame = txtframe.Text.Trim() == "" ? 0 : Convert.ToInt32(txtframe.Text.Trim()),
                    port = txtport.Text.Trim() == "" ? 0 : Convert.ToInt32(txtport.Text.Trim()),
                    shell = txtshelf.Text.Trim() == "" ? 0 : Convert.ToInt32(txtshelf.Text.Trim()),
                    slot = txtslot.Text.Trim() == "" ? 0 : Convert.ToInt32(txtslot.Text.Trim()),
                    slp = txtslp.Text.Trim() == "" ? 0 : Convert.ToInt32(txtslp.Text.Trim()),
                    card = txtmod.Text.Trim() == "" ? 0 : Convert.ToInt32(txtmod.Text.Trim()),
                    logic = false,
                    ma_huyen = App.ma_huyen,
                    ma_yc = cmbloai.GetKeyValue(cmbloai.SelectedIndex).ToString(),
                    mo = rdomo.IsChecked == true ? false : true,
                    nguoi_yc = App.User_name,
                    tg_yc = App.Current_d
                };
                dstb.cat_mos.Add(cm);
                dstb.SubmitChanges(OnSubmitCompleted, true);
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
                MessageBox.Show("Đã gửi yêu cầu !");
                OKButton.IsEnabled = false;
            }
        }        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Clear_control();
            txtsdt.Focus();
        }
    }
}

