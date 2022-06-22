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
    public partial class fMain : Form
    {
        public fMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.cbbThanhPho.Items.Add(new CBBItem { Key = "All", Value = "All" });
            this.cbbThanhPho.Items.AddRange(BLL_QL.Instance.GetCBBTinh().ToArray());
        }
        public void LoadData()
        {
            this.dataGridView1.Rows.Clear();
            string MaTP = ((CBBItem)this.cbbThanhPho.SelectedItem).Key;
            int MaNCC = 0;
            if (this.cbbNhaCungCap.SelectedIndex >= 0) MaNCC = Convert.ToInt32(((CBBItem)this.cbbNhaCungCap.SelectedItem).Key);
            string txtSearch = this.txtSearch.Text;
            foreach(SanPham i in BLL_QL.Instance.GetDSSP(MaTP, MaNCC, txtSearch))
            {
                this.dataGridView1.Rows.Add(i.MaSanPham, i.TenSanPham, i.GiaNhap, i.NgayNhapHang, BLL_QL.Instance.GetNCCByMaNCC(i.MaNCC), BLL_QL.Instance.GetTenTPByMaTP(i.MaThanhPho));
            }
        }

        private void cbbThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cbbThanhPho.SelectedIndex >= 0)
            {
                this.cbbNhaCungCap.Text = "";
                string MaTP = ((CBBItem)this.cbbThanhPho.SelectedItem).Key;
                this.cbbNhaCungCap.Items.Clear();
                this.cbbNhaCungCap.Items.AddRange(BLL_QL.Instance.GetCBBNCC(MaTP).ToArray());
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            fDetail f = new fDetail("", 0, "");
            f.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 1)
            {
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                string MaTP = ((CBBItem)this.cbbThanhPho.SelectedItem).Key;
                int MaNCC = 0;
                if (this.cbbNhaCungCap.SelectedIndex >= 0) MaNCC = Convert.ToInt32(((CBBItem)this.cbbNhaCungCap.SelectedItem).Key);
                string MaSanPham = this.dataGridView1.SelectedRows[0].Cells["colID"].Value.ToString();
                fDetail f = new fDetail(MaTP, MaNCC, MaSanPham);
                f.Show();
            }
        }

    }
}
