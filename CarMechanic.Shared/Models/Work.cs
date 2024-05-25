using System;
using System.ComponentModel.DataAnnotations;

namespace CarMechanic.Shared
{
    public class Work
    {
        [Key]
        public Guid MunkaId { get; set; }

        [Required]
        public Guid Ugyfelszam { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$")]
        public string Rendszam { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public int GyartasiEv { get; set; }

        [Required]
        public string Kategoria { get; set; }

        public string HibakLeirasa { get; set; }

        [Required]
        [Range(1, 10)]
        public int HibaSulyossag { get; set; }

        [Required]
        [RegularExpression("Felvett Munka|Elvégzés alatt|Befejezett")]
        public string Allapot { get; set; }
    }
}