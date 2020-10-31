using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstPracticeUpdates.Models
{
    [Table("shelfs")]
    class Shelf
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        //[Column(CreateFormate = "varchar(50) COLLATE NOCASE")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "int(10)")]
        //[Column(CreateFormate = "varchar(50) COLLATE NOCASE")]
        public int ShelfMaterialID { get; set; }

        [ForeignKey(nameof(ShelfMaterialID))]
        //[InverseProperty(nameof(Models.Shelf_Material.Shelfs))]
        public virtual Shelf_Material Shelf_Material { get; set; }

    }
}
