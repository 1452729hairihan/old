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
    public partial class DetailedDishForm : Form
    {
        protected OracleConnection conn;
        public DetailedDishForm()
        {
            InitializeComponent();
        }

        private void DetailedDishForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "SELECT * FROM DISH_INFO";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;

            string queryString1 = "SELECT * FROM DISH_EVALUATION";
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView2.DataSource = dtbl1;
        }
    }
}
