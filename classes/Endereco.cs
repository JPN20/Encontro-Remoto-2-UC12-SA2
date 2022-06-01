namespace Curso.Classes
{
    public class Endereco
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public bool? EndComercial { get; set; }

        public Endereco()
        {
        }

        public Endereco(string logradouro, string numero, string complemento, bool endComercial)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            EndComercial = endComercial;
        }

        public override string ToString()
        {
            string comercial = EndComercial.Equals(true) ? "Sim" : "Não";

            return 
              "Endereço: " + Logradouro  + ", " + Numero 
              + "\nComplemento: " + Complemento 
              + "\nEndereço comercial: " + comercial;       
        }
    }
}
