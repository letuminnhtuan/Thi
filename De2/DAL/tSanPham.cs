using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2.DAL
{
    [Table("SanPham")]
    public class tSanPham
    {
        [Key][MaxLength(10)]
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float GiaNhap { get; set; }
        public DateTime NgayNhapSanPham { get; set; }
        public int SoLuong { get; set; }
        public int MaNhaCungCap { get; set; }

        [ForeignKey("MaNhaCungCap")]
        public virtual tNhaCungCap NhaCungCap { get; set; }
    }
}
