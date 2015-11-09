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
    public partial class frmhopdonggp : ChildWindow
    {

        bool dcthuebao, dclapdat, v_update;
        string m_sohopdong, m_makh, idgoi;
        string S_null;
        DateTime? D_null = null;
        frmdiachi frmdc;
        frmhdcoquan frmhdcq;
        int m_lan;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<tram_vt> LoadOp;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<Mdiaban> LoadOpCB;
        LoadOperation<Mdiaban> LoadOpCBKT;
        LoadOperation<Gphone> LoadOptb;
        LoadOperation<Goi_th> LoadGoi;
        public frmhopdonggp()
        {
            InitializeComponent();
            App.id_goicuoc = "";
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOp = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p=>p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.Where(p=>p.hieu_luc==true).OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN.OrderBy(p => p.ten_nghe), LoadOpN_Complete, null);
            EntityQuery<Mdiaban> QueryNV = dstb.GetMadiabanTrimQuery();
            LoadOpCB = dstb.Load(QueryNV.Where(p => p.ma_huyen == App.ma_huyen && p.kt == false).OrderBy(p => p.ten_tuyen), LoadOpCB_Complete, null);
            EntityQuery<Mdiaban> QueryNVKT = dstb.GetMadiabanTrimQuery();
            LoadOpCBKT = dstb.Load(QueryNVKT.Where(p => p.ma_huyen == App.ma_huyen && p.kt == true).OrderBy(p => p.ten_tuyen), LoadOpCBKT_Complete, null);
            EntityQuery<Goi_th> QueryG = dstb.GetGoi_thQuery();
            LoadGoi = dstb.Load(QueryG.OrderBy(p => p.ten_goi), LoadOpG_Complete, null);
            this.txtsdt.MaxLength = App.len_sdt;
           
            frmhdcq = new frmhdcoquan();
            frmhdcq.Closed += new EventHandler(frmhdcoquan_Closed);
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

        void LoadOpN_Complete(LoadOperation<nganh_nghe> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnganh.DisplayMember = ("ten_nghe").Trim();
                this.cmbnganh.ValueMember = "ma_nghe";
                this.cmbnganh.ItemsSource = lo.Entities;
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

        void LoadOpCB_Complete(LoadOperation<Mdiaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbcbcs.DisplayMember = ("ten_tuyen").Trim();
                this.cmbcbcs.ValueMember = "ma_tuyen";
                this.cmbcbcs.ItemsSource = lo.Entities;
            }
        }

        void LoadOpCBKT_Complete(LoadOperation<Mdiaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbcbkt.DisplayMember = ("ten_tuyen").Trim();
                this.cmbcbkt.ValueMember = "ma_tuyen";
                this.cmbcbkt.ItemsSource = lo.Entities;
            }
        }

        void LoadOpG_Complete(LoadOperation<Goi_th> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbgoith.DisplayMember = ("ten_goi").Trim();
                this.cmbgoith.ValueMember = "ma_goi";
                this.cmbgoith.ItemsSource = lo.Entities;
                this.cmbgoith.SelectedIndex = -1;
            }
        }

        private void txtsdt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtsdt.Text.Length == App.len_sdt)
            {
                {
                    EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                    LoadOptb = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text), LoadOp_Complete, null);

                }
            }
            else
            {
                if (this.txtsdt.Text.Length > 0)
                {
                    MessageBox.Show("Chưa nhập đúng định dạng");
                    txtsdt.Focus();
                }
            }
        }
        void LoadOp_Complete(LoadOperation<Gphone> lo)
        {            
            if (lo.Entities.Count() > 0)
            {
                v_update = true;
                m_lan = 0;
                if (lo.Entities.ElementAt(0).may_ngung == "M" && lo.Entities.ElementAt(0).ma_huyen == App.ma_huyen)
                {
                    enable_control(false);
                    this.TextLuu.Text = "Lưu";
                    this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
                }
                else
                {
                    enable_control(true);
                    this.TextLuu.Text = "In HĐ";
                    this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/print-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
                }
                OKButton.IsEnabled = true;                
                this.txtmakh.Text = lo.Entities.ElementAt(0).ma_kh.Trim();
                this.txtsohd.Text = lo.Entities.ElementAt(0).sohopdong == null ? "" : lo.Entities.ElementAt(0).sohopdong.Trim();
                this.dngayhd.EditValue = lo.Entities.ElementAt(0).ngay_hd;
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_dkdb == null ? "" : lo.Entities.ElementAt(0).ten_dkdb.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb==null ? "": lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();
                this.txtsosim.Text = lo.Entities.ElementAt(0).SoSim == null ? "" : lo.Entities.ElementAt(0).SoSim.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;
                this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                this.txtNH.Text = lo.Entities.ElementAt(0).ngan_hang== null ? "" :lo.Entities.ElementAt(0).ngan_hang.Trim();
                this.txtmst.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                this.dngaykn.EditValue = lo.Entities.ElementAt(0).ngay_kn;
                this.txtghichu.Text = lo.Entities.ElementAt(0).note_ngay_kn == null ? "" : lo.Entities.ElementAt(0).note_ngay_kn.Trim();
                this.txtemail.Text = lo.Entities.ElementAt(0).e_mail == null ? "" : lo.Entities.ElementAt(0).e_mail.Trim();
                this.txtdtlh.Text = lo.Entities.ElementAt(0).dt_lh == null ? "" : lo.Entities.ElementAt(0).dt_lh.ToString();
                this.spcamket.Text = lo.Entities.ElementAt(0).camket == null ? "0" : lo.Entities.ElementAt(0).camket.ToString();
                idgoi = lo.Entities.ElementAt(0).id_goicuoc == null ? "" : lo.Entities.ElementAt(0).id_goicuoc.Trim();
                App.id_goicuoc = idgoi == "" ? S_null : idgoi;
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
                    EntityQuery<loaikh> Query = dstb.GetLoaikhQuery();
                    LoadOpkh = dstb.Load(Query.Where(t => t.ma_nghe.Trim() == m_nghe), lo1 =>
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

                string m_nv = lo.Entities.ElementAt(0).ma_nvcs == null ? "" : lo.Entities.ElementAt(0).ma_nvcs.Trim();

                if (m_nv != "")
                {
                    for (int i = 0; i < LoadOpCB.Entities.Count(); i++)
                    {
                        if (this.cmbcbcs.GetKeyValue(i).ToString().Trim() == m_nv)
                        {
                            this.cmbcbcs.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    this.cmbcbcs.SelectedIndex = -1;

                string m_nvkt = lo.Entities.ElementAt(0).ma_nvkt == null ? "" : lo.Entities.ElementAt(0).ma_nvkt.Trim();

                if (m_nvkt != "")
                {
                    for (int i = 0; i < LoadOpCBKT.Entities.Count(); i++)
                    {
                        if (this.cmbcbkt.GetKeyValue(i).ToString().Trim() == m_nvkt)
                        {
                            this.cmbcbkt.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    this.cmbcbkt.SelectedIndex = -1;


                string m_goi = lo.Entities.ElementAt(0).goi_th == null ? "" : lo.Entities.ElementAt(0).goi_th.Trim();

                if (m_goi != "")
                {
                    for (int i = 0; i < LoadGoi.Entities.Count(); i++)
                    {
                        if (this.cmbgoith.GetKeyValue(i).ToString().Trim() == m_goi)
                        {
                            this.cmbgoith.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    this.cmbgoith.SelectedIndex = -1;
                // this.textalert.Text = lo.Entities.ElementAt(0).fullname;
                cmbloaitb.SelectedIndex = lo.Entities.ElementAt(0).loai_tb == true ? 1 : 0;
                     
            }
            else
            {               
                Clear_control();
                enable_control(false);
                this.TextLuu.Text = "Lưu";
                this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
                OKButton.IsEnabled = true;
                v_update = false;
            }
        }
        void enable_control(bool enabled)
        {

           // this.txtmakh.IsReadOnly = enabled;
           // this.txtsohd.IsReadOnly = enabled;
           // this.dngayhd.IsEnabled = enabled;
            this.txttentb.IsReadOnly = enabled;
            this.txtdctb.IsReadOnly = enabled;
            this.txtdcld.IsReadOnly = enabled;
            this.txttendb.IsReadOnly = enabled;
            this.txtsosim.IsReadOnly = enabled;
            this.txtcmnd.IsReadOnly = enabled;
            this.txtnoicap.IsReadOnly = enabled;
            this.dngaycap.IsReadOnly = enabled;
            this.txttk.IsReadOnly = enabled;
            this.txtNH.IsReadOnly = enabled;
            this.txtmst.IsReadOnly = enabled;
            this.cmbloaitb.IsReadOnly = enabled;
            this.cmbtramvt.IsReadOnly = enabled;
            this.cmbcbcs.IsReadOnly = enabled;
            this.cmbcbkt.IsReadOnly = enabled;
            this.cmbnganh.IsReadOnly = enabled;
            this.cmbhttt.IsReadOnly = enabled;
            if (v_update)
            {
                this.cmbkm.IsReadOnly = true;
                this.txtsdt.IsReadOnly = true;
            }
            else
            {
                this.cmbkm.IsReadOnly = enabled;
                this.txtsdt.IsReadOnly = enabled;
            }
            this.cmbnhom.IsReadOnly = enabled;
            this.dngaykn.IsReadOnly = enabled;
            this.txtghichu.IsReadOnly = enabled;
            this.txtemail.IsReadOnly = enabled;
            this.spcamket.IsReadOnly = enabled;
            this.txtdtlh.IsReadOnly = enabled;
            this.cmbgoith.IsReadOnly = enabled;
        }

        void Clear_control()
        {
            this.txtsdt.IsReadOnly = false;
            this.txtmakh.Text = "";
            this.txtsohd.Text = "";
            this.dngayhd.EditValue = App.Current_d;
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtcmnd.Text = "";
            this.txtsosim.Text = "";
            this.txtnoicap.Text = "";
            this.dngaycap.EditValue = null;
            this.txttk.Text = "";
            this.txtNH.Text = "";
            this.txtmst.Text = "";
            this.cmbloaitb.SelectedIndex = -1;
            this.cmbtramvt.SelectedIndex = -1;
            this.cmbgoith.SelectedIndex = -1;
            this.cmbhttt.SelectedIndex = 0;
            this.cmbkm.SelectedIndex = 0;
            this.cmbnganh.SelectedIndex = -1;
            this.cmbnhom.SelectedIndex = -1;
            this.cmbcbcs.SelectedIndex = -1;
            this.cmbcbkt.SelectedIndex = -1;
            this.spcamket.Text = "0";
            this.dngaykn.EditValue = null;
            this.txtghichu.Text = "";
            this.txtemail.Text = "";
            this.txtdtlh.Text = "";
            this.chkhdcq.IsChecked = false;
            App.nguoidaidien = "";
            App.chucvu = "";
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

        private void frmhdcoquan_Closed(object sender, EventArgs e)
        {
            if (frmhdcq.DialogResult.Value)
            {
                if (App.nguoidaidien == "")
                {
                    chkhdcq.IsChecked = false;
                    App.chucvu = "";
                }
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbcbcs.SelectedIndex == -1 || this.cmbcbkt.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn địa bàn kỹ thuật và địa bàn kinh doanh !");
                return;
            }

            if (this.cmbgoith.SelectedIndex > -1 && (App.id_goicuoc == null || App.id_goicuoc == ""))
            {
                MessageBox.Show("Chọn gói cước tích hợp chưa đúng !");
                this.cmbgoith.SelectedIndex = -1;
                return;
            }

            //if (this.cmbcbcs.SelectedIndex == -1 || this.cmbcbkt.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Chưa chọn địa bàn kinh doanh và kỹ thuật !");
            //    return;
            //}

            if (this.txtdtlh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại liên hệ !");
                this.txtdtlh.Focus();
                return;
            }

            if (this.txtemail.Text.Trim() != "")
            {
                if (!this.txtemail.Text.Contains('@'))
                {
                    MessageBox.Show("Nhập e mail sai định dạng !");
                    this.txtemail.Focus();
                    return;
                }

            }
 


            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            if (this.txtsdt.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbnhom.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || dngaycap.Text.Trim() == "" || cmbloaitb.SelectedIndex==-1)
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                if (v_update)
                {
                    if(LoadOptb.Entities.ElementAt(0).may_ngung=="M")
                        Update_data();
                    else
                        if (nhiemthu.IsChecked == true)
                            innhiemthu();
                        else
                            inhopdong();
                }
                else
                {
                    // lay hopdong                
                    string m_hd = App.ma_huyen + "-G/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2);
                    EntityQuery<maxmakhachhang> Query = dstb.GethopdonggpQuery(m_hd);
                    LoadOperation<maxmakhachhang> LoadOp = dstb.Load(Query, LoadOpHD_Complete, null);
                }
            }
        }


        
        void LoadOpHD_Complete(LoadOperation<maxmakhachhang> lo)
        {           
            string temps;
            if (lo.Entities.Count() > 0)
            {

                temps = lo.Entities.ElementAt(0).maxmakh == null ? "0" : lo.Entities.ElementAt(0).maxmakh.Trim();
                temps = (Convert.ToInt32(temps) + 1).ToString();              
            }
            else
            {
                temps = "1";               
            }
            m_sohopdong = temps.PadLeft(6, '0') + "/" + App.ma_huyen + "-G/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2);
            this.txtsohd.Text = m_sohopdong;
            // lay ma khach hang
            EntityQuery<maxmakhachhang> Query = dstb.GetmaxmakhachhanggpQuery(App.batdau_mkh);
            LoadOperation<maxmakhachhang> LoadOp = dstb.Load(Query, LoadOpMKH_Complete, null);
        }

        void LoadOpMKH_Complete(LoadOperation<maxmakhachhang> lo)
        {           
            string temps;
            if (lo.Entities.Count() > 0)
            {
                temps = lo.Entities.ElementAt(0).maxmakh == null ? "0" : lo.Entities.ElementAt(0).maxmakh.Trim();
                temps=(Convert.ToInt32(temps)+ 1).ToString();
            }
            else
                temps = "1";
            
            m_makh = App.batdau_mkh +"G"+ temps.PadLeft(5, '0');
            this.txtmakh.Text = m_makh;
            // bat dau luu du lieu nhap vao tables
            SaveData();           
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            v_update = false;
            enable_control(true);
            Clear_control();
            txtsdt.Text = "";
            txtsdt.Focus();           
            this.TextLuu.Text = "Lưu";
            this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
            OKButton.IsEnabled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           this.DialogResult = false;         
            
        }

        void SaveData()
        {

            try
            {
                // get_hopdong(App.ma_huyen + "/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2));
                Gphone ds = new Gphone
                {
                    so_dt = this.txtsdt.Text,
                    SoSim= this.txtsosim.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    tuyen_tc = "",
                    ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString(),
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),
                    village = "",
                    tien_tb = 0,
                    tienno = 0,
                    tb_dv = 0,
                    ngay_ld = null,                    
                    ngay_mo = null,
                    may_ngung = "M",
                    ngay_ngung = null,
                    keo_may = false,
                    mo_may = false,                   
                    ma_huyen = App.ma_huyen,
                    stt = 0,
                    sohopdong = this.txtsohd.Text.Trim(),
                    ngay_hd = this.dngayhd.DateTime,
                    thangbd = "",
                    inct = false,
                    ma_kh = this.txtmakh.Text,
                    ngay_kn = dngaykn.Text.Trim() == "" ? D_null : this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text.Trim(),                    
                    tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim()),
                    dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim()),
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    khg_vat = false,
                    cuoc = 0,
                    ngay = null,
                    duong = App.duong,
                    xa_phuong = App.phuong,
                    khom_ap = App.khom,
                    tbdc = false,
                    kh_db = "",
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    ngan_hang = this.txtNH.Text.Trim(),
                    e_mail = this.txtemail.Text.Trim(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0,1))),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString(),
                    dt_lh = this.txtdtlh.Text.Trim(),
                    goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim(),
                    id_goicuoc = App.id_goicuoc
                };
                dstb.Gphones.Add(ds);


                Gphone_log dsl = new Gphone_log
                {
                    so_dt = this.txtsdt.Text.Trim(),
                    SoSim = this.txtsosim.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    tuyen_tc = null,                    
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),
                    may_ngung = "M",
                    ma_huyen = App.ma_huyen,
                    sohopdong = this.txtsohd.Text,
                    ngay_hd = this.dngayhd.DateTime,
                    ma_kh = this.txtmakh.Text,
                    ngay_kn = dngaykn.Text.Trim() == "" ? D_null : this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text.Trim(),
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    e_mail = this.txtemail.Text.Trim(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    thoi_gian = App.Current_d,
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0, 1))),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString(),
                    users = App.User_name,
                    dt_lh = this.txtdtlh.Text.Trim(),
                    goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim(),
                    id_goicuoc = App.id_goicuoc
                };

                dstb.Gphone_logs.Add(dsl);
                dstb.SubmitChanges(OnSubmitCompleted,true);
                
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}",e));
            }
        }

        void Update_data()
        {
            if (App.id_goicuoc == "" && cmbgoith.SelectedIndex != -1)
            {
                MessageBox.Show("Chưa chọn thuê bao tích hợp !");
                return;
            }
            try
            {
                // get_hopdong(App.ma_huyen + "/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2));
                  //  LoadOptb.Entities.ElementAt(0).so_dt = this.txtsdt.Text;
                    LoadOptb.Entities.ElementAt(0).SoSim = this.txtsosim.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ten_dktb = this.txttentb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ten_dkdb = this.txttendb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dia_chitb = this.txtdctb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dc_tbld = this.txtdcld.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).tuyen_tc = "";
                    LoadOptb.Entities.ElementAt(0).ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim());
                    LoadOptb.Entities.ElementAt(0).village = "";
                    LoadOptb.Entities.ElementAt(0).tien_tb = 0;
                    LoadOptb.Entities.ElementAt(0).tienno = 0;
                    LoadOptb.Entities.ElementAt(0).tb_dv = 0;
                    LoadOptb.Entities.ElementAt(0).ngay_ld = null;
                    LoadOptb.Entities.ElementAt(0).ngay_mo = null;
                    LoadOptb.Entities.ElementAt(0).may_ngung = "M";
                    LoadOptb.Entities.ElementAt(0).ngay_ngung = null;
                    LoadOptb.Entities.ElementAt(0).keo_may = false;
                    LoadOptb.Entities.ElementAt(0).mo_may = false;
                    LoadOptb.Entities.ElementAt(0).ma_huyen = App.ma_huyen;
                    LoadOptb.Entities.ElementAt(0).stt = 0;
                    LoadOptb.Entities.ElementAt(0).sohopdong = this.txtsohd.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ngay_hd = this.dngayhd.DateTime;
                    LoadOptb.Entities.ElementAt(0).thangbd = "";
                    LoadOptb.Entities.ElementAt(0).inct = false;
                    LoadOptb.Entities.ElementAt(0).ma_kh = this.txtmakh.Text;
                    LoadOptb.Entities.ElementAt(0).ngay_kn = dngaykn.Text.Trim() == "" ? D_null : this.dngaykn.DateTime;
                    LoadOptb.Entities.ElementAt(0).note_ngay_kn = this.txtghichu.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).khg_vat = false;
                    LoadOptb.Entities.ElementAt(0).cuoc = 0;
                    LoadOptb.Entities.ElementAt(0).ngay = null;
                    LoadOptb.Entities.ElementAt(0).duong = App.duong;
                    LoadOptb.Entities.ElementAt(0).xa_phuong = App.phuong;
                    LoadOptb.Entities.ElementAt(0).khom_ap = App.khom;
                    LoadOptb.Entities.ElementAt(0).tbdc = false;
                    LoadOptb.Entities.ElementAt(0).kh_db = "";
                    LoadOptb.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).socmnd = this.txtcmnd.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).noi_cap = this.txtnoicap.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ngay_cap = this.dngaycap.DateTime;
                    LoadOptb.Entities.ElementAt(0).ngan_hang = this.txtNH.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).e_mail = this.txtemail.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dt_lh = this.txtdtlh.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).camket = Convert.ToInt16(this.spcamket.Text);
                    LoadOptb.Entities.ElementAt(0).ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0, 1)));
                    LoadOptb.Entities.ElementAt(0).ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString();              
             

                Gphone_log dsl = new Gphone_log
                {
                    so_dt = this.txtsdt.Text.Trim(),
                    SoSim = this.txtsosim.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    tuyen_tc = null,
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),
                    may_ngung = "M",
                    ma_huyen = App.ma_huyen,
                    sohopdong = this.txtsohd.Text,
                    ngay_hd = this.dngayhd.DateTime,
                    ma_kh = this.txtmakh.Text,
                    ngay_kn = dngaykn.Text.Trim() == "" ? D_null : this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text.Trim(),
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    e_mail = this.txtemail.Text.Trim(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    thoi_gian = App.Current_d,
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0, 1))),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbkt.SelectedIndex).ToString(),
                    users = App.User_name,
                    dt_lh = this.txtdtlh.Text.Trim(),
                    goi_th= cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim(),
                };

                dstb.Gphone_logs.Add(dsl);
                dstb.SubmitChanges(OnSubmitCompleted, true);

            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}", e));
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
                enable_control(false);
                this.OKButton.IsEnabled = false;
                this.btnNew.IsEnabled = true;
                if (v_update == false)
                    Send_SMS();
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
                if (nhiemthu.IsChecked == true)
                    innhiemthu();
                else
                    inhopdong();              
            }
        }

        void Send_SMS()
        {
            if (cmbcbcs.SelectedIndex != -1)
            {
                string m_db = ";" + cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString().Trim() + ";";
                EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOp = dstb.Load(Query.Where(p => p.diaban.Trim().Contains(m_db) && p.ma_huyen == App.ma_huyen && p.kt == false), LoadOpSMSKD_Complete, null);
            }

            if (cmbcbkt.SelectedIndex != -1)
            {
                string m_db = ";" + cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString().Trim() + ";";
                EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOp = dstb.Load(Query.Where(p => p.diaban.Trim().Contains(m_db) && p.ma_huyen == App.ma_huyen && p.kt == true), LoadOpSMSKT_Complete, null);
            }
        }

        void LoadOpSMSKD_Complete(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                if (lo.Entities.ElementAt(0).phone.Trim() != "")
                {
                    string mess = "HDM: " + txtsdt.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
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
                    string mess = "HDM: " + txtsdt.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
                    InvokeOperation<System.Nullable<int>> p = dstb.SendSMS(mess, lo.Entities.ElementAt(0).phone.Trim(), 0);
                    //p.Completed += new EventHandler(Completed);
                }
            }
        }

        public string Getplkhachhang(string m_maloai)
        {
            string temp="";
            for (int i = 0; i < LoadOpkh.Entities.Count(); i++)
            {
                string ma=LoadOpkh.Entities.ElementAt(i).maloai.Trim();
            	if (ma==m_maloai)
                {
                    temp=LoadOpkh.Entities.ElementAt(i).pl;
                    break;
                }
            }
            return temp;
        }

        private void chkhdcq_Checked(object sender, RoutedEventArgs e)
        {
            frmhdcoquan hdcq = new frmhdcoquan();
            hdcq.Show();
        }

        private void chkhdcq_Unchecked(object sender, RoutedEventArgs e)
        {
            App.nguoidaidien = "";
            App.chucvu = "";
        }

        void inhopdong()
        {           
            frmreport frm;
            MessageBoxResult result = MessageBox.Show("In theo mẫu hợp đồng cũ hay mới ?", "Xác nhận", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
                frm = new frmreport("Rphopdongmoi");
            else
                frm = new frmreport("Rphopdong");               
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            string ngayc = dngaycap.DateTime.Day.ToString().PadLeft(2, '0') + "/" + dngaycap.DateTime.Month.ToString().PadLeft(2, '0') + "/" + dngaycap.DateTime.Year.ToString();
            if (chkhdcq.IsChecked==true)
                frm.m_prBenA = "Bên A: " + Converter.TCVN3ToUnicode(App.nguoidaidien);
            else
                frm.m_prBenA = "Bên A: " + Converter.TCVN3ToUnicode(this.txttentb.Text.Trim());
            frm.m_prChucVu = "Chức Vụ: " + Converter.TCVN3ToUnicode(App.chucvu == null ? "" : App.chucvu);
            frm.m_prDiachi = "Địa chỉ: " + Converter.TCVN3ToUnicode(txtdctb.Text.Trim());
            frm.m_prTK = (this.txttk.Text.Trim() == "" ? "........................." : this.txttk.Text.Trim()) + "   - Ngân hàng: " + (Converter.TCVN3ToUnicode(txtNH.Text.Trim() == "" ? "........................." : txtNH.Text.Trim())) + "    - MST: " + this.txtmst.Text.Trim();
            frm.m_prCMND = this.txtcmnd.Text.Trim() == "" ? "........................." : this.txtcmnd.Text.Trim() + "   - Cấp ngày :" + ngayc + "    - Nơi cấp: " + Converter.TCVN3ToUnicode(txtnoicap.Text.Trim() == "" ? "........................." : txtnoicap.Text.Trim());
            frm.m_prEmail = this.txtemail.Text.Trim();
            frm.m_prSoHD = "SHĐ: " + this.txtsohd.Text.Trim();
            frm.m_prMkh = "MKH: " + this.txtmakh.Text.Trim();       
            frm.m_prSTT1 = "1";
            frm.m_prDCLD1 = " " + Converter.TCVN3ToUnicode(txtdcld.Text.Trim());
            frm.m_prSDT1 = txtsdt.Text;
            frm.m_prDVCT1 = "";
            frm.m_prLoaidv1 = "Điện Thoại Gphone";
            frm.m_prGoicuoc1 = "";
            frm.m_prdtlh = "ĐTLH:" + txtdtlh.Text.Trim();
            frm.Show();
        }

        void innhiemthu()
        {
            frmreportNT frm = new frmreportNT("Rpnhiemthu");
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.m_prsoHD = this.txtsohd.Text.Trim();
            frm.m_prngayHD = dngayhd.DateTime.Day.ToString().PadLeft(2, '0') + "/" + dngayhd.DateTime.Month.ToString().PadLeft(2, '0') + "/" + dngayhd.DateTime.Year.ToString();
            frm.m_prtenKH = "Tên Khách Hàng : " + Converter.TCVN3ToUnicode(this.txttentb.Text.Trim());
            frm.m_prmaKH = "Mã Khách Hàng : " + this.txtmakh.Text.Trim();
            frm.m_prnhanvien = App.nhanvienld;

            frm.m_prDCLD1 = " " + Converter.TCVN3ToUnicode(txtdcld.Text.Trim());
            frm.m_prSDT1 = txtsdt.Text;
            frm.m_prsoSIM = App.soSIM;
            frm.m_prDVCT1 = "";
            frm.m_prtgHM = App.tghoamang;
            frm.m_prkhac = App.thongtinkhac;           
            frm.Show();
        }


        private void cmbnganh_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (cmbnganh.SelectedIndex == -1)
                return;
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

        private void txttentb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txttendb.Text.Trim() == "")
            {
                char[] s = txttentb.Text.Trim().ToCharArray();
                if (FunAndPro.ContainsUnicodeCharacter(s))
                {
                    MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                    txttentb.Focus();
                }
                else
                    txttendb.Text = txttentb.Text.Trim();
            }
            else
            {
                char[] s = txttentb.Text.Trim().ToCharArray();
                if (FunAndPro.ContainsUnicodeCharacter(s))
                {
                    MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                    txttentb.Focus();
                }
            }
        }

        private void txttendb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txttendb.Text.Trim() != "")
            {
                char[] s = txttendb.Text.Trim().ToCharArray();
                if (FunAndPro.ContainsUnicodeCharacter(s))
                {
                    MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                    txttendb.Focus();
                }
            }
        }    

        private void nhiemthu_Checked(object sender, RoutedEventArgs e)
        {
            this.TextLuu.Text = "In NT";
            this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/print-16x16.png", UriKind.RelativeOrAbsolute));
            frmnhiemthugp frm = new frmnhiemthugp();
            frm.txtSIM.Text = this.txtsosim.Text.Trim();
            frm.Show();
        }

        private void nhiemthu_Unchecked(object sender, RoutedEventArgs e)
        {
            if (txtsdt.Text.Trim() != "")
            {
                this.TextLuu.Text = "In HĐ";
                this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/print-16x16.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.TextLuu.Text = "Lưu";
                this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute));
            }
            App.nhanvienld = "";
            App.tghoamang = "";
            App.soSIM = "";
            App.thongtinkhac = "";
        }

        private void cmbgoith_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            m_lan += 1;
            if (cmbgoith.SelectedIndex == -1)
                return;
            //if (txtusr.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập đầy đủ thông tin !");
            //    return;
            //}
            string m_goi = this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();

            if (m_goi != "" && m_lan > 1)
            {           
                for (int i = 0; i < LoadGoi.Entities.Count(); i++)
                {
                    if (LoadGoi.Entities.ElementAt(i).ma_goi.Trim() == m_goi)
                    {
                        Int32 sl = Convert.ToInt32(LoadGoi.Entities.ElementAt(i).sl_dd);
                        string so = txtsdt.Text.Trim();
                        string ten = txttentb.Text.Trim();
                        string dc = txtdctb.Text.Trim();
                        frmgoicuoc frm = new frmgoicuoc(sl, false, so, ten, dc, "G", m_goi,false,"");
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void cmdview_Click(object sender, RoutedEventArgs e)
        {
            string m_goi = this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();
            if (idgoi != "")
            {
                frmgoicuoc frm = new frmgoicuoc(0, false, "", "", "", "", m_goi, true, idgoi);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Khách hàng này chưa có dữ liệu gói cước !");
        }

        private void cmdviewkt_Click(object sender, RoutedEventArgs e)
        {
            if (cmbcbkt.SelectedIndex != -1)
            {
                string ma_db = this.cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString().Trim();
                ma_db = ";" + ma_db + ";";
                EntityQuery<nhanvien_cs> Q = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> Load = dstb.Load(Q.Where(p => p.ma_huyen == App.ma_huyen && p.kt == true && p.diaban.Contains(ma_db)), LoadC, null);
            }
        }

        private void cmdviewcs_Click(object sender, RoutedEventArgs e)
        {
            if (cmbcbcs.SelectedIndex != -1)
            {
                string ma_db = this.cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString().Trim();
                ma_db = ";" + ma_db + ";";
                EntityQuery<nhanvien_cs> Q = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> Load = dstb.Load(Q.Where(p => p.ma_huyen == App.ma_huyen && p.kt == false && p.diaban.Contains(ma_db)), LoadC, null);
            }
        }

        void LoadC(LoadOperation<nhanvien_cs> lo)
        {
            string nv = "";
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    if (nv == "")
                        nv = lo.Entities.ElementAt(i).ten_nv.Trim();
                    else
                        nv = nv + " +" + lo.Entities.ElementAt(i).ten_nv.Trim();
                }
                MessageBox.Show("Nhân viên phụ trách: " + Converter.TCVN3ToUnicode(nv));
            }
            else
                MessageBox.Show("Chưa tìm thấy nhân viên phụ trách địa bàn này !");
        }
        
    }
}

