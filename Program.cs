using AutoCheck.ConsoleApp.models;





bool executar = true;
List<Veiculo> veiculosVistoriados = new List<Veiculo>();
Console.WriteLine("===================================================================");
Console.WriteLine("BEM VINDO AO SISTEMA DE VISTORIAS");
Console.WriteLine("===================================================================\n");


while (executar)
{

    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Realizar Nova Vistoria:");
    Console.WriteLine("2 - Exibir Relatório das Vistorias:");
    Console.WriteLine("0 - Sair:\n");

    Console.Write("Sua escolha: ");
    string escolha = Console.ReadLine();

    Console.WriteLine("===================================================================\n");
    switch (escolha)
    {
        case "0":
            Console.WriteLine("0 - Sair");
            executar = false;
            break;

        case "1":
            Console.WriteLine("1 - Realizar Nova Vistoria:");
            RealizarVistoria();
            break;

        case "2":
            Console.WriteLine("2 - Exibir Relatório das Vistorias:\n");
            RelatoriaVistorias();
            break;
        default:
            Console.WriteLine($" {escolha} - Opção Invalida");
            break;

    }
    Console.WriteLine("===================================================================\n");


}


void RealizarVistoria()
{
    bool sair = false;
    Console.WriteLine("===================================================================\n");
    while (!sair)
    {
        Console.WriteLine("Escolha o tipo do Veiculo");
        Console.WriteLine("1) Carro");
        Console.WriteLine("2) Moto");
        Console.WriteLine("3) Caminhão");
        Console.WriteLine("4) Sair");

        Console.WriteLine("");
        Console.Write("Sua escolha: ");
        string escolha = Console.ReadLine();
        Console.WriteLine("");

        switch (escolha)
        {
            case "1":
                Console.WriteLine("Cadastrar Novo CARRO:");
                veiculosVistoriados.Add(new Carro());
                break;
            case "2":
                Console.WriteLine("Cadastrar Nova MOTO:");
                veiculosVistoriados.Add(new Moto());
                break;
            case "3":
                Console.WriteLine("Cadastrar Novo CAMINHÃO:");
                veiculosVistoriados.Add(new Caminhao());
                break;
            case "4":
                sair = true;
                break;
            default:
                Console.WriteLine($" {escolha} - Opção Invalida");
                break;
        }

    }
}



void RelatoriaVistorias()
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