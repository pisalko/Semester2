using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3_Sem_2
{
    public class Sensor
    {
        public string name { get; set; }
        public string unit { get; set; }
        public double value { get; set; }
        public DateTime date { get; set; }
        
        public Sensor()
        {
            name = null;
            unit = null;
            value = 0;            
        }
        /// <summary>
        /// This is where most of the magic happens. Here I record the this sensor into a List if I have to,or calculate their average. 
        /// </summary>
        /// <returns></returns>
        public bool isRecordable(bool b)
        {
            if (name != null && unit != null && value != 0)
            {
                if (b)
                {
                    date = DateTime.Now;
                    bool contains = false;
               
                    foreach (Sensor s in Form1.sensorList)
                    {
                        if (s.name == this.name)
                        {
                            s.value = (s.value + this.value) / 2;
                            contains = true;
                        }
                    }
                    if (!contains)
                        Form1.sensorList.Add(this);
                }
                return true;
            }
            else
                return false;
        }
    }
}
