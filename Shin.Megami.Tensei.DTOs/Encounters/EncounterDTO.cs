using System;
using System.ComponentModel.DataAnnotations;

namespace Shin.Megami.Tensei.DTOs.Encounters
{
    public class EncounterDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string Notes { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][0-9][A-Z][ ][0-9][A-Z][0-9]", ErrorMessage = "Visit Code field must have the format 'LDL DLD'.")]
        public string VisitCode { get; set; }

        [Required]
        public string Provider { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", ErrorMessage = "Billing Code field must have the format 'DDD.DDD.DDD-DD'.")]
        public string BillingCode { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[0-9]{1}[0-9]{1}", ErrorMessage = "ICD10 field requires format 'A00'.")]
        public string ICD10 { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[.][0-9]{1,2}$", ErrorMessage = "This field requires numbers only.")]
        public decimal TotalCost { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[.][0-9]{1,2}$", ErrorMessage = "This field requires numbers only.")]
        public decimal Copay { get; set; }

        [Required]
        public string ChiefComplaint { get; set; }

        [RegularExpression(@"^[0-9]+[.][0-9]{1,2}$", ErrorMessage = "This field requires numbers only.")]
        public decimal Pulse { get; set; }

        [RegularExpression(@"^[0-9]+[.][0-9]{1,2}$", ErrorMessage = "This field requires numbers only.")]
        public decimal Systolic { get; set; }

        [RegularExpression(@"^[0-9]+[.][0-9]{1,2}$", ErrorMessage = "This field requires numbers only.")]
        public decimal Diastolic { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
