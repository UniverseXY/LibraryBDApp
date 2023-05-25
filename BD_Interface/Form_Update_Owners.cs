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
    public partial class Form_Update_Owners : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");
        public Form_Update_Owners()
        {
            InitializeComponent();
        }

        private void Form_Update_Owners_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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
                textBox4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox4.Text = "";
                textBox4.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                label5.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox5.Text = "";
                textBox5.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                label7.Visible = true;
                textBox6.Visible = true;
            }
            else
            {
                label7.Visible = false;
                textBox6.Text = "";
                textBox6.Visible = false;
            }
        }
        private void UpdateData()
        {
            conn.Open();
            string ln_upd = (textBox2.Text == "") ? "" : "UPDATE owners SET lastname='" + textBox2.Text + "' WHERE id=" + textBox1.Text + ";";
            string fn_upd = (textBox3.Text == "") ? "" : "UPDATE owners SET firstname='" + textBox3.Text + "' WHERE id=" + textBox1.Text + ";";
            string mn_upd = (textBox4.Text == "") ? "" : "UPDATE owners SET middlename='" + textBox4.Text + "' WHERE id=" + textBox1.Text + ";";
            string tel_upd = (textBox5.Text == "") ? "" : "UPDATE owners SET phone_number='" + textBox5.Text + "' WHERE id=" + textBox1.Text + ";";
            string bonus_upd = (textBox6.Text == "") ? "" : "UPDATE owners SET bonus_card='" + textBox6.Text + "' WHERE id=" + textBox1.Text + ";";
            string update_string = ln_upd + fn_upd + mn_upd + tel_upd + bonus_upd;
            var cmd = conn.CreateCommand();
            cmd.CommandText = update_string;
            try
            {
                if (textBox1.Text == "") throw new Exception();
                if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox5.Text == "")
                {
                    throw new Exception();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Введите № Владельца!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
            
        }
    }
}
