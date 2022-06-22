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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
