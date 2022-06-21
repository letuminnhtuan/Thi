using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thi
{
    public partial class Detail : Form
    {
        QuanLySinhVien QL = new QuanLySinhVien();
        public delegate void Del(object o, EventArgs e);
        public Del d;
        private string MSSV;
        public Detail(string mssv = null)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            LoadComboBox();
            this.MSSV = mssv;
            Create();
        }
        public void Create()
        {
            if(MSSV != null)
            {
                SinhVien sv = QL.GetSVByMSSV(MSSV);
                this.txtMSSV.Enabled = false;
                this.txtMSSV.Text = sv.MSSV;
                this.txtHoTen.Text = sv.HoTen;
                this.cbbLSH.SelectedItem = sv.LopSH;
                if (sv.GioiTinh) this.radiobtnNam.Checked = true;
                else this.radiobtnNu.Checked = true;
                this.dateTimePicker1.Value = sv.NgaySinh;
                this.txtDiemTB.Text = sv.DiemTB.ToString();
                this.checkAnh.Checked = sv.Anh;
                this.checkHocBa.Checked = sv.HocBa;
                this.checkCCNN.Checked = sv.CCNN;
            }
        }
        public void LoadComboBox()
        {
            foreach (string s in QL.GetDSLop().Distinct())
            {
                this.cbbLSH.Items.Add(s);
            }
        }
        public SinhVien GetSV()
        {
            SinhVien sv = new SinhVien {
                MSSV = this.txtMSSV.Text,
                HoTen = this.txtHoTen.Text,
                LopSH = this.cbbLSH.Text,
                GioiTinh = this.radiobtnNam.Checked,
                NgaySinh = this.dateTimePicker1.Value,
                DiemTB = Convert.ToDouble(this.txtDiemTB.Text),
                Anh = this.checkAnh.Checked,
                HocBa = this.checkHocBa.Checked,
                CCNN = this.checkCCNN.Checked
            };
            return sv;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            QL.Run(GetSV(), MSSV);
            d(null, null);
            this.Dispose();
        }
    }
}
