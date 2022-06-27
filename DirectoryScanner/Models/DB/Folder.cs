using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DirectoryScanner.Models.DB
{
    [Table("Folders", Schema = "Computer")]
    public partial class Folder
    {
        public Folder()
        {
            Files = new HashSet<File>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; } = null!;

        [InverseProperty("Folder")]
        public virtual ICollection<File> Files { get; set; }
    }
}
