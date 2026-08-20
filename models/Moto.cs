using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class Moto : Veiculo
    {
        public int Cilindradas { get; set; }

        public Moto() : base()
        {
            while (true)
            {
                Console.Write("Quantidade de CILINDRADAS: ");
                bool validaResposta = int.TryParse(Console.ReadLine(), out int cilindradas);
                if (validaResposta && cilindradas > 0)
                {
                    this.Cilindradas = cilindradas;
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
                "Kit Transmissão/Corrente", "Manetes de Freio/Embreagem", "Pezinho Lateral"
            });
            return checklist;
        }
        
    }
}