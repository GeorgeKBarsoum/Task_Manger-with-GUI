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
    public partial class Form4 : Form
    {
        Dictionary<string, Task> map4 = new Dictionary<string, Task>();
        //copies the passed map to use it in this form
        public Form4(Dictionary<string, Task> d)
        {
            map4 = d;
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        //The "Close" Button
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map4);
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }
        //The "Edit" Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool oldNameFound = false;
            //the isEdited is set to true if at least one attribute has been edited
            //it is used to display a MessageBox saying that the edit was successful
            bool isEdited = false;
            //checks if the user enterd a name for the (Old) task
            if (string.IsNullOrWhiteSpace(oldName.Text))
            {
                MessageBox.Show("Please enter a name", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            {
                //checks if the task to be edited exists
                if (map4.ContainsKey(oldName.Text))
                {
                    oldNameFound = true;
                }
                if (oldNameFound)
                {
                    //checks if the user enterd a name for the (New) Task
                    //if a new name is enterd all the other changes happen to the task with the new name
                    //if a new name is NOT enterd all the other changes happen to the task with the old name
                    //This executes if the user did NOT enter a new name
                    if (string.IsNullOrWhiteSpace(newName.Text))
                    {
                        //checks if the description field is not empty
                        if (!string.IsNullOrWhiteSpace(newDesc.Text))
                        {
                            map4[oldName.Text].desription = newDesc.Text;
                            isEdited = true;
                        }
                        //checks if the "Change Date" check box is ticked
                        //if it is ticked the date will be changed to the one selected in the date picker
                        if (checkBox1.Checked)
                        {
                            map4[oldName.Text].dateStr = monthCalendar1.SelectionStart.Day.ToString() + "/" + monthCalendar1.SelectionStart.Month.ToString() + "/" + monthCalendar1.SelectionStart.Year.ToString();
                            map4[oldName.Text].eventdate.day = monthCalendar1.SelectionStart.Day;
                            map4[oldName.Text].eventdate.month = monthCalendar1.SelectionStart.Month;
                            map4[oldName.Text].eventdate.year = monthCalendar1.SelectionStart.Year;
                            map4[oldName.Text].dateTime = DateTime.Parse(monthCalendar1.SelectionStart.ToShortDateString());
                            isEdited = true;
                        }
                        //checks if the "Set Finished" checkbox is ticked
                        //changes the finished attribute of the task to true if it is ticked
                        if (checkBox2.Checked)
                        {
                            map4[oldName.Text].finished = true;
                            isEdited = true;
                        }
                    }
                    //This executes if the user enters a new name
                    else
                    {
                        //checks if the new name already exists
                        bool newNameFound = false;
                        if (map4.ContainsKey(newName.Text))
                        {
                            newNameFound = true;
                        }
                        if (newNameFound)
                        {
                            MessageBox.Show("New name must be unique", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        //if the new name does not exist a new task is created with the new name, the attributes of the old one is copied to it and the old one is deleted
                        else
                        {
                            Task newTask = map4[oldName.Text];
                            newTask.name = newName.Text;
                            map4.Add(newName.Text, newTask);
                            map4.Remove(oldName.Text);
                            isEdited = true;
                            //checks if the description field is left empty
                            if (!string.IsNullOrWhiteSpace(newDesc.Text))
                            {
                                map4[newName.Text].desription = newDesc.Text;
                                isEdited = true;
                            }
                            //checks if the "Change Date" checkBox is ticked
                            if (checkBox1.Checked)
                            {
                                map4[newName.Text].dateStr = monthCalendar1.SelectionStart.Day.ToString() + "/" + monthCalendar1.SelectionStart.Month.ToString() + "/" + monthCalendar1.SelectionStart.Year.ToString();
                                map4[newName.Text].eventdate.day = monthCalendar1.SelectionStart.Day;
                                map4[newName.Text].eventdate.month = monthCalendar1.SelectionStart.Month;
                                map4[newName.Text].eventdate.year = monthCalendar1.SelectionStart.Year;
                                map4[newName.Text].dateTime = DateTime.Parse(monthCalendar1.SelectionStart.ToShortDateString());
                                isEdited = true;
                            }
                            //checks if the "Set Finished" checkBox is ticked
                            if (checkBox2.Checked)
                            {
                                map4[newName.Text].finished = true;
                                isEdited = true;
                            }
                        }
                    }
                }else
                {
                    MessageBox.Show("Task not found!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //checks if the task has been edited in any way
                if (isEdited)
                {
                    MessageBox.Show("Task Edited Sucessfully!");
                    Form1 f13 = new Form1(map4);
                    this.Hide();
                    f13.ShowDialog();
                    this.Close();
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map4);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        //sets the max number of dates that can be selected in the date picker to 1
        private void Form4_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
            Form1 f1 = new Form1(map4);
            f1.Close();
        }
    }
}
