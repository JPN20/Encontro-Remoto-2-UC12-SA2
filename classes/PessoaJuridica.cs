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

        public bool ValidarCnpj(string cnpj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() 
            + "CNPJ: " + Cnpj
            + "\nRazão Social: " + RazaoSocial
            + "\n";
        }
    }
}
