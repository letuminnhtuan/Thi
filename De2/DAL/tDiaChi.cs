using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2.DAL
{
    [Table("DiaChi")]
    public class tDiaChi
    {
        [Key][MaxLength(5)]
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }

        public tDiaChi()
        {
            this.NhaCungCaps = new HashSet<tNhaCungCap>();
        }
        public virtual ICollection<tNhaCungCap> NhaCungCaps { get; set; }
    }
}
