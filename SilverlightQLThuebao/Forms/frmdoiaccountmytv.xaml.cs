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
    public partial class frmdoiaccountmytv : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<mytv> LoadOp;
        LoadOperation<gc_mytv> LoadOpgc;      
        public frmdoiaccountmytv()
        {
            InitializeComponent();
            OKButton.IsEnabled = false;
            EntityQuery<gc_mytv> Querygc = dstb.GetGc_mytvQuery();
            LoadOpgc = dstb.Load(Querygc.OrderBy(p => p.ma_goi), LoadOpGC_Complete, null);                       
        }


        void LoadOpGC_Complete(LoadOperation<gc_mytv> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbgoicuoc.DisplayMember = ("ten_dv").Trim();
                this.cmbgoicuoc.ValueMember = "ma_goi";
                this.cmbgoicuoc.ItemsSource = lo.Entities;

            }
        }
               
        private void txtusr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtusr.Text.Length>0)
            {
                laythongtin();
            }        
        }

        void laythongtin()
        {
            if (this.txtusr.Text.Length > 0)
            {
                {
                    EntityQuery<mytv> Query = dstb.GetMytvsQuery();
                    LoadOp = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusr.Text.Trim()), LoadOp_Complete, null);
                }
            }
        }
        void LoadOp_Complete(LoadOperation<mytv> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                //v_update = true;
                OKButton.IsEnabled = false;
                //this.TextLuu.Text = "In HĐ";
                //this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/print-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";              
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_dkdb == null ? "" : lo.Entities.ElementAt(0).ten_dkdb.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb == null ? "" : lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();                
                this.txtsdt.Text = lo.Entities.ElementAt(0).so_dt == null ? "" : lo.Entities.ElementAt(0).so_dt.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                this.seri.Text = lo.Entities.ElementAt(0).stb_serial == null ? "" : lo.Entities.ElementAt(0).stb_serial.Trim();
                if (lo.Entities.ElementAt(0).ngay_cap.HasValue)
                    this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;
              
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


               
                OKButton.IsEnabled = true;
            }
            else
            {
                Clear_control();
                // enable_control(true);                
                OKButton.IsEnabled = false;
            }
        }
       
        void Clear_control()
        {          
            this.cmbgoicuoc.EditValue = null; ;          
            this.cmbloaicap.Text = "";
            this.txtusrn.Text = "";
            this.cmbhtld.Text = "";
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtcmnd.Text = "";
            this.seri.Text = "";
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
                mytv_log dsl = new mytv_log
                {
                    user_name = txtusrn.Text.Trim(),
                    n_user_name = LoadOp.Entities.ElementAt(0).user_name.Trim(),
                    //ten_dktb = LoadOp.Entities.ElementAt(0).ten_dktb,
                    //ten_nsd = LoadOp.Entities.ElementAt(0).ten_nsd,
                    //dia_chitb = LoadOp.Entities.ElementAt(0).dia_chitb,
                    //dc_tbld = LoadOp.Entities.ElementAt(0).dc_tbld,
                    //sohopdong = LoadOp.Entities.ElementAt(0).sohopdong,
                    //ngay_hd = LoadOp.Entities.ElementAt(0).ngay_hd,
                    //ngay_ld = LoadOp.Entities.ElementAt(0).ngay_ld,
                    //tuyen_tc = LoadOp.Entities.ElementAt(0).tuyen_tc,
                    goi_cuoc = LoadOp.Entities.ElementAt(0).goi_cuoc.Trim(),
                    //toc_do = LoadOp.Entities.ElementAt(0).toc_do,
                    //so_dt = LoadOp.Entities.ElementAt(0).so_dt,                    
                    //ht_ld = LoadOp.Entities.ElementAt(0).ht_ld,
                    ma_huyen = LoadOp.Entities.ElementAt(0).ma_huyen,
                    //socmnd = LoadOp.Entities.ElementAt(0).socmnd,
                    //may_ngung = LoadOp.Entities.ElementAt(0).may_ngung,
                    //noi_cap = LoadOp.Entities.ElementAt(0).noi_cap,
                    //ngay_cap = LoadOp.Entities.ElementAt(0).ngay_cap,
                    ma_kh = LoadOp.Entities.ElementAt(0).ma_kh,
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

                dstb.mytv_logs.Add(dsl);
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
                InvokeOperation<System.Nullable<int>> p = dstb.Excute_p_doiaccmytv(txtusr.Text.Trim(), txtusrn.Text.Trim());
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
      
       

        private void txtusrn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtusrn.Text.Length > 0)
            {
                {
                    EntityQuery<mytv> Query = dstb.GetMytvsQuery();
                    LoadOperation<mytv> LoadOpN = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusrn.Text.Trim()), LoadOpS_Complete, null);
                }
            }        
        }

        void LoadOpS_Complete(LoadOperation<mytv> lo)
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

