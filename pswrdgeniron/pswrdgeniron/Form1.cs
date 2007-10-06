////////////////////////////////////////////////////////////////////////////
// pswrdgeniron v0.4.0
// Semantic Password generator that uses WordNet, random capitalization,
// and character swapping. Prerequisite:WordNet
// by Joseph P. Socoloski III
// Copyright 2007. All Rights Reserved.
// http://pswrdgen..googlecode.com
// 
//LICENSE:
//BY DOWNLOADING AND USING, YOU AGREE TO THE FOLLOWING TERMS:
//If it is your intent to use this software for non-commercial purposes, 
//such as in academic research, this software is free and is covered under 
//the GNU GPL License, given here: <http://www.gnu.org/licenses/gpl.txt> 
////////////////////////////////////////////////////////////////////////////
//IronPython is licensed, copyrighted, and a registered trademark by
// Microsoft Corporation. http://www.codeplex.com/IronPython
//WordNet is licensed, copyrighted, and a registered trademark by 
// Princeton University. http://wordnet.princeton.edu/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IronPython.Runtime;   //PythonDictionary
using IronPython.Hosting;   //PythonEngine
using Microsoft.Scripting;  //ScriptDomainManager
using Joe.Utils;            //DownloadWebpage

namespace pswrdgeniron
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Globals
        /// <summary>
        /// The main IronPython Engine
        /// </summary>
        public static PythonEngine pe = PythonEngine.CurrentEngine;

        /// <summary>
        /// Temporary PythonEngine to handle autoupdates
        /// </summary>
        public static PythonEngine temp_pe = PythonEngine.CurrentEngine;

        /// <summary>
        /// Keep this Empty PythonEngine to handle autoupdates
        /// </summary>
        public static PythonEngine empty_pe = PythonEngine.CurrentEngine;

        /// <summary>
        /// Holds the swapping patterns
        /// self.SWAPS = {}
        /// </summary>
        public PythonDictionary SWAPS = new PythonDictionary();

        /// <summary>
        /// Variables found in pswrdgen.py
        /// </summary>
        public int MINLENGTH, MAXLENGTH, CAPLENGTH, GENCOUNT, ADDCOUNT;

        /// <summary>
        /// Holds the current insert characters
        /// </summary>
        string ADDCHAR = "";

        /// <summary>
        /// Holds the current pswrdgen.py version number
        /// </summary>
        string currentversion = "";

        /// <summary>
        /// Holds the word file paths
        /// self.WORDFILELISTS = {}
        /// </summary>
        public List WORDFILELISTS = new List();

        #endregion Globals

        /// <summary>
        /// Exit the App
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize main IronPythonEngine and load pswrdgen.py variables
                bootstrap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load error:\r\n" + ex.Message);
            }
            
        }

        /// <summary>
        /// Initializes main IronPythonEngine and loads pswrdgen.py variables
        /// </summary>
        private void bootstrap()
        {
            try
            {
                //Let check and make sure the user has Python24
                if (!Directory.Exists("C:\\Python24\\Lib"))
                {
                    DialogResult dResult = MessageBox.Show("C:\\Python24\\Lib not found.\r\npswrdgeniron needs Python24 to run. Do you want to download Python24?", "Python 2.4 Not Found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"http://www.python.org/download/releases/2.4.4/");
                    }
                    else
                        return;
                }
                //Start importing pswrdgen.py to IronPython
                pe.ExecuteCommand("import sys");
                pe.AddToPath("C:\\Python24\\Lib");
                pe.AddToPath(Application.StartupPath);//add the windows installation path so no errors when using shortcuts
                pe.ExecuteCommand("import os");
                pe.ExecuteCommand("import pswrdgen");
                pe.ExecuteCommand("i = pswrdgen.pswrdgen()");

                //Get version number of current file
                currentversion = pe.EvaluateAs<string>("pswrdgen.__version__");

                //Get url
                string url = pe.EvaluateAs<string>("pswrdgen.__url__");

                //Display some info to user...
                tbDisplay.AppendText("*************************************************************************\r\n");
                tbDisplay.AppendText("pswrdgeniron: " + url + "\r\npswrdgen.py version " + currentversion + " on \r\n" + pe.VersionString + "\r\n");
                tbDisplay.AppendText(pe.EvaluateAs<string>(@"pswrdgen.__doc__") + "\r\n");
                tbDisplay.AppendText("*************************************************************************\r\n");

                //Get the pswrdgen.py defaults values and assign them to the C# equivalent variables
                SWAPS = (PythonDictionary)pe.EvaluateAs<PythonDictionary>("i.SWAPS").Clone();
                MINLENGTH = (int)pe.EvaluateAs<object>("i.MINLENGTH");
                MAXLENGTH = (int)pe.EvaluateAs<object>("i.MAXLENGTH");
                CAPLENGTH = (int)pe.EvaluateAs<object>("i.CAPLENGTH");
                GENCOUNT  = (int)pe.EvaluateAs<object>("i.GENCOUNT");
                ADDCHAR = (string)pe.EvaluateAs<object>("i.ADDCHAR");
                ADDCOUNT = (int)pe.EvaluateAs<object>("i.ADDCOUNT");
                WORDFILELISTS = (List)pe.EvaluateAs<List>("i.WORDFILELISTS");

                //*** Update the controls to display to user
                //Display the current SWAP PythonDictionary ruleset
                tbSwapSet.Text = SWAPS.ToString();

                //Display the current ADDCHAR ruleset
                tbInsertionChars.Text = ADDCHAR;

                //Update cbMinLength and the Event will update cbMaxLength and cbCaps
                int numbers = 3;
                if (MINLENGTH <= MAXLENGTH)
                {
                    //Populate the choices for MinLength
                    while (numbers <= 25)
                    {
                        cbMinLength.Items.Add(numbers);
                        numbers = numbers + 1;
                    }
                    cbMinLength.SelectedItem = MINLENGTH;
                    cbMaxLength.SelectedItem = MAXLENGTH;
                    cbCaps.SelectedItem = CAPLENGTH;

                    //Populate the choices for MinLength
                    numbers = 1;
                    while (numbers <= 101)
                    {
                        cbGencount.Items.Add(numbers);
                        numbers = numbers + 1;
                    }
                    cbGencount.SelectedItem = GENCOUNT;

                    //Populate the choices for AddCount
                    numbers = 0;
                    while (numbers <= 40)
                    {
                        cdAddCount.Items.Add(numbers);
                        numbers = numbers + 1;
                    }
                    cdAddCount.SelectedItem = ADDCOUNT;

                    //Make bUpdate button enabled false since their were no changes
                    //  this must be done after its data population
                    bUpdate.Enabled = false;
                    bSavesettings.Enabled = false;
                }
                else
                    MessageBox.Show("MINLENGTH > MAXLENGTH ; Can not populate cbMinLength");

                //update the file list combobox
                IEnumerator listenum = WORDFILELISTS.GetEnumerator();
                while (listenum.MoveNext())
                    cbWordFiles.Items.Add(listenum.Current);
                cbWordFiles.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("bootstrap error:\r\n" + ex.Message + "\r\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Update the script vars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bUpdate_Click(object sender, EventArgs e)
        {
            //Create variable bridge from C# to IronPython engine
            pe.ExecuteCommand("interface_val = 0");
            pe.ExecuteCommand("user_val = {}");

            //Set the IronPython bridge variables...
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", cbMinLength.SelectedItem);
            pe.ExecuteCommand("i.MINLENGTH = interface_val");
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", cbMaxLength.SelectedItem);
            pe.ExecuteCommand("i.MAXLENGTH = interface_val");
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", cbCaps.SelectedItem);
            pe.ExecuteCommand("i.CAPLENGTH = interface_val");
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", cbGencount.SelectedItem);
            pe.ExecuteCommand("i.GENCOUNT = interface_val");
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", cdAddCount.SelectedItem);
            pe.ExecuteCommand("i.ADDCOUNT = interface_val");
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("interface_val", tbInsertionChars.Text.Trim());
            pe.ExecuteCommand("i.ADDCHAR = interface_val");

            //This was the only way I could succesfully update the SWAP PythonDictionary from a string
            SWAPS.Clear();
            try
            {
                SWAPS = (PythonDictionary)pe.EvaluateAs<PythonDictionary>(tbSwapSet.Text.Trim()).Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nInvalid SwapSet. Autofixing to an empty swapset {}");
                //Fix for user...
                tbSwapSet.Text = "{}";
                SWAPS = (PythonDictionary)pe.EvaluateAs<PythonDictionary>(tbSwapSet.Text.Trim()).Clone();
            }
            
            //Now set the SWAP bridge
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("user_val", SWAPS);
            pe.ExecuteCommand("i.SWAPS = user_val");

            //Set the C# password GENCOUNT
            GENCOUNT = (int)cbGencount.SelectedItem;

            //Notify user...
            tbDisplay.AppendText("Password options successfully UPDATED!\r\n");

            bUpdate.Enabled = false;
            bSavesettings.Enabled = true;
        }

        /// <summary>
        /// Run the script with the current vars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRun_Click(object sender, EventArgs e)
        {
            //the pswrdgen.py run method only generates one password
            //  so we must loop it according to GENCOUNT
            for (int i = 0; i < GENCOUNT; i++)
            {
                tbDisplay.AppendText(pe.EvaluateAs<string>("i.run()") + "\r\n");
            }

        }

        /// <summary>
        /// Downloads the latest pswrdgen.py as newpswrdgen.py
        /// </summary>
        /// <returns></returns>
        private bool DownloadNewpswrdgen()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Joe.Utils.Helper.DownloadWebpage(Common.pswrdgen_url, Common.newpswrdgen_py))
                {
                    Cursor.Current = Cursors.Default;
                    return true;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Check for pswrdgen.py updates using the internet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDownload_Click(object sender, EventArgs e)
        {
            #region autoupdate
            string ver = "";
            bool downloaded = DownloadNewpswrdgen();
            //Download the current version 
            if (downloaded)
            {
                tbDisplay.AppendText("Downloaded latest pswrdgen.py file as newpswrdgen.py...\r\n");
            }
            else
                tbDisplay.AppendText("Could not download latest pswrdgen.py file\r\n");

            /////BUG: PROGRAM FREEZES BECAUSE IT CAN NOT RELOAD WITH CLOSING AND RESTARTING
            //Try and download the latest version
            if (downloaded)
            {
                //Reimport pswrdgen into IronPython to get the new info
                temp_pe.ExecuteCommand("import sys");
                temp_pe.ExecuteCommand("sys.path.append(\"C:\\Python24\\Lib\")");
                temp_pe.ExecuteCommand("import os");
                temp_pe.ExecuteCommand("import newpswrdgen");
                ver = pe.EvaluateAs<string>("newpswrdgen.__version__");
                
                if (ver != currentversion)
                {
                    DialogResult dResult = MessageBox.Show("Do you wish to update to version " + ver + "?\r\nThe application will automatically close and restart.", "pswrdgen.py Autoupdate", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        //make backup of pswrdgen.py
                        File.Copy(Common.pswrdgen_py, Common.bakpswrdgen_py, true);
                        //Copy newpswrdgen.py to pswrdgen.py
                        File.Copy(Common.newpswrdgen_py, Common.pswrdgen_py, true);

                        //We have a new pswrdgen.py so clear we must restart the application
                        Application.Restart();

                    }
                    else if (dResult == DialogResult.No)
                    {

                    }
                    else if (dResult == DialogResult.Cancel)
                    {

                    }
                }
                else
                {
                    tbDisplay.AppendText("You are using the latest pswrdgen.py file version " + ver + "\r\n");
                }
                
            }
            #endregion autoupdate
        }

        #region Events
        /// <summary>
        /// Update cbMaxLength when changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMinLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;

            //Populate the choices for MaxLength
            cbMaxLength.Items.Clear();
            int numbers = (int)cbMinLength.SelectedItem;
            while (numbers <= 25)
            {
                cbMaxLength.Items.Add(numbers);
                numbers = numbers + 1;
            }
            cbMaxLength.SelectedIndex = 0;

            //Populate the choices for CAPLENGTH
            cbCaps.Items.Clear();
            numbers = 0;
            while (numbers <= (int)cbMinLength.SelectedItem)
            {
                cbCaps.Items.Add(numbers);
                numbers = numbers + 1;
            }
            cbCaps.SelectedIndex = 0;
        }

        private void cbMaxLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void cbCaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void cbGencount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void cdAddCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void tbSwapSet_TextChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void tbInsertionChars_TextChanged(object sender, EventArgs e)
        {
            //Make bUpdate button enabled since their were some changes
            bUpdate.Enabled = true;
            bSavesettings.Enabled = false;
        }

        private void bSavesettings_Click(object sender, EventArgs e)
        {
            pe.ExecuteCommand("i._savesettings()");
            bSavesettings.Enabled = false;
        }
        #endregion Events

        /// <summary>
        /// Browse to a word file for random word generation
        /// File must one word in the beginning of each line (no spaces)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBrowse_Click(object sender, EventArgs e)
        {
            //Browse to the first.py sample file and import it
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.ShowDialog();

            //Now set the WORDFILELISTS bridge
            ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("user_val", Path.GetFullPath(ofd.FileName));
            pe.ExecuteCommand("i.addnounfile(user_val)");

            //Add the users path to the internal list, bUpdate_Click updates IPEngine var
            WORDFILELISTS.Add(Path.GetFullPath(ofd.FileName));
            cbWordFiles.Items.Add(Path.GetFullPath(ofd.FileName));
            cbWordFiles.Update();
        }

        /// <summary>
        /// Remove the selected word file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
                // Displays the MessageBox.
                DialogResult result = MessageBox.Show("Are you sure you want to remove\r\n" + cbWordFiles.SelectedItem.ToString(), "Confirm Remove", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );
                if (result == DialogResult.Yes)
                {
                    if (cbWordFiles.Items.Count != 1)
                    {
                        //Now set the WORDFILELISTS bridge
                        ScriptDomainManager.CurrentManager.Host.DefaultModule.SetVariable("user_val", cbWordFiles.SelectedItem);
                        pe.ExecuteCommand("i.removenounfile(user_val)");

                        cbWordFiles.Items.RemoveAt(cbWordFiles.SelectedIndex);//  .RemoveAt(cbWordFiles.SelectedIndex);
                        cbWordFiles.SelectedIndex = 0;
                        cbWordFiles.Update();

                    }
                    else
                    {
                        MessageBox.Show("You can not remove the only word file!");
                    }
                }
        }


    }

    #region Common Class
    /// <summary>
    /// Common strings //Environment.SpecialFolder.Desktop
    /// Set and Customize HERE!!!
    /// </summary>
    public class Common
    {
        #region AppPaths
        /// <summary>
        /// Application.StartupPath + "\\pswrdgen.py"
        /// </summary>
        public static string pswrdgen_py = Application.StartupPath + "\\pswrdgen.py";

        /// <summary>
        /// Application.StartupPath + "\\newpswrdgen.py"
        /// </summary>
        public static string newpswrdgen_py = Application.StartupPath + "\\newpswrdgen.py";

        /// <summary>
        /// Application.StartupPath + "\\bakpswrdgen.py"
        /// </summary>
        public static string bakpswrdgen_py = Application.StartupPath + "\\bakpswrdgen.py";

        /// <summary>
        /// Update URL to the latest pswrdgen.py
        /// </summary>
        public static string pswrdgen_url = (@"http://pswrdgen.googlecode.com/svn/trunk/pswrdgen.py");

        #endregion AppPaths

        #region Python24Paths
        /// <summary>
        /// Folder to Python library modules.
        /// default: "C:\Python24\Lib"
        /// </summary>
        public static string Python24_Lib = @"C:\Python24\Lib";

        /// <summary>
        /// Folder to Tkinter library modules.
        /// default: "C:\Python24\Lib\lib-tk"
        /// </summary>
        public static string Python24_Lib_lib_tk = @"C:\Python24\Lib\lib-tk";

        /// <summary>
        /// default: "C:\Python24\libs"
        /// </summary>
        public static string Python24_libs = @"C:\Python24\libs";

        /// <summary>
        /// default: "C:\Python24\DLLs"
        /// </summary>
        public static string Python24_DLLs = @"C:\Python24\DLLs";

        /// <summary>
        /// Some useful programs written in Python.
        /// default: "C:\Python24\Tools"
        /// </summary>
        public static string Python24_Tools = @"C:\Python24\Tools";

        /// <summary>
        /// Some useful programs written in Python.
        /// default: "C:\Python24\Tools\Scripts"
        /// </summary>
        public static string Python24_Tools_Scripts = @"C:\Python24\Tools\Scripts";
        #endregion Python24Paths
    }
    #endregion Common Class

}