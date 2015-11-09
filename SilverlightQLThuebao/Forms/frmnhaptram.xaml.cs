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
    public partial class frmnhaptram : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<tram_vt> LoadOp;
        bool m_update;
        public frmnhaptram(bool update)
        {
            InitializeComponent();
            m_update = update;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            if (m_update)
               LoadOp = dstb.Load(Query.Where(p => p.ma_tram == this.txtmaxa.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), UpdateData, null);
            else
               LoadOp = dstb.Load(Query.Where(p => p.ma_tram == this.txtmaxa.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), SaveData, null);
            // SaveData1();
        }

        private void UpdateData(LoadOperation<tram_vt> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).ten_tram = txtten.Text.Trim();              
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<tram_vt> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã trạm viễn thông " + this.txtmaxa.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmaxa.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    tram_vt tram = new tram_vt
                    {
                        ma_tram = txtmaxa.Text.Trim().ToUpper(),
                        ten_tram = txtten.Text.Trim(),                        
                        ma_huyen = App.ma_huyen
                    };
                    dstb.tram_vts.Add(tram);
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
                    MessageBox.Show("Đã thêm trạm viễn thông :" + txtten.Text.Trim());
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
            frmtramvt frm = new frmtramvt();           
            frm.Show();
        }

    }
}

