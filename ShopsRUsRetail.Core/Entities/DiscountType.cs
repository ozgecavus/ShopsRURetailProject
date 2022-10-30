using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUsRetail.Core.Entities
{
    public class DiscountType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(35)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Rate { get; set; }
        public bool IsRatePercentage { get; set; }
    
    }
}
