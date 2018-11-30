using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Group_30___CNIT_155_Group_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int cSize = 100;
        private string[] mFName = new string[cSize];
        private string[] mLName = new string[cSize];
        private string[] mPPhone = new string[cSize];
        private string[] mWPhone = new string[cSize];
        private string[] mEMail = new string[cSize];
        private string[] mAffiliation = new string[cSize];
        private int mIndex = 0;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }
            string FName;
            string LName;
            string PPhone;
            string WPhone;
            string EMail;
            string Affiliation;
            if (txtPPhone.Text == "")
            {
                PPhone = "None";
            }
            else
            {
                PPhone = txtPPhone.Text;
            }
            if (txtWPhone.Text == "")
            {
                WPhone = "None";
            }
            else
            {
                WPhone = txtWPhone.Text;
            }
            if (txtEMail.Text == "")
            {
                EMail = "None";
            }
            else
            {
                EMail = txtEMail.Text;
            }
            Affiliation = CheckAffiliation();
            FName = txtFName.Text;
            LName = txtLName.Text;
            mFName[mIndex] = FName;
            mLName[mIndex] = LName;
            mPPhone[mIndex] = PPhone;
            mWPhone[mIndex] = WPhone;
            mEMail[mIndex] = EMail;
            mAffiliation[mIndex] = Affiliation;
            mIndex++;
            if (mIndex == cSize)
            {
                DisplayMessage("The address book is full");
                btnEnter.Enabled = false;
            }
            ClearInputs();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("No data has been entered");
                return;
            }
            lstOutput.Items.Clear();
            lstOutput.Items.Add("Name".PadRight(20) + "Affiliation ");
            lstOutput.Items.Add("//////////////////////////////");
            int ctr;
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                if (mAffiliation[ctr] == "Family")
                {
                    lstOutput.Items.Add(mFName[ctr] + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                }
            }
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                if (mAffiliation[ctr] == "Friend")
                {
                    lstOutput.Items.Add(mFName[ctr] + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                }
            }
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                if (mAffiliation[ctr] == "Work")
                {
                    lstOutput.Items.Add(mFName[ctr] + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                }
            }
            for (ctr = 0; ctr < mIndex; ctr++)
            {
                if (mAffiliation[ctr] == "Other")
                {
                    lstOutput.Items.Add(mFName[ctr] + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateInput()
        {
            if (txtFName.Text == "")
            {
                DisplayMessage("Enter a first name.");
                txtFName.Focus();
                return false;
            }
            if (txtLName.Text == "")
            {
                DisplayMessage("Enter a last name.");
                txtLName.Focus();
                return false;
            }
            if (radFamily.Checked == false && radFriend.Checked == false && radWork.Checked == false && radOther.Checked == false)
            {
                DisplayMessage("Select an affiliation");
                return false;
            }
            
            return true;
        }

        private string CheckAffiliation()
        {
            string Affiliation;
            if (radFamily.Checked == true)
            {
                Affiliation = "Family";
            }
            else if (radFriend.Checked == true)
            {
                Affiliation = "Friend";
            }
            else if (radWork.Checked == true)
            {
                Affiliation = "Work";
            }
            else
            {
                Affiliation = "Other";
            }
            return Affiliation;
        }

        private void ClearInputs()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtPPhone.Text = "";
            txtWPhone.Text = "";
            txtEMail.Text = "";
            txtSearch.Text = "";

            radFamily.Checked = false;
            radFriend.Checked = false;
            radWork.Checked = false;
            radOther.Checked = false;
            radFName.Checked = false;
            radLName.Checked = false;
            lstOutput.Items.Clear();

            txtFName.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("No data has been entered");
                return;
            }
            lstOutput.Items.Clear();
            lstOutput.Items.Add("Name".PadRight(20) + "Affiliation");
            lstOutput.Items.Add("//////////////////////////////");
            int ctr;
            if (radFamily.Checked == false && radFriend.Checked == false && radWork.Checked == false && radOther.Checked == false)
            {
                DisplayMessage("Select an affiliation");
                return;
            }
            
            if (radFamily.Checked == true)
            {
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mAffiliation[ctr] == "Family")
                    {
                        lstOutput.Items.Add(mFName[ctr]+ " " + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                    }
                    else
                    {
                        lstOutput.Items.Add("No contacts with 'Family' affiliation");
                    }
                }
            }
            else if (radFriend.Checked == true)
            {
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mAffiliation[ctr] == "Friend")
                    {
                        lstOutput.Items.Add(mFName[ctr] + " " + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                    }
                    else
                    {
                        lstOutput.Items.Add("No contacts with 'Family' affiliation");
                    }
                }
            }
            else if (radWork.Checked == true)
            {
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mAffiliation[ctr] == "Work")
                    {
                        lstOutput.Items.Add(mFName[ctr] + " " + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                    }
                    else
                    {
                        lstOutput.Items.Add("No contacts with 'Family' affiliation");
                    }
                }
            }
            else
            {
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mAffiliation[ctr] == "Other")
                    {
                        lstOutput.Items.Add(mFName[ctr] + " " + mLName[ctr].PadRight(20) + mAffiliation[ctr]);
                    }
                    else
                    {
                        lstOutput.Items.Add("No contacts with 'Family' affiliation");
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (mIndex == 0)
            {
                DisplayMessage("No data has been entered");
                return;
            }
            if (radFamily.Checked == false && radFriend.Checked == false && radWork.Checked == false && radOther.Checked == false)
            {
                DisplayMessage("Select an affiliation");
                return;
            }
            if (radFName.Checked == false && radLName.Checked == false)
            {
                DisplayMessage("Select a search type");
                return;
            }
            if (txtSearch.Text == "")
            {
                DisplayMessage("Enter a name into the search");
            }
            string UniqueName;
            bool flag = false;
            int ctr;
            if (radFName.Checked == true)
            {
                UniqueName = txtSearch.Text.ToLower();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mFName[ctr].ToLower() == UniqueName)
                    {
                        lstOutput.Items.Clear();
                        lstOutput.Items.Add("Discovered First Name: " + mFName[ctr]);
                        lstOutput.Items.Add("Name".PadRight(20) + "Affiliation");
                        lstOutput.Items.Add("//////////////////////////////");
                        lstOutput.Items.Add(mFName[ctr] + "" + mLName[ctr].PadRight(20) + mAffiliation[ctr]);

                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    DisplayMessage("Could not find " + UniqueName + " in the address book");
                }
            }
            if (radLName.Checked == true)
            {
                UniqueName = txtSearch.Text.ToLower();
                for (ctr = 0; ctr < mIndex; ctr++)
                {
                    if (mLName[ctr].ToLower() == UniqueName)
                    {
                        lstOutput.Items.Clear();
                        lstOutput.Items.Add("Discovered Last Name: " + mLName[ctr]);
                        lstOutput.Items.Add("Name".PadRight(20) + "Affiliation");
                        lstOutput.Items.Add("//////////////////////////////");
                        lstOutput.Items.Add(mFName[ctr] + "" + mLName[ctr].PadRight(20) + mAffiliation[ctr]);

                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    DisplayMessage("Could not find " + UniqueName + " in the address book");
                }
            }
        }

        private void lstOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = lstOutput.SelectedIndex - 2;
            txtFName.Text = mFName[Index];
            txtLName.Text = mLName[Index];
            txtPPhone.Text = mPPhone[Index];
            txtWPhone.Text = mWPhone[Index];
            txtEMail.Text = mEMail[Index];
            if (mAffiliation[Index] == "Family")
            {
                radFamily.Checked = true;
            }
            if (mAffiliation[Index] == "Friend")
            {
                radFamily.Checked = true;
            }
            if (mAffiliation[Index] == "Work")
            {
                radFamily.Checked = true;
            }
            if (mAffiliation[Index] == "Other")
            {
                radFamily.Checked = true;
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (mIndex <= 0)
            {
                DisplayMessage("No contacts currently exist locally");
                return;
            }
            if (!File.Exists("Address Book.txt"))
            {
                DisplayMessage("No local file exists yet. Please create one and add some entries.");
                return;
            }

            progressBar.Value = 0;
            lblProgess.Text = "Preparing for upload...";
            lblProgess.Location = new Point(242, 494);
            lblProgess.Refresh();
            progressBar.Value = 25;
            gitAdd();
            lblProgess.Text = "Commiting changes...";
            lblProgess.Refresh();
            progressBar.Value = 50;
            gitCommit();
            lblProgess.Text = "Uploading to GitHub...";
            lblProgess.Refresh();
            progressBar.Value = 75;
            gitPush();
            lblProgess.Location = new Point(346, 494);
            lblProgess.Text = "Done!";
            progressBar.Value = 100;

            Thread.Sleep(3000);
            lblProgess.Text = "";
            progressBar.Value = 0;
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to sync with the database? any local changes made will be lost", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    lblProgess.Location = new Point(279, 494);
                    wc.DownloadFileAsync(
                        new System.Uri("https://raw.githubusercontent.com/Sergeant-Soda/Group-30---CNIT-155-Group-Project/master/Group%2030%20-%20CNIT%20155%20Group%20Project/Group%2030%20-%20CNIT%20155%20Group%20Project/bin/Debug/Address%20Book.txt"),
                        "Address Book.txt"
                    );
                }
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double percent = (progressBar.Value / progressBar.Maximum) * 100;

            progressBar.Value = e.ProgressPercentage;
            lblProgess.Text = "Fetching... " + Math.Round(percent, 2) + "%";

            if (percent >= 100)
            {
                lblProgess.Location = new Point(346, 494);
                lblProgess.Text = "Done!";
            }
        }

        private void gitAdd()
        {
            System.Diagnostics.Process gitAdd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C git add \"Address Book.txt\"";
            gitAdd.StartInfo = startInfo;
            gitAdd.Start();
            Thread.Sleep(500);
        }

        private void gitCommit()
        {
            System.Diagnostics.Process gitAdd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C git commit -a -m \"Auto Update: Address Book.txt\"";
            gitAdd.StartInfo = startInfo;
            gitAdd.Start();
            Thread.Sleep(500);
        }

        private void gitPush()
        {
            System.Diagnostics.Process gitAdd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C git push";
            gitAdd.StartInfo = startInfo;
            gitAdd.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Program Files\\Git\\git-cmd.exe") == false)
            {
                MessageBox.Show("This program uses the \"Git\"" +
                    " plugin to save address books to GitHub. Please " +
                    "install it from the link below. Until then, " +
                    "certain functions will be limited. https://git-scm.com/download/win");

                btnPush.Enabled = false;
                btnFetch.Enabled = false;
            }
            if (File.Exists("Address Book.txt") == false)
            {
                DisplayMessage("No such Filename");
                return;
            }
            StreamReader SR = null;
            SR = new StreamReader("Address Book.txt");
            try
            {
                string line;
                string[] parts;


                while (SR.Peek() != -1)
                {
                    line = SR.ReadLine();
                    parts = line.Split('\t');
                    mFName[mIndex] = parts[0];
                    mLName[mIndex] = (parts[1]);
                    mPPhone[mIndex] = parts[2];
                    mWPhone[mIndex] = parts[3];
                    mEMail[mIndex] = parts[4];
                    mAffiliation[mIndex] = parts[5];
                    mIndex++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (SR != null)
                    SR.Close();

            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to end the program? ", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                StreamWriter SW = null;
                SW = new StreamWriter("Address Book.txt");
                try
                {
                    for (int count = 0; count < mIndex; count++)
                    {
                        SW.WriteLine( mFName[count] + "\t" + mLName[count] + "\t" + mPPhone[count]+"\t"+mWPhone[count]+"\t"+mEMail[count]+"\t"+mAffiliation[count]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (SW != null)
                        SW.Close();

                }
            }
        }
    }
}
