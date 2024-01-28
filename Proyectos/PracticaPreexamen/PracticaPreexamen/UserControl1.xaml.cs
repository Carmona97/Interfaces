using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace PracticaPreexamen
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            debil.Visibility = Visibility.Hidden;
            medio.Visibility = Visibility.Hidden;
            fuerte.Visibility = Visibility.Hidden;
            
        }

        private void contrasena_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(contrasena.Password.Length == 0)
            {
                debil.Visibility = Visibility.Hidden;
                medio.Visibility = Visibility.Hidden;
                fuerte.Visibility = Visibility.Hidden;
                valorContrasena.Content = "No es una contraseña válida";
            }
            else if(contrasena.Password.Length <= 4)
            {
                debil.Visibility = Visibility.Visible;
                medio.Visibility = Visibility.Hidden;
                valorContrasena.Content = "El nivel de seguridad es: débil";
            }
            else if(contrasena.Password.Length >= 5 && contrasena.Password.Length <= 8)
            {
                medio.Visibility = Visibility.Visible;
                fuerte.Visibility = Visibility.Hidden;
                valorContrasena.Content = "El nivel de seguridad es: medio";
            }
            else
            {
                fuerte.Visibility = Visibility.Visible;
                valorContrasena.Content = "El nivel de seguridad es: fuerte";
            }

            if(contrasena.Password.Length == contrasena.MaxLength)
            {
                MessageBox.Show("Se ha alcanzado el máximo de caracteres", "Alto ahí Domingo");
            }
        }
    }
}
