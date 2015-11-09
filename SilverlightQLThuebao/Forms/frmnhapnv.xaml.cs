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
using DevExpress.Xpf.Core;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;


namespace SilverlightQLThuebao
{
    public partial class frmnhapnv : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmnhapnv()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult=false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<nv_thuethu> Query = dstb.GetNv_thuethuQuery();
            LoadOperation<nv_thuethu> LoadOp = dstb.Load(Query.Where(p => p.ten.Trim() == this.txttuyen.Text.Trim().ToUpper() && p.ma_huyen==App.ma_huyen), SaveData, null);
            // SaveData1();
        }
        private void SaveData(LoadOperation<nv_thuethu> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Tuyến thu " + this.txttuyen.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {               

                if (txttuyen.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    nv_thuethu nv = new nv_thuethu
                    {
                        ten = txttuyen.Text.Trim().ToUpper(),
                        ten_nv = txtten.Text.Trim(),
                        ghi_chu=txtghichu.Text.Trim(),
                        ma_huyen=App.ma_huyen
                    };
                    dstb.nv_thuethus.Add(nv);
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
                MessageBox.Show("Đã thêm tuyến :" + txttuyen.Text.Trim().ToUpper());
                this.txtten.Text = "";
                this.txttuyen.Text = "";
                this.txtghichu.Text = "";
                this.txttuyen.Focus();           
            }
        }

        private void DXWindow_Closed(object sender, EventArgs e)
        {
            frmthuethu nv = new frmthuethu();
            nv.Show();
        }

    }
}
