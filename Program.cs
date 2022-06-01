using Curso.Classes;

CarregarBoasVindas();

ExecutarOpcaoMenu
(
     () => Menu("Escolha uma das opções abaixo:",
                "Pessoa Física",
                "Pessoa Jurídica",
                "Sair"
                ),
     () => Menu("O que deseja fazer? ",
                "Cadastrar Pessoa Física",
                "Listar Pessoas Físicas",
                "Voltar"
                ),
     () => Menu("O que deseja fazer? ",
               "Cadastrar Pessoa Jurídica",
               "Listar Pessoas Jurídicas",
               "Voltar"
               )
);


static void CarregarBoasVindas()
{
    Console.Clear();
    Console.WriteLine();

    CarregarBarraDeProgresso("Carregando", ".", 10, 500,
     ConsoleColor.DarkGreen, ConsoleColor.DarkGray);
}


static void ConstruirLinhaMenu(string conteudo)
{
    int qtdSeparadores = 69;
    int linha = Console.CursorTop;
    int coluna = Console.CursorLeft;

    if (conteudo.Length == 1)
        conteudo += new string('=', qtdSeparadores);

    Console.SetCursorPosition(coluna, linha);
    Console.Write("|");
    Console.Write(conteudo);
    Console.SetCursorPosition(coluna + qtdSeparadores + 1, linha);
    Console.Write("|");
    Console.SetCursorPosition(0, linha + 1);
}

static void Menu(string titulo, params string[] itens)
{
    Console.Clear();
    ConstruirLinhaMenu("=");
    ConstruirLinhaMenu("\t" + titulo);
    ConstruirLinhaMenu(Environment.NewLine);

    int i;
    for (i = 0; i < itens.Length - 1; i++)
    {
        ConstruirLinhaMenu($"\t{ i + 1 } - { itens[i] }");
    }

    ConstruirLinhaMenu(Environment.NewLine);
    ConstruirLinhaMenu($"\t0 - { itens[i]}");
    ConstruirLinhaMenu("=");
}


static string? EscolherOpcao()
{
    Console.Write("\tInsira uma opção: ");
    return Console.ReadLine();
}

static void ExecutarOpcaoMenu(Action menu, Action subMenuPf, Action subMenuPj)
{
    string? opcao, opcaoPf, opcaoPj;
    var pfList = new List<PessoaFisica>();
    var pjList = new List<PessoaJuridica>();
 
    do
    {
        Console.Clear();
        menu();
        opcao = EscolherOpcao();
        switch (opcao)
        {
            case "1":
                do
                {
                    Console.Clear();
                    subMenuPf();
                    opcaoPf = EscolherOpcao();
                    switch (opcaoPf)
                    {
                        case "1":
                            Console.Clear();
                            pfList.Add(EntrarDadosPessoaFisica());
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tCadastro com sucesso!", 
                            ConsoleColor.DarkGreen);
                            Pausar();
                            break;
                        case "2":
                            Console.Clear();
                            Listar(pfList);
                            break;
                        case "0":
                            Console.Clear();
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tVoltando ao menu principal...", 
                            ConsoleColor.DarkYellow);
                            Thread.Sleep(800);
                            break;
                        default:
                            Console.WriteLine("\tOpção inválida");
                            Pausar();
                            break;
                    }

                } while (opcaoPf != "0");
                break;

            case "2":
                do
                {
                    Console.Clear();
                    subMenuPj();
                    opcaoPj = EscolherOpcao();
                    switch (opcaoPj)
                    {
                        case "1":
                            Console.Clear();
                            pjList.Add(EntrarDadosPessoaJuridica());
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tCadastro com sucesso!", 
                            ConsoleColor.DarkGreen);
                            Pausar();
                            break;
                        case "2":
                            Console.Clear();
                            Listar(pjList);
                            break;
                        case "0":
                            Console.Clear();
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tVoltando ao menu principal...", 
                            ConsoleColor.DarkYellow);
                            Thread.Sleep(800);
                            break;
                        default:
                            Console.WriteLine("\tOpção inválida");
                            Pausar();
                            break;
                    }
                } while (opcaoPj != "0");
                break;

            case "0":
                Console.Clear();
                Console.WriteLine();
                ExibirTextoEstilizado("\tObrigado por utilizar nosso sistema! Volte sempre!", 
                ConsoleColor.DarkYellow);
                CarregarBarraDeProgresso("Fechando...", "bye!!", 2, 500, 
                ConsoleColor.Black, ConsoleColor.DarkYellow);
                break;

            default:
                Console.Write("\tOpção inválida!");
                Thread.Sleep(2000);
                break;
        }
    } while (opcao != "0");
}


