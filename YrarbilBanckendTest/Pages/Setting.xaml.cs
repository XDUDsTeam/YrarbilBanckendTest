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
using YrarbilBanckendTest.Classes;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace YrarbilBanckendTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Setting : Page
    {
        public Setting()
        {
            this.InitializeComponent();
        }

        private void hostNameBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.hostname != null)
                hostNameBox.Text = Settings.hostname;
        }

        private void hostname_Update(object sender, RoutedEventArgs e)
        {
            Settings.hostname = hostNameBox.Text;
        }

        private void port_Update(object sender, RoutedEventArgs e)
        {
            Settings.port = portBox.Text;
        }


        private void portBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.hostname != null)
                portBox.Text = Settings.port;
        }
    }
}
