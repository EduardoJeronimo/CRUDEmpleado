using CRUDEmpleado.Context;
using CRUDEmpleado.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
