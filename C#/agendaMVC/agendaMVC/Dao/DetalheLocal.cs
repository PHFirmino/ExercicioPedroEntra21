using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;

namespace agendaMVC.Dao
{
    public class DetalheLocal : IDetalhe<Local>
    {
        public void detalhe(Local local, List<Local> listarLocal)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_local where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = local.Id;

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarLocal.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nome = Convert.ToString(reader["nome"]);
                    string rua = Convert.ToString(reader["rua"]);
                    int numero = Convert.ToInt32(reader["numero"]);
                    string bairro = Convert.ToString(reader["bairro"]);
                    string cidade = Convert.ToString(reader["cidade"]);
                    string cep = Convert.ToString(reader["cep"]);
                    string uf = Convert.ToString(reader["uf"]);

                    Local locais = new Local(id, nome, rua, numero, bairro, cidade, cep, uf);
                    listarLocal.Add(locais);
                }
            }
        }
    }
}
