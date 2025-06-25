namespace OmieSharp.Models.ContaPagarModels;

public class ListarContaPagarResponse
{
    public int pagina { get; set; }
    public int total_de_paginas { get; set; }
    public int registros { get; set; }
    public int total_de_registros { get; set; }
    public List<ContaPagar> conta_pagar_cadastro { get; set; }

    public ListarContaPagarResponse()
    {
        conta_pagar_cadastro = [];
    }
}
