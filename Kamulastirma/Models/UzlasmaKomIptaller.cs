using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomIptaller
    {
        public UzlasmaKomIptaller()
        {
            SozlesmeIptalleris = new HashSet<SozlesmeIptalleri>();
        }

        public int UzlasmaKomIptallerId { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public int KomisyonGoreviId { get; set; }

        public virtual ICollection<SozlesmeIptalleri> SozlesmeIptalleris { get; set; }
    }
}
