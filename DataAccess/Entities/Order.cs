using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Order
    {
        //[ForeignKey("OrderName")]
        //public ICollection<Product> Products { get; set; }
        [Key]
        public Int64 OrderId { get; set; }
        public string OrderName { get; set; }
        //public Int64 Id { get; set; }
        
        public Int32 Quantity { get; set; }

        public Int64 Price { get; set; }
        public Int64 ProductRefId { get; set; }
        
    }
}
