using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmdoiaccount : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<internet> LoadOp;
        LoadOperation<GoiCuoc> LoadOpgc;
        LoadOperation<TocDo> LoadOptd;        
        public frmdoiaccount()
        {
            InitializeComponent();
            OKButton.IsEnabled = false;
            EntityQuery<GoiCuoc> Querygc = dstb.GetGoiCuocTrimQuery();
            LoadOpgc = dstb.Load(Querygc.OrderBy(p=>p.ma_goi), LoadOpGC_Complete, null);                             
        }
               

        void LoadOpGC_Complete(LoadOperation<GoiCuoc> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbgoicuoc.DisplayMember = ("ten_goi").Trim();
                this.cmbgoicuoc.ValueMember = "ma_goi";
                this.cmbgoicuoc.ItemsSource = lo.Entities;
            }
        }             
               
        private void txtusr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtusr.Text.Length>0)
            {
                {
                    EntityQuery<internet> Query = dstb.GetInternetsQuery();
                    LoadOp = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusr.Text.Trim()), LoadOp_Complete, null);
                }
            }        
        }

        void LoadOp_Complete(LoadOperation<internet> lo)
        {            
            if (lo.Entities.Count() > 0)
            {                 
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_nsd == null ? "" : lo.Entities.ElementAt(0).ten_nsd.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();
                this.txtsdt.Text = lo.Entities.ElementAt(0).so_dt == null ? "" : lo.Entities.ElementAt(0).so_dt.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;                
               // this.txtseri.Text = lo.Entities.ElementAt(0).stb_serial == null ? "" : lo.Entities.ElementAt(0).stb_serial.Trim();
                string gc = lo.Entities.ElementAt(0).goi_cuoc == null ? "" : lo.Entities.ElementAt(0).goi_cuoc.Trim();
                if (gc != "")
                {
                    for (int i = 0; i < LoadOpgc.Entities.Count(); i++)
                    {
                        if (this.cmbgoicuoc.GetKeyValue(i).ToString().Trim() == gc)
                        {
                            this.cmbgoicuoc.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbgoicuoc.SelectedIndex = -1;               


                string td = lo.Entities.ElementAt(0).toc_do == null ? "" : lo.Entities.ElementAt(0).toc_do.Trim();

                if (td != "")
                {
                    EntityQuery<TocDo> Query = dstb.GetTocDoTrimQuery();
                    LoadOptd = dstb.Load(Query.Where(t => t.ma_goi.Trim() == gc), lo2 =>
                    {
                        if (lo2.Entities.Count() > 0)
                        {
                            this.cmbtocdo.DisplayMember = ("toc_do").Trim();
                            this.cmbtocdo.ValueMember = "ma_td";
                            this.cmbtocdo.ItemsSource = lo2.Entities;
                            for (int i = 0; i < lo2.Entities.Count(); i++)
                            {
                                if (this.cmbtocdo.GetKeyValue(i).ToString().Trim() ==td)
                                {
                                    this.cmbtocdo.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }, null);
                }
                else
                    this.cmbtocdo.SelectedIndex = -1;


                string loaicap = lo.Entities.ElementAt(0).loai_cap == null ? "" : lo.Entities.ElementAt(0).loai_cap.Trim();
                if (loaicap != "")
                {                    
                   this.cmbloaicap.SelectedIndex = Convert.ToInt16(loaicap);                 
                }
                else
                    this.cmbloaicap.SelectedIndex = -1;

                string htld = lo.Entities.ElementAt(0).ht_ld == null ? "" : lo.Entities.ElementAt(0).ht_ld.Trim();
                if (htld != "")
                {
                    this.cmbhtld.SelectedIndex = Convert.ToInt16(htld);
                }
                else
                    this.cmbhtld.SelectedIndex = -1;

                


                // this.textalert.Text = lo.Entities.ElementAt(0).fullname;
           
                OKButton.IsEnabled = true;               
            }
            else
            {               
                Clear_control();             
            }
        }
       
        void Clear_control()
        {          
            this.cmbgoicuoc.EditValue = null; ;
            this.cmbtocdo.EditValue = null; ;
            this.cmbloaicap.Text = "";
            this.txtusrn.Text = "";
            this.cmbhtld.Text = "";
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtcmnd.Text = "";
            this.txtsdt.Text = "";
            this.txtnoicap.Text = "";
            this.dngaycap.EditValue = null;            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            if (this.txtusr.Text == "" || this.txtusrn.Text == "" )
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                // lay hopdong                                    
               // LoadOp.Entities.ElementAt(0).user_name = txtusrn.Text.Trim();
                internet_log dsl = new internet_log
                {
                    user_name = txtusrn.Text.Trim(),
                    n_user_name = LoadOp.Entities.ElementAt(0).user_name,
                    //ten_dktb = LoadOp.Entities.ElementAt(0).ten_dktb,
                    //ten_nsd = LoadOp.Entities.ElementAt(0).ten_nsd,
                    //dia_chitb = LoadOp.Entities.ElementAt(0).dia_chitb,
                    //dc_tbld = LoadOp.Entities.ElementAt(0).dc_tbld,
                    //sohopdong = LoadOp.Entities.ElementAt(0).sohopdong,
                    //ngay_hd = LoadOp.Entities.ElementAt(0).ngay_hd,
                    //ngay_ld = LoadOp.Entities.ElementAt(0).ngay_ld,
                    //tuyen_tc = LoadOp.Entities.ElementAt(0).tuyen_tc,
                    //goi_cuoc = LoadOp.Entities.ElementAt(0).goi_cuoc,
                    //toc_do = LoadOp.Entities.ElementAt(0).toc_do,
                    //so_dt = LoadOp.Entities.ElementAt(0).so_dt,                    
                    //ht_ld = LoadOp.Entities.ElementAt(0).ht_ld,
                    //ma_huyen = LoadOp.Entities.ElementAt(0).ma_huyen,
                    //socmnd = LoadOp.Entities.ElementAt(0).socmnd,
                    //may_ngung = LoadOp.Entities.ElementAt(0).may_ngung,
                    //noi_cap = LoadOp.Entities.ElementAt(0).noi_cap,
                    //ngay_cap = LoadOp.Entities.ElementAt(0).ngay_cap,
                    //ma_kh = LoadOp.Entities.ElementAt(0).ma_kh,
                    //ngay_kn = LoadOp.Entities.ElementAt(0).ngay_kn,
                    //note_ngay_kn = LoadOp.Entities.ElementAt(0).note_ngay_kn,
                    //ms_thue = LoadOp.Entities.ElementAt(0).ms_thue,
                    //ngan_hang = LoadOp.Entities.ElementAt(0).ngan_hang,
                    //ma_km = LoadOp.Entities.ElementAt(0).ma_km,
                    //ma_nhom = LoadOp.Entities.ElementAt(0).ma_nhom,
                    //ma_nghe = LoadOp.Entities.ElementAt(0).ma_nghe,
                    //ma_nvcs = LoadOp.Entities.ElementAt(0).ma_nvcs,
                    user_login = App.User_name,
                    thoi_gian = App.Current_d
                };
                dstb.internet_logs.Add(dsl);
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
                QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
                InvokeOperation<System.Nullable<int>> p = dstb.Excute_p_doiaccint(txtusr.Text.Trim(), txtusrn.Text.Trim());
                p.Completed += new EventHandler(Completed);
            }
        }


        void Completed(object sende, EventArgs e)
        {
            MessageBox.Show("Đã đổi account xong !");
            this.OKButton.IsEnabled = false;
            this.btnNew.IsEnabled = true;
            this.txtusr.Focus();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Clear_control();
            txtusr.Text = "";
            txtusr.Focus();                                 
            OKButton.IsEnabled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           this.DialogResult = false;         
            
        }     
      
      
        private void cmbgoicuoc_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbgoicuoc.SelectedIndex==-1) return;
            string m_goi = this.cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString().Trim();
            if (m_goi != "")
            {
                EntityQuery<TocDo> Query = dstb.GetTocDoTrimQuery();
                LoadOptd = dstb.Load(Query.Where(t => t.ma_goi.Trim() == m_goi), lo =>
                {
                    if (lo.Entities.Count() > 0)
                    {
                        this.cmbtocdo.DisplayMember = ("toc_do1").Trim();
                        this.cmbtocdo.ValueMember = "ma_td";
                        this.cmbtocdo.ItemsSource = lo.Entities;
                    }
                }, null);
            }
        }

        private void txtusrn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtusrn.Text.Length > 0)
            {
                {
                    EntityQuery<internet> Query = dstb.GetInternetsQuery();
                    LoadOperation<internet> LoadOpN = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusrn.Text.Trim()), LoadOpS_Complete, null);
                }
            }        
        }

        void LoadOpS_Complete(LoadOperation<internet> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("User name : " + txtusrn.Text.Trim() + " đã tồn tại !");
                OKButton.IsEnabled = false;
                return;
            }
            else
                OKButton.IsEnabled = true;
        }
    }
}

