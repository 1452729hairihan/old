using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace RestService
{
    public partial class SelectClerkForm : Form
    {
        protected OracleConnection conn;
        public SelectClerkForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "select * from STAFF_INFO where STAFF_ID=" + textBox1.Text.Trim().ToString();
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;
        }

        private void SelectClerkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
