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
    public partial class Form1 : Form
    {
        private DataGridViewCell currCell;
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");

        public Form1()
        {
            InitializeComponent();
          /*  dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();*/
            LoadData(1);
            LoadData(2);
            LoadData(3);

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                currCell = c;

                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                c.ContextMenuStrip = contextMenuStrip1;
                c.ContextMenuStrip.Items["Delete"].Text = "Удалить";
                c.ContextMenuStrip.Items["Add"].Text = "Добавить авто";
                if (c.RowIndex == dataGridView1.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = true;
                }
                if (c.RowIndex == dataGridView1.RowCount - 1 && c.ColumnIndex != 0)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                if (c.ColumnIndex == 0 && c.RowIndex != dataGridView1.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }

                else if (c.ColumnIndex != 0 && c.RowIndex != dataGridView1.RowCount - 1)
                {
                    if (c.ColumnIndex == 4 && currCell.Value.ToString() != "") c.ContextMenuStrip.Items["Delete"].Visible = true;
                    else c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                //c.ContextMenuStrip.Show(dataGridView1, e.Location);
            }
        }
        private void LoadData(int table_id)
        {
           
            conn.Open();
            List<string[]> data = new List<string[]>();
           // var conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234");
          //  conn.Open();
            string query = "";
            if (table_id == 1)
            {
                query = "SELECT * FROM cars";
            }
            else if (table_id == 2)
            {
                query = "SELECT * FROM owners";
            }
            else if (table_id == 3)
            {
                query = "SELECT `id`, `car_code`, `owner_code`, SUBSTR(delivery_date,1,10) FROM `orders`";
            }

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
                if (table_id == 1) dataGridView1.Rows.Add(s);
                else if (table_id == 2) dataGridView2.Rows.Add(s);
                else if (table_id == 3) dataGridView3.Rows.Add(s);
            }
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                currCell = c;

                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                c.ContextMenuStrip = contextMenuStrip1;
                c.ContextMenuStrip.Items["Delete"].Text = "Удалить";
                c.ContextMenuStrip.Items["Add"].Text = "Добавить владельца";
                if (c.RowIndex == dataGridView2.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = true;
                }
                if (c.RowIndex == dataGridView2.RowCount - 1 && c.ColumnIndex != 0)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                if (c.ColumnIndex == 0 && c.RowIndex != dataGridView2.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                else if (c.ColumnIndex != 0 && c.RowIndex != dataGridView2.RowCount - 1)
                {
                    if (c.ColumnIndex == 3 && currCell.Value.ToString() != "") c.ContextMenuStrip.Items["Delete"].Visible = true;
                    else c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                //c.ContextMenuStrip.Show(dataGridView1, e.Location);
            }
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                currCell = c;

                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                c.ContextMenuStrip = contextMenuStrip1;
                c.ContextMenuStrip.Items["Delete"].Text = "Удалить заказ";
                c.ContextMenuStrip.Items["Add"].Text = "Добавить заказ";
                if (c.RowIndex == dataGridView3.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = true;
                }
                if (c.RowIndex == dataGridView3.RowCount - 1 && c.ColumnIndex != 0)
                 {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = false;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                 }
                if (c.ColumnIndex == 0 && c.RowIndex != dataGridView3.RowCount - 1)
                {
                    c.ContextMenuStrip.Items["Delete"].Visible = true;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                else if (c.ColumnIndex != 0 && c.RowIndex != dataGridView3.RowCount - 1) {
                    c.ContextMenuStrip.Items["Delete"].Visible = false;
                    c.ContextMenuStrip.Items["Edit"].Visible = true;
                    c.ContextMenuStrip.Items["Add"].Visible = false;
                }
                //c.ContextMenuStrip.Show(dataGridView1, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //DataGridViewCell c = (sender as DataGridView).CurrentCell;
           
                conn.Open();
                int flag = 1;
                string add_Str = "";
               
            if (currCell.DataGridView == dataGridView1)
            {
                add_Str = "cars WHERE release_year=";
                flag = 1;
                dataGridView1.Rows.Clear();
            }
            if (currCell.DataGridView == dataGridView2)
            {
                add_Str = "owners WHERE middlename=";
                flag = 2;
                dataGridView2.Rows.Clear();
            }
            if (currCell.DataGridView == dataGridView3)
            {
                add_Str = "orders WHERE id=";
                flag = 3;
                dataGridView3.Rows.Clear();
            }
           
            var cmd = conn.CreateCommand();
            string del_string = "DELETE FROM " + add_Str + currCell.Value.ToString() + ";";
            cmd.CommandText = del_string;
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData(flag);

        }

        private void Delete_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (currCell.DataGridView == dataGridView1)
            {
                Form_Insert_Auto f1 = new Form_Insert_Auto();
                f1.Show();
                /*dataGridView1.Rows.Clear();
                LoadData(1);*/
            }
            else if (currCell.DataGridView == dataGridView2)
            {
                Form_Insert_Owners f2 = new Form_Insert_Owners();
                f2.Show();
                /*dataGridView2.Rows.Clear();
                LoadData(2);*/
            }
            else {
                Form_Insert_Orders f3 = new Form_Insert_Orders();
                f3.Show();
               /* dataGridView3.Rows.Clear();
                LoadData(3);*/
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            currCell.ReadOnly = false;
            currCell.Value = "";
            if (currCell.DataGridView == dataGridView1) dataGridView1.BeginEdit(true);
            else if (currCell.DataGridView == dataGridView2) dataGridView2.BeginEdit(true);
            else dataGridView3.BeginEdit(true);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            string col_name = "";
            string id_Str = currCell.OwningRow.Cells[0].Value.ToString();
            if (currCell.OwningColumn.Name.ToString() == "owner_id") col_name = "id";
            if (currCell.OwningColumn.Name.ToString() == "lastname") col_name = "lastname";
            if (currCell.OwningColumn.Name.ToString() == "firstname") col_name = "firstname";
            if (currCell.OwningColumn.Name.ToString() == "middlename") col_name = "middlename";
            if (currCell.OwningColumn.Name.ToString() == "phone_number") col_name = "phone_number";
            if (currCell.OwningColumn.Name.ToString() == "bonus_card") col_name = "bonus_card";

            var cmd = conn.CreateCommand();
            string upd_string = "UPDATE owners SET " + col_name + "= '" + currCell.Value.ToString() + "' WHERE id= " +id_Str + ";";
            cmd.CommandText = upd_string;
            cmd.ExecuteNonQuery();
            conn.Close();
            dataGridView2.Rows.Clear();
            currCell.ReadOnly = true;
            LoadData(2);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            string col_name = "";
            string id_Str = currCell.OwningRow.Cells[0].Value.ToString();
            if (currCell.OwningColumn.Name.ToString() == "car_id") col_name = "id";
            if (currCell.OwningColumn.Name.ToString() == "brand_name") col_name = "brand";
            if (currCell.OwningColumn.Name.ToString() == "model_name") col_name = "model";
            if (currCell.OwningColumn.Name.ToString() == "color_name") col_name = "color";
            if (currCell.OwningColumn.Name.ToString() == "Release_year") col_name = "release_year";

            var cmd = conn.CreateCommand();
            string upd_string = "UPDATE cars SET " + col_name + "= '" + currCell.Value.ToString() + "' WHERE id= " + id_Str + ";";
            cmd.CommandText = upd_string;
            cmd.ExecuteNonQuery();
            conn.Close();
            dataGridView1.Rows.Clear();
            currCell.ReadOnly = true;
            LoadData(1);
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            string col_name = "";
            string id_Str = currCell.OwningRow.Cells[0].Value.ToString();
            if (currCell.OwningColumn.Name.ToString() == "order_id") col_name = "id";
            if (currCell.OwningColumn.Name.ToString() == "car_code") col_name = "car_code";
            if (currCell.OwningColumn.Name.ToString() == "owner_code") col_name = "owner_code";
            if (currCell.OwningColumn.Name.ToString() == "delivery_date") col_name = "delivery_date";
    
            var cmd = conn.CreateCommand();
            string upd_string = "UPDATE orders SET " + col_name + "= '" + currCell.Value.ToString() + "' WHERE id= " + id_Str + ";";
            cmd.CommandText = upd_string;
            cmd.ExecuteNonQuery();
            conn.Close();
            dataGridView3.Rows.Clear();
            currCell.ReadOnly = true;
            LoadData(3);
        }

        /*  private void dataGridView3_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
          {
              e.ContextMenuStrip = contextMenuStrip1;
          }*/

        /* private void dataGridView3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
         {
             currCell_evnt = e;
             currCell = dataGridView3.CurrentCell;
         }*/
    }
 }

