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