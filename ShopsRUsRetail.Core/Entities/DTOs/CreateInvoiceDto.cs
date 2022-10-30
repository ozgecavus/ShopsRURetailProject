using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShopsRUsRetail.Core.Entities.DTOs
{
    [DataContract]
    public class CreateInvoiceDto
    {

        [DataMember]
        [Required(ErrorMessage = "User ID field is required")]
        public int UserId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Order ID field is required")]
        public int OrderId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Invoice Number field is required")]
        public string InvoiceNumber { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Order total field is required")] 
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Order total must be a positive value")]
        public decimal TotalAmount { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Store Type field is required")]
        public int StoreTypeId { get; set; }

        [DataMember]
        [IgnoreDataMember]
        public decimal DiscountAmount { get; set; }

        [DataMember]
        [IgnoreDataMember]
        public decimal PayableAmount { get; set; }

        [DataMember]
        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
