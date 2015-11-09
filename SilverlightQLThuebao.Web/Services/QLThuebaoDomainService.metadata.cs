
namespace SilverlightQLThuebao.Web.Models
{
    using System;
    using System.Data;
    using System.Data.Objects.DataClasses;
    using System.Data.EntityClient;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;

    public class maxmakhachhang
    {
        [Key]
        public string maxmakh { get; set; }
    }
    public class maxmakhachhangs
    {
        [Key]
        public decimal maxmakh { get; set; }
    }

    public class manvcs
    {
        [Key]
        public string ma_nvcs { get; set; }
    }

    public class BSCT
    {
        public string  ten_vien_canh { get; set; }

        public string  ten_kpos { get; set; }       
       
         [Key]
        public string ma_kpi { get; set; }

        public string ten_kpi { get; set; }

        public string dvt { get; set; }

        public string loai_dvt { get; set; }

        public bool check { get; set; }

        public Nullable<int> sap_xep { get; set; }

        public Nullable<bool> tonghop { get; set; }

        public Nullable<double> trongso { get; set; }

        public Nullable<double> chitieugiao { get; set; }

        public Nullable<double> chitieuth { get; set; }  

        public Nullable<double> ty_trong_thuc_hien { get; set; }

        public string ten_kpo { get; set; }    

      

      
    }

    //public class BSCT_temp
    //{
    //    public string ten_vien_canh { get; set; }

    //    public string ten_kpos { get; set; }
    //    [Key]
    //    public decimal id { get; set; }

    //    public string ma_kpis { get; set; }

    //    public string ten_kpis { get; set; }

    //    public string dvt { get; set; }

    //    public string loai_dvt { get; set; }

    //    public bool check { get; set; }

    //    public Nullable<int> sap_xep { get; set; }

    //    public Nullable<bool> tonghop { get; set; }

        
    //}
   

    public class matram
    {        
        [Key]
        public int id { get; set; }

        public string ma_tram { get; set; }
    }     

    public class loaikh
    {
        [Key]
        public int id { get; set; }

        public string maloai { get; set; }

        public string ma_nghe { get; set; }

        public string mota { get; set; }

        public string pl { get; set; }
    }
    public class khmai
    {
        [Key]
        public string ma_km { get; set; }

        public Nullable<DateTime> ngay_bd { get; set; }

        public Nullable<DateTime> ngay_kt { get; set; }

        public string ten_ct { get; set; }

        public Nullable<bool> hieu_luc { get; set; }
    }
    public class mlydocat
    {
        [Key]
        public string ma_ld { get; set; }

        public string ten_ld { get; set; }

        public string loai { get; set; }

        public int m_order { get; set; }
    }
    public class loaicatmo
    {
        [Key]
        public decimal id { get; set; }

        public string ma_yc { get; set; }

        public string ten_yc { get; set; }
    }

    public class maxas
    {
        [Key]
        public decimal id { get; set; }

        public string ma_huyen { get; set; }

        public string maxa { get; set; }

        public string ten { get; set; }

        public Nullable<decimal> tientb { get; set; }

        public bool vtci { get; set; }
    }

    public class SLGanDB
    {
        [Key]
        public decimal id { get; set; }

        public string ma_huyen { get; set; }

        public string ma_nv { get; set; }

        public string ma_tuyen { get; set; }

        public Nullable<int> soluong { get; set; }

        public Nullable<int> soluongcd { get; set; }

        public Nullable<int> soluonggp { get; set; }

        public Nullable<int> soluongint { get; set; }

        public Nullable<int> soluongftth { get; set; }

        public Nullable<int> soluongmy { get; set; }

        public Nullable<decimal> tien { get; set; }

        public Nullable<decimal> tiencd { get; set; }

        public Nullable<decimal> tiengp { get; set; }

        public Nullable<decimal> tienint { get; set; }

        public Nullable<decimal> tienftth { get; set; }

        public Nullable<decimal> tienmy { get; set; }

        public string thang{ get; set; }

        public string ten_nv { get; set; }

        public string ten_tuyen { get; set; }
    }

    public class ds119s
    {
        [Key]
        
        public string user_name { get; set; }

        public string so_dt { get; set; }

        public string ten_dktb { get; set; }

        public string dc_tbld { get; set; }

        public string ma_huyen { get; set; }

    }

    public class tuyencskhs
    {
        public string so_dt { get; set; }

        public string ma_kh { get; set; }

        public string ten_dktb { get; set; }

        public string ten_dkdb { get; set; }

        public string dia_chitb { get; set; }

        public string dc_tbld { get; set; }

        public string ma_tram { get; set; }

        public string ma_nvcs { get; set; }

        public string ma_nvkt { get; set; }       

    }

    public class tuyen
    {
        [Key]
        public string so_dt { get; set; }

        public string ma_kh { get; set; }

        public string ten_dktb { get; set; }

        public string ten_dkdb { get; set; }

        public string dia_chitb { get; set; }

        public string dc_tbld { get; set; } 

        public string tuyen_tc { get; set; }

        public string loai { get; set; }

        public Nullable<decimal> stt { get; set; }
    }

    public class Mdiaban
    {
        public Nullable<bool> kt { get; set; }

        public string ma_huyen { get; set; }
        [Key]
        public string ma_tuyen { get; set; }

        public string ten_tuyen { get; set; }
    }

    public class DSCD
    {
        public Nullable<decimal> cuoc { get; set; }

        public Nullable<bool> dau { get; set; }

        public string dc_tbld { get; set; }

        public string dckd { get; set; }

        public string dia_chitb { get; set; }

        public string duong { get; set; }

        public string e_mail { get; set; }

        public Nullable<bool> inct { get; set; }

        public Nullable<bool> keo_may { get; set; }

        public Nullable<bool> khg_vat { get; set; }

        public string khom_ap { get; set; }

        public string ma_huyen { get; set; }

        public string ma_kh { get; set; }

        public string ma_km { get; set; }

        public string ma_nghe { get; set; }

        public string ma_nhom { get; set; }

        public string ma_tram { get; set; }

        public string may_ngung { get; set; }

        public Nullable<bool> mo_may { get; set; }

        public string ms_thue { get; set; }

        public string ngan_hang { get; set; }

        public Nullable<DateTime> ngay { get; set; }

        public Nullable<DateTime> ngay_cap { get; set; }

        public Nullable<DateTime> ngay_hd { get; set; }

        public Nullable<DateTime> ngay_kn { get; set; }

        public Nullable<DateTime> ngay_ld { get; set; }

        public Nullable<DateTime> ngay_mo { get; set; }

        public Nullable<DateTime> ngay_ngung { get; set; }

        public string noi_cap { get; set; }

        public string note_ngay_kn { get; set; }

        public string pl { get; set; }
        [Key]

        public string so_dt { get; set; }

        public string socmnd { get; set; }

        public string sohopdong { get; set; }

        public Nullable<decimal> stt { get; set; }

        public string tai_khoan { get; set; }

        public Nullable<decimal> tb_dv { get; set; }

        public Nullable<bool> tbdc { get; set; }

        public string ten_dkdb { get; set; }

        public string ten_dktb { get; set; }

        public string tenkhkd { get; set; }

        public string thangbd { get; set; }

        public Nullable<decimal> tien_tb { get; set; }

        public Nullable<decimal> tienno { get; set; }

        public string tuyen_tc { get; set; }

        public string village { get; set; }

        public string xa_phuong { get; set; }

        public string goi_th { get; set; }

        public string ma_nvcs { get; set; }

        public string ma_nvkt { get; set; }

        public Nullable<bool> thtb { get; set; }

        public string users { get; set; }

        public Nullable<int> camket { get; set; }

        public string dt_lh { get; set; }

        public string duongld { get; set; }

        public string xa_phuongld { get; set; }

        public string khom_apld { get; set; }

        public string kh_db { get; set; }

        public string so_nha { get; set; }

        public string so_nhald { get; set; }

        public string id_goicuoc { get; set; }

        public string ttin108s { get; set; }
    }

    

    public class MyTv
    {
        public string dc_tbld { get; set; }

        public string dckd { get; set; }

        public string dia_chitb { get; set; }

        public string duong { get; set; }

        public string e_mail { get; set; }

        public string goi_cuoc { get; set; }

        public string ht_ld { get; set; }

        public string ht_tt { get; set; }

        public string khom_ap { get; set; }

        public string loai_cap { get; set; }

        public string ma_huyen { get; set; }

        public string ma_kh { get; set; }

        public string ma_km { get; set; }

        public string ma_nhom { get; set; }

        public string ma_nghe { get; set; }

        public string ma_tram { get; set; }

        public string maxa { get; set; }

        public string ms_thue { get; set; }

        public string ngan_hang { get; set; }

        public Nullable<DateTime> ngay_cap { get; set; }

        public Nullable<DateTime> ngay_hd { get; set; }

        public Nullable<DateTime> ngay_hdl { get; set; }

        public Nullable<DateTime> ngay_kn { get; set; }

