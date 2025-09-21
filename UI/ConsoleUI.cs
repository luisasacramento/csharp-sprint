using System;
using ProjetoCSharp.Services;
using ProjetoCSharp.Models;
using ProjetoCSharp.Utils;

namespace ProjetoCSharp.UI
{
    public class ConsoleUI
    {
        private ClienteService service = new ClienteService();
        private string jsonPath = "clientes.json";

        public void Start()
        {
            Console.WriteLine("=== Sistema de Gerenciamento de Clientes ===");

            while (true)
            {
                Console.WriteLine("\n1 - Listar | 2 - Criar | 3 - Atualizar | 4 - Deletar | 5 - Exportar JSON | 6 - Importar JSON | 0 - Sair");
                Console.Write("Escolha: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": ListarClientes(); break;
                    case "2": CriarCliente(); break;
                    case "3": AtualizarCliente(); break;
                    case "4": DeletarCliente(); break;
                    case "5": ExportarJson(); break;
                    case "6": ImportarJson(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        private void ListarClientes()
        {
            var clientes = service.GetAll();
            if (clientes.Count == 0) Console.WriteLine("Nenhum cliente cadastrado.");
            foreach (var c in clientes)
                Console.WriteLine($"{c.Id} - {c.Nome} - {c.Email}");
        }

        private void CriarCliente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            service.AdicionarCliente(nome, email);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        private void AtualizarCliente()
        {
            Console.Write("ID do cliente: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();
            Console.Write("Novo email: ");
            string email = Console.ReadLine();
            service.AtualizarCliente(id, nome, email);
            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        private void DeletarCliente()
        {
            Console.Write("ID do cliente: ");
            int id = int.Parse(Console.ReadLine());
            service.DeletarCliente(id);
            Console.WriteLine("Cliente removido com sucesso!");
        }

        private void ExportarJson()
        {
            var clientes = service.GetAll();
            FileHandler.SaveToJson(jsonPath, clientes);
            Console.WriteLine("Clientes exportados para JSON!");
        }

        private void ImportarJson()
        {
            var clientes = FileHandler.ReadFromJson<System.Collections.Generic.List<Cliente>>(jsonPath);
            if (clientes != null)
            {
                foreach (var cliente in clientes)
                    service.AdicionarCliente(cliente.Nome, cliente.Email);
                Console.WriteLine("Clientes importados do JSON!");
            }
            else
            {
                Console.WriteLine("Nenhum arquivo JSON encontrado.");
            }
        }
    }
}
