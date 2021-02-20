using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}
