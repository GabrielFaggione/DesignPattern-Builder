using Builders.Entitites;
using Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.EntitiesTests
{
    public class ProdutoTests
    {

        [Fact]
        public void Produto_CriacaoComSucesso()
        {
            // Arrange
            var nome = "Teste";
            var descricao = "Produto teste";
            var valor = 10;

            // Act
            var produto = new Produto(nome, descricao, valor);

            // Assert
            produto.Nome.ShouldBe(nome);
            produto.Descricao.ShouldBe(descricao);
            produto.Valor.ShouldBe(valor);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Produto_CriacaoSemNome(string nome)
        {
            // Arrange
            var produtoBuilder = ProdutoBuilder.Novo()
                .ComNome(nome);

            // Act
            var exception = Record.Exception(() => produtoBuilder.Build());

            // Assert
            exception.ShouldNotBeNull();
            exception.GetType().ShouldBe(typeof(ArgumentNullException));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Produto_CriacaoSemDescricao(string descricao)
        {
            // Arrange
            var produtoBuilder = ProdutoBuilder.Novo()
                .ComDescricao(descricao);

            // Act
            var exception = Record.Exception(() => produtoBuilder.Build());

            // Assert
            exception.ShouldNotBeNull();
            exception.GetType().ShouldBe(typeof(ArgumentNullException));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Produto_CriacaoSemValor(decimal valor)
        {
            // Arrange
            var produtoBuilder = ProdutoBuilder.Novo()
                .ComValor(valor);

            // Act
            var exception = Record.Exception(() => produtoBuilder.Build());

            // Assert
            exception.ShouldNotBeNull();
            exception.GetType().ShouldBe(typeof(ArgumentException));
        }


        [Theory]
        [InlineData(-25)]
        [InlineData(0)]
        [InlineData(75)]
        [InlineData(100)]
        public void Produto_InserirPromocaoComPorcentagemInvalida(decimal porcentagem)
        {
            // Arrange
            var produto = ProdutoBuilder.Novo().ComValor(10).Build();

            // Act
            var exception = Record.Exception(() => produto.InserirPromocao(porcentagem));

            // Assert
            exception.ShouldNotBeNull();
            exception.GetType().ShouldBe(typeof(ArgumentException));
        }

        [Theory]
        [InlineData(10, 9)]
        [InlineData(25, 7.5d)]
        [InlineData(50, 5)]
        public void Produto_InserirPromocaoComPorcentagemValida(decimal porcentagem, decimal valorEsperado)
        {
            // Arrange
            var produto = ProdutoBuilder.Novo().ComValor(10).Build();

            // Act
            produto.InserirPromocao(porcentagem);

            // Assert
            produto.EmPromocao.ShouldBeTrue();
            produto.PorcentagemDesconto.ShouldBe(porcentagem);
            produto.Valor.ShouldBe(valorEsperado);
        }

    }
}
