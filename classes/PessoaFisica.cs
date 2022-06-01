using Curso.Interfaces;

namespace Curso.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public PessoaFisica()
        {
        }

        public PessoaFisica(string nome, Endereco endereco, float rendimento, string cpf,
        DateTime dataNascimento) : base(nome, endereco, rendimento)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public bool ValidarNascimento()
        {
            DateTime dataAtual = DateTime.Today;

            int idade = dataAtual.Year - DataNascimento.Year;

            if (dataAtual.Month < DataNascimento.Month ||
               (dataAtual.Month == DataNascimento.Month &&
                dataAtual.Day < DataNascimento.Day))
            {
                idade--;
            }

            if (idade >= 18)
            {
                return true;
            }

            return false;
        }

        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string maiorDeIdade = ValidarNascimento() ? "Sim" : "Não";

            return base.ToString()
            + "CPF: " + Cpf
            + "\nData de nascimento: " + DataNascimento
            + "\nMaior de idade: " + maiorDeIdade
            + "\n";
        }
    }
}
