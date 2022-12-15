using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MulkiyetKonutIsyeri
    {
        public int KonutIsyeriId { get; set; }
        public int? MulkiyetId { get; set; }
        public short? Adet { get; set; }
        public int? Metrekare { get; set; }

        public virtual MulkiyetBilgileri? Mulkiyet { get; set; }
    }
}
