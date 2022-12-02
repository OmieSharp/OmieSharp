namespace OmieSharp.Models
{
    public class Recomendacoes
    {
        public int codigo_transportadora { get; set; }
        public string? gerar_boletos { get; set; }
        public int? codigo_vendedor { get; set; }
        public string? email_fatura { get; set; }
        public string? numero_parcelas { get; set; }
    }
}
