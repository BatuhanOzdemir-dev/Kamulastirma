using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MahkemeDavaKonulari
    {
        public MahkemeDavaKonulari()
        {
            Mahkemelers = new HashSet<Mahkemeler>();
        }

        public int DavaKonusuId { get; set; }
        public string DavaKonusu { get; set; } = null!;

        public virtual ICollection<Mahkemeler> Mahkemelers { get; set; }
    }
}
