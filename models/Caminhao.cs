using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; set; }
        public double CapacidadeCargaToneladas { get; set; }

        public Caminhao(): base()
        {
            while (true)
            {
                Console.Write("Quantidade de EIXOS: ");
                bool validaQuantidade = int.TryParse(Console.ReadLine(),out int qtdEixo);
                if(validaQuantidade && qtdEixo > 1)
                {
                    this.QuantidadeEixos = qtdEixo;
                    break;
                }
                else
                {
                    Console.WriteLine("QUANTIDADE INVALIDA");
                }
            }
            while (true)
            {
                Console.Write("Capacidade de Carga em Toneladas: ");
                bool validaQuantidade = int.TryParse(Console.ReadLine(),out int qtdCarga);
                if(validaQuantidade && qtdCarga > 0)
                {
                    this.CapacidadeCargaToneladas = qtdCarga;
                    break;
                }
                else
                {
                    Console.WriteLine("CAPACIDADE INVALIDA");
                }
            }
            foreach (string item in ObterChecklistObrigatorio())
            {
                this.AdicionarItemVistoriado(item);
            }
        }
        public override List<string> ObterChecklistObrigatorio()
        {

           List<string> checklist = base.ObterChecklistObrigatorio();
           
           checklist.AddRange(new List<string>{"Tacógrafo", "Sistema de Freios a Ar", "Trava e Lona da Caçamba"});
           return checklist;

        }

    }
}