namespace OmieSharp.Models
{
    public class ListarClientesRequest
    {
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }
        public string apenas_importado_api { get; set; }

        public ListarClientesRequest(int pagina = 1, int registros_por_pagina = 50, string apenas_importado_api = "N")
        {
            this.pagina = pagina;
            this.registros_por_pagina = registros_por_pagina;
            this.apenas_importado_api = apenas_importado_api;
        }
    }
}
