using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomDuzeltme
    {
        public UzlasmaKomDuzeltme()
        {
            SozlesmeDuzeltmeleris = new HashSet<SozlesmeDuzeltmeleri>();
        }

        public int UzlasmaKomDuzeltmeId { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public int KomisyonGoreviId { get; set; }

        public virtual ICollection<SozlesmeDuzeltmeleri> SozlesmeDuzeltmeleris { get; set; }
    }
}
