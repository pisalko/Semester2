using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Assignment_3_Sem_2
{
    
    public partial class Form1 : Form
    {
        Thread serverThread;
        public static List<string> listBoxItems = new List<string>();
        private List<string> compareList = new List<string>();
        private LinkedListStack lls = new LinkedListStack();
        public static List<Sensor> sensorList = new List<Sensor>();
        Server sr;


        public Form1()
        {
            InitializeComponent();
            VisibilityCheck(false);
        }

        /// <summary>
        /// Begins the server listener and revelas controls
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            sr = new Server();
            serverThread = new Thread(sr.Run);
            serverThread.Start();
            VisibilityCheck(true);
        }

        int difference = listBoxItems.Count;

        /// <summary>
        /// Here we check for new data from the other thread (I tried doing it with a static Linked List but it caused way too much trouble)
        /// And we also update the listbox 
        /// </summary>
        private void timerLb_Tick(object sender, EventArgs e)
        {
            if (difference != listBoxItems.Count)
            {
                for (int i; difference < listBoxItems.Count; difference++)
                {
                    lls.push(listBoxItems[difference]);                    
                }
                

                ListBox.ObjectCollection objc = lls.AsListBoxCollection();
                lbComLog.Items.Clear();
                foreach (var item in objc)
                {
                    lbComLog.Items.Add(item);
                }
                lbSensors.Items.Clear();
                foreach (Sensor s in sensorList)
                {
                    lbSensors.Items.Add(s.name);
                }
            }

            
        }


        /// <summary>
        /// Just for better looking code and less CTRL+Vs
        /// </summary>
        private void VisibilityCheck(bool b)
        {
            lbComLog.Visible = b;
            lblComLog.Visible = b;
            lblSensors.Visible = b;
            lbSensors.Visible = b;
            lblNamel.Visible = b;
            lblValuel.Visible = b;
            lblDatel.Visible = b;
            lblUnitl.Visible = b;
            lblName.Visible = b;
            lblValue.Visible = b;
            lblDate.Visible = b;
            lblUnit.Visible = b;
            btnStart.Visible = !b;
        }
        /// <summary>
        /// Display sensors' values
        /// </summary>
        private void lbSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSensors.SelectedIndex >= 0)
            {
                Sensor s = sensorList.ElementAt(lbSensors.SelectedIndex);
                lblName.Text = s.name;
                lblUnit.Text = s.unit;
                lblValue.Text = s.value.ToString();
                lblDate.Text = s.date.ToString();
            }
            else
            {
                lblName.Text = "";
                lblUnit.Text = "";
                lblValue.Text = "";
                lblDate.Text = "";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
