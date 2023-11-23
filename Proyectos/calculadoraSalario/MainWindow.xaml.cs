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

namespace calculadoraSalario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            familiaCombo.ItemsSource = new string[] { "Casado", "Divorciado", "Viudo", "Soltero" };
        }

        private void calcularBtn_Click(object sender, RoutedEventArgs e)
        {

            
            int conversor = 0;

            if (Double.TryParse(brutoTxt.Text, out double salarioBruto) && Int32.TryParse(edadTxt.Text, out int edad))
            {
                salarioBruto = Convert.ToDouble(brutoTxt.Text);
                edad = Convert.ToInt32(edadTxt.Text);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para el salario bruto y la edad.","Error");
                return;
            }


            if (edad == null || edad <0)
            {
                MessageBox.Show("La edad no puede ser un campo vacio o negativo");
            }

            String situacionFamiliar = familiaCombo.SelectedItem?.ToString();
            if (situacionFamiliar == null)
            {
                MessageBox.Show("Por favor, seleccione una situación familiar.","Error");
                return;
            }


            situacionFamiliar = familiaCombo.SelectedItem.ToString();
            double salarioNeto = 0;

            if(salarioBruto < 15000)
            {
                conversor = 8;
            }else if(salarioBruto >=15000 && salarioBruto <= 30000)
            {
                conversor = 15;
            }else if (salarioBruto > 30000)
            {
                conversor = 20;
            }


            if(edad >=20 && edad < 50)
            {
                conversor = conversor + 1;
            }else if(edad >= 50)
            {
                conversor = conversor - 2;
            }


            if (situacionFamiliar.Equals("Divorciado"))
            {
                conversor = conversor - 1;

            }
            else if (situacionFamiliar.Equals("Soltero"))
            {
                conversor = conversor + 2;
            }
            else if(situacionFamiliar.Equals("Viudo"))
            {

                conversor = conversor - 2;

            }
            if(disponibleChk.IsChecked == true)
            {
                conversor = conversor - 1;
            }

            if(discapacidadBtn.IsChecked == true)
            {
                conversor = conversor - 5;
            }


            salarioNeto = salarioBruto - salarioBruto * (conversor / 100.0);
            SalarioNetoTxt.Text = "Salario neto:  "+ salarioNeto.ToString();

        }

        private void discapacidadBtn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void familiaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }

}
