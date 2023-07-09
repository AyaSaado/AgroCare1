using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("Agricultural_Item")]
    public class AgriculturalItem
    {
        public AgriculturalItem()
        {
            StepDetails = new HashSet<StepDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty("AgriculturalItem")]
        public  ICollection<StepDetail> StepDetails { get; set; }
    }
}
