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
        bool isLogined;
        string strSource
        {
            get
            {
                string t1 = subCode.text,t2 = subJson.text,t3=subHtml.text;
                if (t1 == t2 && t2 == t3)
                    return t1;
                else
                    throw new Exception("why?");
            }
            set
            {
                subCode.text = value;
                subJson.text = value;
                subHtml.text = value;
            }
        }
        Code subCode { get; set; }
        Json subJson { get; set; }
        Html subHtml { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            isLogined = false;
            subCode = new Code();
            subHtml = new Html();
            subJson = new Json();
            subP.Content = subCode;
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {

            
            Login.Flyout = loginFo;
            isLogined = true;
            loginFo.Hide();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login.Flyout = loginFo;
            isLogined = false;
            logoutFo.Hide();
        }
        
        private async Task<string> http_get(Uri u)
        {
            HttpClient httpClient = new HttpClient();
            var httpHeaders = httpClient.DefaultRequestHeaders;
            if (!httpHeaders.UserAgent.TryParseAdd("YrarbilBackend-testclient"))
                throw new Exception("Invalid header value: YrarbilBackend - testclient");
            HttpResponseMessage httpRes = new HttpResponseMessage();
            string rt;
            try
            {
                httpRes = await httpClient.GetAsync(u);
                httpRes.EnsureSuccessStatusCode();
                rt = await httpRes.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                rt = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
            }
            return rt;
        }

        private async Task<string> http_post(Uri u, IHttpContent c)
        {
            HttpClient httpClient = new HttpClient();
            var httpHeaders = httpClient.DefaultRequestHeaders;
            if (!httpHeaders.UserAgent.TryParseAdd("YrarbilBackend-testclient"))
                throw new Exception("Invalid header value: YrarbilBackend - testclient");
            HttpResponseMessage httpRes = new HttpResponseMessage();
            string rt;
            try
            {
                httpRes = await httpClient.PostAsync(u, c);
                httpRes.EnsureSuccessStatusCode();
                rt = await httpRes.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                rt = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
            }
            return rt;
        }

        private async void subP_Loaded(object sender, RoutedEventArgs e)
        {
            strSource = await http_get(new Uri("http://cn.bing.com"));
        }

        private void toHtml_Click(object sender, RoutedEventArgs e)
        {
            subP.Content = subHtml;
        }

        private void toJson_Click(object sender, RoutedEventArgs e)
        {
            subP.Content = subJson;
        }

        private void toText_Click(object sender, RoutedEventArgs e)
        {
            subP.Content = subCode;
        }
    }
}
