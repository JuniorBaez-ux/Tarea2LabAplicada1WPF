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
            int id;
            Usuario usuario = new Usuario();
            int.TryParse(IDTextbox.Text, out id);

            Limpiar();

            usuario = UsuarioBLL.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Persona Encotrada");
                LlenarCampos(usuario);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }
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
                MessageBox.Show("Usuario guardado Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Usuario modificado correctamente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IDTextbox.Text, out id);
            Limpiar();
            if (UsuarioBLL.Eliminar(id))
            {
                MessageBox.Show("Usuario eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existente");
            }
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

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuario usuarios = UsuarioBLL.Buscar(Utilidades.ToInt(IDTextbox.Text));

            return (usuarios != null);
        }

        private void LlenarCampos(Usuario usuarios)
        {
            IDTextbox.Text = usuarios.UsuarioID.ToString();
            NombreTextbox.Text = usuarios.Nombre;
            EmailTextBox.Text = usuarios.Email;
            AliasTextbox.Text = usuarios.Alias;
            ClaveTextbox.Text = usuarios.Clave;
        }

        private Usuario LlenarClase()
        {
            Usuario usuarios = new Usuario();
            usuarios.UsuarioID = Utilidades.ToInt(IDTextbox.Text);
            usuarios.Clave = ClaveTextbox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Nombre = NombreTextbox.Text;
            usuarios.Alias = AliasTextbox.Text;

            return usuarios;
        }

        private bool Validar()
        {
            bool paso = true;

            if (NombreTextbox.Text == string.Empty)
            {
                MessageBox.Show("El campo nombre no puede estar vacio");
                NombreTextbox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NivelComboBox.Text))
            {
                MessageBox.Show("Debe agregar un rol especifico");
                NivelComboBox.Focus();
                paso = false;
            }

            if (AliasTextbox.Text == string.Empty)
            {
                MessageBox.Show("El campo de alias no puede estar vacio");
                AliasTextbox.Focus();
                paso = false;
            }

            if (ClaveTextbox.Text == string.Empty)
            {
                MessageBox.Show("El campo de clave no puede estar vacio");
                ClaveTextbox.Focus();
                paso = false;
            }

            if (ConfirmarClaveTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de confirmar clave no puede estar vacio");
                ConfirmarClaveTextBox.Focus();
                paso = false;
            }

            if (EmailTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (UsuarioBLL.ExisteAlias(AliasTextbox.Text))
            {
                MessageBox.Show("Este Alias ya existe");
                AliasTextbox.Focus();
                paso = false;
            }
            if (string.Equals(ClaveTextbox.Text, ConfirmarClaveTextBox.Text) != true)
            {
                MessageBox.Show("La clave es distinta");
                ConfirmarClaveTextBox.Focus();
                paso = false;
            }

            return paso;
        }

    }
}
