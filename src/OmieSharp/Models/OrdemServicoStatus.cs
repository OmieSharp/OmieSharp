﻿namespace OmieSharp.Models
{
    public class OrdemServicoStatus
    {
        public string? cCodIntOS { get; set; }
        public long nCodOS { get; set; }
        public string? cNumOS { get; set; }
        public string? cCodStatus { get; set; }
        public string? cDescStatus { get; set; }

        public bool Success { get { return (cCodStatus ?? "999").Equals("0"); } }
    }
}
