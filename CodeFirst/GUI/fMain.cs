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
                    this.dataGridView1.Rows.Add(i.MaNguyenLieu, i.TenNguyenLieu, i.SoLuong, i.DonViTinh, i.TinhTrang);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cbbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
            fDetail f = new fDetail(MaMonAn, "");
            f.d = new fDetail.Del(LoadData);
            f.Show();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 1)
            {
                string TenNguyenLieu = this.dataGridView1.SelectedRows[0].Cells["colID"].Value.ToString();
                MessageBox.Show(TenNguyenLieu);
                //int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
                //string TenNguyenLieu = this.dataGridView1.SelectedRows[0].Cells["colTenNguyenLieu"].Value.ToString();
                //fDetail f = new fDetail(MaMonAn, TenNguyenLieu);
                //f.d = new fDetail.Del(LoadData);
                //f.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
                string TenNguyenLieu = this.dataGridView1.SelectedRows[0].Cells["colTenNguyenLieu"].Value.ToString();
                int MaNguyenLieu = 0;
                foreach(CBBItem i in BLL_QL.Instance.GetCBBNguyenLieu())
                {
                    if (i.Value.Equals(TenNguyenLieu))
                    {
                        MaNguyenLieu = i.Key;
                        break;
                    }
                }
                BLL_QL.Instance.DeleteNL(MaMonAn, MaNguyenLieu);
                LoadData();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(this.cbbSort.SelectedIndex >= 0)
            {
                this.dataGridView1.Rows.Clear();
                string txtSort = this.cbbSort.Text;
                int MaMonAn = ((CBBItem)this.cbbMonAn.SelectedItem).Key;
                string txtSearch = this.txtSearch.Text;
                foreach (MA_NL i in BLL_QL.Instance.Sort(txtSort, MaMonAn, txtSearch))
                {
                    this.dataGridView1.Rows.Add(i.TenNguyenLieu, i.SoLuong, i.DonViTinh, i.TinhTrang);
                }
            }

        }
    }
}