static Pessoa EntrarDadosPessoa()
{
    string? nome, logradouro, numero, complemento;
    char tipo = ' ';
    float rendimento;
    bool endComercial, valido;

    Console.WriteLine();

    Console.Write("\tInsira o nome: ");
    nome = Console.ReadLine()?.ToUpper();

    Console.Write("\tInsira o logradouro: ");
    logradouro = Console.ReadLine();

    Console.Write("\tInsira o número: ");
    numero = Console.ReadLine();

    Console.Write("\tInsira o complemento: ");
    complemento = Console.ReadLine();

    Console.Write("\tÉ endereço comercial ? (s/n) : ");
    valido = char.TryParse(Console.ReadLine(), out tipo);
    tipo = valido ? Char.ToUpper(tipo) : tipo;

    while (!valido || ((tipo != 'S') && (tipo != 'N')))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\tErro! É endereço comercial ? (s/n) : ");
        Console.ResetColor();
        valido = char.TryParse(Console.ReadLine(), out tipo);
        tipo = valido ? Char.ToUpper(tipo) : tipo;
    }

    endComercial = (tipo == 'S') ? true : false;

    Console.Write("\tInsira o seu rendimento (Ex. X.YYY,ZZ ou XYYY,ZZ) : ");
    valido = float.TryParse(Console.ReadLine(), out rendimento);
    while (!valido)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\tErro! Insira o seu rendimento (Ex. X.YYY,ZZ, ou XYYY,ZZ) :  ");
        Console.ResetColor();
        valido = float.TryParse(Console.ReadLine(), out rendimento);
    }

    Endereco endereco = new Endereco(logradouro, numero, complemento, endComercial);

    Pessoa pessoa = new PessoaFisica();
    pessoa.Nome = nome;
    pessoa.Endereco = endereco;
    pessoa.Rendimento = rendimento;

    return pessoa;

}

static PessoaFisica EntrarDadosPessoaFisica()
{

    Pessoa pessoa = EntrarDadosPessoa();

    var metodoPf = new PessoaFisica();

    bool valido;

    Console.Write("\tInsira o CPF: ");
    string? cpf = Console.ReadLine();

    DateTime dataNascimento;
    Console.Write("\tInsira a data de nascimento (dd/mm/aaaa) : ");

    valido = (DateTime.TryParse(Console.ReadLine(), out dataNascimento)) &&
    (metodoPf.ValidarNascimento(dataNascimento));

    while (!valido)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\tData inválida. Insira a data de nascimento (dd/mm/aaaa) : ");
        Console.ResetColor();
        valido = (DateTime.TryParse(Console.ReadLine(), out dataNascimento)) &&
        (metodoPf.ValidarNascimento(dataNascimento));
    }

    PessoaFisica pf = new PessoaFisica(pessoa, cpf, dataNascimento);

    return pf;
}

static PessoaJuridica EntrarDadosPessoaJuridica()
{

    Pessoa pessoa = EntrarDadosPessoa();
    
    var metodoPj = new PessoaJuridica();

    Console.Write("\tInsira o CNPJ: ");
    string? cnpj = Console.ReadLine();

    while (!metodoPj.ValidarCnpj(cnpj))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\tCNPJ inválido! Insira o CNPJ: ");
        Console.ResetColor();
        cnpj = Console.ReadLine();
    }

    Console.Write("\tInsira a Razão Social: ");
    string? razaoSocial = Console.ReadLine();

    PessoaJuridica pj = new PessoaJuridica(pessoa, cnpj, razaoSocial);

    return pj;

}

static void Listar<T>(List<T> lista) where T : Pessoa
{
    List<T> listaOrdenada = lista.OrderBy(x => x.Nome).ToList();

    String tipoPessoa = typeof(T).Equals(typeof(PessoaFisica)) ? "Física(s)" : "Jurídica(s)";

    int i = 1;
    if (listaOrdenada.Count > 0)
    {
        foreach (var pessoa in listaOrdenada)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("\t" + pessoa);
            Console.WriteLine("----------------------------------------------------------------");
            ExibirTextoEstilizado($"\t{i} de { lista.Count } Pessoa(s) { tipoPessoa } cadastrada(s)", ConsoleColor.DarkCyan);
            i++;
            Pausar();
            Console.Clear();
        }
    }
    else
    {
        Console.WriteLine();
        ExibirTextoEstilizado($"\tNão há Pessoas(s) { tipoPessoa } cadastrada(s)",
         ConsoleColor.DarkYellow);
        Pausar();
    }
}


static void ExibirTextoEstilizado(string texto, ConsoleColor corDaFonte)
{
   Console.ForegroundColor = corDaFonte;
   Console.WriteLine(texto);
   Console.ResetColor();
}

static void Pausar()
{
    Console.WriteLine();
    ExibirTextoEstilizado("\tPressione qualquer tecla para continuar...",
     ConsoleColor.DarkYellow);
    Console.ReadKey();
    Console.Clear();
}

static void CarregarBarraDeProgresso(string status, string caracteres, int repeticoes,
int tempo, ConsoleColor corDeFundo, ConsoleColor corDaFonte)
{
    Console.BackgroundColor = corDeFundo;
    Console.ForegroundColor = corDaFonte;

    Console.Write($"\t{ status } ");

    for (int i = 0; i < repeticoes; i++)
    {
        Thread.Sleep(tempo);
        Console.Write($"{ caracteres }");
    }

    Console.ResetColor();
}
