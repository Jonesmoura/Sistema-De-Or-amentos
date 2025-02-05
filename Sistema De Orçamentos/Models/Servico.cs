namespace SistemaOrc.Models
{
    public class Servico
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }


        public int OrcamentoId { get; set; }
        public virtual Orcamento Orcamento{ get; set; }
    }
}
