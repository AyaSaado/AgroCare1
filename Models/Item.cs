using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("Item")]
    public  class Item
    {
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        [InverseProperty("Item")]
        public  ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
