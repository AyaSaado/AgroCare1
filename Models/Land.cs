﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Table("Land")]
    public  class Land
    {
        public Land()
        {
            Plans = new HashSet<Plan>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Farmer_Id")]
        public int FarmerId { get; set; }
        [Column("Type_Id")]
        public int TypeId { get; set; }
        [Column("Soil_Type_Id")]
        public int SoilTypeId { get; set; }
        [StringLength(50)]
        public string Location { get; set; } = null!;
        [Column("Has_Well")]
        public bool HasWell { get; set; }
        public float Area { get; set; }

        [ForeignKey("FarmerId")]
        [InverseProperty("Lands")]
        public  Farmer Farmer { get; set; } = null!;
        [ForeignKey("SoilTypeId")]
        [InverseProperty("Lands")]
        public  SoilType SoilType { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("Lands")]
        public  LandType Type { get; set; } = null!;
        [InverseProperty("Land")]
        public  ICollection<Plan> Plans { get; set; }
    }
}
