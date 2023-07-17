using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string email, string logradouro, string numero, string complemento, string cidade, string estado)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException();
            }

            Nome = nome;
            Email = email;
            Endereco = new Endereco(logradouro, numero, complemento, cidade, estado);
        }

        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        List<Carrinho> Carrinhos { get; set; }
        public Carrinho CarrinhoAtual
        {
            get
            {
                var carrinhoAtual = Carrinhos
                    .OrderByDescending(o => o.DataCriacao)
                    .FirstOrDefault();

                if (carrinhoAtual == null || carrinhoAtual.Abandonado)
                {
                    carrinhoAtual = GerarNovoCarrinho();
                }
                else if ((carrinhoAtual.DataCriacao - DateTime.UtcNow).Days > 5)
                {
                    carrinhoAtual.AbandonarCarrinho();
                    carrinhoAtual = GerarNovoCarrinho();
                }

                return carrinhoAtual;
            }
        }

        private Carrinho GerarNovoCarrinho()
        {
            var carrinho = new Carrinho(this);
            Carrinhos.Add(carrinho);
            return carrinho;
        } 

    }
}
