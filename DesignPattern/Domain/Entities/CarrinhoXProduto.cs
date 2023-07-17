using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarrinhoXProduto
    {

        private CarrinhoXProduto() { }

        public CarrinhoXProduto(Carrinho carrinho, Produto produto, int quantidade)
        {
            if (carrinho.Finalizado)
            {
                throw new ArgumentException();
            }

            Carrinho = carrinho;
            Produto = produto;
            Quantidade = quantidade;
        }

        public Carrinho Carrinho { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

    }
}
