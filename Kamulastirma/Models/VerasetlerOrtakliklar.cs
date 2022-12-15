using System;
using System.Collections.Generic;

namespace Kamulastirma.Models
{
    public partial class VerasetlerOrtakliklar
    {
        public int VerasetOrtaklikId { get; set; }
        public int KisiId { get; set; }
        public int VarisOrtakId { get; set; }
        public string VerasetOrtaklik { get; set; } = null!;

        public virtual Kisiler Kisi { get; set; } = null!;
        public virtual Kisiler VarisOrtak { get; set; } = null!;
    }
}
