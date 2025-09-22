# Projeto C# CRUD Clientes

## Integrantes
Gabriel aparecido Cassalho Xavier RM 99794  
Gustavo Vegi RM 550188  
Lucas Rodrigues Delfino RM 550196  
Luisa Cristina dos Santos Neves RM 551889  
Pedro Henrique Silva de Morais RM 98804  


## 📌 Descrição
Este projeto é uma aplicação em **C# .NET Console** que permite gerenciar clientes através de **CRUD** integrado a banco de dados SQL Server, além de suportar **manipulação de arquivos TXT e JSON** para importação/exportação de dados.

## 🎯 Funcionalidades
- ✅ Criar, listar, atualizar e deletar clientes (CRUD)
- ✅ Conexão com banco de dados SQL Server
- ✅ Exportação e importação de clientes em JSON
- ✅ Manipulação de arquivos TXT
- ✅ Interface via Console
- ✅ Código limpo e estruturado em camadas

## Tecnologias
- C# .NET 6
- SQL Server
- Newtonsoft.Json

## Script para usar no SQL Server com essa aplicação

---

## 🛠️ Configuração do Banco de Dados

1. Abra o **SQL Server Management Studio (SSMS)** ou outro cliente SQL.
2. Execute o script abaixo para criar o banco e as tabelas:

```sql
-- Criar banco de dados
CREATE DATABASE ProjetoDB;
GO

USE ProjetoDB;
GO

-- Tabela de Clientes
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Email NVARCHAR(100)
);

-- Tabela de Produtos
CREATE TABLE Produtos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Preco DECIMAL(10,2),
    Estoque INT
);´´´

## Estrutura
- Models/ -> Classes de dados
- Data/ -> Conexão com banco
- Services/ -> Lógica
- Utils/ -> Manipulação de arquivos
- UI/ -> Interface

## Arquitetura em Diagrama 
mermaid
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

