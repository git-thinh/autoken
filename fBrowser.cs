﻿using CefSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using CefSharp.WinForms;
using System.Diagnostics;

namespace autoken
{
    public partial class fBrowser : Form, IRequestHandler 
    {
        private readonly WebView web_view;
        public fBrowser(string url)
        {
            //if (!CEF.Initialize(new Settings()))
            //{
            //    ////////if (Environment.GetCommandLineArgs().Contains("--type=renderer"))
            //    ////////{
            //    ////////    Environment.Exit(0);
            //    ////////}
            //    ////////else
            //    ////////{
            //    ////////    return;
            //    ////////}
            //}

            web_view = new WebView(url, new BrowserSettings());
            web_view.Dock = DockStyle.Fill;
            web_view.RequestHandler = this;
            web_view.PropertyChanged += Web_view_PropertyChanged;

            this.Controls.Add(web_view);
            //this.WindowState = FormWindowState.Maximized;
            this.Text = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: x86", CEF.ChromiumVersion, CEF.CefVersion, CEF.CefSharpVersion);

            var btn = new Button() { Location = new System.Drawing.Point(0, 0), Text = "DEV", Width = 45 };
            btn.Click += (se, ev) => {
                web_view.ShowDevTools();
            };
            this.Controls.Add(btn);

            btn.BringToFront();
        }

        private void Web_view_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("--------->" + e.PropertyName);
        }

        public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, NavigationType naigationvType, bool isRedirect)
        {
            return false;
        }

        public bool OnBeforeResourceLoad(IWebBrowser browser, IRequestResponse requestResponse)
        {
            return false;
        }
         

        public void OnResourceResponse(IWebBrowser browser, string url, int status, string statusText, string mimeType, WebHeaderCollection headers)
        {
        }
    }
}
