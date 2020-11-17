using Craques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Craques.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Craque")]
    public class CraqueController : ApiController
    {
        // GET: api/Craque
        [HttpGet]
        [Route("Recuperar")]
        public IHttpActionResult Recuperar()
        {
            try
            {
                CraqueModel craque = new CraqueModel();
                return Ok(craque.ListarCraque());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/Craque/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public IHttpActionResult RecuperarPorId(int id)
        {
            try
            {
                CraqueModel craque = new CraqueModel();
                return Ok(craque.ListarCraque(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        //[HttpGet]
        //[Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2}/{username:minlength(3)}")]
        //public IHttpActionResult Recuperar(string data, string username)
        //{
        //    try
        //    {
        //        Craque craque = new Craque();
        //        IEnumerable<CraqueDTO> craques = craque.ListarCraque().Where(item => item.Data == data || item.Username == username);
        //        if (!craques.Any())
        //        {
        //            return NotFound();
        //        }

        //        return Ok(craques);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }

        //}

        // POST: api/Craque
        [HttpPost]
        public IHttpActionResult Post(CraqueDTO craque)
        {
            try
            {
                CraqueModel _craque = new CraqueModel();
                _craque.Inserir(craque);
                return Ok(_craque.ListarCraque());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        // PUT: api/Craque/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] CraqueDTO craque)
        {
            try
            {
                CraqueModel _craque = new CraqueModel();
                craque.Id = id;
                _craque.Atualizar(craque);
                return Ok(_craque.ListarCraque().FirstOrDefault(craq => craq.Id == id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

        // DELETE: api/Craque/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CraqueModel _craque = new CraqueModel();

                _craque.Deletar(id);
                return Ok($"Craque ID {id} removido com sucesso");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
