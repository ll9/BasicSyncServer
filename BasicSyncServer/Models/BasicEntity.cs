using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicSyncServer.Models
{
    public class BasicEntity
    {
        [Key]
        public string Id { get; set; }

        public string Ort { get; set; }
        public string Straße { get; set; }
        public int? Hausnummer { get; set; }

        public bool IsDeleted { get; set; }
        public int RowVersion { get; set; }
    }
}
