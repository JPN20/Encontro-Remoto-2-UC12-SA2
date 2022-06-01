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
                "Editar Pessoa Física",
                "Listar Pessoas Físicas",
                "Buscar Pessoa Física",
                "Remover Pessoa Física",
                "Remover Todas as Pessoas Físicas",
                "Voltar"
                ),
     () => Menu("O que deseja fazer? ",
               "Cadastrar Pessoa Jurídica",
               "Editar Pessoa Jurídica",
               "Listar Pessoas Jurídicas",
               "Buscar Pessoa Jurídica",
               "Remover Pessoa Jurídica",
               "Remover Todas as Pessoas Jurídicas",
               "Voltar"
               )
);


static void CarregarBoasVindas()
{
    Console.Clear();
    Console.WriteLine();

    CarregarBarraDeProgresso("Carregando", ".", 10, 500,
     ConsoleColor.DarkBlue, ConsoleColor.DarkYellow);
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
    return Console.ReadLine()?.Trim();
}

static void ExecutarOpcaoMenu(Action menu, Action subMenuPf, Action subMenuPj)
{
    string? opcao, opcaoPf, opcaoPj;
    var metodoPf = new PessoaFisica();
    var metodoPj = new PessoaJuridica();

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
                            PessoaFisica novaPf = EntrarDadosPessoaFisica();
                            metodoPf.Inserir(novaPf);
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tCadastro com sucesso!",
                            ConsoleColor.DarkGreen);
                            Pausar();
                            break;
                        case "2":
                            Console.Clear();
                            EditarPessoaFisica();
                            break;
                        case "3":
                            Console.Clear();
                            metodoPf = new PessoaFisica();
                            List<PessoaFisica> pfList = metodoPf.Ler();
                            Listar(pfList);
                            break;
                        case "4":
                            Console.Clear();
                            BuscarPessoaFisica();
                            break;
                        case "5":
                            Console.Clear();
                            RemoverPessoaFisica();
                            break;
                        case "6":
                            Console.Clear();
                            RemoverTodasPessoasFisicas();
                            break;
                        case "7":
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
                            PessoaJuridica novaPj = EntrarDadosPessoaJuridica();
                            metodoPj.Inserir(novaPj);
                            Console.WriteLine();
                            ExibirTextoEstilizado("\tCadastro com sucesso!",
                            ConsoleColor.DarkGreen);
                            Pausar();
                            break;
                        case "2":
                            Console.Clear();
                            EditarPessoaJuridica();
                            break;
                        case "3":
                            Console.Clear();
                            metodoPj = new PessoaJuridica();
                            List<PessoaJuridica> pjList = metodoPj.Ler();
                            Listar(pjList);
                            break;
                        case "4":
                            Console.Clear();
                            BuscarPessoaJuridica();
                            break;
                        case "5":
                            Console.Clear();
                            RemoverPessoaJuridica();
                            break;
                        case "6":
                            Console.Clear();
                            RemoverTodasPessoasJuridicas();
                            break;
                        case "7":
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

            case "3":
                Console.Clear();
                Console.WriteLine();
                ExibirTextoEstilizado("\tObrigado por utilizar nosso sistema! Volte sempre!",
                ConsoleColor.DarkYellow);
                CarregarBarraDeProgresso("Fechando...", "bye!!", 2, 500,
                ConsoleColor.Black, ConsoleColor.DarkYellow);
                Thread.Sleep(2000);
                break;

            default:
                Console.Write("\tOpção inválida!");
                Thread.Sleep(2000);
                break;
        }
    } while (opcao != "3");
}


