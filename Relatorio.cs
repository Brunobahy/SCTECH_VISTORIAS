using AutoCheck.ConsoleApp.models;


Dictionary<string, string> manutencoes = new Dictionary<string, string>
    {
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
    };



void RelatoriaVistorias(List<Veiculo> veiculosVistoriados)
{


    if (veiculosVistoriados.Count < 1)
    {
        Console.WriteLine("Nenhuma vistoria realizada até o momento");
        return;
    }
    Console.WriteLine("===================================================================");
    Console.WriteLine("             VISTORIA .NET - MOTOR DE VISTORIA                    ");
    Console.WriteLine("===================================================================");

    int index = 0;
    foreach (Veiculo veiculoAtual in veiculosVistoriados)
    {
        index++;

        Console.WriteLine($"""

        [{index}/{veiculosVistoriados.Count}] PROCESSANDO VISTORIA
        -------------------------------------------------------------------
        > DADOS DO VEÍCULO:
        - Tipo: {veiculoAtual.GetType().Name}
        - Modelo: {veiculoAtual.Modelo}
        - Ano: {veiculoAtual.Ano} | Quilometragem: {veiculoAtual.Quilometragem:N0} km
        """);

        if (veiculoAtual is Carro carro)
        {
            Console.WriteLine($"- Atributo Específico: {carro.QuantidadePortas} Portas");

        }
        else if (veiculoAtual is Moto moto)
        {
            Console.WriteLine($"- Atributo Específico: {moto.Cilindradas} cc");

        }
        else if (veiculoAtual is Caminhao caminhao)
        {
            Console.WriteLine($"- Atributo Específico: Capacidade de carga:{caminhao.CapacidadeCargaToneladas} T | {caminhao.QuantidadeEixos} Eixos");

        }

        Console.WriteLine($"\n> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculoAtual.VistoriasRealizadas.Count} ITENS):");

        int totalPontos = 0;
        int maxPontos = veiculoAtual.VistoriasRealizadas.Count * 10;
        List<string> itensRegular = new List<string>();
        List<string> itensRuim = new List<string>();
        foreach (var item in veiculoAtual.VistoriasRealizadas)
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

        double porcentagem = (double)totalPontos * 100 / maxPontos;
        Console.WriteLine($"""

        > RESUMO DA PONTUAÇÃO:
            - Pontuação Atingida: {totalPontos} de {maxPontos} pontos possíveis
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
        foreach (var item in itensRuim)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (manutencoes.ContainsKey(item))
            {
                Console.WriteLine($"- {item}: {manutencoes[item]}");
            }
        }
        Console.ResetColor();
        Console.WriteLine("\n🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):\n");

        foreach (var item in itensRegular)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (manutencoes.ContainsKey(item))
            {
                Console.WriteLine($"- {item}: {manutencoes[item]}");
            }
        }
        Console.ResetColor();

        Console.WriteLine("-------------------------------------------------------------------");
        Console.Write("Aperte enter para passar: ");
        Console.ReadLine();
    }
}