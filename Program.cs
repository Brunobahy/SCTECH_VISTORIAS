using AutoCheck.ConsoleApp.models;


bool executar = true;
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
            Cadastro.RealizarCadastro();
            break;

        case "2":
            Console.WriteLine("2 - Exibir Relatório das Vistorias:\n");
            Relatorio.RelatoriaVistorias();
            break;
        default:
            Console.WriteLine($" {escolha} - Opção Invalida");
            break;

    }
    Console.WriteLine("===================================================================\n");


}

