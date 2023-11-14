namespace propriedadeEncapsulamentoExercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro("4343-AB4", "Ford", "Fusion", "Preto");

            Console.WriteLine(carro.mostrarCarro());

            Calculadora calculadora = new Calculadora(3, 3);

            calculadora.adicao();
            calculadora.subtracao();
            calculadora.multiplicacao();
            calculadora.divisao();


            Retangulo retangulo = new Retangulo(4, 6);

            retangulo.calculoArea();
            retangulo.calculoPerimetro();

            Produto produto = new Produto(1, "Cadeira", 10, 5);

            produto.MostrarProduto();

            Console.ReadKey();
        }
    }
    class Carro
    {
        private string placa;
        public string Placa
        {
            get
            {
                return placa;
            }
            set
            {
                if (value.Length >= 4)
                {
                    placa = value;
                }
                else
                {
                    placa = "Valor Inválido";
                }
            }
        }

        private string marca;
        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                if (value.Length >= 4)
                {
                    marca = value;
                }
                else
                {
                    marca = "Valor Inválido";
                }
            }
        }

        private string modelo;
        public string Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                if (value.Length >= 4)
                {
                    modelo = value;
                }
                else
                {
                    modelo = "Valor Inválido";
                }
            }
        }

        private string cor;
        public string Cor
        {
            get
            {
                return cor;
            }
            set
            {
                if (value.Length >= 4)
                {
                    cor = value;
                }
                else
                {
                    cor = "Valor Inválido";
                }
            }
        }

        public Carro(string placa, string marca, string modelo, string cor)
        {
            Placa = placa;
            Marca = marca;;
            Modelo = modelo;
            Cor = cor;
        }

        public string mostrarCarro()
        {
            return $"Placa: {placa}, Marca: {marca}, Modelo: {modelo} Cor: {cor}";
        }
    }
    class Calculadora
    {
        private int n1;
        private int n2;

        public int N1
        {
            get
            {
                return n1;
            }
            set
            {
                if (value > 0)
                {
                    n1 = value;
                }
            }
        }
        public int N2
        {
            get
            {
                return n2;
            }
            set
            {
                if (value > 0)
                {
                    n2 = value;
                }
            }
        }

        public Calculadora(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
        }

        public void adicao()
        {
            if (n1 == 0 || n2 == 0)
            {
                Console.WriteLine("Inválido coloque acima de 0");
            }
            else
            {
                Console.WriteLine(n1 + n2);
            }
        }
        public void subtracao()
        {
            if (n1 == 0 || n2 == 0)
            {
                Console.WriteLine("Inválido coloque acima de 0");
            }
            else
            {
                Console.WriteLine(n1 - n2);
            }
        }
        public void multiplicacao()
        {
            if (n1 == 0 || n2 == 0)
            {
                Console.WriteLine("Inválido coloque acima de 0");
            }
            else
            {
                Console.WriteLine(n1 * n2);
            }
        }
        public void divisao()
        {
            if (n1 == 0 || n2 == 0)
            {
                Console.WriteLine("Inválido coloque acima de 0");
            }
            else
            {
                Console.WriteLine(n1 / n2);
            }
        }
    }
    class Retangulo
    {
        private int altura;
        private int comprimento;

        public int Altura
        {
            get
            {
                return altura;
            }
            set
            {
                if (value > 0)
                {
                    altura = value;
                }
            }
        }
        public int Comprimento
        {
            get
            {
                return comprimento;
            }
            set
            {
                if (value > 0)
                {
                    comprimento = value;
                }
            }
        }

        public Retangulo(int altura, int comprimento)
        {
            Altura = altura;
            Comprimento = comprimento;
        }

        public void calculoPerimetro()
        {
            if (altura != 0 && comprimento != 0)
            {
                Console.WriteLine($"Perimetro: {(altura + comprimento) * 2}");
            }
            else
            {
                Console.WriteLine("Reveja os valores");
            }
        }
        public void calculoArea()
        {
            if (altura != 0 && comprimento != 0)
            {
                Console.WriteLine($"Área: {comprimento * altura}");
            }
            else
            {
                Console.WriteLine("Reveja os valores");
            }
        }
    }
    class Produto
    {
        private int codigo;
        private string descricao;
        private int estoque;
        private double valorUnitario;
        private double valorDesconto;
        private double valorTaxa;
        private double valorTotal;

        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                if (value > 0)
                {
                    codigo = value;
                }
            }
        }
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                if (value.Length >= 4)
                {
                    descricao = value;
                }
                else
                {
                    descricao = "Valor Inválido";
                }
            }
        }
        public int Estoque
        {
            get
            {
                return estoque;
            }
            set
            {
                if (value > 0)
                {
                    estoque = value;
                }
            }
        }
        public double ValorUnitário
        {
            get
            {
                return valorUnitario;
            }
            set
            {
                if (value > 0)
                {
                    valorUnitario = value;
                }
            }
        }

        public Produto(int codigo, string descricao, int estoque, double valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            Estoque = estoque;
            ValorUnitário = valorUnitario;
        }

        public void MostrarProduto()
        {
            if (codigo == 0 || valorUnitario == 0 || estoque == 0)
            {
                Console.WriteLine("Reveja os valores");
            }
            else
            {
                valorDesconto = valorUnitario / 100 * 5;
                valorTaxa = valorUnitario / 100 * 10;
                valorTotal = valorUnitario + valorTaxa - valorDesconto;

                Console.WriteLine($"Código: {codigo}, Descrição: {descricao}, Estoque: {estoque}");
                Console.WriteLine($"Valor unitário: {valorUnitario}, Valor desconto:{valorDesconto}, Valor taxa: {valorTaxa}, Valor total: {valorTotal}");
            }
        }
    }
}