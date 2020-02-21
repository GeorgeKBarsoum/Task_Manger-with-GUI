using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_GUI
{
    public class Task
    {
        public struct date
        {
            public int day;
            public int month;
            public int year;
        };
        public int id;
        public string name;
        public string desription;
        public date eventdate;
        public bool finished = false;
        public string dateStr;
        public DateTime dateTime;
    }
}
