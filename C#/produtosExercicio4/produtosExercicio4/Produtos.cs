using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produtosExercicio4
{
    class Produtos
    {
        public string codigo;
        public string descricao;
        public int estoque = 6;
        public double valorUnitario;
        double valorDesconto;
        double valorTaxa;
        double valorTotal;

        public void infoProduto()
        {
            valorDesconto = valorUnitario / 100 * 5;
            valorTaxa = valorUnitario / 100 * 10;
            valorTotal = valorUnitario - valorDesconto + valorTaxa;

            Console.WriteLine($"Código: {codigo} Descrição:{descricao} Estoque: {estoque}");
            Console.WriteLine($"Valor unitário: {valorUnitario} Valor desconto: {valorDesconto} Valor taxa: {valorTaxa} Valor total: {valorTotal}");
        }
    }
}
