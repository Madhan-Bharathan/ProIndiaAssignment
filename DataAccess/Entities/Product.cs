using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Product
    {
      
        //public Int64 Id { get; set; }

        [Key]
        public Int64 ProductId { get; set; }
        public String ProductName { get; set; }

        //[Required]
        public Int32 Quantity { get; set; }

        //[Required]
        public Int64 Price { get; set; }

        [ForeignKey("ProductRefId")]
        public ICollection<Order> Orders { get; set; }
    }
}