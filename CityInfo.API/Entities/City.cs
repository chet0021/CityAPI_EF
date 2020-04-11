﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
               = new List<PointOfInterest>();
        public ICollection<Mayor> Mayor { get; set; }
               = new List<Mayor>();
        public int MayorId { get; internal set; }

        internal void Add(City city)
        {
            throw new NotImplementedException();
        }
    }
}
