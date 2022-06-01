using Curso.Interfaces;

namespace Curso.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }


        public bool ValidarNascimento()
        {
           throw new NotImplementedException();
        }
        
        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }
    }
}
