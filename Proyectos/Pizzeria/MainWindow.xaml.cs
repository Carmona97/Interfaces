using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            borrarRadio(masas);
            borrarCheckBox(ingredientes);
            borrarRadio(bebidas);
            borrarTextBox(pedido);
        }

        private void borrarRadio(StackPanel stackPanel)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(RadioButton))
                {
                    RadioButton radioButton = (RadioButton)stackPanel.Children[i];
                    radioButton.IsChecked = false;
                }
            }
        }

        private void borrarCheckBox(StackPanel stackPanel)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(CheckBox))
                {
                    CheckBox checkbox = (CheckBox)stackPanel.Children[i];
                    checkbox.IsChecked = false;
                }
            }
        }

        private void borrarTextBox(TextBox textBox)
        {
            pedido.Text = string.Empty;
        }
                private void realizarPedido_Click(object sender, RoutedEventArgs e)
        {
            
            pedido.Text = "Masa: "+ GetSelectedOptionsText(masas)+"\n";
            pedido.Text += "Ingredientes: \n" + GetSelectedOptionsText(ingredientes)+"\n";
            pedido.Text += "Bebida: "+GetSelectedOptionsText(bebidas);
        }

       

        private string GetSelectedOptionsText(StackPanel stackPanel)
        {
            StringBuilder selectedOptions = new StringBuilder();
            foreach (UIElement element in stackPanel.Children)
            {
                if (element is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    selectedOptions.AppendLine(radioButton.Content.ToString());
                }
                else if (element is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    selectedOptions.AppendLine(checkBox.Content.ToString());
                }
            }
            return selectedOptions.ToString();
        }

        private void mostrarImagenBebida(Image imagen)
        {
            try
            {
                string bebidaSeleccionada = GetSelectedOptionsText(bebidas).Trim();
                string rutaImagen = "";

                if (bebidaSeleccionada == "Coca - cola")
                {
                    rutaImagen = "CocaCola.jpg";
                }
                else if (bebidaSeleccionada == "Nestea")
                {
                    rutaImagen = "Nestea.jpg";
                }
                else if (bebidaSeleccionada == "Fanta")
                {
                    rutaImagen = "Fanta.jpg";
                }
                

                if (!string.IsNullOrEmpty(rutaImagen))
                {
                    BitmapImage imagenBebida = new BitmapImage(new Uri(rutaImagen, UriKind.Relative));
                    imagen.Source = imagenBebida;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores si la imagen no se puede cargar
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void masaQueso_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cocaCola_checked(object sender, RoutedEventArgs e)
        {
            mostrarImagenBebida(mostrarImg);
        }

        private void nestea_Checked(object sender, RoutedEventArgs e)
        {
            mostrarImagenBebida(mostrarImg);
        }

        private void fanta_Checked(object sender, RoutedEventArgs e)
        {
            mostrarImagenBebida(mostrarImg);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void oregano_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void pollo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void nata_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
