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

        //Banco de dados com arquivo Base.json - Listar dados
        //public List<Craque> ListarCraque()
        //{
        //    var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
        //    var json = File.ReadAllText(caminhoArquivo);
        //    var listaCraques = JsonConvert.DeserializeObject<List<Craque>>(json);
        //    return listaCraques;
        //}

        public List<Craque> ListarCraque()
        {
            try
            {
                var craqueBD = new CraqueDAO();
                return craqueBD.ListarCraquesDB();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar craques: {ex.Message}");
            }
        }
                
        public bool RescreverArquivo(List<Craque> listaCraques)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = JsonConvert.SerializeObject(listaCraques, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        //Banco de dados com arquivo Base.json - Inserir dados
        //public Craque Inserir(Craque Craque)
        //{
        //    var listaCraques = this.ListarCraque();

        //    var maxId = listaCraques.Max(item => item.Id);
        //    Craque.Id = maxId + 1;
        //    listaCraques.Add(Craque);

        //    RescreverArquivo(listaCraques);
        //    return Craque;
        //}

        public void Inserir(Craque craque)
        {
            craque.DataCadastro = DateTime.Now;
            try
            {
                var craqueBD = new CraqueDAO();
                craqueBD.InserirCraqueDB(craque);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir craques: {ex.Message}");
            }
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