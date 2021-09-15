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
    public class UsuarioBLL
    {
        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioID)) //Si no existe insertamos
            {
                return Insertar(usuario);
            }
            else
            {
                return Modificar(usuario);
            }
        }

        private static bool Insertar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Usuario.Add(usuario);
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

        private static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Marcar la entidad como modificada para que
                //El contexto sepa como proceder
                contexto.Entry(usuario).State = EntityState.Modified;
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
                var usuario = contexto.Usuario.Find(id);

                if (usuario != null)
                {
                    contexto.Usuario.Remove(usuario); //Remover la entidad
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

        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;

            try
            {
                usuario = contexto.Usuario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {
            List<Usuario> lista = new List<Usuario>();
            Contexto contexto = new Contexto();

            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido como parametro
                lista = contexto.Usuario.Where(criterio).ToList();
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
                encontrado = contexto.Usuario.Any(e => e.UsuarioID == id);
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

        public static bool ExisteAlias(string buscaralias)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Usuario.Any(e => e.Alias == buscaralias);
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
