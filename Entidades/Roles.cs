using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2LabAplicada1WPF.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String Descripcion { get; set; }
    }
}
