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
    public partial class frmeditcd : ChildWindow
    {
     //   private Action<System.ServiceModel.DomainServices.Client.LoadOperation<ds_codinh>> LoadOp_Complete = null;
        bool dcthuebao,dclapdat,m_tinhtb,m_ld,m_tbmoi,m_lan;
        string m_sdt, idgoi; // sodt neu co thi quay ve tim lai 
        int m_loaiform; // dung de luu form khi dong se quay ve 1: quay ve form frmdscodinh 2 : quay ve form frmdsbdcodinh
        string S_null;
        frmdiachi frmdc;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<tram_vt> LoadOptram;
        LoadOperation<maxas> LoadOpxa;
        LoadOperation<nv_thuethu> LoadOptuyen;
        LoadOperation<dichvugiatang> LoadOpdvgt;
        LoadOperation<dichvugiatang_log> LoadOpdv;
        LoadOperation<Mdiaban> LoadOpCB;
        LoadOperation<Mdiaban> LoadOpCBKT;
        LoadOperation<ds_codinh> LoadOp;
        LoadOperation<chungloaicap> LoadOpcap;
        LoadOperation<Goi_th> LoadGoi;
        
        public frmeditcd(bool tinhtb,string sdt,int loaiform)
        {
            InitializeComponent();
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOptram = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p => p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN.OrderBy(p => p.ten_nghe), LoadOpN_Complete, null);
            EntityQuery<maxas> Queryxa = dstb.GetMaxasQuery();
            LoadOpxa = dstb.Load(Queryxa.Where(p=>p.ma_huyen==App.ma_huyen).OrderBy(p=>p.ten), LoadOpXA_Complete, null);
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpTT_Complete, null);
            EntityQuery<dichvugiatang> Querydvgt = dstb.GetDichvugiatangsQuery();
            LoadOpdvgt = dstb.Load(Querydvgt.OrderBy(p => p.ten_dv), LoadOpDV_Complete, null);
            EntityQuery<Mdiaban> QueryNV = dstb.GetMadiabanTrimQuery();
            LoadOpCB = dstb.Load(QueryNV.Where(p => p.ma_huyen == App.ma_huyen && p.kt==false).OrderBy(p => p.ten_tuyen), LoadOpCB_Complete, null);
            EntityQuery<Mdiaban> QueryNVKT = dstb.GetMadiabanTrimQuery();
            LoadOpCBKT = dstb.Load(QueryNVKT.Where(p => p.ma_huyen == App.ma_huyen && p.kt == true).OrderBy(p => p.ten_tuyen), LoadOpCBKT_Complete, null);
            EntityQuery<chungloaicap> Querycap = dstb.GetChungloaicapsQuery();
            LoadOpcap = dstb.Load(Querycap.Where(p => p.dv == "C").OrderBy(p => p.ten_loai), LoadOpCAP_Complete, null);
            EntityQuery<Goi_th> QueryG = dstb.GetGoi_thQuery();
            LoadGoi = dstb.Load(QueryG.OrderBy(p => p.ten_goi), LoadOpG_Complete, null);
            this.txtsdt.MaxLength = App.len_sdt;
            m_tinhtb = tinhtb;
            m_loaiform = loaiform;
            m_sdt = sdt;
            dngayld.EditValue = App.Current_d;
            if (m_tinhtb)
                this.Title = "Tính tiền thuê bao cho thuê bao cố định mới";
            else
                this.Title = "Sửa đổi thông tin thuê bao cố định";
            Loaded += new RoutedEventHandler(frmeditcd_Loaded);          
            //frmdc = new frmdiachi();
            //frmdc.Closed += new EventHandler(frmdiachi_Closed); 
           
        }
        void frmeditcd_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_sdt != "")
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

        void LoadOpKH_Complete(LoadOperation<loaikh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnhom.DisplayMember = ("mota").Trim();
                this.cmbnhom.ValueMember = "maloai";
                this.cmbnhom.ItemsSource = lo.Entities;

            }
        }

        void LoadOpXA_Complete(LoadOperation<maxas> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbxa.ItemsSource = lo.Entities;
                this.cmbxa.DisplayMember = ("ten").Trim(); 
                this.cmbxa.ValueMember = "maxa";
                

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

        void LoadOpN_Complete(LoadOperation<nganh_nghe> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnganh.DisplayMember = ("ten_nghe").Trim();
                this.cmbnganh.ValueMember = "ma_nghe";
                this.cmbnganh.ItemsSource = lo.Entities;

            }
        }
        void LoadOpDV_Complete(LoadOperation<dichvugiatang> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbdvct.ItemsSource = lo.Entities;
                this.cmbdvct.DisplayMember = ("ten_dv").Trim();
                this.cmbdvct.ValueMember = "ma_dv";

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


        void LoadOpCAP_Complete(LoadOperation<chungloaicap> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbloaicap.DisplayMember = ("ten_loai").Trim();
                this.cmbloaicap.ValueMember = "loai_cap";
                this.cmbloaicap.ItemsSource = lo.Entities;

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
            m_lan = false;
            App.id_goicuoc = null;
            laythongtin();
        }

        void laythongtin()
        {
            Clear_control();
            if (this.txtsdt.Text.Length == App.len_sdt)
            {                
                {
                    EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                    LoadOp = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text && t.ma_kh.Substring(0,7) == App.batdau_mkh), LoadOp_Complete, null);
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

        void LoadOp_Complete(LoadOperation<ds_codinh> lo)
        {           
            if (lo.Entities.Count() > 0)
            {
                //v_update = true;
                OKButton.IsEnabled = true;
                cmdview.IsEnabled = true;
                this.txtmakh.Text = lo.Entities.ElementAt(0).ma_kh.Trim();
                this.txtsohd.Text = lo.Entities.ElementAt(0).sohopdong == null ? "" : lo.Entities.ElementAt(0).sohopdong.Trim();
                if (lo.Entities.ElementAt(0).ngay_hd.HasValue)  
                this.dngayhd.EditValue = lo.Entities.ElementAt(0).ngay_hd;
                this.txttentb.Text = lo.Entities.ElementAt(0).ten_dktb == null ? "" : lo.Entities.ElementAt(0).ten_dktb.Trim();
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_dkdb == null ? "" : lo.Entities.ElementAt(0).ten_dkdb.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();
                this.txttientb.Text = lo.Entities.ElementAt(0).tien_tb == null ? "0" : lo.Entities.ElementAt(0).tien_tb.ToString();
                this.txttbdv.Text = lo.Entities.ElementAt(0).tb_dv == null ? "0" : lo.Entities.ElementAt(0).tb_dv.ToString();
                this.txttientbtk.Text = lo.Entities.ElementAt(0).tienno == null ? "0" : lo.Entities.ElementAt(0).tienno.ToString();
                m_tbmoi = lo.Entities.ElementAt(0).may_ngung == "M" ? true : false;
                //this.cmbvtci.SelectedIndex = lo.Entities.ElementAt(0).khg_vat == null ? -1 : lo.Entities.ElementAt(0).khg_vat == false ? 0 : 1;
                if (lo.Entities.ElementAt(0).ngay_ld.HasValue)
                {
                    this.dngayld.EditValue = lo.Entities.ElementAt(0).ngay_ld;
                    dngayld.IsEnabled = false;
                }
                else
                    dngayld.IsEnabled = true;
                
                this.txtthangbd.Text = lo.Entities.ElementAt(0).thangbd == null ? "" : lo.Entities.ElementAt(0).thangbd.ToString();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                if (lo.Entities.ElementAt(0).ngay_cap.HasValue)  
                this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap.Value;                
                this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                this.txtNH.Text = lo.Entities.ElementAt(0).ngan_hang== null ? "" :lo.Entities.ElementAt(0).ngan_hang.Trim();
                this.txtmst.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                if (lo.Entities.ElementAt(0).ngay_kn.HasValue)  
                this.dngaykn.EditValue = lo.Entities.ElementAt(0).ngay_kn;
                this.txtghichu.Text = lo.Entities.ElementAt(0).note_ngay_kn == null ? "" : lo.Entities.ElementAt(0).note_ngay_kn.Trim();
                this.txtemail.Text = lo.Entities.ElementAt(0).e_mail == null ? "" : lo.Entities.ElementAt(0).e_mail.Trim();
                this.txtdtlh.Text = lo.Entities.ElementAt(0).dt_lh == null ? "" : lo.Entities.ElementAt(0).dt_lh.ToString();
                this.spcamket.Text = lo.Entities.ElementAt(0).camket == null ? "0" : lo.Entities.ElementAt(0).camket.ToString();
                idgoi = lo.Entities.ElementAt(0).id_goicuoc == null ? "" : lo.Entities.ElementAt(0).id_goicuoc.Trim();
                App.id_goicuoc = idgoi == "" ? S_null : idgoi; ;
                string xa = lo.Entities.ElementAt(0).village == null ? "" : lo.Entities.ElementAt(0).village.Trim();

                if (xa != "")
                {
                    for (int i = 0; i < LoadOpxa.Entities.Count(); i++)
                    {
                        if (this.cmbxa.GetKeyValue(i).ToString().Trim() == xa)
                        {
                            this.cmbxa.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbxa.SelectedIndex = -1;


                string loaic = lo.Entities.ElementAt(0).loai_cap == null ? "" : lo.Entities.ElementAt(0).loai_cap.Trim();
                if (loaic != "")
                {
                    for (int i = 0; i < LoadOpcap.Entities.Count(); i++)
                    {
                        if (this.cmbloaicap.GetKeyValue(i).ToString().Trim() == loaic)
                        {
                            this.cmbloaicap.SelectedIndex = i;
                        }
                    }
                }
                else
                    this.cmbloaicap.SelectedIndex = -1;            


                App.sonha = lo.Entities.ElementAt(0).so_nha == null ? "" : lo.Entities.ElementAt(0).so_nha.Trim();
                App.duong = lo.Entities.ElementAt(0).duong == null ? "" : lo.Entities.ElementAt(0).duong.Trim();
                App.phuong = lo.Entities.ElementAt(0).xa_phuong == null ? "" : lo.Entities.ElementAt(0).xa_phuong.Trim();
                App.khom = lo.Entities.ElementAt(0).khom_ap == null ? "" : lo.Entities.ElementAt(0).khom_ap.Trim();
                App.sonhald = lo.Entities.ElementAt(0).so_nhald == null ? "" : lo.Entities.ElementAt(0).so_nhald.Trim();
                App.duongld = lo.Entities.ElementAt(0).duongld == null ? "" : lo.Entities.ElementAt(0).duongld.Trim();
                App.phuongld = lo.Entities.ElementAt(0).xa_phuongld == null ? "" : lo.Entities.ElementAt(0).xa_phuongld.Trim();
                App.khomld = lo.Entities.ElementAt(0).khom_apld == null ? "" : lo.Entities.ElementAt(0).khom_apld.Trim();

                string tram = lo.Entities.ElementAt(0).ma_tram == null ? "" : lo.Entities.ElementAt(0).ma_tram.Trim();
                if (tram != "")
                {
                    for (int i = 0; i < LoadOptram.Entities.Count(); i++)
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
                    cmbkm.IsEnabled = true;
                    for (int i = 0; i < LoadOpkm.Entities.Count(); i++)
                    {
                        if (cmbkm.GetKeyValue(i).ToString().Trim() == km)
                        {
                            cmbkm.SelectedIndex = i;
                        }
                    }
                    cmbkm.IsEnabled = false;
                }
                else
                {
                    this.cmbkm.SelectedIndex = -1;
                    cmbkm.IsEnabled = false;
                }

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

                // lay danh sach dich vu cong them thue bao dang su dung danh dau check vao comboxbox cmbdvct
                if (this.txttbdv.Text.Trim() != "" || this.txttbdv.Text.Trim() != "0")
                {
                    EntityQuery<dichvugiatang_log> Query = dstb.GetDichvugiatang_logQuery();
                    LoadOpdv = dstb.Load(Query.Where(t => t.so_dt.Trim() == this.txtsdt.Text), LoadOpDVG_Complete, null);
                }
                m_lan = true; // lam dau de neu lan dau thi khong the hien form goicuoc.      
            }
            else
            {               
                Clear_control();
                enable_control(true);
                cmdview.IsEnabled = false;
                OKButton.IsEnabled = false;
            }
        }

        void LoadOpDVG_Complete(LoadOperation<dichvugiatang_log> lo)
        {
            string dv = "";
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)                
                    dv += lo.Entities.ElementAt(i).ma_dv.Trim() + ";";
                string[] dvct = dv.Split(';');
                    foreach (string s in dvct)
                    {
                        foreach (var p in LoadOpdvgt.Entities)
                        {
                            if (p.ma_dv.Trim() == s)
                                this.cmbdvct.SelectedItems.Add(p);

                        }
                    }
            }
        }
        void enable_control(bool enabled)
        {

            this.txtmakh.IsEnabled = enabled;
            this.txtsohd.IsEnabled = enabled;
            this.dngayhd.IsEnabled = enabled;
            this.txttentb.IsEnabled = enabled;
            this.txtdctb.IsEnabled = enabled;
            this.txtdcld.IsEnabled = enabled;
            this.txttendb.IsEnabled = enabled;            
            this.txtcmnd.IsEnabled = enabled;
            this.txtnoicap.IsEnabled = enabled;
            this.dngaycap.IsEnabled = enabled;
            this.txttk.IsEnabled = enabled;
            this.txtNH.IsEnabled = enabled;
            this.txtmst.IsEnabled = enabled;
            this.cmbdvct.IsEnabled = enabled;
            this.cmbtramvt.IsEnabled = enabled;
            this.cmbcbcs.IsEnabled = enabled;
            this.cmbcbkt.IsEnabled = enabled;
            this.cmbhttt.IsEnabled = enabled;
            this.cmbkm.IsEnabled = enabled;
            this.txtdtlh.IsEnabled = enabled;
            this.cmbnhom.IsEnabled = enabled;
            this.dngaykn.IsEnabled = enabled;
            this.spcamket.IsEnabled = enabled;
            this.spslcap.IsEnabled = enabled;
            if (enabled)
                this.txtghichu.IsReadOnly = false;
            else
                this.txtghichu.IsReadOnly = true;
            this.txtemail.IsEnabled = enabled;
            this.cmbgoith.IsEnabled = enabled;
        }

        void Clear_control()
        {

            this.txtmakh.Text = "";
            this.txtsohd.Text = "";
            this.dngayhd.EditValue = null;
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtcmnd.Text = "";
            this.txtnoicap.Text = "";
            this.dngaycap.EditValue = null;
            this.dngayld.EditValue = null;
            this.cmbxa.SelectedIndex = -1;
            //this.cmbtuyen.SelectedIndex = -1;
            this.txttientb.Text = "";
            this.txttbdv.Text = "";
            this.txttientbtk.Text = "";
            this.txtthangbd.Text = "";
           // this.cmbvtci.SelectedIndex = -1;
            this.cmbtuyen.SelectedIndex = -1;
            this.cmbcbcs.SelectedIndex = -1;
            this.cmbcbkt.SelectedIndex = -1;
            this.cmbgoith.SelectedIndex = -1;
            this.txttk.Text = "";
            this.txtNH.Text = "";
            this.txtmst.Text = "";
            this.cmbdvct.Text = "";
            this.cmbtramvt.EditValue=null;
            this.cmbhttt.EditValue = null;
            this.cmbkm.EditValue = null;
            this.cmbnhom.EditValue = null;
            this.cmbnganh.EditValue = null;
            this.dngaykn.EditValue = null;
            this.dngayld.EditValue = null;
            this.txtghichu.Text = "";
            this.txtdtlh.Text = "";
            this.txtemail.Text = "";
            this.spcamket.Text = "0";
            this.spslcap.Text = "0";
            m_lan = false;
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


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
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

            if ((DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngayld.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString())) && dngayld.IsEnabled)
            {
                MessageBox.Show("Ngày lắp đặt không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngayld.Focus();
                return;
            }

            if (DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(this.dngayhd.DateTime.ToShortDateString()))
            {
                MessageBox.Show("Ngày lắp đặt nhỏ hơn ngày hợp đồng không lưu dữ liệu được !");
                return;
               // dngayld.Focus();
               // return;
            }

            if (this.txtsdt.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbnhom.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || this.cmbxa.Text.Trim() == "" || cmbtuyen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {   
                EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                LoadOp = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text && t.ma_kh.Substring(0, 7) == App.batdau_mkh), LoadOpHD_Complete, true);
            }
        }


        
        void LoadOpHD_Complete(LoadOperation<ds_codinh> lo)
        { 
            if (lo.Entities.Count() > 0)
            {
                SaveData();
            }           
        }
            

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Clear_control();
            txtsdt.Text = "";
            txtsdt.Focus();
            enable_control(true);
            //this.TextLuu.Text = "Lưu";
            //this.PictureLuu.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/save-16x16.png", UriKind.RelativeOrAbsolute)); //"/SilverlightQLThuebao;component/Images/print-16x16.png";
            OKButton.IsEnabled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           this.DialogResult = false;                   
        }

        void SaveData()
        {
            Nullable<DateTime> m_ngayhd, m_ngaykn,m_ngayld,m_ngaycap;

            if (dngayhd.Text.Trim() != "")
                m_ngayhd = dngayhd.DateTime;
            else
                m_ngayhd = null;

            if (dngaykn.Text.Trim() != "")
                m_ngaykn = dngaykn.DateTime;
            else
                m_ngaykn = null;

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
                LoadOp.Entities.ElementAt(0).ma_kh=this.txtmakh.Text ;
                LoadOp.Entities.ElementAt(0).sohopdong =this.txtsohd.Text.Trim();
                LoadOp.Entities.ElementAt(0).ngay_hd = m_ngayhd;
                LoadOp.Entities.ElementAt(0).ten_dktb =this.txttentb.Text.Trim() ;
                LoadOp.Entities.ElementAt(0).ten_dkdb =this.txttendb.Text.Trim();
                LoadOp.Entities.ElementAt(0).dia_chitb=this.txtdctb.Text.Trim();
                LoadOp.Entities.ElementAt(0).dc_tbld =this.txtdcld.Text.Trim();
                LoadOp.Entities.ElementAt(0).tien_tb = this.txttientb.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientb.Text.Trim());
                LoadOp.Entities.ElementAt(0).tb_dv = this.txttbdv.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttbdv.Text.Trim());
                LoadOp.Entities.ElementAt(0).tienno = this.txttientbtk.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientbtk.Text.Trim());
                //LoadOp.Entities.ElementAt(0).khg_vat =this.cmbvtci.SelectedIndex ==0  ? false : true;
                LoadOp.Entities.ElementAt(0).socmnd =this.txtcmnd.Text.Trim();
                LoadOp.Entities.ElementAt(0).ngay_ld=m_ngayld;
                LoadOp.Entities.ElementAt(0).may_ngung = LoadOp.Entities.ElementAt(0).may_ngung.Trim()=="M" ? "D" : LoadOp.Entities.ElementAt(0).may_ngung.Trim();
                LoadOp.Entities.ElementAt(0).thangbd =this.txtthangbd.Text.ToString();
                LoadOp.Entities.ElementAt(0).noi_cap =this.txtnoicap.Text.Trim();                
                LoadOp.Entities.ElementAt(0).ngay_cap=m_ngaycap;
                LoadOp.Entities.ElementAt(0).tai_khoan =this.txttk.Text.Trim();
                LoadOp.Entities.ElementAt(0).ngan_hang=this.txtNH.Text.Trim();
                LoadOp.Entities.ElementAt(0).ms_thue =txtmst.Text.Trim()==""? "": FunAndPro.ma_st(this.txtmst.Text.Trim());
                if (dngaykn.Text.Trim()!="")
                LoadOp.Entities.ElementAt(0).ngay_kn=m_ngaykn;
                LoadOp.Entities.ElementAt(0).note_ngay_kn = this.txtghichu.Text.Trim();
                LoadOp.Entities.ElementAt(0).village = cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim();
                LoadOp.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim());
                LoadOp.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim());
                LoadOp.Entities.ElementAt(0).ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).ma_km = cmbkm.Text.Trim()=="" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString());
                LoadOp.Entities.ElementAt(0).tuyen_tc = cmbtuyen.Text.Trim();
                LoadOp.Entities.ElementAt(0).e_mail = txtemail.Text.Trim();
                LoadOp.Entities.ElementAt(0).dt_lh = this.txtdtlh.Text.Trim();
                LoadOp.Entities.ElementAt(0).camket = Convert.ToInt16(this.spcamket.Text);
                LoadOp.Entities.ElementAt(0).so_nha = App.sonha;
                LoadOp.Entities.ElementAt(0).duong = App.duong;
                LoadOp.Entities.ElementAt(0).xa_phuong = App.phuong;
                LoadOp.Entities.ElementAt(0).khom_ap = App.khom;
                LoadOp.Entities.ElementAt(0).so_nhald = App.sonhald;
                LoadOp.Entities.ElementAt(0).duongld = App.duongld;
                LoadOp.Entities.ElementAt(0).xa_phuongld = App.phuongld;
                LoadOp.Entities.ElementAt(0).khom_apld = App.khomld;
                LoadOp.Entities.ElementAt(0).loai_cap = cmbloaicap.SelectedIndex == -1 ? "" : cmbloaicap.GetKeyValue(cmbloaicap.SelectedIndex).ToString();
                LoadOp.Entities.ElementAt(0).slg_cap = Convert.ToInt16(this.spslcap.Text.Trim());
                LoadOp.Entities.ElementAt(0).goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();
                LoadOp.Entities.ElementAt(0).id_goicuoc = cmbgoith.SelectedIndex == -1 ? S_null : App.id_goicuoc;

                OKButton.IsEnabled = false;
               // dstb.Update_goi_cuoc_th(this.txtsdt.Text.Trim(), m_goi, m_id_goicuoc, l, ten, dc, App.User_name);
                codinh_log dsl = new codinh_log
                {
                    so_dt = this.txtsdt.Text.Trim(),
                    ten_dktb = this.txttentb.Text.Trim(),
                    ten_dkdb = this.txttendb.Text.Trim(),
                    dia_chitb = this.txtdctb.Text.Trim(),
                    dc_tbld = this.txtdcld.Text.Trim(),
                    tuyen_tc = cmbtuyen.Text.Trim(),
                    tien_tb = this.txttientb.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientb.Text.Trim()),
                    tb_dv = this.txttbdv.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttbdv.Text.Trim()),
                    tienno = this.txttientbtk.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientbtk.Text.Trim()),
                    //khg_vat = this.cmbvtci.SelectedIndex == 0 ? false : true,
                    ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString(),
                    pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString()),
                    may_ngung = LoadOp.Entities.ElementAt(0).may_ngung.Trim() == "M" ? "D" : LoadOp.Entities.ElementAt(0).may_ngung.Trim(),
                    ma_huyen = LoadOp.Entities.ElementAt(0).ma_huyen,
                    sohopdong = this.txtsohd.Text,
                    ngay_hd = m_ngayhd,
                    ngay_ld = m_ngayld,
                    village = cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim(),
                    ma_kh = this.txtmakh.Text,
                    ngay_kn = m_ngaykn,
                    note_ngay_kn = this.txtghichu.Text.Trim(),
                    ms_thue = txtmst.Text.Trim() == "" ? "" : FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = m_ngaycap,
                    e_mail = this.txtemail.Text.Trim(),
                    thoi_gian = App.Current_d,
                    ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    users = App.User_name,
                    dt_lh = this.txtdtlh.Text.Trim(),
                    so_nha = App.sonha,
                    so_nhald = App.sonhald,
                    goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim(),
                    id_goicuoc = cmbgoith.SelectedIndex == -1 ? S_null : App.id_goicuoc
                };

                idgoi = App.id_goicuoc;
                dstb.codinh_logs.Add(dsl);
               
                // xoa cac dich vu da dang ky va ghi lai dv da chon
                DeleteCompleted();
                //this.OKButton.IsEnabled = false;
                //this.btnNew.IsEnabled = true;
                //MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}",e));
            }
        }




        private void DeleteCompleted()
        { 
            if (LoadOpdv.Entities.Count() > 0)
            {
                dichvugiatang_log bm;
                for (int i = 0; i < LoadOpdv.Entities.Count(); i++)
                {
                    bm = LoadOpdv.Entities.ElementAt(i);
                    dstb.dichvugiatang_logs.Remove(bm);
                }                
            }
           // lo.Completed += new EventHandler(Lo_Completed());
            string dv = FunAndPro.GetSelectedKeyValue(cmbdvct, LoadOpdvgt.Entities.Count());            
            if (dv.Trim() != "")
            {
                string[] dva = dv.Split(';');
                foreach (string s in dva)
                {
                    dichvugiatang_log dvgt = new dichvugiatang_log
                    {
                        ngay = App.Current_d,
                        ma_dv = s,
                        so_dt = this.txtsdt.Text,
                        nguoi_mo = App.User_name,
                        don_vi = App.ma_huyen
                    };
                    dstb.dichvugiatang_logs.Add(dvgt);
                }                
            }
            dstb.SubmitChanges(OnSubmitCompleted,true);
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
               // this.txtsdt.Focus();
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

        private void dngayld_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            this.txtthangbd.Text = dngayld.DateTime.Month.ToString().PadLeft(2,'0') + dngayld.DateTime.Year.ToString();
            tienthuebao();
        }

        private void cmbdvct_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            string t = FunAndPro.GetSelectedKeyValue(cmbdvct, LoadOpdvgt.Entities.Count());
            string[] t1 = t.Split(';');
            int tien=0;
            foreach (string p in t1)
            {
                for (int i = 0; i < LoadOpdvgt.Entities.Count(); i++)
                {
                    if (LoadOpdvgt.Entities.ElementAt(i).ma_dv.Trim() == p.Trim())
                        tien += Convert.ToInt32(LoadOpdvgt.Entities.ElementAt(i).tien);
                }
            }
            this.txttbdv.Text=tien.ToString();
            if (Convert.ToInt32(txttbdv.Text.Trim()) > 0)
            {
                MessageBox.Show("Chu y ! tien thue bao dich vu >0 !");
            }
        }

        void tienthuebao()
        {
            if (m_tinhtb && m_tbmoi)
            {
                decimal tien = 0;
                if (this.cmbxa.EditValue != null && this.dngayld.DateTime != null && this.cmbnhom.EditValue != null)
                {
                    string xa = this.cmbxa.EditValue.ToString();
                    if (xa != "")
                    {
                        for (int i = 0; i < LoadOpxa.Entities.Count(); i++)
                        {
                            if (this.cmbxa.GetKeyValue(i).ToString().Trim() == xa)
                            {
                                tien = Convert.ToDecimal(LoadOpxa.Entities.ElementAt(i).tientb);
                            }
                        }
                    }

                    int songay = DateTime.DaysInMonth(this.dngayld.DateTime.Year, this.dngayld.DateTime.Month);
                    int ngay = songay- this.dngayld.DateTime.Day+1;                    
                    string pl = Getplkhachhang(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString());
                    if (tien > 0)
                    {
                        if (pl != "N")
                        {
                            decimal m_tien = (tien / songay) * ngay > tien ? tien : Math.Round((tien / songay) * ngay, 0);
                            this.txttientb.Text = (Math.Round(m_tien / 100, 0) * 100).ToString();
                            this.txttientbtk.Text = tien.ToString();
                        }
                        else
                        {
                            this.txttientb.Text = "0";
                            this.txttientbtk.Text = "0";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xem lại tiền thuê bao của xã");
                    }
                }
            }
        }

        private void cmbnhom_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            tienthuebao();
        }

        private void cmbxa_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            tienthuebao();
        }

        private void cmbvtci_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (txtsdt.Text.Trim() != "" && this.txtcmnd.Text.Trim() !="")
            {
                EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                LoadOp = dstb.Load(Query.Where(t => t.so_dt != this.txtsdt.Text.Trim() && t.socmnd.Trim() == this.txtcmnd.Text.Trim() && t.khg_vat == true), LoadOpCMND_Complete, null);
            }
        }

        private void LoadOpCMND_Complete(LoadOperation<ds_codinh> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Số CMND cho thuê bao này đã được hưởng VTCI");
                //cmbvtci.SelectedIndex = 0;
            }

        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            if (m_sdt != "")
            {
                if (m_loaiform == 1)
                {
                    frmdscodinh dscd = new frmdscodinh();
                    dscd.Width = this.ActualWidth;
                    dscd.Height = this.ActualHeight;
                    dscd.Show();
                    dscd.txttim.Text = m_sdt;
                }
                if (m_loaiform == 2)
                {
                    frmdsbdcodinh dscd = new frmdsbdcodinh();
                    dscd.Width = this.ActualWidth;
                    dscd.Height = this.ActualHeight;
                    dscd.Show();
                }

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

        private void dngayld_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngayld.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString())) && ! dngayld.IsReadOnly)
            {
                MessageBox.Show("Ngày lắp đặt không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngayld.Focus();
            }

            if (DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(this.dngayhd.DateTime.ToShortDateString()))
            {
                MessageBox.Show("Ngày lắp đặt nhỏ hơn ngày hợp đồng !");
               // dngayld.Focus();
               // return;
            }
        }

        private void txttentb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txttentb.Text.Trim() != "")
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

        private void cmbgoith_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (m_lan == false)
            {
                m_lan = true;
                return;
            }
            if (cmbgoith.SelectedIndex == -1 )           
                return;
          
            if (txtsdt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin !");
                return;
            }
            string m_goi = this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();

            if (m_goi != "" && idgoi=="")
            {
                for (int i = 0; i < LoadGoi.Entities.Count(); i++)
                {
                    if (LoadGoi.Entities.ElementAt(i).ma_goi.Trim() == m_goi)
                    {
                        Int32 sl = Convert.ToInt32(LoadGoi.Entities.ElementAt(i).sl_dd);
                        string so = txtsdt.Text.Trim();
                        string ten = txttentb.Text.Trim();
                        string dc = txtdctb.Text.Trim();
                        frmgoicuoc frm = new frmgoicuoc(sl, true, so, ten, dc, "C", m_goi, false, "");
                        frm.ShowDialog();
                    }
                }
            }
            if (idgoi != "")
            {
                frmgoicuoc frm = new frmgoicuoc(0, true, "", "", "", "", m_goi, false, idgoi);
                frm.ShowDialog();
            }
        }

        private void cmdview_Click(object sender, RoutedEventArgs e)
        {
            string m_goi = this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();
            if (idgoi != "")
            {
                frmgoicuoc frm = new frmgoicuoc(0, true, "", "", "", "", m_goi, false, idgoi);
                frm.ShowDialog();
            }
          
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