static Pessoa EntrarDadosPessoa()
{
    string? nome, logradouro, numero, complemento;
    char tipo = ' ';
    float rendimento;
    bool endComercial, valido;

    Console.WriteLine();

    Console.Write("\n\tInsira o nome: ");
    nome = Console.ReadLine()?.ToUpper().Trim();

    Console.Write("\n\tInsira o logradouro: ");
    logradouro = Console.ReadLine()?.Trim();

    Console.Write("\n\tInsira o número: ");
    numero = Console.ReadLine()?.Trim();

    Console.Write("\n\tInsira o complemento: ");
    complemento = Console.ReadLine()?.Trim();

    Console.Write("\n\tÉ endereço comercial ? (s/n) : ");
    valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
    tipo = valido ? Char.ToUpper(tipo) : tipo;

    while (!valido || ((tipo != 'S') && (tipo != 'N')))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\n\tErro! É endereço comercial ? (s/n) : ");
        Console.ResetColor();
        valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
        tipo = valido ? Char.ToUpper(tipo) : tipo;
    }

    endComercial = (tipo == 'S') ? true : false;

    Console.Write("\n\tInsira o seu rendimento (Ex. X.YYY,ZZ ou XYYY,ZZ) : ");
    valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
    while (!valido)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\n\tErro! Insira o seu rendimento (Ex. X.YYY,ZZ, ou XYYY,ZZ) :  ");
        Console.ResetColor();
        valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
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
    bool v1 = false, v2 = false;

    Console.Write("\n\tInsira o CPF: ");
    string? cpf = Console.ReadLine()?.Trim();

    while ((v1 = !metodoPf.ValidarCpf(cpf)) || (v2 = metodoPf.ExisteCpf(cpf)))
    {
        string mensagem = "";

        if (v1)
            mensagem = "CPF inválido!";
        else if (v2)
            mensagem = "CPF já existe!";


        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"\n\t{ mensagem } Insira o CPF: ");
        Console.ResetColor();
        cpf = Console.ReadLine()?.Trim();

    }

    cpf = metodoPf.RemoveMascaraCpf(cpf);

    DateTime dataNascimento;
    Console.Write("\n\tInsira a data de nascimento (dd/mm/aaaa) : ");

    valido = (DateTime.TryParse(Console.ReadLine()?.Trim(), out dataNascimento)) &&
    (metodoPf.ValidarNascimento(dataNascimento));

    while (!valido)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\n\tData inválida. Insira a data de nascimento (dd/mm/aaaa) : ");
        Console.ResetColor();
        valido = (DateTime.TryParse(Console.ReadLine()?.Trim(), out dataNascimento)) &&
        (metodoPf.ValidarNascimento(dataNascimento));
    }

    PessoaFisica pf = new PessoaFisica(pessoa, cpf, dataNascimento);

    return pf;
}

static PessoaJuridica EntrarDadosPessoaJuridica()
{

    Pessoa pessoa = EntrarDadosPessoa();

    var metodoPj = new PessoaJuridica();
    bool v1 = false, v2 = false;

    Console.Write("\n\tInsira o CNPJ: ");
    string? cnpj = Console.ReadLine()?.Trim();

    while ((v1 = !metodoPj.ValidarCnpj(cnpj)) || (v2 = metodoPj.ExisteCnpj(cnpj)))
    {
        string mensagem = "";
        if (v1)
            mensagem = "CNPJ inválido!";
        else if (v2)
            mensagem = "CNPJ já existe!";

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"\n\t{ mensagem }.Insira o CNPJ: ");
        Console.ResetColor();
        cnpj = Console.ReadLine()?.Trim();
    }

    cnpj = metodoPj.RemoveMascaraCnpj(cnpj);

    Console.Write("\n\tInsira a Razão Social: ");
    string? razaoSocial = Console.ReadLine()?.Trim();

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

static void BuscarPessoaFisica()
{
    PessoaFisica? metodoPf = new PessoaFisica();

    if (metodoPf.TotalPessoasFisicas() > 0)
    {
        Console.Write("\n\tInsira o CPF da Pessoa Física que deseja buscar : ");
        string? cpf = Console.ReadLine()?.Trim();

        cpf = metodoPf.RemoveMascaraCpf(cpf);

        PessoaFisica? pf = metodoPf.BuscarPessoaFisica(cpf);

        if (pf != null)
        {
            Console.WriteLine($"\n\tPessoa Física encontrada !");
            Console.WriteLine($"------------------------------------------");
            Console.WriteLine($"\t{ pf }");
            Console.WriteLine($"------------------------------------------");
        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Física não encontrada!",
             ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Físicas cadastradas!",
        ConsoleColor.DarkYellow);
    }

    Pausar();
}

