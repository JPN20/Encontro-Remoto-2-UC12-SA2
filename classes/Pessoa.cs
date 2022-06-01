using Curso.Interfaces;

namespace Curso.Classes
{
    public abstract class Pessoa: IPessoa
    {
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public float? Rendimento { get; set; }

        public abstract float PagarImposto(float rendimento);
    
    }
}
