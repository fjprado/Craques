using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Craques.Models
{
    public class CraqueDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["conexaoDev"].ConnectionString;
        private IDbConnection conexao;
        public CraqueDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<CraqueDTO> ListarCraquesDB(int? id)
        {
            var listaCraques = new List<CraqueDTO>();
            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                if (id == null)
                    selectCmd.CommandText = "select * from Craques";
                else
                    selectCmd.CommandText = $"select * from Craques where id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var craqueDb = new CraqueDTO
                    {
                        Id = Convert.ToInt32(resultado["Id"]),
                        Username = Convert.ToString(resultado["Username"]),
                        Posicao = Convert.ToString(resultado["Posicao"]),
                        DataCadastro = Convert.ToDateTime(resultado["DataCadastro"]),
                        NivelAtaque = Convert.ToInt32(resultado["NivelAtaque"]),
                        NivelDefesa = Convert.ToInt32(resultado["NivelDefesa"]),
                        Telefone = Convert.ToString(resultado["Telefone"]),
                        Email = Convert.ToString(resultado["Email"])
                    };

                    listaCraques.Add(craqueDb);
                }

                return listaCraques;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void InserirCraqueDB(CraqueDTO craque)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Craques (Username, Posicao, DataCadastro, NivelAtaque, NivelDefesa, Telefone, Email) values (@Username, @Posicao, @DataCadastro, @NivelAtaque, @NivelDefesa, @Telefone, @Email)";

                IDbDataParameter paramUsername = new SqlParameter("Username", craque.Username);
                IDbDataParameter paramPosicao = new SqlParameter("Posicao", craque.Posicao);
                IDbDataParameter paramDataCadastro = new SqlParameter("DataCadastro", craque.DataCadastro);
                IDbDataParameter paramNivelAtaque = new SqlParameter("NivelAtaque", craque.NivelAtaque);
                IDbDataParameter paramNivelDefesa = new SqlParameter("NivelDefesa", craque.NivelDefesa);
                IDbDataParameter paramTelefone = new SqlParameter("Telefone", craque.Telefone);
                IDbDataParameter paramEmail = new SqlParameter("Email", craque.Email);
                insertCmd.Parameters.Add(paramUsername);
                insertCmd.Parameters.Add(paramPosicao);
                insertCmd.Parameters.Add(paramDataCadastro);
                insertCmd.Parameters.Add(paramNivelAtaque);
                insertCmd.Parameters.Add(paramNivelDefesa);
                insertCmd.Parameters.Add(paramTelefone);
                insertCmd.Parameters.Add(paramEmail);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AtualizarCraqueDB(CraqueDTO craque)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "update Craques set Username = @Username, Posicao = @Posicao, NivelAtaque = @NivelAtaque, NivelDefesa = @NivelDefesa, Telefone = @Telefone, Email = @Email where Id = @Id";

                IDbDataParameter paramUsername = new SqlParameter("Username", craque.Username);
                IDbDataParameter paramPosicao = new SqlParameter("Posicao", craque.Posicao);
                IDbDataParameter paramDataCadastro = new SqlParameter("DataCadastro", craque.DataCadastro);
                IDbDataParameter paramNivelAtaque = new SqlParameter("NivelAtaque", craque.NivelAtaque);
                IDbDataParameter paramNivelDefesa = new SqlParameter("NivelDefesa", craque.NivelDefesa);
                IDbDataParameter paramTelefone = new SqlParameter("Telefone", craque.Telefone);
                IDbDataParameter paramEmail = new SqlParameter("Email", craque.Email);
                updateCmd.Parameters.Add(paramUsername);
                updateCmd.Parameters.Add(paramPosicao);
                updateCmd.Parameters.Add(paramDataCadastro);
                updateCmd.Parameters.Add(paramNivelAtaque);
                updateCmd.Parameters.Add(paramNivelDefesa);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramEmail);

                IDbDataParameter paramId = new SqlParameter("Id", craque.Id);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarCraqueDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "delete from Craques where Id = @Id";

                IDbDataParameter paramId = new SqlParameter("Id", id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}