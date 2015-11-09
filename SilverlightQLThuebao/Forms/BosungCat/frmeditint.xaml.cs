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
    public partial class frmeditint : ChildWindow
    {
        bool dcthuebao, dclapdat, m_lan;
        string m_usr,gc,m_dv,m_dichvu;
        string loaidv,so_119c,so_119;
        string m_may_ngung, idgoi;
        string S_null;
        frmdiachi frmdc;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<GoiCuoc> LoadOpgc;
        LoadOperation<loai_dv> LoadOpdv;
        LoadOperation<TocDo> LoadOptd;
        LoadOperation<KhachHangUuTien> LoadOput;
        LoadOperation<tram_vt> LoadOp;
        LoadOperation<nv_thuethu> LoadOptuyen;
        LoadOperation<internet> LoadOpMy;
        LoadOperation<Mdiaban> LoadOpCB;
        LoadOperation<Mdiaban> LoadOpCBKT;
        LoadOperation<chungloaicap> LoadOpcap;
        LoadOperation<thiet_bi> LoadOptb;
        LoadOperation<Goi_th> LoadGoi;

        public frmeditint(string usr)
        {
            InitializeComponent();
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOp = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p => p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN.OrderBy(p => p.ten_nghe), LoadOpN_Complete, null);
            EntityQuery<loai_dv> Queryloaidv = dstb.GetLoai_dvQuery();
            LoadOpdv = dstb.Load(Queryloaidv, LoadOpDV_Complete, null);
            EntityQuery<KhachHangUuTien> Queryut = dstb.GetKhachHangUuTienTrimQuery();
            LoadOput = dstb.Load(Queryut.OrderBy(p => p.kh_uutien1), LoadOpUT_Complete, null);
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpTT_Complete, null);
            EntityQuery<Mdiaban> QueryNV = dstb.GetMadiabanTrimQuery();
            LoadOpCB = dstb.Load(QueryNV.Where(p => p.ma_huyen == App.ma_huyen && p.kt == false).OrderBy(p => p.ten_tuyen), LoadOpCB_Complete, null);
            EntityQuery<Mdiaban> QueryNVKT = dstb.GetMadiabanTrimQuery();
            LoadOpCBKT = dstb.Load(QueryNVKT.Where(p => p.ma_huyen == App.ma_huyen && p.kt == true).OrderBy(p => p.ten_tuyen), LoadOpCBKT_Complete, null);
            EntityQuery<chungloaicap> Querycap = dstb.GetChungloaicapsQuery();
            LoadOpcap = dstb.Load(Querycap.Where(p => p.dv == "I").OrderBy(p => p.ten_loai), LoadOpCAP_Complete, null);
            EntityQuery<thiet_bi> Querytb = dstb.GetThiet_bisQuery();
            LoadOptb = dstb.Load(Querytb.OrderBy(p => p.ten_tb), LoadOpTB_Complete, null);
            EntityQuery<Goi_th> QueryG = dstb.GetGoi_thQuery();
            LoadGoi = dstb.Load(QueryG.OrderBy(p => p.ten_goi), LoadOpG_Complete, null);
            //this.txtsdt.MaxLength = App.len_sdt;
            m_usr = usr;
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

        void LoadOpCAP_Complete(LoadOperation<chungloaicap> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbloaicap.DisplayMember = ("ten_loai").Trim();
                this.cmbloaicap.ValueMember = "loai_cap";
                this.cmbloaicap.ItemsSource = lo.Entities;

            }
        }

        void LoadOpTB_Complete(LoadOperation<thiet_bi> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbloaitb.DisplayMember = ("ten_tb").Trim();
                this.cmbloaitb.ValueMember = "ma_tb";
                this.cmbloaitb.ItemsSource = lo.Entities;

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

        private void txtusr_LostFocus(object sender, RoutedEventArgs e)
        {
            m_lan = false;
            App.id_goicuoc = null;
            laythongtin();
         
        }

        void laythongtin()
        {
            if (this.txtusr.Text.Length > 0)
            {
                {
                    EntityQuery<internet> Query = dstb.GetInternetsQuery();
                    LoadOperation<internet> LoadOp = dstb.Load(Query.Where(p => p.user_name.Trim() == this.txtusr.Text.Trim() && p.ma_kh.Substring(0, 7) == App.batdau_mkh), LoadOp_Complete, null);
                }
            }
        }
        void LoadOp_Complete(LoadOperation<internet> lo)
        {            
            if (lo.Entities.Count() > 0)
            {
                //v_update = true;
                OKButton.IsEnabled = true;
                cmdview.IsEnabled = true;
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
                m_may_ngung = lo.Entities.ElementAt(0).may_ngung.Trim();
                if (lo.Entities.ElementAt(0).ngay_ld.HasValue)
                {
                     this.dngayld.EditValue = lo.Entities.ElementAt(0).ngay_ld;
                     dngayld.IsEnabled = false;
                }
                else
                    dngayld.IsEnabled = true;
                App.m_phuong = lo.Entities.ElementAt(0).maxa == null ? "" : lo.Entities.ElementAt(0).maxa.Trim();
                this.txtsdt.Text = lo.Entities.ElementAt(0).so_dt == null ? "" : lo.Entities.ElementAt(0).so_dt.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                if (lo.Entities.ElementAt(0).ngay_cap.HasValue)
                this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;
                this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                this.txtNH.Text = lo.Entities.ElementAt(0).ngan_hang== null ? "" :lo.Entities.ElementAt(0).ngan_hang.Trim();
                this.txtmst.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                if (lo.Entities.ElementAt(0).ngay_kn.HasValue)
                this.dngaykn.EditValue = lo.Entities.ElementAt(0).ngay_kn;
                this.txtghichu.Text = lo.Entities.ElementAt(0).note_ngay_kn == null ? "" : lo.Entities.ElementAt(0).note_ngay_kn.Trim();
                this.txtemail.Text = lo.Entities.ElementAt(0).e_mail == null ? "" : lo.Entities.ElementAt(0).e_mail.Trim();
                this.txtdtlh.Text = lo.Entities.ElementAt(0).dt_lh == null ? "" : lo.Entities.ElementAt(0).dt_lh.ToString();
                this.spcamket.Text = lo.Entities.ElementAt(0).camket == null ? "0" : lo.Entities.ElementAt(0).camket.ToString();
                loaidv = lo.Entities.ElementAt(0).ma_dv == null ? "" : lo.Entities.ElementAt(0).ma_dv.Trim();
                this.txtseri.Text = lo.Entities.ElementAt(0).modem_seri == null ? "" : lo.Entities.ElementAt(0).modem_seri.Trim();
                this.spslcap.Text = lo.Entities.ElementAt(0).slg_cap == null ? "0" : lo.Entities.ElementAt(0).slg_cap.ToString().Trim();
                idgoi = lo.Entities.ElementAt(0).id_goicuoc == null ? "" : lo.Entities.ElementAt(0).id_goicuoc.Trim();
                App.id_goicuoc = idgoi==""? S_null: idgoi;
                so_119c=lo.Entities.ElementAt(0).so_119 == null ? "" : lo.Entities.ElementAt(0).so_119.ToString().Trim();
                so_119 = so_119c;
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

                string loaicap = lo.Entities.ElementAt(0).loai_cap == null ? "" : lo.Entities.ElementAt(0).loai_cap.Trim();
                if (loaicap != "")
                {
                    for (int i = 0; i < LoadOpcap.Entities.Count(); i++)
                    {
                        if (this.cmbloaicap.GetKeyValue(i).ToString().Trim() == loaicap)
                        {
                            this.cmbloaicap.SelectedIndex = i;
                        }
                    }                  
                }
                else
                    this.cmbloaicap.SelectedIndex = -1;

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

                //string m_nvld = lo.Entities.ElementAt(0).ma_nvld == null ? "" : lo.Entities.ElementAt(0).ma_nvld.Trim();

                //if (m_nvld != "")
                //{
                //    for (int i = 0; i < LoadOpCBKT.Entities.Count(); i++)
                //    {
                //        if (this.cmbcbld.GetKeyValue(i).ToString().Trim() == m_nvld)
                //        {
                //            this.cmbcbld.SelectedIndex = i;
                //            break;
                //        }
                //    }
                //}
                //else
                //    this.cmbcbld.SelectedIndex = -1;

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

                string m_tb = lo.Entities.ElementAt(0).loai_tb == null ? "" : lo.Entities.ElementAt(0).loai_tb.Trim();

                if (m_tb != "")
                {
                    for (int i = 0; i < LoadOptb.Entities.Count(); i++)
                    {
                        if (this.cmbloaitb.GetKeyValue(i).ToString().Trim() == m_tb)
                        {
                            this.cmbloaitb.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                    this.cmbloaitb.SelectedIndex = -1;
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


                m_lan = true;
                // this.textalert.Text = lo.Entities.ElementAt(0).fullname;
       
                        
            }
            else
            {               
                Clear_control();
               // enable_control(true);                
                OKButton.IsEnabled = false;
                cmdview.IsEnabled = false;
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
            this.txtNH.IsEnabled = enabled;
            this.txtmst.IsEnabled = enabled;
            this.cmbkhuutien.IsEnabled = enabled;
            this.cmbtramvt.IsEnabled = enabled;
            this.cmbcbcs.IsEnabled = enabled;
            this.cmbcbkt.IsEnabled = enabled;
           // this.cmbcbld.IsEnabled = enabled;
            this.cmbhttt.IsEnabled = enabled;
           // this.cmbkm.IsEnabled = enabled;
            this.cmbnhom.IsEnabled = enabled;
            this.cmbnganh.IsEnabled = enabled;
            this.dngaykn.IsEnabled = enabled;
            this.spcamket.IsEnabled = enabled;
            this.txtdtlh.IsEnabled = enabled;
            if (enabled)
                this.txtghichu.IsReadOnly = false;
            else
                this.txtghichu.IsReadOnly = true;
            this.txtemail.IsEnabled = enabled;
            this.txtseri.IsEnabled = enabled;
            this.spslcap.IsEnabled = enabled;
            this.cmbgoith.IsEnabled = enabled;
        }

        void Clear_control()
        {
            this.txtmakh.Text = "";
            this.txtsohd.Text = "";
            this.dngayhd.EditValue = null;
            this.cmbgoicuoc.SelectedIndex = -1;
            this.cmbtocdo.SelectedIndex = -1;
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
            this.txtNH.Text = "";
            this.txtmst.Text = "";
            this.cmbkhuutien.Text = "";
            this.cmbtramvt.EditValue=null;
            this.cmbhttt.EditValue = null;
            this.cmbkm.EditValue = null;
            this.cmbnhom.EditValue = null;
            this.cmbnganh.EditValue = null;
            this.cmbtuyen.SelectedIndex = -1;
            this.cmbcbcs.SelectedIndex = -1;
            this.cmbcbkt.SelectedIndex = -1;
           // this.cmbcbld.SelectedIndex = -1;
            this.cmbgoith.SelectedIndex = -1;
            this.dngaykn.EditValue = null;
            this.dngayld.EditValue = null;
            this.txtghichu.Text = "";
            this.txtemail.Text = "";
            this.txtdtlh.Text = "";
            this.spcamket.Text = "0";
            this.txtseri.Text = "";
            this.cmbloaicap.SelectedIndex = -1;
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
            //if (m_may_ngung == "M" && txtseri.Text.Trim() == "")
            //{
            //    MessageBox.Show("Chưa nhập vào số seri thiết bị lắp đặt !");
            //    txtseri.Focus();
            //}

            if (cmbhtld.Text.Substring(0, 1) == "1" && txtsdt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập vào số điện thoại lắp chung");
                return;
            }

            if ((DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngayld.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString())) && dngayld.IsEnabled)
            {
                MessageBox.Show("Ngày lắp đặt không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngayld.Focus();
            }

            if (DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(this.dngayhd.DateTime.ToShortDateString()))
            {
                MessageBox.Show("Ngày lắp đặt nhỏ hơn ngày hợp đồng không lưu dữ liệu được !");
                return;
               // dngayld.Focus();
              //  return;
            }

            if (this.txtusr.Text == "" || this.cmbgoicuoc.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbtocdo.Text.Trim()=="" || cmbkhuutien.Text.Trim()=="" || cmbnhom.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || cmbhtld.Text.Trim()=="" || cmbkm.Text.Trim()=="")
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                EntityQuery<internet> Query = dstb.GetInternetsQuery();
                LoadOpMy = dstb.Load(Query.Where(t => t.user_name == this.txtusr.Text.Trim() && t.ma_kh.Substring(0, 7) == App.batdau_mkh), LoadOpHD_Complete, null);
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
            Nullable<DateTime> m_ngayhd, m_ngaykn, m_ngayld, m_ngaycap;

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
                // get_hopdong(App.ma_huyen + "/" + this.dngayhd.DateTime.Year.ToString().Substring(2, 2));                
                    
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
                LoadOpMy.Entities.ElementAt(0).toc_do= cmbtocdo.GetKeyValue(cmbtocdo.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ma_dv = cmbdichvu.GetKeyValue(cmbdichvu.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ht_ld = cmbhtld.Text.Trim().Substring(0, 1);                
                LoadOpMy.Entities.ElementAt(0).socmnd = txtcmnd.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).noi_cap = txtnoicap.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).ngay_cap = m_ngaycap;
                LoadOpMy.Entities.ElementAt(0).ma_kh = txtmakh.Text;
                LoadOpMy.Entities.ElementAt(0).ma_tram = cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).kh_uutien = cmbkhuutien.SelectedIndex==-1 ? "" : cmbkhuutien.GetKeyValue(cmbkhuutien.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).may_ngung = LoadOpMy.Entities.ElementAt(0).may_ngung.Trim() == "M" ? "D" : LoadOpMy.Entities.ElementAt(0).may_ngung.Trim();
                LoadOpMy.Entities.ElementAt(0).ngay_kn = m_ngaykn;
                LoadOpMy.Entities.ElementAt(0).note_ngay_kn = txtghichu.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(txttentb.Text.Trim());
                LoadOpMy.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(txtdctb.Text.Trim());
                LoadOpMy.Entities.ElementAt(0).ms_thue =txtmst.Text.Trim()==""? "": FunAndPro.ma_st(txtmst.Text.Trim());
                LoadOpMy.Entities.ElementAt(0).duong = App.duong;
                LoadOpMy.Entities.ElementAt(0).xa_phuong = App.phuong;
                LoadOpMy.Entities.ElementAt(0).khom_ap = App.khom;
                LoadOpMy.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString();
                //LoadOpMy.Entities.ElementAt(0).ma_nvld = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbld.GetKeyValue(cmbcbld.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).ngan_hang = txtNH.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).e_mail = txtemail.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).dt_lh = this.txtdtlh.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).camket = Convert.ToInt16(this.spcamket.Text);
                LoadOpMy.Entities.ElementAt(0).maxa = App.m_phuong;
                LoadOpMy.Entities.ElementAt(0).loai_cap=cmbloaicap.SelectedIndex == -1 ? "" : cmbloaicap.GetKeyValue(cmbloaicap.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).slg_cap = Convert.ToInt16(this.spslcap.Text.Trim());
                LoadOpMy.Entities.ElementAt(0).modem_seri = this.txtseri.Text.Trim();
                LoadOpMy.Entities.ElementAt(0).loai_tb = cmbloaitb.Text.Trim() == "" ? "" : cmbloaitb.GetKeyValue(cmbloaitb.SelectedIndex).ToString();
                LoadOpMy.Entities.ElementAt(0).so_119= so_119;
                LoadOpMy.Entities.ElementAt(0).goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();
                LoadOpMy.Entities.ElementAt(0).id_goicuoc = cmbgoith.SelectedIndex == -1 ? S_null : App.id_goicuoc;


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
                    ht_ld = this.cmbhtld.Text.Trim().Substring(0, 1),
                    ma_huyen = LoadOpMy.Entities.ElementAt(0).ma_huyen,
                    socmnd = this.txtcmnd.Text.Trim(),
                    may_ngung=LoadOpMy.Entities.ElementAt(0).may_ngung.Trim() == "M" ? "D" : LoadOpMy.Entities.ElementAt(0).may_ngung.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = m_ngaycap,
                    ma_kh = this.txtmakh.Text.Trim(),                    
                    ngay_kn = m_ngaykn,
                    note_ngay_kn = this.txtghichu.Text.Trim(),
                    ms_thue = txtmst.Text.Trim() == "" ? "" : FunAndPro.ma_st(txtmst.Text.Trim()),
                    ngan_hang = this.txtNH.Text.Trim(),
                    ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                    ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),
                    camket = Convert.ToInt16(this.spcamket.Text),
                    ma_nvcs = cmbcbcs.SelectedIndex == -1 ? S_null : cmbcbcs.GetKeyValue(cmbcbcs.SelectedIndex).ToString(),
                    ma_nvkt = cmbcbkt.SelectedIndex == -1 ? S_null : cmbcbkt.GetKeyValue(cmbcbkt.SelectedIndex).ToString(),
                    //ma_nvld = cmbcbld.SelectedIndex == -1 ? "" : cmbcbld.GetKeyValue(cmbcbld.SelectedIndex).ToString(),
                    kh_uutien = cmbkhuutien.SelectedIndex==-1 ? "" : cmbkhuutien.GetKeyValue(cmbkhuutien.SelectedIndex).ToString(),
                    user_login = App.User_name,
                    thoi_gian = App.Current_d,
                    dt_lh = this.txtdtlh.Text.Trim(),
                    loai_cap=cmbloaicap.SelectedIndex == -1 ? "" : cmbloaicap.GetKeyValue(cmbloaicap.SelectedIndex).ToString(),
                    slg_cap = Convert.ToInt16(this.spslcap.Text.Trim()),
                    modem_seri = this.txtseri.Text.Trim(),
                    goi_th = cmbgoith.SelectedIndex == -1 ? S_null : this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim(),
                    id_goicuoc = cmbgoith.SelectedIndex == -1 ? S_null : App.id_goicuoc              

                };
                idgoi = App.id_goicuoc;
                dstb.internet_logs.Add(dsl);
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
            if (m_dv != "" && m_dv !="1260" && m_dv !=loaidv)
            {
                MessageBoxResult result = MessageBox.Show("Đổi loại dịch vụ sẽ đổi luôn mã báo hỏng 119 ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    OKButton.IsEnabled = false;
                    if (cmbdichvu.GetKeyValue(cmbdichvu.SelectedIndex).ToString().Trim() == "ADSL")
                        m_dichvu = "1";
                    else
                        m_dichvu = "2";
                    EntityQuery<maxmakhachhang> Query = dstb.Get119intQuery(App.batdau_119 + m_dichvu);
                    LoadOperation<maxmakhachhang> LoadOp = dstb.Load(Query, LoadOp119_Complete, null);   
                }
            }
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
            so_119 = App.batdau_119 + m_dichvu + temps.PadLeft(5, '0');
            this.label1.Content = "Số báo 119: " + so_119c + " được đổi thành: " + so_119;
            OKButton.IsEnabled = true;
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

        private void dngayld_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngayld.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString())) && !dngayld.IsReadOnly)
            {
                MessageBox.Show("Ngày lắp đặt không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngayld.Focus();
            }
            if (DateTime.Parse(dngayld.DateTime.ToShortDateString()) < DateTime.Parse(this.dngayhd.DateTime.ToShortDateString()))
            {
                MessageBox.Show("Ngày lắp đặt nhỏ hơn ngày hợp đồng !");
                //dngayld.Focus();
                //return;
            }
        }

        private void txtsdt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtsdt.Text.Trim().Length > 0 && txtsdt.Text.Trim().Length <7)
            {
                MessageBox.Show("Nhập số điện thoại sai định dạng ! (vd:3855090)");
            }
            else
            {
                EntityQuery<internet> Query = dstb.GetInternetsQuery();
                LoadOperation<internet> Loads = dstb.Load(Query.Where(p => p.so_dt.Trim() == txtsdt.Text.Trim() && p.user_name.Trim() != txtusr.Text.Trim()), LoadOpSDT_Complete, null);
            }
        }
        void LoadOpSDT_Complete(LoadOperation<internet> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Số điện thoại này đã lắp chung với account :" + lo.Entities.ElementAt(0).user_name);
                txtsdt.Focus();
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
            if (cmbgoith.SelectedIndex == -1)
                return;

            if (txtusr.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin !");
                return;
            }
            string m_goi = this.cmbgoith.GetKeyValue(cmbgoith.SelectedIndex).ToString().Trim();

            if (m_goi != "" && idgoi == "")
            {
                for (int i = 0; i < LoadGoi.Entities.Count(); i++)
                {
                    if (LoadGoi.Entities.ElementAt(i).ma_goi.Trim() == m_goi)
                    {
                        Int32 sl = Convert.ToInt32(LoadGoi.Entities.ElementAt(i).sl_dd);
                        string so = txtusr.Text.Trim();
                        string ten = txttentb.Text.Trim();
                        string dc = txtdctb.Text.Trim();
                        frmgoicuoc frm = new frmgoicuoc(sl, true, so, ten, dc, "I", m_goi, false, "");
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
