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
    public partial class FormBegin : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id = root;password=1234; Database = car_service");
        public FormBegin()
        {
            InitializeComponent();
            label8.Text = "\u2B24";
            label9.Text = "\u2B24";
            label11.Text = "\u2B24";
            label13.Text = "\u2B24";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form_Insert_Auto f2 = new Form_Insert_Auto();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Insert_Owners f3 = new Form_Insert_Owners();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Insert_Orders f4 = new Form_Insert_Orders();
            f4.Show();
        }

        private void FormBegin_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Введите № записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) MessageBox.Show("Выберите таблицу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    string add_str = "";
                    if (radioButton1.Checked) add_str = " cars WHERE id= ";
                    else if (radioButton2.Checked) add_str = "owners WHERE id= ";
                    else add_str = "orders WHERE id= ";
                    DeleteData(add_str);
                    MessageBox.Show("Удалено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DeleteData(string a_str)
        {
            conn.Open();

            string del_string = "DELETE FROM " + a_str + textBox1.Text;
            var cmd = conn.CreateCommand();
            cmd.CommandText = del_string;
            cmd.ExecuteNonQuery();
            conn.Close(); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form_Update_Auto f5 = new Form_Update_Auto();
            f5.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form_Update_Owners f6 = new Form_Update_Owners();
            f6.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_Update_Orders f7 = new Form_Update_Orders();
            f7.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form_Select_Condition f8 = new Form_Select_Condition();
            f8.Show();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.MediumBlue;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.MediumBlue;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Black;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form_Select_GroupBy f9 = new Form_Select_GroupBy();
            f9.Show();
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.ForeColor = Color.MediumBlue;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Black;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form_Select_Multitable f10 = new Form_Select_Multitable();
            f10.Show();
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            label14.ForeColor = Color.MediumBlue;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Black;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Form_Select_NestedQueries f11 = new Form_Select_NestedQueries();
            f11.Show();
        }
    }
}
