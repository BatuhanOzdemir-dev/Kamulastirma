using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class Sozlesmeler
    {
        public Sozlesmeler()
        {
            SozlesmeDuzeltmeleris = new HashSet<SozlesmeDuzeltmeleri>();
            SozlesmeIptalleris = new HashSet<SozlesmeIptalleri>();
            SozlesmeOnaylaris = new HashSet<SozlesmeOnaylari>();
        }

        public int SozlesmeId { get; set; }
        public int? SozlesmeTuruId { get; set; }
        public int? MulkiyetId { get; set; }
        public int? KisiId { get; set; }
        public int? KonutTeslimiId { get; set; }
        public int? ProjeId { get; set; }

        public virtual Kisiler? Kisi { get; set; }
        public virtual MulkiyetBilgileri? Mulkiyet { get; set; }
        public virtual SozlesmeTurleri? SozlesmeTuru { get; set; }
        public virtual ICollection<SozlesmeDuzeltmeleri> SozlesmeDuzeltmeleris { get; set; }
        public virtual ICollection<SozlesmeIptalleri> SozlesmeIptalleris { get; set; }
        public virtual ICollection<SozlesmeOnaylari> SozlesmeOnaylaris { get; set; }
    }
}
