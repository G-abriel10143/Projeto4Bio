using Projeto4Bio.Models;
using Projeto4Bio.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Projeto4Bio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public List<Cliente> Listar(string nome = null, string email = null, string cpf = null)
        {
            var clientes = _repo.GetAll();

            if (!string.IsNullOrEmpty(nome))
                clientes = clientes.Where(c => c.Nome.Contains(nome, System.StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(email))
                clientes = clientes.Where(c => c.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(cpf))
                clientes = clientes.Where(c => c.CPF == cpf).ToList();

            return clientes;
        }

        public Cliente Criar(Cliente cliente)
        {
            _repo.Add(cliente);
            return cliente;
        }

        public Cliente Atualizar(int id, Cliente cliente)
        {
            var existente = _repo.GetById(id);
            if (existente == null) return null;

            cliente.Id = id;
            _repo.Update(cliente);
            return cliente;
        }

        public bool Remover(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null) return false;

            _repo.Delete(id);
            return true;
        }
    }
}
