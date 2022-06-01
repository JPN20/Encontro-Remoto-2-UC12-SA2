using Curso.Classes;

//Construção do menu.
Console.WriteLine;

CarregarBarraDeProgresso("Carregando", ".", 10, 500,
 ConsoleColor.DarkGreen, ConsoleColor.DarkGray);

string? opcao;

do
{

    Console.Clear();
    Console.WriteLine;

    Console.Write("Insira uma opção: ");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaFisica pf = new PessoaFisica();
            Endereco ender = new Endereco();

            ender.Logradouro = "Rua fulano";
            ender.Numero = "300";
            ender.Complemento = "Condomínio";
            ender.EndComercial = false;

            pf.Nome = "Carly";
            pf.DataNascimento = new DateTime(1996, 06, 25);
            pf.Rendimento = 2880F;
            pf.Endereco = ender;

            Console.Clear();
            Console.WriteLine($"Nome: { pf.Nome }");
            Console.Write($"Logradouro: { pf.Endereco.Logradouro }");
            Console.WriteLine($", { pf.Endereco.Numero } ");
          
           
            string idadeValida = pf.ValidarNascimento() ? "Sim" : "Não";
            Console.WriteLine($"Idade válida: { idadeValida }");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "2":
            PessoaJuridica pj = new PessoaJuridica(
                "Nome 2",
                new Endereco("Rua ciclano", "800", "Prédio", true),
                50000F,
                "68.964.532/1783-23",
                "Pessoa jurídica 2"
            );

            Console.Clear();
            Console.WriteLine(pj);
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nosso sistema!");
            CarregarBarraDeProgresso("Finalizando", "\tbye!", 2, 1000,
             ConsoleColor.Blue, ConsoleColor.White);
            break;

        default:
            Console.Write("Opção inválida!");
            Thread.Sleep(2000);
            break;
    }

} while (opcao != "0");


static void CarregarBarraDeProgresso(string status, string caracter, int repeticoes,
int tempo, ConsoleColor corDeFundo, ConsoleColor corDaFonte)
{
    Console.BackgroundColor = corDeFundo;
    Console.ForegroundColor = corDaFonte;

    Console.Write($"{ status } ");

    for (int i = 0; i < repeticoes; i++)
    {
        Thread.Sleep(tempo);
        Console.Write($"{ caracter }");
    }

    Console.ResetColor();
}
