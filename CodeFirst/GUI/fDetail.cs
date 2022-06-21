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
    public partial class fDetail : Form
    {
        public delegate void Del();
        public Del d;
        private int MaMonAn;
        private string TenNguyenLieu;
        public fDetail(int MaMonAn, string TenNguyenLieu)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.cbbTinhTrang.Items.AddRange(new CBBItem[]
            {
                new CBBItem { Key = 0, Value = "Chua nhap hang" },
                new CBBItem { Key = 1, Value = "Da nhap hang" },
            });
            this.cbbTenNguyenLieu.Items.AddRange(BLL_QL.Instance.GetCBBNguyenLieu().ToArray());
            this.MaMonAn = MaMonAn;
            this.TenNguyenLieu = TenNguyenLieu;
            SetGUI();
        }
        public void SetGUI()
        {
            int MaNguyenLieu = 0;
            foreach (CBBItem i in BLL_QL.Instance.GetCBBNguyenLieu())
            {
                if (i.Value.Equals(TenNguyenLieu))
                {
                    MaNguyenLieu = i.Key;
                    break;
                }
            }
            if (BLL_QL.Instance.GetNguyenLieuByMonAn(MaMonAn, MaNguyenLieu) != null)
            {
                MA_NL data = BLL_QL.Instance.GetNguyenLieuByMonAn(MaMonAn, MaNguyenLieu);
                foreach (CBBItem i in this.cbbTenNguyenLieu.Items)
                {
                    if (i.Key == data.MaNguyenLieu)
                    {
                        this.cbbTenNguyenLieu.SelectedItem = i;
                        break;
                    }
                }
                this.cbbTenNguyenLieu.Enabled = false;
                this.txtSoLuong.Text = data.SoLuong.ToString();
                this.cbbDonViTinh.Text = data.DonViTinh;
                int TT = (data.TinhTrang) ? 1 : 0;
                foreach (CBBItem i in this.cbbTinhTrang.Items)
                {
                    if (i.Key == TT)
                    {
                        this.cbbTinhTrang.SelectedItem = i;
                        break;
                    }
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            MA_NL data = new MA_NL
            {
                MaMonAn = this.MaMonAn,
                SoLuong = Convert.ToInt32(this.txtSoLuong.Text),
                DonViTinh = this.cbbDonViTinh.Text,
                MaNguyenLieu = ((CBBItem)this.cbbTenNguyenLieu.SelectedItem).Key,
                TenNguyenLieu = ((CBBItem)this.cbbTenNguyenLieu.SelectedItem).Value,
                TinhTrang = (((CBBItem)this.cbbTinhTrang.SelectedItem).Key == 1) ? true : false,
            };
            BLL_QL.Instance.AddUpdateNL(data);
            d();
        }
    }
}
