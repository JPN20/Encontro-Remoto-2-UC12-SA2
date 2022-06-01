using Curso.Classes;

Endereco endPj1 = new Endereco("Rua fulano", "4009", "Condomínio", true);
PessoaJuridica pj1 = new PessoaJuridica();

pj1.Nome =  "Nome";
pj1.RazaoSocial = "Pessoa jurídica";
pj1.Cnpj = "66.743.394/1996-21";
pj1.Endereco = endPj1;
pj1.Rendimento = 46560F;


Console.WriteLine(@$"
-----------------------------------------------
Pessoa Jurídica 1 (Usuário insere CNPJ válido).
-----------------------------------------------
{ pj1 }

");


pj1.Cnpj = "66743394199621";

Console.WriteLine(@$"
--------------------------------------------
Pessoa Jurídica 1 (Usuário insere apenas 
números no CNPJ).
--------------------------------------------
{ pj1 }

");


pj1.Cnpj = "66743394199621";
Console.WriteLine(@$"
----------------------------------------------
Pessoa Jurídica 1 (Usuário insere caractere 
separador 'traço' ao invés de 'ponto' no 
número-base do CNPJ, sendo portanto, inválido).
----------------------------------------------
{ pj1 }

");

Endereco endPj2 = new Endereco("Rua beltrano", "200", "condomínio", true);
PessoaJuridica pj2 = new PessoaJuridica();

pj2.Nome =  "Nome 2";
pj2.RazaoSocial = "Pessoa jurídica 2";
pj2.Cnpj = "67.783.334/1496-31";
pj2.Endereco = endPj2;
pj2.Rendimento = 40570F;


Console.WriteLine(@$"
-------------------------------------------------
Pessoa Jurídica 2 (Usuário insere CNPJ inválido).
-------------------------------------------------
{ pj2 }

");


Endereco endPj3 = new Endereco("Rua ciclano", "2233", "Condomínio", true);
PessoaJuridica pj3 = new PessoaJuridica();

pj3.Nome =  "Nome 3";
pj3.RazaoSocial = "Pessoa jurídica 3";
pj3.Cnpj = "32.448.645/2012-66";
pj3.Endereco = endPj3;
pj3.Rendimento = 67340F;

Console.WriteLine(@$"
-----------------------------------------------
Pessoa Jurídica 3 (Usuário insere CNPJ válido).
-----------------------------------------------
{ pj3 }

");
