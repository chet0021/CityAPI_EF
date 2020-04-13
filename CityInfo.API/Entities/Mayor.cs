using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class Mayor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public char Gender { get; set; }

        [Required]
        [Range(40, 100)]
        public int Age { get; set; }

        //[ForeignKey("CityId")]
        //public City MayorsCity { get; set; }

    }
}
