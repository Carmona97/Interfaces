using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CarmonaJuanManuelExamen2Interfaces
{
    public partial class MainWindow : Window
    {
        double tasas = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            double cantidad;
            if (!double.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            cantidad = double.Parse(txtCantidad.Text);
            List<string> divisasConvertidas = new List<string>();
            double rusia = 0;
            double lituania = 0;
            double euro = 0;
            double checa = 0;
            double danesa = 0;
            double noruega = 0;
            double suiza = 0;
            double lira = 0;

            calcularTasas();

            if (chRusia.IsChecked == true)
            {
                rusia = cantidad * 0.9796*(tasas/100);
                divisasConvertidas.Add("Rusia:" + rusia.ToString("N2"));

            }
            if (chLituania.IsChecked == true)
            {
                lituania = cantidad * 3.2 * (tasas / 100);
                divisasConvertidas.Add("Lituania:" + lituania.ToString("N2"));
            }
            if (chEuro.IsChecked == true)
            {
                euro = cantidad * (tasas / 100);
                divisasConvertidas.Add("Euro:" + euro.ToString("N2"));
            }
            if (chCheca.IsChecked == true)
            {
                checa = cantidad * 2.441 * (tasas / 100);
                divisasConvertidas.Add("Corona checa:" + checa.ToString("N2"));
            }
            if (chDanesa.IsChecked == true)
            {
                danesa = cantidad * 7.46 * (tasas / 100);
                divisasConvertidas.Add("Corona danesa" + danesa.ToString("N2"));
            }
            if (chNoruega.IsChecked == true)
            {
                noruega = cantidad * 1.18 * (tasas / 100);
                divisasConvertidas.Add("Corona noruega" + noruega.ToString("N2"));
            }
            if (chSuiza.IsChecked == true)
            {
                suiza = cantidad * 9.7 * (tasas / 100);
                divisasConvertidas.Add("Corona suiza" + suiza.ToString("N2"));
            }
            if (chLira.IsChecked == true)
            {
                lira = cantidad * 3.31 * (tasas / 100);
                divisasConvertidas.Add("Lira" + lira.ToString("N2"));
            }

            listaDivisas.Text = string.Join("\n", divisasConvertidas);
            

        }

        public void calcularTasas()
        {
            if(radioEfectivo.IsChecked == true)
            {
                tasas = 1;
            }else if(radioTransferencia.IsChecked == true)
            {
                tasas = 2;
            }else if(radioTarjeta.IsChecked == true)
            {
                tasas = 3;
            }

            if(chkDescuento.IsChecked == true)
            {
                tasas = tasas - 0.25;
            }
        }




        private void listaDivisas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listaDivisas.Text = null;           
        }
    }
}
