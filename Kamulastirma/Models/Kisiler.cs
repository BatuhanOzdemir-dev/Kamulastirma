using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class Kisiler
    {
        public Kisiler()
        {
            Mahkemelers = new HashSet<Mahkemeler>();
            Sozlesmelers = new HashSet<Sozlesmeler>();
            VerasetlerOrtakliklarKisis = new HashSet<VerasetlerOrtakliklar>();
            VerasetlerOrtakliklarVarisOrtaks = new HashSet<VerasetlerOrtakliklar>();
        }

        public int KisiId { get; set; }
        public int? HakSahibiNo { get; set; }
        public int? TckimlikNo { get; set; }
        public string? KisiAd { get; set; }
        public string? KisiSoyad { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public bool? VefatBool { get; set; }
        public DateTime? VefatTarih { get; set; }

        public virtual ICollection<Mahkemeler> Mahkemelers { get; set; }
        public virtual ICollection<Sozlesmeler> Sozlesmelers { get; set; }
        public virtual ICollection<VerasetlerOrtakliklar> VerasetlerOrtakliklarKisis { get; set; }
        public virtual ICollection<VerasetlerOrtakliklar> VerasetlerOrtakliklarVarisOrtaks { get; set; }
    }
}
