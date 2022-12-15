using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MulkiyetKonutTeslimi
    {
        public int KonutTeslimiId { get; set; }
        public int? MulkiyetId { get; set; }
        public int? TeslimAdedi { get; set; }
        public string? AdaParsel { get; set; }
        public int? BlokNo { get; set; }
        public int? DaireNo { get; set; }
        public DateTime? KonutTeslimTarihi { get; set; }
        public DateTime? TapuTescilTarihi { get; set; }
        public DateTime? TapuYevmiyeTarihi { get; set; }
        public DateTime? KiraBaslama { get; set; }
        public DateTime? KiraBitirilme { get; set; }

        public virtual MulkiyetBilgileri? Mulkiyet { get; set; }
    }
}
