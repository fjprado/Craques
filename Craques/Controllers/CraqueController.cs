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
                Craque craque = new Craque();
                return Ok(craque.ListarCraquesDB());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/Craque/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public Craque Get(int id)
        {
            Craque craque = new Craque();
            return craque.ListarCraque().Where(item => item.Id == id).FirstOrDefault();
        }

        //[HttpGet]
        //[Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2}/{username:minlength(3)}")]
        //public IHttpActionResult Recuperar(string data, string username)
        //{
        //    try
        //    {
        //        Craque craque = new Craque();
        //        IEnumerable<Craque> craques = craque.ListarCraque().Where(item => item.Data == data || item.Username == username);
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
        public List<Craque> Post(Craque craque)
        {
            Craque _craque = new Craque();
            _craque.Inserir(craque);
            return _craque.ListarCraque();
        }

        // PUT: api/Craque/5
        public Craque Put(int id, [FromBody] Craque craque)
        {
            Craque _craque = new Craque();

            return _craque.Atualizar(id, craque);
        }

        // DELETE: api/Craque/5
        public string Delete(int id)
        {
            Craque _craque = new Craque();

            _craque.Deletar(id);
            return $"Craque ID {id} removido com sucesso";
        }
    }
}
