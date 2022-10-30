
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopsRUsRetail.Core.Entities
{
    public class InvoiceDetails
    {
        [Key]
        
        public int Id { get; set; }

        [Required] 
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal ProductCost { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal ProductDiscountPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal ProductPayableCost { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        //public Invoice Invoice { get; set; } 



    }
}
