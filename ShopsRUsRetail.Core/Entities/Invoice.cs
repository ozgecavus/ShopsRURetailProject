using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopsRUsRetail.Core.Entities
{
    public class Invoice
    {
        public Invoice()
        {
            DateCreated = DateTime.Now;
        }
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [MaxLength(25)]
        public string InvoiceNumber { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int StoreTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal TotalAmount { get; set; }

       
        [Column(TypeName = "decimal(19, 2)")]
        public decimal DiscountAmount { get; set; }

      
        [Column(TypeName = "decimal(19, 2)")]
        public decimal PayableAmount { get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public  ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
