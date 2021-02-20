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
            throw new System.NotImplementedException();
        }
    }
}
