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
    public partial class Form7 : Form
    {
        Dictionary<string, Task> map7 = new Dictionary<string, Task>();
        //copies the passed map to be used in this form
        public Form7(Dictionary<string, Task> d)
        {
            map7 = d;
            InitializeComponent();
        }

        //on loading the form, searches the map for finished tasks and adds them to the dataGridView
        private void Form7_Load(object sender, EventArgs e)
        {

            Form1 f1 = new Form1(map7);
            f1.Close();
            foreach (KeyValuePair<string, Task> entry in map7)
            {
                if (entry.Value.finished == true)
                {
                    this.dataGridView1.Rows.Add(new object[] { entry.Value.id, entry.Value.name, entry.Value.desription, entry.Value.dateStr, entry.Value.finished });
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Form1 f1 = new Form1(map7);
            this.Hide();
            f1.ShowDialog();
            base.OnFormClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(map7);
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
