using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craques.Models
{
    public class CraqueDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Posicao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int NivelAtaque { get; set; }
        public int NivelDefesa { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}