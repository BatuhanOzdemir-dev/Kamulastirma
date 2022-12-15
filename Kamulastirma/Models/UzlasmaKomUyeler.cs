using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class UzlasmaKomUyeler
    {
        public UzlasmaKomUyeler()
        {
            UzlasmaKomisyonlars = new HashSet<UzlasmaKomisyonlar>();
        }

        public int UzlasmaKomUyeId { get; set; }
        public int UzlasmaKomGorevId { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;

        public virtual UzlasmaKomGorevler UzlasmaKomGorev { get; set; } = null!;
        public virtual ICollection<UzlasmaKomisyonlar> UzlasmaKomisyonlars { get; set; }
    }
}
