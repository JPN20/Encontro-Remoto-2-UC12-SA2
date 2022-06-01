# Encontro-Remoto-2-UC12-SA2

# Projeto ClientLab

## Descrição
Sistema desenvolvido para cadastro de Pessoas Físicas e Jurídicas. 

## Funcionalidades
O projeto irá realizar a programação de um sistema de cadastro de clientes customizado (Pessoas Físicas e Jurídicas), atendendo às seguintes características:

- [x] O sistema de clientes deverá guardar os cadastros das Pessoas Físicas e Jurídicas;

- [x] O cadastro das Pessoas Físicas foi criado com os seguintes dados: nome, rendimento, CPF e data de nascimento;

- [x] O cadastro das Pessoas Jurídicas foi criado com os seguintes dados: nome, rendimento, CNPJ e razão social;

- [x] Ambos devem possuir um endereço e determinar se é comercial ou residencial;

- [x] O sistema não permitirá o cadastro de uma Pessoa com o CPF ou CNPJ que já foram armazenados anteriormente.

- [x] O sistema precisa guardar os registros em arquivos de extensão ".txt".

! __Em tempo__: 

Neste projeto, os dados são armazenados em arquivos de extensão ".txt". 

No início, o objetivo desse projeto era cadastrar e listar as pessoas, tanto Físicas quanto Jurídicas. Com o objetivo de aprendizagem , antes da criação do sistema, foram pensadas em algumas melhorias que poderiam se utilizadas no projeto. Por causa disso, o sistema também irá permitir que o usuário realize as seguintes tarefas:

- [x] A atualização de Pessoas Físicas ou Jurídicas;

- [x] A busca por uma Pessoa Física ou Jurídica;

- [x] A remoção de uma Pessoa Física ou Jurídica;

- [x] A remoção de todas as Pessoas ( Físicas ou Jurídicas );


## Tecnologias utilizadas

-   [Linguagem de desenvolvimento C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
-   [.NET 6.0](https://dotnet.microsoft.com/en-us/download)
-   [Visual Studio Code](https://code.visualstudio.com/download)   

## Organização do projeto

Foi utilizado o paradigma padrão de _programação orientada a objetos_, onde as classes representam uma abstração do mundo real. Para isso, utilizamos conceitos de herança. As classes utilizadas foram : Pessoa (classe-pai), Pessoa Física e Pessoa Jurídica(classes-filhas) e a classe Endereço, que está conectada com a classe Pessoa. Além disso, criamos as interfaces relacionadas.

## Pré-requisitos da instalação

É preciso que o DOTNET (.NET) runtime versão atual 6.0 ou superior seja instalado para executar a aplicação pelo terminal do Windows. Acesse o site:
https://dotnet.microsoft.com/en-us/download

Caso ocorra alguma atualização no link de acesso do .NET acima, acesse o portal principal: 
https://dotnet.microsoft.com/en-us/ e clicar na aba downloads.

Instruções e detalhes para a instalação no Windows , podem ser acessadas em :
https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=net60

## Execução da aplicação

A aplicação foi desenvolvida utilizando o Sistema Operacional Windows 10. Para executar a aplicação :

1-Faça um clone do projeto na sua máquina :

```
git clone (https://github.com/JPN20/Encontro-Remoto-2-UC12-SA2)
```
Ou se preferir, faça o download do conteúdo, clicando no botão Code > Download Zip. Logo depois, faça sua descompactação.

2-Acesse o diretório contendo um dos projetos pelo _terminal do prompt de comando do Windows_:

- _Projeto Encontro-Remoto-2-UC12-SA2:_
 
``` 
cd https://github.com/JPN20/Encontro-Remoto-2-UC12-SA2
```

__OU__

- _Projeto Encontro remoto 8:_

```
cd https://github.com/JPN20/Encontro-Remoto-2-UC12-SA2
```  

3-Em seguida, execute a aplicação: 
```
dotnet run
```

Após a instalação , um ícone da aplicação ClientLab será criado na área de trabalho do Windows.

## Erros comuns

- A instalação da versão incorreta do .NET para execução da aplicação.

- Acesso ao diretório incorreto para execução da aplicação pelo terminal do Windows.

## Contribuidores

Aluno SENAI-SP : João Pedro Neves Guerreiro

-----------------------------------------

<h4>Curso de Qualificação Desenvolvedor FullStack - Módulo BackEnd SENAI-SP.</h4>
