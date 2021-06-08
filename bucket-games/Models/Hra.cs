using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bucket_games.Models
{
    public class Hra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Prosím vyplň název hry")]
        [Display(Name = "Název hry")]
        [StringLength(100)]
        public string Název { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Prosím vyplň datum vydání hry")]
        [Display(Name = "Datum vydání")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Prosím vyplň žánr hry")]
        public string Žánr { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "Prosím vyplň cenu hry")]
        public decimal Cena { get; set; }
    }
}
