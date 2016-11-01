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
    public partial class PaymethodForm : Form
    {
        protected OracleConnection conn;
        protected String method;
        public PaymethodForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PaymethodForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("现金支付");
            comboBox1.Items.Add("支付宝支付");
            comboBox1.Items.Add("网银刷卡");
            comboBox1.Items.Add("微信支付");
            comboBox1.Items.Add("储值卡支付");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            method = comboBox1.SelectedItem.ToString();

            String updatesql = "insert into PAYMENT values(b.nextval,a.nextval," + textBox1.Text.Trim().ToString() + ",sysdate,'" + method + "')";
            //String updatesql = "insert into PAYMENT values(b.nextval,a.nextval,100,sysdate,'支付宝支付')";
            OracleCommand cmd3 = new OracleCommand(updatesql, conn);
            cmd3.CommandType = CommandType.Text;
            object c = cmd3.ExecuteScalar();
            this.Hide();
            String updatesql2 = "update BILL set IS_PAID=1 where ORDER_NO="+ CasherForm.t;
            //String updatesql2 = "select IS_PAID from BILL where ORDER_NO=500002";
            OracleCommand cmd4 = new OracleCommand(updatesql2, conn);
            cmd4.CommandType = CommandType.Text;
            object d = cmd4.ExecuteScalar();
            MessageBox.Show("结账成功！", "提示");

        }
    }

}
