using CRUDEmpleado.Context;
using CRUDEmpleado.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace CRUDEmpleado.Services
{
    public class EmpladosServices
    {

        public void Agregar(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado res = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        FechaRegistro = DateTime.Now,
                        Correo = request.Correo,
                    };

                    _context.Empleados.Add(res);
                    _context.SaveChanges();                   
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Succedio un error: " + ex.Message);
            }
        }

        public Empleado Mostrar(int id)
        {
            try
            { 
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(id);
                    return empleado;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(id);
                    _context.Empleados.Remove(empleado);
                    _context.SaveChanges();
             
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error "+ex.Message);
            }

        }

        public void Editar(Empleado empleado)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleadoExistente = _context.Empleados.Find(empleado.pkEmpleado);

                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Nombre = empleado.Nombre;
                        empleadoExistente.Apellido = empleado.Apellido;
                        empleadoExistente.Correo = empleado.Correo;

                        _context.SaveChanges();
                        MessageBox.Show("Empleado editado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el empleado");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        internal void Editar(Empleado emple, object id)
        {
            throw new NotImplementedException();
        }
    }
}
