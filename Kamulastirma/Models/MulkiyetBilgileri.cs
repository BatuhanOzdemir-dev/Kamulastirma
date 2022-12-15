using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class MulkiyetBilgileri
    {
        public MulkiyetBilgileri()
        {
            MulkiyetAnalizs = new HashSet<MulkiyetAnaliz>();
            MulkiyetKonutIsyeris = new HashSet<MulkiyetKonutIsyeri>();
            MulkiyetKonutTeslimis = new HashSet<MulkiyetKonutTeslimi>();
            Sozlesmelers = new HashSet<Sozlesmeler>();
        }

        public int MulkiyetId { get; set; }
        public int? TahsisMetrekare { get; set; }
        public bool? TahsisBorcuVarmi { get; set; }
        public int? Etap { get; set; }
        public int? KonutMetrekare { get; set; }
        public string? BorcluAlacakli { get; set; }
        public string? BorcPesinTaksit { get; set; }
        public string? BorcluSicil { get; set; }
        public int? MetrekareBedeli { get; set; }
        public int? ToplamOdeme { get; set; }

        public virtual ICollection<MulkiyetAnaliz> MulkiyetAnalizs { get; set; }
        public virtual ICollection<MulkiyetKonutIsyeri> MulkiyetKonutIsyeris { get; set; }
        public virtual ICollection<MulkiyetKonutTeslimi> MulkiyetKonutTeslimis { get; set; }
        public virtual ICollection<Sozlesmeler> Sozlesmelers { get; set; }
    }
}
