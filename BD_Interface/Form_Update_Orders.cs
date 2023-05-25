using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_Interface
{
    public partial class Form_Update_Orders : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");
        public Form_Update_Orders()
        {
            InitializeComponent();
        }

        private void Form_Update_Orders_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label2.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Text = "";
                textBox2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label3.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBox3.Text = "";
                textBox3.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                label4.Visible = true;
                label5.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                textBox4.Text = "";
                textBox4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            conn.Open();
            string carCode_upd = (textBox2.Text == "") ? "" : "UPDATE orders SET car_code='" + textBox2.Text + "' WHERE id=" + textBox1.Text + ";";
            string ownerCode_upd = (textBox3.Text == "") ? "" : "UPDATE orders SET owner_code='" + textBox3.Text + "' WHERE id=" + textBox1.Text + ";";
            string delDate_upd = (textBox4.Text == "") ? "" : "UPDATE orders SET delivery_date='" + textBox4.Text + "' WHERE id=" + textBox1.Text + ";";

            string update_string = carCode_upd + ownerCode_upd + delDate_upd;
            var cmd = conn.CreateCommand();
            cmd.CommandText = update_string;
            try
            {
                if (textBox1.Text == "") throw new Exception();
                if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
                {
                    throw new Exception();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Введите № Заказа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Заполните хотя бы одно поле!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
