using Craques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Craques.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CraqueController : ApiController
    {
        // GET: api/Craque
        public IEnumerable<Craque> Get()
        {
            Craque craque = new Craque();
            return craque.ListarCraque();
        }

        // GET: api/Craque/5
        public Craque Get(int id)
        {
            Craque craque = new Craque();
            return craque.ListarCraque().Where(item => item.Id == id).FirstOrDefault();
        }

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
