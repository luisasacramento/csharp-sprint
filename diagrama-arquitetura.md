```mermaid
classDiagram
    class Cliente {
        +int Id
        +string Nome
        +string Email
    }

    class ClienteRepository {
        +Create(Cliente)
        +ReadAll() List<Cliente>
        +Update(Cliente)
        +Delete(int)
    }

    class ClienteService {
        +AdicionarCliente(string, string)
        +GetAll() List<Cliente>
        +AtualizarCliente(int, string, string)
        +DeletarCliente(int)
    }

    class FileHandler {
        +SaveToTxt(string, string)
        +ReadFromTxt(string) string
        +SaveToJson<T>(string, T)
        +ReadFromJson<T>(string) T
    }

    class ConsoleUI {
        +Start()
    }

    ClienteRepository --> Cliente
    ClienteService --> ClienteRepository
    ConsoleUI --> ClienteService
    FileHandler --> Cliente
