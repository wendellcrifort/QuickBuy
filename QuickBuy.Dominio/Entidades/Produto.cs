namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            if(string.IsNullOrWhiteSpace(Nome))
                MensagensValidacao.Add("Voce deve informar o nome do produto.");

            if (string.IsNullOrWhiteSpace(Descricao))
                MensagensValidacao.Add("Voce deve informar a descrição do produto.");
        }
    }
}
