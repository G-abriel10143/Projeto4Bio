Projeto4Bio – API de Clientes
Sobre o Projeto

O Projeto4Bio é uma API feita em .NET Core para gerenciar informações de clientes, incluindo seus contatos e endereços.
Ela foi construída pensando em boas práticas de desenvolvimento: código limpo, orientação a objetos, princípios SOLID e separação de responsabilidades (Controller → Service → Repository).

O armazenamento é feito usando JSON, então você não precisa de banco de dados instalado para testar. É tudo local e fácil de mexer.

Estrutura de Dados
Cliente

Id: incremental

Nome: obrigatório

Email: obrigatório e válido

CPF: obrigatório e válido

RG: obrigatório

Contatos: lista de contatos

Endereços: lista de endereços

Contato

Id: incremental

Tipo: Residencial, Comercial ou Celular

DDD: código de área

Telefone: número

Endereço

Id: incremental

Tipo: Preferencial, Entrega, Cobrança

CEP: obrigatório

Logradouro, Número, Bairro, Complemento, Cidade, Estado, Referência

Funcionalidades da API

Listar todos os clientes (com filtros opcionais: nome, email ou cpf)

Adicionar um novo cliente

Atualizar cliente existente

Incluir ou atualizar contatos

Incluir ou atualizar endereços

Remover cliente, contato ou endereço

Rotas e Como Usar
Método	Rota	O que faz
GET	/cliente/listar	Lista todos os clientes (pode filtrar por nome, email ou CPF)
POST	/cliente/criar	Cria um novo cliente
PUT	/cliente/atualizar/{id}	Atualiza um cliente existente
DELETE	/cliente/remover/{id}	Remove um cliente

Dica: os filtros do GET são opcionais. Se você não passar nada, ele retorna todos os clientes cadastrados.

Exemplos de JSON
Criar Cliente (POST)
{
  "nome": "João da Silva",
  "email": "joao.silva@example.com",
  "cpf": "12345678900",
  "rg": "12345678",
  "contatos": [
    {
      "tipo": "Celular",
      "ddd": 11,
      "telefone": "999888777"
    }
  ],
  "enderecos": [
    {
      "tipo": "Preferencial",
      "cep": "04534000",
      "logradouro": "Av. Paulista",
      "numero": 1200,
      "bairro": "Bela Vista",
      "cidade": "São Paulo",
      "estado": "SP"
    }
  ]
}

Atualizar Cliente (PUT)
{
  "nome": "João C. Silva",
  "email": "joao.silva@example.com",
  "cpf": "12345678900",
  "rg": "12345678",
  "contatos": [
    {
      "tipo": "Celular",
      "ddd": 11,
      "telefone": "999888777"
    }
  ],
  "enderecos": [
    {
      "tipo": "Preferencial",
      "cep": "04534000",
      "logradouro": "Av. Paulista",
      "numero": 1200,
      "bairro": "Bela Vista",
      "cidade": "São Paulo",
      "estado": "SP"
    }
  ]
}

Como Rodar

Clone o repositório:

git clone https://github.com/G-abriel10143/Projeto4Bio


Abra no Visual Studio.

Restaure os pacotes NuGet:

dotnet restore


Rode o projeto:

dotnet run


Acesse a API pelo Swagger para testar:

http://localhost:7020/swagger
