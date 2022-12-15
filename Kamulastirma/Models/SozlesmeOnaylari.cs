using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class SozlesmeOnaylari
    {
        public int SozlesmeOnayiId { get; set; }
        public DateTime? SozlesmeTarihi { get; set; }
        public DateTime? TapuFeragTarihi { get; set; }
        public int? KlasorNo { get; set; }
        public DateTime? UzlasmaKomTarih { get; set; }
        public int? UzlasmaKomSayi { get; set; }
        public int? SozlesmeId { get; set; }

        public virtual Sozlesmeler? Sozlesme { get; set; }
    }
}
