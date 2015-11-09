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
    public partial class frmcatint : ChildWindow
    {     
        bool dcthuebao,dclapdat;
        string m_usr,gc,seri_ldn,loai_tbn;
        frmdiachi frmdc;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        LoadOperation<mlydocat> LoadOpcat;
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<GoiCuoc> LoadOpgc;
        LoadOperation<loai_dv> LoadOpdv;
        LoadOperation<TocDo> LoadOptd;
        LoadOperation<KhachHangUuTien> LoadOput;
        LoadOperation<tram_vt> LoadOp;
        LoadOperation<nv_thuethu> LoadOptuyen;
        LoadOperation<internet> LoadOpMy;
        int m_camket;
        public frmcatint(string usr)
        {
            InitializeComponent();
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOp = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p => p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
            EntityQuery<mlydocat> Querycat = dstb.GetLyDoCatTrimQuery();
            LoadOpcat = dstb.Load(Querycat.OrderBy(p => p.m_order), LoadOpCT_Complete, null);
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN, LoadOpN_Complete, null);
            EntityQuery<loai_dv> Queryloaidv = dstb.GetLoai_dvQuery();
            LoadOpdv = dstb.Load(Queryloaidv, LoadOpDV_Complete, null);            
            EntityQuery<KhachHangUuTien> Queryut = dstb.GetKhachHangUuTienTrimQuery();
            LoadOput = dstb.Load(Queryut.OrderBy(p => p.kh_uutien1), LoadOpUT_Complete, null);
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpTT_Complete, null);
            //this.txtsdt.MaxLength = App.len_sdt;
            m_usr = usr;
            dngaycat.EditValue = App.Current_d;           
            mlydo.IsEnabled = false;
            Loaded += new RoutedEventHandler(frmeditmy_Loaded);  
            //frmdc = new frmdiachi();
            //frmdc.Closed += new EventHandler(frmdiachi_Closed); 
           
        }

        void frmeditmy_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_usr != "")
            {
                laythongtin();
            }
        }

        void LoadOpT_Complete(LoadOperation<tram_vt> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtramvt.DisplayMember = ("ten_tram").Trim();
                this.cmbtramvt.ValueMember = "ma_tram";
                this.cmbtramvt.ItemsSource = lo.Entities;
            }
        }
        void LoadOpTK_Complete(LoadOperation<khmai> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbkm.DisplayMember = ("ten_ct").Trim();
                this.cmbkm.ValueMember = "ma_km";
                this.cmbkm.ItemsSource = lo.Entities;

            }
        }

        void LoadOpCT_Complete(LoadOperation<mlydocat> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.mlydo.DisplayMember = ("ten_ld").Trim();
                this.mlydo.ValueMember = "ma_ld";
                this.mlydo.ItemsSource = lo.Entities;
            }
        }

        void LoadOpKH_Complete(LoadOperation<loaikh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnhom.DisplayMember = ("mota").Trim();
                this.cmbnhom.ValueMember = "maloai";
                this.cmbnhom.ItemsSource = lo.Entities;

            }
        }

        void LoadOpDV_Complete(LoadOperation<loai_dv> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbdichvu.DisplayMember = ("ten_dv").Trim();
                this.cmbdichvu.ValueMember = "ma_dv";
                this.cmbdichvu.ItemsSource = lo.Entities;
            }
        }             

        void LoadOpUT_Complete(LoadOperation<KhachHangUuTien> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbkhuutien.DisplayMember = ("ten_uutien").Trim();
                this.cmbkhuutien.ValueMember = "kh_uutien1";
                this.cmbkhuutien.ItemsSource = lo.Entities;
            }
        }

        void LoadOpN_Complete(LoadOperation<nganh_nghe> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnganh.DisplayMember = ("ten_nghe").Trim();
                this.cmbnganh.ValueMember = "ma_nghe";
                this.cmbnganh.ItemsSource = lo.Entities;

            }
        }

        void LoadOpTT_Complete(LoadOperation<nv_thuethu> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtuyen.ItemsSource = lo.Entities;
                this.cmbtuyen.DisplayMember = ("ten").Trim();
                this.cmbtuyen.ValueMember = "ten";

            }
        }

        private void txtusr_LostFocus(object sender, RoutedEventArgs e)
        {

            laythongtin();
         
        }

        void laythongtin()
        {
            if (this.txtusr.Text.Length > 0)
            {
                {
                    EntityQuery<internet> Query = dstb.GetInternetsQuery();
                    LoadOperation<internet> LoadOp = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusr.Text.Trim()), LoadOp_Complete, null);
                }
            }
        }
        void LoadOp_Complete(LoadOperation<internet> lo)
        {            
            if (lo.Entities.Count() > 0)
            {
                //v_update = true;
                cmdLuu.IsEnabled = false;
                OKButton.IsEnabled = true;         
                //this.TextLuu.Text = "In HĐ";
                //this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/print-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
                this.txtmakh.Text = lo.Entities.ElementAt(0).ma_kh.Trim();
                this.txtsohd.Text = lo.Entities.ElementAt(0).sohopdong == null ? "" : lo.Entities.ElementAt(0).sohopdong.Trim();
                if (lo.Entities.ElementAt(0).ngay_hd.HasValue)
                    this.dngayhd.EditValue = lo.Entities.ElementAt(0).ngay_hd;
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_nsd == null ? "" : lo.Entities.ElementAt(0).ten_nsd.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb == null ? "" : lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();
                if (lo.Entities.ElementAt(0).ngay_ld.HasValue)
                this.dngayld.EditValue = lo.Entities.ElementAt(0).ngay_ld;
                this.txtsdt.Text = lo.Entities.ElementAt(0).so_dt == null ? "" : lo.Entities.ElementAt(0).so_dt.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                if (lo.Entities.ElementAt(0).ngay_cap.HasValue)
                this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;
                this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                seri_ldn = lo.Entities.ElementAt(0).modem_seri== null ? "" :lo.Entities.ElementAt(0).modem_seri.Trim();
                loai_tbn = lo.Entities.ElementAt(0).loai_tb == null ? "" : lo.Entities.ElementAt(0).loai_tb.Trim();
                this.chkthtb.IsChecked = lo.Entities.ElementAt(0).thtb == null ? false : lo.Entities.ElementAt(0).thtb; 
               //// this.txtvtk.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                if (lo.Entities.ElementAt(0).ngay_ngung.HasValue)
                this.dngaycat.EditValue = lo.Entities.ElementAt(0).ngay_ngung;
                this.txttt.Text = lo.Entities.ElementAt(0).may_ngung == null ? "" : lo.Entities.ElementAt(0).may_ngung.Trim();                
                string loaidv = lo.Entities.ElementAt(0).ma_dv == null ? "" : lo.Entities.ElementAt(0).ma_dv.Trim();
                m_camket = Convert.ToInt16(lo.Entities.ElementAt(0).camket);
                if (loaidv != "")
                {
                    for (int i = 0; i < LoadOpdv.Entities.Count(); i++)
                    {
                        if (this.cmbdichvu.GetKeyValue(i).ToString().Trim() == loaidv)
                        {
                            this.cmbdichvu.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbdichvu.SelectedIndex = -1;

                gc = lo.Entities.ElementAt(0).goi_cuoc == null ? "" : lo.Entities.ElementAt(0).goi_cuoc.Trim();
                
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
                                if (this.cmbtocdo.GetKeyValue(i).ToString().Trim() == td)
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


                string ut = lo.Entities.ElementAt(0).kh_uutien == null ? "" : lo.Entities.ElementAt(0).kh_uutien.Trim();
                if (ut != "")
                {
                    for (int i = 0; i < LoadOput.Entities.Count(); i++)
                    {
                        if (this.cmbkhuutien.GetKeyValue(i).ToString().Trim() == ut)
                        {
                            this.cmbkhuutien.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbkhuutien.SelectedIndex = -1;
                

                string htld = lo.Entities.ElementAt(0).ht_ld == null ? "" : lo.Entities.ElementAt(0).ht_ld.Trim();
                if (htld != "")
                {
                    this.cmbhtld.SelectedIndex = Convert.ToInt16(htld);

                }
                else
                    this.cmbhtld.SelectedIndex = -1;


                string tram = lo.Entities.ElementAt(0).ma_tram == null ? "" : lo.Entities.ElementAt(0).ma_tram.Trim();
                if (tram != "")
                {
                    for (int i = 0; i < LoadOp.Entities.Count(); i++)
                    {
                        if (this.cmbtramvt.GetKeyValue(i).ToString().Trim() == tram)
                        {
                            this.cmbtramvt.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbtramvt.SelectedIndex = -1;

                string km = lo.Entities.ElementAt(0).ma_km == null ? "" : lo.Entities.ElementAt(0).ma_km.Trim();
                if (km != "")
                {
                    for (int i = 0; i < LoadOpkm.Entities.Count(); i++)
                    {
                        if (cmbkm.GetKeyValue(i).ToString().Trim() == km)
                        {
                            cmbkm.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbkm.SelectedIndex = -1;

                string m_nghe = lo.Entities.ElementAt(0).ma_nghe == null ? "" : lo.Entities.ElementAt(0).ma_nghe.Trim();

                if (m_nghe != "")
                {
                    for (int i = 0; i < LoadOpN.Entities.Count(); i++)
                    {
                        if (this.cmbnganh.GetKeyValue(i).ToString().Trim() == m_nghe)
                        {
                            this.cmbnganh.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    this.cmbnganh.SelectedIndex = -1;

                string nhomkh = lo.Entities.ElementAt(0).ma_nhom == null ? "" : lo.Entities.ElementAt(0).ma_nhom.Trim();

                if (nhomkh != "")
                {
                    EntityQuery<loaikh> Querykh = dstb.GetLoaikhQuery();
                    LoadOpkh = dstb.Load(Querykh.Where(t => t.ma_nghe.Trim() == m_nghe), lo1 =>
                    {
                        if (lo1.Entities.Count() > 0)
                        {
                            this.cmbnhom.DisplayMember = ("mota").Trim();
                            this.cmbnhom.ValueMember = "maloai";
                            this.cmbnhom.ItemsSource = lo1.Entities;
                            for (int i = 0; i < lo1.Entities.Count(); i++)
                            {
                                if (this.cmbnhom.GetKeyValue(i).ToString().Trim() == nhomkh)
                                {
                                    this.cmbnhom.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }, null);
                }
                else
                    this.cmbnhom.SelectedIndex = -1;  

                string m_tuyenthu = lo.Entities.ElementAt(0).tuyen_tc == null ? "" : lo.Entities.ElementAt(0).tuyen_tc.Trim();
                if (m_tuyenthu != "")
                {
                    for (int i = 0; i < LoadOptuyen.Entities.Count(); i++)
                    {
                        if (cmbtuyen.GetKeyValue(i).ToString().Trim() == m_tuyenthu)
                        {
                            cmbtuyen.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbtuyen.SelectedIndex = -1;

                if (this.chkthtb.IsChecked == true)
                    mlydoth.IsEnabled = false;
                else
                    mlydoth.IsEnabled = true;
               // this.textalert.Text = lo.Entities.ElementAt(0).fullname;
                
              //  enable_control(false);

                     
            }
            else
            {               
                Clear_control();
               // enable_control(true);                
                OKButton.IsEnabled = false;
            }
        }
        void enable_control(bool enabled)
        {

            this.txtmakh.IsEnabled = enabled;
            this.txtsohd.IsEnabled = enabled;
            this.dngayhd.IsEnabled = enabled;
            this.cmbgoicuoc.IsEnabled = enabled;
            this.cmbtocdo.IsEnabled = enabled;
            this.cmbdichvu.IsEnabled = enabled;
            this.cmbhtld.IsEnabled = enabled;
            this.txttentb.IsEnabled = enabled;
            this.txtdctb.IsEnabled = enabled;
            this.txtdcld.IsEnabled = enabled;
            this.txttendb.IsEnabled = enabled;
            this.txtsdt.IsEnabled = enabled;
            this.txtcmnd.IsEnabled = enabled;
            this.txtnoicap.IsEnabled = enabled;
            this.dngaycap.IsEnabled = enabled;
            this.txttk.IsEnabled = enabled;
            //this.txtNH.IsEnabled = enabled;
            //this.txtmst.IsEnabled = enabled;
            this.cmbkhuutien.IsEnabled = enabled;
            this.cmbtramvt.IsEnabled = enabled;
            this.cmbhttt.IsEnabled = enabled;
            this.cmbkm.IsEnabled = enabled;
            this.cmbnhom.IsEnabled = enabled;           
        }

        void Clear_control()
        {

            this.txtmakh.Text = "";
            this.txtsohd.Text = "";
            this.dngayhd.EditValue = null;
            this.cmbgoicuoc.Text = "";
            this.cmbtocdo.Text = "";
            this.cmbdichvu.Text = "";
            this.cmbhtld.Text = "";
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtcmnd.Text = "";
            this.txtsdt.Text = "";
            this.txtnoicap.Text = "";
            this.dngaycap.EditValue = null;
            this.txttk.Text = "";
            //this.txtNH.Text = "";
            //this.txtmst.Text = "";
            this.cmbkhuutien.Text = "";
            this.cmbtramvt.EditValue=null;
            this.cmbhttt.EditValue = null;
            this.cmbkm.EditValue = null;
            this.cmbnhom.EditValue = null;
            this.cmbnganh.EditValue = null;
            this.cmbtuyen.SelectedIndex = -1;
            this.dngaycat.EditValue = null;
            this.txttt.Text = "";
            this.cmbloaibd.SelectedIndex = -1;           
            this.mlydo.Text = "";
            this.mlydoth.Text = "";
            this.chkthtb.IsChecked = false;
        }

        private void dctb_click(object sender, RoutedEventArgs e)
        {
            dcthuebao = true;
            dclapdat = false;
            frmdc = new frmdiachi(false);
            frmdc.Closed += new EventHandler(frmdiachi_Closed);
            frmdc.Show();
        }
        private void dcld_click(object sender, RoutedEventArgs e)
        {
            dcthuebao = false;
            dclapdat = true;
            frmdc = new frmdiachi(true);
            frmdc.Closed += new EventHandler(frmdiachi_Closed);
            frmdc.Show();
        }
    
        private void frmdiachi_Closed(object sender, EventArgs e)
        {
            if (frmdc.DialogResult.Value)
            {
                if (dcthuebao)
                    this.txtdctb.Text = frmdc.txtdiachi.ToString();
                if (dclapdat)
                    this.txtdcld.Text = frmdc.txtdiachi.ToString();               
            }
        }
        private void Cat_Click(object sender, RoutedEventArgs e)
        {
            if (cmbloaibd.Text.Trim()=="")
            {
                MessageBox.Show("Chưa chọn loại biến động");
                return;
            }

            if (DateTime.Parse(dngaycat.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngaycat.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString()))
            {
                MessageBox.Show("Ngày cắt, ngưng, thanh lý không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngaycat.Focus();
                return;
            }
            if (m_camket > 0 && (DateTime.Parse(dngaycat.DateTime.ToShortDateString()) < DateTime.Parse(dngaycat.DateTime.AddMonths(m_camket).ToShortDateString())))
            {
                MessageBoxResult Q = MessageBox.Show("Thuê bao này cam kết sử dụng : " + m_camket.ToString() + " tháng, thời gian cắt ngưng chưa đủ thời gian cam kết sử dụng, bạn muốn cắt ngưng không ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (Q == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            if ((mlydo.IsEnabled == true && mlydo.Text.Trim() == "") || (mlydoth.IsEnabled == true && mlydoth.Text.Trim() == "") && (cmbloaibd.Text.Substring(0, 1) == "C" || cmbloaibd.Text.Substring(0, 1) == "N"))
            {
                MessageBox.Show("Chưa nhập lý do cắt, ngưng hoặc lý do không thu hồi thiết bị !");
                return;
            }

            if (txttt.Text.Trim() == "M" && cmbloaibd.Text.Substring(0, 1) != "X")
            {
                MessageBox.Show("Thuê bao này lập hợp đồng chưa bổ sung ngày lắp đặt nên không thể cắt, ngưng được");
                cmdLuu.IsEnabled = false;
                return;
            }


            if (cmbloaibd.Text.Trim() == "" || dngaycat.Text.Trim() == "")
                MessageBox.Show("Chưa chọn loại biến động hoặc ngày biến động !");
            else
            {
                if (cmbloaibd.Text.Substring(0, 1) == "X")
                {
                    MessageBoxResult result = MessageBox.Show("Muốn thanh lý hợp đồng và xóa thuê bao này ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        this.txttt.Text = "X";
                    }
                }
                else
                    this.txttt.Text = cmbloaibd.Text.Substring(0, 1);
                cmdLuu.IsEnabled = true;
                OKButton.IsEnabled = false;

            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();

            //if (chkthtb.IsChecked == true && txtSeri.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập vào seri thiết bị thu hồi!");
            //    return;
            //}

            if (DateTime.Parse(dngaycat.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngaycat.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString()))
            {
                MessageBox.Show("Ngày cắt, ngưng, thanh lý không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngaycat.Focus();
                return;
            }

            if ( this.txtusr.Text == "" || this.cmbgoicuoc.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbnhom.Text.Trim() == "" || cmbnganh.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || cmbtocdo.Text.Trim()=="" || cmbkhuutien.Text.Trim()=="" || cmbloaibd.Text.Trim()=="")
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                EntityQuery<internet> Query = dstb.GetInternetsQuery();
                LoadOpMy = dstb.Load(Query.Where(t => t.user_name.Trim() == this.txtusr.Text.Trim() && t.ma_huyen == App.ma_huyen), LoadOpHD_Complete, null);
            }
        }
        
        void LoadOpHD_Complete(LoadOperation<internet> lo)
        {  
            if (lo.Entities.Count() > 0)
            {
               SaveData();            
            }            
        }       
     

        void SaveData()
        {
            Nullable<DateTime> m_ngayhd, m_ngaycat, m_ngayld, m_ngaycap;

            if (dngayhd.Text.Trim() != "")
                m_ngayhd = dngayhd.DateTime;
            else
                m_ngayhd = null;

            if (dngaycat.Text.Trim() != "")
                m_ngaycat = dngaycat.DateTime;
            else
                m_ngaycat = null;

            if (dngayld.Text.Trim() != "")
                m_ngayld = dngayld.DateTime;
            else
                m_ngayld = null;

            if (dngaycap.Text.Trim() != "")
                m_ngaycap = dngaycap.DateTime;
            else
                m_ngaycap = null;

            try
            {
                // get_hopdong(App.ma_huyen + "/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2));                
                if (txttt.Text.Trim() != "X") // khong phai thanh ly thi update
                {
                    LoadOpMy.Entities.ElementAt(0).ten_dktb = txttentb.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).ten_nsd = txttendb.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).dia_chitb = txtdctb.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).dc_tbld = txtdcld.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).sohopdong = txtsohd.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).ngay_hd = m_ngayhd;
                    LoadOpMy.Entities.ElementAt(0).ngay_ld = m_ngayld;
                    LoadOpMy.Entities.ElementAt(0).tuyen_tc = cmbtuyen.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString();
                    LoadOpMy.Entities.ElementAt(0).so_dt = txtsdt.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).toc_do = cmbtocdo.GetKeyValue(cmbtocdo.SelectedIndex).ToString();
                    LoadOpMy.Entities.ElementAt(0).ma_dv = cmbdichvu.GetKeyValue(cmbdichvu.SelectedIndex).ToString();
                    LoadOpMy.Entities.ElementAt(0).ht_ld = cmbhtld.Text.Trim().Substring(0, 1);
                    LoadOpMy.Entities.ElementAt(0).ma_huyen = App.ma_huyen;
                    LoadOpMy.Entities.ElementAt(0).socmnd = txtcmnd.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).noi_cap = txtnoicap.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).ngay_cap = m_ngaycap;
                    LoadOpMy.Entities.ElementAt(0).ma_kh = txtmakh.Text;
                    LoadOpMy.Entities.ElementAt(0).ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();                    
                    LoadOpMy.Entities.ElementAt(0).may_ngung = txttt.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).ngay_ngung = m_ngaycat;
                    LoadOpMy.Entities.ElementAt(0).thtb = this.chkthtb.IsChecked;
                    LoadOpMy.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(txttentb.Text.Trim());
                    LoadOpMy.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(txtdctb.Text.Trim());
                   // LoadOpMy.Entities.ElementAt(0).ms_thue = FunAndPro.ma_st(txtmst.Text.Trim());
                    LoadOpMy.Entities.ElementAt(0).duong = App.duong;
                    LoadOpMy.Entities.ElementAt(0).xa_phuong = App.phuong;
                    LoadOpMy.Entities.ElementAt(0).khom_ap = App.khom;
                    //LoadOpMy.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                    //LoadOpMy.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                   // LoadOpMy.Entities.ElementAt(0).ngan_hang = txtNH.Text.Trim();
                    LoadOpMy.Entities.ElementAt(0).ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                    LoadOpMy.Entities.ElementAt(0).kh_uutien = cmbkhuutien.SelectedIndex == -1 ? "" : cmbkhuutien.GetKeyValue(cmbkhuutien.SelectedIndex).ToString();
                }
                else
                {
                    if (LoadOpMy.Entities.Count() > 0) // xoa so dt khoi ds_codinh neu chon loai thanh ly hop dong
                    {
                        internet cd = LoadOpMy.Entities.First();
                        dstb.internets.Remove(cd);
                    }
                }
               
                internet_log dsl = new internet_log
                {
                    user_name = this.txtusr.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_nsd = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    sohopdong = this.txtsohd.Text.Trim(),
                    ngay_hd = m_ngayhd,
                    ngay_ld = m_ngayld,
                    tuyen_tc = cmbtuyen.Text.Trim(),
                    goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString(),
                    so_dt = this.txtsdt.Text.Trim(),
                    toc_do = cmbtocdo.GetKeyValue(cmbtocdo.SelectedIndex).ToString(),
                    ma_dv = cmbdichvu.GetKeyValue(cmbdichvu.SelectedIndex).ToString(),
                    kh_uutien = cmbkhuutien.SelectedIndex == -1 ? "" : cmbkhuutien.GetKeyValue(cmbkhuutien.SelectedIndex).ToString(),
                    ht_ld = this.cmbhtld.Text.Trim() == "" ? "1" : this.cmbhtld.Text.Trim().Substring(0, 1),
                    ma_huyen = App.ma_huyen,
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = m_ngaycap,
                    ma_kh = this.txtmakh.Text,                    
                    ngay_ngung = m_ngaycat,
                    may_ngung = this.txttt.Text.Trim(),
                    //ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    //ngan_hang = this.txtNH.Text.Trim(),
                    ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    //ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    //ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    thtb = this.chkthtb.IsChecked,
                    ldthtb = this.mlydoth.Text.Trim(),
                    lydocat = mlydo.Text.Trim() == "" ? "" : mlydo.GetKeyValue(mlydo.SelectedIndex).ToString(),                   
                    user_login = App.User_name,
                    thoi_gian = App.Current_d
                };

                dstb.internet_logs.Add(dsl);

                if (txttt.Text.Trim() == "C") // neu la cat may thi ghi vao table thuhoi
                {
                    thuhoi_thietbi th = new thuhoi_thietbi {                    
                        user_name = this.txtusr.Text.Trim(),
                        dia_chitb=txtdctb.Text.Trim(),
                        dc_tbld=txtdcld.Text.Trim(),
                        goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString(),
                        loai_dv="I",
                        ma_huyen=App.ma_huyen,
                        may_ngung="C",
                        ngay_ngung = m_ngaycat,
                        ten_dktb=txttentb.Text.Trim(),
                        toc_do = cmbtocdo.GetKeyValue(cmbtocdo.SelectedIndex).ToString(),
                        thtb=chkthtb.IsChecked,
                        ten_nsd = txttentb.Text.Trim(),
                        seri_ld=seri_ldn,
                        seri_th=txtSeri.Text.Trim(),
                        loai_tb=loai_tbn
                    };
                    dstb.thuhoi_thietbis.Add(th);
                }
                
                dstb.SubmitChanges(OnSubmitCompleted,true);
               // enable_control(false);
                             
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}",e));
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
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");               
                this.OKButton.IsEnabled = false;
                this.btnNew.IsEnabled = true;
                this.txtusr.Focus();
            }
        }

        void Send_SMS()
        {
            if (LoadOpMy.Entities.ElementAt(0).ma_nvcs != "" && LoadOpMy.Entities.ElementAt(0).ma_nvcs != null)
            {
                string m_db = ";" + LoadOpMy.Entities.ElementAt(0).ma_nvcs.ToString().Trim() + ";";
                EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOpS = dstb.Load(Query.Where(p => p.diaban.Trim().Contains(m_db) && p.ma_huyen == App.ma_huyen && p.kt == false), LoadOpSMSKD_Complete, null);
            }

            if (LoadOpMy.Entities.ElementAt(0).ma_nvkt != "" && LoadOpMy.Entities.ElementAt(0).ma_nvkt != null)
            {
                string m_db = ";" + LoadOpMy.Entities.ElementAt(0).ma_nvkt.ToString().Trim() + ";";
                EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOps = dstb.Load(Query.Where(p => p.diaban.Trim().Contains(m_db) && p.ma_huyen == App.ma_huyen && p.kt == true), LoadOpSMSKT_Complete, null);
            }
        }

        void LoadOpSMSKD_Complete(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                if (lo.Entities.ElementAt(0).phone.Trim() != "")
                {
                    string m_loai = "";
                    if (txttt.Text.Trim() == "C")
                        m_loai = "CAT:";
                    if (txttt.Text.Trim() == "N")
                        m_loai = "NGUNG:";
                    if (txttt.Text.Trim() == "S")
                        m_loai = "1CHIEU:";
                    if (txttt.Text.Trim() == "H")
                        m_loai = "HDLai:";
                    string mess = m_loai + txtusr.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
                    InvokeOperation<System.Nullable<int>> p = dstb.SendSMS(mess, lo.Entities.ElementAt(0).phone.Trim(), 0);
                    //p.Completed += new EventHandler(Completed);
                }
            }
        }

        void LoadOpSMSKT_Complete(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                if (lo.Entities.ElementAt(0).phone.Trim() != "")
                {
                    string m_loai = "";
                    if (txttt.Text.Trim() == "C")
                        m_loai = "CAT:";
                    if (txttt.Text.Trim() == "N")
                        m_loai = "NGUNG:";
                    if (txttt.Text.Trim() == "S")
                        m_loai = "1CHIEU:";
                    if (txttt.Text.Trim() == "H")
                        m_loai = "HDLai:";
                    string mess = m_loai + txtusr.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
                    InvokeOperation<System.Nullable<int>> p = dstb.SendSMS(mess, lo.Entities.ElementAt(0).phone.Trim(), 0);
                    //p.Completed += new EventHandler(Completed);
                }
            }
        }


        public string Getplkhachhang(string m_maloai)
        {
            string temp = "";
            for (int i = 0; i < LoadOpkh.Entities.Count(); i++)
            {
                string ma = LoadOpkh.Entities.ElementAt(i).maloai.Trim();
                if (ma == m_maloai)
                {
                    temp = LoadOpkh.Entities.ElementAt(i).pl;
                    break;
                }
            }
            return temp;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Clear_control();
            txtusr.Text = "";
            txtusr.Focus();
            enable_control(true);
            this.TextLuu.Text = "Lưu";
            this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
            OKButton.IsEnabled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            if (m_usr != "")
            {
                frmdsinternet frm = new frmdsinternet();
                frm.Width = this.ActualWidth;
                frm.Height = this.ActualHeight;
                frm.Show();
                frm.txttim.Text = m_usr;
            }
        }

        private void cmbnganh_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbnganh.SelectedIndex == -1) return;
            string m_nghe = this.cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString().Trim();
            if (m_nghe != "")
            {
                EntityQuery<loaikh> Query = dstb.GetLoaikhQuery();
                LoadOpkh = dstb.Load(Query.Where(t => t.ma_nghe.Trim() == m_nghe), lo =>
                {
                    if (lo.Entities.Count() > 0)
                    {
                        this.cmbnhom.DisplayMember = ("mota").Trim();
                        this.cmbnhom.ValueMember = "maloai";
                        this.cmbnhom.ItemsSource = lo.Entities;
                    }
                }, null);
            }
        }

        private void cmbgoicuoc_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbgoicuoc.SelectedIndex == -1) return;
            string m_goi = this.cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString().Trim();
            if (m_goi != "")
            {
                EntityQuery<TocDo> Query = dstb.GetTocDoTrimQuery();
                LoadOptd = dstb.Load(Query.Where(t => t.ma_goi.Trim() == m_goi), lo =>
                {
                    if (lo.Entities.Count() > 0)
                    {
                        this.cmbtocdo.DisplayMember = ("toc_do").Trim();
                        this.cmbtocdo.ValueMember = "ma_td";
                        this.cmbtocdo.ItemsSource = lo.Entities;
                    }
                }, null);
            }
        }

        private void cmbdichvu_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbdichvu.SelectedIndex == -1) return;
            string m_dv = this.cmbdichvu.GetKeyValue(cmbdichvu.SelectedIndex).ToString().Trim();
            if (m_dv != "")
            {
                EntityQuery<GoiCuoc> Querygc = dstb.GetGoiCuocTrimQuery();
                LoadOpgc = dstb.Load(Querygc.Where(p => p.ma_dv == m_dv).OrderBy(p => p.ma_goi), LoadCGComplete, null);
            }
        }

        void LoadCGComplete(LoadOperation<GoiCuoc> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbgoicuoc.DisplayMember = ("ten_goi").Trim();
                this.cmbgoicuoc.ValueMember = "ma_goi";
                this.cmbgoicuoc.ItemsSource = lo.Entities;
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
            }
        }

        private void dngaycat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DateTime.Parse(dngaycat.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngaycat.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString()))
            {
                MessageBox.Show("Ngày cắt, ngưng, thanh lý, không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngaycat.Focus();
            }
        }

        private void cmbloaibd_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbloaibd.SelectedIndex == -1) return;
            dngaycat.EditValue = App.Current_d;
            string chuoi = "C.N.S.X";
            if (chuoi.Contains(cmbloaibd.Text.Substring(0, 1)))
            {
                mlydo.IsEnabled = true;
            }
            else
                mlydo.IsEnabled = false;
        }

        private void chkthtb_Checked(object sender, RoutedEventArgs e)
        {
            mlydoth.IsEnabled = false;
            txtSeri.IsEnabled = true;
        }

        private void chkthtb_Unchecked(object sender, RoutedEventArgs e)
        {
            mlydoth.IsEnabled = true;
            txtSeri.IsEnabled = false;
        }    
    }
}

