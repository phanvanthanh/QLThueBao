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
    public partial class frmnhapxa : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_xa> LoadOp;
        bool m_update;
        public frmnhapxa(bool update)
        {
            InitializeComponent();
            m_update = update;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<ma_xa> Query = dstb.GetMa_xaQuery();
            if (m_update)
               LoadOp = dstb.Load(Query.Where(p => p.maxa == this.txtmaxa.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), UpdateData, null);
            else
               LoadOp = dstb.Load(Query.Where(p => p.maxa == this.txtmaxa.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), SaveData, null);
            // SaveData1();
        }

        private void UpdateData(LoadOperation<ma_xa> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).ten = txtten.Text.Trim();
                lo.Entities.ElementAt(0).tientb = 20000;
                lo.Entities.ElementAt(0).vtci = false;
                lo.Entities.ElementAt(0).ma_huyen = App.ma_huyen;
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<ma_xa> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã xã phường " + this.txtmaxa.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmaxa.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    ma_xa xa = new ma_xa
                    {
                        maxa = txtmaxa.Text.Trim().ToUpper(),
                        ten = txtten.Text.Trim(),
                        tientb = 20000,
                        vtci=false,
                        ma_huyen = App.ma_huyen
                    };
                    dstb.ma_xas.Add(xa);
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
                    MessageBox.Show("Đã thêm xã :" + txtten.Text.Trim());
                    this.txtten.Text = "";
                    this.txtmaxa.Text = "";
                    this.txtghichu.Text = "";
                    this.txtmaxa.Focus();
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmxaphuong frm = new frmxaphuong();           
            frm.Show();
        }

    }
}

