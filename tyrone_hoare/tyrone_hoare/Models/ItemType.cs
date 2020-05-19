using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tyrone_hoare.Models
{
    public class ItemType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemTypeId { get; set; }

        [Required(ErrorMessage = "Item Type name is required")]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }

        //public virtual ICollection<Item> Items { get; set; }
    }
}