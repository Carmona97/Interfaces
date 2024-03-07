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

namespace relojAnalogico.Componente
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        [Description("Aqui puedes introducir la hora"), Category("Reloj"), DisplayName("Introduce la hora"), DefaultValue(0)]
        public int hora { get => (int) anguloHoras.Angle / 30; set => ActualizarHora(value); }
        [Description("Aquí puedes introducir el minuto"), Category("Reloj"), DisplayName("Introduce el minuto"), DefaultValue(0)]

        public int minuto { get => (int)anguloMinutos.Angle / 6; set => ActualizarMinutos(value); }
        [Description("Aquí puedes introducir el segundo"), Category("Reloj"), DisplayName("Introduce el segundo"), DefaultValue(0)]

        public int segundo { get => (int)anguloSegundos.Angle / 6; set => ActualizarSegundos(value); }

        public UserControl1()
        {
            InitializeComponent();
        }
        private void ActualizarHora(int valor)
        {
            if(valor > 0 && valor <= 12)
            {
                anguloHoras.Angle = valor * 30;
            }
            
        }        
        private void ActualizarMinutos(int valor)
        {
            if(valor > 0 && valor <= 60)
            {
                anguloMinutos.Angle = valor * 6;
            }
            
        }        
        private void ActualizarSegundos(int valor)
        {
            if(valor > 0 && valor <= 60)
            {
                anguloSegundos.Angle = valor * 6;
            }
            
        }
    }

    

}
