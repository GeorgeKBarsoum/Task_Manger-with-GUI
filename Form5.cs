using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager_GUI
{
    public partial class Form5 : Form
    {
        Dictionary<string, Task> map5 = new Dictionary<string, Task>();
        //copies the passed map to use it in this form
        public Form5(Dictionary<string, Task> d)
        {
            map5 = d;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map5);
            f1.Close();
        }

        //the "Search" Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool found = false;
            //checks if the user left the name field empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please Enter a name first", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            {
                //checks if the enterd name exists and displays the task if it does
                if (map5.ContainsKey(textBox1.Text))
                {
                    this.dataGridView1.Rows.Add(new object[] { map5[textBox1.Text].id, map5[textBox1.Text].name, map5[textBox1.Text].desription, map5[textBox1.Text].dateStr, map5[textBox1.Text].finished });
                }
                else
                {
                    MessageBox.Show("Task not found", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map5);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map5);
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        //clears the dataGridView
        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
