using CodeFirst.BLL;
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
            InitializeComponent();
            this.cbbMonAn.Items.AddRange(BLL_QL.Instance.GetCBBMonAn().ToArray());
        }

    }
}
