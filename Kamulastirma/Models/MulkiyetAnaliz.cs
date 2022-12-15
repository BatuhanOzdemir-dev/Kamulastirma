using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MulkiyetAnaliz
    {
        public int AnalizId { get; set; }
        public int? MulkiyetId { get; set; }
        public int? Analiz { get; set; }
        public string? TakdirBedeli { get; set; }
        public string? GecekonduAdresi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public DateTime? YikimTarihi { get; set; }

        public virtual MulkiyetBilgileri? Mulkiyet { get; set; }
    }
}
