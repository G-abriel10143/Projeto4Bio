using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Projeto4Bio.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public List<Contato> Contatos { get; set; } = new();
        public List<Endereco> Enderecos { get; set; } = new();
    }
}
