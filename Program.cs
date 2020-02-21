using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task_Manager_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dictionary<string, Task> d = new Dictionary<string, Task>();
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.IO.File.Exists("Tasks.txt"))
            {
                StreamReader sr = new StreamReader("Tasks.txt");
                string line = sr.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entries = line.Split(';');
                    Task newT = new Task();
                    newT.id = Int32.Parse(entries[1]);
                    newT.name = entries[0];
                    newT.desription = entries[2];
                    string[] date = entries[3].Split('/');
                    newT.eventdate.day = Int32.Parse(date[0]);
                    newT.eventdate.month = Int32.Parse(date[1]);
                    newT.eventdate.year = Int32.Parse(date[2]);
                    newT.dateStr = date[1] + "/" + date[0] + "/" + date[2];
                    newT.finished = Int32.Parse(entries[4]) == 0 ? false : true;
                    newT.dateTime = DateTime.Parse(newT.dateStr);
                    newT.dateStr = date[0] + "/" + date[1] + "/" + date[2];
                    d.Add(entries[0], newT);
                    line = sr.ReadLine();
                }
                sr.Close();
            }else
            {
                System.IO.File.Create("Tasks.txt");
            }
            
            
            Application.Run(new Form1(d));
        }
        /*static void Main()
        {
            Dictionary<string, Task> d = new Dictionary<string, Task>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Form1(d);
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            main.Show();
            Application.Run();

        }*/
    }
}
