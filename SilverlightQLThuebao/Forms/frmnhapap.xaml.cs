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
    public partial class frmnhapap : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_ap> LoadOp;
        bool m_update;
        string m_maxa;
        public frmnhapap(bool update,string maxa)
        {
            InitializeComponent();
            m_update = update;
            m_maxa = maxa;           
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<ma_ap> Query = dstb.GetMa_apQuery();
            if (m_update)
               LoadOp = dstb.Load(Query.Where(p => p.maap == this.txtmaap.Text.Trim().ToUpper() && p.maxa == m_maxa), UpdateData, null);
            else
                LoadOp = dstb.Load(Query.Where(p => p.maap == this.txtmaap.Text.Trim().ToUpper() && p.maxa == m_maxa), SaveData, null);
            // SaveData1();
        }

        private void UpdateData(LoadOperation<ma_ap> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).maxa = m_maxa;
                lo.Entities.ElementAt(0).maap = this.txtmaap.Text.Trim().ToUpper();
                lo.Entities.ElementAt(0).ten_ap = txtten.Text.Trim();                
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<ma_ap> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã xã phường " + this.txtmaap.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmaap.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    ma_ap ap = new ma_ap
                    {
                       maxa = m_maxa,
                       maap = this.txtmaap.Text.Trim().ToUpper(),
                       ten_ap = txtten.Text.Trim()            
                    };
                    dstb.ma_aps.Add(ap);
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
                    this.txtmaap.Text = "";                    
                    this.txtmaap.Focus();
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmapkhom frm = new frmapkhom();           
            frm.Show();
        }

    }
}

