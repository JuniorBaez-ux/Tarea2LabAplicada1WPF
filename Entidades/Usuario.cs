using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2LabAplicada1WPF.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public String Alias { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }
        public bool Activo { get; set; }
        public String Nivel { get; set; }
        public String Email { get; set; }
        public int CostoxHora { get; set; }
    }
}
