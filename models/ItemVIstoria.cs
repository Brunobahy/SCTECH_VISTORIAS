using AutoCheck.ConsoleApp.models;

namespace AutoCheck.ConsoleApp.models
{
    public class ItemVIstoria
    {
        public string Nome { get; private set; } ="";
        public string Status { get; private set; }="";

    public ItemVIstoria(string nome)
        {
            DefineNome(nome);
            Console.WriteLine($"Avaliando item: {nome}");
            Console.WriteLine("Digite o Status da vistoria: ");
            Console.WriteLine("1) Bom \n 2) Regular \n 3) Ruim");
            Console.Write("Status: ");
            DefineStatus(Console.ReadLine());

        }

    public void DefineStatus(string respostaStatus)
        {
            bool validaResposta = int.TryParse(respostaStatus,out int alternativa);

            if(!validaResposta || alternativa<1 || alternativa > 3)
            {   
                Console.WriteLine("\nStatus Invalido! \n\n");
                
                Console.WriteLine("Digite o Status da vistoria: ");
                Console.WriteLine(" 1) Bom \n 2) Regular \n 3) Ruim");
                Console.Write("Status: ");
                DefineStatus(Console.ReadLine());
            }
            else
            {
                switch (alternativa)
                {
                    case 1:
                    Status = "Bom";
                    break;
                    case 2:
                    Status = "Regular";
                    break;
                    case 3:
                    Status = "Ruim";
                    break;
                    
                } 
            }
        }

    public void DefineNome(string respostaNome)
    {
        if(respostaNome.Length < 3)
        {
            Console.WriteLine("\nNome Invalido! \n");
            Console.Write("Digite o nome do Item:");
            DefineNome(Console.ReadLine());
            }
            else
            {
                Nome = respostaNome;
            }
    }

    };
}

