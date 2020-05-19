using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WebApplication1.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Required]
        public int ItemTypeId { get; set; }


        [Display(Name = "Seller Id")]
        public Guid ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers are allowed.")]
        [Index("indexing", 2, IsUnique = true)]
        public int Quantity { get; set; }

        [Required]
        [Index("indexing", 3, IsUnique = true)]
        public int QualityId { get; set; }

        [Required(ErrorMessage = "Price field is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "Only positive numbers are allowed.")]
        [Index("indexing", 4, IsUnique = true)]
        public float Price { get; set; }

        //[Required]
        //[Index("IX_Date", 5)]
        public DateTime Date = DateTime.Now;


        public virtual ItemType ItemTypes { get; set; }
        public virtual Quality Quality { get; set; }

    }
}