using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class SozlesmeIptalleri
    {
        public int SozlesmeIptalId { get; set; }
        public int SozlesmeId { get; set; }
        public string IptalGerekcesi { get; set; } = null!;
        public DateTime UzlasmaKomTarih { get; set; }
        public int UzlasmaKomSayi { get; set; }

        public virtual Sozlesmeler Sozlesme { get; set; } = null!;
    }
}
