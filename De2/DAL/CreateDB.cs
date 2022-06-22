using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace De2.DAL
{
    public class CreateDB : DropCreateDatabaseIfModelChanges<QLSP>
    {
        protected override void Seed(QLSP context)
        {
            context.DiaChis.Add(new tDiaChi { MaTinh = "DN", TenTinh = "Da Nang" });
            context.DiaChis.Add(new tDiaChi { MaTinh = "HE", TenTinh = "Hue" });
            context.DiaChis.Add(new tDiaChi { MaTinh = "QN", TenTinh = "Quang Nam" });
            context.DiaChis.Add(new tDiaChi { MaTinh = "HN", TenTinh = "Ha Noi" });
            context.DiaChis.Add(new tDiaChi { MaTinh = "QT", TenTinh = "Quang Tri" });

            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "ABC", MaTinh = "QN"});
            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "BCD", MaTinh = "DN" });
            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "DEF", MaTinh = "HE" });
            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "EFG", MaTinh = "HN" });
            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "FGH", MaTinh = "DN" });
            context.NhaCungCaps.Add(new tNhaCungCap { TenNhaCungCap = "GHI", MaTinh = "QN" });
        }
    }
}
