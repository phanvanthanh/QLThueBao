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
    public partial class frmhopdongkr : ChildWindow
    {
        bool dcthuebao, dclapdat, v_update;
        string m_sohopdong,m_makh,m_phuong;
        string so_119;
        frmdiachi frmdc;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();      
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<gc_mytv> LoadOpgc;
        LoadOperation<tram_vt> LoadOp;
        LoadOperation<nhanvien_cs> LoadOpCB;
        LoadOperation<kenh_thue_rieng> LoadOptb;
        LoadOperation<chungloaicap> LoadOpcap;

        public frmhopdongkr()
        {
            InitializeComponent();
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOp = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p => p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
          
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN.OrderBy(p => p.ten_nghe), LoadOpN_Complete, null);
            EntityQuery<gc_mytv> Querygc = dstb.GetGc_mytvQuery();
            LoadOpgc = dstb.Load(Querygc.OrderBy(p=>p.ma_goi), LoadOpGC_Complete, null);
            EntityQuery<nhanvien_cs> QueryNV = dstb.Getnhanvien_csQuery();
            LoadOpCB = dstb.Load(QueryNV.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten_nv), LoadOpCB_Complete, null);
            //EntityQuery<chungloaicap> Querycap = dstb.GetChungloaicapsQuery();
            //LoadOpcap = dstb.Load(Querycap.Where(p => p.dv == "M").OrderBy(p => p.ten_loai), LoadOpCAP_Complete, null);
            //this.txtsdt.MaxLength = App.len_sdt;
            //frmdc = new frmdiachi();
            //frmdc.Closed += new EventHandler(frmdiachi_Closed); 
           
        }

        //void LoadOpCAP_Complete(LoadOperation<chungloaicap> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        this.cmbloaicap.DisplayMember = ("ten_loai").Trim();
        //        this.cmbloaicap.ValueMember = "loai_cap";
        //        this.cmbloaicap.ItemsSource = lo.Entities;

        //    }
        //}

        void LoadOpT_Complete(LoadOperation<tram_vt> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtramvt.DisplayMember = ("ten_tram").Trim();
                this.cmbtramvt.ValueMember = "ma_tram";
                this.cmbtramvt.ItemsSource = lo.Entities;
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

        void LoadOpN_Complete(LoadOperation<nganh_nghe> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnganh.DisplayMember = ("ten_nghe").Trim();
                this.cmbnganh.ValueMember = "ma_nghe";
                this.cmbnganh.ItemsSource = lo.Entities;
            }
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

        void LoadOpCB_Complete(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbcbcs.DisplayMember = ("ten_nv").Trim();
                this.cmbcbcs.ValueMember = "ma_nvcs";
                this.cmbcbcs.ItemsSource = lo.Entities;
            }
        }

        private void txtmakh_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtmakh.Text.Length>0)
            {
                {
                    EntityQuery<kenh_thue_rieng> Query = dstb.GetKenh_thue_riengQuery();
                    LoadOptb = dstb.Load(Query.Where(p => p.ma_kh.Trim() == this.txtmakh.Text.Trim()), LoadOp_Complete, null);
                }
            }        
        }

        void LoadOp_Complete(LoadOperation<kenh_thue_rieng> lo)
        {            
            if (lo.Entities.Count() > 0)
            {
                v_update = true;
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
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb==null ? "" : lo.Entities.ElementAt(0).dia_chitb.Trim();
                
                //this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                //this.txtNH.Text = lo.Entities.ElementAt(0).ngan_hang== null ? "" :lo.Entities.ElementAt(0).ngan_hang.Trim();
                this.txtmst.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                this.dngaykn.EditValue = lo.Entities.ElementAt(0).ngay_kn;
                this.txtghichu.Text = lo.Entities.ElementAt(0).note_ngay_kn == null ? "" : lo.Entities.ElementAt(0).note_ngay_kn.Trim();
                this.txtemail.Text = lo.Entities.ElementAt(0).e_mail == null ? "" : lo.Entities.ElementAt(0).e_mail.Trim();
                this.txtseri.Text = lo.Entities.ElementAt(0).stb_serial == null ? "" : lo.Entities.ElementAt(0).stb_serial.Trim();
                this.spcamket.Text = lo.Entities.ElementAt(0).camket == null ? "0" : lo.Entities.ElementAt(0).camket.ToString();
                this.txtdtlh.Text = lo.Entities.ElementAt(0).dt_lh == null ? "" :  lo.Entities.ElementAt(0).dt_lh.ToString();
                this.label1.Content = lo.Entities.ElementAt(0).so_119 == null ? "" : "Số báo 119: " + lo.Entities.ElementAt(0).so_119.ToString();
                so_119 = lo.Entities.ElementAt(0).so_119.ToString();
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

                //string loaicap = lo.Entities.ElementAt(0).loai_cap == null ? "" : lo.Entities.ElementAt(0).loai_cap.Trim();
                //if (loaicap != "")
                //{
                //    for (int i = 0; i < LoadOpcap.Entities.Count(); i++)
                //    {
                //        if (this.cmbloaicap.GetKeyValue(i).ToString().Trim() == loaicap)
                //        {
                //            this.cmbloaicap.SelectedIndex = i;
                //        }
                //    }
                //}
                //else
                //    this.cmbloaicap.SelectedIndex = -1;

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
          //  this.txtsohd.IsReadOnly = enabled;
          //  this.dngayhd.IsReadOnly = enabled;
            this.cmbgoicuoc.IsReadOnly = enabled;
            this.txtseri.IsReadOnly = enabled;
            //this.cmbloaicap.IsReadOnly = enabled;
            this.cmbhtld.IsReadOnly = enabled;
            this.txttentb.IsReadOnly = enabled;
            this.txtdctb.IsReadOnly = enabled;
            this.txtdcld.IsReadOnly = enabled;
            this.txttendb.IsReadOnly = enabled;
            this.txtsdt.IsReadOnly = enabled;
            this.txtcmnd.IsReadOnly = enabled;
            this.txtnoicap.IsReadOnly = enabled;
            this.dngaycap.IsReadOnly = enabled;
            this.txttk.IsReadOnly = enabled;
            this.txtNH.IsReadOnly = enabled;
            this.txtmst.IsReadOnly = enabled;
            this.txtdvct.IsReadOnly = enabled;
            this.cmbtramvt.IsReadOnly = enabled;
            this.cmbhttt.IsReadOnly = enabled;
            this.cmbcbcs.IsReadOnly = enabled;
            if (v_update)
            {
                this.cmbkm.IsReadOnly = true;
                this.txtusr.IsReadOnly = true;
            }
            else
            {
                this.cmbkm.IsReadOnly = enabled;
                this.txtusr.IsReadOnly = enabled;
            }
            this.cmbnhom.IsReadOnly = enabled;
            this.cmbnganh.IsReadOnly = enabled;
            this.dngaykn.IsReadOnly = enabled;           
            this.txtghichu.IsReadOnly = enabled;            
            this.txtemail.IsReadOnly = enabled;
            this.spcamket.IsReadOnly = enabled;
            this.txtdtlh.IsReadOnly = enabled;
        }

        void Clear_control()
        {            
            this.txtusr.IsReadOnly = false;
            //this.txtusr.Text = "";
            this.txtmakh.Text = "";
            this.txtsohd.Text = "";
            this.dngayhd.EditValue = App.Current_d;
            this.cmbgoicuoc.Text = "";
            this.txtseri.Text = "";
           // this.cmbloaicap.Text = "";
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
            this.txtNH.Text = "";
            this.txtmst.Text = "";
            this.txtdvct.Text = "";
            this.cmbtramvt.EditValue=null;
            this.cmbhttt.SelectedIndex=0;
            this.cmbkm.SelectedIndex = 0;
            this.spcamket.Text = "0";
            this.cmbnhom.EditValue = null;
            this.cmbnganh.EditValue = null;
            this.dngaykn.EditValue = null;
            this.cmbcbcs.SelectedIndex = -1;
            this.txtghichu.Text = "";
            this.txtemail.Text = "";
            this.txtdtlh.Text = "";
            this.label1.Content = "";
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
                {
                    this.txtdcld.Text = frmdc.txtdiachi.ToString();
                    m_phuong = App.m_phuong;
                }
            }
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
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
            if (this.txtusr.Text == "" || this.cmbgoicuoc.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbnhom.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || dngaycap.Text.Trim() == "" )
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                if (v_update)
                    if (LoadOptb.Entities.ElementAt(0).tinh_trang == "M")
                        Update_data();
                    else
                        if (nhiemthu.IsChecked == true)
                            innhiemthu();
                        else
                            inhopdong();    
                else
                {
                    // lay hopdong                
                    string m_hd = App.ma_huyen + "-M/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2);
                    EntityQuery<maxmakhachhang> Query = dstb.GethopdongmyQuery(m_hd);
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
            m_sohopdong = temps.PadLeft(6, '0') + "/" + App.ma_huyen + "-M/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2);
            this.txtsohd.Text = m_sohopdong;
            // lay ma khach hang
            EntityQuery<maxmakhachhang> Query = dstb.GetmaxmakhachhangmyQuery(App.batdau_mkh);
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
            
            m_makh = App.batdau_mkh +"M"+ temps.PadLeft(5, '0');
            this.txtmakh.Text = m_makh;

            EntityQuery<maxmakhachhang> Query = dstb.Get119MytvQuery(App.batdau_119+"3");
            LoadOperation<maxmakhachhang> LoadOp = dstb.Load(Query, LoadOp119_Complete, null);           
        }

        void LoadOp119_Complete(LoadOperation<maxmakhachhang> lo)
        {
            string temps;
            if (lo.Entities.Count() > 0)
            {
                temps = lo.Entities.ElementAt(0).maxmakh == null ? "0" : lo.Entities.ElementAt(0).maxmakh.Trim();
                temps = (Convert.ToInt32(temps) + 1).ToString();
            }
            else
                temps = "1";
            so_119= App.batdau_119+"3" + temps.PadLeft(5, '0');
            this.label1.Content = "Số báo 119: " + so_119;
            // bat dau luu du lieu nhap vao tables
            SaveData();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            v_update = false;
            enable_control(true);
            Clear_control();
            txtusr.Text = "";
            txtusr.Focus();            
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
                mytv ds = new mytv
                {
                    user_name = this.txtusr.Text.Trim(),                    
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    sohopdong = this.txtsohd.Text.Trim(),
                    ngay_hd = this.dngayhd.DateTime,
                    tuyen_tc = "",
                    goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString(),
                    so_dt=this.txtsdt.Text.Trim(),
                    stb_serial = this.txtseri.Text.Trim(),
                   // loai_cap=this.cmbloaicap.Text.Trim().Substring(0,1),
                    ht_ld = this.cmbhtld.Text.Trim().Substring(0, 1),
                    ma_huyen = App.ma_huyen,
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    ma_kh = this.txtmakh.Text,
                    ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString(),
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),                    
                    tinh_trang="M",                    
                    ngay_kn = this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text,                    
                    tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim()),
                    dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim()),
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),                  
                    duong = App.duong,
                    xa_phuong = App.phuong,
                    khom_ap = App.khom, 
                    maxa=m_phuong,
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    ngan_hang = this.txtNH.Text.Trim(),
                    e_mail = this.txtemail.Text.Trim(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? "" : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    user_login = App.User_name,
                    dt_lh = this.txtdtlh.Text.Trim(),
                    so_119=so_119

                };
                dstb.mytvs.Add(ds);


                mytv_log dsl = new mytv_log
                {
                    user_name = this.txtusr.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    sohopdong = this.txtsohd.Text.Trim(),
                    ngay_hd = this.dngayhd.DateTime,
                    tuyen_tc = "",
                    goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString(),
                    so_dt = this.txtsdt.Text.Trim(),
                    stb_serial = this.txtseri.Text.Trim(),
                   // loai_cap = this.cmbloaicap.Text.Trim().Substring(0, 1),
                    ht_ld = this.cmbhtld.Text.Trim().Substring(0, 1),
                    ma_huyen = App.ma_huyen,
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    ma_kh = this.txtmakh.Text,                    
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),
                    tinh_trang = "M",
                    ngay_kn = this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text,                    
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),                    
                    ngan_hang = this.txtNH.Text.Trim(),
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    user_login = App.User_name,
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? "" : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    thoi_gian=App.Current_d,
                    dt_lh = this.txtdtlh.Text.Trim()
                };
                dstb.mytv_logs.Add(dsl);
                dstb.SubmitChanges(OnSubmitCompleted,true);                
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}",e));
            }
        }

        void Update_data()
        {
            try
            {
                // get_hopdong(App.ma_huyen + "/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2));
             
                    //LoadOptb.Entities.ElementAt(0).user_name = this.txtusr.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ten_dktb = this.txttentb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ten_dkdb = this.txttendb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dia_chitb = this.txtdctb.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dc_tbld = this.txtdcld.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).sohopdong = this.txtsohd.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ngay_hd = this.dngayhd.DateTime;
                    LoadOptb.Entities.ElementAt(0).tuyen_tc = "";
                    LoadOptb.Entities.ElementAt(0).goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).so_dt = this.txtsdt.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).stb_serial = this.txtseri.Text.Trim();
                   // LoadOptb.Entities.ElementAt(0).loai_cap = this.cmbloaicap.Text.Trim().Substring(0, 1);
                    LoadOptb.Entities.ElementAt(0).ht_ld = this.cmbhtld.Text.Trim().Substring(0, 1);
                    LoadOptb.Entities.ElementAt(0).ma_huyen = App.ma_huyen;
                    LoadOptb.Entities.ElementAt(0).socmnd = this.txtcmnd.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).noi_cap = this.txtnoicap.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).ngay_cap = this.dngaycap.DateTime;
                    LoadOptb.Entities.ElementAt(0).ma_kh = this.txtmakh.Text;
                    LoadOptb.Entities.ElementAt(0).ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim());
                    LoadOptb.Entities.ElementAt(0).tinh_trang = "M";
                    LoadOptb.Entities.ElementAt(0).ngay_kn = this.dngaykn.DateTime;
                    LoadOptb.Entities.ElementAt(0).note_ngay_kn = this.txtghichu.Text;
                    LoadOptb.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim());
                    LoadOptb.Entities.ElementAt(0).duong = App.duong;
                    LoadOptb.Entities.ElementAt(0).xa_phuong = App.phuong;
                    LoadOptb.Entities.ElementAt(0).khom_ap = App.khom;
                    LoadOptb.Entities.ElementAt(0).maxa = m_phuong;
                    LoadOptb.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).ngan_hang = this.txtNH.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).e_mail = this.txtemail.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).dt_lh = this.txtdtlh.Text.Trim();
                    LoadOptb.Entities.ElementAt(0).camket = Convert.ToInt16(this.spcamket.Text);
                    LoadOptb.Entities.ElementAt(0).ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).ma_nvcs = cmbcbcs.SelectedIndex == -1 ? "" : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString();
                    LoadOptb.Entities.ElementAt(0).user_login = App.User_name;



                mytv_log dsl = new mytv_log
                {
                    user_name = this.txtusr.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    sohopdong = this.txtsohd.Text.Trim(),
                    ngay_hd = this.dngayhd.DateTime,
                    tuyen_tc = "",
                    goi_cuoc = cmbgoicuoc.GetKeyValue(cmbgoicuoc.SelectedIndex).ToString(),
                    so_dt = this.txtsdt.Text.Trim(),
                    stb_serial = this.txtseri.Text.Trim(),
                   // loai_cap = this.cmbloaicap.Text.Trim().Substring(0, 1),
                    ht_ld = this.cmbhtld.Text.Trim().Substring(0, 1),
                    ma_huyen = App.ma_huyen,
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = this.dngaycap.DateTime,
                    ma_kh = this.txtmakh.Text,
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString().Trim()),
                    tinh_trang = "M",
                    ngay_kn = this.dngaykn.DateTime,
                    note_ngay_kn = this.txtghichu.Text,
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    ngan_hang = this.txtNH.Text.Trim(),
                    ma_km = cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    user_login = App.User_name,
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? "" : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    thoi_gian = App.Current_d,
                    dt_lh = this.txtdtlh.Text.Trim()
                };
                dstb.mytv_logs.Add(dsl);
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
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
                if (nhiemthu.IsChecked == true)
                    innhiemthu();
                else
                    inhopdong();    
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
            if (chkhdcq.IsChecked == true)
                frm.m_prBenA = "Bên A: " + Converter.TCVN3ToUnicode(App.nguoidaidien);
            else
                frm.m_prBenA = "Bên A: " + Converter.TCVN3ToUnicode(this.txttentb.Text.Trim());
            frm.m_prChucVu = "Chức Vụ: " + Converter.TCVN3ToUnicode(App.chucvu == null ? "" : App.chucvu);
            frm.m_prDiachi = "Địa chỉ: " + Converter.TCVN3ToUnicode(txtdctb.Text.Trim());
            frm.m_prTK = (this.txttk.Text.Trim() == "" ? "........................." : this.txttk.Text.Trim()) + "   - Ngân hàng: " + (Converter.TCVN3ToUnicode(txtNH.Text.Trim() == "" ? "........................." : txtNH.Text.Trim())) + "    - MST: " + this.txtmst.Text.Trim();
            frm.m_prCMND = this.txtcmnd.Text.Trim() == "" ? "........................." : this.txtcmnd.Text.Trim() + "   - Cấp ngày :" + ngayc + "    - Nơi cấp: " + Converter.TCVN3ToUnicode(txtnoicap.Text.Trim() == "" ? "........................." : txtnoicap.Text.Trim());
            frm.m_prEmail = this.txtemail.Text.Trim();
            frm.m_prSoHD = "SHĐ: "+this.txtsohd.Text.Trim();
            frm.m_prMkh = "MKH: "+this.txtmakh.Text.Trim();
            frm.m_prSTT1 = "1";
            frm.m_prDCLD1 = " " + Converter.TCVN3ToUnicode(txtdcld.Text.Trim());
            frm.m_prSDT1 = txtusr.Text;
            frm.m_prDVCT1 = "";
            frm.m_prLoaidv1 = "MyTV";
            frm.m_prGoicuoc1 = cmbgoicuoc.Text;
            frm.m_prdtlh = "ĐTLH:"+ txtdtlh.Text.Trim();
            frm.m_prso119 = "Số 119:" + so_119;
         
            frm.Show();
        }


        void innhiemthu()
        {
            frmreportNTMy frm = new frmreportNTMy("Rpnhiemthumy");
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.m_prsoHD = this.txtsohd.Text.Trim();
            frm.m_prngayHD = dngayhd.DateTime.Day.ToString().PadLeft(2, '0') + "/" + dngayhd.DateTime.Month.ToString().PadLeft(2, '0') + "/" + dngayhd.DateTime.Year.ToString();
            frm.m_prtenKH = "Tên Khách Hàng : " + Converter.TCVN3ToUnicode(this.txttentb.Text.Trim());
            frm.m_prmaKH = "Mã Khách Hàng : " + this.txtmakh.Text.Trim();
            frm.m_prnhanvien = App.nhanvienld;

            frm.m_prDCLD1 = " " + Converter.TCVN3ToUnicode(txtdcld.Text.Trim());
            frm.m_prSDT1 = this.txtsdt.Text.Trim();         
            frm.m_prsoBGM = txtseri.Text.Trim();
            frm.m_prgoiCuoc = cmbgoicuoc.Text.Trim();
           // frm.m_prloaiCap = cmbloaicap.Text.Trim();
            frm.m_prloaiCap = "";
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
            frmnhiemthucd frm = new frmnhiemthucd();
            frm.Title = "In nhiệm thu MyTV";
            frm.Show();
        }

        private void nhiemthu_Unchecked(object sender, RoutedEventArgs e)
        {
            if (txtusr.Text.Trim() != "")
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
            App.thongtinkhac = "";
        }   
    }
}

