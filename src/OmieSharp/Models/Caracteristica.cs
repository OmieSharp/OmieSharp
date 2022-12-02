namespace OmieSharp.Models
{
    public class Caracteristica
    {
        public string campo { get; set; }
        public string conteudo { get; set; }

        public Caracteristica(string campo, string conteudo)
        {
            this.campo = campo;
            this.conteudo = conteudo;
        }
    }
}
