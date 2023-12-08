using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;

namespace agendaMVC.Dao
{
    public class DaoCompromisso : ICrud<Compromisso>
    {
        public void mostrar(List<Compromisso> listarCompromissos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = cmd.CommandText = "select tc.id, tc.hora, tc.data, tl.rua, tct.email, tc.status " +
                  "from tb_compromisso tc " +
                  "inner join tb_local tl on tc.id_local = tl.id " +
                  "inner join tb_contatos tct on tc.id_contato = tct.Id";


                con.Open();

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarCompromissos.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string hora = Convert.ToString(reader["hora"]).Trim();
                    string data = Convert.ToString(reader["data"]).Trim();
                    string local = Convert.ToString(reader["rua"]);
                    string contato = Convert.ToString(reader["email"]);
                    string status = Convert.ToString(reader["status"]).Trim();

                    Local localObj = new Local(local);
                    Contato contatoObj = new Contato(contato);

                    Compromisso compromisso = new Compromisso(id, data, hora, localObj, contatoObj, status);
                    listarCompromissos.Add(compromisso);
                }
            }
        }
        public bool criar(Compromisso compromisso)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_compromisso (data, hora, id_local, id_contato, status) values(@data, @hora, @id_local, @id_contato, @status)";

                con.Open();

                cmd.Parameters.Add("data", System.Data.SqlDbType.Date).Value = compromisso.Data;
                cmd.Parameters.Add("hora", System.Data.SqlDbType.Time).Value = compromisso.Hora;
                cmd.Parameters.Add("id_local", System.Data.SqlDbType.Int).Value = compromisso.Local.Id;
                cmd.Parameters.Add("id_contato", System.Data.SqlDbType.Int).Value = compromisso.Contato.Id;
                cmd.Parameters.Add("status", System.Data.SqlDbType.VarChar).Value = compromisso.Status;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool att(Compromisso compromisso)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update tb_compromisso set data = @data, hora = @hora, id_local = @id_local, id_contato = @id_contato, status = @status where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = compromisso.Id;
                cmd.Parameters.Add("data", System.Data.SqlDbType.VarChar).Value = compromisso.Data;
                cmd.Parameters.Add("hora", System.Data.SqlDbType.Time).Value = compromisso.Hora;
                cmd.Parameters.Add("id_local", System.Data.SqlDbType.Int).Value = compromisso.Local.Id;
                cmd.Parameters.Add("id_contato", System.Data.SqlDbType.Int).Value = compromisso.Contato.Id;
                cmd.Parameters.Add("status", System.Data.SqlDbType.VarChar).Value = compromisso.Status;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool deletar(Compromisso compromisso)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from tb_compromisso where id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = compromisso.Id;

                cmd.Connection = con;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
