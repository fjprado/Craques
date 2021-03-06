﻿using System;
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
                new Usuario { Username="torres", Senha = "111111", Funcoes = new string[] {Funcao.Craque} },
                new Usuario { Username="fernando", Senha = "123456", Funcoes = new string[] {Funcao.Manager, Funcao.Administrador} },
                new Usuario { Username="ana", Senha= "654321", Funcoes = new string[] {Funcao.Manager} }
            };
        }
    }
    public class Usuario
    {
        public string Username { get; set; }
        public string Senha { get; set; }
        public string[] Funcoes { get; set; }
    }

    public class Funcao
    {
        public const string Craque = "Craque";
        public const string Manager = "Manager";
        public const string Administrador = "Administrador";
    }
}