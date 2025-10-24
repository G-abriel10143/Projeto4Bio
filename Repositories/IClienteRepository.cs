using Projeto4Bio.Models;
using System.Collections.Generic;

namespace Projeto4Bio.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
        void SaveChanges(List<Cliente> clientes);
    }
}
