using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class SozlesmeKonutTeslimi
    {
        public SozlesmeKonutTeslimi()
        {
            Sozlesmelers = new HashSet<Sozlesmeler>();
        }

        public int KonutTeslimiId { get; set; }
        public int TeslimAdedi { get; set; }
        public string AdaParsel { get; set; } = null!;
        public int BlokNo { get; set; }
        public int DaireNo { get; set; }
        public DateTime KonutTeslimTarihi { get; set; }
        public DateTime TapuTescilTarihi { get; set; }
        public DateTime TapuYevmiyeTarihi { get; set; }
        public DateTime? KiraBaslama { get; set; }
        public DateTime? KiraBitirilme { get; set; }

        public virtual ICollection<Sozlesmeler> Sozlesmelers { get; set; }
    }
}
