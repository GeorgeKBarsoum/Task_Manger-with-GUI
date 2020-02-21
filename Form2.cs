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
    public partial class Form2 : Form
    {
        Dictionary<string, Task> map2 = new Dictionary<string, Task>();
        int id = 0;

        //copies the passed map to be used i this form
        public Form2(Dictionary<string, Task> map)
        {
            map2 = map;
            InitializeComponent();
            
        }
        
        //sets the maximum number of selections in the date Picker to 1
        //finds the largest id in map2 to calculate the id of the added task
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map2);
            f1.Close();
            monthCalendar1.MaxSelectionCount = 1;
            foreach(KeyValuePair<string, Task> entry in map2)
            {
                if(entry.Value.id > id)
                {
                    id = entry.Value.id;
                }
            }
        }

        //Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            //checks if any of the filds are empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in all the fields", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //checks if the new name already exists
            bool found = false;
            if (map2.ContainsKey(textBox1.Text))
            {
                found = true;
            }
            //adds the task to the map
            if (!found)
            {
                id++;   //increments the id to be set to the new task
                Task newTask = new Task();
                newTask.finished = false;
                newTask.id = id;
                newTask.name = textBox1.Text.ToString();
                newTask.desription = textBox2.Text.ToString();
                //dateStr is used for displaying the date in the dataGridView
                newTask.dateStr = monthCalendar1.SelectionStart.Day.ToString() + "/" + monthCalendar1.SelectionStart.Month.ToString() + "/" + monthCalendar1.SelectionStart.Year.ToString();
                newTask.eventdate.day = monthCalendar1.SelectionStart.Day;
                newTask.eventdate.month = monthCalendar1.SelectionStart.Month;
                newTask.eventdate.year = monthCalendar1.SelectionStart.Year;
                newTask.dateTime = DateTime.Parse(monthCalendar1.SelectionRange.Start.ToShortDateString());     //dateTime is only used for comparing dates when sorting
                map2.Add(newTask.name, newTask);
                MessageBox.Show("Task sucessfully added!");
            }else
            {
                MessageBox.Show("Please Enter a unique name", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map2);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        //the "Close" button
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f12 = new Form1(map2);
            this.Hide();
            f12.ShowDialog();
            this.Close();
        }
    }
}
