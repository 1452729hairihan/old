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
    public partial class OpenForm : Form
    {
        protected OracleConnection conn;
        public OpenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String opensql = "select IS_SERVED from DINNING_TABLE where TABLE_NO='" + textBox2.Text.Trim().ToString() + "' ";
            OracleCommand cmd = new OracleCommand(opensql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            int isServed = int.Parse(a.ToString());
            if(isServed==1)//被占用
                MessageBox.Show("该餐桌有客人就餐或已被预约！", "提示");
            else
            {
                String opensql2 = " update DINNING_TABLE set IS_SERVED=1 where TABLE_NO=" + textBox2.Text.Trim().ToString();
                OracleCommand cmd2 = new OracleCommand(opensql2, conn);
                cmd2.CommandType = CommandType.Text;
                object b = cmd2.ExecuteScalar();
                MessageBox.Show("开台成功！", "提示");
                //时间 
                String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                String opensql3 = " update DINNING_TABLE set START_TIME = to_date('" + time + "','yyyy-MM-dd HH24:mi:ss') where TABLE_NO=" + textBox2.Text.Trim().ToString();
                OracleCommand cmd3 = new OracleCommand(opensql3, conn);
                cmd3.CommandType = CommandType.Text;
                object c = cmd3.ExecuteScalar();
                this.Hide();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
