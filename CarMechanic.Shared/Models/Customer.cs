using System;
using System.ComponentModel.DataAnnotations;

namespace CarMechanic.Shared
{
    public class Customer
    {
        [Key]
        public Guid Ugyfelszam { get; set; }

        [Required]
        public string Nev { get; set; }

        [Required]
        public string Lakcim { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}