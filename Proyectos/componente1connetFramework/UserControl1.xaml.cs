using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace componente1connetFramework
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            labelContador.Content ="0/" + miTexto.MaxLength;
        }

        public string etiqueta
        {
            get => miLabel.Content.ToString(); set => miLabel.Content = value;

        }
        [Description("")]

        public string bloqueTexto
        {
            get => miTexto.Text; set => miTexto.Text = value;
        }

        private void miTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            labelContador.Content = Convert.ToString(miTexto.Text.Length);
            labelContador.Content = labelContador.Content + "/"+miTexto.MaxLength;
        }
    }
}
