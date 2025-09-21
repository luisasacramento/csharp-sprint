using System.Collections.Generic;
using ProjetoCSharp.Models;
using ProjetoCSharp.Data;

namespace ProjetoCSharp.Services
{
    public class ClienteService
    {
        private ClienteRepository repository = new ClienteRepository();

        public void AdicionarCliente(string nome, string email)
        {
            var cliente = new Cliente { Nome = nome, Email = email };
            repository.Create(cliente);
        }

        public List<Cliente> GetAll()
        {
            return repository.ReadAll();
        }

        public void AtualizarCliente(int id, string nome, string email)
        {
            var cliente = new Cliente { Id = id, Nome = nome, Email = email };
            repository.Update(cliente);
        }

        public void DeletarCliente(int id)
        {
            repository.Delete(id);
        }
    }
}
