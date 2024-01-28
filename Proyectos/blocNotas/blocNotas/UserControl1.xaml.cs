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

namespace blocNotas
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            visualizar.Visibility = Visibility.Hidden;
            textoV.Visibility = Visibility.Hidden;
            marco.Visibility = Visibility.Hidden;
        }

        [Description("texto del cuadro de notas"), Category("Mi categoria"),DisplayName("Texto a añadir") ]
        public String textoIzquierda { get=> editarTexto.Text.ToString(); set=> editarTexto.Text = value; }

        [Description("Texto guardado"),Category("Mi categoria"),DisplayName("Texto guardado")]
        public String textoDerecha { get=>visualizar.Text.ToString(); set=>visualizar.Text = value; }

        [Description("Cambia el fondo del cuadro de notas"), Category("Mi categoria"), DisplayName("Color a cambiar")]
        public Brush cambiarFondo { get=> editarTexto.Background; set=> editarTexto.Background = value; }

        [Description("Cambia la visibilidad del bloc de notas"), Category("Mi categoria"), DisplayName("Visibilidad")]
        public Visibility verTextoGuardado { get => marco.Visibility; set { marco.Visibility = value; textoV.Visibility = value; visualizar.Visibility = value; } }
    }
}
