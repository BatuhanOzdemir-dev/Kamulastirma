using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MahkemeOdemeler
    {
        public MahkemeOdemeler()
        {
            Mahkemelers = new HashSet<Mahkemeler>();
        }

        public int MahkemeOdemeId { get; set; }
        public string OdenenIcraMd { get; set; } = null!;
        public int EsasNo { get; set; }
        public int AsilBedel { get; set; }

        public virtual ICollection<Mahkemeler> Mahkemelers { get; set; }
    }
}
