namespace SistemaOrc.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string MyProperty { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public bool Ativo { get; set; }

        public List<Orcamento> Orcamentos { get; set; }

    }
}
