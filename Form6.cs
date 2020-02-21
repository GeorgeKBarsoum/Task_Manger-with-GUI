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
    public partial class Form6 : Form
    {
        Dictionary<string, Task> map6 = new Dictionary<string, Task>();
        public Form6(Dictionary<string, Task> d)
        {
            //copies the Tasks in the main form to use in the search
            map6 = d;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map6);
            f1.Close();
        }

        //search button
        private void button1_Click(object sender, EventArgs e)
        {
            //creates a list to contain the tasks resulted from the search
            List<Task> Tasks = new List<Task>();
            //checks if all fields are empty
            if (string.IsNullOrWhiteSpace(Day.Text) && string.IsNullOrWhiteSpace(Month.Text) && string.IsNullOrWhiteSpace(Year.Text))
            {
                MessageBox.Show("Please Enter a date to search for",string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            //checks if a field is empty and searches using the other 2
            //or if 2 fields are empty it searches using the non-empty one
            {
                if (string.IsNullOrWhiteSpace(Day.Text))
                {
                    if (string.IsNullOrWhiteSpace(Month.Text))
                    {
                        
                        foreach(KeyValuePair<string, Task> entry in map6)
                        {
                            if(entry.Value.eventdate.year.ToString() == Year.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    }else if (string.IsNullOrWhiteSpace(Year.Text))
                    {

                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.month.ToString() == Month.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    }else
                    {
                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.month.ToString() == Month.Text && entry.Value.eventdate.year.ToString() == Year.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }
                    }

                }else if (string.IsNullOrWhiteSpace(Month.Text))
                {
                    if (string.IsNullOrWhiteSpace(Day.Text))
                    {

                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.year.ToString() == Year.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    } else if (string.IsNullOrWhiteSpace(Year.Text))
                    {

                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.day.ToString() == Day.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    }else
                    {
                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.day.ToString() == Day.Text && entry.Value.eventdate.year.ToString() == Year.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }
                    }

                }else if (string.IsNullOrWhiteSpace(Year.Text))
                {
                    if (string.IsNullOrWhiteSpace(Day.Text))
                    {

                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.month.ToString() == Month.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    }
                    else if (string.IsNullOrWhiteSpace(Month.Text))
                    {

                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.day.ToString() == Day.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }

                    }else
                    {
                        foreach (KeyValuePair<string, Task> entry in map6)
                        {
                            if (entry.Value.eventdate.month.ToString() == Month.Text && entry.Value.eventdate.day.ToString() == Day.Text)
                            {
                                Tasks.Add(entry.Value);
                            }
                        }
                    }
                }else
                {
                    foreach (KeyValuePair<string, Task> entry in map6)
                    {
                        if (entry.Value.eventdate.month.ToString() == Month.Text && entry.Value.eventdate.day.ToString() == Day.Text && entry.Value.eventdate.year.ToString() == Year.Text)
                        {
                            Tasks.Add(entry.Value);
                        }
                    }
                }
            }
            //puts the results in the dataGridView
            foreach(Task t in Tasks)
            {
                this.dataGridView1.Rows.Add(new object[] { t.id, t.name, t.desription, t.dateStr, t.finished });
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map6);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map6);
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
        //clears the dataGridView
        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
