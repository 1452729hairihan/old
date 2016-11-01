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
    public partial class PayForm : Form
    {
        protected OracleConnection conn;
        public static int result;
        public PayForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();           
            String opensql = "select IS_SERVED from DINNING_TABLE where TABLE_NO='" + textBox1.Text.Trim().ToString() + "' ";
            OracleCommand cmd = new OracleCommand(opensql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            int isServed = int.Parse(a.ToString());
            if (isServed == 0)//未被占用
                MessageBox.Show("该餐桌还没有客人就餐，无法结账！", "提示");
            else
            {
                string queryString1 = "SELECT DISH_NAME,DISH_AMOUNT,PRICE FROM ORDER_LIST natural join MENU WHERE TABLE_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand Command1 = conn.CreateCommand();
                Command1.CommandText = queryString1;
                OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
                DataSet ds1 = new DataSet();
                oraDA1.Fill(ds1);
                DataTable dtbl1 = ds1.Tables[0];
                this.dataGridView1.DataSource = dtbl1;

                String opensql2 = " update DINNING_TABLE set IS_SERVED=0 where TABLE_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand cmd2 = new OracleCommand(opensql2, conn);
                cmd2.CommandType = CommandType.Text;
                object b = cmd2.ExecuteScalar();
                MessageBox.Show("结账成功！", "提示");
                //时间 
                /*String opensql3 = " update DINNING_TABLE set START_TIME = to_date(sysdate,'yyyy-MM-dd hh24:mi:ss') where TABLE_NO=" +textBox2.Text.Trim().ToString();
                OracleCommand cmd3 = new OracleCommand(opensql3, conn);
                cmd3.CommandType = CommandType.Text;
                object c = cmd3.ExecuteScalar();*/
                string sql = "select*from ORDER_LIST where TABLE_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand cmd3 = new OracleCommand(sql, conn);
                cmd3.CommandType = CommandType.Text;
                object c = cmd3.ExecuteScalar();
                if (c != null)
                {
                    string queryString2 = "select sum(DISH_AMOUNT*PRICE) from  ORDER_LIST natural join MENU WHERE TABLE_NO=" + textBox1.Text.Trim().ToString();
                    OracleCommand Command2 = conn.CreateCommand();
                    Command2.CommandText = queryString2;
                    object d = Command2.ExecuteScalar();
                    result = int.Parse(d.ToString());
                    label2.Text = "总金额：" + result + "元";
                }
                else
                {
                    this.Hide();
                }
            }
        }
    }
}
