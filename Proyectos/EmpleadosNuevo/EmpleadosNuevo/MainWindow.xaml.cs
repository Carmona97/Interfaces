using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;

namespace EmpleadosNuevo
{
    public partial class MainWindow : Window
    {
        private static List<Empleado> empleados = new List<Empleado>();

        public const double ALTURA_MIN = 1.10;
        public const double ALTURA_MAX = 2.20;

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;

            var nombreColumn = new DataGridTextColumn { Header = "Nombre", Binding = new Binding("nombre") };
            var apellidosColumn = new DataGridTextColumn { Header = "Apellidos", Binding = new Binding("apellidos") };
            var telefonoColumn = new DataGridTextColumn { Header = "Teléfono", Binding = new Binding("telefono") };
            var direccionColumn = new DataGridTextColumn { Header = "Dirección", Binding = new Binding("direccion") };
            var hijosColumn = new DataGridTextColumn { Header = "Hijos", Binding = new Binding("hijos") };
            var alturaColumn = new DataGridTextColumn { Header = "Altura", Binding = new Binding("altura") };
            var fechaNacimientoColumn = new DataGridTextColumn { Header = "Fecha de Nacimiento", Binding = new Binding("fechaNacimiento") };

            dataGrid.ItemsSource = empleados;
            dataGrid.IsReadOnly = true;
            slider.IsEnabled = false;
            valorSlider.Text = "0";

            preCargarEmpleado();
        }

        public static void preCargarEmpleado()
        {
            Empleado paco = new Empleado("Paco", "Canela Rama", "633452134", "Capancala 1", "0", 1.78, "14/08/1997");
            Empleado roberto = new Empleado("Roberto", "Garcia Perez", "633452133", "Capancala 2", "0", 1.68, "19/08/1965");
            Empleado antonio = new Empleado("Antonio", "Hurtado Jerez", "633452134", "Capancala 3", "0", 1.74, "14/03/1977");
            Empleado dani = new Empleado("Daniel", "Ruiz Gomez", "633452134", "Capancala 4", "0", 1.83, "11/2/1992");
            Empleado dani2 = new Empleado("Daniel", "Ruiz Perez", "633232134", "Capancala 6", "0", 1.93, "11/2/1982");
            Empleado recesvinto = new Empleado("Recesvinto", "Vazquez Anatoli", "633452134", "Capancala 5", "0", 1.46, "23/12/1985");
            empleados.Add(paco);
            empleados.Add(roberto);
            empleados.Add(antonio);
            empleados.Add(dani);
            empleados.Add(dani2);
            empleados.Add(recesvinto);
        }

        private void insertar_Click(object sender, RoutedEventArgs e)
        {
            Empleado nuevoEmpleado = new Empleado
            {
                nombre = textNombre.Text,
                apellidos = textApellidos.Text,
                telefono = textTelefono.Text,
                direccion = textDireccion.Text,
                hijos = valorSlider.Text,
                altura = Convert.ToDouble(alturaTxt.Text),
                fechaNacimiento = fechaNacimientoPicker.Text,
            };

            foreach (var item in listBoxHijos.Items)
            {
                nuevoEmpleado.nombreHijos.Add(item.ToString());
            }

            empleados.Add(nuevoEmpleado);
            dataGrid.Items.Refresh();

            textNombre.Clear();
            textApellidos.Clear();
            textTelefono.Clear();
            textDireccion.Clear();
            valorSlider.Text = "0";
            nombreHijoTxt.Clear();
            slider.Value = 0;
            listBoxHijos.Items.Clear();


        }

        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Empleado empleadoSeleccionado = (Empleado)dataGrid.SelectedItem;

                empleadoSeleccionado.nombre = textNombre.Text;
                empleadoSeleccionado.apellidos = textApellidos.Text;
                empleadoSeleccionado.telefono = textTelefono.Text;
                empleadoSeleccionado.direccion = textDireccion.Text;
                empleadoSeleccionado.fechaNacimiento = fechaNacimientoPicker.Text;

