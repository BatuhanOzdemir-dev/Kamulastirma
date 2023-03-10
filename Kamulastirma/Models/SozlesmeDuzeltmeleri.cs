using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class SozlesmeDuzeltmeleri
    {
        public int SozlesmeDuzeltmeId { get; set; }
        public int SozlesmeId { get; set; }
        public DateTime DuzeltilenSozlesmeTarihi { get; set; }
        public string DuzeltmeAciklaması { get; set; } = null!;
        public DateTime UzlasmaKomTarih { get; set; }
        public int UzlasmaKomSayi { get; set; }

        public virtual Sozlesmeler Sozlesme { get; set; } = null!;
    }
}
