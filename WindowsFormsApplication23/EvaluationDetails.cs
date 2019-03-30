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
    public partial class EvaluationDetails : Form
    {
        public EvaluationDetails()
        {
            InitializeComponent();
        }

        private void EvaluationDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet4.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet4.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
