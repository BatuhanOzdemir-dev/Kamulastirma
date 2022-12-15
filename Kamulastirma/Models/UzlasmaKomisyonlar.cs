using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomisyonlar
    {
        public int UzlasmaKomisyonId { get; set; }
        public int? UzlasmaKomUyeId { get; set; }
        public int? SozlesmeId { get; set; }
        public string? KomisyonDurumu { get; set; }

        public virtual UzlasmaKomUyeler? UzlasmaKomUye { get; set; }
    }
}