                dataGrid.Items.Refresh();
            }
        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Empleado empleadoSeleccionado = (Empleado)dataGrid.SelectedItem;
                empleados.Remove(empleadoSeleccionado);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = empleados;
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            textNombre.Clear();
            textApellidos.Clear();
            textTelefono.Clear();
            textDireccion.Clear();
            nombreHijoTxt.Clear();
            slider.Value = 0;
            listBoxHijos.Items.Clear();

            dataGrid.UnselectAll();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Empleado empleadoSeleccionado = (Empleado)dataGrid.SelectedItem;
                textNombre.Text = empleadoSeleccionado.nombre;
                textApellidos.Text = empleadoSeleccionado.apellidos;
                textTelefono.Text = empleadoSeleccionado.telefono;
                textDireccion.Text = empleadoSeleccionado.direccion;
                fechaNacimientoPicker.Text = empleadoSeleccionado.fechaNacimiento;

                listBoxHijos.Items.Clear();

                foreach (string nombreHijo in empleadoSeleccionado.nombreHijos)
                {
                    listBoxHijos.Items.Add(nombreHijo);
                }
               
                aceptar.IsEnabled = true;
                borrar.IsEnabled = true;
            }
            else
            {
                borrar.IsEnabled = false;
            }
        }

        private void hijos_Checked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = true;
        }

        private void hijos_UnChecked(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = false;
            valorSlider.Text = "0";
        }

        private void textNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            textNombre.Background = System.Windows.Media.Brushes.LightGreen;
        }

        private void textNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            textNombre.Background = System.Windows.Media.Brushes.White;
        }

        private void textApellidos_GotFocus(object sender, RoutedEventArgs e)
        {
            textApellidos.Background = System.Windows.Media.Brushes.LightGreen;
        }

        private void textApellidos_LostFocus(object sender, RoutedEventArgs e)
        {
            textApellidos.Background = System.Windows.Media.Brushes.White;
        }

        private void textTelefono_GotFocus(object sender, RoutedEventArgs e)
        {
            textTelefono.Background = System.Windows.Media.Brushes.LightGreen;
        }

        private void textTelefono_LostFocus(object sender, RoutedEventArgs e)
        {
            textTelefono.Background = System.Windows.Media.Brushes.White;
        }

        private void textDireccion_GotFocus(object sender, RoutedEventArgs e)
        {
            textDireccion.Background = System.Windows.Media.Brushes.LightGreen;
        }

        private void textDireccion_LostFocus(object sender, RoutedEventArgs e)
        {
            textDireccion.Background = System.Windows.Media.Brushes.White;
        }

        private void ButtonMas_Click(object sender, RoutedEventArgs e)
        {
            string alturaTexto = alturaTxt.Text;
            double nuevaAltura = Convert.ToDouble(alturaTexto);

            if (nuevaAltura >= ALTURA_MAX)
            {
                nuevaAltura = ALTURA_MAX;
            }
            else
            {
                nuevaAltura = Math.Min(ALTURA_MAX, nuevaAltura + 0.05);
                alturaTxt.Text = nuevaAltura.ToString("F2");
            }
        }

        private void ButtonMenos_Click(object sender, RoutedEventArgs e)
        {
            string alturaTexto = alturaTxt.Text;
            double nuevaAltura = Convert.ToDouble(alturaTexto);

            if (nuevaAltura <= ALTURA_MIN)
            {
                nuevaAltura = ALTURA_MIN;
            }
            else
            {
                nuevaAltura = Math.Max(ALTURA_MIN, nuevaAltura - 0.05);
                alturaTxt.Text = nuevaAltura.ToString("F2");
            }
        }

        private void nombreHijoTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void anadirHijoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hijoschk.IsChecked == true)
            {
                int maximoHijos = Convert.ToInt32(valorSlider.Text);
                if (listBoxHijos.Items.Count < maximoHijos)
                {
                    listBoxHijos.Items.Add(nombreHijoTxt.Text);
                    nombreHijoTxt.Clear();
                    
                }
                else
                {
                    MessageBox.Show("No se pueden añadir más hijos de los seleccionados", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("No se pueden añadir hijos sin la opción 'hijo'", "Error", MessageBoxButton.OK);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void textApellidos_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        private void textNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            valorSlider.Text = $"{slider.Value}";


        }
        private void blueMenuItem_Click(object sender, RoutedEventArgs e)
        {

            this.Background = System.Windows.Media.Brushes.Blue;
        }

        private void greenMenuItem_Click(object sender, RoutedEventArgs e)
        {

            this.Background = System.Windows.Media.Brushes.Green;
        }
        private void redMenuItem_Click(object sender, RoutedEventArgs e)
        {

            this.Background = System.Windows.Media.Brushes.Red;
        }

        private void buscar_Click(object sender, RoutedEventArgs e)
        {
            string criterio = busqueda.Text.ToLower();

            IEnumerable<Empleado> resultados = empleados.Where(empleado => empleado.nombre.ToLower().Contains(criterio)).ToList();

                dataGrid.ItemsSource = resultados;

        }

        private void recargar_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=empleados;
            busqueda.Text = null;
        }
    }

    public class Empleado
    {
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }
        public String hijos { get; set; }
        public double altura { get; set; }
        public String fechaNacimiento { get; set; }
        public List<string> nombreHijos { get; set; }

        public Empleado()
        {
            nombreHijos = new List<string>();
        }
        public Empleado(string nombre, string apellidos, string telefono, string direccion, String hijos, double altura, String fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.hijos = hijos;
            this.altura = altura;
            this.fechaNacimiento = fechaNacimiento;  
            this.nombreHijos = new List<string>();
        }
    }
}