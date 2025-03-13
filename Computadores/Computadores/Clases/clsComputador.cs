using Computadores.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Computadores.Clases
{
    public class clsComputador
    {
        private DBComputadoresEntities dbComputadores = new DBComputadoresEntities();

        public Computador computador { get; set; }

        public string Insertar()
        {
            string respuesta = "";
            try
            {
                dbComputadores.Computadors.Add(computador);
                dbComputadores.SaveChanges();
                respuesta = "Computador insertado correctamente";
            }
            catch (Exception ex)
            {
                respuesta = "Error al registrar computador: " + ex.Message;
            }
            return respuesta;
        }

        public Computador Consultar(int codigo)
        {
            try
            {
                Computador comp = dbComputadores.Computadors.FirstOrDefault(c => c.Codigo == codigo);
                return comp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Computador> ConsultarTodos()
        {
            try
            {
                List<Computador> computadores = dbComputadores.Computadors
                                                .OrderBy(c => c.Codigo)
                                                .ToList();
                return computadores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Computador> ConsultarPorTipo(int codigoTipo)
        {
            try
            {
                List<Computador> computadores = dbComputadores.Computadors
                                                .Where(c => c.CodigoTipo == codigoTipo)
                                                .OrderBy(c => c.Codigo)
                                                .ToList();
                return computadores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Actualizar()
        {
            string respuesta = "";
            try
            {
                Computador comp = Consultar(computador.Codigo);
                if (comp == null)
                {
                    respuesta = "El computador no existe";
                }
                else
                {
                    dbComputadores.Computadors.AddOrUpdate(computador);
                    dbComputadores.SaveChanges();
                    respuesta = "Computador actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error al actualizar computador: " + ex.Message;
            }
            return respuesta;
        }

        public string Eliminar()
        {
            string respuesta = "";
            try
            {
                Computador comp = Consultar(computador.Codigo);
                if (comp == null)
                {
                    respuesta = "El computador no existe";
                }
                else
                {
                    dbComputadores.Computadors.Remove(comp);
                    dbComputadores.SaveChanges();
                    respuesta = "Computador eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error al eliminar computador: " + ex.Message;
            }
            return respuesta;
        }
    }
}