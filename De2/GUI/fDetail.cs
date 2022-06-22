using De2.BLL;
using De2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De2.GUI
{
    public partial class fDetail : Form
    {
        private string MaTP;
        private int MaNCC;
        private string MaSP;
        public fDetail(string MaTP, int MaNCC, string MaSP)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.cbbTinhThanh.Items.AddRange(BLL_QL.Instance.GetCBBTinh().ToArray());
            this.MaTP = MaTP;
            this.MaNCC = MaNCC;
            this.MaSP = MaSP;
            SetGUI();
        }
        public void SetGUI()
        {
            if(BLL_QL.Instance.GetSanPham(MaNCC, MaSP) != null)
            {
                SanPham data = BLL_QL.Instance.GetSanPham(MaNCC, MaSP);
                this.txtMaSanPham.Text = data.MaSanPham;
                this.txtMaSanPham.Enabled = false;
                this.txtTenSanPham.Text = data.TenSanPham;
                this.txtGiaNhap.Text = data.GiaNhap.ToString();
                this.txtSoLuong.Text = data.SoLuong.ToString();
                this.dateNhap.Value = data.NgayNhapHang;
                foreach(CBBItem i in this.cbbTinhThanh.Items)
                {
                    if (i.Key.Equals(data.MaThanhPho))
                    {
                        this.cbbTinhThanh.SelectedItem = i;
                        break;
                    }
                }
                foreach (CBBItem i in this.cbbNhaCungCap.Items)
                {
                    if (i.Key.Equals(data.MaNCC.ToString()))
                    {
                        this.cbbNhaCungCap.SelectedItem = i;
                        break;
                    }
                }
            }
        }
        private void cbbTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbTinhThanh.SelectedIndex >= 0)
            {
                this.cbbNhaCungCap.Text = "";
                string MaTP = ((CBBItem)this.cbbTinhThanh.SelectedItem).Key;
                this.cbbNhaCungCap.Items.Clear();
                this.cbbNhaCungCap.Items.AddRange(BLL_QL.Instance.GetCBBNCC(MaTP).ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham data = new SanPham
            {
                MaSanPham = this.txtMaSanPham.Text,
                TenSanPham = this.txtTenSanPham.Text,
                GiaNhap = float.Parse(this.txtGiaNhap.Text),
                SoLuong = Convert.ToInt32(this.txtSoLuong.Text),
                NgayNhapHang = this.dateNhap.Value,
                MaNCC = Convert.ToInt32(((CBBItem)this.cbbNhaCungCap.SelectedItem).Key),
                MaThanhPho = ((CBBItem)this.cbbTinhThanh.SelectedItem).Key
            };
            BLL_QL.Instance.AddUpdateSP(data);
        }
    }
}
