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
using Tarea2LabAplicada1WPF.UI.Registros;

namespace Tarea2LabAplicada1WPF
{
    /// <summary>
    /// Interaction logic for VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            rROles rOles = new rROles();
            rOles.Show();
        }
    }
}
