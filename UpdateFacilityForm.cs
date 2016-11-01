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
    public partial class UpdateFacilityForm : Form
    {
        protected OracleConnection conn;
        String upFacility;
        public UpdateFacilityForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            upFacility = textBox1.Text.Trim().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Updatesql = "update FACILITIES set FACILITY_STATE='" + textBox2.Text.Trim().ToString() +"' where FACILITY_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd = new OracleCommand(Updatesql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("更新成功！", "提示");
            this.Hide();
        }
    }
}
