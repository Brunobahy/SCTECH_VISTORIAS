namespace AutoCheck.ConsoleApp.models
{
    public class Relatorio : Veiculo
    {
        public List<string> atributosEspecificos { get; set; } = new List<string>();
        public List<string> itensRegular { get; set; } = new List<string>();
        public List<string> itensRuim { get; set; } = new List<string>();
        public int totalPontos { get; set; }
        public int maxPontos { get; set; }
        public double porcentagem { get; set; }


        public void exibirRelatorio()
        {

        }
    };

}