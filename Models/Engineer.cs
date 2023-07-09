using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("Engineer")]
    public  class Engineer
    {
        public Engineer()
        {
            InverseHeadEngineer = new HashSet<Engineer>();
            OrderAdminEngineers = new HashSet<Order>();
            OrderExecutiveTeams = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Engineer_Type_Id")]
        public int EngineerTypeId { get; set; }
        [Column("Head_Engineer_Id")]
        public int HeadEngineerId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Phone { get; set; } = null!;
        public float Salary { get; set; }

        [ForeignKey("EngineerTypeId")]
        [InverseProperty("Engineers")]
        public  EngineerType EngineerType { get; set; } = null!;
        [ForeignKey("HeadEngineerId")]
        [InverseProperty("InverseHeadEngineer")]
        public  Engineer HeadEngineer { get; set; } = null!;
        [InverseProperty("HeadEngineer")]
        public  ICollection<Engineer> InverseHeadEngineer { get; set; }
        [InverseProperty("AdminEngineer")]
        public  ICollection<Order> OrderAdminEngineers { get; set; }
        [InverseProperty("ExecutiveTeam")]
        public  ICollection<Order> OrderExecutiveTeams { get; set; }
    }
}
