using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    public class CreateDB : DropCreateDatabaseIfModelChanges<QLMA>
    {
        protected override void Seed(QLMA context)
        {
            context._MonAns.Add(new tMonAn { Ten_MonAn = "Canh chua" });
            context._MonAns.Add(new tMonAn { Ten_MonAn = "Trung chien" });
            context._MonAns.Add(new tMonAn { Ten_MonAn = "Thit kho" });

            context._NguyenLieus.Add(new tNguyenLieu { Ten_NguyenLieu = "Ca", TT_NguyenLieu = true });
            context._NguyenLieus.Add(new tNguyenLieu { Ten_NguyenLieu = "Trung", TT_NguyenLieu = false });
            context._NguyenLieus.Add(new tNguyenLieu { Ten_NguyenLieu = "Thi", TT_NguyenLieu = true });
        }
    }
}
