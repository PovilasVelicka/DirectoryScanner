using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DirectoryScanner.Models.DB
{
    [Table("Files", Schema = "Computer")]
    public partial class File
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        public string FullDirectory { get; set; } = null!;
        public long Size { get; set; }
        public Guid FolderId { get; set; }

        [ForeignKey("FolderId")]
        [InverseProperty("Files")]
        public virtual Folder Folder { get; set; } = null!;
    }
}
