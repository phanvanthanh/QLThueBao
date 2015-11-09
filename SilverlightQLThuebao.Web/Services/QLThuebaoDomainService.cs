
namespace SilverlightQLThuebao.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using SilverlightQLThuebao.Web.Models;


    // Implements application logic using the QLThuebaoEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class QLThuebaoDomainService : LinqToEntitiesDomainService<QLThuebaoEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'bc_bd' query.
      
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'cat_mo' query.
        public IQueryable<cat_mo> GetCat_mo()
        {
            return this.ObjectContext.cat_mo;
        }

        public void InsertCat_mo(cat_mo cat_mo)
        {
            if ((cat_mo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cat_mo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.cat_mo.AddObject(cat_mo);
            }
        }

        public void UpdateCat_mo(cat_mo currentcat_mo)
        {
            this.ObjectContext.cat_mo.AttachAsModified(currentcat_mo, this.ChangeSet.GetOriginal(currentcat_mo));
        }

        public void DeleteCat_mo(cat_mo cat_mo)
        {
            if ((cat_mo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cat_mo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.cat_mo.Attach(cat_mo);
                this.ObjectContext.cat_mo.DeleteObject(cat_mo);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'cat_mo_log' query.
        public IQueryable<cat_mo_log> GetCat_mo_log()
        {
            return this.ObjectContext.cat_mo_log;
        }

        public void InsertCat_mo_log(cat_mo_log cat_mo_log)
        {
            if ((cat_mo_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cat_mo_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.cat_mo_log.AddObject(cat_mo_log);
            }
        }

        public void UpdateCat_mo_log(cat_mo_log currentcat_mo_log)
        {
            this.ObjectContext.cat_mo_log.AttachAsModified(currentcat_mo_log, this.ChangeSet.GetOriginal(currentcat_mo_log));
        }

        public void DeleteCat_mo_log(cat_mo_log cat_mo_log)
        {
            if ((cat_mo_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cat_mo_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.cat_mo_log.Attach(cat_mo_log);
                this.ObjectContext.cat_mo_log.DeleteObject(cat_mo_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'codinh_log' query.
        public IQueryable<codinh_log> GetCodinh_log()
        {
            return this.ObjectContext.codinh_log;
        }

        public void InsertCodinh_log(codinh_log codinh_log)
        {
            if ((codinh_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(codinh_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.codinh_log.AddObject(codinh_log);
            }
        }

        public void UpdateCodinh_log(codinh_log currentcodinh_log)
        {
            this.ObjectContext.codinh_log.AttachAsModified(currentcodinh_log, this.ChangeSet.GetOriginal(currentcodinh_log));
        }

        public void DeleteCodinh_log(codinh_log codinh_log)
        {
            if ((codinh_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(codinh_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.codinh_log.Attach(codinh_log);
                this.ObjectContext.codinh_log.DeleteObject(codinh_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'nganh_nghe' query.
        public IQueryable<nganh_nghe> GetNganh_nghe()
        {
            return this.ObjectContext.nganh_nghe;
        }

        public void InsertNganh_nghe(nganh_nghe nganh_nghe)
        {
            if ((nganh_nghe.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nganh_nghe, EntityState.Added);
            }
            else
            {
                this.ObjectContext.nganh_nghe.AddObject(nganh_nghe);
            }
        }

        public void UpdateNganh_nghe(nganh_nghe currentnganh_nghe)
        {
            this.ObjectContext.nganh_nghe.AttachAsModified(currentnganh_nghe, this.ChangeSet.GetOriginal(currentnganh_nghe));
        }

        public void DeleteNganh_nghe(nganh_nghe nganh_nghe)
        {
            if ((nganh_nghe.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nganh_nghe, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.nganh_nghe.Attach(nganh_nghe);
                this.ObjectContext.nganh_nghe.DeleteObject(nganh_nghe);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'dichvugiatangs' query.
        public IQueryable<dichvugiatang> GetDichvugiatangs()
        {
            return this.ObjectContext.dichvugiatangs;
        }

        public void InsertDichvugiatang(dichvugiatang dichvugiatang)
        {
            if ((dichvugiatang.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dichvugiatang, EntityState.Added);
            }
            else
            {
                this.ObjectContext.dichvugiatangs.AddObject(dichvugiatang);
            }
        }

        public void UpdateDichvugiatang(dichvugiatang currentdichvugiatang)
        {
            this.ObjectContext.dichvugiatangs.AttachAsModified(currentdichvugiatang, this.ChangeSet.GetOriginal(currentdichvugiatang));
        }

        public void DeleteDichvugiatang(dichvugiatang dichvugiatang)
        {
            if ((dichvugiatang.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dichvugiatang, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.dichvugiatangs.Attach(dichvugiatang);
                this.ObjectContext.dichvugiatangs.DeleteObject(dichvugiatang);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'dichvugiatang_log' query.
        public IQueryable<dichvugiatang_log> GetDichvugiatang_log()
        {
            return this.ObjectContext.dichvugiatang_log;
        }

        public void InsertDichvugiatang_log(dichvugiatang_log dichvugiatang_log)
        {
            if ((dichvugiatang_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dichvugiatang_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.dichvugiatang_log.AddObject(dichvugiatang_log);
            }
        }

        public void UpdateDichvugiatang_log(dichvugiatang_log currentdichvugiatang_log)
        {
            this.ObjectContext.dichvugiatang_log.AttachAsModified(currentdichvugiatang_log, this.ChangeSet.GetOriginal(currentdichvugiatang_log));
        }

        public void DeleteDichvugiatang_log(dichvugiatang_log dichvugiatang_log)
        {
            if ((dichvugiatang_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dichvugiatang_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.dichvugiatang_log.Attach(dichvugiatang_log);
                this.ObjectContext.dichvugiatang_log.DeleteObject(dichvugiatang_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'don_vi' query.
        public IQueryable<don_vi> GetDon_vi()
        {
            return this.ObjectContext.don_vi;
        }

        public void InsertDon_vi(don_vi don_vi)
        {
            if ((don_vi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(don_vi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.don_vi.AddObject(don_vi);
            }
        }

        public void UpdateDon_vi(don_vi currentdon_vi)
        {
            this.ObjectContext.don_vi.AttachAsModified(currentdon_vi, this.ChangeSet.GetOriginal(currentdon_vi));
        }

        public void DeleteDon_vi(don_vi don_vi)
        {
            if ((don_vi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(don_vi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.don_vi.Attach(don_vi);
                this.ObjectContext.don_vi.DeleteObject(don_vi);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ds_codinh' query.
        public IQueryable<ds_codinh> GetDs_codinh()
        {
            return this.ObjectContext.ds_codinh;
        }

        public void InsertDs_codinh(ds_codinh ds_codinh)
        {
            if ((ds_codinh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ds_codinh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ds_codinh.AddObject(ds_codinh);
            }
        }

        public void UpdateDs_codinh(ds_codinh currentds_codinh)
        {
            this.ObjectContext.ds_codinh.AttachAsModified(currentds_codinh, this.ChangeSet.GetOriginal(currentds_codinh));
        }

        public void DeleteDs_codinh(ds_codinh ds_codinh)
        {
            if ((ds_codinh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ds_codinh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ds_codinh.Attach(ds_codinh);
                this.ObjectContext.ds_codinh.DeleteObject(ds_codinh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'gc_mytv' query.
        public IQueryable<gc_mytv> GetGc_mytv()
        {
            return this.ObjectContext.gc_mytv;
        }

        public void InsertGc_mytv(gc_mytv gc_mytv)
        {
            if ((gc_mytv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gc_mytv, EntityState.Added);
            }
            else
            {
                this.ObjectContext.gc_mytv.AddObject(gc_mytv);
            }
        }

        public void UpdateGc_mytv(gc_mytv currentgc_mytv)
        {
            this.ObjectContext.gc_mytv.AttachAsModified(currentgc_mytv, this.ChangeSet.GetOriginal(currentgc_mytv));
        }

        public void DeleteGc_mytv(gc_mytv gc_mytv)
        {
            if ((gc_mytv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gc_mytv, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.gc_mytv.Attach(gc_mytv);
                this.ObjectContext.gc_mytv.DeleteObject(gc_mytv);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Goi_th' query.
        public IQueryable<Goi_th> GetGoi_th()
        {
            return this.ObjectContext.Goi_th;
        }

        public void InsertGoi_th(Goi_th goi_th)
        {
            if ((goi_th.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(goi_th, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Goi_th.AddObject(goi_th);
            }
        }

        public void UpdateGoi_th(Goi_th currentGoi_th)
        {
            this.ObjectContext.Goi_th.AttachAsModified(currentGoi_th, this.ChangeSet.GetOriginal(currentGoi_th));
        }

        public void DeleteGoi_th(Goi_th goi_th)
        {
            if ((goi_th.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(goi_th, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Goi_th.Attach(goi_th);
                this.ObjectContext.Goi_th.DeleteObject(goi_th);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Gphones' query.
        public IQueryable<Gphone> GetGphones()
        {
            return this.ObjectContext.Gphones;
        }

        public void InsertGphone(Gphone gphone)
        {
            if ((gphone.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gphone, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Gphones.AddObject(gphone);
            }
        }

        public void UpdateGphone(Gphone currentGphone)
        {
            this.ObjectContext.Gphones.AttachAsModified(currentGphone, this.ChangeSet.GetOriginal(currentGphone));
        }

        public void DeleteGphone(Gphone gphone)
        {
            if ((gphone.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gphone, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Gphones.Attach(gphone);
                this.ObjectContext.Gphones.DeleteObject(gphone);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Gphone_log' query.
        public IQueryable<Gphone_log> GetGphone_log()
        {
            return this.ObjectContext.Gphone_log;
        }

        public void InsertGphone_log(Gphone_log gphone_log)
        {
            if ((gphone_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gphone_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Gphone_log.AddObject(gphone_log);
            }
        }

        public void UpdateGphone_log(Gphone_log currentGphone_log)
        {
            this.ObjectContext.Gphone_log.AttachAsModified(currentGphone_log, this.ChangeSet.GetOriginal(currentGphone_log));
        }

        public void DeleteGphone_log(Gphone_log gphone_log)
        {
            if ((gphone_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gphone_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Gphone_log.Attach(gphone_log);
                this.ObjectContext.Gphone_log.DeleteObject(gphone_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'kh_mai' query.
        public IQueryable<kh_mai> GetKh_mai()
        {
            return this.ObjectContext.kh_mai;
        }

        public void InsertKh_mai(kh_mai kh_mai)
        {
            if ((kh_mai.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kh_mai, EntityState.Added);
            }
            else
            {
                this.ObjectContext.kh_mai.AddObject(kh_mai);
            }
        }

        public void UpdateKh_mai(kh_mai currentkh_mai)
        {
            this.ObjectContext.kh_mai.AttachAsModified(currentkh_mai, this.ChangeSet.GetOriginal(currentkh_mai));
        }

        public void DeleteKh_mai(kh_mai kh_mai)
        {
            if ((kh_mai.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kh_mai, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.kh_mai.Attach(kh_mai);
                this.ObjectContext.kh_mai.DeleteObject(kh_mai);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'khachhangDN' query.
        public IQueryable<khachhangDN> GetKhachhangDN()
        {
            return this.ObjectContext.khachhangDNs;
        }

        public void InsertkhachhangDN(khachhangDN khachhangDN)
        {
            if ((khachhangDN.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(khachhangDN, EntityState.Added);
            }
            else
            {
                this.ObjectContext.khachhangDNs.AddObject(khachhangDN);
            }
        }

        public void UpdateKh_mai(khachhangDN currentkhachhangDN)
        {
            this.ObjectContext.khachhangDNs.AttachAsModified(currentkhachhangDN, this.ChangeSet.GetOriginal(currentkhachhangDN));
        }

        public void DeleteKh_mai(khachhangDN khachhangDN)
        {
            if ((khachhangDN.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(khachhangDN, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.khachhangDNs.Attach(khachhangDN);
                this.ObjectContext.khachhangDNs.DeleteObject(khachhangDN);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'loai_catmo' query.
        public IQueryable<loai_catmo> GetLoai_catmo()
        {           
            return this.ObjectContext.loai_catmo;
        }

        public void InsertLoai_catmo(loai_catmo loai_catmo)
        {
            if ((loai_catmo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_catmo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.loai_catmo.AddObject(loai_catmo);
            }
        }

        public void UpdateLoai_catmo(loai_catmo currentloai_catmo)
        {
            this.ObjectContext.loai_catmo.AttachAsModified(currentloai_catmo, this.ChangeSet.GetOriginal(currentloai_catmo));
        }

        public void DeleteLoai_catmo(loai_catmo loai_catmo)
        {
            if ((loai_catmo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_catmo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.loai_catmo.Attach(loai_catmo);
                this.ObjectContext.loai_catmo.DeleteObject(loai_catmo);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'loai_kh' query.
        public IQueryable<loai_kh> GetLoai_kh()
        {
            return this.ObjectContext.loai_kh;
        }

        public void InsertLoai_kh(loai_kh loai_kh)
        {
            if ((loai_kh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_kh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.loai_kh.AddObject(loai_kh);
            }
        }

        public void UpdateLoai_kh(loai_kh currentloai_kh)
        {
            this.ObjectContext.loai_kh.AttachAsModified(currentloai_kh, this.ChangeSet.GetOriginal(currentloai_kh));
        }

        public void DeleteLoai_kh(loai_kh loai_kh)
        {
            if ((loai_kh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_kh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.loai_kh.Attach(loai_kh);
                this.ObjectContext.loai_kh.DeleteObject(loai_kh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ma_ap' query.
        public IQueryable<ma_ap> GetMa_ap()
        {
            return this.ObjectContext.ma_ap;
        }

        public void InsertMa_ap(ma_ap ma_ap)
        {
            if ((ma_ap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_ap, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ma_ap.AddObject(ma_ap);
            }
        }

        public void UpdateMa_ap(ma_ap currentma_ap)
        {
            this.ObjectContext.ma_ap.AttachAsModified(currentma_ap, this.ChangeSet.GetOriginal(currentma_ap));
        }

        public void DeleteMa_ap(ma_ap ma_ap)
        {
            if ((ma_ap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_ap, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ma_ap.Attach(ma_ap);
                this.ObjectContext.ma_ap.DeleteObject(ma_ap);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ma_duong' query.
        public IQueryable<ma_duong> GetMa_duong()
        {
            return this.ObjectContext.ma_duong;
        }

        public void InsertMa_duong(ma_duong ma_duong)
        {
            if ((ma_duong.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_duong, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ma_duong.AddObject(ma_duong);
            }
        }

        public void UpdateMa_duong(ma_duong currentma_duong)
        {
            this.ObjectContext.ma_duong.AttachAsModified(currentma_duong, this.ChangeSet.GetOriginal(currentma_duong));
        }

        public void DeleteMa_duong(ma_duong ma_duong)
        {
            if ((ma_duong.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_duong, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ma_duong.Attach(ma_duong);
                this.ObjectContext.ma_duong.DeleteObject(ma_duong);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ma_xa' query.
        public IQueryable<ma_xa> GetMa_xa()
        {
            return this.ObjectContext.ma_xa;
        }

        public void InsertMa_xa(ma_xa ma_xa)
        {
            if ((ma_xa.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_xa, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ma_xa.AddObject(ma_xa);
            }
        }

        public void UpdateMa_xa(ma_xa currentma_xa)
        {
            this.ObjectContext.ma_xa.AttachAsModified(currentma_xa, this.ChangeSet.GetOriginal(currentma_xa));
        }

        public void DeleteMa_xa(ma_xa ma_xa)
        {
            if ((ma_xa.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_xa, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ma_xa.Attach(ma_xa);
                this.ObjectContext.ma_xa.DeleteObject(ma_xa);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'menus' query.
        public IQueryable<menu> GetMenus()
        {
            return this.ObjectContext.menus;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'mytvs' query.
        public IQueryable<mytv> GetMytvs()
        {
            return this.ObjectContext.mytvs;
        }

        public void InsertMytv(mytv mytv)
        {
            if ((mytv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mytv, EntityState.Added);
            }
            else
            {
                this.ObjectContext.mytvs.AddObject(mytv);
            }
        }

        public void UpdateMytv(mytv currentmytv)
        {
            this.ObjectContext.mytvs.AttachAsModified(currentmytv, this.ChangeSet.GetOriginal(currentmytv));
        }

        public void DeleteMytv(mytv mytv)
        {
            if ((mytv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mytv, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.mytvs.Attach(mytv);
                this.ObjectContext.mytvs.DeleteObject(mytv);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'mytv_log' query.
        public IQueryable<mytv_log> GetMytv_log()
        {
            return this.ObjectContext.mytv_log;
        }

        public void InsertMytv_log(mytv_log mytv_log)
        {
            if ((mytv_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mytv_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.mytv_log.AddObject(mytv_log);
            }
        }

        public void UpdateMytv_log(mytv_log currentmytv_log)
        {
            this.ObjectContext.mytv_log.AttachAsModified(currentmytv_log, this.ChangeSet.GetOriginal(currentmytv_log));
        }

        public void DeleteMytv_log(mytv_log mytv_log)
        {
            if ((mytv_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mytv_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.mytv_log.Attach(mytv_log);
                this.ObjectContext.mytv_log.DeleteObject(mytv_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'nhom_kh' query.
        public IQueryable<nhom_kh> GetNhom_kh()
        {
            return this.ObjectContext.nhom_kh;
        }

        public void InsertNhom_kh(nhom_kh nhom_kh)
        {
            if ((nhom_kh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhom_kh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.nhom_kh.AddObject(nhom_kh);
            }
        }

        public void UpdateNhom_kh(nhom_kh currentnhom_kh)
        {
            this.ObjectContext.nhom_kh.AttachAsModified(currentnhom_kh, this.ChangeSet.GetOriginal(currentnhom_kh));
        }

        public void DeleteNhom_kh(nhom_kh nhom_kh)
        {
            if ((nhom_kh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhom_kh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.nhom_kh.Attach(nhom_kh);
                this.ObjectContext.nhom_kh.DeleteObject(nhom_kh);
            }
        }

        public IQueryable<chungloaicap> GetChungloaicaps()
        {
            return this.ObjectContext.chungloaicaps;
        }

        public IQueryable<thiet_bi> GetThiet_bis()
        {
            return this.ObjectContext.thiet_bi;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'nv_thuethu' query.
        public IQueryable<nv_thuethu> GetNv_thuethu()
        {
            return this.ObjectContext.nv_thuethu;
        }

        public void InsertNv_thuethu(nv_thuethu nv_thuethu)
        {
            if ((nv_thuethu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nv_thuethu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.nv_thuethu.AddObject(nv_thuethu);
            }
        }

        public void UpdateNv_thuethu(nv_thuethu currentnv_thuethu)
        {
            this.ObjectContext.nv_thuethu.AttachAsModified(currentnv_thuethu, this.ChangeSet.GetOriginal(currentnv_thuethu));
        }

        public void DeleteNv_thuethu(nv_thuethu nv_thuethu)
        {
            if ((nv_thuethu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nv_thuethu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.nv_thuethu.Attach(nv_thuethu);
                this.ObjectContext.nv_thuethu.DeleteObject(nv_thuethu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tien_tb' query.
        public IQueryable<tien_tb> GetTien_tb()
        {
            return this.ObjectContext.tien_tb;
        }

        public void InsertTien_tb(tien_tb tien_tb)
        {
            if ((tien_tb.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tien_tb, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tien_tb.AddObject(tien_tb);
            }
        }

        public void UpdateTien_tb(tien_tb currenttien_tb)
        {
            this.ObjectContext.tien_tb.AttachAsModified(currenttien_tb, this.ChangeSet.GetOriginal(currenttien_tb));
        }

        public void DeleteTien_tb(tien_tb tien_tb)
        {
            if ((tien_tb.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tien_tb, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tien_tb.Attach(tien_tb);
                this.ObjectContext.tien_tb.DeleteObject(tien_tb);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tram_vt' query.
        public IQueryable<tram_vt> GetTram_vt()
        {
            return this.ObjectContext.tram_vt;
        }

        public void InsertTram_vt(tram_vt tram_vt)
        {
            if ((tram_vt.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tram_vt, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tram_vt.AddObject(tram_vt);
            }
        }

        public void UpdateTram_vt(tram_vt currenttram_vt)
        {
            this.ObjectContext.tram_vt.AttachAsModified(currenttram_vt, this.ChangeSet.GetOriginal(currenttram_vt));
        }

        public void DeleteTram_vt(tram_vt tram_vt)
        {
            if ((tram_vt.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tram_vt, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tram_vt.Attach(tram_vt);
                this.ObjectContext.tram_vt.DeleteObject(tram_vt);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'users' query.
        public IQueryable<user> GetUsers()
        {
            return this.ObjectContext.users;
        }

        public void InsertUser(user user)
        {
            if ((user.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(user, EntityState.Added);
            }
            else
            {
                this.ObjectContext.users.AddObject(user);
            }
        }

        public void UpdateUser(user currentuser)
        {
            this.ObjectContext.users.AttachAsModified(currentuser, this.ChangeSet.GetOriginal(currentuser));
        }

        public void DeleteUser(user user)
        {
            if ((user.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(user, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.users.Attach(user);
                this.ObjectContext.users.DeleteObject(user);
            }
        }

        public IQueryable<users_log> GetUsers_log()
        {
            return this.ObjectContext.users_log;
        }

        public void InsertUsers_log(users_log users_log)
        {
            if ((users_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(users_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.users_log.AddObject(users_log);
            }
        }

        public void UpdateUsers_log(users_log currentusers_log)
        {
            this.ObjectContext.users_log.AttachAsModified(currentusers_log, this.ChangeSet.GetOriginal(currentusers_log));
        }

        public void DeleteUsers_log(users_log users_log)
        {
            if ((users_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(users_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.users_log.Attach(users_log);
                this.ObjectContext.users_log.DeleteObject(users_log);
            }
        }


        public IQueryable<nhanvien_cs> Getnhanvien_cs()
        {
            return this.ObjectContext.nhanvien_cs;
        }

        public void InsertNhanvien_cs(nhanvien_cs nhanvien_cs)
        {
            if ((nhanvien_cs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhanvien_cs, EntityState.Added);
            }
            else
            {
                this.ObjectContext.nhanvien_cs.AddObject(nhanvien_cs);
            }
        }

        public void UpdateNhanvien_cs(nhanvien_cs currentnhanvien_cs)
        {
            this.ObjectContext.nhanvien_cs.AttachAsModified(currentnhanvien_cs, this.ChangeSet.GetOriginal(currentnhanvien_cs));
        }

        public void DeleteNhanvien_cs(nhanvien_cs nhanvien_cs)
        {
            if ((nhanvien_cs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhanvien_cs, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.nhanvien_cs.Attach(nhanvien_cs);
                this.ObjectContext.nhanvien_cs.DeleteObject(nhanvien_cs);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'goicuoc_int' query.
        public IQueryable<goicuoc_int> GetGoicuoc_int()
        {
            return this.ObjectContext.goicuoc_int;
        }

        public void InsertGoicuoc_int(goicuoc_int goicuoc_int)
        {
            if ((goicuoc_int.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(goicuoc_int, EntityState.Added);
            }
            else
            {
                this.ObjectContext.goicuoc_int.AddObject(goicuoc_int);
            }
        }

        public void UpdateGoicuoc_int(goicuoc_int currentgoicuoc_int)
        {
            this.ObjectContext.goicuoc_int.AttachAsModified(currentgoicuoc_int, this.ChangeSet.GetOriginal(currentgoicuoc_int));
        }

        public void DeleteGoicuoc_int(goicuoc_int goicuoc_int)
        {
            if ((goicuoc_int.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(goicuoc_int, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.goicuoc_int.Attach(goicuoc_int);
                this.ObjectContext.goicuoc_int.DeleteObject(goicuoc_int);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'internets' query.
        public IQueryable<internet> GetInternets()
        {
            return this.ObjectContext.internets;
        }

        public void InsertInternet(internet internet)
        {
            if ((internet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.internets.AddObject(internet);
            }
        }

        public void UpdateInternet(internet currentinternet)
        {
            this.ObjectContext.internets.AttachAsModified(currentinternet, this.ChangeSet.GetOriginal(currentinternet));
        }

        public void DeleteInternet(internet internet)
        {
            if ((internet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.internets.Attach(internet);
                this.ObjectContext.internets.DeleteObject(internet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'internet_log' query.
        public IQueryable<internet_log> GetInternet_log()
        {
            return this.ObjectContext.internet_log;
        }

        public void InsertInternet_log(internet_log internet_log)
        {
            if ((internet_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internet_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.internet_log.AddObject(internet_log);
            }
        }

        public void UpdateInternet_log(internet_log currentinternet_log)
        {
            this.ObjectContext.internet_log.AttachAsModified(currentinternet_log, this.ChangeSet.GetOriginal(currentinternet_log));
        }

        public void DeleteInternet_log(internet_log internet_log)
        {
            if ((internet_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(internet_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.internet_log.Attach(internet_log);
                this.ObjectContext.internet_log.DeleteObject(internet_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ma_diaban' query.
        public IQueryable<ma_diaban> GetMa_diaban()
        {
            return this.ObjectContext.ma_diaban;
        }

        public void InsertMa_diaban(ma_diaban ma_diaban)
        {
            if ((ma_diaban.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_diaban, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ma_diaban.AddObject(ma_diaban);
            }
        }

        public void UpdateMa_diaban(ma_diaban currentma_diaban)
        {
            this.ObjectContext.ma_diaban.AttachAsModified(currentma_diaban, this.ChangeSet.GetOriginal(currentma_diaban));
        }

        public void DeleteMa_diaban(ma_diaban ma_diaban)
        {
            if ((ma_diaban.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ma_diaban, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ma_diaban.Attach(ma_diaban);
                this.ObjectContext.ma_diaban.DeleteObject(ma_diaban);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'toc_do' query.
        public IQueryable<toc_do> GetToc_do()
        {
            return this.ObjectContext.toc_do;
        }

        public void InsertToc_do(toc_do toc_do)
        {
            if ((toc_do.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(toc_do, EntityState.Added);
            }
            else
            {
                this.ObjectContext.toc_do.AddObject(toc_do);
            }
        }

        public void UpdateToc_do(toc_do currenttoc_do)
        {
            this.ObjectContext.toc_do.AttachAsModified(currenttoc_do, this.ChangeSet.GetOriginal(currenttoc_do));
        }

        public void DeleteToc_do(toc_do toc_do)
        {
            if ((toc_do.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(toc_do, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.toc_do.Attach(toc_do);
                this.ObjectContext.toc_do.DeleteObject(toc_do);
            }
        }

        public IQueryable<loai_dv> GetLoai_dv()
        {
            return this.ObjectContext.loai_dv;
        }

        public void InsertLoai_dv(loai_dv loai_dv)
        {
            if ((loai_dv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_dv, EntityState.Added);
            }
            else
            {
                this.ObjectContext.loai_dv.AddObject(loai_dv);
            }
        }

        public void UpdateLoai_dv(loai_dv currentloai_dv)
        {
            this.ObjectContext.loai_dv.AttachAsModified(currentloai_dv, this.ChangeSet.GetOriginal(currentloai_dv));
        }

        public void DeleteLoai_dv(loai_dv loai_dv)
        {
            if ((loai_dv.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_dv, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.loai_dv.Attach(loai_dv);
                this.ObjectContext.loai_dv.DeleteObject(loai_dv);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'kh_uutien' query.
        public IQueryable<kh_uutien> GetKh_uutien()
        {
            return this.ObjectContext.kh_uutien;
        }

        public void InsertKh_uutien(kh_uutien kh_uutien)
        {
            if ((kh_uutien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kh_uutien, EntityState.Added);
            }
            else
            {
                this.ObjectContext.kh_uutien.AddObject(kh_uutien);
            }
        }

        public void UpdateKh_uutien(kh_uutien currentkh_uutien)
        {
            this.ObjectContext.kh_uutien.AttachAsModified(currentkh_uutien, this.ChangeSet.GetOriginal(currentkh_uutien));
        }

        public void DeleteKh_uutien(kh_uutien kh_uutien)
        {
            if ((kh_uutien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kh_uutien, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.kh_uutien.Attach(kh_uutien);
                this.ObjectContext.kh_uutien.DeleteObject(kh_uutien);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'kh_uutien' query.
        public IQueryable<thongbao> GetThongbao()
        {
            return this.ObjectContext.thongbaos;
        }

        public void InsertThongbao(thongbao thongbao)
        {
            if ((thongbao.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thongbao, EntityState.Added);
            }
            else
            {
                this.ObjectContext.thongbaos.AddObject(thongbao);
            }
        }

        public void UpdateThongbao(thongbao currentthongbao)
        {
            this.ObjectContext.thongbaos.AttachAsModified(currentthongbao, this.ChangeSet.GetOriginal(currentthongbao));
        }

        public void DeleteThongbao(thongbao thongbao)
        {
            if ((thongbao.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thongbao, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.thongbaos.Attach(thongbao);
                this.ObjectContext.thongbaos.DeleteObject(thongbao);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'lydocat' query.
        public IQueryable<lydocat> GetLydocat()
        {
            return this.ObjectContext.lydocats;
        }

        public void InsertLydocat(lydocat lydocat)
        {
            if ((lydocat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(lydocat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.lydocats.AddObject(lydocat);
            }
        }

        public void UpdateLydocat(lydocat currentlydocat)
        {
            this.ObjectContext.lydocats.AttachAsModified(currentlydocat, this.ChangeSet.GetOriginal(currentlydocat));
        }

        public void DeleteLydocat(lydocat lydocat)
        {
            if ((lydocat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(lydocat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.lydocats.Attach(lydocat);
                this.ObjectContext.lydocats.DeleteObject(lydocat);
            }
        }

        public IQueryable<ds_119> GetDs_119()
        {
            return this.ObjectContext.ds_119;
        }

        public void InsertDs_119(ds_119 ds_119)
        {
            if ((ds_119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ds_119, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ds_119.AddObject(ds_119);
            }
        }

        public void UpdateDs_119(ds_119 currentds_119)
        {
            this.ObjectContext.ds_119.AttachAsModified(currentds_119, this.ChangeSet.GetOriginal(currentds_119));
        }

        public void DeleteDs_119(ds_119 ds_119)
        {
            if ((ds_119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ds_119, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ds_119.Attach(ds_119);
                this.ObjectContext.ds_119.DeleteObject(ds_119);
            }
        }


        public IQueryable<dsw_119> GetDsw_119()
        {
            return this.ObjectContext.dsw_119;
        }

        public void InsertDs_119(dsw_119 dsw_119)
        {
            if ((dsw_119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dsw_119, EntityState.Added);
            }
            else
            {
                this.ObjectContext.dsw_119.AddObject(dsw_119);
            }
        }

        public void UpdateDsw_119(dsw_119 currentdsw_119)
        {
            this.ObjectContext.dsw_119.AttachAsModified(currentdsw_119, this.ChangeSet.GetOriginal(currentdsw_119));
        }

        public void DeleteDs_119(dsw_119 dsw_119)
        {
            if ((dsw_119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dsw_119, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.dsw_119.Attach(dsw_119);
                this.ObjectContext.dsw_119.DeleteObject(dsw_119);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tkloai119' query.
        public IQueryable<tkloai119> GetTkloai119()
        {
            return this.ObjectContext.tkloai119;
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'C119TVPrefix' query.
        public IQueryable<C119TVPrefix> GetC119TVPrefix()
        {
            return this.ObjectContext.C119TVPrefix;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'CnfgStatus119' query.
        public IQueryable<CnfgStatus119> GetCnfgStatus119()
        {
            return this.ObjectContext.CnfgStatus119;
        }

        public void InsertCnfgStatus119(CnfgStatus119 cnfgStatus119)
        {
            if ((cnfgStatus119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cnfgStatus119, EntityState.Added);
            }
            else
            {
                this.ObjectContext.CnfgStatus119.AddObject(cnfgStatus119);
            }
        }

        public void UpdateCnfgStatus119(CnfgStatus119 currentCnfgStatus119)
        {
            this.ObjectContext.CnfgStatus119.AttachAsModified(currentCnfgStatus119, this.ChangeSet.GetOriginal(currentCnfgStatus119));
        }

        public void DeleteCnfgStatus119(CnfgStatus119 cnfgStatus119)
        {
            if ((cnfgStatus119.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(cnfgStatus119, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.CnfgStatus119.Attach(cnfgStatus119);
                this.ObjectContext.CnfgStatus119.DeleteObject(cnfgStatus119);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'nhanvien_cs_log' query.
        public IQueryable<nhanvien_cs_log> GetNhanvien_cs_log()
        {
            return this.ObjectContext.nhanvien_cs_log;
        }

        public void InsertNhanvien_cs_log(nhanvien_cs_log nhanvien_cs_log)
        {
            if ((nhanvien_cs_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhanvien_cs_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.nhanvien_cs_log.AddObject(nhanvien_cs_log);
            }
        }

        public void UpdateNhanvien_cs_log(nhanvien_cs_log currentnhanvien_cs_log)
        {
            this.ObjectContext.nhanvien_cs_log.AttachAsModified(currentnhanvien_cs_log, this.ChangeSet.GetOriginal(currentnhanvien_cs_log));
        }

        public void DeleteNhanvien_cs_log(nhanvien_cs_log nhanvien_cs_log)
        {
            if ((nhanvien_cs_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(nhanvien_cs_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.nhanvien_cs_log.Attach(nhanvien_cs_log);
                this.ObjectContext.nhanvien_cs_log.DeleteObject(nhanvien_cs_log);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'khoes' query.
        public IQueryable<kho> GetKhoes()
        {
            return this.ObjectContext.khoes;
        }

        public void InsertKho(kho kho)
        {
            if ((kho.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kho, EntityState.Added);
            }
            else
            {
                this.ObjectContext.khoes.AddObject(kho);
            }
        }

        public void UpdateKho(kho currentkho)
        {
            this.ObjectContext.khoes.AttachAsModified(currentkho, this.ChangeSet.GetOriginal(currentkho));
        }

        public void DeleteKho(kho kho)
        {
            if ((kho.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kho, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.khoes.Attach(kho);
                this.ObjectContext.khoes.DeleteObject(kho);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'thuhoi_log' query.
        public IQueryable<thuhoi_log> GetThuhoi_log()
        {
            return this.ObjectContext.thuhoi_log;
        }

        public void InsertThuhoi_log(thuhoi_log thuhoi_log)
        {
            if ((thuhoi_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thuhoi_log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.thuhoi_log.AddObject(thuhoi_log);
            }
        }

        public void UpdateThuhoi_log(thuhoi_log currentthuhoi_log)
        {
            this.ObjectContext.thuhoi_log.AttachAsModified(currentthuhoi_log, this.ChangeSet.GetOriginal(currentthuhoi_log));
        }

        public void DeleteThuhoi_log(thuhoi_log thuhoi_log)
        {
            if ((thuhoi_log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thuhoi_log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.thuhoi_log.Attach(thuhoi_log);
                this.ObjectContext.thuhoi_log.DeleteObject(thuhoi_log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'thuhoi_thietbi' query.
        public IQueryable<thuhoi_thietbi> GetThuhoi_thietbi()
        {
            return this.ObjectContext.thuhoi_thietbi;
        }

        public void InsertThuhoi_thietbi(thuhoi_thietbi thuhoi_thietbi)
        {
            if ((thuhoi_thietbi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thuhoi_thietbi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.thuhoi_thietbi.AddObject(thuhoi_thietbi);
            }
        }

        public void UpdateThuhoi_thietbi(thuhoi_thietbi currentthuhoi_thietbi)
        {
            this.ObjectContext.thuhoi_thietbi.AttachAsModified(currentthuhoi_thietbi, this.ChangeSet.GetOriginal(currentthuhoi_thietbi));
        }

        public void DeleteThuhoi_thietbi(thuhoi_thietbi thuhoi_thietbi)
        {
            if ((thuhoi_thietbi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(thuhoi_thietbi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.thuhoi_thietbi.Attach(thuhoi_thietbi);
                this.ObjectContext.thuhoi_thietbi.DeleteObject(thuhoi_thietbi);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'kenh_thue_rieng' query.
        public IQueryable<kenh_thue_rieng> GetKenh_thue_rieng()
        {
            return this.ObjectContext.kenh_thue_rieng;
        }

        public void InsertKenh_thue_rieng(kenh_thue_rieng kenh_thue_rieng)
        {
            if ((kenh_thue_rieng.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kenh_thue_rieng, EntityState.Added);
            }
            else
            {
                this.ObjectContext.kenh_thue_rieng.AddObject(kenh_thue_rieng);
            }
        }

        public void UpdateKenh_thue_rieng(kenh_thue_rieng currentkenh_thue_rieng)
        {
            this.ObjectContext.kenh_thue_rieng.AttachAsModified(currentkenh_thue_rieng, this.ChangeSet.GetOriginal(currentkenh_thue_rieng));
        }

        public void DeleteKenh_thue_rieng(kenh_thue_rieng kenh_thue_rieng)
        {
            if ((kenh_thue_rieng.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kenh_thue_rieng, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.kenh_thue_rieng.Attach(kenh_thue_rieng);
                this.ObjectContext.kenh_thue_rieng.DeleteObject(kenh_thue_rieng);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'loai_kenh' query.
        public IQueryable<loai_kenh> GetLoai_kenh()
        {
            return this.ObjectContext.loai_kenh;
        }

        public void InsertLoai_kenh(loai_kenh loai_kenh)
        {
            if ((loai_kenh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_kenh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.loai_kenh.AddObject(loai_kenh);
            }
        }

        public void UpdateLoai_kenh(loai_kenh currentloai_kenh)
        {
            this.ObjectContext.loai_kenh.AttachAsModified(currentloai_kenh, this.ChangeSet.GetOriginal(currentloai_kenh));
        }

        public void DeleteLoai_kenh(loai_kenh loai_kenh)
        {
            if ((loai_kenh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(loai_kenh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.loai_kenh.Attach(loai_kenh);
                this.ObjectContext.loai_kenh.DeleteObject(loai_kenh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'td_kenhrieng' query.
        public IQueryable<td_kenhrieng> GetTd_kenhrieng()
        {
            return this.ObjectContext.td_kenhrieng;
        }

        public void InsertTd_kenhrieng(td_kenhrieng td_kenhrieng)
        {
            if ((td_kenhrieng.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(td_kenhrieng, EntityState.Added);
            }
            else
            {
                this.ObjectContext.td_kenhrieng.AddObject(td_kenhrieng);
            }
        }

        public void UpdateTd_kenhrieng(td_kenhrieng currenttd_kenhrieng)
        {
            this.ObjectContext.td_kenhrieng.AttachAsModified(currenttd_kenhrieng, this.ChangeSet.GetOriginal(currenttd_kenhrieng));
        }

        public void DeleteTd_kenhrieng(td_kenhrieng td_kenhrieng)
        {
            if ((td_kenhrieng.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(td_kenhrieng, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.td_kenhrieng.Attach(td_kenhrieng);
                this.ObjectContext.td_kenhrieng.DeleteObject(td_kenhrieng);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'dssuaxong_119' query.
        public IQueryable<dssuaxong_119> GetDssuaxong_119()
        {
            return this.ObjectContext.dssuaxong_119;
        }

        public IQueryable<rp_dt_diaban> GetRp_dt_diaban()
        {
            return this.ObjectContext.rp_dt_diaban;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tk119' query.
        public IQueryable<tk119> GetTk119()
        {
            return this.ObjectContext.tk119;
        }

        public IQueryable<rp_slg_diaban> GetRp_slg_diaban()
        {
            return this.ObjectContext.rp_slg_diaban;
        }


        public IQueryable<rp_tktonghop> GetRp_tktonghop()
        {
            return this.ObjectContext.rp_tktonghop;
        }

        public IQueryable<rp_tklydocat> GetRp_tklydocat()
        {
            return this.ObjectContext.rp_tklydocat;
        }

        public IQueryable<rp_dsgan> GetRp_dsgan()
        {
            return this.ObjectContext.rp_dsgan;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'chi_tieu_huyen' query.
        public IQueryable<chi_tieu_huyen> GetChi_tieu_huyen()
        {
            return this.ObjectContext.chi_tieu_huyen;
        }

        public void InsertChi_tieu_huyen(chi_tieu_huyen chi_tieu_huyen)
        {
            if ((chi_tieu_huyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(chi_tieu_huyen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.chi_tieu_huyen.AddObject(chi_tieu_huyen);
            }
        }

        public void UpdateChi_tieu_huyen(chi_tieu_huyen currentchi_tieu_huyen)
        {
            this.ObjectContext.chi_tieu_huyen.AttachAsModified(currentchi_tieu_huyen, this.ChangeSet.GetOriginal(currentchi_tieu_huyen));
        }

        public void DeleteChi_tieu_huyen(chi_tieu_huyen chi_tieu_huyen)
        {
            if ((chi_tieu_huyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(chi_tieu_huyen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.chi_tieu_huyen.Attach(chi_tieu_huyen);
                this.ObjectContext.chi_tieu_huyen.DeleteObject(chi_tieu_huyen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'khois' query.
        public IQueryable<khoi> GetKhois()
        {
            return this.ObjectContext.khois;
        }

        public void InsertKhoi(khoi khoi)
        {
            if ((khoi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(khoi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.khois.AddObject(khoi);
            }
        }

        public void UpdateKhoi(khoi currentkhoi)
        {
            this.ObjectContext.khois.AttachAsModified(currentkhoi, this.ChangeSet.GetOriginal(currentkhoi));
        }

        public void DeleteKhoi(khoi khoi)
        {
            if ((khoi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(khoi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.khois.Attach(khoi);
                this.ObjectContext.khois.DeleteObject(khoi);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'KPIs' query.
        public IQueryable<KPI> GetKPIs()
        {
            return this.ObjectContext.KPIs;
        }

        public void InsertKPI(KPI kPI)
        {
            if ((kPI.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kPI, EntityState.Added);
            }
            else
            {
                this.ObjectContext.KPIs.AddObject(kPI);
            }
        }

        public void UpdateKPI(KPI currentKPI)
        {
            this.ObjectContext.KPIs.AttachAsModified(currentKPI, this.ChangeSet.GetOriginal(currentKPI));
        }

        public void DeleteKPI(KPI kPI)
        {
            if ((kPI.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kPI, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.KPIs.Attach(kPI);
                this.ObjectContext.KPIs.DeleteObject(kPI);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'KPOs' query.
        public IQueryable<KPOs> GetKPOs()
        {
            return this.ObjectContext.KPOs;
        }

        public void InsertKPOs(KPOs kPOs)
        {
            if ((kPOs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kPOs, EntityState.Added);
            }
            else
            {
                this.ObjectContext.KPOs.AddObject(kPOs);
            }
        }

        public void UpdateKPOs(KPOs currentKPOs)
        {
            this.ObjectContext.KPOs.AttachAsModified(currentKPOs, this.ChangeSet.GetOriginal(currentKPOs));
        }

        public void DeleteKPOs(KPOs kPOs)
        {
            if ((kPOs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(kPOs, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.KPOs.Attach(kPOs);
                this.ObjectContext.KPOs.DeleteObject(kPOs);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Phong_huyen' query.
        public IQueryable<Phong_huyen> GetPhong_huyen()
        {
            return this.ObjectContext.Phong_huyen;
        }

        public void InsertPhong_huyen(Phong_huyen phong_huyen)
        {
            if ((phong_huyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(phong_huyen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Phong_huyen.AddObject(phong_huyen);
            }
        }

        public void UpdatePhong_huyen(Phong_huyen currentPhong_huyen)
        {
            this.ObjectContext.Phong_huyen.AttachAsModified(currentPhong_huyen, this.ChangeSet.GetOriginal(currentPhong_huyen));
        }

        public void DeletePhong_huyen(Phong_huyen phong_huyen)
        {
            if ((phong_huyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(phong_huyen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Phong_huyen.Attach(phong_huyen);
                this.ObjectContext.Phong_huyen.DeleteObject(phong_huyen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vien_canh' query.
        public IQueryable<vien_canh> GetVien_canh()
        {
            return this.ObjectContext.vien_canh;
        }

        public void InsertVien_canh(vien_canh vien_canh)
        {
            if ((vien_canh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vien_canh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vien_canh.AddObject(vien_canh);
            }
        }

        public void UpdateVien_canh(vien_canh currentvien_canh)
        {
            this.ObjectContext.vien_canh.AttachAsModified(currentvien_canh, this.ChangeSet.GetOriginal(currentvien_canh));
        }

        public void DeleteVien_canh(vien_canh vien_canh)
        {
            if ((vien_canh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vien_canh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vien_canh.Attach(vien_canh);
                this.ObjectContext.vien_canh.DeleteObject(vien_canh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'chi_tieu_ca_nhan' query.
        public IQueryable<chi_tieu_ca_nhan> GetChi_tieu_ca_nhan()
        {
            return this.ObjectContext.chi_tieu_ca_nhan;
        }

        public void InsertChi_tieu_ca_nhan(chi_tieu_ca_nhan chi_tieu_ca_nhan)
        {
            if ((chi_tieu_ca_nhan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(chi_tieu_ca_nhan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.chi_tieu_ca_nhan.AddObject(chi_tieu_ca_nhan);
            }
        }

        public void UpdateChi_tieu_ca_nhan(chi_tieu_ca_nhan currentchi_tieu_ca_nhan)
        {
            this.ObjectContext.chi_tieu_ca_nhan.AttachAsModified(currentchi_tieu_ca_nhan, this.ChangeSet.GetOriginal(currentchi_tieu_ca_nhan));
        }

        public void DeleteChi_tieu_ca_nhan(chi_tieu_ca_nhan chi_tieu_ca_nhan)
        {
            if ((chi_tieu_ca_nhan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(chi_tieu_ca_nhan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.chi_tieu_ca_nhan.Attach(chi_tieu_ca_nhan);
                this.ObjectContext.chi_tieu_ca_nhan.DeleteObject(chi_tieu_ca_nhan);
            }
        }

       
       
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'sKPIs' query.
        public IQueryable<sKPI> GetSKPIs()
        {
            return this.ObjectContext.sKPIs;
        }

        public void InsertSKPI(sKPI sKPI)
        {
            if ((sKPI.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sKPI, EntityState.Added);
            }
            else
            {
                this.ObjectContext.sKPIs.AddObject(sKPI);
            }
        }

        public void UpdateSKPI(sKPI currentsKPI)
        {
            this.ObjectContext.sKPIs.AttachAsModified(currentsKPI, this.ChangeSet.GetOriginal(currentsKPI));
        }

        public void DeleteSKPI(sKPI sKPI)
        {
            if ((sKPI.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sKPI, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.sKPIs.Attach(sKPI);
                this.ObjectContext.sKPIs.DeleteObject(sKPI);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'sKPOes' query.
        public IQueryable<sKPO> GetSKPOes()
        {
            return this.ObjectContext.sKPOes;
        }

        public void InsertSKPO(sKPO sKPO)
        {
            if ((sKPO.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sKPO, EntityState.Added);
            }
            else
            {
                this.ObjectContext.sKPOes.AddObject(sKPO);
            }
        }

        public void UpdateSKPO(sKPO currentsKPO)
        {
            this.ObjectContext.sKPOes.AttachAsModified(currentsKPO, this.ChangeSet.GetOriginal(currentsKPO));
        }

        public void DeleteSKPO(sKPO sKPO)
        {
            if ((sKPO.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sKPO, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.sKPOes.Attach(sKPO);
                this.ObjectContext.sKPOes.DeleteObject(sKPO);
            }
        }

        public IQueryable<maxmakhachhang> Getmaxmakhachhang(string m_ma) // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.ds_codinh
                           where t.ma_kh.Substring(0, 7) == m_ma
                           select new
                           {
                               Column1 = t.ma_kh.Substring(t.ma_kh.Trim().Length - 6, 6),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        

        public IQueryable<maxmakhachhang> Getmaxmakhachhanggp(string m_ma) // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.Gphones
                           where t.ma_kh.Substring(0, 7) == m_ma
                           select new
                           {
                               Column1 = t.ma_kh.Substring(t.ma_kh.Trim().Length - 5, 5),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Getmaxmakhachhangmy(string m_ma) // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.mytvs
                           where t.ma_kh.Substring(0, 7) == m_ma
                           select new
                           {
                               Column1 = t.ma_kh.Substring(t.ma_kh.Trim().Length - 5, 5),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Getmaxmakhachhangint(string m_ma) // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.internets
                           where t.ma_kh.Substring(0, 8) == m_ma + "I" || t.ma_kh.Substring(0, 8) == m_ma+"F"
                           select new
                           {
                               Column1 = t.ma_kh.Substring(t.ma_kh.Trim().Length - 5, 5),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> GetidgoicuocCD() // lay ma goi cuoc
        {
            var qr = (from t in
                          (from t in this.ObjectContext.ds_codinh
                           where t.id_goicuoc.Substring(0, 1) == "1"
                           select new
                           {
                               Column1 = t.id_goicuoc,
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> GetidgoicuocGP() // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.Gphones
                           where t.id_goicuoc.Substring(0, 1) == "2"
                           select new
                           {
                               Column1 = t.id_goicuoc,
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1)}
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> GetidgoicuocINT() // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.internets
                           where t.id_goicuoc.Substring(0, 1) == "3"
                           select new
                           {
                               Column1 = t.id_goicuoc,
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1)}
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> GetidgoicuocMY() // lay max ma khach hang
        {
            var qr = (from t in
                          (from t in this.ObjectContext.mytvs
                          where t.id_goicuoc.Substring(0,1) == "4"
                           select new
                           {
                               Column1 = t.id_goicuoc,
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1)}
                      );
            return qr;
        }


        public IQueryable<maxmakhachhang> Gethopdong(string m_ma) // lay max sohopdong
        {
            var qr = (from t in
                          (from t in this.ObjectContext.ds_codinh
                           where t.sohopdong.Substring(t.sohopdong.Trim().Length - 6, 6) == m_ma
                           select new
                           {
                               Column1 = t.sohopdong.Substring(0, 6),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Gethopdonggp(string m_ma) // lay max sohopdong
        {
            var qr = (from t in
                          (from t in this.ObjectContext.Gphones
                           where t.sohopdong.Substring(t.sohopdong.Trim().Length - 8, 8) == m_ma
                           select new
                           {
                               Column1 = t.sohopdong.Substring(0, 6),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Gethopdongmy(string m_ma) // lay max sohopdong
        {
            var qr = (from t in
                          (from t in this.ObjectContext.mytvs
                           where t.sohopdong.Substring(t.sohopdong.Trim().Length - 8, 8) == m_ma
                           select new
                           {
                               Column1 = t.sohopdong.Substring(0, 6),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Gethopdongint(string m_ma) // lay max sohopdong
        {
            var qr = (from t in
                          (from t in this.ObjectContext.internets
                          // where t.sohopdong.Substring(t.sohopdong.Trim().Length - 8, 8) == m_ma
                           where t.sohopdong.Trim().Substring(0, 3) == m_ma 
                           select new
                           {
                             //Column1 = t.sohopdong.Trim().Substring(3, t.sohopdong.Trim().Length - 3).Substring(0,t.sohopdong.Trim().Substring(3, t.sohopdong.Trim().Length - 3).Length-10),                                                           
                               Column1 = t.sohopdong.Trim().Substring(3, 6),                                                           
                              Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                      );
            return qr;
        }

        public IQueryable<maxmakhachhang> Get119int(string m_ma) // lay max so bao 119
        {
            var qr = (from t in
                              (from t in this.ObjectContext.internets
                               where t.so_119.Trim().Substring(0, 2) == m_ma
                               select new
                               {
                                   Column1 = t.so_119.Trim().Substring(2, 5),
                                   Dummy = "x"
                               })
                          group t by new { t.Dummy } into g
                          select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                          );
          
            return qr;
        }

        //SELECT  [119TVLOG].sDamagedPhoneNo, [119TVGroup].sName, [119TVLOG].sCallerNo,[119TVLOG].dtfinished, dstb.ten_dkdb, dstb.dc_tbld, [119TVLOG].dtRecvTime,[119TVLOG].sNotes,[119TVLOG].ID FROM [119TVLOG] LEFT OUTER JOIN [119TVGroup] ON [119TVLOG].nGroup = [119TVGroup].nGroupId LEFT OUTER JOIN CnfgStatus119 ON [119TVLOG].iStatusID = CnfgStatus119.iStatusID LEFT OUTER JOIN dstb ON [119TVLOG].sDamagedPhoneNo = dstb.so_dt where (bChecked = 0 and bFinished = 0) and ([119TVLOG].iStatus = 0)  order by dtRecvTime ASC
        public IQueryable<maxmakhachhang> Get119Mytv(string m_ma) // lay max so bao 119
        {
            var qr = (from t in
                          (from t in this.ObjectContext.mytvs
                           where t.so_119.Trim().Substring(0, 2) == m_ma
                           select new
                           {
                               Column1 = t.so_119.Trim().Substring(2, 5),
                               Dummy = "x"
                           })
                      group t by new { t.Dummy } into g
                      select new maxmakhachhang { maxmakh = g.Max(p => p.Column1) }
                          );
         
            return qr;
        }


        public IQueryable<loaikh> GetLoaikh()
        {
            var qr = (from a in this.ObjectContext.loai_kh                
                      select new loaikh { id = a.id, maloai = a.maloai.Trim(),ma_nghe=a.ma_nghe, mota = a.mota.Trim(), pl = a.pl });
            return qr;
            // return this.ObjectContext.loai_kh;
        }

        public IQueryable<khmai> GetKhmai()
        {
            var qr = (from a in this.ObjectContext.kh_mai //where a.hieu_luc==true
                      select new khmai { ma_km = a.ma_km.Trim(), ten_ct = a.ten_ct.Trim(), ngay_bd = a.ngay_bd, ngay_kt = a.ngay_kt, hieu_luc=a.hieu_luc });
            return qr;
        }
        public IQueryable<loaicatmo> GetLoaiCatMo()
        {
            var q = (from a in this.ObjectContext.loai_catmo
                     select new loaicatmo {id = a.id,ma_yc=a.ma_yc.Trim(),ten_yc=a.ten_yc.Trim()});
            return q;
        }

        public IQueryable<maxas> GetMaxas()
        {
            var qr = (from a in this.ObjectContext.ma_xa
                      select new maxas { id = a.id, ma_huyen = a.ma_huyen, maxa = a.maxa, ten = a.ten.Trim(), tientb = a.tientb, vtci = a.vtci });
            return qr;
        }

        public IQueryable<MyTv> GetdsMyTv(string m_huyen)
        {
            var qr = (from a in this.ObjectContext.mytvs
                      join b in this.ObjectContext.gc_mytv on a.goi_cuoc equals b.ma_goi                    
                      where a.ma_huyen==m_huyen
                      select new MyTv
                      {
                        dc_tbld=a.dc_tbld.Trim(),dckd=a.dc_tbld.Trim(),dia_chitb=a.dia_chitb.Trim(),duong=a.duong,
                        e_mail=a.e_mail,goi_cuoc=b.ten_dv.Trim(),ht_ld=a.ht_ld,ht_tt=a.ht_tt,khom_ap=a.khom_ap,loai_cap=a.loai_cap,
                        ma_kh=a.ma_kh,ma_km=a.ma_km,ma_nhom=a.ma_nhom,ma_tram=a.ma_tram,maxa=a.maxa,ms_thue=a.ms_thue,ngan_hang=a.ngan_hang,
                        ngay_cap=a.ngay_cap,ngay_hd=a.ngay_hd,ngay_hdl=a.ngay_hdl,ngay_kn=a.ngay_kn,ngay_ld=a.ngay_ld,ngay_ngung=a.ngay_ngung,
                        noi_cap=a.noi_cap,user_adsl=a.user_adsl,note_ngay_kn=a.note_ngay_kn.Trim(),pl=a.pl,port=a.port,slot=a.slot,so_dt=a.so_dt,
                        socmnd=a.socmnd,sohopdong=a.sohopdong,stb_serial=a.stb_serial,system_id=a.system_id,tai_khoan=a.tai_khoan,ten_dkdb=a.ten_dkdb,
                        ten_dktb=a.ten_dkdb,tenkhkd=a.tenkhkd,tinh_trang=a.tinh_trang,tuyen_tc=a.tuyen_tc,user_login=a.user_login,user_name=a.user_name,xa_phuong=a.xa_phuong,goi_th=a.goi_th,ma_nvcs=a.ma_nvcs,ma_nvkt=a.ma_nvkt,thtb=a.thtb, camket=a.camket, dt_lh=a.dt_lh, so_119=a.so_119
                      });
            return qr;
        }

        public IQueryable<tuyen> GetTuyenthucuoc(string ma_huyen, string m_tuyen)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                        where a.ma_huyen==ma_huyen && a.tuyen_tc.Trim()==m_tuyen
                        select new tuyen
                        {
                            so_dt = a.so_dt,ma_kh = a.ma_kh,ten_dktb = a.ten_dktb,ten_dkdb = a.ten_dkdb,dia_chitb = a.dia_chitb,dc_tbld = a.dc_tbld,stt = a.stt,tuyen_tc = a.tuyen_tc
                        }).Concat
                        (from b in this.ObjectContext.Gphones
                        where b.ma_huyen==ma_huyen && b.tuyen_tc.Trim()==m_tuyen
                         select new tuyen
                        {
                            so_dt = b.so_dt,ma_kh=b.ma_kh,ten_dktb = b.ten_dktb,ten_dkdb = b.ten_dkdb,dia_chitb = b.dia_chitb,dc_tbld = b.dc_tbld,stt = b.stt,tuyen_tc = b.tuyen_tc
                        }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.ma_huyen == ma_huyen && c.tuyen_tc.Trim() == m_tuyen
                         select new tuyen
                         {
                             so_dt = c.user_name.Trim(),ma_kh = c.ma_kh,ten_dktb = c.ten_dktb,ten_dkdb = c.ten_dkdb,dia_chitb = c.dia_chitb,dc_tbld = c.dc_tbld,stt = c.stt,tuyen_tc = c.tuyen_tc
                         }).Concat
                         (from d in this.ObjectContext.internets
                          where d.ma_huyen == ma_huyen && d.tuyen_tc.Trim() == m_tuyen
                          select new tuyen
                          {
                              so_dt = d.user_name.Trim(),ma_kh = d.ma_kh,ten_dktb = d.ten_dktb,ten_dkdb = d.ten_nsd,dia_chitb = d.dia_chitb,dc_tbld = d.dc_tbld,stt = d.stt,tuyen_tc = d.tuyen_tc
                          }).OrderBy(p=>p.stt);
            return query;

        }

        public IQueryable<tuyen> Getdsgoicuoc(string so)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                         where a.id_goicuoc.Trim()==so
                         select new tuyen
                         {
                             so_dt = a.so_dt,                            
                             ten_dktb = a.ten_dktb,                            
                             dia_chitb = a.dia_chitb,
                             loai="C"
                         }).Concat
                        (from b in this.ObjectContext.Gphones
                         where b.id_goicuoc.Trim() == so
                         select new tuyen
                         {
                             so_dt = b.so_dt,
                             ten_dktb = b.ten_dktb,
                             dia_chitb = b.dia_chitb,
                             loai = "G"
                         }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.id_goicuoc.Trim() == so
                         select new tuyen
                         {
                             so_dt = c.user_name,
                             ten_dktb = c.ten_dktb,
                             dia_chitb = c.dia_chitb,
                             loai = "M"
                         }).Concat
                         (from d in this.ObjectContext.internets
                          where d.id_goicuoc.Trim() == so
                          select new tuyen
                          {
                              so_dt = d.user_name,
                              ten_dktb = d.ten_dktb,
                              dia_chitb = d.dia_chitb,
                              loai = "I"
                          }).OrderBy(p => p.so_dt);
            return query;

        }

        public IQueryable<maxas> GetXa(string ma_huyen, string m_xa)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                         where a.ma_huyen == ma_huyen && a.village.Trim() == m_xa
                         select new maxas
                         {  
                             id=DateTime.Now.Second,
                             ma_huyen=a.ma_huyen,
                             maxa=a.village,
                             ten="",
                             tientb=1
                         }).Concat
                        (from b in this.ObjectContext.Gphones
                         where b.ma_huyen == ma_huyen && b.village.Trim() == m_xa
                         select new maxas
                         {
                             id = DateTime.Now.Second,
                             ma_huyen = b.ma_huyen,
                             maxa = b.village,
                             ten = "",
                             tientb = 1
                         }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.ma_huyen == ma_huyen && c.maxa.Trim() == m_xa
                         select new maxas
                         {
                             id = DateTime.Now.Second,
                             ma_huyen = c.ma_huyen,
                             maxa = c.maxa,
                             ten = "",
                             tientb = 1
                         });
            return query;

        }
        public IQueryable<matram> GetTram(string ma_huyen, string m_tram)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                         where a.ma_huyen == ma_huyen && a.ma_tram.Trim() == m_tram
                         select new matram
                         {
                             id = DateTime.Now.Second,
                             ma_tram = a.ma_tram                             
                         }).Concat
                        (from b in this.ObjectContext.Gphones
                         where b.ma_huyen == ma_huyen && b.ma_tram.Trim() == m_tram
                         select new matram
                         {
                             id = DateTime.Now.Second,
                             ma_tram = b.ma_tram     
                         }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.ma_huyen == ma_huyen && c.ma_tram.Trim() == m_tram
                         select new matram
                         {
                             id = DateTime.Now.Second,
                             ma_tram = c.ma_tram   
                         });
            return query;

        }

        public IQueryable<Catmo> GetDataCatmo()
        {
            var query = (from a in this.ObjectContext.cat_mo
                         from b in this.ObjectContext.loai_catmo
                         where a.ma_yc == b.ma_yc
                         select new Catmo
                         {                             
                             card = a.card,dc_tbld = a.dc_tbld,
                             dia_chitb = a.dia_chitb,
                             dlu = a.dlu,en = a.en,
                             frame = a.frame,
                             id = a.id,
                             logic = a.logic,
                             ma_huyen = a.ma_huyen,                             
                             ma_yc = a.ma_yc,
                             ten_yc = b.ten_yc,                            
                             mo = a.mo,
                             nguoi_mo = a.nguoi_mo,
                             nguoi_yc = a.nguoi_yc,
                             port = a.port,
                             shell = a.shell,
                             slot = a.slot,
                             slp = a.slp,
                             so_dt = a.so_dt,
                             ten_dkdb = a.ten_dkdb,
                             ten_dktb = a.ten_dktb,
                             tg_mo = a.tg_mo,
                             tg_yc = a.tg_yc
                         });
            return query;

        }

        public IQueryable<Catmo> GetDataLogCatmo(string m_sdt)
        {
            var query = (from a in this.ObjectContext.cat_mo
                         from b in this.ObjectContext.loai_catmo
                         where a.ma_yc == b.ma_yc && a.so_dt == m_sdt
                         select new Catmo
                         {
                             card = a.card,
                             dc_tbld = a.dc_tbld,
                             dia_chitb = a.dia_chitb,
                             dlu = a.dlu,
                             en = a.en,
                             frame = a.frame,
                             id = a.id,
                             logic = a.logic,
                             ma_huyen = a.ma_huyen,
                             ma_yc = a.ma_yc,
                             ten_yc = b.ten_yc,
                             mo = a.mo,
                             nguoi_mo = a.nguoi_mo,
                             nguoi_yc = a.nguoi_yc,
                             port = a.port,
                             shell = a.shell,
                             slot = a.slot,
                             slp = a.slp,
                             so_dt = a.so_dt,
                             ten_dkdb = a.ten_dkdb,
                             ten_dktb = a.ten_dktb,
                             tg_mo = a.tg_mo,
                             tg_yc = a.tg_yc
                         }).Concat
                         (from a in this.ObjectContext.cat_mo_log
                          from b in this.ObjectContext.loai_catmo
                          where a.ma_yc == b.ma_yc && a.so_dt==m_sdt
                          select new Catmo
                          {
                              card = a.card,
                              dc_tbld = a.dc_tbld,
                              dia_chitb = a.dia_chitb,
                              dlu = a.dlu,
                              en = a.en,
                              frame = a.frame,
                              id = a.id,
                              logic = a.logic,
                              ma_huyen = a.ma_huyen,
                              ma_yc = a.ma_yc,
                              ten_yc = b.ten_yc,
                              mo = a.mo,
                              nguoi_mo = a.nguoi_mo,
                              nguoi_yc = a.nguoi_yc,
                              port = a.port,
                              shell = a.shell,
                              slot = a.slot,
                              slp = a.slp,
                              so_dt = a.so_dt,
                              ten_dkdb = a.ten_dkdb,
                              ten_dktb = a.ten_dktb,
                              tg_mo = a.tg_mo,
                              tg_yc = a.tg_yc
                          }).OrderBy(p=>p.tg_yc);
            return query;

        }

        public IQueryable<Catmo> GetTKLogCatmo(DateTime ngaybd, DateTime ngaykt)
        {
            var query = (from a in this.ObjectContext.cat_mo
                         from b in this.ObjectContext.loai_catmo
                         where a.ma_yc == b.ma_yc && a.tg_yc>=ngaybd && a.tg_yc<=ngaykt
                         select new Catmo
                         {
                             card = a.card,
                             dc_tbld = a.dc_tbld,
                             dia_chitb = a.dia_chitb,
                             dlu = a.dlu,
                             en = a.en,
                             frame = a.frame,
                             id = a.id,
                             logic = a.logic,
                             ma_huyen = a.ma_huyen,
                             ma_yc = a.ma_yc,
                             ten_yc = b.ten_yc,
                             mo = a.mo,
                             nguoi_mo = a.nguoi_mo,
                             nguoi_yc = a.nguoi_yc,
                             port = a.port,
                             shell = a.shell,
                             slot = a.slot,
                             slp = a.slp,
                             so_dt = a.so_dt,
                             ten_dkdb = a.ten_dkdb,
                             ten_dktb = a.ten_dktb,
                             tg_mo = a.tg_mo,
                             tg_yc = a.tg_yc
                         }).Concat
                         (from a in this.ObjectContext.cat_mo_log
                          from b in this.ObjectContext.loai_catmo
                          where a.ma_yc == b.ma_yc && a.tg_mo >= ngaybd && a.tg_mo <= ngaykt
                          select new Catmo
                          {
                              card = a.card,
                              dc_tbld = a.dc_tbld,
                              dia_chitb = a.dia_chitb,
                              dlu = a.dlu,
                              en = a.en,
                              frame = a.frame,
                              id = a.id,
                              logic = a.logic,
                              ma_huyen = a.ma_huyen,
                              ma_yc = a.ma_yc,
                              ten_yc = b.ten_yc,
                              mo = a.mo,
                              nguoi_mo = a.nguoi_mo,
                              nguoi_yc = a.nguoi_yc,
                              port = a.port,
                              shell = a.shell,
                              slot = a.slot,
                              slp = a.slp,
                              so_dt = a.so_dt,
                              ten_dkdb = a.ten_dkdb,
                              ten_dktb = a.ten_dktb,
                              tg_mo = a.tg_mo,
                              tg_yc = a.tg_yc
                          }).OrderBy(p => p.tg_yc);
            return query;

        }

        //Cancel

        public IQueryable<Catmo> GetTKLogCatmo1(DateTime ngaybd, DateTime ngaykt)
        {
            var query = (from a in this.ObjectContext.cat_mo_log
                          from b in this.ObjectContext.loai_catmo  
                          where a.ma_yc == b.ma_yc && a.tg_mo>=ngaybd && a.tg_mo<=ngaykt
                          select new Catmo
                          {
                              card = a.card,
                              dc_tbld = a.dc_tbld,
                              dia_chitb = a.dia_chitb,
                              dlu = a.dlu,
                              en = a.en,
                              frame = a.frame,
                              id = a.id,
                              logic = a.logic,
                              ma_huyen = a.ma_huyen,
                              ma_yc = a.ma_yc,
                              ten_yc = b.ten_yc,
                              mo = a.mo,
                              nguoi_mo = a.nguoi_mo,
                              nguoi_yc = a.nguoi_yc,
                              port = a.port,
                              shell = a.shell,
                              slot = a.slot,
                              slp = a.slp,
                              so_dt = a.so_dt,
                              ten_dkdb = a.ten_dkdb,
                              ten_dktb = a.ten_dktb,
                              tg_mo = a.tg_mo,
                              tg_yc = a.tg_yc
                          }).OrderBy(p => p.tg_yc);
            return query;

        }

        public System.Nullable<int> CreateTableTemp()
        {
            return this.ObjectContext.Create_tables();
        }

        public System.Nullable<int> Excute_p_tktonghop(DateTime b_time, DateTime e_time)
        {
            return this.ObjectContext.p_tktonghop(b_time, e_time);
        }


        public System.Nullable<int> Excute_p_tklydocat(DateTime b_time, DateTime e_time)
        {
            return this.ObjectContext.p_tklydocat(b_time, e_time);
        }


        public System.Nullable<int> Excute_p_doiaccint(string ac, string ac1)
        {
            return this.ObjectContext.doi_accint(ac,ac1);
        }

        public System.Nullable<int> Excute_p_suaxong119(string m_so, int m_status, string m_ten)
        {
           // this.ObjectContext.CommandTimeout = 180;
            return this.ObjectContext.suaxong_119(m_so, m_status, m_ten);
        }

        public System.Nullable<int> Excute_p_getsuaxong119(string m_huyen, DateTime tungay, DateTime denngay) // lay toan bo danh sach may sua xong
        {
            return this.ObjectContext.get_suaxong119(m_huyen, tungay,denngay);
        }

        public System.Nullable<int> Excute_p_Delete_119(string m_so)
        {
            return this.ObjectContext.Delete_119(m_so);
        }

        public System.Nullable<int> Excute_p_bao119(string m_so, int nGroup , string m_user)
        {
            return this.ObjectContext.bao_119(m_so, m_user, nGroup);
        }

        public System.Nullable<int> Excute_p_Dathongbao_119(string m_so)
        {
            return this.ObjectContext.dathongbao_119(m_so);
        }

        public System.Nullable<int> Excute_p_doiaccmytv(string ac, string ac1)
        {
            return this.ObjectContext.doi_accmytv(ac, ac1);
        }      

       
        public System.Nullable<int> Excute_get_119_new()
        {
            return this.ObjectContext.get_119_new();
        }


        public System.Nullable<int> Excute_TKsoluongtbGanNV(bool kt,bool nv)
        {
            return this.ObjectContext.TKsoluongtbGanNV(kt,nv);
        }

        public System.Nullable<int> Excute_TKDoanhThuGanNV(bool kt, bool nv, DateTime dt)
        {
            return this.ObjectContext.TKDoanhThuGanNV(kt, nv,dt);
        }



        public System.Nullable<int> Update_goi_cuoc_th(string ac, string goi, string idgoi,string loai,string ten,string dc,string usr)
        {
            return this.ObjectContext.update_goi_tich_hop(ac,goi,idgoi,loai,ten,dc,usr);
        }

        public System.Nullable<int> SendSMS(string noidung, string phone, decimal id)
        {
            return this.ObjectContext.SendSMS(noidung, phone,id);
        }

        public System.Nullable<int> Excute_DsGanDiaban(bool kt, string nv,string m_huyen,bool emp)
        {
            return this.ObjectContext.DSGanDiaban(kt, nv, m_huyen,emp);
        }


        //public IQueryable<ds119> Getds119(string m_tim)
        //{        
        //    var query = (from c in this.ObjectContext.mytvs
        //                 where c.so_119.Trim().Contains(m_tim) || c.ten_dktb.Trim().Contains(m_tim)
        //                 select new ds119
        //                 {
        //                     so_dt = c.so_119,
        //                     ten_dktb = c.ten_dktb,
        //                     dc_tbld = c.dc_tbld,
        //                     ma_huyen = c.ma_huyen
        //                 }).Concat
        //                 (from d in this.ObjectContext.internets
        //                  where d.so_119.Trim().Contains(m_tim) || d.ten_dktb.Trim().Contains(m_tim)
        //                  select new ds119
        //                  {
        //                      so_dt = d.so_119,
        //                      ten_dktb = d.ten_dktb,
        //                      dc_tbld = d.dc_tbld,
        //                      ma_huyen = d.ma_huyen
        //                  });
        //    return query;
        //}

        public IQueryable<ds119s> Getds119(string m_tim)
        {
            var query = (from c in this.ObjectContext.mytvs
                         where c.so_119.Trim().Contains(m_tim) || c.so_119.Trim() == m_tim || c.user_name.Trim().Contains(m_tim) || c.user_name.Trim() == m_tim || c.ten_dktb.Trim().Contains(m_tim) || c.dc_tbld.Trim().Contains(m_tim)
                         select new ds119s
                         {
                             user_name=c.user_name,
                             so_dt = c.so_119,
                             ten_dktb = c.ten_dktb,
                             dc_tbld = c.dc_tbld,
                             ma_huyen = c.ma_huyen
                         }).Concat
                         (from d in this.ObjectContext.internets
                          where d.so_119.Trim().Contains(m_tim) || d.so_119.Trim() == m_tim || d.user_name.Trim().Contains(m_tim) || d.user_name.Trim() == m_tim || d.ten_dktb.Trim().Contains(m_tim) || d.dc_tbld.Trim().Contains(m_tim) 
                          select new ds119s
                          {
                              user_name = d.user_name,
                              so_dt = d.so_119,
                              ten_dktb = d.ten_dktb,
                              dc_tbld = d.dc_tbld,
                              ma_huyen = d.ma_huyen
                          });
            return query;
        }



        public IQueryable<manvcs> GetManvcs(string ma_huyen,string ma_nv)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                         where a.ma_huyen == ma_huyen && a.ma_nvcs.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs=a.ma_nvcs
                         }).Concat
                        (from b in this.ObjectContext.Gphones
                         where b.ma_huyen == ma_huyen && b.ma_nvcs.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = b.ma_nvcs
                         }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.ma_huyen == ma_huyen && c.ma_nvcs.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = c.ma_nvcs
                         }).Concat
                        (from d in this.ObjectContext.internets
                         where d.ma_huyen == ma_huyen && d.ma_nvcs.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = d.ma_nvcs
                         });
            return query;

        }

        public IQueryable<manvcs> Gettuyenktcs(string ma_huyen, string ma_nv)
        {
            var query = (from a in this.ObjectContext.ds_codinh
                         where a.ma_huyen == ma_huyen && a.ma_nvkt.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = a.ma_nvkt
                         }).Concat
                        (from b in this.ObjectContext.Gphones
                         where b.ma_huyen == ma_huyen && b.ma_nvkt.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = b.ma_nvkt
                         }).Concat
                        (from c in this.ObjectContext.mytvs
                         where c.ma_huyen == ma_huyen && c.ma_nvkt.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = c.ma_nvkt
                         }).Concat
                        (from d in this.ObjectContext.internets
                         where d.ma_huyen == ma_huyen && d.ma_nvkt.Trim() == ma_nv
                         select new manvcs
                         {
                             ma_nvcs = d.ma_nvkt
                         });
            return query;

        }

        //public IQueryable<tuyencskhs> Gettuyenkt(string ma_huyen, string ma_nv)
        //{
        //    var query = (from a in this.ObjectContext.ds_codinh
        //                 where a.ma_huyen == ma_huyen && (a.ma_nvkt.Trim() == ma_nv || ma_nv.Contains(';'+a.ma_nvkt.Trim()+';'))
        //                 select new tuyencskhs
        //                 {
        //                      dc_tbld=a.dc_tbld.Trim(), dia_chitb= a.dia_chitb.Trim(), ma_kh=a.ma_kh, ma_nvkt=a.ma_nvkt, ma_nvcs=a.ma_nvcs, so_dt=a.so_dt, ten_dkdb=a.ten_dkdb.Trim(), ten_dktb=a.ten_dktb.Trim()
        //                 }).Concat
        //                (from b in this.ObjectContext.Gphones
        //                 where b.ma_huyen == ma_huyen && (b.ma_nvkt.Trim() == ma_nv || ma_nv.Contains(';' + b.ma_nvkt.Trim() + ';'))
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = b.dc_tbld.Trim(),
        //                     dia_chitb = b.dia_chitb.Trim(),
        //                     ma_kh = b.ma_kh,
        //                     ma_nvkt = b.ma_nvkt,
        //                     ma_nvcs = b.ma_nvcs,
        //                     so_dt = b.so_dt,
        //                     ten_dkdb = b.ten_dkdb.Trim(),
        //                     ten_dktb = b.ten_dktb.Trim()
        //                 }).Concat
        //                (from c in this.ObjectContext.mytvs
        //                 where c.ma_huyen == ma_huyen && (c.ma_nvkt.Trim() == ma_nv || ma_nv.Contains(';' + c.ma_nvkt.Trim() + ';'))
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = c.dc_tbld.Trim(),
        //                     dia_chitb = c.dia_chitb.Trim(),
        //                     ma_kh = c.ma_kh,
        //                     ma_nvkt = c.ma_nvkt,
        //                     ma_nvcs = c.ma_nvcs,
        //                     so_dt = c.user_name.Trim(),
        //                     ten_dkdb = c.ten_dkdb.Trim(),
        //                     ten_dktb = c.ten_dktb.Trim()
        //                 }).Concat
        //                (from d in this.ObjectContext.internets
        //                 where d.ma_huyen == ma_huyen && (d.ma_nvkt.Trim() == ma_nv || ma_nv.Contains(';' + d.ma_nvkt.Trim() + ';'))
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = d.dc_tbld.Trim(),
        //                     dia_chitb = d.dia_chitb.Trim(),
        //                     ma_kh = d.ma_kh,
        //                     ma_nvkt = d.ma_nvkt,
        //                     ma_nvcs = d.ma_nvcs,
        //                     so_dt = d.user_name.Trim(),
        //                     ten_dkdb = d.ten_nsd.Trim(),
        //                     ten_dktb = d.ten_dktb.Trim()
        //                 });
        //    return query;

        //}

        //public IQueryable<tuyencskhs> Gettuyenktd(string ma_huyen, string ma_nv)
        //{
        //    var query = (from a in this.ObjectContext.ds_codinh
        //                 where a.ma_huyen == ma_huyen && (a.ma_nvcs.Trim() == ma_nv || ma_nv.Contains(';' + a.ma_nvcs.Trim() + ';'))
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = a.dc_tbld.Trim(),
        //                     dia_chitb = a.dia_chitb.Trim(),
        //                     ma_kh = a.ma_kh,
        //                     ma_nvkt = a.ma_nvkt,
        //                     ma_nvcs = a.ma_nvcs,
        //                     so_dt = a.so_dt,
        //                     ten_dkdb = a.ten_dkdb.Trim(),
        //                     ten_dktb = a.ten_dktb.Trim()
        //                 }).Concat
        //                (from b in this.ObjectContext.Gphones
        //                 where b.ma_huyen == ma_huyen && b.ma_nvcs.Trim() == ma_nv
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = b.dc_tbld.Trim(),
        //                     dia_chitb = b.dia_chitb.Trim(),
        //                     ma_kh = b.ma_kh,
        //                     ma_nvkt = b.ma_nvkt,
        //                     ma_nvcs = b.ma_nvcs,
        //                     so_dt = b.so_dt,
        //                     ten_dkdb = b.ten_dkdb.Trim(),
        //                     ten_dktb = b.ten_dktb.Trim()
        //                 }).Concat
        //                (from c in this.ObjectContext.mytvs
        //                 where c.ma_huyen == ma_huyen && c.ma_nvcs.Trim() == ma_nv
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = c.dc_tbld.Trim(),
        //                     dia_chitb = c.dia_chitb.Trim(),
        //                     ma_kh = c.ma_kh,
        //                     ma_nvkt = c.ma_nvkt,
        //                     ma_nvcs = c.ma_nvcs,
        //                     so_dt = c.user_name.Trim(),
        //                     ten_dkdb = c.ten_dkdb.Trim(),
        //                     ten_dktb = c.ten_dktb.Trim()
        //                 }).Concat
        //                (from d in this.ObjectContext.internets
        //                 where d.ma_huyen == ma_huyen && d.ma_nvcs.Trim() == ma_nv
        //                 select new tuyencskhs
        //                 {
        //                     dc_tbld = d.dc_tbld.Trim(),
        //                     dia_chitb = d.dia_chitb.Trim(),
        //                     ma_kh = d.ma_kh,
        //                     ma_nvkt = d.ma_nvkt,
        //                     ma_nvcs = d.ma_nvcs,
        //                     so_dt = d.user_name.Trim(),
        //                     ten_dkdb = d.ten_nsd.Trim(),
        //                     ten_dktb = d.ten_dktb.Trim()
        //                 });
        //    return query;

        //}


        public IQueryable<TocDo> GetTocDoTrim()
        {
            var Query = from a in this.ObjectContext.toc_do
                        select new TocDo { id = a.id, ma_goi = a.ma_goi.Trim(), ma_td = a.ma_td.Trim(), toc_do = a.toc_do1.Trim(), ghi_chu = a.ghi_chu };
            return Query;
        }

        public IQueryable<KhachHangUuTien> GetKhachHangUuTienTrim()
        {
            var Query = from a in this.ObjectContext.kh_uutien
                        select new KhachHangUuTien { id = a.id, kh_uutien1=a.kh_uutien1.Trim(), ten_uutien=a.ten_uutien.Trim() };
            return Query;
        }
        public IQueryable<GoiCuoc> GetGoiCuocTrim()
        {
            var Query = from a in this.ObjectContext.goicuoc_int
                        select new GoiCuoc { ma_goi=a.ma_goi.Trim(), ten_goi=a.ten_goi.Trim(), ghi_chu=a.ghi_chu,ma_dv=a.ma_dv.Trim() };
            return Query;
        }
        
        public IQueryable<INTERNET> GetINTERNET()
        {
            var Query = from a in this.ObjectContext.internets
                        from b in this.ObjectContext.kh_uutien
                        //from c in this.ObjectContext.internet_log
                        where a.kh_uutien==b.kh_uutien1// && a.user_name==c.user_name
                        select new INTERNET { dc_tbld=a.dc_tbld.Trim() ,dckd=a.dckd.Trim(),dia_chitb=a.dia_chitb.Trim(),duong=a.duong,e_mail=a.e_mail,goi_cuoc=a.goi_cuoc,ht_ld=a.ht_ld,ht_tt=a.ht_tt,kh_uutien=a.kh_uutien,ten_uutien=b.ten_uutien.Trim(),khg_vat=a.khg_vat,khom_ap=a.khom_ap,ma_dv=a.ma_dv,ma_huyen=a.ma_huyen,ma_kh=a.ma_kh,ma_km=a.ma_km,ma_nghe=a.ma_nghe,ma_nhom=a.ma_nhom,ma_nvcs=a.ma_nvcs,ma_nvkt=a.ma_nvkt,ma_tram=a.ma_tram,maxa=a.maxa,may_ngung=a.may_ngung,ms_thue=a.ms_thue,loai_cap=a.loai_cap,ngan_hang=a.ngan_hang,ngay_cap=a.ngay_cap,ngay_hd=a.ngay_hd,ngay_kn=a.ngay_kn,ngay_ld=a.ngay_ld,ngay_ngung=a.ngay_ngung,noi_cap=a.noi_cap,note_ngay_kn=a.note_ngay_kn,so_dt=a.so_dt,socmnd=a.socmnd,sohopdong=a.sohopdong,stt=a.stt,tai_khoan=a.tai_khoan,ten_dktb=a.ten_dktb.Trim(),ten_nsd=a.ten_nsd,tenkhkd=a.tenkhkd,toc_do=a.toc_do,tuyen_tc=a.tuyen_tc,user_name=a.user_name,xa_phuong=a.xa_phuong,thtb=a.thtb, camket=a.camket, dt_lh=a.dt_lh, so_119=a.so_119};
            return Query;
        }

        public IQueryable<DSCD> GetDSCD()
        {
            var Query = from a in this.ObjectContext.ds_codinh

                        select new DSCD
                        {
                            cuoc = a.cuoc,
                            dau = a.dau,
                            dc_tbld = a.dc_tbld,
                            dckd = a.dckd,
                            dia_chitb = a.dia_chitb,
                            duong = a.duong,
                            e_mail = a.e_mail,
                            goi_th = a.goi_th,
                            keo_may = a.keo_may,
                            inct = a.inct,
                            khg_vat = a.khg_vat,
                            khom_ap = a.khom_ap,
                            ma_huyen = a.ma_huyen,
                            ma_kh = a.ma_kh,
                            ma_km = a.ma_km,
                            ma_nghe = a.ma_nghe,
                            ma_nhom = a.ma_nhom,
                            ma_nvcs = a.ma_nvcs,
                            ma_nvkt=a.ma_nvkt,
                            ma_tram = a.ma_tram,
                            may_ngung = a.may_ngung,
                            mo_may = a.mo_may,
                            ms_thue = a.ms_thue,
                            ngan_hang = a.ngan_hang,
                            ngay = a.ngay,
                            ngay_cap = a.ngay_cap,
                            ngay_hd = a.ngay_hd,
                            ngay_kn = a.ngay_kn,
                            ngay_ld = a.ngay_ld,
                            ngay_mo = a.ngay_mo,
                            ngay_ngung = a.ngay_ngung,
                            noi_cap = a.noi_cap,
                            note_ngay_kn = a.note_ngay_kn,
                            pl = a.pl,
                            so_dt = a.so_dt,
                            socmnd = a.socmnd,
                            sohopdong = a.sohopdong,
                            stt = a.stt,
                            tai_khoan = a.tai_khoan,
                            tb_dv = a.tb_dv,
                            tbdc = a.tbdc,
                            ten_dkdb = a.ten_dkdb,
                            ten_dktb = a.ten_dktb,
                            tenkhkd = a.tenkhkd,
                            thangbd = a.thangbd,
                            thtb = a.thtb,
                            tien_tb = a.tien_tb,
                            tienno = a.tienno,
                            tuyen_tc = a.tuyen_tc,
                            village = a.village,
                            xa_phuong = a.xa_phuong,
                            camket=a.camket,
                            dt_lh=a.dt_lh
                            
                            //users = ((from b in this.ObjectContext.codinh_log
                            //          where
                            //            a.so_dt == b.so_dt
                            //          orderby
                            //            b.thoi_gian
                            //          select new
                            //          {
                            //              b.users
                            //          }).Take(1).First().users)
                        };
            return Query;
        }

        public IQueryable<mlydocat> GetLyDoCatTrim()
        {
            var Query = from a in this.ObjectContext.lydocats                        
                        select new mlydocat { ma_ld = a.ma_ld.Trim(), ten_ld = a.ten_ld.Trim(),m_order = a.m_order, loai = a.loai};
            return Query;
        }

        public IQueryable<Mdiaban> GetMadiabanTrim()
        {
            var Query = from a in this.ObjectContext.ma_diaban
                        select new Mdiaban {ma_huyen=a.ma_huyen, ma_tuyen=a.ma_tuyen, ten_tuyen=a.ten_tuyen.Trim(),kt=a.kt};
            return Query;
        }

        public IQueryable<SLGanDB> GetSLGanDB()
        {
            var Query = from a in this.ObjectContext.rp_slg_diaban
                        select new SLGanDB { id = a.id, ma_huyen = a.ma_huyen, ma_nv = a.ma_nv.Trim(), ma_tuyen = a.ma_tuyen.Trim(), soluong = a.soluong, soluongcd = a.soluongcd, soluongftth = a.soluongftth, soluonggp = a.soluonggp, soluongint = a.soluongint, soluongmy = a.soluongmy, ten_nv = a.ten_nv.Trim(), ten_tuyen = a.ten_tuyen.Trim(), thang=a.thang.Trim(), tien=a.tien, tiencd=a.tiencd, tienftth=a.tienftth, tiengp=a.tiengp, tienint=a.tienint, tienmy=a.tienmy };
            return Query;
        }

        public IQueryable<DSCD> Getds1080(string m_tim)
        {        
                var query = (from c in this.ObjectContext.ds_codinh
                             where c.so_dt == m_tim
                             select new DSCD
                             {
                                 so_dt = c.so_dt,
                                 ten_dktb = c.ten_dktb.Trim(),
                                 dia_chitb = c.dia_chitb.Trim(),
                                 dc_tbld = c.dc_tbld.Trim(),
                                 ma_huyen = c.ma_huyen,
                                 ttin108s = c.ttin108s.Trim(),
                                 may_ngung = c.may_ngung
                             }).Concat
                            (from d in this.ObjectContext.Gphones
                             where d.so_dt == m_tim
                             select new DSCD
                             {
                                 so_dt = d.so_dt,
                                 ten_dktb = d.ten_dktb.Trim(),
                                 dia_chitb = d.dia_chitb.Trim(),
                                 dc_tbld = d.dc_tbld.Trim(),
                                 ma_huyen = d.ma_huyen,
                                 ttin108s = d.ttin108s.Trim(),
                                 may_ngung = d.may_ngung
                             });
         
            return query;
        }

        public IQueryable<DSCD> Getds10801(string m_tim)
        {
            var query = (from c in this.ObjectContext.ds_codinh
                         where c.ten_dktb == m_tim || c.ten_dktb.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = c.so_dt,
                             ten_dktb = c.ten_dktb.Trim(),
                             dia_chitb = c.dia_chitb.Trim(),
                             dc_tbld = c.dc_tbld.Trim(),
                             ma_huyen = c.ma_huyen,
                             ttin108s = c.ttin108s.Trim(),
                             may_ngung = c.may_ngung
                         }).Concat
                        (from d in this.ObjectContext.Gphones
                         where d.ten_dktb == m_tim || d.ten_dktb.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = d.so_dt,
                             ten_dktb = d.ten_dktb.Trim(),
                             dia_chitb = d.dia_chitb.Trim(),
                             dc_tbld = d.dc_tbld.Trim(),
                             ma_huyen = d.ma_huyen,
                             ttin108s = d.ttin108s.Trim(),
                             may_ngung = d.may_ngung
                         });

            return query;
        }

        public IQueryable<DSCD> Getds10802(string m_ten, string m_dc)
        {
            var query = (from c in this.ObjectContext.ds_codinh
                         where ((c.ten_dktb == m_ten || c.ten_dktb.Contains(m_ten)) && (c.dc_tbld == m_dc || c.dc_tbld.Contains(m_dc)))
                         select new DSCD
                         {
                             so_dt = c.so_dt,
                             ten_dktb = c.ten_dktb.Trim(),
                             dia_chitb = c.dia_chitb.Trim(),
                             dc_tbld = c.dc_tbld.Trim(),
                             ma_huyen = c.ma_huyen,
                             ttin108s = c.ttin108s.Trim(),
                             may_ngung = c.may_ngung
                         }).Concat
                        (from d in this.ObjectContext.Gphones
                         where ((d.ten_dktb == m_ten || d.ten_dktb.Contains(m_ten)) && (d.dc_tbld == m_dc || d.dc_tbld.Contains(m_dc)))
                         select new DSCD
                         {
                             so_dt = d.so_dt,
                             ten_dktb = d.ten_dktb.Trim(),
                             dia_chitb = d.dia_chitb.Trim(),
                             dc_tbld = d.dc_tbld.Trim(),
                             ma_huyen = d.ma_huyen,
                             ttin108s = d.ttin108s.Trim(),
                             may_ngung = d.may_ngung
                         });

            return query;
        }

        public IQueryable<DSCD> Getds10803(string m_ten, string m_dc, string m_tin)
        {
            var query = (from c in this.ObjectContext.ds_codinh
                         where ((c.ten_dktb == m_ten || c.ten_dktb.Contains(m_ten)) && (c.dc_tbld == m_dc || c.dc_tbld.Contains(m_dc)) && (c.ttin108s == m_tin || c.ttin108s.Contains(m_tin)))
                         select new DSCD
                         {
                             so_dt = c.so_dt,
                             ten_dktb = c.ten_dktb.Trim(),
                             dia_chitb = c.dia_chitb.Trim(),
                             dc_tbld = c.dc_tbld.Trim(),
                             ma_huyen = c.ma_huyen,
                             ttin108s = c.ttin108s.Trim(),
                             may_ngung = c.may_ngung
                         }).Concat
                        (from d in this.ObjectContext.Gphones
                         where ((d.ten_dktb == m_ten || d.ten_dktb.Contains(m_ten)) && (d.dc_tbld == m_dc || d.dc_tbld.Contains(m_dc)) && (d.ttin108s == m_tin || d.ttin108s.Contains(m_tin)))
                         select new DSCD
                         {
                             so_dt = d.so_dt,
                             ten_dktb = d.ten_dktb.Trim(),
                             dia_chitb = d.dia_chitb.Trim(),
                             dc_tbld = d.dc_tbld.Trim(),
                             ma_huyen = d.ma_huyen,
                             ttin108s = d.ttin108s.Trim(),
                             may_ngung = d.may_ngung
                         });

            return query;
        }

        public IQueryable<DSCD> Getds10804(string m_tim)
        {
            var query = (from c in this.ObjectContext.ds_codinh
                         where c.ttin108s == m_tim || c.ttin108s.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = c.so_dt,
                             ten_dktb = c.ten_dktb.Trim(),
                             dia_chitb = c.dia_chitb.Trim(),
                             dc_tbld = c.dc_tbld.Trim(),
                             ma_huyen = c.ma_huyen,
                             ttin108s = c.ttin108s.Trim(),
                             may_ngung = c.may_ngung
                         }).Concat
                        (from d in this.ObjectContext.Gphones
                         where d.ttin108s == m_tim || d.ttin108s.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = d.so_dt,
                             ten_dktb = d.ten_dktb.Trim(),
                             dia_chitb = d.dia_chitb.Trim(),
                             dc_tbld = d.dc_tbld.Trim(),
                             ma_huyen = d.ma_huyen,
                             ttin108s = d.ttin108s.Trim(),
                             may_ngung = d.may_ngung
                         });

            return query;
        }

        public IQueryable<DSCD> Getds10805(string m_tim)
        {
            var query = (from c in this.ObjectContext.ds_codinh
                         where c.dc_tbld == m_tim || c.dc_tbld.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = c.so_dt,
                             ten_dktb = c.ten_dktb.Trim(),
                             dia_chitb = c.dia_chitb.Trim(),
                             dc_tbld = c.dc_tbld.Trim(),
                             ma_huyen = c.ma_huyen,
                             ttin108s = c.ttin108s.Trim(),
                             may_ngung = c.may_ngung
                         }).Concat
                        (from d in this.ObjectContext.Gphones
                         where d.dc_tbld == m_tim || d.dc_tbld.Contains(m_tim)
                         select new DSCD
                         {
                             so_dt = d.so_dt,
                             ten_dktb = d.ten_dktb.Trim(),
                             dia_chitb = d.dia_chitb.Trim(),
                             dc_tbld = d.dc_tbld.Trim(),
                             ma_huyen = d.ma_huyen,
                             ttin108s = d.ttin108s.Trim(),
                             may_ngung=d.may_ngung
                         });

            return query;
        }

        public IQueryable<BSCT> GetKpis_tinh(bool kt)
        {
            var query = ( from b in this.ObjectContext.KPOs
                          from c in this.ObjectContext.KPIs
                          where  b.id== c.id_kpos && c.ky_thuat==kt && b.ky_thuat==kt
                          orderby b.vien_canh.sap_xep,b.sap_xep
                        select new BSCT { ten_vien_canh=  b.vien_canh.ten_vien_canh.Trim(),
                                          ten_kpos= b.ten_kpos.Trim(), ten_kpi= c.ten_kpis.Trim(), ma_kpi=c.ma_kpis, dvt=c.dvt, loai_dvt=c.loai_dvt, check=false, sap_xep=b.vien_canh.sap_xep});

            return query;
        }

        public IQueryable<BSCT> GetExitsKpis_tinh(string m_tg, string m_dv)
        {
            var query = (from b in this.ObjectContext.KPOs
                         from c in this.ObjectContext.KPIs
                         from d in this.ObjectContext.chi_tieu_huyen
                         where b.id == c.id_kpos && d.id_kpis==c.ma_kpis && d.qui==m_tg && d.ma_dv==m_dv
                         orderby b.vien_canh.sap_xep, b.sap_xep
                         select new BSCT
                         {
                             ten_vien_canh = b.vien_canh.ten_vien_canh.Trim(),
                             ten_kpos = b.ten_kpos.Trim(),
                             ten_kpi = c.ten_kpis.Trim(),
                             ma_kpi = c.ma_kpis,                           
                             dvt = c.dvt,
                             loai_dvt = c.loai_dvt,
                             check = false,
                             sap_xep = b.vien_canh.sap_xep,
                             trongso=d.trong_so_giao,
                             chitieugiao=d.chi_tieu_giao,
                             chitieuth=d.chi_tieu_thuc_hien,
                             ty_trong_thuc_hien=d.ty_trong_thuc_hien
                         });

            return query;
        }

        //public 
        //public IQueryable<SP1_Result> SP1()
        //{
        //    return this.ObjectContext.Create_tables();
        //}


        //public IQueryable<tuyen> GetTuyenthucuoc(string ma_huyen)
        //{
        //    var query = (from a in this.ObjectContext.ds_codinh
        //                 where a.tuyen_tc != "" && a.ma_huyen == ma_huyen
        //                 select new 
        //                 {
        //                     a.tuyen_tc
        //                 }
        //                 ).Concat
        //                 (
        //                from b in this.ObjectContext.Gphones
        //                where b.tuyen_tc != "" && b.ma_huyen == ma_huyen
        //                select new 
        //                {
        //                    tuyen_tc = b.tuyen_tc
        //                }
        //                ).Concat
        //                (
        //                from c in this.ObjectContext.mytvs
        //                where c.tuyen_tc != "" && c.ma_huyen == ma_huyen
        //                group c by new 
        //                {
        //                    c.tuyen_tc
        //                } into g
        //                select new tuyen
        //                {
        //                    tuyen_tc = g.Key.tuyen_tc
        //                }
        //                );
        //    return query;

        //}

        //quang them
        public IQueryable<BSCT> GetKpi_huyen(bool kt)
        {
            var query = (from b in this.ObjectContext.sKPOes
                         from c in this.ObjectContext.sKPIs
                         where b.id == c.id_kpo && c.ky_thuat == kt && b.ky_thuat == kt
                         orderby b.sap_xep
                         select new BSCT
                         {
                             ten_kpo = b.ten_kpo.Trim(),
                             ten_kpi = c.ten_kpi.Trim(),
                             ma_kpi = c.ma_kpi,                             
                             dvt = c.dvt,
                             loai_dvt = c.loai_dvt,
                             check = false,
                             sap_xep = b.sap_xep
                         });

            return query;
        }
        // het quang them
     
    }
}


