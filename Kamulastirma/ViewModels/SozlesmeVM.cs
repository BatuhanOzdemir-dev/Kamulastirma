using Kamulastirma.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kamulastirma.ViewModels
{
    public class SozlesmeVM
    {        
        //
        public Sozlesmeler? Sozlesmeler { get; set; }
        //
        public MulkiyetBilgileri? MulkiyetBilgileri { get; set; }
        public MulkiyetAnaliz? MulkiyetAnaliz { get; set; }
        public MulkiyetTasinmazlari? MulkiyetTasinmazlari { get; set; }
        public MulkiyetKonutTeslimi? MulkiyetKonutTeslimi { get; set; }
        public MulkiyetKonutIsyeri? MulkiyetKonutIsyeri { get; set; }
        //
        public Kisiler? Kisi { get; set; }
        public List<Kisiler>? Kisiler { get; set; }

    }
}