static void BuscarPessoaJuridica()
{
    PessoaJuridica? metodoPj = new PessoaJuridica();

    if (metodoPj.TotalPessoasJuridicas() > 0)
    {
        Console.Write("\n\tInsira o CNPJ da Pessoa Jurídica que deseja buscar : ");
        string? cnpj = Console.ReadLine()?.Trim();

        cnpj = metodoPj.RemoveMascaraCnpj(cnpj);

        PessoaJuridica? pj = metodoPj.BuscarPessoaJuridica(cnpj);

        if (pj != null)
        {
            Console.WriteLine($"\n\tPessoa Jurídica encontrada !");
            Console.WriteLine($"------------------------------------------");
            Console.WriteLine($"\t{ pj }");
            Console.WriteLine($"------------------------------------------");
        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Jurídica não encontrada!",
            ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Jurídicas cadastradas!",
       ConsoleColor.DarkYellow);
    }

    Pausar();

}

static void RemoverPessoaFisica()
{
    PessoaFisica metodoPf = new PessoaFisica();

    if (metodoPf.TotalPessoasFisicas() > 0)
    {
        Console.Write($"\n\tInsira o CPF da Pessoa Física que deseja excluir: ");

        string? cpf = Console.ReadLine()?.Trim();

        cpf = metodoPf.RemoveMascaraCpf(cpf);

        if (metodoPf.ExcluirPessoaFisica(cpf))
        {
            ExibirTextoEstilizado($"\n\tPessoa Física com CPF { cpf } excluída com sucesso! ",
            ConsoleColor.Cyan);
        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Física não encontrada!",
            ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Físicas cadastradas!",
        ConsoleColor.DarkYellow);
    }

    Pausar();
}

static void RemoverPessoaJuridica()
{
    PessoaJuridica metodoPj = new PessoaJuridica();

    if (metodoPj.TotalPessoasJuridicas() > 0)
    {
        Console.Write($"\n\tInsira o CNPJ da Pessoa Jurídica que deseja excluir: ");

        string? cnpj = Console.ReadLine()?.Trim();

        cnpj = metodoPj.RemoveMascaraCnpj(cnpj);

        if (metodoPj.ExcluirPessoaJuridica(cnpj))
        {
            ExibirTextoEstilizado($"\n\tPessoa Jurídica com CNPJ { cnpj } excluída com sucesso! ",
             ConsoleColor.Cyan);
        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Jurídica não encontrada!",
             ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Jurídicas cadastradas!",
      ConsoleColor.DarkYellow);
    }

    Pausar();
}

static void RemoverTodasPessoasFisicas()
{
    string? opcao;
    bool valido;
    int resposta;
    PessoaFisica metodoPf = new PessoaFisica();

    if (metodoPf.TotalPessoasFisicas() > 0)
    {
        Console.Write($"\n\tTem certeza de que deseja excluir TODAS as Pessoas Físicas do cadastro? 1-Sim/2-Não: ");
        opcao = Console.ReadLine()?.Trim();

        valido = int.TryParse(opcao, out resposta);
        while (!valido || (resposta < 1 || resposta > 2))
        {
            Console.Write($"\n\tTem certeza de que deseja excluir TODAS as Pessoas Físicas do cadastro? 1-Sim/2-Não: ");
            opcao = Console.ReadLine()?.Trim();
            valido = int.TryParse(opcao, out resposta);
        }

        if (resposta == 1)
        {
            metodoPf.ExcluirTodasPessoasFisicas();
            ExibirTextoEstilizado($"\n\tTodas as Pessoas  Físicas foram excluídas!",
              ConsoleColor.Cyan);
        }
        else
        {
            ExibirTextoEstilizado($"\n\tOk! Você optou por NÃO excluir todas as Pessoas Físicas!",
             ConsoleColor.Red);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Físicas a serem excluídas!",
        ConsoleColor.DarkYellow);
    }

    Pausar();

}

