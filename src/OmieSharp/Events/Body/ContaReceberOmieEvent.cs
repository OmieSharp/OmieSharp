namespace OmieSharp.Events.Body
{
    public class ContaReceberOmieEvent : BaseOmieEvent
    {
        public string? baixa_bloqueada { get; set; }
        public string? bloqueado { get; set; }
        public string? boleto_gerado { get; set; }
        public string? chave_nfe { get; set; }
        public string? codigo_categoria { get; set; }
        public long codigo_cliente_fornecedor { get; set; }
        public string? codigo_cmc7_cheque { get; set; }
        public string? codigo_lancamento_integracao { get; set; }
        public long codigo_lancamento_omie { get; set; }
        public int codigo_projeto { get; set; }
        public string? codigo_tipo_documento { get; set; }
        public int codigo_vendedor { get; set; }
        public DateTime data_emissao { get; set; }
        public DateTime data_previsao { get; set; }
        public DateTime data_registro { get; set; }
        public DateTime data_vencimento { get; set; }
        public long id_conta_corrente { get; set; }
        public string? id_origem { get; set; }
        public string? nsu { get; set; }
        public string? numero_documento { get; set; }
        public string? numero_documento_fiscal { get; set; }
        public string? numero_parcela { get; set; }
        public string? numero_pedido { get; set; }
        public string? observacao { get; set; }
        public string? operacao { get; set; }
        public string? pix_gerado { get; set; }
        public string? retem_cofins { get; set; }
        public string? retem_csll { get; set; }
        public string? retem_inss { get; set; }
        public string? retem_ir { get; set; }
        public string? retem_iss { get; set; }
        public string? retem_pis { get; set; }
        public string? situacao { get; set; }
        public int valor_cofins { get; set; }
        public int valor_csll { get; set; }
        public decimal valor_documento { get; set; }
        public int valor_inss { get; set; }
        public decimal valor_ir { get; set; }
        public int valor_iss { get; set; }
        public decimal valor_pis { get; set; }
    }
}
