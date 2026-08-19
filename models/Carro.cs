using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; set; }

        public Carro() : base()
        {
            while (true)
            {
                Console.Write("Quantidade de PORTAS: ");
                bool validaResposta = int.TryParse(Console.ReadLine(), out int quantidadePortas);
                if (validaResposta && quantidadePortas > 1)
                {
                    this.QuantidadePortas = quantidadePortas;
                    break;
                }
                else
                {
                    Console.WriteLine("QUANTIDADE INVALIDA");

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
            checklist.AddRange(new List<string>
            {
                 "Estepe e Macaco", "Triângulo de Sinalização", "Ar Condicionado Funcional"
            });

            return checklist;
        }

    }

}

