using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; set; }

        public Carro(
            string marca,
            string modelo,
            int ano,
            double km,
            int quantidadePortas
        ) : base(marca, modelo, ano, km)
        {
            this.QuantidadePortas = quantidadePortas;
        }
        
        public override List<string> ObterChecklistObrigatorio()
        {
            return new List<string>
            {
                 "Estepe e Macaco", "Triângulo de Sinalização", "Ar Condicionado Funcional"
            };
        }

    }

}

