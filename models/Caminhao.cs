using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; set; }
        public double CapacidadeCargaToneladas { get; set; }

        public Caminhao(
            string marca,
            string modelo,
            int ano, double km,
            int quantidadeeixos,
            int capacidadecargatonelada)
            : base(marca, modelo, ano, km)
        {
            this.QuantidadeEixos = quantidadeeixos;
            this.CapacidadeCargaToneladas = capacidadecargatonelada;
        }
        public override List<string> ObterChecklistObrigatorio()
        {
            return new List<string>
           {
               "Tacógrafo", "Sistema de Freios a Ar", "Trava e Lona da Caçamba"
           };
        }

    }
}