using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("Engineer_Type")]
    public  class EngineerType
    {
        public EngineerType()
        {
            Engineers = new HashSet<Engineer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty("EngineerType")]
        public  ICollection<Engineer> Engineers { get; set; }
    }
}
