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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace relojDigital
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            horaDecena = new Rectangle[] { hd1, hd2, hd3, hd4, hd5, hd6, hd7 };            
            horaUnidad = new Rectangle[] { hu1, hu2, hu3, hu4, hu5, hu6, hu7 };
            minutoDecena = new Rectangle[] { md1, md2, md3, md4, md5, md6, md7 };
            minutoUnidad = new Rectangle[] { mu1, mu2, mu3, mu4, mu5, mu6, mu7 };

        }
        Rectangle[] horaDecena;
        Rectangle[] horaUnidad;
        Rectangle[] minutoDecena;
        Rectangle[] minutoUnidad;
      
        public int horas { get => ; set => ; }
        [Category("Reloj"), Description("Introduce la hora")];
    }
}
