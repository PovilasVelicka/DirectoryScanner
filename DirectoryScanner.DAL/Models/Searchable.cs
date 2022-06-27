using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScanner.DAL.Models.DB
{
    public class Searchable
    {
        private bool _exists;
        public bool Exists { get => _exists; }
        public void SetExists() => _exists = true;
    }
}
