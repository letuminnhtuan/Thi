using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Thi
{
    class DuLieuSinhVien
    {
        // Design Pattern: Singleton
        private static DuLieuSinhVien _Instance;
        public static DuLieuSinhVien Instance
        {
            get
            {
                if (_Instance == null) _Instance = new DuLieuSinhVien();
                return _Instance;
            }
            private set { }
        }
        public DataTable DTSinhVien;
        private DuLieuSinhVien()
        {
            this.DTSinhVien = new DataTable();
            this.DTSinhVien.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("Ho ten", typeof(string)),
                new DataColumn("Lop SH", typeof(string)),
                new DataColumn("Gioi tinh", typeof(bool)),
                new DataColumn("Ngay sinh", typeof(DateTime)),
                new DataColumn("Diem trung binh", typeof(double)),
                new DataColumn("Anh", typeof(bool)),
                new DataColumn("Hoc ba", typeof(bool)),
                new DataColumn("CC Ngoai ngu", typeof(bool)),
            });
            this.DTSinhVien.Rows.Add("1001", "Nguyen Van A", "20T", true, new DateTime(2002, 7, 22), 8.0, true, true, false);
            this.DTSinhVien.Rows.Add("1003", "Tran Van C", "19T", false, new DateTime(2001, 4, 4), 8.5, false, true, false);
            this.DTSinhVien.Rows.Add("1002", "Nguyen Van B", "21T", true, new DateTime(2003, 12, 2), 7.0, false, true, true);
            this.DTSinhVien.Rows.Add("1004", "Le Van D", "18T", true, new DateTime(2000, 9, 3), 9.0, true, false, false);
            this.DTSinhVien.Rows.Add("1005", "Nguyen Thi A", "20T", false, new DateTime(2002, 2, 7), 6.0, true, false, false);
            this.DTSinhVien.Rows.Add("1006", "Le Van B", "19T", true, new DateTime(2001, 1, 6), 10.0, false, true, false);
            this.DTSinhVien.Rows.Add("1007", "Nguyen D", "21T", true, new DateTime(2003, 7, 1), 6.5, true, true, false);
        }
    }
}
