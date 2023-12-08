using agendaMVC.Interfaces;
using agendaMVC.Models;
using System.Data.SqlClient;

namespace agendaMVC.Dao
{
    public class DetalheCompromisso : IDetalhe<Compromisso>
    {
        public void detalhe(Compromisso compromisso, List<Compromisso> listarCompromisso)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DaoConexao.stringConexao;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = cmd.CommandText = "select tc.id, tc.hora, tc.data, tl.rua, tct.email, tc.status " +
                                                    "from tb_compromisso tc " +
                                                    "inner join tb_local tl on tc.id_local = tl.id " +
                                                    "inner join tb_contatos tct on tc.id_contato = tct.Id where tc.id = @id";

                con.Open();

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = compromisso.Id;

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listarCompromisso.Clear();

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

                    Compromisso compromissoObj = new Compromisso(id, data, hora, localObj, contatoObj, status);
                    listarCompromisso.Add(compromissoObj);
                }
            }
        }
    }
}
