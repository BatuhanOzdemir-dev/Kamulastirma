using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class SozlesmeTurleri
    {
        public SozlesmeTurleri()
        {
            Sozlesmelers = new HashSet<Sozlesmeler>();
        }

        public int SozlesmeTuruId { get; set; }
        public string SozlesmeTuru { get; set; } = null!;

        public virtual ICollection<Sozlesmeler> Sozlesmelers { get; set; }
    }
}
