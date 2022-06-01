using System.Text;
using Curso.Interfaces;

namespace Curso.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? Nome { get; set; }
        public Endereco? Endereco { get; set; }
        public float Rendimento { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, Endereco endereco, float rendimento)
        {
            Nome = nome;
            Endereco = endereco;
            Rendimento = rendimento;
        }

        public Pessoa(Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Endereco = pessoa.Endereco;
            Rendimento = pessoa.Rendimento;
        }

        public abstract float PagarImposto(float rendimento);

        public void VerificarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            string subpasta = caminho.Split("/")[1];

            string pastas = Path.Combine(pasta, subpasta);

            if (!Directory.Exists(pastas))
            {
                Directory.CreateDirectory(pastas);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho)) { }
            }
        }

        public void VerificarPasta(string caminho)
        {
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nome: " + Nome);
            sb.AppendLine(Endereco?.ToString());
            sb.AppendLine("\tRendimento: " + Rendimento.ToString("C"));

            return sb.ToString();
        }

    }
}
