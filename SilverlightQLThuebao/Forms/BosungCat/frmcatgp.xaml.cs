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
    public partial class frmcatgp : ChildWindow
    {
     //   private Action<System.ServiceModel.DomainServices.Client.LoadOperation<ds_codinh>> LoadOp_Complete = null;
        bool dcthuebao,dclapdat,m_trove;
        string m_sdt,mtrangthai;        
        frmdiachi frmdc;
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        LoadOperation<mlydocat> LoadOpcat;
        LoadOperation<loaikh> LoadOpkh;
        LoadOperation<nganh_nghe> LoadOpN;
        LoadOperation<tram_vt> LoadOptram;
        LoadOperation<maxas> LoadOpxa;
        LoadOperation<nv_thuethu> LoadOptuyen;
        LoadOperation<dichvugiatang> LoadOpdvgt;
        LoadOperation<dichvugiatang_log> LoadOpdv;
        LoadOperation<Gphone> LoadOp;
        int m_camket;
        public frmcatgp(string sdt,bool trove)
        {
            InitializeComponent();
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOptram = dstb.Load(Query.Where(t => App.ma_huyen.Contains(t.ma_huyen)).OrderBy(p => p.ten_tram), LoadOpT_Complete, null);
            //QLThuebaoDomainContext tramvt = new QLThuebaoDomainContext();
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
            EntityQuery<mlydocat> Querycat = dstb.GetLyDoCatTrimQuery();
            LoadOpcat = dstb.Load(Querycat.OrderBy(p => p.m_order), LoadOpCT_Complete, null);
            EntityQuery<loaikh> Queryloai = dstb.GetLoaikhQuery();
            LoadOpkh = dstb.Load(Queryloai, LoadOpKH_Complete, null);
            EntityQuery<nganh_nghe> QueryN = dstb.GetNganh_ngheQuery();
            LoadOpN = dstb.Load(QueryN, LoadOpN_Complete, null);
            EntityQuery<maxas> Queryxa = dstb.GetMaxasQuery();
            LoadOpxa = dstb.Load(Queryxa.Where(p=>p.ma_huyen==App.ma_huyen).OrderBy(p=>p.ten), LoadOpXA_Complete, null);
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpTT_Complete, null);
            //EntityQuery<dichvugiatang> Querydvgt = dstb.GetDichvugiatangsQuery();
            //LoadOpdvgt = dstb.Load(Querydvgt.OrderBy(p => p.ten_dv), LoadOpDV_Complete, null);
            this.txtsdt.MaxLength = App.len_sdt;           
            m_sdt = sdt;
            m_trove = trove;
            dngaycat.EditValue = App.Current_d;          
            mlydo.IsEnabled = false;
            Loaded += new RoutedEventHandler(frmeditgp_Loaded);  
            //frmdc = new frmdiachi();
            //frmdc.Closed += new EventHandler(frmdiachi_Closed);
            cmdLuu.IsEnabled = false;
           
        }

        void frmeditgp_Loaded(object sender, RoutedEventArgs e)
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

        //void LoadOpDV_Complete(LoadOperation<dichvugiatang> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        this.cmbdvct.ItemsSource = lo.Entities;
        //        this.cmbdvct.DisplayMember = ("ten_dv").Trim();
        //        this.cmbdvct.ValueMember = "ma_dv";
        //    }
        //}

        private void txtsdt_LostFocus(object sender, RoutedEventArgs e)
        {
            laythongtin();
        }

        void laythongtin()
        {
            Clear_control();
            if (this.txtsdt.Text.Length == App.len_sdt)
            {
                {
                    EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                    LoadOp = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text && t.ma_huyen == App.ma_huyen), LoadOp_Complete, null);
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
                this.txttendb.Text = lo.Entities.ElementAt(0).ten_dkdb == null ? "" : lo.Entities.ElementAt(0).ten_dkdb.Trim();
                this.txtdctb.Text = lo.Entities.ElementAt(0).dia_chitb.Trim();
                this.txtdcld.Text = lo.Entities.ElementAt(0).dc_tbld == null ? "" : lo.Entities.ElementAt(0).dc_tbld.Trim();
                this.txttientb.Text = lo.Entities.ElementAt(0).tien_tb == null ? "0" : lo.Entities.ElementAt(0).tien_tb.ToString();
                this.txttbdv.Text = lo.Entities.ElementAt(0).tb_dv == null ? "0" : lo.Entities.ElementAt(0).tb_dv.ToString();
                this.txttientbtk.Text = lo.Entities.ElementAt(0).tienno == null ? "0" : lo.Entities.ElementAt(0).tienno.ToString();
                this.cmbvtci.SelectedIndex = lo.Entities.ElementAt(0).khg_vat == null ? -1 : lo.Entities.ElementAt(0).khg_vat == false ? 0 : 1;
                this.txtsosim.Text = lo.Entities.ElementAt(0).SoSim == null ? "" : lo.Entities.ElementAt(0).SoSim.Trim();
                this.txtcmnd.Text = lo.Entities.ElementAt(0).socmnd == null ? "" : lo.Entities.ElementAt(0).socmnd.Trim();
                if (lo.Entities.ElementAt(0).ngay_ld.HasValue)  
                    this.dngayld.EditValue = lo.Entities.ElementAt(0).ngay_ld;
                this.txtthangbd.Text = lo.Entities.ElementAt(0).thangbd == null ? "" : lo.Entities.ElementAt(0).thangbd.ToString();
                this.txtnoicap.Text = lo.Entities.ElementAt(0).noi_cap == null ? "" : lo.Entities.ElementAt(0).noi_cap.Trim();
                if (lo.Entities.ElementAt(0).ngay_cap.HasValue)
                    this.dngaycap.EditValue = lo.Entities.ElementAt(0).ngay_cap;
                this.txttk.Text = lo.Entities.ElementAt(0).tai_khoan == null ? "" : lo.Entities.ElementAt(0).tai_khoan.Trim();
                this.txtNH.Text = lo.Entities.ElementAt(0).ngan_hang== null ? "" :lo.Entities.ElementAt(0).ngan_hang.Trim();
                this.txtmst.Text = lo.Entities.ElementAt(0).ms_thue == null ? "" : lo.Entities.ElementAt(0).ms_thue.Trim();
                if (lo.Entities.ElementAt(0).ngay_ngung.HasValue)
                    this.dngaycat.EditValue = lo.Entities.ElementAt(0).ngay_ngung;
                this.txttt.Text = lo.Entities.ElementAt(0).may_ngung == null ? "" : lo.Entities.ElementAt(0).may_ngung;
                mtrangthai = txttt.Text.Trim();                
                m_camket = Convert.ToInt16(lo.Entities.ElementAt(0).camket);
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
             
                //// lay danh sach dich vu cong them thue bao dang su dung danh dau check vao comboxbox cmbdvct

                //EntityQuery<dichvugiatang_log> Query = dstb.GetDichvugiatang_logQuery();
                //LoadOpdv = dstb.Load(Query.Where(t => t.so_dt.Trim() == this.txtsdt.Text), LoadOpDVG_Complete, null);
                          
            }
            else
            {               
                Clear_control();               
                OKButton.IsEnabled = true;
            }
        }

        //void LoadOpDVG_Complete(LoadOperation<dichvugiatang_log> lo)
        //{
        //    string dv = "";
        //    if (lo.Entities.Count() > 0)
        //    {
        //        for (int i = 0; i < lo.Entities.Count(); i++)                
        //            dv += lo.Entities.ElementAt(i).ma_dv.Trim() + ";";
        //        string[] dvct = dv.Split(';');
        //            foreach (string s in dvct)
        //            {
        //                foreach (var p in LoadOpdvgt.Entities)
        //                {
        //                    if (p.ma_dv.Trim() == s)
        //                        this.cmbdvct.SelectedItems.Add(p);

        //                }
        //            }
        //    }
        //}
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
            this.cmbloaitb.IsEnabled = enabled;
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
            this.txttentb.Text = "";
            this.txtdctb.Text = "";
            this.txtdcld.Text = "";
            this.txttendb.Text = "";
            this.txtsosim.Text = "";
            this.txtcmnd.Text = "";
            this.txtnoicap.Text = "";
            this.dngaycap.EditValue = null;
            this.dngayld.EditValue = null;
            this.cmbxa.SelectedIndex = -1;
            this.cmbtuyen.SelectedIndex = -1;
            this.txttientb.Text = "";
            this.txttbdv.Text = "";
            this.txttientbtk.Text = "";
            this.txtthangbd.Text = "";
            this.cmbvtci.SelectedIndex = -1;
            this.cmbtuyen.SelectedIndex = -1;
            this.txttk.Text = "";
            this.txtNH.Text = "";
            this.txtmst.Text = "";
            this.cmbloaitb.SelectedIndex = -1;
            this.cmbtramvt.EditValue=null;
            this.cmbhttt.EditValue = null;
            this.cmbkm.EditValue = null;
            this.cmbnhom.EditValue = null;
            this.cmbnganh.EditValue = null;
            this.dngaycat.EditValue = null;
            this.txttt.Text = "";
            this.cmbloaibd.SelectedIndex=-1;           
            this.mlydo.Text = "";          
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
            int m_camket = Convert.ToInt16(LoadOp.Entities.ElementAt(0).camket);
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
                

            if ((mlydo.IsEnabled == true && mlydo.Text.Trim() == "") || (cmbloaitb.SelectedIndex == -1) && (cmbloaibd.Text.Substring(0, 1) == "C" || cmbloaibd.Text.Substring(0, 1) == "N"))
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
                    MessageBoxResult result = MessageBox.Show("Muốn thanh lý hợp đồng và xóa thuê bao này ? ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        this.txttt.Text = "X";
                    }
                }
                else
                {
                    if (cmbloaitb.Text.Substring(0, 1) == "0")
                        tienthuebao();
                    else
                    {
                        this.txttientb.Text = "0";
                        this.txttientbtk.Text = "0";
                    }
                }
                cmdLuu.IsEnabled = true;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();            
            callF.GetDateTime();
            if (cmbloaibd.Text.Trim() == "")
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

            if (this.txtsdt.Text == "" || this.txttentb.Text == "" || this.txtdctb.Text == "" || this.txttendb.Text == "" || this.txtdcld.Text == "" || cmbtramvt.Text.Trim() == "" || cmbnhom.Text.Trim() == "" || cmbnganh.Text.Trim() == "" || this.txtcmnd.Text.Trim() == "" || this.cmbxa.Text.Trim() == "" || cmbtuyen.Text.Trim() == "" || cmbloaitb.SelectedIndex == -1 || cmbloaibd.Text.Trim()=="")
            {
                MessageBox.Show("Nhập chưa đủ dữ liệu");
            }
            else
            {
                EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                LoadOp = dstb.Load(Query.Where(t => t.so_dt == this.txtsdt.Text && t.ma_huyen == App.ma_huyen), LoadOpHD_Complete, null);           
            }
        }


        
        void LoadOpHD_Complete(LoadOperation<Gphone> lo)
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
                if (txttt.Text.Trim() != "X") // khong phai thanh ly thi update
                {
                    LoadOp.Entities.ElementAt(0).ma_kh=this.txtmakh.Text ;
                    LoadOp.Entities.ElementAt(0).sohopdong =this.txtsohd.Text.Trim();
                    LoadOp.Entities.ElementAt(0).ngay_hd=m_ngayhd;
                    LoadOp.Entities.ElementAt(0).ten_dktb =this.txttentb.Text.Trim() ;
                    LoadOp.Entities.ElementAt(0).ten_dkdb =this.txttendb.Text.Trim();
                    LoadOp.Entities.ElementAt(0).dia_chitb=this.txtdctb.Text.Trim();
                    LoadOp.Entities.ElementAt(0).dc_tbld =this.txtdcld.Text.Trim();
                    LoadOp.Entities.ElementAt(0).tien_tb = this.txttientb.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientb.Text.Trim());
                    LoadOp.Entities.ElementAt(0).tb_dv = this.txttbdv.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttbdv.Text.Trim());
                    LoadOp.Entities.ElementAt(0).tienno = this.txttientbtk.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txttientbtk.Text.Trim());
                    LoadOp.Entities.ElementAt(0).khg_vat =this.cmbvtci.SelectedIndex ==0  ? false : true;
                    LoadOp.Entities.ElementAt(0).SoSim= this.txtsosim.Text.Trim();
                    LoadOp.Entities.ElementAt(0).socmnd =this.txtcmnd.Text.Trim();
                    LoadOp.Entities.ElementAt(0).ngay_ld=m_ngayld;                    
                    LoadOp.Entities.ElementAt(0).thangbd =this.txtthangbd.Text.Trim();
                    LoadOp.Entities.ElementAt(0).noi_cap =this.txtnoicap.Text.Trim();
                    LoadOp.Entities.ElementAt(0).ngay_cap=m_ngaycap;
                    LoadOp.Entities.ElementAt(0).tai_khoan =this.txttk.Text.Trim();
                    LoadOp.Entities.ElementAt(0).ngan_hang=this.txtNH.Text.Trim();
                    LoadOp.Entities.ElementAt(0).ms_thue =FunAndPro.ma_st(this.txtmst.Text.Trim());
                    LoadOp.Entities.ElementAt(0).ngay_ngung=m_ngaycat;
                    LoadOp.Entities.ElementAt(0).may_ngung =this.txttt.Text.Trim();
                    LoadOp.Entities.ElementAt(0).thtb = false;
                    LoadOp.Entities.ElementAt(0).village =cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim();
                    LoadOp.Entities.ElementAt(0).tenkhkd = FunAndPro.KhongDau(this.txttentb.Text.Trim());
                    LoadOp.Entities.ElementAt(0).dckd = FunAndPro.KhongDau(this.txtdctb.Text.Trim());
                    LoadOp.Entities.ElementAt(0).ma_tram =cmbtramvt.GetKeyValue(cmbtramvt.SelectedIndex).ToString();
                    LoadOp.Entities.ElementAt(0).ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString();
                    //LoadOp.Entities.ElementAt(0).ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString();
                    //LoadOp.Entities.ElementAt(0).ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString();
                    //LoadOp.Entities.ElementAt(0).pl = Getplkhachhang(Convert.ToString(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex)).Trim());
                    LoadOp.Entities.ElementAt(0).tuyen_tc = cmbtuyen.Text.Trim();
                    LoadOp.Entities.ElementAt(0).loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0, 1)));
                    LoadOp.Entities.ElementAt(0).so_nha = App.sonha;
                    LoadOp.Entities.ElementAt(0).duong = App.duong;
                    LoadOp.Entities.ElementAt(0).xa_phuong = App.phuong;
                    LoadOp.Entities.ElementAt(0).khom_ap = App.khom;
                    LoadOp.Entities.ElementAt(0).so_nhald = App.sonhald;
                    LoadOp.Entities.ElementAt(0).duongld = App.duongld;
                    LoadOp.Entities.ElementAt(0).xa_phuongld = App.phuongld;
                    LoadOp.Entities.ElementAt(0).khom_apld = App.khomld;
                    Send_SMS();
                 }
                else
                {
                    if (LoadOp.Entities.Count() > 0) // xoa so dt khoi ds_codinh neu chon loai thanh ly hop dong
                    {
                        Gphone cd = LoadOp.Entities.First();
                        dstb.Gphones.Remove(cd);
                        // xoa cac dich vu da dang ky va ghi lai dv da chon
                      //  DeleteCompleted();
                    }
                }
                OKButton.IsEnabled = false; 
               
                Gphone_log dsl = new Gphone_log
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
                    khg_vat =this.cmbvtci.SelectedIndex ==0  ? false : true,
                    //pl = Getplkhachhang(Convert.ToString(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex)).Trim()),
                    may_ngung = this.txttt.Text.Trim(),
                    ma_huyen = App.ma_huyen,
                    sohopdong = this.txtsohd.Text,
                    ngay_hd = m_ngayhd,
                    ngay_ld=m_ngayld,
                    ngay_ngung=m_ngaycat,
                    village =cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim(),
                    ma_kh = this.txtmakh.Text,
                    ngay_kn = m_ngaycat,                    
                    ms_thue = FunAndPro.ma_st(this.txtmst.Text.Trim()),
                    socmnd = this.txtcmnd.Text.Trim(),
                    noi_cap = this.txtnoicap.Text.Trim(),
                    ngay_cap = m_ngaycap,                    
                    thoi_gian = App.Current_d,
                    ma_km = cmbkm.Text.Trim() == "" ? "0" : cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString(),
                   // ma_nhom = cmbnhom.GetKeyValue(cmbnhom.SelectedIndex).ToString(),
                    //ma_nghe = cmbnganh.GetKeyValue(cmbnganh.SelectedIndex).ToString(),                  
                    lydocat = mlydo.Text.Trim() == "" ? "" : mlydo.GetKeyValue(mlydo.SelectedIndex).ToString(),                    
                    loai_tb = Convert.ToBoolean(Convert.ToInt16(cmbloaitb.Text.Substring(0, 1))),
                    users = App.User_name,
                    so_nha = App.sonha,
                    so_nhald = App.sonhald
                };

                dstb.Gphone_logs.Add(dsl);
                dstb.SubmitChanges(OnSubmitCompleted, true);
               // dstb.SubmitChanges();              
                //this.OKButton.IsEnabled = false;
                //this.btnNew.IsEnabled = true;
                //MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}",e));
            }
        }

        //private void DeleteCompleted()
        //{   
        //    if (LoadOpdv.Entities.Count() > 0)
        //    {
        //        dichvugiatang_log bm;
        //        for (int i = 0; i < LoadOpdv.Entities.Count(); i++)
        //        {
        //            bm = LoadOpdv.Entities.ElementAt(i);
        //            dstb.dichvugiatang_logs.Remove(bm);
        //        }                
        //    }
        //   // lo.Completed += new EventHandler(Lo_Completed());
        //    string dv = FunAndPro.GetSelectedKeyValue(cmbdvct, LoadOpdvgt.Entities.Count());            
        //    if (dv.Trim() != "")
        //    {
        //        string[] dva = dv.Split(';');
        //        foreach (string s in dva)
        //        {
        //            dichvugiatang_log dvgt = new dichvugiatang_log
        //            {
        //                ngay = App.Current_d,
        //                ma_dv = s,
        //                so_dt = this.txtsdt.Text,
        //                nguoi_mo = App.User_name,
        //                don_vi = App.ma_huyen
        //            };
        //            dstb.dichvugiatang_logs.Add(dvgt);
        //        }                
        //    }
        //    dstb.SubmitChanges(OnSubmitCompleted,true);
        //}

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
                this.OKButton.IsEnabled = true;
                this.cmdLuu.IsEnabled = false;
                this.btnNew.IsEnabled = true;
               // this.txtsdt.Focus();
            }
        }

        void Send_SMS()
        {
            if (LoadOp.Entities.ElementAt(0).ma_nvcs != "" && LoadOp.Entities.ElementAt(0).ma_nvcs != null)
            {
                string m_db = ";" + LoadOp.Entities.ElementAt(0).ma_nvcs.ToString().Trim() + ";";
                EntityQuery<nhanvien_cs> Query = dstb.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOpS = dstb.Load(Query.Where(p => p.diaban.Trim().Contains(m_db) && p.ma_huyen == App.ma_huyen && p.kt == false), LoadOpSMSKD_Complete, null);
            }

            if (LoadOp.Entities.ElementAt(0).ma_nvkt != "" && LoadOp.Entities.ElementAt(0).ma_nvkt != null)
            {
                string m_db = ";" + LoadOp.Entities.ElementAt(0).ma_nvkt.ToString().Trim() + ";";
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
                    string mess = m_loai + txtsdt.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
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
                    string mess = m_loai + txtsdt.Text.Trim() + "-" + FunAndPro.KhongDau(this.txttentb.Text.Trim()) + "- " + FunAndPro.KhongDau(this.txtdcld.Text.Trim());
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

        //private void cmbdvct_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        //{
        //    string t = FunAndPro.GetSelectedKeyValue(cmbdvct, LoadOpdvgt.Entities.Count());
        //    string[] t1 = t.Split(';');
        //    int tien=0;
        //    foreach (string p in t1)
        //    {
        //        for (int i = 0; i < LoadOpdvgt.Entities.Count(); i++)
        //        {
        //            if (LoadOpdvgt.Entities.ElementAt(i).ma_dv.Trim() == p.Trim())
        //                tien += Convert.ToInt32(LoadOpdvgt.Entities.ElementAt(i).tien);
        //        }
        //    }
        //    this.txttbdv.Text=tien.ToString();
        //}

        void tienthuebao()
        {
            decimal tien = 0;
            decimal m_tien1 = 0;      
            if (this.cmbxa.EditValue != null && this.dngaycat.DateTime != null && this.cmbnhom.EditValue != null)
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

                int ngay = this.dngaycat.DateTime.Day;
                string pl = Getplkhachhang(Convert.ToString(cmbnhom.GetKeyValue(cmbnhom.SelectedIndex)).Trim());
                if (tien > 0)
                {
                    if (pl != "N")
                    {
                        if (cmbloaibd.Text.Substring(0, 1) == "C" || cmbloaibd.Text.Substring(0, 1) == "N") // cat may
                        {
                            decimal m_tien = (tien / 30) * ngay > tien ? tien : Math.Round((tien / 30) * ngay, 0);
                            if (mtrangthai == "S")
                                m_tien = m_tien / 2;   
                            this.txttientb.Text = (Math.Round(m_tien / 100, 0) * 100).ToString();
                            this.txttientbtk.Text = "0";
                        }
                        if (cmbloaibd.Text.Substring(0, 1) == "H") // hoat dong lai
                        {
                            decimal m_tien = (tien / 30) * (30 - ngay) > tien ? tien : Math.Round((tien / 30) * (30 - ngay), 0);
                            if (mtrangthai == "S")
                            {
                                m_tien1 = (tien / 30) * ngay > tien ? tien : Math.Round((tien / 30) * ngay, 0);
                                m_tien1 = m_tien / 2;
                            }
                            m_tien = m_tien + m_tien1;
                            this.txttientb.Text = (Math.Round(m_tien / 100, 0) * 100).ToString();
                            this.txttientbtk.Text = tien.ToString();
                        }
                        if (cmbloaibd.Text.Substring(0, 1) == "S") // Ngưng 1 chieu
                        {
                            decimal m_tien = (tien / 30) * ngay > tien ? tien : Math.Round((tien / 30) * ngay, 0);
                            m_tien += Math.Round(((tien / 2) / 30) * (30 - ngay), 0);
                            this.txttientb.Text = (Math.Round(m_tien / 100, 0) * 100).ToString();
                            this.txttientbtk.Text = (tien / 2).ToString();
                        }
                    }
                    else
                    {
                        this.txttientb.Text = "0";
                        this.txttientbtk.Text = "0";
                    }
                    this.txttt.Text = cmbloaibd.Text.Substring(0, 1);
                    this.txtthangbd.Text = dngaycat.DateTime.Month.ToString().PadLeft(2, '0') + dngaycat.DateTime.Year.ToString();
                }
                else
                {
                    MessageBox.Show("Xem lại tiền thuê bao của xã");
                }
            }

        }
     
        private void cmbvtci_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (txtsdt.Text.Trim() != "" && this.txtcmnd.Text.Trim() != "")
            {
                EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                LoadOp = dstb.Load(Query.Where(t => t.so_dt != this.txtsdt.Text && t.socmnd.Trim() == this.txtcmnd.Text.Trim() && t.khg_vat == true), LoadOpCMND_Complete, null);
            }
        }

        private void LoadOpCMND_Complete(LoadOperation<Gphone> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Số CMND cho thuê bao này đã được hưởng VTCI");
                cmbvtci.SelectedIndex = 0;
            }
           
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            if (m_trove)
            {
                frmdsgphone dsgp = new frmdsgphone();
                dsgp.Width = this.ActualWidth;
                dsgp.Height = this.ActualHeight;
                dsgp.Show();
                dsgp.txttim.Text = m_sdt;
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

        private void dngaycat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DateTime.Parse(dngaycat.DateTime.ToShortDateString()) < DateTime.Parse(App.Min_Date.ToShortDateString()) || DateTime.Parse(dngaycat.DateTime.ToShortDateString()) > DateTime.Parse(App.Current_d.ToShortDateString()))
            {
                MessageBox.Show("Ngày cắt, ngưng, thanh lý không được nhỏ hơn 2 ngày hoặc lớn hơn so với ngày hiện tại !");
                dngaycat.Focus();               
            }
        }

        private void cmbloaibd_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            dngaycat.EditValue = App.Current_d;
            if (cmbloaibd.SelectedIndex == -1) return;
            string chuoi = "C.N.S.X";
            if (chuoi.Contains(cmbloaibd.Text.Substring(0, 1)))
            {
                mlydo.IsEnabled = true;
            }
            else
                mlydo.IsEnabled = false;
        }

      
    }
}