        public Nullable<DateTime> ngay_ld { get; set; }

        public Nullable<DateTime> ngay_ngung { get; set; }

        public string noi_cap { get; set; }

        public string note_ngay_kn { get; set; }

        public string pl { get; set; }

        public Nullable<decimal> port { get; set; }

        public Nullable<decimal> slot { get; set; }

        public string so_dt { get; set; }

        public string socmnd { get; set; }

        public string sohopdong { get; set; }

        public string stb_serial { get; set; }

        public string system_id { get; set; }

        public string tai_khoan { get; set; }

        public string ten_dkdb { get; set; }

        public string ten_dktb { get; set; }

        public string tenkhkd { get; set; }

        public string tinh_trang { get; set; }

        public string tuyen_tc { get; set; }

        public string user_adsl { get; set; }

        public string user_login { get; set; }
        [Key]
        public string user_name { get; set; }

        public string xa_phuong { get; set; }

        public string goi_th { get; set; }

        public string ma_nvcs { get; set; }

        public string ma_nvkt { get; set; }

        public string ma_nvld { get; set; }

        public Nullable<bool> thtb { get; set; }

        public string users { get; set; }

        public Nullable<int> camket { get; set; }

        public string dt_lh { get; set; }

        public string so_119 { get; set; }

        public string duongld { get; set; }

        public string xa_phuongld { get; set; }

        public string khom_apld { get; set; }

        public string kh_db { get; set; }

        public string so_nha { get; set; }

        public string so_nhald { get; set; }

        public string id_goicuoc { get; set; }

        public Nullable<bool> maychinh { get; set; }

        public string id_nhom { get; set; }
    }

    public class Catmo
    {
        public Nullable<int> card { get; set; }

        public string dc_tbld { get; set; }

        public string dia_chitb { get; set; }

        public Nullable<int> dlu { get; set; }       

        public Nullable<int> en { get; set; }

        public Nullable<int> frame { get; set; }
         [Key]

        public decimal id { get; set; }

        public Nullable<bool> logic { get; set; }

        public string ma_huyen { get; set; }

        public string ma_yc { get; set; }

        public string ten_yc { get; set; }

        public Nullable<bool> mo { get; set; }

        public string nguoi_mo { get; set; }

        public string nguoi_yc { get; set; }

        public Nullable<int> port { get; set; }

        public Nullable<int> shell { get; set; }

        public Nullable<int> slot { get; set; }

        public Nullable<int> slp { get; set; }

        public string so_dt { get; set; }

        public string ten_dkdb { get; set; }

        public string ten_dktb { get; set; }

        public Nullable<DateTime> tg_mo { get; set; }

        public Nullable<DateTime> tg_yc { get; set; }
    }

    public class TocDo
    {
        public string ghi_chu { get; set; }
        [Key]
        public decimal id { get; set; }

        public string ma_goi { get; set; }

        public string ma_td { get; set; }

        public string toc_do { get; set; }
    }

    public class KhachHangUuTien
    {
        [Key]
        public decimal id { get; set; }

        public string kh_uutien1 { get; set; }

        public string ten_uutien { get; set; }
    }

    public class GoiCuoc
    {
        public string ghi_chu { get; set; }
        [Key]
        public string ma_goi { get; set; }

        public string ma_dv { get; set; }

        public string ten_goi { get; set; }
    }

    public class INTERNET
    {
        public string dc_tbld { get; set; }

        public string dckd { get; set; }

        public string dia_chitb { get; set; }

        public string duong { get; set; }

        public string e_mail { get; set; }

        public string goi_cuoc { get; set; }

        public string ht_ld { get; set; }

        public string ht_tt { get; set; }              

        public string kh_uutien { get; set; }

        public string ten_uutien { get; set; }

        public Nullable<bool> khg_vat { get; set; }

        public string khom_ap { get; set; }

        public string ma_dv { get; set; }

        public string ma_huyen { get; set; }

        public string ma_kh { get; set; }

        public string ma_km { get; set; }

        public string ma_nghe { get; set; }

        public string ma_nhom { get; set; }

        public string ma_nvcs { get; set; }

        public string ma_nvkt { get; set; }

        public string ma_nvld { get; set; }

        public string ma_tram { get; set; }

        public string maxa { get; set; }

        public string may_ngung { get; set; }

        public string ms_thue { get; set; }

        public string loai_cap { get; set; }

        public string ngan_hang { get; set; }

        public Nullable<DateTime> ngay_cap { get; set; }

        public Nullable<DateTime> ngay_hd { get; set; }

        public Nullable<DateTime> ngay_kn { get; set; }

        public Nullable<DateTime> ngay_ld { get; set; }

        public Nullable<DateTime> ngay_ngung { get; set; }

        public string noi_cap { get; set; }

        public string note_ngay_kn { get; set; }

        public string so_dt { get; set; }

        public string socmnd { get; set; }

        public string sohopdong { get; set; }

        public Nullable<decimal> stt { get; set; }

        public string tai_khoan { get; set; }

        public string ten_dktb { get; set; }

        public string ten_nsd { get; set; }

        public string tenkhkd { get; set; }

        public string toc_do { get; set; }

        public string tuyen_tc { get; set; }
          [Key]

        public string user_name { get; set; }

        public string user_login { get; set; }

        public string xa_phuong { get; set; }

        public Nullable<bool> thtb { get; set; }

        public string us { get; set; }

        public Nullable<int> camket { get; set; }

        public string dt_lh { get; set; }

        public string so_119 { get; set; }

        public string duongld { get; set; }

        public string xa_phuongld { get; set; }

        public string khom_apld { get; set; }

        public string kh_db { get; set; }

        public string so_nha { get; set; }

        public string so_nhald { get; set; }

        public string id_goicuoc { get; set; }

        public string goi_th { get; set; }
    }

    //public partial class Procedures : global::System.Data.Objects.ObjectContext
    //{
    //    public void CreateTables(int n)
    //    {
    //        try
    //        {
    //            this.Connection.Open();
    //            EntityCommand command = new EntityCommand();
    //            //Imported function name
    //            command.CommandText = "QLThuebaoEntities.CreateTable";
    //            command.CommandType = CommandType.StoredProcedure;
    //            // EntityParameter param1 = new EntityParameter("storeId", DbType.String, 4);
    //            // param1.Value = storeId;
    //            //EntityParameter param2 = new EntityParameter("state", DbType.String, 2);
    //            //param2.Value = State;
    //            //command.Parameters.Add(param1);
    //            //command.Parameters.Add(param2);
    //            command.Connection = this.Connection as EntityConnection;
    //            command.ExecuteNonQuery();
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //}


    // The MetadataTypeAttribute identifies cat_moMetadata as the class
    // that carries additional metadata for the cat_mo class.
    [MetadataTypeAttribute(typeof(cat_mo.cat_moMetadata))]
    public partial class cat_mo
    {

        // This class allows you to attach custom attributes to properties
        // of the cat_mo class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class cat_moMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private cat_moMetadata()
            {
            }

            public Nullable<int> card { get; set; }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public Nullable<int> dlu { get; set; }

            public Nullable<int> en { get; set; }

            public Nullable<int> frame { get; set; }

            public decimal id { get; set; }

            public Nullable<bool> logic { get; set; }

            public string ma_huyen { get; set; }

            public string ma_yc { get; set; }

            public Nullable<bool> mo { get; set; }

            public string nguoi_mo { get; set; }

            public string nguoi_yc { get; set; }

            public Nullable<int> port { get; set; }

            public Nullable<int> shell { get; set; }

            public Nullable<int> slot { get; set; }

            public Nullable<int> slp { get; set; }

