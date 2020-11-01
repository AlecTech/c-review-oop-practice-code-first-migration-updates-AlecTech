using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstPracticeUpdates.Models
{
    [Table("shelf_material")]
    class Shelf_Material
    {
        
        public Shelf_Material()
        {
            Shelfs = new HashSet<Shelf>();
        }
        
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //[Required]
        [Column(TypeName = "varchar(25)")]
        //[Column(CreateFormate = "varchar(50) COLLATE NOCASE")]
        public string MaterialName { get; set; }
        //nameof property allows auto update of names in case if change it later
        [InverseProperty(nameof(Models.Shelf.ShelfMaterial))]
       public virtual ICollection<Shelf> Shelfs { get; set; }
    }

}
