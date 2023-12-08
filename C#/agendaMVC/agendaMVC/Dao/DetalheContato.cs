using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;

namespace agendaMVC.Dao
{
    public class DetalheContato : IDetalhe<Contato>
    {
        public void detalhe(Contato contato, List<Contato> listarContato)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_contatos where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = contato.Id;

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarContato.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nome = Convert.ToString(reader["nome"]);
                    string email = Convert.ToString(reader["email"]);
                    string telefone = Convert.ToString(reader["fone"]);

                    Contato contatos = new Contato(id, nome, email, telefone);
                    listarContato.Add(contatos);
                }
            }
        }
    }
}
