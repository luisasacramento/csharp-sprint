using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ClienteRepository
{
    private string connectionString = "Server=localhost;Database=MeuDB;Trusted_Connection=True;";

    public void Create(Cliente cliente)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var query = "INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nome", cliente.Nome);
        command.Parameters.AddWithValue("@Email", cliente.Email);
        command.ExecuteNonQuery();
    }

    public List<Cliente> ReadAll()
    {
        var clientes = new List<Cliente>();
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var query = "SELECT * FROM Clientes";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            clientes.Add(new Cliente
            {
                Id = (int)reader["Id"],
                Nome = reader["Nome"].ToString(),
                Email = reader["Email"].ToString()
            });
        }
        return clientes;
    }

    public void Update(Cliente cliente)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var query = "UPDATE Clientes SET Nome=@Nome, Email=@Email WHERE Id=@Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nome", cliente.Nome);
        command.Parameters.AddWithValue("@Email", cliente.Email);
        command.Parameters.AddWithValue("@Id", cliente.Id);
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var query = "DELETE FROM Clientes WHERE Id=@Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }
}
