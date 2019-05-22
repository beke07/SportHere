using Microsoft.AspNetCore.Mvc.Rendering;
using SportHere.Web.ViewModels.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Leírás megadása kötelező!")]
        [Display(Name = "Leírás")]
        public string Description { get; set; }

        [Display(Name = "Sport")]
        public string SportId { get; set; }

        public SelectViewModel SportSelect { get; set; }

        [Required(ErrorMessage = "Létszám megadása kötelező!")]
        [Display(Name = "Létszám")]
        public int MaxNumberOfParticipants { get; set; }

        [Required(ErrorMessage = "Ár megadása kötelező!")]
        [Display(Name = "Ár")]
        public int Price { get; set; }

        [Display(Name = "Szín")]
        public string Color { get; set; }

        [Display(Name = "Megjegyzés")]
        public string Comment { get; set; }

        [Display(Name = "Van világítás")]
        public bool IsLighting { get; set; }

        [Display(Name = "Van labda")]
        public bool HasBall { get; set; }

        [Display(Name = "Van öltöző")]
        public bool HasDressingRoom { get; set; }

        [Display(Name = "Dátum -tól")]
        [Required(ErrorMessage = "Dátum megadása kötelező!")]
        public DateTime Date { get; set; }

        [Display(Name = "Dátum -ig")]
        [Required(ErrorMessage = "Dátum megadása kötelező!")]
        public string TimeTo { get; set; }

        public MapViewModel Map { get; set; }

        public bool IsExpired { get; set; }

        [Display(Name = "Kihívás")]
        public bool IsChallenge { get; set; }

        [Display(Name = "Nyeremény")]
        [Required(ErrorMessage = "Nyeremény megadása kötelező!")]
        public int Prize { get; set; }
    }
}
