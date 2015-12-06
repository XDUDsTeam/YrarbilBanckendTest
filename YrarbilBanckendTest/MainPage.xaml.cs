using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using System.Runtime.Serialization.Json;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace YrarbilBanckendTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// 是否登陆
        /// </summary>
        bool isLogined = false;
        string strSource { get; set; }


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {


            Login.Flyout = logoutFo;
            isLogined = true;
            loginFo.Hide();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login.Flyout = loginFo;
            isLogined = false;
            logoutFo.Hide();
        }

        private void requestText_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private string http_get(Uri u,IHttpContent i)
        {
            HttpClient httpClient = new HttpClient();
            var httpHeaders = httpClient.DefaultRequestHeaders;
            if (!httpHeaders.UserAgent.TryParseAdd("YrarbilBackend-testclient"))
                throw new Exception("Invalid header value: YrarbilBackend - testclient");
            HttpResponseMessage httpRes = new HttpResponseMessage();
            try
            {
                httpResponse
            }
            return null;
        }

    }
}
