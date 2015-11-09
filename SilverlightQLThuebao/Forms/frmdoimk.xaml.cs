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
    public partial class frmdoimk : ChildWindow
    {
        QLThuebaoDomainContext users = new QLThuebaoDomainContext();
        FunAndPro callF = new FunAndPro();
        public frmdoimk()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtpass.Password.Trim() != App.Password)            
            {
                MessageBox.Show("Mật khẩu cũ không đúng !");
                return;
            }

            if (txtpassnew.Password.Trim() != txtpassrenew.Password.Trim())
            {
                MessageBox.Show("Mật khẩu mới không giống nhau !");
                return;
            }
            else
            {
                if (txtpass.Password.Trim() == txtpassnew.Password.Trim())
                {
                    MessageBox.Show("Mật khẩu cũ và mật khẩu mới không được giống nhau !");
                    return;
                }
                EntityQuery<user> Query = users.GetUsersQuery();
                LoadOperation<user> LoadOp = users.Load(Query.Where(p => p.user_name.Trim() == App.User_name), UpdateData, null);
            }
        }

        void UpdateData(LoadOperation<user> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                string p = callF.EncrytedString(this.txtpassnew.Password);               
                lo.Entities.ElementAt(0).m_password =p;
                lo.Entities.ElementAt(0).lan_dau = false;
                App.Password = this.txtpassnew.Password;
                App.lan_dau = false;
                users.SubmitChanges(OnSubmitCompleted, true);                   
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
                MessageBox.Show("Đổi mật khẩu thành công !");
                this.DialogResult = false; 
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

