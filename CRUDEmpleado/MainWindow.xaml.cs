using CRUDEmpleado.Entities;
using CRUDEmpleado.Services;
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

namespace CRUDEmpleado
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

        private void BntAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado emple = new Empleado();
            EmpladosServices services = new EmpladosServices();

            emple.Nombre = txtNombre.Text;
            emple.Apellido = txtApellido.Text;
            emple.Correo = txtCorreo.Text;

            //agregar una condicion para no enviar datos nulos 

            services.Agregar(emple);


            txtNombre.Clear();
            txtApellido.Clear();    
            txtCorreo.Clear();
            MessageBox.Show("Los datos se guardaron");

        }
    }
}
