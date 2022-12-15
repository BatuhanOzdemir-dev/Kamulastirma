using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomGorevler
    {
        public UzlasmaKomGorevler()
        {
            UzlasmaKomUyelers = new HashSet<UzlasmaKomUyeler>();
        }

        public int UzlasmaKomGorevId { get; set; }
        public string KomisyonGorevi { get; set; } = null!;

        public virtual ICollection<UzlasmaKomUyeler> UzlasmaKomUyelers { get; set; }
    }
}
