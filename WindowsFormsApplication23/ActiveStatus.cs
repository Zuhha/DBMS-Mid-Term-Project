using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class ActiveStatus : Form
    {
        public ActiveStatus()
        {
            InitializeComponent();
        }

        private void ActiveStatus_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet7.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet7.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
