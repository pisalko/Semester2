using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1Sem2
{
    public partial class Form1 : Form
    {
        static List<Member> memberList = new List<Member>(); 
        public Member member = new Member();
        public static bool memberAdded = false;

        public Form1() //Initialize Form, setup for work.
        {
            InitializeComponent();
            cbGym.Visible = false;
            cbSwimmingPool.Visible = false;
            cbDance.Visible = false;
            cbBilliards.Visible = false;
            btnPaid.Visible = false;
            lbPackageName.Visible = false;
            lbAnnouncement.Text = "";
            lbWish.Text = "";
            lbForget.Text = "";
            rbCARD.Checked = true;
        }

        private void btnAddMember_Click(object sender, EventArgs e) //Button opening AddMemberForm and hanging the Form until Form2 is closed.
        {
            FormAddMember newMemberForm = new FormAddMember();
            newMemberForm.ShowDialog(); //hangs
            if (memberAdded)
            {
                memberAdded = false;
                updateList();
                listBoxMembers.SelectedIndex = listBoxMembers.Items.Count - 1;
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e) //Button for removing members with confirmation message.
        {
            if (listBoxMembers.SelectedIndex >= 0) 
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove that member ?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    memberList.RemoveAt(listBoxMembers.SelectedIndex);
                    listBoxMembers.Items.Remove(listBoxMembers.SelectedItem);
                    
                }
            }
        }

        private void listBoxMembers_SelectedIndexChanged(object sender, EventArgs e) //Ticking and Unticking checkboxes depending on what packages the member has.
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                cbGym.Visible = true;
                cbSwimmingPool.Visible = true;
                cbDance.Visible = true;
                cbBilliards.Visible = true;
                btnPaid.Visible = true;
                lbPackageName.Visible = true;
                cbSwimmingPool.Checked = memberList[listBoxMembers.SelectedIndex].SwimmingPool;
                cbDance.Checked = memberList[listBoxMembers.SelectedIndex].Dance;
                cbBilliards.Checked = memberList[listBoxMembers.SelectedIndex].Billiards;
                cbGym.Checked = memberList[listBoxMembers.SelectedIndex].Gym;
            }
            else 
            {
                cbGym.Visible = false;
                cbSwimmingPool.Visible = false;
                cbDance.Visible = false;
                cbBilliards.Visible = false;
                btnPaid.Visible = false;
                lbPackageName.Visible = false;
            }
            
        }

        

        private void cbSwimmingPool_Click(object sender, EventArgs e) //Deciding whether or not the member has to have that package (based on .Checked)
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                memberList[listBoxMembers.SelectedIndex].SwimmingPool = cbSwimmingPool.Checked;
                if (cbSwimmingPool.Checked == true)
                    memberList[listBoxMembers.SelectedIndex].HasPaid = false;
                updateList();
            }
        }

        private void cbGym_Click(object sender, EventArgs e) //Same as above
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                memberList[listBoxMembers.SelectedIndex].Gym = cbGym.Checked;
                if (cbGym.Checked == true)
                    memberList[listBoxMembers.SelectedIndex].HasPaid = false;
                updateList();
            }
        }

        private void cbDance_Click(object sender, EventArgs e)// Same as above
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                memberList[listBoxMembers.SelectedIndex].Dance = cbDance.Checked;
                if (cbDance.Checked == true)
                    memberList[listBoxMembers.SelectedIndex].HasPaid = false;
                updateList();
            }
        }

        private void cbBilliards_Click(object sender, EventArgs e) //Same as above
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                memberList[listBoxMembers.SelectedIndex].Billiards = cbBilliards.Checked;
                if(cbBilliards.Checked == true)
                memberList[listBoxMembers.SelectedIndex].HasPaid = false;
                updateList();
            }
        }
        public static void transferMember(Member mmember) //static method to transfer a Member instance trough the 2 forms. This is where we "Add" and "Create" new members. Kept in a static List.
        {
            memberList.Add(mmember);
        }
        private void updateList() //Updating the listbox for any changes and keeping the same index selected for ease of use and less irritating clicks of the mouse.
        {
            int index = listBoxMembers.SelectedIndex;
            listBoxMembers.Items.Clear();
            foreach (Member m in memberList)
            {
                m.PriceOwned();
                listBoxMembers.Items.Add(m.GetGivenName() + " " + m.GetLastName() + " " + m.owns + "$  ID: " + m.GetMembershipID());
            }
            listBoxMembers.SelectedIndex = index;
            CheckCode();
        }

        private void btnPaid_Click(object sender, EventArgs e) //Sets a member's propery "HasPaid" to true. After the member hands over the money of course !
        {
            if (listBoxMembers.SelectedIndex >= 0)
            {
                memberList[listBoxMembers.SelectedIndex].HasPaid = true;
                updateList();
            }
        }

        private void rbNFC_CheckedChanged(object sender, EventArgs e) //Updates and checks the entered code (Which if was connected to an 
        {                                                             //embedded reader would be automatic ! No need of manual entering the code!)
            CheckCode();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //same as above
        {
            CheckCode();
        }

        private void rbCARD_CheckedChanged(object sender, EventArgs e)//same as above
        {
            CheckCode();
        }

        private void CheckCode() //This is where the entered (read from card reader) code is checked whether or not it in the system or not. Displays a corresponding message.
        {
            string code = tbCode.Text;
            string area = cbArea.Text;
            bool found = false;
            

            foreach (Member m in memberList)
            {
                if (code == m.GetMembershipID())
                {
                    if (m.Dance)
                    { 
                        if (area == "Dance")
                        {
                            if (m.HasPaid)
                            {
                                string username = m.GetLastName() == "" ? m.GetGivenName() : m.GetLastName();
                                pbAccess.BackColor = Color.Green;
                                lbAnnouncement.Text = "Welcome, Mr. " + username + " !";
                                lbAnnouncement.BackColor = Color.Green;
                                lbWish.Text = "Happy Dancing!";
                                lbForget.BackColor = Color.Green;
                                lbWish.BackColor = Color.Green;
                                if (rbNFC.Checked)
                                    lbForget.Text = "Do not forget your phone!";
                                if (rbCARD.Checked)
                                    lbForget.Text = "Do not forget your card!";
                            }
                            else
                            {
                                pbAccess.BackColor = Color.Orange;
                                lbWish.BackColor = Color.Orange;
                                lbForget.BackColor = Color.Orange;
                                lbAnnouncement.BackColor = Color.Orange;
                                lbAnnouncement.Text = "Unpaid services";
                                lbForget.Text = "Please pay at the\ninformation desk!";
                                lbWish.Text = "";
                            }
                        }
                    }
                    

                    if (m.Gym)
                    {
                        if (area == "Gym")
                        {
                            if (m.HasPaid)
                            {
                                string username = m.GetLastName() == "" ? m.GetGivenName() : m.GetLastName();
                                pbAccess.BackColor = Color.Green;
                                lbAnnouncement.Text = "Welcome, Mr. " + username + " !";
                                lbAnnouncement.BackColor = Color.Green;
                                lbWish.BackColor = Color.Green;
                                lbForget.BackColor = Color.Green;
                                lbWish.Text = "Happy Training!";
                                if (rbNFC.Checked)
                                    lbForget.Text = "Do not forget your phone!";
                                if (rbCARD.Checked)
                                    lbForget.Text = "Do not forget your card!";
                            }
                            else
                            {
                                pbAccess.BackColor = Color.Orange;
                                lbWish.BackColor = Color.Orange;
                                lbForget.BackColor = Color.Orange;
                                lbAnnouncement.BackColor = Color.Orange;
                                lbAnnouncement.Text = "Unpaid services";
                                lbForget.Text = "Please pay at the\ninformation desk!";
                                lbWish.Text = "";
                            }
                        }
                    }
                   
                    if (m.SwimmingPool)
                    {
                        if (area == "Swimming Pool")
                        {
                            if (m.HasPaid)
                            {
                                string username = m.GetLastName() == "" ? m.GetGivenName() : m.GetLastName();
                                pbAccess.BackColor = Color.Green;
                                lbAnnouncement.Text = "Welcome, Mr. " + username + " !";
                                lbAnnouncement.BackColor = Color.Green;
                                lbWish.BackColor = Color.Green;
                                lbForget.BackColor = Color.Green;
                                lbWish.Text = "Happy Swimming!";
                                if (rbNFC.Checked)
                                    lbForget.Text = "Do not forget your phone!";
                                if (rbCARD.Checked)
                                    lbForget.Text = "Do not forget your card!";
                            }
                            else
                            {
                                pbAccess.BackColor = Color.Orange;
                                lbWish.BackColor = Color.Orange;
                                lbForget.BackColor = Color.Orange;
                                lbAnnouncement.BackColor = Color.Orange;
                                lbAnnouncement.Text = "Unpaid services";
                                lbForget.Text = "Please pay at the\ninformation desk!";
                                lbWish.Text = "";
                            }
                        }

                    }
                    
                    if (m.Billiards)
                    {
                        if (area == "Billiards")
                        {
                            if (m.HasPaid)
                            {
                                string username = m.GetLastName() == "" ? m.GetGivenName() : m.GetLastName();
                                pbAccess.BackColor = Color.Green;
                                lbAnnouncement.Text = "Welcome, Mr. " + username + " !";
                                lbAnnouncement.BackColor = Color.Green;
                                lbWish.Text = "Good luck!";
                                lbWish.BackColor = Color.Green;
                                lbForget.BackColor = Color.Green;
                                if (rbNFC.Checked)
                                    lbForget.Text = "Do not forget your phone!";
                                if (rbCARD.Checked)
                                    lbForget.Text = "Do not forget your card!";
                            }
                            else
                            {
                                pbAccess.BackColor = Color.Orange;
                                lbWish.BackColor = Color.Orange;
                                lbForget.BackColor = Color.Orange;
                                lbAnnouncement.BackColor = Color.Orange;
                                lbAnnouncement.Text = "Unpaid services";
                                lbForget.Text = "Please pay at the\ninformation desk!";
                                lbWish.Text = "";
                            }
                        }
                    }
                   
                    found = true;
                }
                else
                    found = false;
            }

            if(!found)
            {
                if (code.Length >= 6)
                {
                    lbAnnouncement.Text = "";
                    lbWish.Text = "Wrong or Broken Card!";
                    lbForget.Text = "Please contact \n information desk !";
                    pbAccess.BackColor = Color.Red;
                    lbAnnouncement.BackColor = Color.Red;
                    lbWish.BackColor = Color.Red;
                    lbForget.BackColor = Color.Red;
                }
                else
                {
                    lbAnnouncement.Text = "";
                    lbWish.Text = "";
                    lbForget.Text = "";
                    pbAccess.BackColor = Color.Pink;
                    lbAnnouncement.BackColor = Color.Pink;
                    lbWish.BackColor = Color.Pink;
                    lbForget.BackColor = Color.Pink;
                }
            }
        }

        private void cbArea_DropDownClosed(object sender, EventArgs e) //Again an event to check the entered code against the database.
        {
            CheckCode();
        }
    }
}