            public string so_dt { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public Nullable<DateTime> tg_mo { get; set; }

            public Nullable<DateTime> tg_yc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies cat_mo_logMetadata as the class
    // that carries additional metadata for the cat_mo_log class.
    [MetadataTypeAttribute(typeof(cat_mo_log.cat_mo_logMetadata))]
    public partial class cat_mo_log
    {

        // This class allows you to attach custom attributes to properties
        // of the cat_mo_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class cat_mo_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private cat_mo_logMetadata()
            {
            }

            public Nullable<int> card { get; set; }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public Nullable<int> dlu { get; set; }

            public Nullable<int> en { get; set; }

            public Nullable<int> frame { get; set; }

            public decimal id { get; set; }

            public Nullable<bool> logic { get; set; }

            public string ma_huyen { get; set; }

            public string ma_yc { get; set; }

            public Nullable<bool> mo { get; set; }

            public string nguoi_mo { get; set; }

            public string nguoi_yc { get; set; }

            public Nullable<int> port { get; set; }

            public Nullable<int> shell { get; set; }

            public Nullable<int> slot { get; set; }

            public Nullable<int> slp { get; set; }

            public string so_dt { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public Nullable<DateTime> tg_mo { get; set; }

            public Nullable<DateTime> tg_yc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies codinh_logMetadata as the class
    // that carries additional metadata for the codinh_log class.
    [MetadataTypeAttribute(typeof(codinh_log.codinh_logMetadata))]
    public partial class codinh_log
    {

        // This class allows you to attach custom attributes to properties
        // of the codinh_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class codinh_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private codinh_logMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public string e_mail { get; set; }

            public decimal id { get; set; }

            public Nullable<bool> keo_may { get; set; }

            public Nullable<bool> khg_vat { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_tram { get; set; }

            public string may_ngung { get; set; }

            public Nullable<bool> mo_may { get; set; }

            public string ms_thue { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_mo { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string pl { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public Nullable<decimal> stt { get; set; }

            public Nullable<decimal> tb_dv { get; set; }

            public Nullable<bool> tbdc { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public Nullable<decimal> tien_tb { get; set; }

            public Nullable<decimal> tienno { get; set; }

            public string tuyen_tc { get; set; }

            public string users { get; set; }

            public string village { get; set; }

            public string goi_th { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public string lydocat { get; set; }

            public string ldthtb { get; set; }

            public string dt_lh { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies dichvugiatangMetadata as the class
    // that carries additional metadata for the dichvugiatang class.
    [MetadataTypeAttribute(typeof(dichvugiatang.dichvugiatangMetadata))]
    public partial class dichvugiatang
    {

        // This class allows you to attach custom attributes to properties
        // of the dichvugiatang class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class dichvugiatangMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private dichvugiatangMetadata()
            {
            }

            public string ma_dv { get; set; }

            public string ten_dv { get; set; }

            public Nullable<decimal> tien { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies CnfgStatus119Metadata as the class
    // that carries additional metadata for the CnfgStatus119 class.
    [MetadataTypeAttribute(typeof(CnfgStatus119.CnfgStatus119Metadata))]
    public partial class CnfgStatus119
    {

        // This class allows you to attach custom attributes to properties
        // of the CnfgStatus119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CnfgStatus119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private CnfgStatus119Metadata()
            {
            }

            public int ID { get; set; }

            public int iStatusID { get; set; }

            public string sStatus { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies dichvugiatang_logMetadata as the class
    // that carries additional metadata for the dichvugiatang_log class.
    [MetadataTypeAttribute(typeof(dichvugiatang_log.dichvugiatang_logMetadata))]
    public partial class dichvugiatang_log
    {

        // This class allows you to attach custom attributes to properties
        // of the dichvugiatang_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class dichvugiatang_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private dichvugiatang_logMetadata()
            {
            }

            public string don_vi { get; set; }

            public decimal id { get; set; }

            public string ma_dv { get; set; }

            public Nullable<bool> mo_dv { get; set; }

            public Nullable<DateTime> ngay { get; set; }

            public string nguoi_mo { get; set; }

            public string so_dt { get; set; }

            public Nullable<decimal> tien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies don_viMetadata as the class
    // that carries additional metadata for the don_vi class.
    [MetadataTypeAttribute(typeof(don_vi.don_viMetadata))]
    public partial class don_vi
    {

        // This class allows you to attach custom attributes to properties
        // of the don_vi class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class don_viMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private don_viMetadata()
            {
            }

            public string batdau_mkh { get; set; }

            public Nullable<decimal> ind { get; set; }

            public string ma_dv { get; set; }

            public EntityCollection<nhanvien_cs> nhanvien_cs { get; set; }

            public string ten_dv { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ds_codinhMetadata as the class
    // that carries additional metadata for the ds_codinh class.
    [MetadataTypeAttribute(typeof(ds_codinh.ds_codinhMetadata))]
    public partial class ds_codinh
    {

        // This class allows you to attach custom attributes to properties
        // of the ds_codinh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ds_codinhMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ds_codinhMetadata()
            {
            }

            public Nullable<decimal> cuoc { get; set; }

            public Nullable<bool> dau { get; set; }

            public string dc_tbld { get; set; }

            public string dckd { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string e_mail { get; set; }

            public Nullable<bool> inct { get; set; }

            public Nullable<bool> keo_may { get; set; }      

            public Nullable<bool> khg_vat { get; set; }

            public string khom_ap { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nhom { get; set; }

            public string ma_tram { get; set; }

            public string may_ngung { get; set; }

            public Nullable<bool> mo_may { get; set; }

            public string ms_thue { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_mo { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string pl { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string tai_khoan { get; set; }

            public Nullable<decimal> tb_dv { get; set; }

            public Nullable<bool> tbdc { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public string tenkhkd { get; set; }

            public string thangbd { get; set; }

            public Nullable<decimal> tien_tb { get; set; }

            public Nullable<decimal> tienno { get; set; }

            public string tuyen_tc { get; set; }

            public string village { get; set; }

            public string xa_phuong { get; set; }

            public string goi_th { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string duongld { get; set; }

            public string xa_phuongld { get; set; }

            public string khom_apld { get; set; }

            public string kh_db { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }

            public string ttin108s { get; set; }
            
        }
    }

    // The MetadataTypeAttribute identifies gc_mytvMetadata as the class
    // that carries additional metadata for the gc_mytv class.
    [MetadataTypeAttribute(typeof(gc_mytv.gc_mytvMetadata))]
    public partial class gc_mytv
    {

        // This class allows you to attach custom attributes to properties
        // of the gc_mytv class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class gc_mytvMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private gc_mytvMetadata()
            {
            }

            public int id { get; set; }

            public string ma_goi { get; set; }

            public string ten_dv { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Goi_thMetadata as the class
    // that carries additional metadata for the Goi_th class.
    [MetadataTypeAttribute(typeof(Goi_th.Goi_thMetadata))]
    public partial class Goi_th
    {

        // This class allows you to attach custom attributes to properties
        // of the Goi_th class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Goi_thMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Goi_thMetadata()
            {
            }

            public string Ghi_chu { get; set; }

            public string ma_goi { get; set; }

            public Nullable<byte> sl_dd { get; set; }

            public string ten_goi { get; set; }

            public decimal tien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies GphoneMetadata as the class
    // that carries additional metadata for the Gphone class.
    [MetadataTypeAttribute(typeof(Gphone.GphoneMetadata))]
    public partial class Gphone
    {

        // This class allows you to attach custom attributes to properties
        // of the Gphone class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class GphoneMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private GphoneMetadata()
            {
            }

            public string CellID { get; set; }

            public string chucvu { get; set; }

            public Nullable<decimal> cuoc { get; set; }

            public string dc_tbld { get; set; }

            public string dckd { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string dvgt { get; set; }

            public string e_mail { get; set; }

            public string goicuoc { get; set; }

            public string imei { get; set; }

            public Nullable<bool> inct { get; set; }

            public Nullable<bool> keo_may { get; set; }

            public string kh_db { get; set; }

            public Nullable<bool> khg_vat { get; set; }

            public string khom_ap { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nghe { get; set; }

            public string ma_tram { get; set; }

            public string may_ngung { get; set; }

            public Nullable<bool> mo_may { get; set; }

            public string ms_thue { get; set; }

            public string ng_daidien { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_mo { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string nv_ld { get; set; }

            public string pl { get; set; }

            public string ptt_toan { get; set; }

            public string seri { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohieu_nv { get; set; }

            public string sohopdong { get; set; }

            public string SoSim { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string tai_khoan { get; set; }

            public Nullable<decimal> tb_dv { get; set; }

            public Nullable<bool> tbdc { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public string tenkhkd { get; set; }

            public string thangbd { get; set; }

            public Nullable<decimal> tien_tb { get; set; }

            public Nullable<decimal> tienno { get; set; }

            public string tt_tb { get; set; }

            public string ttin_khac { get; set; }

            public string tuyen_tc { get; set; }

            public string village { get; set; }

            public string xa_phuong { get; set; }

            public string goi_th { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public Nullable<bool> loai_tb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string duongld { get; set; }

            public string xa_phuongld { get; set; }

            public string khom_apld { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }

            public string ttin108s { get; set; }
            
        }
    }

    // The MetadataTypeAttribute identifies Gphone_logMetadata as the class
    // that carries additional metadata for the Gphone_log class.
    [MetadataTypeAttribute(typeof(Gphone_log.Gphone_logMetadata))]
    public partial class Gphone_log
    {

        // This class allows you to attach custom attributes to properties
        // of the Gphone_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Gphone_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Gphone_logMetadata()
            {
            }

            public string chucvu { get; set; }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string e_mail { get; set; }

            public string goicuoc { get; set; }

            public decimal id { get; set; }

            public string imei { get; set; }

            public Nullable<bool> keo_may { get; set; }

            public Nullable<bool> khg_vat { get; set; }

            public string khom_ap { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string may_ngung { get; set; }

            public Nullable<bool> mo_may { get; set; }

            public string ms_thue { get; set; }

            public string ng_daidien { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_mo { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string nv_ld { get; set; }

            public string pl { get; set; }

            public string seri { get; set; }

            public string so_dt { get; set; }

            public string so_nha { get; set; }

            public string socmnd { get; set; }

            public string sohieu_nv { get; set; }

            public string sohopdong { get; set; }

            public string SoSim { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string tai_khoan { get; set; }

            public Nullable<decimal> tb_dv { get; set; }

            public Nullable<bool> tbdc { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public Nullable<DateTime> tghmang { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public Nullable<decimal> tien_tb { get; set; }

            public Nullable<decimal> tienno { get; set; }

            public string ttin_khac { get; set; }

            public string tuyen_tc { get; set; }

            public string users { get; set; }

            public string village { get; set; }

            public string xa_phuong { get; set; }

            public string goi_th { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public string lydocat { get; set; }

            public string ldthtb { get; set; }

            public Nullable<bool> loai_tb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies kh_maiMetadata as the class
    // that carries additional metadata for the kh_mai class.
    [MetadataTypeAttribute(typeof(kh_mai.kh_maiMetadata))]
    public partial class kh_mai
    {

        // This class allows you to attach custom attributes to properties
        // of the kh_mai class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class kh_maiMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private kh_maiMetadata()
            {
            }

            public string ma_km { get; set; }

            public Nullable<DateTime> ngay_bd { get; set; }

            public Nullable<DateTime> ngay_kt { get; set; }

            public string ten_ct { get; set; }

            public bool hieu_luc { get; set; }
        }
    }

    [MetadataTypeAttribute(typeof(khachhangDN.khachhangDNMetadata))]
    public partial class khachhangDN
    {

        // This class allows you to attach custom attributes to properties
        // of the kh_mai class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class khachhangDNMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private khachhangDNMetadata()
            {
            }

            public decimal id { get; set; }

            public Nullable<DateTime> ngay_tl { get; set; }           

            public string ten_dktb { get; set; }

            public string dia_chitb { get; set; }

            public string giam_doc { get; set; }

            public string so_dt { get; set; }

           
        }
    }

    // The MetadataTypeAttribute identifies loai_catmoMetadata as the class
    // that carries additional metadata for the loai_catmo class.
    [MetadataTypeAttribute(typeof(loai_catmo.loai_catmoMetadata))]
    public partial class loai_catmo
    {

        // This class allows you to attach custom attributes to properties
        // of the loai_catmo class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class loai_catmoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private loai_catmoMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_yc { get; set; }

            public string ten_yc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies loai_khMetadata as the class
    // that carries additional metadata for the loai_kh class.
    [MetadataTypeAttribute(typeof(loai_kh.loai_khMetadata))]
    public partial class loai_kh
    {

        // This class allows you to attach custom attributes to properties
        // of the loai_kh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class loai_khMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private loai_khMetadata()
            {
            }

            public int id { get; set; }

            public string ma_nghe { get; set; }

            public string maloai { get; set; }

            public string mota { get; set; }

            public string pl { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies loai_dvMetadata as the class
    // that carries additional metadata for the loai_dv class.
    [MetadataTypeAttribute(typeof(loai_dv.loai_dvMetadata))]
    public partial class loai_dv
    {

        // This class allows you to attach custom attributes to properties
        // of the loai_dv class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class loai_dvMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private loai_dvMetadata()
            {
            }

            public string ma_dv { get; set; }

            public string ten_dv { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies ma_apMetadata as the class
    // that carries additional metadata for the ma_ap class.
    [MetadataTypeAttribute(typeof(ma_ap.ma_apMetadata))]
    public partial class ma_ap
    {

        // This class allows you to attach custom attributes to properties
        // of the ma_ap class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ma_apMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ma_apMetadata()
            {
            }

            public decimal id { get; set; }

            public string maap { get; set; }

            public string maxa { get; set; }

            public string ten_ap { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ma_duongMetadata as the class
    // that carries additional metadata for the ma_duong class.
    [MetadataTypeAttribute(typeof(ma_duong.ma_duongMetadata))]
    public partial class ma_duong
    {

        // This class allows you to attach custom attributes to properties
        // of the ma_duong class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ma_duongMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ma_duongMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string ten_duong { get; set; }
       
        }
    }

    // The MetadataTypeAttribute identifies ma_xaMetadata as the class
    // that carries additional metadata for the ma_xa class.
    [MetadataTypeAttribute(typeof(ma_xa.ma_xaMetadata))]
    public partial class ma_xa
    {

        // This class allows you to attach custom attributes to properties
        // of the ma_xa class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ma_xaMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ma_xaMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string maxa { get; set; }

            public string ten { get; set; }

            public Nullable<decimal> tientb { get; set; }

            public bool vtci { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies menuMetadata as the class
    // that carries additional metadata for the menu class.
    [MetadataTypeAttribute(typeof(menu.menuMetadata))]
    public partial class menu
    {

        // This class allows you to attach custom attributes to properties
        // of the menu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class menuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private menuMetadata()
            {
            }

            public Nullable<decimal> id { get; set; }

            public string m_menu { get; set; }

            public string t_menu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies mytvMetadata as the class
    // that carries additional metadata for the mytv class.
    [MetadataTypeAttribute(typeof(mytv.mytvMetadata))]
    public partial class mytv
    {

        // This class allows you to attach custom attributes to properties
        // of the mytv class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class mytvMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private mytvMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dckd { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string e_mail { get; set; }

            public string goi_cuoc { get; set; }

            public string ht_ld { get; set; }

            public string ht_tt { get; set; }

            public string khom_ap { get; set; }

            public string loai_cap { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nghe { get; set; }

            public string ma_tram { get; set; }

            public string maxa { get; set; }

            public string ms_thue { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_hdl { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string pl { get; set; }

            public Nullable<decimal> port { get; set; }

            public Nullable<decimal> slot { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public string stb_serial { get; set; }

            public string system_id { get; set; }

            public string tai_khoan { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public string tenkhkd { get; set; }

            public string tinh_trang { get; set; }

            public string tuyen_tc { get; set; }

            public string user_adsl { get; set; }

            public string user_login { get; set; }

            public string user_name { get; set; }

            public string xa_phuong { get; set; }

            public string goi_th { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string so_119 { get; set; }

            public string duongld { get; set; }

            public string xa_phuongld { get; set; }

            public string khom_apld { get; set; }

            public string kh_db { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }

            public Nullable<bool> maychinh { get; set; }

            public string id_nhom { get; set; }
            
        }
    }

    // The MetadataTypeAttribute identifies mytv_logMetadata as the class
    // that carries additional metadata for the mytv_log class.
    [MetadataTypeAttribute(typeof(mytv_log.mytv_logMetadata))]
    public partial class mytv_log
    {

        // This class allows you to attach custom attributes to properties
        // of the mytv_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class mytv_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private mytv_logMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public string goi_cuoc { get; set; }

            public string ht_ld { get; set; }

            public string ht_tt { get; set; }

            public decimal id { get; set; }

            public string loai_cap { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string maxa { get; set; }

            public string ms_thue { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_hdl { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string pl { get; set; }

            public Nullable<decimal> port { get; set; }

            public Nullable<decimal> slot { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public string stb_serial { get; set; }

            public string ten_dkdb { get; set; }

            public string ten_dktb { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public string tinh_trang { get; set; }

            public string tk_nh { get; set; }

            public string tuyen_tc { get; set; }

            public string user_login { get; set; }

            public string user_name { get; set; }

            public string n_user_name { get; set; }      

            public string goi_th { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public Nullable<bool> thtb { get; set; }

            public string lydocat { get; set; }

            public string ldthtb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string id_goicuoc { get; set; }

            public Nullable<bool> maychinh { get; set; }

            public string id_nhom { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies nhom_khMetadata as the class
    // that carries additional metadata for the nhom_kh class.
    [MetadataTypeAttribute(typeof(nhom_kh.nhom_khMetadata))]
    public partial class nhom_kh
    {

        // This class allows you to attach custom attributes to properties
        // of the nhom_kh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class nhom_khMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private nhom_khMetadata()
            {
            }

            public string dc_dktb { get; set; }

            public string dc_dktb_cd { get; set; }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string so_dt { get; set; }

            public Nullable<decimal> soluu { get; set; }

            public string ten_dktb { get; set; }

            public string ten_dktb_cd { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies nv_thuethuMetadata as the class
    // that carries additional metadata for the nv_thuethu class.
    [MetadataTypeAttribute(typeof(nv_thuethu.nv_thuethuMetadata))]
    public partial class nv_thuethu
    {

        // This class allows you to attach custom attributes to properties
        // of the nv_thuethu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class nv_thuethuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private nv_thuethuMetadata()
            {
            }

            public string ghi_chu { get; set; }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string ten { get; set; }

            public string ten_nv { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies nv_thuethuMetadata as the class
    // that carries additional metadata for the nv_thuethu class.
    [MetadataTypeAttribute(typeof(nhanvien_cs.nhanvien_csMetadata))]
    public partial class nhanvien_cs
    {

        // This class allows you to attach custom attributes to properties
        // of the nv_thuethu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class nhanvien_csMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private nhanvien_csMetadata()
            {
            }
            public EntityCollection<chi_tieu_ca_nhan> chi_tieu_ca_nhan { get; set; }

            public Boolean kt { get; set; }

            public string phone { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_huyen { get; set; }
         
            public string ten_nv { get; set; }

            public string diaban { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies tien_tbMetadata as the class
    // that carries additional metadata for the tien_tb class.
    [MetadataTypeAttribute(typeof(tien_tb.tien_tbMetadata))]
    public partial class tien_tb
    {

        // This class allows you to attach custom attributes to properties
        // of the tien_tb class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tien_tbMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tien_tbMetadata()
            {
            }

            public string ghi_chu { get; set; }

            public string loai { get; set; }

            public Nullable<decimal> tien_tb1 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tram_vtMetadata as the class
    // that carries additional metadata for the tram_vt class.
    [MetadataTypeAttribute(typeof(tram_vt.tram_vtMetadata))]
    public partial class tram_vt
    {

        // This class allows you to attach custom attributes to properties
        // of the tram_vt class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tram_vtMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tram_vtMetadata()
            {
            }

            public decimal id { get; set; }

            public string dauso { get; set; }

            public string ma_huyen { get; set; }

            public string ma_tram { get; set; }

            public string ten_tram { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies userMetadata as the class
    // that carries additional metadata for the user class.
    [MetadataTypeAttribute(typeof(user.userMetadata))]
    public partial class user
    {

        // This class allows you to attach custom attributes to properties
        // of the user class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class userMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private userMetadata()
            {
            }

            public Nullable<bool> connecting { get; set; }

            public string e_mail { get; set; }

            public string hoten { get; set; }

            public string huyen { get; set; }

            public string huyentd { get; set; }    

            public string m_menu { get; set; }

            public string m_password { get; set; }

            public string phone { get; set; }

            public string user_name { get; set; }

            public bool sua { get; set; }

            public bool admin { get; set; }

            public bool admin119 { get; set; }

            public bool kt { get; set; }

            public bool lock_usr { get; set; }

            public bool gioitinh { get; set; }

            public bool lan_dau { get; set; }

            public Nullable<DateTime> namsinh { get; set; }

            public bool adminBSC_VTT { get; set; }

            public bool adminBSC_TTKD { get; set; }

            public string xemBSC { get; set; }    
           
        }
      
    }

    // The MetadataTypeAttribute identifies nganh_ngheMetadata as the class
    // that carries additional metadata for the nganh_nghe class.
    [MetadataTypeAttribute(typeof(nganh_nghe.nganh_ngheMetadata))]
    public partial class nganh_nghe
    {

        // This class allows you to attach custom attributes to properties
        // of the nganh_nghe class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class nganh_ngheMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private nganh_ngheMetadata()
            {
            }

            public int id { get; set; }

            public string ma_nghe { get; set; }

            public string ten_nghe { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies users_logMetadata as the class
    // that carries additional metadata for the users_log class.
    [MetadataTypeAttribute(typeof(users_log.users_logMetadata))]
    public partial class users_log
    {

        // This class allows you to attach custom attributes to properties
        // of the users_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class users_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private users_logMetadata()
            {
            }

            public decimal id { get; set; }

            public string ip_address { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public string user_name { get; set; }

            public Nullable<bool> thanhcong { get; set; }
        }
    }

       

        // The MetadataTypeAttribute identifies goicuoc_intMetadata as the class
    // that carries additional metadata for the goicuoc_int class.
    [MetadataTypeAttribute(typeof(goicuoc_int.goicuoc_intMetadata))]
    public partial class goicuoc_int
    {

        // This class allows you to attach custom attributes to properties
        // of the goicuoc_int class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class goicuoc_intMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private goicuoc_intMetadata()
            {
            }

            public string ghi_chu { get; set; }

            public string ma_dv { get; set; }

            public string ma_goi { get; set; }

            public string ten_goi { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies internetMetadata as the class
    // that carries additional metadata for the internet class.
    [MetadataTypeAttribute(typeof(internet.internetMetadata))]
    public partial class internet
    {

        // This class allows you to attach custom attributes to properties
        // of the internet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class internetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private internetMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dckd { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string e_mail { get; set; }

            public string goi_cuoc { get; set; }

            public string ht_ld { get; set; }

            public string ht_tt { get; set; }

            public string kh_uutien { get; set; }

            public Nullable<bool> khg_vat { get; set; }

            public string khom_ap { get; set; }

            public string ma_dv { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public string ma_tram { get; set; }

            public string maxa { get; set; }

            public string may_ngung { get; set; }

            public string ms_thue { get; set; }

            public string loai_cap { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string tai_khoan { get; set; }

            public string ten_dktb { get; set; }

            public string ten_nsd { get; set; }

            public string tenkhkd { get; set; }

            public string toc_do { get; set; }

            public string tuyen_tc { get; set; }

            public string user_name { get; set; }

            public string xa_phuong { get; set; }

            public Nullable<bool> thtb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string so_119 { get; set; }

            public string duongld { get; set; }

            public string xa_phuongld { get; set; }

            public string khom_apld { get; set; }

            public string kh_db { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string modem_seri { get; set; }

            public string id_goicuoc { get; set; }

            public string goi_th { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ds_119Metadata as the class
    // that carries additional metadata for the ds_119 class.
    [MetadataTypeAttribute(typeof(ds_119.ds_119Metadata))]
    public partial class ds_119
    {

        // This class allows you to attach custom attributes to properties
        // of the ds_119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ds_119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private ds_119Metadata()
            {
            }

            public string dc_tbld { get; set; }

            public Nullable<DateTime> dtfinished { get; set; }

            public Nullable<DateTime> dtRecvTime { get; set; }

            public decimal ID { get; set; }

            public string ma_huyen { get; set; }

            public string sCallerNo { get; set; }

            public string sDamagedPhoneNo { get; set; }

            public string sName { get; set; }

            public string user_name { get; set; }

            public string sNotes { get; set; }

            public string ten_dkdb { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies dsw_119Metadata as the class
    // that carries additional metadata for the dsw_119 class.
    [MetadataTypeAttribute(typeof(dsw_119.dsw_119Metadata))]
    public partial class dsw_119
    {

        // This class allows you to attach custom attributes to properties
        // of the ds_119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class dsw_119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private dsw_119Metadata()
            {
            }

            public string dc_tbld { get; set; }

            public Nullable<DateTime> dtfinished { get; set; }

            public Nullable<DateTime> dtRecvTime { get; set; }

            public decimal ID { get; set; }

            public string ma_huyen { get; set; }

            public string sCallerNo { get; set; }

            public string sDamagedPhoneNo { get; set; }

            public string sName { get; set; }

            public string user_name { get; set; }

            public string sNotes { get; set; }

            public string ten_dkdb { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies internet_logMetadata as the class
    // that carries additional metadata for the internet_log class.
    [MetadataTypeAttribute(typeof(internet_log.internet_logMetadata))]
    public partial class internet_log
    {

        // This class allows you to attach custom attributes to properties
        // of the internet_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class internet_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private internet_logMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public string duong { get; set; }

            public string e_mail { get; set; }

            public string goi_cuoc { get; set; }

            public string ht_ld { get; set; }

            public string loai_cap { get; set; }

            public string ht_tt { get; set; }

            public decimal id { get; set; }

            public string kh_uutien { get; set; }

            public Nullable<bool> khg_vat { get; set; }

            public string khom_ap { get; set; }

            public string ma_dv { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_km { get; set; }

            public string ma_nghe { get; set; }

            public string ma_nhom { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string ma_nvld { get; set; }

            public string ma_tram { get; set; }

            public string maxa { get; set; }

            public string may_ngung { get; set; }

            public string ms_thue { get; set; }           

            public string n_user_name { get; set; }

            public string ngan_hang { get; set; }

            public Nullable<DateTime> ngay_cap { get; set; }

            public Nullable<DateTime> ngay_hd { get; set; }

            public Nullable<DateTime> ngay_kn { get; set; }

            public Nullable<DateTime> ngay_ld { get; set; }

            public Nullable<DateTime> ngay_ngung { get; set; }

            public string noi_cap { get; set; }

            public string note_ngay_kn { get; set; }

            public string so_dt { get; set; }

            public string socmnd { get; set; }

            public string sohopdong { get; set; }

            public Nullable<decimal> stt { get; set; }

            public string tai_khoan { get; set; }

            public string ten_dktb { get; set; }

            public string ten_nsd { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public string toc_do { get; set; }

            public string tuyen_tc { get; set; }

            public string user_name { get; set; }

            public string user_login { get; set; }

            public string xa_phuong { get; set; }

            public Nullable<bool> thtb { get; set; }

            public string lydocat { get; set; }

            public string ldthtb { get; set; }

            public Nullable<int> camket { get; set; }

            public string dt_lh { get; set; }

            public string so_nha { get; set; }

            public string so_nhald { get; set; }

            public string modem_seri { get; set; }

            public string id_goicuoc { get; set; }

            public string goi_th { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies toc_doMetadata as the class
    // that carries additional metadata for the toc_do class.
    [MetadataTypeAttribute(typeof(toc_do.toc_doMetadata))]
    public partial class toc_do
    {

        // This class allows you to attach custom attributes to properties
        // of the toc_do class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class toc_doMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private toc_doMetadata()
            {
            }

            public string ghi_chu { get; set; }

            public decimal id { get; set; }

            public string ma_goi { get; set; }

            public string ma_td { get; set; }

            public string toc_do1 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies kh_uutienMetadata as the class
    // that carries additional metadata for the kh_uutien class.
    [MetadataTypeAttribute(typeof(kh_uutien.kh_uutienMetadata))]
    public partial class kh_uutien
    {

        // This class allows you to attach custom attributes to properties
        // of the kh_uutien class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class kh_uutienMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private kh_uutienMetadata()
            {
            }

            public decimal id { get; set; }

            public string kh_uutien1 { get; set; }

            public string ten_uutien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies rp_tktonghopMetadata as the class
    // that carries additional metadata for the rp_tktonghop class.
    [MetadataTypeAttribute(typeof(rp_tktonghop.rp_tktonghopMetadata))]
    public partial class rp_tktonghop
    {

        // This class allows you to attach custom attributes to properties
        // of the rp_tktonghop class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class rp_tktonghopMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private rp_tktonghopMetadata()
            {
            }

            public Nullable<decimal> catcd { get; set; }

            public Nullable<decimal> catftth { get; set; }

            public Nullable<decimal> catnguftth { get; set; }

            public Nullable<decimal> catgp { get; set; }

            public Nullable<decimal> catint { get; set; }

            public Nullable<decimal> catnguint { get; set; }

            public Nullable<decimal> catmy { get; set; }

            public Nullable<decimal> hmcd { get; set; }

            public Nullable<decimal> hmftth { get; set; }

            public Nullable<decimal> hmgp { get; set; }

            public Nullable<decimal> hmint { get; set; }

            public Nullable<decimal> hmmy { get; set; }

            public Nullable<decimal> hdlcd { get; set; }

            public Nullable<decimal> hdlftth { get; set; }

            public Nullable<decimal> hdlgp { get; set; }

            public Nullable<decimal> hdlint { get; set; }

            public Nullable<decimal> hdlmy { get; set; }

            public string ma_dv { get; set; }

            public Nullable<decimal> ngungcd { get; set; }

            public Nullable<decimal> ngungftth { get; set; }

            public Nullable<decimal> ngunggp { get; set; }

            public Nullable<decimal> ngungint { get; set; }

            public Nullable<decimal> ngungmy { get; set; }

            public string ten_dv { get; set; }

            public Nullable<decimal> thcd { get; set; }

            public Nullable<decimal> thftth { get; set; }

            public Nullable<decimal> thgp { get; set; }

            public Nullable<decimal> thint { get; set; }

            public Nullable<decimal> thmy { get; set; }
        }
    }

    [MetadataTypeAttribute(typeof(rp_tklydocat.rp_tklydocatMetadata))]
    public partial class rp_tklydocat
    {

        // This class allows you to attach custom attributes to properties
        // of the rp_tklydocat class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class rp_tklydocatMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private rp_tklydocatMetadata()
            {
            }
            public Nullable<Int32> ID { get; set; }

            public string ma_dv { get; set; }

            public string ma_ld { get; set; }

            public Nullable<decimal> slcd { get; set; }

            public Nullable<decimal> slftth { get; set; }

            public Nullable<decimal> slgp { get; set; }

            public Nullable<decimal> slint { get; set; }

            public Nullable<decimal> slmy { get; set; }

            public string ten_dv { get; set; }

            public string ten_ld { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies nv_thuethuMetadata as the class
    // that carries additional metadata for the thongbao class.
    [MetadataTypeAttribute(typeof(thongbao.thongbaoMetadata))]
    public partial class thongbao
    {

        // This class allows you to attach custom attributes to properties
        // of the nv_thuethu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class thongbaoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private thongbaoMetadata()
            {
            }           

            public string ma_huyen { get; set; }

            public string noi_dung { get; set; }         
        }
    }

    // The MetadataTypeAttribute identifies lydocatMetadata as the class
    // that carries additional metadata for the thongbao class.
    [MetadataTypeAttribute(typeof(lydocat.lydocatMetadata))]
    public partial class lydocat
    {

        // This class allows you to attach custom attributes to properties
        // of the nv_thuethu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class lydocatMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private lydocatMetadata()
            {
            }

            public string ma_ld { get; set; }

            public string ten_ld { get; set; }

            public string loai { get; set; }

            public int m_order { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies dssuaxong_119Metadata as the class
    // that carries additional metadata for the dssuaxong_119 class.
    [MetadataTypeAttribute(typeof(dssuaxong_119.dssuaxong_119Metadata))]
    public partial class dssuaxong_119
    {

        // This class allows you to attach custom attributes to properties
        // of the dssuaxong_119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class dssuaxong_119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private dssuaxong_119Metadata()
            {
            }

            public Nullable<bool> bfinished { get; set; }

            public string dc_tbld { get; set; }

            public Nullable<DateTime> dtfinished { get; set; }

            public Nullable<DateTime> dtRecvTime { get; set; }

            public decimal ID { get; set; }

            public string ma_huyen { get; set; }

            public string sCallerNo { get; set; }

            public string sDamagedPhoneNo { get; set; }

            public string sName { get; set; }

            public decimal iStatusID { get; set; }

            public string sStatus { get; set; }

            public string sNotes { get; set; }

            public string ten_dkdb { get; set; }

            public string tg { get; set; }

            public string user_name { get; set; }

            public string ma_tram { get; set; }

            public string ten_tram { get; set; }

            public string sohopdong { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tk119Metadata as the class
    // that carries additional metadata for the tk119 class.
    [MetadataTypeAttribute(typeof(tk119.tk119Metadata))]
    public partial class tk119
    {

        // This class allows you to attach custom attributes to properties
        // of the tk119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tk119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private tk119Metadata()
            {
            }

            public Nullable<int> baohong { get; set; }

            public decimal ID { get; set; }

            public string loai { get; set; }

            public Nullable<int> suaxong { get; set; }
        }

        // The MetadataTypeAttribute identifies tk119Metadata as the class
    // that carries additional metadata for the tk119 class.
        [MetadataTypeAttribute(typeof(thiet_bi.thiet_biMetadata))]
        public partial class thiet_bi
        {

            // This class allows you to attach custom attributes to properties
            // of the thiet_bi class.
            //
            // For example, the following marks the Xyz property as a
            // required property and specifies the format for valid values:
            //    [Required]
            //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
            //    [StringLength(32)]
            //    public string Xyz { get; set; }
            internal sealed class thiet_biMetadata
            {

                // Metadata classes are not meant to be instantiated.
                private thiet_biMetadata()
                {
                }

                public string ma_tb { get; set; }

                public string ten_tb { get; set; }

            }
        }

        // The MetadataTypeAttribute identifies khoMetadata as the class
        // that carries additional metadata for the kho class.
        [MetadataTypeAttribute(typeof(kho.khoMetadata))]
        public partial class kho
        {

            // This class allows you to attach custom attributes to properties
            // of the kho class.
            //
            // For example, the following marks the Xyz property as a
            // required property and specifies the format for valid values:
            //    [Required]
            //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
            //    [StringLength(32)]
            //    public string Xyz { get; set; }
            internal sealed class khoMetadata
            {

                // Metadata classes are not meant to be instantiated.
                private khoMetadata()
                {
                }

                public string ma_kho { get; set; }

                public string ten_kh { get; set; }
            }
        }

        // The MetadataTypeAttribute identifies thuhoi_logMetadata as the class
        // that carries additional metadata for the thuhoi_log class.
        [MetadataTypeAttribute(typeof(thuhoi_log.thuhoi_logMetadata))]
        public partial class thuhoi_log
        {

            // This class allows you to attach custom attributes to properties
            // of the thuhoi_log class.
            //
            // For example, the following marks the Xyz property as a
            // required property and specifies the format for valid values:
            //    [Required]
            //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
            //    [StringLength(32)]
            //    public string Xyz { get; set; }
            internal sealed class thuhoi_logMetadata
            {

                // Metadata classes are not meant to be instantiated.
                private thuhoi_logMetadata()
                {
                }

                public string dc_tbld { get; set; }

                public string dia_chitb { get; set; }

                public string goi_cuoc { get; set; }

                public decimal id { get; set; }

                public string ld_khong_thuhoi { get; set; }

                public string loai_cap { get; set; }

                public string loai_dv { get; set; }

                public string ma_huyen { get; set; }

                public string may_ngung { get; set; }

                public Nullable<DateTime> ngay_ngung { get; set; }

                public Nullable<DateTime> ngay_th { get; set; }

                public string nhap_kho { get; set; }

                public string ten_dktb { get; set; }

                public string ten_nsd { get; set; }

                public Nullable<DateTime> thoi_gian { get; set; }

                public Nullable<bool> thtb { get; set; }

                public string tinhtrang_tb { get; set; }

                public string toc_do { get; set; }

                public string user_name { get; set; }

                public string users { get; set; }
            }
        }

        // The MetadataTypeAttribute identifies chungloaicapMetadata as the class
        // that carries additional metadata for the chungloaicap class.
        [MetadataTypeAttribute(typeof(chungloaicap.chungloaicapMetadata))]
        public partial class chungloaicap
        {

            // This class allows you to attach custom attributes to properties
            // of the chungloaicap class.
            //
            // For example, the following marks the Xyz property as a
            // required property and specifies the format for valid values:
            //    [Required]
            //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
            //    [StringLength(32)]
            //    public string Xyz { get; set; }
            internal sealed class chungloaicapMetadata
            {

                // Metadata classes are not meant to be instantiated.
                private chungloaicapMetadata()
                {
                }

                public string dv { get; set; }

                public string loai_cap { get; set; }

                public Nullable<bool> moi { get; set; }

                public string ten_loai { get; set; }
            }
        }

        

        // The MetadataTypeAttribute identifies thuhoi_thietbiMetadata as the class
        // that carries additional metadata for the thuhoi_thietbi class.
        [MetadataTypeAttribute(typeof(thuhoi_thietbi.thuhoi_thietbiMetadata))]
        public partial class thuhoi_thietbi
        {

            // This class allows you to attach custom attributes to properties
            // of the thuhoi_thietbi class.
            //
            // For example, the following marks the Xyz property as a
            // required property and specifies the format for valid values:
            //    [Required]
            //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
            //    [StringLength(32)]
            //    public string Xyz { get; set; }
            internal sealed class thuhoi_thietbiMetadata
            {

                // Metadata classes are not meant to be instantiated.
                private thuhoi_thietbiMetadata()
                {
                }

                public string dc_tbld { get; set; }

                public string dia_chitb { get; set; }

                public string goi_cuoc { get; set; }

                public decimal id { get; set; }

                public string ld_khong_thuhoi { get; set; }

                public string loai_cap { get; set; }

                public string loai_dv { get; set; }

                public string ma_huyen { get; set; }

                public string may_ngung { get; set; }

                public Nullable<DateTime> ngay_ngung { get; set; }

                public Nullable<DateTime> ngay_th { get; set; }

                public string nhap_kho { get; set; }

                public string ten_dktb { get; set; }

                public string ten_nsd { get; set; }

                public Nullable<bool> thtb { get; set; }

                public string tinhtrang_tb { get; set; }

                public string toc_do { get; set; }

                public string user_name { get; set; }
            }

        }
    }

    // The MetadataTypeAttribute identifies tkloai119Metadata as the class
    // that carries additional metadata for the tkloai119 class.
    [MetadataTypeAttribute(typeof(tkloai119.tkloai119Metadata))]
    public partial class tkloai119
    {

        // This class allows you to attach custom attributes to properties
        // of the tkloai119 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tkloai119Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private tkloai119Metadata()
            {
            }

            public decimal id { get; set; }

            public Nullable<int> istatusID { get; set; }

            public Nullable<int> sl { get; set; }

            public string sstatus { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies C119TVPrefixMetadata as the class
    // that carries additional metadata for the C119TVPrefix class.
    [MetadataTypeAttribute(typeof(C119TVPrefix.C119TVPrefixMetadata))]
    public partial class C119TVPrefix
    {

        // This class allows you to attach custom attributes to properties
        // of the C119TVPrefix class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class C119TVPrefixMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private C119TVPrefixMetadata()
            {
            }

            public int ID { get; set; }

            public Nullable<byte> nGroupID { get; set; }

            public Nullable<int> nPrefixBegin { get; set; }

            public Nullable<int> nPrefixEnd { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies kenh_thue_riengMetadata as the class
    // that carries additional metadata for the kenh_thue_rieng class.
    [MetadataTypeAttribute(typeof(kenh_thue_rieng.kenh_thue_riengMetadata))]
    public partial class kenh_thue_rieng
    {

        // This class allows you to attach custom attributes to properties
        // of the kenh_thue_rieng class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class kenh_thue_riengMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private kenh_thue_riengMetadata()
            {
            }

            public string dc_cuoi { get; set; }

            public string dc_dau { get; set; }

            public string dia_chitb { get; set; }

            public string ghichu { get; set; }

            public decimal id { get; set; }

            public string kh_db { get; set; }

            public string loaikenh { get; set; }

            public string ma_huyen { get; set; }

            public string ma_kh { get; set; }

            public string ma_nghe { get; set; }

            public string ma_tram { get; set; }

            public string may_ngung { get; set; }

            public string ms_thue { get; set; }

            public DateTime ngay_hd { get; set; }

            public DateTime ngay_ld { get; set; }

            public DateTime ngay_mo { get; set; }

            public DateTime ngay_ngung { get; set; }

            public string pl { get; set; }

            public string so_dt { get; set; }

            public string sohopdong { get; set; }

            public decimal stt { get; set; }

            public decimal tbao { get; set; }

            public string ten_dktb { get; set; }

            public string thanghd { get; set; }

            public decimal tien_tb { get; set; }

            public decimal tienno { get; set; }

            public string toc_do { get; set; }

            public string tuyen_tc { get; set; }

            public string village { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies loai_kenhMetadata as the class
    // that carries additional metadata for the loai_kenh class.
    [MetadataTypeAttribute(typeof(loai_kenh.loai_kenhMetadata))]
    public partial class loai_kenh
    {

        // This class allows you to attach custom attributes to properties
        // of the loai_kenh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class loai_kenhMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private loai_kenhMetadata()
            {
            }

            public string ma_loai { get; set; }

            public string ten_loai { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies td_kenhriengMetadata as the class
    // that carries additional metadata for the td_kenhrieng class.
    [MetadataTypeAttribute(typeof(td_kenhrieng.td_kenhriengMetadata))]
    public partial class td_kenhrieng
    {

        // This class allows you to attach custom attributes to properties
        // of the td_kenhrieng class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class td_kenhriengMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private td_kenhriengMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_loai { get; set; }

            public string toc_do { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ma_diabanMetadata as the class
    // that carries additional metadata for the ma_diaban class.
    [MetadataTypeAttribute(typeof(ma_diaban.ma_diabanMetadata))]
    public partial class ma_diaban
    {

        // This class allows you to attach custom attributes to properties
        // of the ma_diaban class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ma_diabanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ma_diabanMetadata()
            {
            }

            public Nullable<bool> kt { get; set; }

            public string ma_huyen { get; set; }

            public string ma_tuyen { get; set; }

            public string ten_tuyen { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies nhanvien_cs_logMetadata as the class
    // that carries additional metadata for the nhanvien_cs_log class.
    [MetadataTypeAttribute(typeof(nhanvien_cs_log.nhanvien_cs_logMetadata))]
    public partial class nhanvien_cs_log
    {

        // This class allows you to attach custom attributes to properties
        // of the nhanvien_cs_log class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class nhanvien_cs_logMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private nhanvien_cs_logMetadata()
            {
            }

            public string diaban { get; set; }

            public decimal id { get; set; }

            public Nullable<bool> kt { get; set; }

            public string ma_huyen { get; set; }

            public string ma_nvcs { get; set; }

            public string phone { get; set; }

            public string ten_nv { get; set; }

            public Nullable<DateTime> thoi_gian { get; set; }

            public string users { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies rp_slg_diabanMetadata as the class
    // that carries additional metadata for the rp_slg_diaban class.
    [MetadataTypeAttribute(typeof(rp_slg_diaban.rp_slg_diabanMetadata))]
    public partial class rp_slg_diaban
    {

        // This class allows you to attach custom attributes to properties
        // of the rp_slg_diaban class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class rp_slg_diabanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private rp_slg_diabanMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string ma_nv { get; set; }

            public string ma_tuyen { get; set; }

            public Nullable<int> soluong { get; set; }

            public Nullable<int> soluongcd { get; set; }

            public Nullable<int> soluonggp { get; set; }

            public Nullable<int> soluongint { get; set; }

            public Nullable<int> soluongftth { get; set; }

            public Nullable<int> soluongmy { get; set; }

            public Nullable<decimal> tien { get; set; }

            public Nullable<decimal> tiencd { get; set; }

            public Nullable<decimal> tiengp { get; set; }

            public Nullable<decimal> tienint { get; set; }

            public Nullable<decimal> tienftth { get; set; }

            public Nullable<decimal> tienmy { get; set; }

            public string thang { get; set; }


            public string ten_nv { get; set; }

            public string ten_tuyen { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies rp_dsganMetadata as the class
    // that carries additional metadata for the rp_dsgan class.
    [MetadataTypeAttribute(typeof(rp_dsgan.rp_dsganMetadata))]
    public partial class rp_dsgan
    {

        // This class allows you to attach custom attributes to properties
        // of the rp_dsgan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class rp_dsganMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private rp_dsganMetadata()
            {
            }

            public string dc_tbld { get; set; }

            public string dia_chitb { get; set; }

            public string ma_huyen { get; set; }

            public string ma_nvcs { get; set; }

            public string ma_nvkt { get; set; }

            public string so_dt { get; set; }

            public string ten_dktb { get; set; }

            public string ten_nv { get; set; }

            public string ten_nvkt { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies rp_dt_diabanMetadata as the class
    // that carries additional metadata for the rp_dt_diaban class.
    [MetadataTypeAttribute(typeof(rp_dt_diaban.rp_dt_diabanMetadata))]
    public partial class rp_dt_diaban
    {

        // This class allows you to attach custom attributes to properties
        // of the rp_dt_diaban class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class rp_dt_diabanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private rp_dt_diabanMetadata()
            {
            }

            public decimal id { get; set; }

            public string ma_huyen { get; set; }

            public string ma_nv { get; set; }

            public string ma_tuyen { get; set; }

            public Nullable<int> soluong { get; set; }

            public Nullable<int> soluongb { get; set; }

            public Nullable<int> soluongcd { get; set; }

            public Nullable<int> soluongcdb { get; set; }

            public Nullable<int> soluongftth { get; set; }

            public Nullable<int> soluongftthb { get; set; }

            public Nullable<int> soluonggp { get; set; }

            public Nullable<int> soluonggpb { get; set; }

            public Nullable<int> soluongint { get; set; }

            public Nullable<int> soluongintb { get; set; }

            public Nullable<int> soluongmy { get; set; }

            public Nullable<int> soluongmyb { get; set; }

            public string ten_nv { get; set; }

            public string ten_tuyen { get; set; }

            public string thang { get; set; }

            public string thangb { get; set; }

            public Nullable<decimal> tien { get; set; }

            public Nullable<decimal> tienb { get; set; }

            public Nullable<decimal> tiencd { get; set; }

            public Nullable<decimal> tiencdb { get; set; }

            public Nullable<decimal> tienftth { get; set; }

            public Nullable<decimal> tienftthb { get; set; }

            public Nullable<decimal> tiengp { get; set; }

            public Nullable<decimal> tiengpb { get; set; }

            public Nullable<decimal> tienint { get; set; }

            public Nullable<decimal> tienintb { get; set; }

            public Nullable<decimal> tienmy { get; set; }

            public Nullable<decimal> tienmyb { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies chi_tieu_huyenMetadata as the class
    // that carries additional metadata for the chi_tieu_huyen class.
    [MetadataTypeAttribute(typeof(chi_tieu_huyen.chi_tieu_huyenMetadata))]
    public partial class chi_tieu_huyen
    {

        // This class allows you to attach custom attributes to properties
        // of the chi_tieu_huyen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class chi_tieu_huyenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private chi_tieu_huyenMetadata()
            {
            }

            public Nullable<double> chi_tieu_giao { get; set; }

            public Nullable<double> chi_tieu_thuc_hien { get; set; }

            public decimal id { get; set; }

            public string id_kpis { get; set; }

            public KPI KPI { get; set; }

            public string ma_dv { get; set; }

            public Phong_huyen Phong_huyen { get; set; }

            public string qui { get; set; }

            public Nullable<double> trong_so_giao { get; set; }

            public Nullable<double> ty_trong_thuc_hien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies khoiMetadata as the class
    // that carries additional metadata for the khoi class.
    [MetadataTypeAttribute(typeof(khoi.khoiMetadata))]
    public partial class khoi
    {

        // This class allows you to attach custom attributes to properties
        // of the khoi class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class khoiMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private khoiMetadata()
            {
            }

            public string ma_khoi { get; set; }

            public EntityCollection<Phong_huyen> Phong_huyen { get; set; }

            public string ten_khoi { get; set; }
           
        }
    }

    // The MetadataTypeAttribute identifies KPIMetadata as the class
    // that carries additional metadata for the KPI class.
    [MetadataTypeAttribute(typeof(KPI.KPIMetadata))]
    public partial class KPI
    {

        // This class allows you to attach custom attributes to properties
        // of the KPI class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class KPIMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private KPIMetadata()
            {
            }

            public EntityCollection<chi_tieu_huyen> chi_tieu_huyen { get; set; }

            public string dvt { get; set; }           

            public Nullable<int> id_kpos { get; set; }

            public KPOs KPOs { get; set; }

            public Nullable<bool> ky_thuat { get; set; }

            public string loai_dvt { get; set; }

            public string ma_cha { get; set; }

            public string ma_kpis { get; set; }

            public Nullable<int> sap_xep { get; set; }

            public string ten_kpis { get; set; }

       }
    }

    // The MetadataTypeAttribute identifies KPOsMetadata as the class
    // that carries additional metadata for the KPOs class.
    [MetadataTypeAttribute(typeof(KPOs.KPOsMetadata))]
    public partial class KPOs
    {

        // This class allows you to attach custom attributes to properties
        // of the KPOs class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class KPOsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private KPOsMetadata()
            {
            }

            public int id { get; set; }

            public EntityCollection<KPI> KPIs { get; set; }

            public Nullable<bool> ky_thuat { get; set; }

            public string ma_vien_canh { get; set; }

            public Nullable<int> sap_xep { get; set; }

            public string ten_kpos { get; set; }

            public vien_canh vien_canh { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Phong_huyenMetadata as the class
    // that carries additional metadata for the Phong_huyen class.
    [MetadataTypeAttribute(typeof(Phong_huyen.Phong_huyenMetadata))]
    public partial class Phong_huyen
    {

        // This class allows you to attach custom attributes to properties
        // of the Phong_huyen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Phong_huyenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Phong_huyenMetadata()
            {
            }

            public EntityCollection<chi_tieu_huyen> chi_tieu_huyen { get; set; }

            public khoi khoi { get; set; }

            public string ma_dv { get; set; }

            public string ma_khoi { get; set; }

            public Nullable<int> nhom { get; set; }

            public string ten_dv { get; set; }

            public bool kythuat { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vien_canhMetadata as the class
    // that carries additional metadata for the vien_canh class.
    [MetadataTypeAttribute(typeof(vien_canh.vien_canhMetadata))]
    public partial class vien_canh
    {

        // This class allows you to attach custom attributes to properties
        // of the vien_canh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vien_canhMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vien_canhMetadata()
            {
            }

            public EntityCollection<KPOs> KPOs { get; set; }

            public string ma_vien_canh { get; set; }

            public Nullable<int> sap_xep { get; set; }

            public string ten_vien_canh { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies chi_tieu_ca_nhanMetadata as the class
    // that carries additional metadata for the chi_tieu_ca_nhan class.
    [MetadataTypeAttribute(typeof(chi_tieu_ca_nhan.chi_tieu_ca_nhanMetadata))]
    public partial class chi_tieu_ca_nhan
    {

        // This class allows you to attach custom attributes to properties
        // of the chi_tieu_ca_nhan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class chi_tieu_ca_nhanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private chi_tieu_ca_nhanMetadata()
            {
            }

            public Nullable<double> chitieu_giao { get; set; }

            public Nullable<double> chitieu_th { get; set; }

            public decimal id { get; set; }

            public string id_kpi { get; set; }

            public string id_nv_cs { get; set; }

            public nhanvien_cs nhanvien_cs { get; set; }

            public Nullable<double> sanluong { get; set; }

            public sKPI sKPI { get; set; }

            public Nullable<double> sl_quydoi { get; set; }

            public string thang_nvcs { get; set; }

            public Nullable<double> tytrong { get; set; }

            public Nullable<double> tytrong_giao { get; set; }

            public Nullable<double> tytrong_th { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies sKPIMetadata as the class
    // that carries additional metadata for the sKPI class.
    [MetadataTypeAttribute(typeof(sKPI.sKPIMetadata))]
    public partial class sKPI
    {

        // This class allows you to attach custom attributes to properties
        // of the sKPI class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class sKPIMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private sKPIMetadata()
            {
            }

            public EntityCollection<chi_tieu_ca_nhan> chi_tieu_ca_nhan { get; set; }

            public string dvt { get; set; }           

            public string id_cha { get; set; }

            public string id_kpis { get; set; }

            public Nullable<decimal> id_kpo { get; set; }

            public Nullable<bool> ky_thuat { get; set; }

            public string loai_dvt { get; set; }

            public string ma_kpi { get; set; }

            public Nullable<int> sap_xep { get; set; }

            public sKPO sKPO { get; set; }

            public string ten_kpi { get; set; }

            public Nullable<bool> tong_hop { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies sKPOMetadata as the class
    // that carries additional metadata for the sKPO class.
    [MetadataTypeAttribute(typeof(sKPO.sKPOMetadata))]
    public partial class sKPO
    {

        // This class allows you to attach custom attributes to properties
        // of the sKPO class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class sKPOMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private sKPOMetadata()
            {
            }

            public decimal id { get; set; }

            public Nullable<bool> ky_thuat { get; set; }

            public Nullable<int> sap_xep { get; set; }

            public EntityCollection<sKPI> sKPIs { get; set; }

            public string ten_kpo { get; set; }
        }
    }

  }
