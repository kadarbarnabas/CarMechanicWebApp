using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarMechanic.Shared
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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