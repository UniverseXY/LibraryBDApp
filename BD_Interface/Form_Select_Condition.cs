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
    public partial class Form_Select_Condition : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");
        public Form_Select_Condition()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {

            conn.Open();
            List<string[]> data = new List<string[]>();
            string query = "SELECT id, brand, model, release_year FROM `cars` WHERE brand = 'Audi' AND SUBSTR(model, 1, 1) = 'Q' AND release_year > 2018";

            var cmd = conn.CreateCommand();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(new string[reader.FieldCount]);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }

                }
            }
            reader.Close();
            conn.Close();
            foreach (string[] s in data)
            {
              dataGridView1.Rows.Add(s);
            }

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];


                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                c.ContextMenuStrip = contextMenuStrip2;
                if (c.RowIndex == dataGridView1.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                }
                else if (c.ColumnIndex == 0)
                {
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                }
                else {
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                }
                //c.ContextMenuStrip.Show(dataGridView1, e.Location);
            }
        }
    }
}
