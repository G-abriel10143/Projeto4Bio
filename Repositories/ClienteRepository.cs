using Projeto4Bio.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Projeto4Bio.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _filePath = Path.Combine("Data", "clientes.json");

        public List<Cliente> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Cliente>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
        }

        public Cliente GetById(int id) =>
            GetAll().FirstOrDefault(c => c.Id == id);

        public void Add(Cliente cliente)
        {
            var clientes = GetAll();
            cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
            SaveChanges(clientes);
        }

        public void Update(Cliente cliente)
        {
            var clientes = GetAll();
            var index = clientes.FindIndex(c => c.Id == cliente.Id);
            if (index >= 0)
            {
                clientes[index] = cliente;
                SaveChanges(clientes);
            }
        }

        public void Delete(int id)
        {
            var clientes = GetAll();
            clientes.RemoveAll(c => c.Id == id);
            SaveChanges(clientes);
        }

        public void SaveChanges(List<Cliente> clientes)
        {
            var json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory("Data");
            File.WriteAllText(_filePath, json);
        }
    }
}
