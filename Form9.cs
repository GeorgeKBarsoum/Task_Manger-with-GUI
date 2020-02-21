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
    public partial class Form9 : Form
    {
        Dictionary<string, Task> map7 = new Dictionary<string, Task>();
        //copies the passed map to be used in this form
        public Form9(Dictionary<string, Task> d)
        {
            map7 = d;
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map7);
            f1.Close();
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map7);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        //the "Sort" Button
        private void button1_Click(object sender, EventArgs e)
        {
            //creates a list of tasks to store the tasks and sort them according to date
            List<Task> tasks = new List<Task>();
            //clears the dataGridView;
            this.dataGridView1.Rows.Clear();
            //adds all the tasks to the List created above
            foreach (KeyValuePair<string, Task> entry in map7)
            {
                tasks.Add(entry.Value);
            }
            //checks for the user's choice of sorting method (Ascending or Descending) from a comboBox and sorts accordingly
            if (comboBox1.Text == "Ascending")
            {
                tasks.Sort((x, y) => x.dateTime.CompareTo(y.dateTime));
            }else if(comboBox1.Text == "Descending")
            {
                tasks.Sort((y, x) => x.dateTime.CompareTo(y.dateTime));
            }else
            {
                MessageBox.Show("Please choose a value form the combo box", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //displays the sorted list of tasks in the dataGridView
            foreach(Task t in tasks)
            {
                this.dataGridView1.Rows.Add(new object[] { t.id, t.name, t.desription, t.dateStr, t.finished });
            }
        }
    }
}
