using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmxoalog : ChildWindow
    {
        int m_loai;
        QLThuebaoDomainContext sp = new QLThuebaoDomainContext();
        FunAndPro callF = new FunAndPro();
        public frmxoalog(int loai)
        {
            InitializeComponent();
            callF.GetDateTime();
            m_loai = loai;
            dngayxoa.EditValue = App.Current_d;
            //0: xoa log ma so tong hop; 1: bang mau : 2: users
        }
     

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {         
                MessageBoxResult result = MessageBox.Show("Muốn xóa log trước thời gian " + dngayxoa.Text + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //if (m_loai == 0)
                    //{
                    //    EntityQuery<hanghoa_log> Query = sp.GetHanghoa_logQuery();
                    //    LoadOperation<hanghoa_log> LoadOp = sp.Load(Query.Where(p => p.ngay_tao <= dngayxoa.DateTime), DeleteCompleted, true);
                    //}

                    //if (m_loai == 1)
                    //{
                    //    EntityQuery<bangmau_log> Query = sp.GetBangmau_logQuery();
                    //    LoadOperation<bangmau_log> LoadOp = sp.Load(Query.Where(p => p.ngay_tao <= dngayxoa.DateTime), DeleteCompletedM, true);
                    //}

                    if (m_loai == 2)
                    {
                        EntityQuery<users_log> Query = sp.GetUsers_logQuery();
                        LoadOperation<users_log> LoadOp = sp.Load(Query.Where(p => p.thoi_gian <= dngayxoa.DateTime), DeleteCompletedU, true);
                    }


                }
                else
                    return;

         
        }
     
        private void DeleteCompletedU(LoadOperation<users_log> lo)
        {
            users_log usr;
            for (int i = 0; i < lo.Entities.Count(); i++)
            {
                usr = lo.Entities.ElementAt(i);
                sp.users_logs.Remove(usr);
            }
            sp.SubmitChanges(OnSubmitCompleted, null);
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
                MessageBox.Show("Đã xóa log !");
                this.DialogResult = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

