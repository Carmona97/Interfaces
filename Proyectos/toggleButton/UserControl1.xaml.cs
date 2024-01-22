using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace toggleButton
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        
        public bool pulsado
        {
            get => miCheck.IsChecked.Value;
            set => miCheck.IsChecked = value;

        }

        [Description("Esta es el toggleButton de ios"), Category("botones"), DisplayName("Introduce el color")]
        public Brush establecerColor
        {
            set => miCheck.Background = value;
            get => miCheck.Background;
        }

        private void miCheck_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
