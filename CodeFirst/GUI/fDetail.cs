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
            foreach (CBBItem i in this.cbbTenNguyenLieu.Items)
            {
                if (i.Value.Equals(this.TenNguyenLieu))
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
                this.cbbDonViTinh.Text = data.DonViTinh;
                int TT = (data.TinhTrang) ? 1 : 0;
                foreach (CBBItem i in this.cbbTinhTrang.Items)
                {
                    if (i.Key == TT)
                    {
                        this.cbbTenNguyenLieu.SelectedItem = i;
                        break;
                    }
                }
            }
        }
    }
}
