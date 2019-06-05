﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Student_management
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Point PW;
        bool Move1;
        bool Move2;
        bool flag;
        public Form1()
        {
            InitializeComponent();
            PW = panel4.Location;
            Move1 = false;
            Move2 = false;
            
            

        }
        int selectedRow;
        DataTable table = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
           
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            teacherMetroGrid.DataSource = table;



        }

        private void TableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.student_info);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                int idnew = Int32.Parse(idTextBox.Text);
                try {
                    int n;
                    bool isNumeric = true;
                    isNumeric = int.TryParse(last_NameTextBox.Text, out n);
                    if (isNumeric == true)
                    {
                        throw new FormatException();                       
                    }
                    
                    table.Rows.Add(idnew, nameTextBox.Text, last_NameTextBox.Text);
                    teacherMetroGrid.DataSource = table;
                }
                catch(FormatException ex2)
                {
                    MessageBox.Show("hiiiiii");

                }
                
            }
            catch(FormatException ex)
            {
                MessageBox.Show("The new ID should be a number");
            }
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel4.Height = button1.Height;
            //panel4.Top = button1.Top;

            //panel4.Location = new Point(318, 187);
            timer1.Start();
            Move2 = true;
          

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            //change panel 4 postion to the same as button
            //panel4.Location = new Point(318,360);
            timer1.Start();
            Move1 = true;
            

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Custom_Button1_Click(object sender, EventArgs e)
        {

        }

        private void Custom_Button2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Move1)
            {               
                panel4.Top += 30;

                    if (panel4.Top >= 340)
                    {
                        timer1.Stop();
                        Move1 = false;
                        this.Refresh();
                    //panel4.Top -= 30;

                }
                

            }
            if (Move2)
            {
                
                panel4.Top -= 30;
                
                if (panel4.Top <= 190)
                {
                    timer1.Stop();
                    Move2 = false;
                    this.Refresh();
                    //panel4.Top += 30;
                }
                
            }
        }

        private void TeacherDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = teacherMetroGrid.Rows[selectedRow];
            idTextBox.Text = row.Cells[0].Value.ToString();
            nameTextBox.Text = row.Cells[1].Value.ToString();
            last_NameTextBox.Text = row.Cells[2].Value.ToString();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {            
            DataView table = new DataView(student_info.Teacher);
            table.RowFilter = string.Format("Name LIKE '%{0}%'", textBox1.Text);
            teacherMetroGrid.DataSource = table;
            
            
        }
    }
}
