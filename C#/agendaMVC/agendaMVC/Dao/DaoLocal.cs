using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;

namespace agendaMVC.Dao
{
    public class DaoLocal : ICrud<Local>
    {
        public void mostrar(List<Local> listarLocais)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_local";

                con.Open();

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarLocais.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nome = Convert.ToString(reader["nome"]).Trim();
                    string rua = Convert.ToString(reader["rua"]).Trim();
                    int numero = Convert.ToInt32(reader["numero"]);
                    string bairro = Convert.ToString(reader["bairro"]).Trim();
                    string cidade = Convert.ToString(reader["cidade"]).Trim();
                    string cep = Convert.ToString(reader["cep"]).Trim();
                    string uf = Convert.ToString(reader["uf"]).Trim();

                    Local locais = new Local(id, nome, rua, numero, bairro, cidade, cep, uf);
                    listarLocais.Add(locais);
                }
            }
        }
        public bool criar(Local local)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_local(nome, rua, numero, bairro, cidade, cep, uf) values(@nome, @rua, @numero, @bairro, @cidade, @cep, @uf)";

                con.Open();

                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = local.Nome;
                cmd.Parameters.Add("rua", System.Data.SqlDbType.VarChar).Value = local.Rua;
                cmd.Parameters.Add("numero", System.Data.SqlDbType.Int).Value = local.Numero;
                cmd.Parameters.Add("bairro", System.Data.SqlDbType.VarChar).Value = local.Bairro;
                cmd.Parameters.Add("cidade", System.Data.SqlDbType.VarChar).Value = local.Cidade;
                cmd.Parameters.Add("cep", System.Data.SqlDbType.VarChar).Value = local.Cep;
                cmd.Parameters.Add("uf", System.Data.SqlDbType.VarChar).Value = local.Uf;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool att(Local local)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update tb_local set nome = @nome, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, cep = @cep, uf = @uf where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = local.Id;
                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = local.Nome;
                cmd.Parameters.Add("rua", System.Data.SqlDbType.VarChar).Value = local.Rua;
                cmd.Parameters.Add("numero", System.Data.SqlDbType.Int).Value = local.Numero;
                cmd.Parameters.Add("bairro", System.Data.SqlDbType.VarChar).Value = local.Bairro;
                cmd.Parameters.Add("cidade", System.Data.SqlDbType.VarChar).Value = local.Cidade;
                cmd.Parameters.Add("cep", System.Data.SqlDbType.VarChar).Value = local.Cep;
                cmd.Parameters.Add("uf", System.Data.SqlDbType.VarChar).Value = local.Uf;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool deletar(Local local)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from tb_local where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = local.Id;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
