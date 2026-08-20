namespace AutoCheck.ConsoleApp.models
{
    public class Relatorio : Veiculo
    {
        public string Tipo { get; set; }
        public List<string> atributosEspecificos { get; set; } = new List<string>();
        public List<string> ItensRegular { get; set; } = new List<string>();
        public List<string> ItensRuim { get; set; } = new List<string>();
        public int Pontos { get; set; } = 0;
        public int MaxPontos { get; set; }
        public double porcentagem { get; set; }
        public Dictionary<string, string> Manutencoes { get; set; }

        public Relatorio(Veiculo veiculo) : base(veiculo.Marca, veiculo.Modelo, veiculo.Ano, veiculo.Quilometragem)
        {
            MaxPontos = VistoriasRealizadas.Count * 10;
            Manutencoes = new Dictionary<string, string> {
                { "Estepe e Macaco", "Substituir ou reparar os equipamentos ausentes/danificados." },
        { "Triângulo de Sinalização", "Repor equipamento obrigatório ausente/danificado." },
        { "Ar Condicionado Funcional", "Realizar manutenção no sistema de climatização e verificar funcionamento." },
        { "Tacógrafo", "Verificar, calibrar ou reparar o tacógrafo conforme necessário." },
        { "Sistema de Freios a Ar", "Inspecionar o sistema pneumático e reparar possíveis vazamentos ou falhas." },
        { "Trava e Lona da Caçamba", "Reparar ou substituir trava e lona danificadas, garantindo a correta fixação da carga." },
        { "Kit Transmissão/Corrente", "Ajustar, lubrificar ou substituir componentes desgastados do sistema de transmissão." },
        { "Manetes de Freio/Embreagem", "Regular ou substituir os manetes que apresentarem desgaste ou funcionamento inadequado." },
        { "Pezinho Lateral", "Verificar fixação e substituir o componente caso esteja danificado ou instável." },
        { "Nível de Óleo do Motor", "Completar ou substituir o óleo do motor conforme a necessidade de manutenção." },
        { "Bateria e Sistema Elétrico", "Verificar a bateria, conexões e componentes elétricos, reparando possíveis falhas." },
        { "Documentação Regularizada", "Regularizar documentos vencidos ou pendentes antes da liberação do veículo." }
            }
            ;

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
                    Pontos += 10;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"    [OK] {item.Nome} ---------- Status: {item.Status} (10 pts)");
                    Console.ResetColor();
                }

                else if (item.Status == "Regular")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Pontos += 5;
                    ItensRegular.Add(item.Nome);
                    Console.WriteLine($"    [ ! ] {item.Nome} ------- Status: {item.Status} (5 pts)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ItensRuim.Add(item.Nome);
                    Console.WriteLine($"    [ X ] {item.Nome} ------- Status: {item.Status} (0 pts)");
                    Console.ResetColor();
                }
            }
            porcentagem = (double)Pontos * 100 / MaxPontos;

            Console.WriteLine($"""

        > RESUMO DA PONTUAÇÃO:
            - Pontuação Atingida: {Pontos} de {MaxPontos} pontos possíveis
            - Percentual de Aprovação: {porcentagem:F2}%
        """);
            if (porcentagem >= 90)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("     - Classificação Final: [ APROVADO COM EXCELENCIA ]");
                Console.ResetColor();
            }
            else if (porcentagem >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("     - Classificação Final: [ APROVADO COM APONTAMENTOS ]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     - Classificação Final: [ Reprovado na Vistoria]");
                Console.ResetColor();
            }

            Console.WriteLine($"""

        > RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:

        🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):

        """);
            foreach (var item in ItensRuim)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Manutencoes.ContainsKey(item))
                {
                    Console.WriteLine($"- {item}: {Manutencoes[item]}");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\n🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):\n");

            foreach (var item in ItensRegular)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (Manutencoes.ContainsKey(item))
                {
                    Console.WriteLine($"- {item}: {Manutencoes[item]}");
                }
            }
            Console.ResetColor();

            Console.WriteLine("-------------------------------------------------------------------");

        }
    };

}