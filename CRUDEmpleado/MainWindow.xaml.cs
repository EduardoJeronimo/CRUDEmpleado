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
        Empleado emple = new Empleado();
        EmpladosServices services = new EmpladosServices();

        //crear crear un boton resetear todos los campos 

        private void BntAdd_Click(object sender, RoutedEventArgs e)
        {
           

            emple.Nombre = txtNombre.Text;
            emple.Apellido = txtApellido.Text;
            emple.Correo = txtCorreo.Text;

            
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
         
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
            }
            else
            {
               
                emple.Nombre = txtNombre.Text;
                emple.Apellido = txtApellido.Text;
                emple.Correo = txtCorreo.Text;
                services.Agregar(emple);


                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("Los datos se guardaron");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //btnleer

            int id = int.Parse(txtId.Text);

            Empleado emple = services.Mostrar(id);

            txtNombre.Text = emple.Nombre;
            txtApellido.Text = emple.Apellido;
            txtCorreo.Text = emple.Correo;
            txtFecha.Text = emple.FechaRegistro.ToString();
        }

        private void BntClear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtFecha.Clear();
            txtId.Clear();

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

            int id = int.Parse(txtId.Text);

            services.Eliminar(id);

            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtFecha.Clear();
            txtId.Clear();
            MessageBox.Show("Usuario eliminado");

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                Empleado empl = services.Mostrar(id);

                if (empl != null)
                {
                    if (!string.IsNullOrEmpty(txtNombre.Text))
                        empl.Nombre = txtNombre.Text;

                    if (!string.IsNullOrEmpty(txtApellido.Text))
                        empl.Apellido = txtApellido.Text;

                    if (!string.IsNullOrEmpty(txtCorreo.Text))
                        empl.Correo = txtCorreo.Text;

                    services.Editar(empl);

                    MessageBox.Show("Empleado editado correctamente");
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtId.Clear();
                    txtFecha.Clear();
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el empleado: " + ex.Message);
            }
        }
    }
}
