using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
    {

        private Produto() { }

        public Produto(string nome, string descricao, decimal valorOriginal)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(descricao) || string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentNullException();
            }
            if (valorOriginal <= 0)
            {
                throw new ArgumentException();
            }

            Nome = nome;
            Descricao = descricao;
            ValorOriginal = valorOriginal;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorOriginal { get; set; }
        public bool EmPromocao { get; set; }
        public decimal PorcentagemDesconto { get; set; }
        public decimal Valor
        {
            get 
            { 
                return EmPromocao ? 
                    ValorOriginal * ((100 - PorcentagemDesconto) / 100) : 
                    ValorOriginal; 
            }
        }

        public void InserirPromocao(decimal porcentagemDesconto)
        {
            if (EmPromocao || (porcentagemDesconto <= 0 || porcentagemDesconto >= 75))
                throw new ArgumentException();

            EmPromocao = true;
            PorcentagemDesconto = porcentagemDesconto;
        }

    }
}
