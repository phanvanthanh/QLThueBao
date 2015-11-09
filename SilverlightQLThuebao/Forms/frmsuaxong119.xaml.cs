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
    public partial class frmsuaxong119 : ChildWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        LoadOperation<CnfgStatus119> LoadOp;
        string m_so;
        public frmsuaxong119(string m_so119)
        {
            InitializeComponent();
            m_so = m_so119;
            EntityQuery<CnfgStatus119> Query = db.GetCnfgStatus119Query();
            LoadOp = db.Load(Query.OrderBy(p => p.iStatusID), LoadOp_Complete, null);

        }

        void LoadOp_Complete(LoadOperation<CnfgStatus119> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbloaihong.DisplayMember = "sStatus";
                this.cmbloaihong.ValueMember = "iStatusID";
                this.cmbloaihong.ItemsSource = lo.Entities;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
              QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
              int m= Convert.ToInt16(cmbloaihong.GetKeyValue(cmbloaihong.SelectedIndex).ToString());            
              InvokeOperation<System.Nullable<int>> p = dstb.Excute_p_suaxong119(m_so,m,App.User_name);
              p.Completed += new EventHandler(Completed);          
        }


        void Completed(object sende, EventArgs e)
        {
            this.DialogResult = false;         
        }        
    }
}

