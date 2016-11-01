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
    public partial class UpdateCleaningForm : Form
    {
        protected OracleConnection conn;
        public UpdateCleaningForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Updatesql = "update CLEANING set CLEANING_TIME=sysdate where CLEANING_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd = new OracleCommand(Updatesql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("更新成功！", "提示");
            this.Hide();
        }
    }
}
