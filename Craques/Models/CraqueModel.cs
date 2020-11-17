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
    public class CraqueModel
    {


        //Banco de dados com arquivo Base.json - Listar dados
        //public List<Craque> ListarCraque()
        //{
        //    var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
        //    var json = File.ReadAllText(caminhoArquivo);
        //    var listaCraques = JsonConvert.DeserializeObject<List<Craque>>(json);
        //    return listaCraques;
        //}

        public List<CraqueDTO> ListarCraque(int? id = null)
        {
            try
            {
                var craqueBD = new CraqueDAO();
                return craqueBD.ListarCraquesDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar craques: {ex.Message}");
            }
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

        public void Inserir(CraqueDTO craque)
        {
            craque.DataCadastro = DateTime.Now;
            try
            {
                var craqueBD = new CraqueDAO();
                craqueBD.InserirCraqueDB(craque);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao INSERIR craque: {ex.Message}");
            }
        }

        //Banco de dados com arquivo Base.json - Atualizar dados

        //public Craque Atualizar(int id, Craque Craque)
        //{
        //    var listaCraques = this.ListarCraque();

        //    var itemIndex = listaCraques.FindIndex(item => item.Id == id);
        //    if (itemIndex >= 0)
        //    {
        //        Craque.Id = id;
        //        listaCraques[itemIndex] = Craque;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    RescreverArquivo(listaCraques);
        //    return Craque;
        //}

        //public bool RescreverArquivo(List<CraqueDTO> listaCraques)
        //{
        //    var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
        //    var json = JsonConvert.SerializeObject(listaCraques, Formatting.Indented);
        //    File.WriteAllText(caminhoArquivo, json);

        //    return true;
        //}

        public void Atualizar(CraqueDTO craque)
        {
            try
            {
                var craqueBD = new CraqueDAO();
                craqueBD.AtualizarCraqueDB(craque);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ATUALIZAR craque: {ex.Message}");
            }
        }

        //Banco de dados com arquivo Base.json - Deletar dados
        //public bool Deletar(int id)
        //{
        //    var listaCraques = this.ListarCraque();

        //    var itemIndex = listaCraques.FindIndex(item => item.Id == id);
        //    if (itemIndex >= 0)
        //    {
        //        listaCraques.RemoveAt(itemIndex);
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    RescreverArquivo(listaCraques);
        //    return true;
        //}

        public void Deletar(int id)
        {
            try
            {
                var craqueDB = new CraqueDAO();
                craqueDB.DeletarCraqueDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao DELETAR craque: {ex.Message}");
            }
        }
    }
}