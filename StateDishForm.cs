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
    public partial class StateDishForm : Form
    {
        protected OracleConnection conn;
        public StateDishForm()
        {
            InitializeComponent();
        }

        private void StateDishForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "SELECT * FROM DISH_STATE";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;
        }
    }
}
