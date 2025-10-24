namespace Projeto4Bio.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty; // Residencial, Comercial, Celular
        public int DDD { get; set; }
        public decimal Telefone { get; set; }
    }
}
