using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MkvJoiner
{
    public partial class Form1 : Form
    {

        private List<string> loadedFileNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        public bool isValidMedia(string filename)
        {
            bool isValid = false;

            //Gets the extension at end of a filename
            string fileExtesion = filename.Substring(filename.LastIndexOf("."));

            //Checks to make sure file is an xls file
            if (fileExtesion.Equals(".mkv", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
            }
            //Return whether file is valid or not
            return isValid;
        }

        public void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            //Creates File list array from items draged onto the list.
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, true);

            //Checks to make sure each file dropped is an xls.
            foreach (string f in FileList)
            {
                //Sets file name to a variable
                string filename = f;

                //Checks if the files that were dropped are valid media files
                if (isValidMedia(f))
                {

                    //Checks if the files that were dropped had previously been added
                    if (loadedFileNames.Contains(filename) == false)
                    {

                        //Adds the files to a variable to store full path of each file
                        loadedFileNames.Add(filename);
                        listBox1.Items.Add(filename);
                    }
                }
            }
            Join();
        }

        public void listBox1_DragEnter(object sender, DragEventArgs e)
        {

            // Check if the Dataformat of the data can be accepted
            // (we only accept file drops from Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        public void Join()
        {
            while (loadedFileNames.Any())
            {
                string program = "\"C:\\Program Files\\MKVToolNix\\mkvmerge.exe\"" + " -o ";

                string filename1 = "";
                string filename2 = "";
                string filename3 = "";
                string filename4 = "";
                string filename5 = "";
                string filename6 = "";

                int fileCount = loadedFileNames.Count;
                if (fileCount == 3)
                {

                    int i1 = 0;
                    int i2 = 1;
                    int i3 = 2;

                    filename1 = loadedFileNames[i1];
                    filename2 = loadedFileNames[i2];
                    filename3 = loadedFileNames[i3];

                    string nopathFilename = Path.GetFileNameWithoutExtension(filename1);
                    string outputFileName = textBox1.Text + "\\" + nopathFilename + "x.mkv";

                    string output = "\r\n" + program + "\"" + outputFileName + "\" " + "\"" + filename1 + "\" + " + "\"" + filename2 + "\" + " + "\"" + filename3 + "\"";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(textBox1.Text + "\\Merge.bat", true))
                    {
                        file.WriteLine(output);
                    }
                }
                else if (fileCount == 4)
                {

                    int i1 = 0;
                    int i2 = 1;
                    int i3 = 2;
                    int i4 = 3;

                    filename1 = loadedFileNames[i1];
                    filename2 = loadedFileNames[i2];
                    filename3 = loadedFileNames[i3];
                    filename4 = loadedFileNames[i4];

                    string nopathFilename = Path.GetFileNameWithoutExtension(filename1);
                    string outputFileName = textBox1.Text + "\\" + nopathFilename + "x.mkv";

                    string output = "\r\n" + program + "\"" + outputFileName + "\" " + "\"" + filename1 + "\" + " + "\"" + filename2 + "\" + " + "\"" + filename3 + "\" + " + "\"" + filename4 + "\"";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(textBox1.Text + "\\Merge.bat", true))
                    {
                        file.WriteLine(output);
                    }
                }
                else if (fileCount == 5)
                {

                    int i1 = 0;
                    int i2 = 1;
                    int i3 = 2;
                    int i4 = 3;
                    int i5 = 4;

                    filename1 = loadedFileNames[i1];
                    filename2 = loadedFileNames[i2];
                    filename3 = loadedFileNames[i3];
                    filename4 = loadedFileNames[i4];
                    filename5 = loadedFileNames[i5];


                    string nopathFilename = Path.GetFileNameWithoutExtension(filename1);
                    string outputFileName = textBox1.Text + "\\" + nopathFilename + "x.mkv";

                    string output = "\r\n" + program + "\"" + outputFileName + "\" " + "\"" + filename1 + "\" + " + "\"" + filename2 + "\" + " + "\"" + filename3 + "\" + " + "\"" + filename4 + "\" + " + "\"" + filename5 + "\"";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(textBox1.Text + "\\Merge.bat", true))
                    {
                        file.WriteLine(output);
                    }
                }
                else if (fileCount == 6)
                {

                    int i1 = 0;
                    int i2 = 1;
                    int i3 = 2;
                    int i4 = 3;
                    int i5 = 4;
                    int i6 = 5;

                    filename1 = loadedFileNames[i1];
                    filename2 = loadedFileNames[i2];
                    filename3 = loadedFileNames[i3];
                    filename4 = loadedFileNames[i4];
                    filename5 = loadedFileNames[i5];
                    filename6 = loadedFileNames[i6];

                    string nopathFilename = Path.GetFileNameWithoutExtension(filename1);
                    string outputFileName = textBox1.Text + "\\" + nopathFilename + "x.mkv";

                    string output = "\r\n" + program + "\"" + outputFileName + "\" " + "\"" + filename1 + "\" + " + "\"" + filename2 + "\" + " + "\"" + filename3 + "\" + " + "\"" + filename4 + "\" + " + "\"" + filename5 + "\" + " + "\"" + filename6 + "\"";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(textBox1.Text + "\\Merge.bat", true))
                    {
                        file.WriteLine(output);
                    }
                }

                    loadedFileNames.Clear();
                    listBox1.Items.Clear();

                }

            }

        }

    
}
