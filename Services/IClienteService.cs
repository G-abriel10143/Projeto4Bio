using Projeto4Bio.Models;
using System.Collections.Generic;

namespace Projeto4Bio.Services
{
    public interface IClienteService
    {
        List<Cliente> Listar(string nome = null, string email = null, string cpf = null);
        Cliente Criar(Cliente cliente);
        Cliente Atualizar(int id, Cliente cliente);
        bool Remover(int id);
    }
}
