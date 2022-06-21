using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thi
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string LopSH { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public double DiemTB { get; set; }
        public bool Anh { get; set; }
        public bool HocBa { get; set; }
        public bool CCNN { get; set; }
    }
    public class SortName : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return x.HoTen.CompareTo(y.HoTen);
        }
    }
    public class SortDiemTB : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return x.DiemTB.CompareTo(y.DiemTB);
        }
    }
    public class SortNgaySinh : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            return x.NgaySinh.CompareTo(y.NgaySinh);
        }
    }

}
