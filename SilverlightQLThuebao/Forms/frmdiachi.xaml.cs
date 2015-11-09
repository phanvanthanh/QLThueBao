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
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Services;
using SilverlightQLThuebao.Web.Models;

namespace SilverlightQLThuebao
{
    public partial class frmdiachi : ChildWindow
    {
        public string txtdiachi;
        public string maphuong;
        QLThuebaoDomainContext maxa = new QLThuebaoDomainContext();
        Boolean m_ld;
        public frmdiachi(Boolean ld)
        {
            InitializeComponent();
            m_ld = ld;
            txttp.Text = App.ten_huyen;
            EntityQuery<ma_xa> Query = maxa.GetMa_xaQuery();
            LoadOperation<ma_xa> LoadOp = maxa.Load(Query.Where(t => t.ma_huyen == App.ma_huyen).OrderBy(p=>p.ten), LoadOp_Complete, null);
            EntityQuery<ma_duong> Query1 = maxa.GetMa_duongQuery();
            LoadOperation<ma_duong> LoadOp1 = maxa.Load(Query1.OrderBy(p=>p.ten_duong), LoadOpD_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<ma_xa> lo)
        {
            if (lo.Entities.Count() > 0)
            {
               // this.cmbphuong.Items.Clear();
                this.cmbphuong.DisplayMember = ("ten").Trim();
                this.cmbphuong.ValueMember = "maxa";
                this.cmbphuong.ItemsSource = lo.Entities;
            }
        }

        void LoadOpD_Complete(LoadOperation<ma_duong> lo)
        {
            if (lo.Entities.Count() > 0)
            {
               // this.cmbduong.Items.Clear();
                this.cmbduong.DisplayMember = ("ten_duong").Trim();
                this.cmbduong.ValueMember = "id";
                this.cmbduong.ItemsSource = lo.Entities;
            }
        }      


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmbphuong.Text.Trim() != "")
            {
                //if (this.txtsonha.Text.Trim() == "")
                //  //  if (this.cmbduong.Text.Trim() == "")
                //   //     txtdiachi = this.cmbkhom.Text.Trim() + ", " + this.cmbphuong.Text.Trim() + ", " + txttp.Text.Trim();
                //  //  else
                //        txtdiachi = this.cmbduong.Text.Trim() + ", " + this.cmbkhom.Text.Trim() + ", " + this.cmbphuong.Text.Trim() + ", " + txttp.Text.Trim();
                //else
                //  //  if (this.cmbduong.Text.Trim() == "")
                //    //    txtdiachi = this.txtsonha.Text.Trim() + "," + this.cmbkhom.Text.Trim() + ", " + this.cmbphuong.Text.Trim() + ", " + txttp.Text.Trim();
                //   // else
                txtdiachi = this.txtsonha.Text.Trim() + " " + this.cmbduong.Text.Trim() + ", " + this.cmbkhom.Text.Trim() + ", " + this.cmbphuong.Text.Trim() + ", " + txttp.Text.Trim();
                txtdiachi=txtdiachi.Replace(", , ", ", ").Trim();
                txtdiachi = txtdiachi.Substring(0, 1) == "," ? txtdiachi.Substring(1, txtdiachi.Length - 1) : txtdiachi;
                //if (txtdiachi.Trim() == "")
                //{
                //    char[] s = txtdiachi.Trim().ToCharArray();
                //    MessageBox.Show(s[0].ToString());
                //    if (FunAndPro.ContainsUnicodeCharacter(s))
                //    {
                //        MessageBox.Show("sdfasdad");
                //        MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                //        this.txtsonha.Focus();
                //        return;
                //    }
                //}
                if (m_ld)
                {
                    App.sonhald = this.txtsonha.Text.Trim();
                    App.duongld = this.cmbduong.Text.Trim();
                    App.khomld = this.cmbkhom.Text.Trim();
                    App.phuongld = this.cmbphuong.Text.Trim();
                }
                else
                {
                    App.sonha = this.txtsonha.Text.Trim();
                    App.duong = this.cmbduong.Text.Trim();
                    App.khom = this.cmbkhom.Text.Trim();
                    App.phuong = this.cmbphuong.Text.Trim();
                }
                App.tinhthanh = this.txttp.Text.Trim();
                maphuong = cmbphuong.GetKeyValue(cmbphuong.SelectedIndex).ToString();
                App.m_phuong = maphuong;
                this.DialogResult = true;

            }
            else
                MessageBox.Show("Chưa nhập đầy đủ dữ liệu !");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void cmbphuong_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {           
           //  QLThuebaoDomainContext maap = new QLThuebaoDomainContext();
            string ma = cmbphuong.GetKeyValue(cmbphuong.SelectedIndex).ToString();           
            EntityQuery<ma_ap> Query = maxa.GetMa_apQuery();
            LoadOperation<ma_ap> LoadOp = maxa.Load(Query.Where(t => t.maxa == ma).OrderBy(p => p.ten_ap), LoadOpap_Complete, null);
        }

       void LoadOpap_Complete(LoadOperation<ma_ap> lo)
        {
            if (lo.Entities.Count() > 0)
            {
              // this.cmbkhom.Items.Clear();              
               this.cmbkhom.DisplayMember = ("ten_ap").Trim();
               this.cmbkhom.ValueMember = "maap"; 
               this.cmbkhom.ItemsSource = lo.Entities;
            }
        }

       private void ClearButton_Click(object sender, RoutedEventArgs e)
       {
           cmbduong.SelectedIndex = -1;
           cmbkhom.SelectedIndex = -1;
           txttp.Text = App.ten_huyen;
           txtsonha.Text = "";
           txtsonha.Focus();
       }

       private void txtsonha_LostFocus(object sender, RoutedEventArgs e)
       {
           if (txtsonha.Text.Trim() != "")
           {
               char[] s = txtsonha.Text.Trim().ToCharArray();
               FunAndPro callF = new FunAndPro();
               if (FunAndPro.ContainsUnicodeCharacter(s))
               {
                   MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                   txtsonha.Focus();
               }
           }
       }

       private void txttp_LostFocus(object sender, RoutedEventArgs e)
       {
           if (txttp.Text.Trim() != "")
           {
               char[] s = txttp.Text.Trim().ToCharArray();
               if (FunAndPro.ContainsUnicodeCharacter(s))
               {
                   MessageBox.Show("Nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");
                   txttp.Focus();
               }
           }
       }
       
    }
}

