using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public abstract class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Quilometragem { get; set; }
        public List<ItemVIstoria> VistoriasRealizadas { get; set; } = [];

        // Construtor explícito utilizando a palavra-chave this para atribuição das propriedades;
        public Veiculo(string marca, string modelo, int ano, double km)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = km;
        }
        public Veiculo()
        {
            Console.Write("Qual a MARCA do veiculo: ");
            this.Marca = Console.ReadLine();
            Console.Write("Qual o MODELO do veiculo: ");
            this.Modelo = Console.ReadLine();
            while (true)
            {
                Console.Write("Qual o ANO do veiculo: ");
                bool validaResposta = int.TryParse(Console.ReadLine(),out int ano);
                if (validaResposta && ano < 2026 && ano > 1884)
                {
                    this.Ano = ano;
                    break;
                } else
                {
                    Console.WriteLine("ANO INVALIDO");
                }
                
            }
            while (true)
            {
                Console.Write("Qual a QUILOMETRAGEM do veiculo: ");
                bool validaResposta = double.TryParse(Console.ReadLine(),out double km);
                if (validaResposta && km > 0)
                {
                    this.Quilometragem = km;
                    break;
                }
                else
                {
                    Console.WriteLine("QUILOMETRAGEM INVALIDA");
                    
                }
                
            }
        }
        // Método AdicionarItemVistoriado(string nome, string status);
        public void AdicionarItemVistoriado(string nome)
        {
            VistoriasRealizadas.Add(new ItemVIstoria(nome));
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return new List<string>
            {
                 "Nível de Óleo do Motor",
                 "Bateria e Sistema Elétrico",
                 "Documentação Regularizada"
            };
        }

    };

}