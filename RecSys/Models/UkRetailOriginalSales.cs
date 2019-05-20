using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecSys.Models
{
    [Table("UkRetailOriginalSales")]
    public class UkRetailOriginalSales
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int? InvoiceNo { get; set; }

        [Required]
        public string StockCode { get; set; }

        //Meh: Description can be null
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        public int? CustomerID { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
