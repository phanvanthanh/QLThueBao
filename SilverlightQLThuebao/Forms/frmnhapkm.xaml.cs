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
    public partial class frmnhapkm : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<kh_mai> LoadOp;
        bool m_update;
        public frmnhapkm(bool update)
        {
            InitializeComponent();
            m_update = update;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<kh_mai> Query = dstb.GetKh_maiQuery();
            if (m_update)
               LoadOp = dstb.Load(Query.Where(p => p.ma_km.Trim() == this.txtmakm.Text.Trim().ToUpper()), UpdateData, null);
            else
               LoadOp = dstb.Load(Query.Where(p => p.ma_km.Trim() == this.txtmakm.Text.Trim().ToUpper()), SaveData, null);
            // SaveData1();
        }

        private void UpdateData(LoadOperation<kh_mai> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).ten_ct = txtten.Text.Trim();
                lo.Entities.ElementAt(0).ngay_bd = dbatdau.DateTime;
                lo.Entities.ElementAt(0).ngay_kt = dketthuc.DateTime;
                lo.Entities.ElementAt(0).hieu_luc= chkhieuluc.IsChecked == true ? true : false;                
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<kh_mai> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã chương trình " + this.txtmakm.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmakm.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    kh_mai km = new kh_mai
                    {
                        ma_km = txtmakm.Text.Trim().ToUpper(),
                        ten_ct = txtten.Text.Trim(),
                        ngay_bd = dbatdau.DateTime,
                        ngay_kt=dketthuc.DateTime,
                        hieu_luc= chkhieuluc.IsChecked == true ? true : false
                    };
                    dstb.kh_mais.Add(km);
                    dstb.SubmitChanges(OnSubmitCompleted, true);
                }
                else
                    MessageBox.Show("Nhập chưa đủ thông tin");
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
                if (m_update)
                    this.DialogResult = false;
                else
                {
                    MessageBox.Show("Đã thêm chương trình :" + txtten.Text.Trim());
                    this.txtten.Text = "";
                    this.txtmakm.Text = "";
                    this.dbatdau.EditValue = null;
                    this.dketthuc.EditValue = null;
                    this.txtmakm.Focus();
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmkhuyenmai frm = new frmkhuyenmai();           
            frm.Show();
        }

    }
}

