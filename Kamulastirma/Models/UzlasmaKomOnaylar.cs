using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomOnaylar
    {
        public UzlasmaKomOnaylar()
        {
            SozlesmeOnaylaris = new HashSet<SozlesmeOnaylari>();
        }

        public int UzlasmaKomOnaylarId { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public int KomisyonGoreviId { get; set; }

        public virtual ICollection<SozlesmeOnaylari> SozlesmeOnaylaris { get; set; }
    }
}
