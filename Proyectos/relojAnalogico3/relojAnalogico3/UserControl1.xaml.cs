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

namespace relojAnalogico3
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        [Description("Inserte un valor"),Category("Reloj"),DisplayName("Hora")]
        public int hora { get => (int)angHor.Angle/30; set => actualizarHora(value); }
        [Description("Inserte un valor"), Category("Reloj"), DisplayName("Minuto")]

        public int minuto { get => (int)angMin.Angle / 6; set => actualizarMinuto(value); }
        [Description("Inserte un valor"), Category("Reloj"), DisplayName("Segundo")]

        public int segundo { get => (int)angSec.Angle / 6; set => actualizarSegundo(value); }
        public UserControl1()
        {
            InitializeComponent();
        }

        public void actualizarHora(int valor)
        {
                angHor.Angle = valor * 30;
        }
        public void actualizarMinuto(int valor)
        {
                angMin.Angle = valor * 6;

        }
        public void actualizarSegundo(int valor)
        {
                angSec.Angle = valor * 6;
        }
    }
}
