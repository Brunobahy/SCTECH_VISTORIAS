namespace AutoCheck.ConsoleApp.models
{
    public class Cadastro
    {
        public static List<Veiculo> VeiculosVistoriados { get; set; } =[];
        public static void RealizarCadastro()
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
                        VeiculosVistoriados.Add(new Carro());
                        break;
                    case "2":
                        Console.WriteLine("Cadastrar Nova MOTO:");
                        VeiculosVistoriados.Add(new Moto());
                        break;
                    case "3":
                        Console.WriteLine("Cadastrar Novo CAMINHÃO:");
                        VeiculosVistoriados.Add(new Caminhao());
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
    }
}