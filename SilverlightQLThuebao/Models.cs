using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

public class TuyenList : ObservableCollection<tuyen>
{
    public TuyenList()
        : base()
    {
        Add(new tuyen { });
    }
}


public class tuyencskh
{    
    public string so_dt { get; set; }

    public string ma_kh { get; set; }

    public string ten_dktb { get; set; }

    public string ten_dkdb { get; set; }

    public string dia_chitb { get; set; }

    public string dc_tbld { get; set; }

    public string ma_tram { get; set; }

    public string ma_nvcs { get; set; }

}



public class TuyenCSKH : ObservableCollection<tuyencskh>
{
    public TuyenCSKH()
        : base()
    {
        Add(new tuyencskh { });
    }
}

 public class Gan
    {
        public string so_dt { get; set; }     

        public string ten_dktb { get; set; }

        public string dia_chitb { get; set; }

        public string dc_tbld { get; set; }

        public string ma_nvcs { get; set; }

        public string ma_nvkt { get; set; }

        public string ten_nv { get; set; }

        public string ten_nvkt { get; set; }

    }

public class GanDB : ObservableCollection<Gan>
{
    public GanDB()
        : base()
    {
        Add(new Gan { });
    }
}


public class DSCatmo : ObservableCollection<Catmo>
{
    public DSCatmo()
        : base()
    {
        Add(new Catmo { });
    }
}

public class BSC_tinh : ObservableCollection<BSCT>
{
    public BSC_tinh()
        : base()
    {
        Add(new BSCT { });
    }
}

public class BSC_tinh_temp : ObservableCollection<BSCT>
{
    public BSC_tinh_temp()
        : base()
    {
        Add(new BSCT { });
    }
}