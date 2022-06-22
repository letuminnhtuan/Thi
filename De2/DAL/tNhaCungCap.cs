using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2.DAL
{
    [Table("NhaCungCap")]
    public class tNhaCungCap
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string MaTinh { get; set; }

        public tNhaCungCap()
        {
            this.SanPhams = new HashSet<tSanPham>();
        }
        public virtual ICollection<tSanPham> SanPhams { get; set; }
        [ForeignKey("MaTinh")]
        public virtual tDiaChi DiaChi { get; set; }
    }
}
