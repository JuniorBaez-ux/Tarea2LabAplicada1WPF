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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Tarea2LabAplicada1WPF.Entidades;
using Tarea2LabAplicada1WPF.BLL;
using Tarea2LabAplicada1WPF.DAL;
//using Tarea2LabAplicada1WPF.Migrations;


namespace Tarea2LabAplicada1WPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rROles.xaml
    /// </summary>
    public partial class rROles : Window
    {
        public rROles()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



        private void BuscarIdButton_Click(object sender, EventArgs e)
        {
            int id;
            Roles roles = new Roles();
            int.TryParse(RolIdTextBox.Text, out id);

            Limpiar();

            roles = RolesBLL.Buscar(id);

            if (roles != null)
            {
                MessageBox.Show("Rol Encotrado");
                LlenarCampos(roles);
            }
            else
            {
                MessageBox.Show("Rol no Encontrada");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Roles roles;
            bool paso = false;
            if (!Validar())
            {
                return;
            }
            roles = LlenarClase();
            paso = RolesBLL.Guardar(roles);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Rol guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Rol modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(RolIdTextBox.Text, out id);
            Limpiar();
            if (RolesBLL.Eliminar(id))
                MessageBox.Show("Rol eliminado Correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("ID no existente");
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Roles roles = RolesBLL.Buscar(Utilidades.ToInt(RolIdTextBox.Text));

            return (roles != null);
        }

        private void Limpiar()
        {
            RolIdTextBox.Clear();
            NombreTextBox.Clear();
        }

        private void LlenarCampos(Roles roles)
        {
            RolIdTextBox.Text = roles.RolId.ToString();
            NombreTextBox.Text = roles.Descripcion;
        }

        private Roles LlenarClase()
        {
            Roles roles = new Roles();
            roles.RolId = int.Parse(RolIdTextBox.Text);
            roles.Descripcion = NombreTextBox.Text;

            return roles;
        }

        private bool Validar()
        {
            bool paso = true;

            if (RolesBLL.ExisteDescripcion(NombreTextBox.Text))
            {
                MessageBox.Show("Mensaje repetido");
                NombreTextBox.Focus();
                paso = false;
            }

            return paso;
        }
    }
}
