using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }

        public bool Finalizado { get; private set; }
        public bool Abandonado { get; private set; }
        public DateTime DataCriacao { get; set; }

        private Carrinho() { }

        public Carrinho(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException();
            }
            XProdutos = new List<CarrinhoXProduto>();
            DataCriacao = DateTime.UtcNow;
        }

        public List<CarrinhoXProduto> XProdutos { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public void FinalizarCompra()
        {
            if (XProdutos.Count == 0)
            {
                throw new ArgumentException();
            }
            Finalizado = true;
        }

        public void AbandonarCarrinho()
        {
            Abandonado = true;
        }


    }

}
