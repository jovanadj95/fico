using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProdavnica.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Unesite email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Unesi ime")]
        [StringLength(30,ErrorMessage ="Maksimalno 30 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesi prezime")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesi drzavu")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Drzava { get; set; }

        [Required(ErrorMessage = "Unesi grad")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Grad { get; set; }

        [Required(ErrorMessage = "Unesi adresu")]
        [StringLength(30, ErrorMessage = "Maksimalno 100 karaktera")]
        public string Adresa { get; set; }
        [Required(ErrorMessage ="Unesi lozinku")]
        [StringLength(100, ErrorMessage = "Najmanje 3 karaktera", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Potvrda ne odgovara lozinci")]
        public string ConfirmPassword { get; set; }
    }
}
