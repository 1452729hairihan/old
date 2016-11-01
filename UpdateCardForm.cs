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
    public partial class UpdateCardForm : Form
    {
        protected OracleConnection conn;
        public UpdateCardForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Updatesql = "update PREPAID_CARD set PREPAID_NO=" + textBox1.Text.Trim().ToString() + ",PASSWORD='" + textBox2.Text.Trim().ToString() + "',BALANCE=" + textBox3.Text.Trim().ToString() + "where PREPAID_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd = new OracleCommand(Updatesql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("修改成功！", "提示");
            this.Hide();
        }
    }
}
