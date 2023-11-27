using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBancoDeDados.entidades;

namespace CrudBancoDeDados.dao
{
    class Bd
    {
        public string salvarCategoria(Categorias categorias)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_categorias([id], [nome]) values(@id, @nome)";

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = categorias.Id;
                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = categorias.Nome;

                con.Open();
                cmd.Connection = con;


                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Categoria adicionada com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public string salvarProduto(Produtos produtos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into tb_produtoss([Id],[nome],[valorUnitario],[estoque],[id_categoria]) values(@Id, @nome, @valorUnitario, @estoque, @id_categoria)";

                cmd.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = produtos.Id;
                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = produtos.Nome;
                cmd.Parameters.Add("valorUnitario", System.Data.SqlDbType.Float).Value = produtos.Valor;
                cmd.Parameters.Add("estoque", System.Data.SqlDbType.Int).Value = produtos.Qnt;
                cmd.Parameters.Add("id_categoria", System.Data.SqlDbType.Int).Value = produtos.Id_categorias.Id;

                con.Open();
                cmd.Connection = con;


                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Produto adicionado com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public void mostrarCategoriaBD(List<Categorias> listaCategorias)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_categorias";

                con.Open();
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaCategorias.Clear();

                while (reader.Read())
                {
                    string nome = Convert.ToString(reader["nome"]);
                    int id = Convert.ToInt32(reader["Id"]);

                    Categorias categorias = new Categorias(id, nome);
                    listaCategorias.Add(categorias);
                }

                foreach (Categorias categoriasItem in listaCategorias)
                {
                    Console.WriteLine($"{categoriasItem.Id} - {categoriasItem.Nome}");
                }
            }
        }
        public void mostrarProdutoBD(List<Produtos> listaProdutos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_produtoss";

                con.Open();
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaProdutos.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string nome = Convert.ToString(reader["nome"]);
                    float valorUnitario = (float)Convert.ToDouble(reader["valorUnitario"]);
                    int estoque = Convert.ToInt32(reader["estoque"]);
                    int id_categoria = Convert.ToInt32(reader["id_categoria"]);

                    Categorias categoria = new Categorias(id_categoria);

                    Produtos produtos = new Produtos(id, nome, valorUnitario, estoque, categoria);
                    listaProdutos.Add(produtos);
                }

                foreach (Produtos produtosItem in listaProdutos)
                {
                    Console.WriteLine($"Id: {produtosItem.Id} - Nome: {produtosItem.Nome.Trim()} Valor Unitário: {produtosItem.Valor} - Quantidade: {produtosItem.Qnt} - Id Categoria: {produtosItem.Id_categorias.Id}");
                }
            }
        }
        public void mostrarIndividualProduto(int idCodigo, List<Produtos> listaProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_produtoss where [id_categoria] = @id_categoria";

                cmd.Parameters.Add("id_categoria", System.Data.SqlDbType.Int).Value = idCodigo;

                con.Open();

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaProduto.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string nome = Convert.ToString(reader["nome"]);
                    float valorUnitario = (float)Convert.ToDouble(reader["valorUnitario"]);
                    int estoque = Convert.ToInt32(reader["estoque"]);
                    int id_categoria = Convert.ToInt32(reader["id_categoria"]);

                    Categorias categoria = new Categorias(id_categoria);

                    Produtos produto = new Produtos(id, nome, valorUnitario, estoque, categoria);
                    listaProduto.Add(produto);
                }

                foreach (var produtosItem in listaProduto)
                {
                    Console.WriteLine($"Id: {produtosItem.Id} - Nome: {produtosItem.Nome.Trim()} Valor Unitário: {produtosItem.Valor} - Quantidade: {produtosItem.Qnt} - Id Categoria: {produtosItem.Id_categorias.Id}");
                }

            }
        }
        public void mostrarIndividualCategoria(int idCodigo, List<Categorias> listaCategorias)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_categorias where [id] = @id";

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = idCodigo;

                con.Open();

                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaCategorias.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nome = Convert.ToString(reader["nome"]);

                    Categorias categoria = new Categorias(id, nome);
                    listaCategorias.Add(categoria);
                }

                foreach (Categorias categoriaItem in listaCategorias)
                {
                    Console.WriteLine($"{categoriaItem.Id} - {categoriaItem.Nome}");
                }
            }
        }
        public string alterarCategoriaBD(Categorias categoria)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update tb_categorias set [nome] = @nome WHERE [Id] = @id";

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = categoria.Id;
                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = categoria.Nome;

                con.Open();
                cmd.Connection = con;

                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Categoria alterada com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public string alterarProdutoBD(int codigoProduto, Produtos produto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update tb_produtoss set [nome] = @nome, [valorUnitario] = @valorUnitario, [estoque] = @estoque, [id_categoria] = @id_categoria WHERE [Id] = @Id";

                cmd.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = produto.Nome;
                cmd.Parameters.Add("valorUnitario", System.Data.SqlDbType.Float).Value = produto.Valor;
                cmd.Parameters.Add("estoque", System.Data.SqlDbType.Int).Value = produto.Qnt;
                cmd.Parameters.Add("id_categoria", System.Data.SqlDbType.Int).Value = produto.Id_categorias.Id;
                cmd.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = codigoProduto;

                con.Open();
                cmd.Connection = con;

                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Produto alterado com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public string removerProdutos(int codigoProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from tb_produtoss where [Id] = @Id";

                cmd.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = codigoProduto;

                con.Open();
                cmd.Connection = con;

                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Produto removido com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public string removerCategoria(int codigoCategoria)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from tb_categorias where [id] = @id";

                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = codigoCategoria;

                con.Open();
                cmd.Connection = con;

                try
                {
                    return $"{cmd.ExecuteNonQuery() > 0}Categoria removida com SUCESSO!";
                }
                catch (SqlException)
                {
                    return "Verifique os valores";
                }
            }
        }
        public void verificarCategoria(List<Categorias> listaCategorias)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_categorias";

                con.Open();
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaCategorias.Clear();

                while (reader.Read())
                {
                    string nome = Convert.ToString(reader["nome"]);
                    int id = Convert.ToInt32(reader["Id"]);

                    Categorias categorias = new Categorias(id, nome);
                    listaCategorias.Add(categorias);
                }
            }
        }
        public void verificarProduto(List<Produtos> listaProdutos)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_estoqueProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tb_produtoss";

                con.Open();
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();

                listaProdutos.Clear();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string nome = Convert.ToString(reader["nome"]);
                    float valorUnitario = (float)Convert.ToDouble(reader["valorUnitario"]);
                    int estoque = Convert.ToInt32(reader["estoque"]);
                    int id_categoria = Convert.ToInt32(reader["id_categoria"]);

                    Categorias categoria = new Categorias(id_categoria);

                    Produtos produtos = new Produtos(id, nome, valorUnitario, estoque, categoria);
                    listaProdutos.Add(produtos);
                }
            }
        }
    }
}
