using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2.DTO
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float GiaNhap { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhapHang { get; set; }
        public int MaNCC { get; set; }
        public string MaThanhPho { get; set; }
    }
}
