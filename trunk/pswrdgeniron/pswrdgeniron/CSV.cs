//version 0.09032007
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
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Windows.Forms;

namespace Joe.Utils
{
    class CSV
    {
        /// <summary>
        /// Saves a Comma Separated Values (CVS) File
        /// </summary>
        /// <param name="newfilename">Full path and filename</param>
        /// <param name="StrBuilder">Stringbuilder with csv format</param>
        /// <returns></returns>
        public static bool CreateCSVFile(string newfilename, StringBuilder StrBuilder)
        {
            try
            {
                FileStream fs = File.Create(newfilename);
                fs.Close();

                using (StreamWriter sw = new StreamWriter(newfilename))
                {
                    // Add some text to the file.
                    sw.Write(StrBuilder.ToString());
                    sw.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }

    class Helper
    {
        public static string TmpFilename;

        /// <summary>
        /// Creates a Text File
        /// </summary>
        public static void CreateTextFile(string path_filename, Stream rcvStream)
        {
            byte[] respBytes = new byte[256];
            int byteCount;

            FileStream fs = new FileStream(path_filename, FileMode.Create, FileAccess.Write);
            do
            {
                byteCount = rcvStream.Read(respBytes, 0, 256);
                fs.Write(respBytes, 0, byteCount);
            } while (byteCount > 0);

            fs.Close();
            rcvStream.Close();
        }

        /// <summary>
        /// Creates file from a webpage
        /// </summary>
        public static bool DownloadWebpage(string url, string new_path_filename, string extention)
        {
            //Create Temp File path and name Saves to current system's temp folder
            if (extention.IndexOf(".") != -1)
                TmpFilename = new_path_filename + extention;
            else
                TmpFilename = new_path_filename + "." + extention;

            //MessageBox.Show(TmpFilename);

            //Get the url and make sure it is not https
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
                //TxtUrl.Text = url;
            }

            //Create the HTTP Connection
            HttpWebRequest req;
            try
            {
                req = (HttpWebRequest)HttpWebRequest.Create(url);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TxtUrl.Focus();
                return false;
            }

            //Get the WebResponse class
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException err)
            {
                MessageBox.Show(err.Status + " - " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = (HttpWebResponse)err.Response;
                if (resp == null)
                {
                    //TxtUrl.Focus();
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TxtUrl.Focus();
                return false;
            }

            //Get stream and place into temp file
            Stream rcvStream = resp.GetResponseStream();

            //Create temp USA Today internet file
            CreateTextFile(TmpFilename, rcvStream);

            resp.Close();
            return true;
        }
        public static bool DownloadWebpage(string url, string new_path_filename)
        {
            //Create Temp File path and name Saves to current system's temp folder
            TmpFilename = new_path_filename;
            //MessageBox.Show(TmpFilename);

            //Get the url and make sure it is not https
            if (url.StartsWith("https://"))
            {
                MessageBox.Show("https not supported");
            }
            else
            {

                //Create the HTTP Connection
                HttpWebRequest req;
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create(url);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //TxtUrl.Focus();
                    return false;
                }

                //Get the WebResponse class
                HttpWebResponse resp;
                try
                {
                    resp = (HttpWebResponse)req.GetResponse();
                }
                catch (WebException err)
                {
                    MessageBox.Show(err.Status + " - " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    resp = (HttpWebResponse)err.Response;
                    if (resp == null)
                    {
                        //TxtUrl.Focus();
                        return false;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //TxtUrl.Focus();
                    return false;
                }

                //Get stream and place into temp file
                Stream rcvStream = resp.GetResponseStream();

                //Create temp USA Today internet file
                CreateTextFile(TmpFilename, rcvStream);

                resp.Close();
            }
            return true;
        }

        /// <summary>
        /// Evaluate if object can be represented as a number
        /// </summary>
        /// <param name="Expression">object</param>
        /// <returns></returns>
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}
