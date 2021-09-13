using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2LabAplicada1WPF.Entidades;
using Tarea2LabAplicada1WPF.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Tarea2LabAplicada1WPF.BLL
{
    public class RolesBLL
    {
        public static bool Guardar(Roles roles)
        {
            if (!Existe(roles.RolId)) //Si no existe insertamos
            {
                return Insertar(roles);
            }
            else
            {
                return Modificar(roles);
            }
        }

        private static bool Insertar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Roles.Add(roles);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Marcar la entidad como modificada para que
                //El contexto sepa como proceder
                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Buscar la entidad que se desea eliminar
                var roles= contexto.Roles.Find(id);

                if (roles!= null)
                {
                    contexto.Roles.Remove(roles); //Remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles roles;

            try
            {
                roles = contexto.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return roles;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido como parametro
                lista = contexto.Roles.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool ExisteDescripcion(string descrip)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == descrip);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }



            return encontrado;
        }
    }
}
