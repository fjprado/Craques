using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Craques.Models
{
    public class Craque
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Posicao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int NivelAtaque { get; set; }
        public int NivelDefesa { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Craque> ListarCraque()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaCraques = JsonConvert.DeserializeObject<List<Craque>>(json);
            return listaCraques;
        }


        public List<Craque> ListarCraquesDB()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDev"].ConnectionString;
            IDbConnection conexao;

            conexao = new SqlConnection(stringConexao);
            conexao.Open();
            var listaCraques = new List<Craque>();

            IDbCommand selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "select * from Craques";

            IDataReader resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                var craqueDb = new Craque();
                craqueDb.Id = Convert.ToInt32(resultado["Id"]);
                craqueDb.Username = Convert.ToString(resultado["Username"]);
                craqueDb.Posicao = Convert.ToString(resultado["Posicao"]);
                craqueDb.DataCadastro = Convert.ToDateTime(resultado["DataCadastro"]);
                craqueDb.NivelAtaque = Convert.ToInt32(resultado["NivelAtaque"]);
                craqueDb.NivelDefesa = Convert.ToInt32(resultado["NivelDefesa"]);
                craqueDb.Telefone = Convert.ToString(resultado["Telefone"]);
                craqueDb.Email = Convert.ToString(resultado["Email"]);

                listaCraques.Add(craqueDb);
            }
            conexao.Close();

            return listaCraques;
        }
        public bool RescreverArquivo(List<Craque> listaCraques)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = JsonConvert.SerializeObject(listaCraques, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }


        public Craque Inserir(Craque Craque)
        {
            var listaCraques = this.ListarCraque();

            var maxId = listaCraques.Max(item => item.Id);
            Craque.Id = maxId + 1;
            listaCraques.Add(Craque);

            RescreverArquivo(listaCraques);
            return Craque;
        }

        public Craque Atualizar(int id, Craque Craque)
        {
            var listaCraques = this.ListarCraque();

            var itemIndex = listaCraques.FindIndex(item => item.Id == id);
            if (itemIndex >= 0)
            {
                Craque.Id = id;
                listaCraques[itemIndex] = Craque;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaCraques);
            return Craque;
        }

        public bool Deletar(int id)
        {
            var listaCraques = this.ListarCraque();

            var itemIndex = listaCraques.FindIndex(item => item.Id == id);
            if (itemIndex >= 0)
            {
                listaCraques.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaCraques);
            return true;
        }
    }
}