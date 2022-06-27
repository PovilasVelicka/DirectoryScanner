using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DirectoryScanner.DAL.Models.DB
{
    [Table("Folders", Schema = "Computer")]
    [Index("Name", Name = "IX_FoldersName")]
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
