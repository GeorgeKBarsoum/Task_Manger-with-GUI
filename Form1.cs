using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager_GUI
{
    public partial class Form1 : Form
    {
        Dictionary<string, Task> map = new Dictionary<string, Task>();
        //copies the passed map to use it;
        public Form1(Dictionary<string, Task> m)
        {
            map = m;
            InitializeComponent();
        }

        //opends the "Add" Form
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(map);
            this.Hide();
            f2.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.ExitThread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //displays the contents of the map when the form loads
            foreach (KeyValuePair<string, Task> entry in map)
            {
                this.dataGridView2.Rows.Add(new object[] {entry.Value.id, entry.Key, entry.Value.desription, entry.Value.dateStr, entry.Value.finished });
                Debug.WriteLine(entry.Key);
            }
        }
        //opens the "Remove" Form
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(map);
            this.Hide();
            f3.ShowDialog();
        }
        //opends the "Edit" Form
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(map);
            this.Hide();
            f4.ShowDialog();
        }
        //opens a search form depending on the comboBox value
        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "By Name")
            {
                Form5 f5 = new Form5(map);
                this.Hide();
                f5.ShowDialog();
            }else if(comboBox1.Text == "By Date")
            {
                Form6 f6 = new Form6(map);
                this.Hide();
                f6.ShowDialog();
            }else if(comboBox1.Text == "For Finished")
            {
                Form7 f7 = new Form7(map);
                this.Hide();
                f7.ShowDialog();
            }
            else if(comboBox1.Text == "For Unfinished")
            {
                Form8 f8 = new Form8(map);
                this.Hide();
                f8.ShowDialog();
            }else
            {
                MessageBox.Show("Please select a value form the drop down list", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        //opends the "Tasks arranged according to date" Form
        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(map);
            this.Hide();
            f9.ShowDialog();
        }
        //saves any changes done to the Tasks permenantly to a file
        private void button6_Click(object sender, EventArgs e)
        {
            //confirms if the user wants to overwrite changes
            if (MessageBox.Show("Are you sure you want to overwrite changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //clears the old file to fill it again
                System.IO.File.WriteAllText("Tasks.txt", string.Empty);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Tasks.txt"))
                {
                    //fills the file with the tasks
                    foreach (KeyValuePair<string, Task> pair in map)
                    {
                        string status = pair.Value.finished? "1" : "0";
                        file.WriteLine(pair.Value.name + ";" + pair.Value.id + ";" + pair.Value.desription + ";" + pair.Value.dateStr + ";" + status);
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
