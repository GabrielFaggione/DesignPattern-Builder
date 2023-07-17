using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.Entitites
{
    public class ProdutoBuilder : Builder
    {

        public string Nome = Faker.Name.FirstName();
        public string Descricao = Faker.Name.LastName();
        public decimal ValorOriginal = Faker.Random.Decimal(1, 10);
        private Produto Produto { get; set; }

        public static ProdutoBuilder Novo()
        {
            return new ProdutoBuilder();
        }

        public ProdutoBuilder ComNome(string? nome)
        {
            Nome = nome;
            return this;
        }

        public ProdutoBuilder ComDescricao(string? descricao)
        {
            Descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComValor(decimal valor)
        {
            ValorOriginal = valor;
            return this;
        }

        public Produto Build()
        {
            Produto = new Produto(Nome, Descricao, ValorOriginal);
            return Produto;
        }

    }
}
