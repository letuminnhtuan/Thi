using De2.DAL;
using De2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2.BLL
{
    public class BLL_QL
    {
        QLSP db;
        private static BLL_QL _Instance;
        public static BLL_QL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BLL_QL(new QLSP());
                return _Instance;
            }
            private set { }
        }
        private BLL_QL(QLSP db)
        {
            this.db = db;
        }
        public List<CBBItem> GetCBBTinh()
        {
            List<CBBItem> data = new List<CBBItem>();
            var list = db.DiaChis.Select(p => p);
            foreach(tDiaChi i in list)
            {
                data.Add(new CBBItem { Key = i.MaTinh, Value = i.TenTinh });
            }
            return data;
        }
        public List<CBBItem> GetCBBNCC(string MaTP)
        {
            List<CBBItem> data = new List<CBBItem>();
            var list = db.NhaCungCaps.Select(p => p);
            if (!MaTP.Equals("All"))
            {
                list = list.Where(p => p.MaTinh.Equals(MaTP));
            }
            foreach (tNhaCungCap i in list)
            {
                data.Add(new CBBItem { Key = i.MaNhaCungCap.ToString(), Value = i.TenNhaCungCap });
            }
            return data;
        }
        public void GetDSSP(string MaTP, string MaNCC, string txtSearch)
        {

        }
        public void AddSP(SanPham data)
        {
            tSanPham i = new tSanPham
            {
                MaSanPham = data.MaSanPham,
                GiaNhap = data.GiaNhap,
                TenSanPham = data.TenSanPham,
                NgayNhapSanPham = data.NgayNhapHang,
                SoLuong = data.SoLuong,
                MaNhaCungCap = data.MaNCC,
            };
            db.SanPhams.Add(i);
            db.SaveChanges();
        }
        public void UpdateSP()
        {

        }
    }
}
