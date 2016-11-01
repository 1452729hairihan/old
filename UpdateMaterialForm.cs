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
    public partial class UpdateMaterialForm : Form
    {
        protected OracleConnection conn;
        public UpdateMaterialForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Updatesql = "update MATERIAL set MATERIAL_AMOUNT='" + textBox2.Text.Trim().ToString() + "' where MATERIAL_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd = new OracleCommand(Updatesql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("修改成功！", "提示");
            this.Hide();
        }
    }
}
