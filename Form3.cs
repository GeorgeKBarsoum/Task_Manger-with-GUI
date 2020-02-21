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
    
    public partial class Form3 : Form
    {
        Dictionary<string, Task> map3 = new Dictionary<string, Task>();
        //copies the passed map to be used in this form
        public Form3(Dictionary<string, Task> d)
        {
            map3 = d;
            InitializeComponent();
        }
        //the "Remove" button
        private void button1_Click(object sender, EventArgs e)
        {
            //checks if the user enterd a name
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a name");
            }
            //checks if the task exists in the map
            bool found = false;
            if (map3.ContainsKey(textBox1.Text))
            {
                found = true;
            }
            //Removes the task if it finds it
            if (found)
            {
                map3.Remove(textBox1.Text.ToString());
                MessageBox.Show("Task removed successfully");
                Form1 f13 = new Form1(map3);
                this.Hide();
                f13.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Name not found", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map3);
            f1.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map3);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        //the "Close" Button
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f13 = new Form1(map3);
            this.Hide();
            f13.ShowDialog();
            this.Close();
        }
    }
}
