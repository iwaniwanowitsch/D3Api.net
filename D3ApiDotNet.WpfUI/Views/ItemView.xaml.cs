using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace D3ApiDotNet.WpfUI.Views
{
    /// <summary>
    /// Interaktionslogik für ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        #region TestCode
        public string ImagePathForTesting
        {
            get { return ItemImage.Source.ToString(); }
            set { ItemImage.Source = new BitmapImage(new Uri(value)); }
        }

        public Style ColorForTesting
        {
            get { return ItemBorder.Style; }
            set { ItemBorder.Style = value; }
        }
        #endregion

        public ItemView()
        {
            InitializeComponent();
        }
    }
}
