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
    public partial class Main : Form
    {
        QuanLySinhVien QL = new QuanLySinhVien();
        public Main()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            LoadComboBox();
            LoadComboBoxSearch();
        }
        public void LoadComboBox()
        {
            this.cbbLopSH.Items.Add("All");
            foreach(string s in QL.GetDSLop().Distinct())
            {
                this.cbbLopSH.Items.Add(s);
            }
        }
        public void LoadComboBoxSearch()
        {
            string[] strSearch = new string[] { "Ho ten" , "Diem trung binh", "Ngay sinh"};
            this.cbbSort.Items.AddRange(strSearch);
        }
        private void Show(object o, EventArgs e)
        {
            string Lop = this.cbbLopSH.Text;
            string str = this.txtSearch.Text;
            this.dataSV.DataSource = QL.GetDSSV(Lop, str);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Detail form = new Detail();
            form.d += new Detail.Del(Show);
            form.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataSV.SelectedRows.Count == 1)
            {
                string MSSV = this.dataSV.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Detail form = new Detail(MSSV);
                form.d += new Detail.Del(Show);
                form.Show();
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if(this.dataSV.SelectedRows.Count >= 1)
            {
                List<string> data = new List<string>();
                foreach(DataGridViewRow i in this.dataSV.SelectedRows)
                {
                    data.Add(i.Cells["MSSV"].Value.ToString());
                }
                QL.DeleteSV(data);
                string Lop = this.cbbLopSH.Text;
                string str = this.txtSearch.Text;
                this.dataSV.DataSource = QL.GetDSSV(Lop, str);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(this.cbbSort.SelectedIndex > 0)
            {
                List<SinhVien> LiSV = QL.GetDSSV(this.cbbLopSH.Text, this.txtSearch.Text);
                switch (this.cbbSort.SelectedIndex)
                {
                    case 0: LiSV.Sort(new SortName());  break;
                    case 1: LiSV.Sort(new SortDiemTB()); break;
                    case 2: LiSV.Sort(new SortNgaySinh()); break;
                }
                this.dataSV.DataSource = LiSV;
            }
        }
    }
}
