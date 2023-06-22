using CRUDEmpleado.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpleado.Context
{
    public class ApplicationDbContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AQUI VA LA CADENA DE CONEXION 
            optionsBuilder.UseMySQL("Server=localhost; database-23BM; user=root; password=");
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
