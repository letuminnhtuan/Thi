using CodeFirst.DAL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.BLL
{
    public class BLL_QL
    {
        QLMA db;
        private static BLL_QL _Instance;
        public static BLL_QL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BLL_QL(new QLMA());
                return _Instance;
            }
            private set { }
        }
        private BLL_QL(QLMA db)
        {
            this.db = db;
        }
        public List<CBBItem> GetCBBMonAn()
        {
            var list = db._MonAns.Select(p => p);
            List<CBBItem> data = new List<CBBItem>();
            foreach(tMonAn i in list)
            {
                data.Add(new CBBItem
                {
                    Key = i.ID_MonAn,
                    Value = i.Ten_MonAn
                });
            }
            return data;
        }
        public List<CBBItem> GetCBBNguyenLieu()
        {
            //var list = db._NguyenLieus.Select(p => p);
            //List<CBBItem> data = new List<CBBItem>();
            //foreach (tNguyenLieu i in list)
            //{
            //    data.Add(new CBBItem
            //    {
            //        Key = i.ID_NguyenLieu,
            //        Value = i.Ten_NguyenLieu
            //    });
            //}
            //return data;
            return db._NguyenLieus.Select(p => new CBBItem
            {
                Key = p.ID_NguyenLieu,
                Value = p.Ten_NguyenLieu 
            }).ToList();
        }
        public List<MA_NL> GetDSNguyenLieu(int ID_MonAn, string txtSearch)
        {
            var list = db._MA_NLs.Select(p => p).Where(p => p.MonAn.ID_MonAn == ID_MonAn);
            List<MA_NL> data = new List<MA_NL>();
            if (!txtSearch.Equals(""))
            {
                list = list.Where(p => p.NguyenLieu.Ten_NguyenLieu.Contains(txtSearch) || p.DonViTinh.Contains(txtSearch));
            }
            foreach (tMA_NL i in list)
            {
                data.Add(new MA_NL
                {
                    Ma = i.ID,
                    MaMonAn = i.ID_MonAn,
                    MaNguyenLieu = i.ID_NguyenLieu,
                    TenNguyenLieu = i.NguyenLieu.Ten_NguyenLieu,
                    SoLuong = i.SoLuong,
                    DonViTinh = i.DonViTinh,
                    TinhTrang = i.NguyenLieu.TT_NguyenLieu
                });
            }
            return data;
        }
        public MA_NL GetNguyenLieuByMonAn(int MaMonAn, int MaNguyenLieu)
        {
            var i = db._MonAns.Find(MaMonAn).MA_NLs.Select(p => p).Where(p => p.ID_NguyenLieu == MaNguyenLieu).FirstOrDefault();
            MA_NL data = null;
            if(i != null)
            {
                data = new MA_NL
                {
                    Ma = i.ID,
                    MaNguyenLieu = i.ID_NguyenLieu,
                    MaMonAn = i.ID_MonAn,
                    DonViTinh = i.DonViTinh,
                    TenNguyenLieu = i.NguyenLieu.Ten_NguyenLieu,
                    SoLuong = i.SoLuong,
                    TinhTrang = i.NguyenLieu.TT_NguyenLieu,
                };
            }
            return data;
        }
        public void AddUpdateNL(MA_NL data)
        {
            if (GetNguyenLieuByMonAn(data.MaMonAn, data.MaNguyenLieu) == null) AddNL(data);
            else UpdateNL(data);
        }
        public void UpdateNL(MA_NL data)
        {
            var i = db._MonAns.Find(data.MaMonAn).MA_NLs.Select(p => p).Where(p => p.ID_NguyenLieu == data.MaNguyenLieu).FirstOrDefault();
            i.SoLuong = data.SoLuong;
            i.DonViTinh = data.DonViTinh;
            i.NguyenLieu.TT_NguyenLieu = data.TinhTrang;
            db.SaveChanges();
        }
        public void AddNL(MA_NL data)
        {
            tMA_NL i = new tMA_NL
            {
                ID = data.Ma,
                ID_MonAn = data.MaMonAn,
                ID_NguyenLieu = data.MaNguyenLieu,
                DonViTinh = data.DonViTinh,
                SoLuong = data.SoLuong,
            };
            var j = db._NguyenLieus.Find(data.MaNguyenLieu);
            j.TT_NguyenLieu = data.TinhTrang;
            db._MA_NLs.Add(i);
            db.SaveChanges();
        }
        public void DeleteNL(int MaMonAn, int MaNguyenLieu)
        {
            var i = db._MA_NLs.Select(p => p).Where(p => p.ID_NguyenLieu == MaNguyenLieu && p.ID_MonAn == MaMonAn).FirstOrDefault();
            db._MA_NLs.Remove(i);
            db.SaveChanges();
        }
        public List<MA_NL> Sort(string txtSort, int MaMonAn, string txtSearch)
        {
            List<MA_NL> temp = GetDSNguyenLieu(MaMonAn, txtSearch);
            if (txtSort.Equals("So luong"))
            {
                temp.Sort(delegate (MA_NL data1, MA_NL data2) { return data1.SoLuong.CompareTo(data2.SoLuong); });
            }
            else if(txtSort.Equals("Ten nguyen lieu"))
            {
                temp.Sort(delegate (MA_NL data1, MA_NL data2) { return data1.TenNguyenLieu.CompareTo(data2.TenNguyenLieu); });
            }
            else if(txtSort.Equals("Don vi tinh"))
            {
                temp.Sort(delegate (MA_NL data1, MA_NL data2) { return data1.DonViTinh.CompareTo(data2.DonViTinh); });
            }
            return temp;
        }
    }
}
