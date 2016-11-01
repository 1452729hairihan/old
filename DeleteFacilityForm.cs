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
    public partial class DeleteFacilityForm : Form
    {
        protected OracleConnection conn;
        public DeleteFacilityForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();

            String searchsql0 = "select * from FACILITIES where FACILITY_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd1 = new OracleCommand(searchsql0, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();

            if (b != null)
            {
                String Deletesql = "delete from FACILITIES where FACILITY_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand cmd = new OracleCommand(Deletesql, conn);
                cmd.CommandType = CommandType.Text;
                object a = cmd.ExecuteScalar();
                MessageBox.Show("删除成功！", "提示");
                this.Hide();
            }
            else
            {
                MessageBox.Show("该设施不存在，请再次确认！", "提示");
            }
        }
    }
}
