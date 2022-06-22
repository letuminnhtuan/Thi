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
        private object cbbThanhPho;

        public fDetail()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.cbbTinhThanh.Items.AddRange(BLL_QL.Instance.GetCBBTinh().ToArray());
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
    }
}