static void RemoverTodasPessoasJuridicas()
{
    string? opcao;
    bool valido;
    int resposta;
    PessoaJuridica metodoPj = new PessoaJuridica();

    if (metodoPj.TotalPessoasJuridicas() > 0)
    {
        Console.Write($"\n\tTem certeza de que deseja excluir TODAS as Pessoas Jurídicas do cadastro? 1-Sim/2-Não: ");
        opcao = Console.ReadLine()?.Trim();

        valido = int.TryParse(opcao, out resposta);
        while (!valido || (resposta < 1 || resposta > 2))
        {
            Console.Write($"\n\tTem certeza de que deseja excluir TODAS as Pessoas Jurídicas do cadastro? 1-Sim/2-Não: ");
            opcao = Console.ReadLine()?.Trim();
            valido = int.TryParse(opcao, out resposta);
        }

        if (resposta == 1)
        {
            metodoPj.ExcluirTodasPessoasJuridicas();
            ExibirTextoEstilizado($"\n\tTodas as Pessoas Jurídicas foram excluídas!",
            ConsoleColor.Cyan);
        }
        else
        {
            ExibirTextoEstilizado($"\n\tOk! Você optou por NÃO excluir todas as Pessoas Jurídicas!",
             ConsoleColor.Red);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Jurídicas a serem excluídas!",
        ConsoleColor.DarkYellow);
    }

    Pausar();
}

