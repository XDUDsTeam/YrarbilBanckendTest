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
using System.Threading.Tasks;

using YrarbilBanckendTest.Classes;

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
        DataView dv;
        string strSource
        {
            get
            {
                return dv.Context;
            }
            set
            {
                dv.Context = value;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            dv = new DataView();
            subP.Content = dv;
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            Login.Flyout = loginFo;
            loginFo.Hide();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login.Flyout = loginFo;
            logoutFo.Hide();
        }
        

        private async void subP_Loaded(object sender, RoutedEventArgs e)
        {
            var hostname = Settings.hostname;
            var port = Settings.port;
            if (port == null || port == "")
                port = "80";
            if (hostname == null || hostname == "")
                hostname = "http://cn.bing.com";
            strSource = await HttpReq.http_get(new Uri(hostname+":"+port+"/"));
        }

        private void toHtml_Click(object sender, RoutedEventArgs e)
        {
            dv.BoxType = _BoxType._Html;
            ShowWay.Icon = new SymbolIcon(Symbol.Globe);
            subP.Content = dv;
        }

        private void toJson_Click(object sender, RoutedEventArgs e)
        {
            dv.BoxType = _BoxType._Json;
            ShowWay.Icon = new SymbolIcon(Symbol.Document);
            subP.Content = dv;
        }

        private void toText_Click(object sender, RoutedEventArgs e)
        {
            dv.BoxType = _BoxType._Code;
            ShowWay.Icon = new SymbolIcon(Symbol.List);
            subP.Content = dv;
        }

        private async void homeB_Click(object sender, RoutedEventArgs e)
        {
            strSource = await HttpReq.http_get(new Uri("http://cn.bing.com"));
            subP.Content = dv;
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            subP.Navigate(typeof(Setting), null);
        }
    }
}
