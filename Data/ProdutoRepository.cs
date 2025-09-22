using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoCSharp.Models;

namespace ProjetoCSharp.Data
{
    public class ProdutoRepository
    {
        public void Create(Produto produto)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Produtos (Nome, Preco, Estoque) VALUES (@Nome, @Preco, @Estoque)", conn);
            cmd.Parameters.AddWithValue("@Nome", produto.Nome);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@Estoque", produto.Estoque);

            cmd.ExecuteNonQuery();
        }

        public List<Produto> ReadAll()
        {
            var produtos = new List<Produto>();
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Produtos", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                produtos.Add(new Produto
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Preco = reader.GetDecimal(2),
                    Estoque = reader.GetInt32(3)
                });
            }

            return produtos;
        }

        public void Update(Produto produto)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "UPDATE Produtos SET Nome=@Nome, Preco=@Preco, Estoque=@Estoque WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", produto.Id);
            cmd.Parameters.AddWithValue("@Nome", produto.Nome);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@Estoque", produto.Estoque);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("DELETE FROM Produtos WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
