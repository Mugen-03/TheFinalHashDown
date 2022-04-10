using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleOneWayHashing.Views
{
    /// <summary>
    /// Interaction logic for HasherView.xaml
    /// </summary>
    public partial class HasherView : Window
    {
        public HasherView()
        {
            InitializeComponent();
        }
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("copied");
        }
        private void xlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void xGetHash_Click(object sender, RoutedEventArgs e)
        {
            xlist.Items.Add(PlainText.Text);
            xlist.Items.Add(Salt.Text);
            xlist.Items.Add(HashedString.Text);
            
        }

        private void xClearTxtBox_Click(object sender, RoutedEventArgs e)
        {
            xlist.Items.Clear();
        }
    }
}
