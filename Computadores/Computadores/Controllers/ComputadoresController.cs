using Computadores.Clases;
using Computadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Computadores.Controllers
{
    [RoutePrefix("api/Computadores")]
    public class ComputadoresController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]

        public List<Computador> ConsultarTodos()
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                return clsComputador.ConsultarTodos();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarXCodigo")]
        public Computador ConsultarXCodigo(int codigo)
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                return clsComputador.Consultar(codigo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<Computador> ConsultarXTipo(int codigoTipo)
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                return clsComputador.ConsultarPorTipo(codigoTipo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Computador computador)
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                clsComputador.computador = computador;
                return clsComputador.Insertar();
            }
            catch (Exception ex)
            {
                return "Error al insertar computador: " + ex.Message;
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Computador computador)
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                clsComputador.computador = computador;
                return clsComputador.Actualizar();
            }
            catch (Exception ex)
            {
                return "Error al actualizar computador: " + ex.Message;
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Computador computador)
        {
            try
            {
                clsComputador clsComputador = new clsComputador();
                clsComputador.computador = computador;
                return clsComputador.Eliminar();
            }
            catch (Exception ex)
            {
                return "Error al eliminar computador: " + ex.Message;
            }
        }

        [HttpGet]
        [Route("ConsultarImagenes")]
        public IQueryable ConsultarImagenes(int codigoComp)
        {
            clsComputador clsComputador = new clsComputador();
            return clsComputador.ListarImagenesxComputador(codigoComp);
        }
    }
}