namespace SistemaOrc.Models
{
    public class Orcamento
    {
        public DateTime DataCriacao { get; set; }
        public decimal ValorTotal { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public List<Servico> Servicos { get; set; }

    }
}
