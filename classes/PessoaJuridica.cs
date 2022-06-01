using System.Text.RegularExpressions;
using Curso.Interfaces;

namespace Curso.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {

        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }

        public PessoaJuridica()
        {
        }

        public PessoaJuridica(string nome, Endereco endereco, float rendimento, string cnpj,
        string razaoSocial) : base(nome, endereco, rendimento)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public bool ValidarCnpj(string? cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somatorio;
            int resto;
            string digito;
            string cnpjAux;

            try
            {
                if (String.IsNullOrEmpty(cnpj))
                    return false;

                cnpj = cnpj.Trim();

                if (Regex.IsMatch(cnpj, @"((\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2})|(\d{14}))"))
                {

                    if (cnpj.Length == 18)
                        cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

                    if (cnpj.All(c => c.Equals(cnpj.First())))
                        return false;

                    somatorio = 0;

                    cnpjAux = cnpj.Substring(0, 12);

                    for (int i = 0; i < cnpjAux.Length; i++)
                        somatorio += int.Parse(cnpjAux[i].ToString()) * multiplicador1[i];

                    resto = somatorio % 11;

                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = resto.ToString();
                    cnpjAux = cnpjAux + digito;

                    somatorio = 0;

                    for (int i = 0; i < cnpjAux.Length; i++)
                        somatorio += int.Parse(cnpjAux[i].ToString()) * multiplicador2[i];

                    resto = somatorio % 11;

                    if (resto < 2)
                        resto = 0;
                    else
                        resto = 11 - resto;

                    digito = digito + resto.ToString();

                }
                else
                    return false;

                return cnpj.EndsWith(digito);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public override string ToString()
        {
            string cnpjValido = "";

            if (!String.IsNullOrEmpty(Cnpj))
                cnpjValido = ValidarCnpj(Cnpj) ? "Sim" : "Não";

            return base.ToString()
            + "CNPJ: " + Cnpj
            + "\nRazão Social: " + RazaoSocial
            + "\nCNPJ válido: " + cnpjValido
            + "\n";
        }
    }
}
