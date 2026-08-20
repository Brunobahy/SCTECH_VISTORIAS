namespace AutoCheck.ConsoleApp.models
{
    public class Relatorio : Veiculo
    {
        public string Tipo { get; set; }
        public List<string> atributosEspecificos { get; set; } = new List<string>();
        public List<string> itensRegular { get; set; } = new List<string>();
        public List<string> itensRuim { get; set; } = new List<string>();
        public int totalPontos { get; set; }
        public int maxPontos { get; set; }
        public double porcentagem { get; set; }

        public Relatorio(Veiculo veiculo) : base(veiculo.Marca, veiculo.Modelo, veiculo.Ano, veiculo.Quilometragem)
        {

        }

        public void exibirRelatorio()
        {
            Console.WriteLine($"""
                -------------------------------------------------------------------
        > DADOS DO VEÍCULO:
        - Tipo: {Tipo}
        - Modelo: {Modelo}
        - Ano: {Ano} | Quilometragem: {Quilometragem:N0} km
        - Atributo Específico: {string.Join(" | ", atributosEspecificos)}

        > AVALIAÇÃO DOS ITENS INSPECIONADOS (5 ITENS):
        """);
        foreach (var item in VistoriasRealizadas)
            {
                if (item.Status == "Bom")
                {
                    totalPontos += 10;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"    [OK] {item.Nome} ---------- Status: {item.Status} (10 pts)");
                    Console.ResetColor();
                }

                else if (item.Status == "Regular")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    totalPontos += 5;
                    itensRegular.Add(item.Nome);
                    Console.WriteLine($"    [ ! ] {item.Nome} ------- Status: {item.Status} (5 pts)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    itensRuim.Add(item.Nome);
                    Console.WriteLine($"    [ X ] {item.Nome} ------- Status: {item.Status} (0 pts)");
                    Console.ResetColor();
                }
            }

        > RESUMO DA PONTUAÇÃO:
        -Pontuação Atingida: 30 de 50 pontos possíveis
        -Percentual de Aprovação: 60,0 %
        -Classificação Final: [APROVADO COM APONTAMENTOS]

        > RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:
        🔴 ITENS CRÍTICOS / REPROVADOS(AÇÃO IMEDIATA):
            -Triângulo de Sinalização: Repor equipamento obrigatório ausente/ danificado.

        🟡 ITENS DE ATENÇÃO(REVISÃO PREVENTIVA):
            -Ar Condicionado Funcional: Realizar higienização e checagem do gás refrigerante.
            -Estepe e Macaco: Calibrar pneu reserva e verificar funcionamento do macaco.

        ------------------------------------------------------------------ -
        """);
        }
    };

}