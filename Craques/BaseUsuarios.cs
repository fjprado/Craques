using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Craques
{
    public static class BaseUsuarios
    {


        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Nome="fernando", Senha = "123456"},
                new Usuario { Nome="ana", Senha= "654321"}
            };
        }
    }
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}