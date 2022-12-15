using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MulkiyetTasinmazlari
    {
        public int MulkiyetTasinmazId { get; set; }
        public int? MulkiyetId { get; set; }
        public string? Ada { get; set; }
        public string? Parsel { get; set; }
        public string? Hisse { get; set; }
        public string? Etap { get; set; }

        public virtual MulkiyetBilgileri? Mulkiyet { get; set; }
    }
}
