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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace creacionComponentes1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public string etiqueta
        {
            get => miLabel.Content.ToString() ; set => miLabel.Content = value; 
        }

        public string bloqueTexto
        {
            get => miTexto.Text; set => miTexto.Text = value; 
        }



        /*        public String getLabel()
                {
                    return miLabel.Content.ToString();
                }
                public void setLabel(String valor)
                {
                    miLabel.Content = valor;
                }
                public String getTexto()
                {
                    return miTexto.Text.ToString();
                }
                public void setTexto(String valor)
                {
                    miTexto.Text = valor;
                }*/
    }
}