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
        public List<SanPham> GetDSSP(string MaTP, int MaNCC, string txtSearch)
        {
            var list = db.SanPhams.Select(p => p);
            if (!MaTP.Equals("All")) list = list.Where(p => p.NhaCungCap.MaTinh.Equals(MaTP));
            if (MaNCC > 0) list = list.Where(p => p.MaNhaCungCap == MaNCC);
            if (!txtSearch.Equals("")) list = list.Where(p => p.TenSanPham.Contains(txtSearch));
            List<SanPham> data = new List<SanPham>();
            foreach(tSanPham i in list)
            {
                data.Add(new SanPham
                {
                    MaSanPham = i.MaSanPham,
                    GiaNhap = i.GiaNhap,
                    NgayNhapHang = i.NgayNhapSanPham,
                    MaNCC = i.MaNhaCungCap,
                    SoLuong = i.SoLuong,
                    TenSanPham = i.TenSanPham,
                    MaThanhPho = i.NhaCungCap.MaTinh,
                });
            }
            return data;
        }
        public string GetTenTPByMaTP(string MaThanhPho)
        {
            return db.DiaChis.Find(MaThanhPho).TenTinh;
        }
        public string GetNCCByMaNCC(int MaNCC)
        {
            return db.NhaCungCaps.Find(MaNCC).TenNhaCungCap;
        }
        public SanPham GetSanPham(int MaNCC, string MaSanPham)
        {
            var i = db.SanPhams.Select(p => p).Where(p => p.MaNhaCungCap == MaNCC && p.MaSanPham.Equals(MaSanPham)).FirstOrDefault();
            SanPham data = null;
            if(i != null)
            {
                data = new SanPham
                {
                    MaSanPham = i.MaSanPham,
                    GiaNhap = i.GiaNhap,
                    SoLuong = i.SoLuong,
                    MaNCC = i.MaNhaCungCap,
                    TenSanPham = i.TenSanPham,
                    NgayNhapHang = i.NgayNhapSanPham,
                    MaThanhPho = i.NhaCungCap.MaTinh,
                };
            }
            return data;
        }
        public void AddUpdateSP(SanPham data)
        {
            if (GetSanPham(data.MaNCC, data.MaSanPham) == null) AddSP(data);
            else UpdateSP(data);
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
        public void UpdateSP(SanPham data)
        {
            var i = db.SanPhams.Find(data.MaSanPham);
            i.TenSanPham = data.TenSanPham;
            i.GiaNhap = data.GiaNhap;
            i.SoLuong = data.SoLuong;
            i.NgayNhapSanPham = data.NgayNhapHang;
            i.MaNhaCungCap = data.MaNCC;
            db.SaveChanges();
        }
    }
}
