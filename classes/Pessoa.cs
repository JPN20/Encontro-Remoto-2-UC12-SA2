using System.Text;
using Curso.Interfaces;

namespace Curso.Classes
{
    public abstract class Pessoa: IPessoa
    {
        public string? Nome { get; set; }
        public Endereco? Endereco { get; set; }
        public float? Rendimento { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, Endereco endereco, float rendimento)
        {
            Nome = nome;
            Endereco = endereco;
            Rendimento = rendimento;
        }
        public abstract float PagarImposto(float rendimento);

        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Nome: " + Nome);
            sb.AppendLine(Endereco?.ToString());
            sb.AppendLine("Rendimento: " + Rendimento?.ToString("C"));

            return sb.ToString();
        }
    
    }
}
