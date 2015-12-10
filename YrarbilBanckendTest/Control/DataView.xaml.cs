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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YrarbilBanckendTest
{

    public enum _BoxType { _Code, _Html, _Json };
    public sealed partial class DataView : UserControl
    {
        public DataView()
        {
            this.InitializeComponent();
            pri_DataContext = "";
            boxType = _BoxType._Html;
            BoxTypeChange();
            ContextChanged += ContextChange;
            BoxTypeChanged += BoxTypeChange;
        }

        private string pri_DataContext;
        public string Context
        {
            get { return pri_DataContext; }
            set
            {
                pri_DataContext = value;
                ContextChanged();
            }
        }

        private _BoxType boxType;
        public _BoxType BoxType
        {
            get { return boxType; }
            set
            {
                boxType = value;
                BoxTypeChanged();
            }
        }


        private void BoxTypeChange()
        {
            switch (boxType)
            {
                case _BoxType._Code:
                    var scroll = new ScrollViewer();
                    var con = new RichTextBlock();
                    con.Blocks.Clear();
                    var p = new Windows.UI.Xaml.Documents.Paragraph();
                    p.Inlines.Add(new Windows.UI.Xaml.Documents.Run { Text = pri_DataContext });
                    con.Blocks.Add(p);
                    scroll.Content = con;
                    frame.Content = scroll;
                    break;
                case _BoxType._Html:
                    var html = new WebView();
                    html.NavigateToString(pri_DataContext);
                    frame.Content = html;
                    break;
                case _BoxType._Json:
                    frame.Content = new Grid();
                    break;
            };
        }

        private void ContextChange()
        {
            switch (boxType)
            {
                case _BoxType._Code:
                    var con = (frame.Content as ScrollViewer).Content as RichTextBlock;
                    con.Blocks.Clear();
                    var p = new Windows.UI.Xaml.Documents.Paragraph();
                    p.Inlines.Add(new Windows.UI.Xaml.Documents.Run { Text = pri_DataContext });
                    con.Blocks.Add(p);
                    frame.Content = con;
                    break;
                case _BoxType._Html:
                    var html = frame.Content as WebView;
                    html.NavigateToString(pri_DataContext);
                    frame.Content = html;
                    break;
                case _BoxType._Json:
                    frame.Content = new Grid();
                    break;
            };
        }

        public delegate void EBoxTypeChanged();
        public delegate void EContextChanged();

        public event EBoxTypeChanged BoxTypeChanged;
        public event EContextChanged ContextChanged;
        

    }
}
