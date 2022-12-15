using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class Mahkemeler
    {
        public int MahkemeId { get; set; }
        public int KisiId { get; set; }
        public int DavaKonusuId { get; set; }
        public int AsliyeEsasNo { get; set; }
        public int IdareEsasNo { get; set; }
        public int MahkemeOdemeId { get; set; }

        public virtual MahkemeDavaKonulari DavaKonusu { get; set; } = null!;
        public virtual Kisiler Kisi { get; set; } = null!;
        public virtual MahkemeOdemeler MahkemeOdeme { get; set; } = null!;
    }
}
