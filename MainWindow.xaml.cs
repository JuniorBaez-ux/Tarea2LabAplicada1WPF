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
using Tarea2LabAplicada1WPF.Entidades;
using Tarea2LabAplicada1WPF.BLL;
using Tarea2LabAplicada1WPF.DAL;
//using Tarea2LabAplicada1WPF.Migrations;

namespace Tarea2LabAplicada1WPF
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
        private Usuario usuario = new Usuario();
        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuarioBLL.Buscar(Utilidades.ToInt(IDTextbox.Text));

            if (usuario!= null)
            {
                this.usuario= usuario;
            }
            else
            {
                this.usuario = new Usuario();
            }

            this.DataContext = this.usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuarioBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Operacion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Operacion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(IDTextbox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }


        private void Limpiar()
        {
            AliasTextbox.Clear();
            NombreTextbox.Clear();
            EmailTextBox.Clear();
            ClaveTextbox.Clear();
            ConfirmarClaveTextBox.Clear();
            ActivoChecBox.IsChecked = false;
            NivelComboBox.Text = "";
        }
    }
}
