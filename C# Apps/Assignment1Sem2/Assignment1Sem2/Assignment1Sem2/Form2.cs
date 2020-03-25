using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1Sem2
{
    public partial class FormAddMember : Form
    {
        public FormAddMember() //Init graphics
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e) //Form load
        {
            rbCARD.Checked = true;
            tbDOB1.Text = "00";
            tbDOB2.Text = "00";
            tbDOB3.Text = "00";

        }

        private void btnAddMember_Click(object sender, EventArgs e) //This is where we set all the information needed for the member (all * places must be filled as well).
        {
            Member member = new Member();
            if (tbGivenName.Text == "" || tbGivenName.Text == null || tbDOB1.Text == "" ||
                tbDOB1 == null || tbDOB2.Text == "" || tbDOB2 == null || tbDOB3.Text == "" || tbDOB3 == null)
            {
                MessageBox.Show("Please fill out ALL required fields");
            }
            else
            {
                member.SetGivenName(tbGivenName.Text);
                member.SetLastName(tbLastName.Text);
                member.SetDOB(tbDOB1.Text + "/" + tbDOB2.Text + "/" + tbDOB3.Text);
                member.SetEmail(tbEmail.Text);
                member.SetMembershipID(lbMembershipID.Text); 
                member.HasPaid = false;
                Form1.memberAdded = true;
                Form1.transferMember(member);       //Transfering the member object to the main Form
                this.Close();                       //Closes the form since Its purpose is fulfilled
                
            }
        }

        private void tbGivenName_TextChanged(object sender, EventArgs e) //Helps randomize the MembershipID since CPU-based "randoms" (like c#' one) are not very random
        {
            MemberShipID();
        }

        private void MemberShipID()             //The code where the MembershipID is randomized and assigned to the user.
        {
            Random random = new Random();
            char[] rndchar = new char[] {'A', 'B', 'C', 'R', 'B', 'T', 'F'}; // 0-3 ABCR 4-6 BTF
            if (rbCARD.Checked)
            lbMembershipID.Text = random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + 
                    rndchar[random.Next(0, 3)].ToString() + rndchar[random.Next(0, 3)].ToString() + random.Next(0, 9).ToString()
                    + random.Next(0, 9).ToString() + random.Next(0, 9).ToString(); //###AA###
            else if(rbNFC.Checked)
            lbMembershipID.Text = rndchar[random.Next(0,3)].ToString() + rndchar[random.Next(0, 3)].ToString() + ';'
                    + random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + rndchar[random.Next(4, 6)].ToString()
                    + random.Next(0, 9).ToString() + random.Next(0, 9).ToString() + random.Next(0, 9).ToString(); //AA;##B###
        }

        private void btnClear_Click(object sender, EventArgs e) //clears all fields
        {
            tbGivenName.Text = "";
            tbLastName.Text = "";
            tbDOB1.Text = "";
            tbDOB2.Text = "";
            tbDOB3.Text = "";
            tbEmail.Text = "";
            lbMembershipID.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e) //Says there are no new members and closes the form
        {
            Form1.memberAdded = false;
            this.Close();
        }

        private void rbNFC_CheckedChanged(object sender, EventArgs e) //Helps randomize the MembershipID
        {
            MemberShipID();
        }

        private void rbCARD_CheckedChanged(object sender, EventArgs e) //Helps randomize the MembershipID
        {
            MemberShipID();
        }

        private void tbDOB1_TextChanged(object sender, EventArgs e) //constant checks for what is written
        {
            try //Checks if the user is typing numbers
            {
                Convert.ToInt32(tbDOB1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please type numbers in your Date of Birth..."); //Throws a MessageBox if he types something else than 0-9
                tbDOB1.Text = "00"; //Clears the field
            }
        }

        private void tbDOB2_TextChanged(object sender, EventArgs e) // same as above
        {
            try
            {
                Convert.ToInt32(tbDOB2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please type numbers in your Date of Birth...");
                tbDOB2.Text = "00";
            }
        }

        private void tbDOB3_TextChanged(object sender, EventArgs e) // same as above
        {
            try
            { 
                Convert.ToInt32(tbDOB3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please type numbers in your Date of Birth...");
                tbDOB3.Text = "00";
            }
        }
    }
}
 