using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;
using System.Threading;

namespace agendaMVC.Dao
{
    public class DaoContato : ICrud<Contato>
    {
        public void mostrar(List<Contato> listarContato)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_contatos";

                con.Open();
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarContato.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nome = Convert.ToString(reader["nome"]).Trim();
                    string email = Convert.ToString(reader["email"]).Trim();
                    string telefone = Convert.ToString(reader["fone"]).Trim();

                    Contato contatos = new Contato(id, nome, email, telefone);
                    listarContato.Add(contatos);
                }
            }
        }

        public bool criar(Contato contato) 
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_contatos(nome, email, fone) values(@nome, @email, @fone)";

                con.Open();

                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = contato.Name;
                cmd.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = contato.Email;
                cmd.Parameters.Add("fone", System.Data.SqlDbType.VarChar).Value = contato.Fone;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool att(Contato contato)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update tb_contatos set nome = @nome, email = @email, fone = @fone where Id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = contato.Id;
                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = contato.Name;
                cmd.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = contato.Email;
                cmd.Parameters.Add("fone", System.Data.SqlDbType.VarChar).Value = contato.Fone;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool deletar(Contato contato)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from tb_contatos where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = contato.Id;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
