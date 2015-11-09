using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Drawing;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;
using DevExpress.Xpf.Editors;

namespace SilverlightQLThuebao
{
    public class FunAndPro
    {
        MemoryStream stream;
        public static string GetSelectedKeyValue(ComboBoxEdit cmb, int rowLoai)
        {
            string temp = "";
            string temp1 = "";
            foreach (var p in cmb.SelectedItems)
            {
                temp += p.ToString();
            }
            for (int i = 0; i < rowLoai; i++)
            {
                string key = cmb.GetKeyValue(i).ToString().Trim();
                if (temp.Contains(key))
                    if (temp1 == "")
                    {
                        temp1 += key;
                    }
                    else
                        temp1 = temp1 + ";" + key;
            }
            return temp1;

        }

        public string Catchuoi(string chuoi, int cons)
        {
            string temp = "";
            int j;
            string[] strs;
            strs = chuoi.Split(' ');
            j = 0;
            cons -= 1;
            foreach (string s in strs)
            {
                temp += s + " ";
                j += 1;
                if (j > cons)
                {
                    temp += System.Environment.NewLine;
                    j = 0;
                }

            }
            return temp;
        }




        public string EncrytedString(string str)
        {
            byte[] _encryted = System.Text.Encoding.Unicode.GetBytes(str);
            string s = Convert.ToBase64String(_encryted);
            return s;
        }

        public string DecrytedString(string str)
        {
            byte[] _decryted = Convert.FromBase64String(str);
            string s = System.Text.Encoding.Unicode.GetString(_decryted, 0, _decryted.ToArray().Length);
            return s;
        }

        public static string KhongDau(string str)
        {
            string s = "";
            string sA = "¢,Ê,Ç,È,É,Ë,¡,¾,»,¼,½,Æ,¸,µ,¶,·,¹,©,¨";
            string sE = "£,Õ,Ò,Ó,Ô,Ö,Ð,Ì,Î,Ï,Ñ,ª,Õ,Ò,Ó,Ô,Ö,Ð,Ì,Î,Ï,Ñ,Ð,Ì,Î,Ï,Ñ,Ò,Î";
            string sU = "ò,ï,ñ,ó,­,÷,ô,õ,ö,ø,ù";
            string sO = "¤,ç,ä,å,æ,è,¥,ì,é,ê,ë,í,â,ß,á,ã,¬,«,î";
            string sI = "Ø,Ü,i,×,Ý,Þ";
            string sY = "ü,ú,û,ý";
            string sD = "§,®";

            for (int i = 0; i < str.Length; i++)
            {
                string s1 = str.Substring(i, 1);
                if (s1 !=",")
                {
                    if (sA.Contains(s1))
                        s1 = "A";
                    if (sE.Contains(s1))
                        s1 = "E";
                    if (sU.Contains(s1))
                        s1 = "U";
                    if (sO.Contains(s1))
                        s1 = "O";
                    if (sI.Contains(s1))
                        s1 = "I";
                    if (sY.Contains(s1))
                        s1 = "Y";
                    if (sD.Contains(s1))
                        s1 = "D";
                }
                s += s1.ToUpper();
            }
            return s.Trim();
        }


        public static bool ContainsUnicodeCharacter(char[] input)
        {
            const int MaxAnsiCode = 255;
            bool temp;
            string s;

            foreach (char a in input)
            {
                s = a.ToString();
                temp = s.Any(c => c > MaxAnsiCode); // true neu la unicode
                if (temp == true)
                {
                    return true;
                }
            }
            return false;
        }


        public static string ma_st(string st)
        {
            string mst = ". .   . . . . . . .  .  . . .  .";
            string[] chuoi = new string[mst.Length];
            string sttemp = "";           
            for (int i = 0; i < st.Length; i++)
            {
                if (st.Substring(i, 1) != " ")
                    sttemp += st.Substring(i, 1);
            }
            st = sttemp;
            for (int i = 0; i < mst.Length; i++)
            {
                chuoi[i] = mst.Substring(i, 1);
            }
            int r = 0;
            for (int k = 0; k < st.Length; k++)
            {
                for (int j = r; j < mst.Length; j++)
                {
                    if (chuoi[j] == ".")
                    {
                        chuoi[j] = st.Substring(k, 1);
                        r = j + 1;
                        break;
                    }
                }
            }
            string t = "";
            for (int i = 0; i < mst.Length; i++)
            {
                t += chuoi[i] == "." ? "" : chuoi[i];
            }
            return t;
        }


        public static void CheckUser(Button cmdSua)
        {
            if (App.sua && (cmdSua.Name == "cmdSua" || cmdSua.Name == "cmdCat" || cmdSua.Name == "cmdThem" || cmdSua.Name == "cmdXoa"))
            {
                cmdSua.IsEnabled = true;
                return;
            }
            else
            {
                cmdSua.IsEnabled = false;
                return;
            }         
        }



        public void GetDateTime()
        {
            var fs = new UploadService.UploadClient();
            fs.GetDateTimeCompleted += new EventHandler<SilverlightQLThuebao.UploadService.GetDateTimeCompletedEventArgs>(fs_GetDateTimeCompleted);
            fs.GetDateTimeAsync();
        }

        void fs_GetDateTimeCompleted(object sender, UploadService.GetDateTimeCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    App.Current_d = e.Result;
                    //if (App.Current_d.Day == 1 || App.Current_d.Day == 2 || Convert.ToInt16(App.Current_d.DayOfWeek)==1)
                    //    App.m_ngaymin = 2;
                    //else
                    //    App.m_ngaymin = 1;

                    App.Min_Date = App.Current_d.AddDays(-2);
                    App.Min_Date = App.Min_Date.AddHours(-App.Min_Date.Hour);
                    App.Min_Date = App.Min_Date.AddMinutes(-App.Min_Date.Minute);
                    App.Min_Date = App.Min_Date.AddSeconds(-App.Min_Date.Second);
                }
                else
                {
                    MessageBox.Show("Không lấy được thời gian trên server !");
                }
            }
        }
     
    }
}
