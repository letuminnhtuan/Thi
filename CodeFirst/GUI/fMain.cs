using CodeFirst.BLL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst.GUI
{
    public partial class fMain : Form
    {
        public fMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.cbbMonAn.Items.AddRange(BLL_QL.Instance.GetCBBMonAn().ToArray());
        }
        public void LoadData()
        {
            if (this.cbbMonAn.SelectedIndex >= 0)
            {
                this.dataGridView1.Rows.Clear();
                int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
                string txtSearch = this.txtSearch.Text;
                foreach (MA_NL i in BLL_QL.Instance.GetDSNguyenLieu(MaMonAn, txtSearch))
                {
                    this.dataGridView1.Rows.Add(i.TenNguyenLieu, i.SoLuong, i.DonViTinh, i.TinhTrang);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
            fDetail f = new fDetail(MaMonAn, "");
            f.Show();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 1)
            {
                int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
                string TenNguyenLieu = this.dataGridView1.SelectedRows[0].Cells["colTenNguyenLieu"].Value.ToString();
                fDetail f = new fDetail(MaMonAn, TenNguyenLieu);
                f.Show();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
