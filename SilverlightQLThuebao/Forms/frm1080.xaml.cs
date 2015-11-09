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
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;

namespace SilverlightQLThuebao
{
    public partial class frm1080 : DXWindow
    {
        public string m_info, m_so;
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        public frm1080()
        {
            InitializeComponent();
            this.Title = "Danh bạ 1080";
        }

        private void cmdsearch_Click(object sender, RoutedEventArgs e)
        {
            search();
        }

        void search()
        {
            gridControl1.ItemsSource = null;
            gridControl1.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            //if ((txtsodt.Text.Trim() != "" || txtsodt.Text.Trim() != "0") && txtsodt.Text.Trim().Length < 7)
            //{
            //    MessageBox.Show("Nhập chưa đúng số điện thoại !");
            //    return;
            //}
            if (txtsodt.Text.Trim() != "" && txtsodt.Text.Trim() !="0")
            {
                EntityQuery<DSCD> Query = db.Getds1080Query(txtsodt.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }
            if (txttentb.Text.Trim() != "" && txtdcld.Text.Trim() == "" && txtttin108.Text.Trim() == "")
            {
                EntityQuery<DSCD> Query = db.Getds10801Query(txttentb.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }

            if (txttentb.Text.Trim() != "" && txtdcld.Text.Trim() != "" && txtttin108.Text.Trim() == "")
            {
                EntityQuery<DSCD> Query = db.Getds10802Query(txttentb.Text.Trim(), txtdcld.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }

            if (txttentb.Text.Trim() != "" && txtdcld.Text.Trim() != "" && txtttin108.Text.Trim() != "")
            {
                EntityQuery<DSCD> Query = db.Getds10803Query(txttentb.Text.Trim(), txtdcld.Text.Trim(), txtttin108.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }

            if (txttentb.Text.Trim() == "" && txtdcld.Text.Trim() == "" && txtttin108.Text.Trim() != "")
            {
                EntityQuery<DSCD> Query = db.Getds10804Query(txtttin108.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }
            if (txttentb.Text.Trim() == "" && txtdcld.Text.Trim() != "" && txtttin108.Text.Trim() == "")
            {
                EntityQuery<DSCD> Query = db.Getds10805Query(txtdcld.Text.Trim());
                LoadOperation<DSCD> Load = db.Load(Query, LoadOpComplete, null);
            }
        }

        void LoadOpComplete(LoadOperation<DSCD> lo)
        {
            this.Title = "Kết quả tìm kiếm : " + lo.Entities.Count().ToString();
            gridControl1.ItemsSource = lo.Entities;
            gridControl1.ShowLoadingPanel = false;
        }

        private void txtsodt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                search();
        }

        private void cmbnew_Click(object sender, RoutedEventArgs e)
        {
            txtsodt.Text = "";
            txttentb.Text = "";
            txtdcld.Text = "";
            txtttin108.Text = "";
            txtsodt.Focus();
     
        }

        private void txtdcld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                search();
        }

        private void txtttin108_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                search();
        }

        private void txttentb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                search();
        }

        private void ttin108s_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                m_info = gridControl1.GetFocusedRowCellValue(ttin108s).ToString().Trim();
                m_so = gridControl1.GetFocusedRowCellValue(so_dt).ToString().Trim();
                if (m_info !="")
                    update_info(m_so);
            }
        }
        void update_info(string m_so)
        {         
            EntityQuery<ds_codinh> Query = db.GetDs_codinhQuery();
            LoadOperation<ds_codinh> Load = db.Load(Query.Where(p=>p.so_dt==m_so), LoadOpCompletes, null);
        }

        void LoadOpCompletes(LoadOperation<ds_codinh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).ttin108s = m_info;
                db.SubmitChanges(OnSubmitCompleted, true);
            }
            else
            {                
                EntityQuery<Gphone> Query = db.GetGphonesQuery();
                LoadOperation<Gphone> Load = db.Load(Query.Where(p => p.so_dt == m_so), LoadOpCompleteG, null);
            }
        }
        void LoadOpCompleteG(LoadOperation<Gphone> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                lo.Entities.ElementAt(0).ttin108s = m_info;
                db.SubmitChanges(OnSubmitCompleted, true);
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
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");              
            }
        }
    }
}
