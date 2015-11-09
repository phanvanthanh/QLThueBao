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
    public partial class frmnhapdiaban : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_diaban> LoadOp;
        bool m_update;      
        public frmnhapdiaban(bool update)
        {
            InitializeComponent();
            m_update = update;
            if (App.kythuat)
                checkEdit1.IsChecked = true;
            else
                checkEdit1.IsChecked = false;
            checkEdit1.IsEnabled = false;

            if (! m_update)            
                this.txtmanv.Text ="";
            else
                this.txtmanv.IsReadOnly = true;           
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EntityQuery<ma_diaban> Query = dstb.GetMa_diabanQuery();
            if (m_update)
               LoadOp = dstb.Load(Query.Where(p => p.ma_tuyen.Trim() == this.txtmanv.Text.Trim().ToUpper() && p.ma_huyen==App.ma_huyen && p.kt== App.kythuat), UpdateData, null);
            else
                LoadOp = dstb.Load(Query.Where(p => p.ma_tuyen == this.txtmanv.Text.Trim().ToUpper() && p.ma_huyen == App.ma_huyen), SaveData, null);
            // SaveData1();
        }

        private void UpdateData(LoadOperation<ma_diaban> lo)
        {

            if (lo.Entities.Count() > 0)
            {   
                lo.Entities.ElementAt(0).ten_tuyen = txtten.Text.Trim();               
                dstb.SubmitChanges(OnSubmitCompleted, true);
            }           
        }


        private void SaveData(LoadOperation<ma_diaban> lo)
        {

            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Mã tuyến " + this.txtmanv.Text.Trim().ToUpper() + " đã tồn tại");
            }
            else
            {

                if (txtmanv.Text.Trim() != "" || txtten.Text.Trim() != "")
                {
                    ma_diaban ap = new ma_diaban
                    {
                       ma_tuyen = txtmanv.Text.Trim().ToUpper(),
                       ten_tuyen = this.txtten.Text.Trim(),
                       ma_huyen=App.ma_huyen,
                       kt=checkEdit1.IsChecked                       
                    };
                    dstb.ma_diabans.Add(ap);
                    dstb.SubmitChanges(OnSubmitCompleted, true);
                }
                else
                    MessageBox.Show("Nhập chưa đủ thông tin hoặc sai qui cách nhập mã tuyến !");
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
                    MessageBox.Show("Đã thêm nhân viên :" + txtten.Text.Trim());
                    this.txtten.Text = "";
                    this.txtmanv.Text ="";                    
                    this.txtmanv.Focus();
                    //this.txtphone.Text = "";
                    //checkEdit1.IsChecked = false;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Closed(object sender, EventArgs e)
        {
            frmdiabancs frm = new frmdiabancs();
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }

        private void txtten_LostFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}

