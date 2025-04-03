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
        private DBComputadoresEntities2 dbComputadores = new DBComputadoresEntities2();

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

        public string GrabarImagenComputadora(int codigoComputador, List<string> Imagenes)
        {
            string respuesta = "";
            try
            {
                foreach (string nombreImagen in Imagenes)
                {
                    ImagenesComp img = new ImagenesComp();
                    img.CodigoComputador = codigoComputador;
                    img.NombreImagen = nombreImagen;
                    dbComputadores.ImagenesComps.Add(img);
                    dbComputadores.SaveChanges();
                }
                return "Imagenes grabadas correctamente en la base de datos";

            }
            catch (Exception ex)
            {
                respuesta = "Error al grabar imagen: " + ex.Message;
            }
            return respuesta;
        }
        public IQueryable ListarImagenesxComputador(int codigoComputador)
        {
            return from C in dbComputadores.Set<Computador>()
                   join TC in dbComputadores.Set<TipoComputador>()
                   on C.CodigoTipo equals TC.Codigo
                   join IC in dbComputadores.Set<ImagenesComp>()
                   on C.Codigo equals IC.CodigoComputador
                   where C.Codigo == codigoComputador
                   orderby IC.NombreImagen
                   select new
                   {
                       codigoTipoProducto = TC.Codigo,
                       tipoProducto = TC.Descripcion,
                       codigoComputador = C.Codigo,
                       imagen = IC.NombreImagen
                   };
        }
        public string EliminarImagenComputador(string nombreImagen)
        {
            string respuesta = "";
            try
            {
                ImagenesComp img = dbComputadores.ImagenesComps.FirstOrDefault(i => i.NombreImagen == nombreImagen);
                if (img == null)
                {
                    respuesta = "La imagen no existe";
                }
                else
                {
                    dbComputadores.ImagenesComps.Remove(img);
                    dbComputadores.SaveChanges();
                    respuesta = "Imagen eliminada correctamente de la base de datos";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error al eliminar imagen: " + ex.Message;
            }
            return respuesta;
        }
    }
}