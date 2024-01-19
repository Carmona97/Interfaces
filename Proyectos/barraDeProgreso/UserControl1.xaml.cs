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

namespace barraDeProgreso
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        int maximo;

        public UserControl1()
        {
            InitializeComponent();
            maximo = (int) rellenoRectangulo.Width;
        }

        [Description("Esta es la barra de progreso de la aplicacion"), Category("Porcentaje"), DisplayName("Introduce el valor")]
        public string BarraProgreso { get => porcentaje.Content.ToString().Substring(0,porcentaje.Content.ToString().Length -1); set => establecerValor(value); }


        public void establecerValor(string valor)
        {

            int progresoPorcentaje = int.Parse(valor);
            
            if (progresoPorcentaje > 100)
            {
                progresoPorcentaje = 100;
            }
            if(progresoPorcentaje < 0)
            {
                progresoPorcentaje = 0;
            }
            porcentaje.Content = progresoPorcentaje.ToString() + " %";
            rellenoRectangulo.Width = progresoPorcentaje * maximo / 100;
        }
    }
}
