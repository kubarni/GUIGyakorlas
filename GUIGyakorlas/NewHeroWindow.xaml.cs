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

namespace GUIGyakorlas
{
    /// <summary>
    /// Interaction logic for NewHeroWindow.xaml
    /// </summary>
    public partial class NewHeroWindow : Window
    {
        public NewHeroWindow(Hero h)
        {
            InitializeComponent();
            this.DataContext = new NewHeroWindowViewModel();
            (this.DataContext as NewHeroWindowViewModel).Setup(h);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack1.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
