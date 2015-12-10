using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace YrarbilBanckendTest.Classes
{
    static class Settings
    {
        public static string hostname
        {
            get
            {
                return (ApplicationData.Current.LocalSettings.Values["hostname"] as string);
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["hostname"] = value;
            }
        }
        public static string port
        {
            get
            {
                return (ApplicationData.Current.LocalSettings.Values["port"] as string);
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values["port"] = value;
            }

        }
    }
}