static void EditarPessoaFisica()
{
    PessoaFisica metodoPf = new PessoaFisica();

    if (metodoPf.TotalPessoasFisicas() > 0)
    {
        Console.Write($"\n\tInsira o CPF da Pessoa Física que deseja editar: ");
        string? cpf = Console.ReadLine()?.Trim();
        cpf = metodoPf.RemoveMascaraCpf(cpf);

        PessoaFisica? pf = metodoPf.BuscarPessoaFisica(cpf);

        if (pf != null)
        {
            string? opcao;
            bool valido, endComercial;
            char tipo;
            float rendimento;

            Endereco ender = new Endereco();
            ender.Logradouro = pf.Endereco?.Logradouro;
            ender.Numero = pf.Endereco?.Numero;
            ender.Complemento = pf.Endereco?.Complemento;
            ender.EndComercial = pf.Endereco?.EndComercial;

            Console.WriteLine($"\n\tPessoa Física: { pf?.Nome }");

            Dictionary<string, string?> itensMarcacao = new Dictionary<string, string?>();

            Console.WriteLine($"\n\tMarque com um 'x' o(s) campo(s) que deseja editar e tecle ENTER" +
            "\n\tOU deixe o campo em branco e tecle ENTER para ignorar.");

            Console.Write($"\n\tNome: ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("nome", opcao);

            Console.Write($"\tLogradouro : ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("logradouro", opcao);

            Console.Write($"\tNúmero : ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("numero", opcao);

            Console.Write($"\tComplemento : ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("complemento", opcao);

            Console.Write($"\tEndereço comercial : ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("endComercial", opcao);

            Console.Write($"\tRendimento : ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("rendimento", opcao);

            Console.Write($"\tData de nascimento: ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("dataNascimento", opcao);

            pf.Cpf = cpf;

            Console.WriteLine($"\n\t----------------------------------------");

            bool temAtualizacao = itensMarcacao.Any(i => i.Value == "x");

            if (temAtualizacao)
            {
                Console.WriteLine("\n\tAgora atualize o(s) campo(s): ");

                foreach (KeyValuePair<string, string?> item in itensMarcacao)
                {
                    if (item.Value == "x")
                    {
                        if (item.Key == "nome")
                        {
                            Console.Write($"\n\n\tInsira o nome: ");
                            pf.Nome = Console.ReadLine()?.ToUpper().Trim();
                        }
                        else if (item.Key == "logradouro")
                        {
                            Console.Write($"\n\tInsira o logradouro: ");
                            ender.Logradouro = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "numero")
                        {
                            Console.Write($"\n\tInsira o número: ");
                            ender.Numero = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "complemento")
                        {
                            Console.Write($"\n\tInsira o complemento: ");
                            ender.Complemento = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "endComercial")
                        {
                            Console.Write("\n\tÉ endereço comercial ? (s/n) : ");
                            valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
                            tipo = valido ? Char.ToUpper(tipo) : tipo;

                            while (!valido || ((tipo != 'S') && (tipo != 'N')))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\tErro! É endereço comercial ? (s/n) : ");
                                Console.ResetColor();
                                valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
                                tipo = valido ? Char.ToUpper(tipo) : tipo;
                            }

                            endComercial = (tipo == 'S') ? true : false;
                            ender.EndComercial = endComercial;
                        }
                        else if (item.Key == "rendimento")
                        {
                            Console.Write("\n\tInsira o seu rendimento (Ex. X.YYY,ZZ ou XYYY,ZZ) : ");
                            valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
                            while (!valido)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\tErro! Insira o seu rendimento (Ex. X.YYY,ZZ, ou XYYY,ZZ) :  ");
                                Console.ResetColor();
                                valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
                            }
                            pf.Rendimento = rendimento;
                        }
                        else if (item.Key == "dataNascimento")
                        {
                            DateTime dataNascimento;
                            Console.Write("\n\tInsira a data de nascimento (dd/mm/aaaa) : ");

                            valido = (DateTime.TryParse(Console.ReadLine()?.Trim(), out dataNascimento)) &&
                            (metodoPf.ValidarNascimento(dataNascimento));

                            while (!valido)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\tData inválida. Insira a data de nascimento (dd/mm/aaaa) : ");
                                Console.ResetColor();
                                valido = (DateTime.TryParse(Console.ReadLine()?.Trim(), out dataNascimento)) &&
                                (metodoPf.ValidarNascimento(dataNascimento));
                            }

                            pf.DataNascimento = dataNascimento;
                        }
                    }
                }

                pf.Endereco = ender;
                metodoPf.EditarPessoaFisica(pf);
                ExibirTextoEstilizado($"\n\tEditado com sucesso!", ConsoleColor.Cyan);
            }
            else
            {
                ExibirTextoEstilizado($"\n\tNenhum campo foi atualizado!", ConsoleColor.Magenta);
            }
        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Física não encontrada!", ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Físicas cadastradas!", ConsoleColor.DarkYellow);
    }

    Pausar();
}

static void EditarPessoaJuridica()
{
    PessoaJuridica metodoPj = new PessoaJuridica();

    if (metodoPj.TotalPessoasJuridicas() > 0)
    {
        Console.Write($"\n\tInsira o CNPJ da Pessoa Jurídica que deseja editar: ");
        string? cnpj = Console.ReadLine()?.Trim();
        cnpj = metodoPj.RemoveMascaraCnpj(cnpj);

        PessoaJuridica? pj = metodoPj.BuscarPessoaJuridica(cnpj);

        if (pj != null)
        {
            string? opcao;
            bool valido, endComercial;
            char tipo;
            float rendimento;

            Endereco ender = new Endereco();
            ender.Logradouro = pj.Endereco?.Logradouro;
            ender.Numero = pj.Endereco?.Numero;
            ender.Complemento = pj.Endereco?.Complemento;
            ender.EndComercial = pj.Endereco?.EndComercial;

            Console.WriteLine($"\n\tPessoa Jurídica: { pj?.Nome }");

            Dictionary<string, string?> itensMarcacao = new Dictionary<string, string?>();

            Console.WriteLine($"\n\tMarque com um 'x' o(s) campo(s) que deseja editar e tecle ENTER" +
           "\n\tOU deixe o campo em branco e tecle ENTER para ignorar.");

            Console.Write($"\n\tNome: ");
            opcao = Console.ReadLine()?.ToLower().Trim();
            itensMarcacao?.Add("nome", opcao);

            Console.Write($"\tLogradouro : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("logradouro", opcao);

            Console.Write($"\tNúmero : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("numero", opcao);

            Console.Write($"\tComplemento : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("complemento", opcao);

            Console.Write($"\tEndereço comercial : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("endComercial", opcao);

            Console.Write($"\tRendimento : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("rendimento", opcao);

            Console.Write($"\tRazao Social : ");
            opcao = Console.ReadLine()?.ToLower()?.Trim();
            itensMarcacao?.Add("razaoSocial", opcao);

            pj.Cnpj = cnpj;

            Console.WriteLine($"\n\t----------------------------------------");

            bool temAtualizacao = itensMarcacao.Any(i => i.Value == "x");

            if (temAtualizacao)
            {
                Console.WriteLine("\n\tAgora atualize o(s) campo(s): ");

                foreach (KeyValuePair<string, string?> item in itensMarcacao)
                {
                    if (item.Value == "x")
                    {
                        if (item.Key == "nome")
                        {
                            Console.Write($"\n\n\tInsira o nome: ");
                            pj.Nome = Console.ReadLine()?.ToUpper().Trim();
                        }
                        else if (item.Key == "logradouro")
                        {
                            Console.Write($"\n\tInsira o logradouro: ");
                            ender.Logradouro = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "numero")
                        {
                            Console.Write($"\n\tInsira o número: ");
                            ender.Numero = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "complemento")
                        {
                            Console.Write($"\n\tInsira o complemento: ");
                            ender.Complemento = Console.ReadLine()?.Trim();
                        }
                        else if (item.Key == "endComercial")
                        {
                            Console.Write("\n\tÉ endereço comercial ? (s/n) : ");
                            valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
                            tipo = valido ? Char.ToUpper(tipo) : tipo;

                            while (!valido || ((tipo != 'S') && (tipo != 'N')))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\tErro! É endereço comercial ? (s/n) : ");
                                Console.ResetColor();
                                valido = char.TryParse(Console.ReadLine()?.Trim(), out tipo);
                                tipo = valido ? Char.ToUpper(tipo) : tipo;
                            }

                            endComercial = (tipo == 'S') ? true : false;
                            ender.EndComercial = endComercial;
                        }
                        else if (item.Key == "rendimento")
                        {
                            Console.Write("\n\tInsira o seu rendimento (Ex. X.YYY,ZZ ou XYYY,ZZ) : ");
                            valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
                            while (!valido)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("\n\tErro! Insira o seu rendimento (Ex. X.YYY,ZZ, ou XYYY,ZZ) :  ");
                                Console.ResetColor();
                                valido = float.TryParse(Console.ReadLine()?.Trim(), out rendimento);
                            }
                            pj.Rendimento = rendimento;
                        }
                        else if (item.Key == "razaoSocial")
                        {
                            Console.Write("\n\tInsira a Razão Social: ");
                            string? razaoSocial = Console.ReadLine()?.Trim();
                            pj.RazaoSocial = razaoSocial;
                        }
                    }
                }

                pj.Endereco = ender;
                metodoPj.EditarPessoaJuridica(pj);
                ExibirTextoEstilizado($"\n\tEditado com sucesso!", ConsoleColor.Cyan);
            }
            else
            {
                ExibirTextoEstilizado($"\n\tNenhum campo foi atualizado!", ConsoleColor.Magenta);
            }

        }
        else
        {
            ExibirTextoEstilizado($"\n\tPessoa Jurídica não encontrada!", ConsoleColor.DarkGreen);
        }
    }
    else
    {
        ExibirTextoEstilizado($"\n\tNão há Pessoas Jurídicas cadastradas!", ConsoleColor.DarkYellow);
    }

    Pausar();

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
