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
using System.Net.Browser;

namespace SilverlightQLThuebao
{
    public partial class App : Application
    {
        public static string User_name { get; set; }
        public static string Password { get; set; }
        public static string hoten { get; set; }
        public static string ma_huyen { get; set; }
        public static string nhomtd { get; set; }
        public static string ten_huyen { get; set; }
        public static string batdau_mkh { get; set; }
        public static string batdau_119 { get; set; }
        public static int refix_119 { get; set; }
        public static bool admin_119 { get; set; }
        public static string e_menu { get; set; }
        public static int len_sdt { get; set; }
        public static string sonha { get; set; }
        public static string sonhald { get; set; }
        public static string khom { get; set; }
        public static string duong { get; set; }
        public static string phuong { get; set; }
        public static string khomld { get; set; }
        public static string duongld { get; set; }
        public static string phuongld { get; set; }
        public static string m_phuong { get; set; }
        public static string tinhthanh { get; set; }
        public static bool sua { get; set; }
        public static bool admin { get; set; }
        public static bool adminBSC_VTT { get; set; }
        public static bool adminBSC_TTKD { get; set; }
        public static bool kythuat { get; set; }
        public static string nguoidaidien { get; set; }
        public static string chucvu { get; set; }
        public static string nhanvienld { get; set; }
        public static string tghoamang { get; set; }
        public static string soSIM { get; set; }
        public static string thongtinkhac { get; set; }
        public static string ip_address { get; set; }
    //    public static string computer_name { get; set; }
        public static bool lan_dau { get; set; }
        public static DateTime Current_d { get; set; }
        public static DateTime Min_Date { get; set; }
        public static Int32 m_themes { get; set; }
        public static string id_goicuoc { get; set; }
     //   public static Int32 m_ngaymin { get; set; }
        //public static  string[] m_kdcs {get; set;}
        //public static string[] m_ktcs { get; set; }   
          
   
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
           // this.RootVisual = new MainPage();
            HttpWebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            HttpWebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp);
            Grid g = new Grid();
            this.RootVisual = g;
            LoginPage p = new LoginPage();
            g.Children.Add(p);
            len_sdt = 7;
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
