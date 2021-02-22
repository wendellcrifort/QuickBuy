using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email))
                MensagensValidacao.Add("Voce deve informar o Email do usuário.");

            if (string.IsNullOrWhiteSpace(Nome))
                MensagensValidacao.Add("Voce deve informar o Nome do usuário.");

            if (string.IsNullOrWhiteSpace(Sobrenome))
                MensagensValidacao.Add("Voce deve informar o Sobrenome do usuário.");

            if (string.IsNullOrWhiteSpace(Senha))
                MensagensValidacao.Add("Voce deve informar a Senha do usuário.");
        }
    }
}
