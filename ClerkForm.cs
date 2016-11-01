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
    public partial class ClerkForm : Form
    {
        protected OracleConnection conn;
        public ClerkForm()
        {
            InitializeComponent();
        }

        private void ClerkForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "SELECT * FROM STAFF_INFO";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertClerkForm iForm = new InsertClerkForm();
            iForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateClerkForm upForm = new UpdateClerkForm();
            upForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectClerkForm seForm = new SelectClerkForm();
            seForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AttendanceForm atForm = new AttendanceForm();
            atForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DismissForm dissForm = new DismissForm();
            dissForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClerkForm_Load(sender, e);
        }
    }
}
