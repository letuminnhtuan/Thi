using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Thi
{
    class QuanLySinhVien
    {
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> data = new List<SinhVien>();
            foreach (DataRow i in DuLieuSinhVien.Instance.DTSinhVien.Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        public SinhVien GetSVByMSSV(string s)
        {
            SinhVien data = new SinhVien();
            foreach(SinhVien i in GetAllSV())
            {
                if (i.MSSV == s)
                {
                    data = i;
                    break;
                }
            }
            return data;
        }
        public SinhVien GetSVByDataRow(DataRow i)
        {
            SinhVien sv = new SinhVien
            {
                MSSV = i["MSSV"].ToString(),
                HoTen = i["Ho ten"].ToString(),
                LopSH = i["Lop SH"].ToString(),
                GioiTinh = Convert.ToBoolean(i["Gioi tinh"].ToString()),
                NgaySinh = Convert.ToDateTime(i["Ngay sinh"].ToString()),
                DiemTB = Convert.ToDouble(i["Diem trung binh"].ToString()),
                Anh = Convert.ToBoolean(i["Anh"].ToString()),
                HocBa = Convert.ToBoolean(i["Hoc ba"].ToString()),
                CCNN = Convert.ToBoolean(i["CC Ngoai ngu"].ToString())
            };
            return sv;
        }
        public List<string> GetDSLop()
        {
            List<string> data = new List<string>();
            foreach(SinhVien i in GetAllSV())
            {
                data.Add(i.LopSH);
            }
            return data;
        }
        public List<SinhVien> GetDSSV(string Lop, string str)
        {
            List<SinhVien> data = new List<SinhVien>();
            if (str == "")
            {
                if (Lop == "All") data = GetAllSV();
                else
                {
                    foreach (SinhVien i in GetAllSV())
                    {
                        if (i.LopSH == Lop) data.Add(i);
                    }
                }
            }
            else
            {
                foreach (SinhVien i in GetAllSV())
                {
                    if ((i.HoTen.Contains(str) || i.MSSV.Contains(str)) && (i.LopSH == Lop || Lop == "All")) data.Add(i);
                }
            }
            return data;
        }
        public void Run(SinhVien sv, string str)
        {
            if (str == null) DuLieuSinhVien.Instance.DTSinhVien.Rows.Add(sv.MSSV, sv.HoTen, sv.LopSH, sv.GioiTinh, sv.NgaySinh, sv.DiemTB, sv.Anh, sv.HocBa, sv.CCNN);
            else
            {
                List<SinhVien> data = GetAllSV();
                int index = 0;
                for(int i = 0; i < data.Count; i++)
                {
                    if (data[i].MSSV == str) index = i;
                }
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Ho ten", sv.HoTen);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Lop SH", sv.LopSH);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Gioi tinh", sv.GioiTinh);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Ngay sinh", sv.NgaySinh);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Diem trung binh", sv.DiemTB);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Anh", sv.Anh);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("Hoc ba", sv.HocBa);
                DuLieuSinhVien.Instance.DTSinhVien.Rows[index].SetField("CC Ngoai ngu", sv.CCNN);
            }
        }
        public void DeleteSV(List<string> data)
        {
            for(int i = 0; i < data.Count; i++)
            {
                List<SinhVien> LiSV = GetAllSV();
                for (int j = 0; j < data.Count; j++)
                {
                    if (LiSV[j].MSSV == data[i])
                    {
                        DuLieuSinhVien.Instance.DTSinhVien.Rows[j].Delete();
                        //DuLieuSinhVien.Instance.DTSinhVien.AcceptChanges();
                        break;
                    }
                }
            }
        }
    }
}
