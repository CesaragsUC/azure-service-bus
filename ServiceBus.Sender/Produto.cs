using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Sender
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }


        public async Task<Produto> CriarProduto()
        {
            //gerar produto com bogus
            var produto = new Faker<Produto>("pt_BR")
                .CustomInstantiator(f => new Produto())
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 1000))
                .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 1000))
                .Generate();

            return produto;
        }

        public async Task<List<Produto>> CriarListaProduto(int total)
        {
            //gerar lista produto com bogus
            var produtos = new Faker<Produto>("pt_BR")
                .CustomInstantiator(f => new Produto())
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Preco, f => f.Random.Decimal(1, 1000))
                .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 1000))
                .Generate(total);

            return produtos;
        }
    }
}
