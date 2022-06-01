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
        DateTime dataNascimento) : base (nome, endereco, rendimento)
        {
             Cpf = cpf;
             DataNascimento = dataNascimento;
        }

        public PessoaFisica(Pessoa pessoa, string? cpf, DateTime dataNascimento): base(pessoa)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
        } 

        public bool ValidarNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            
            int idade = dataAtual.Year - dataNasc.Year;

            if(dataAtual.Month < dataNasc.Month || 
               (dataAtual.Month == dataNasc.Month && 
               dataAtual.Day  < dataNasc.Day))
            {
               idade--;
            }   

            if(idade >= 18 && idade <= 100)
            {
              return true;
            }
                 
           return false;      
        }
        
        public override float PagarImposto(float rendimento)
        {
            float desconto;

            if(rendimento <= 1500)
            {
               desconto = 0;
            }
            else if(rendimento <= 3500)
            {
               desconto = (rendimento/100) * 2f;
            }
            else if(rendimento <= 6000)
            {
               desconto = (rendimento/100) * 3.5f;
            }
            else
            {
               desconto = (rendimento/100) * 5.5f;
            }

            return desconto;
        }

        public override string ToString()
        {
            string maiorDeIdade = ValidarNascimento(DataNascimento) ? "Sim": "Não";

            return base.ToString() 
            + "\tCPF: " + Cpf 
            + "\n\tData de nascimento: " + DataNascimento
            + "\n\tTaxa de imposto a ser pago: " + PagarImposto(Rendimento).ToString("C");
        }
    }
}
