﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO.Compression;
using GroupMove.Entity;
using Excel = Microsoft.Office.Interop.Excel;


namespace GroupMove
{
    public partial class Form1 : Form
    {
        string[][] arrSkil = null;
        private FolderBrowserDialog browserDlg;
        private OpenFileDialog browserFileDlg;
        ToolTip toolTip1;

        public Form1()
        {
            InitializeComponent();


			//run with parameters
			string[] args = Environment.GetCommandLineArgs();

			if (args.Length > 1)
				tbFile.Text = args[1];
			else
				tbFile.Text = Properties.Settings.Default.lastFile;

			tbFrom.Text = Properties.Settings.Default.lastFromDir;
            tbTo.Text   = Properties.Settings.Default.LastToDir;

            browserDlg = new System.Windows.Forms.FolderBrowserDialog();
            browserFileDlg = new System.Windows.Forms.OpenFileDialog();

			if (tbFile.Text.Length > 0)
				browserFileDlg.InitialDirectory = Path.GetDirectoryName(tbFile.Text);

            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.

            toolTip1.SetToolTip(this.btnFile, "Browse to and select a file containing the group to extract");
            toolTip1.SetToolTip(this.tbFile, "path to the csv file containing the group to extract from downloaded assignments");

            toolTip1.SetToolTip(this.btnFrom, "Browse to and select a source-parent folder.");
            toolTip1.SetToolTip(this.tbFrom, "Source-parent folder of the downloaded assignments  Can also be a path to a zip file");
            toolTip1.SetToolTip(this.btnTo, "Browse to and select a destnation-parent folder");
            toolTip1.SetToolTip(this.tbTo, "Destnation-parent folder to move assignments to.");
            toolTip1.SetToolTip(this.btnStart, "Start moving assignments");
            
            toolTip1.SetToolTip(this.tbResult, "Action reslults will be displayed here");
            toolTip1.SetToolTip(this.comboHopar, "Select which group you want to extract from");
            toolTip1.SetToolTip(this.statusBar1, "Bar to show information about controls on this form");
            statusBar1.Text = "";

			tmrKeyPressFileKey.Enabled = true;
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            browserDlg.Reset();
            browserDlg.Description = "Select source directory...";
            
            browserDlg.SelectedPath = tbFrom.Text;
            if (browserDlg.ShowDialog() == DialogResult.OK)
                tbFrom.Text = browserDlg.SelectedPath;
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            browserDlg.Description = "Select destination directory...";
            browserDlg.SelectedPath = tbTo.Text;
            
            if (browserDlg.ShowDialog() == DialogResult.OK)
                tbTo.Text = browserDlg.SelectedPath;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            //browserFileDlg.= "Select group file...";

            browserFileDlg.FileName = tbFile.Text;
            if (browserFileDlg.ShowDialog() == DialogResult.OK)
                tbFile.Text = browserFileDlg.FileName;
        }

        //This function is not implemented yet, And I am not shure that I will do that anyway.
        private bool copyAssignmentsFromXml(string fullFileName, string desitnationFolder)
        {
            StringBuilder output = new StringBuilder();

            string xmlString;

            try
            {
                xmlString = File.ReadAllText(fullFileName);
            }
            catch (IOException e)
            {
                Console.WriteLine("error opening xml file");
                return false;
            }

            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    if (!reader.Read())
                        return false; //no Declaration or ProcessingInstruction

                    var ret = reader.Read();
                    ret = reader.Read();

                    if (!ret || reader.NodeType !=XmlNodeType.Element || reader.Name != "verkefni")
                        return false;
                    ret = reader.Read();
                    while (ret && reader.Read() && reader.NodeType == XmlNodeType.Element  && reader.Name == "hopur")
                    {
                        if (!reader.Read() || reader.NodeType != XmlNodeType.Text)
                            return true;//getting this far will be considered success.

                        Console.WriteLine("Text: " + reader.Value);
                        if (!reader.Read()) return true;//end element
                        ret = reader.Read(); //white space

                    }
                 }

              }

            return true;
        }


        private string[][] getAssignmentFromExcel(string fullFileName)
        {
            int ret = -1;

            Excel.Workbook MyBook = null;
            Excel.Worksheet MySheet = null;


            var myApp = new Excel.Application();


            
            MyBook = myApp.Workbooks.Open(fullFileName);


            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
            int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            if (lastRow == 0)
                return null;

            var lines = new List<string[]>();
            foreach (Excel.Range row in MySheet.UsedRange.Rows)
            {
                int count, i;
                count = row.Columns.Count;
                //count = row.Count;
                string[] line = new string[count];
                i = 0;
                foreach (Excel.Range cell in row.Columns)
                {
                    if (cell.Value != null) { 
                        line[i] = cell.Value.ToString(); 
                        /*System.Console.Write("(" + row.Column + ")(" + cell.Column + ") ");
                        System.Console.WriteLine(cell.Value + "   ");*/
                    }
                    else
                    {
                        line[i] = "";
                    }
                    i++;

                }
                lines.Add(line);

            }

            ///https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k(Microsoft.Office.Interop.Excel._Worksheet.Cells);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true


            return lines.ToArray();
        }

        private string[][] getAssignment(string fullFileName)
        {
            string str;

            StreamReader sr;
            try
            {
                sr = new StreamReader(fullFileName, System.Text.Encoding.UTF7);
            }
            catch(IOException)
            {
                return null;
            }
                var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(';',',');
                lines.Add(Line);
                Row++;
            
            }

            return lines.ToArray();
            
        }
        private bool copyAssignmentsFromCSV(string fullFileName, string sourceFolder, string desitnationFolder)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(fullFileName);
            }
            catch (IOException)
            {
                WriteLine("Could not read the csv file: \"" + fullFileName + "\"");
                return false;
            }
            WriteLine("Starting copying assignments");
            
            while ((line = file.ReadLine()) != null)
            {
                string fromFolder = sourceFolder +"\\"+ line;
                string toFolder   = desitnationFolder + "\\" + line;
                counter++;
                if (Directory.Exists(fromFolder))
                { 
                    
                    try
                    {
                        Directory.Move(fromFolder, toFolder);
                        WriteLine("Moving folder: " + fromFolder);
                    }
                    catch (IOException)
                    {
                        WriteLine("ERROR : unable to move folder");
                    }
                }
                else
                    WriteLine("Folder :\"" + fromFolder +"\" not found!");
                    
            }

            file.Close();


            return true;
        }
       

        /*
            returns unique values from a specifice coloumn in an array
        */
        private string[] getUnique(string[][] arrayOfArray, int column)
        {
            if (!(column < arrayOfArray[0].Length))
                return null;//column out of index
            List<string> list = new List<string>();
            for (int i = 1; i < arrayOfArray.Length; i++)
            {
               if(list.IndexOf(arrayOfArray[i][column])==-1)
                    list.Add(arrayOfArray[i][column]);
            }
            list.Sort();
            return list.ToArray();
        }

        private bool moveAssignments(string[] verkefnaHopsID, string sourceFolder, string desitnationFolder)
        {
            foreach (var VARIABLE in verkefnaHopsID)
            {


                string fromFolder = sourceFolder + "\\" + VARIABLE;
                string toFolder = desitnationFolder + "\\" + VARIABLE;

                if (Directory.Exists(fromFolder))
                {

                    try
                    {
                        Directory.Move(fromFolder, toFolder);
                        WriteLine("Moving folder: " + fromFolder);
                    }
                    catch (IOException)
                    {
                        WriteLine("ERROR : unable to move folder");
                    }
                }
                else
                    WriteLine("Folder :\"" + fromFolder + "\" not found!");

            }

            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tbResult.Clear();


            //string[][] arrSkil = getAssignment(tbFile.Text);
            
            string hopur = comboHopar.Items[comboHopar.SelectedIndex].ToString();
            List<string> verkHoparID = new List<string>();

            for (int i = 1; i < arrSkil.Length; i++)
            {
               
                if (arrSkil[i][3] == hopur && arrSkil[i][2].Length > 0)
                {
                   
                    Write(arrSkil[i][3] + "\t"); //Hópur
                    WriteLine(arrSkil[i][2]); //verkefni
                    Write(arrSkil[i][1] + "\t"); //kennitala
                    verkHoparID.Add(arrSkil[i][2]);
                }
        }
            
            verkHoparID.Sort();
            int ret = pathToWhat(tbFrom.Text);

            if (ret == 1) //directory
                moveAssignments(verkHoparID.ToArray(), tbFrom.Text, tbTo.Text);
            else if (ret == 4)
                unZipAssignments(verkHoparID.ToArray(), tbFrom.Text, tbTo.Text);
        else
            MessageBox.Show("Invalid value in the From textbox", "Error", MessageBoxButtons.OK);


        }

		//returns a the string before the last index of.....
		//returns a string with of 0 length if lastIndexOfMe is not found in the string 
	    private string getBeforeLastIndexOf(string str, char lastIndexOfMe)
	    {
		    int index = str.LastIndexOf(lastIndexOfMe);
		    if (index == -1)
			    return "";
			string strRet = str.Remove(index);

		    return strRet;
	    }

		//replaces all '/' with '\' and returns the the string before the last index of '\'
		//if no '\' is found then the return value is ""
		private string MergeAndExtractPath(string str)
		{
			str = str.Replace('/', '\\');
			return getBeforeLastIndexOf(str, '\\');
		}

		private int unZipFolder(string pathToZip, string destinationFolder)

        {
            int ret = -1;
            using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
            {
                ret = 1;
				int x = 0;
				if (pathToZip == "C:\\Users\\GuðjónHólm\\Desktop\\testMove\\out\\58668\\1373926\\Verkefni_1.zip")
					x = 1;
	            bool firstEntry = false;
				foreach (ZipArchiveEntry entry in archive.Entries)
                {
	                
						//if (entry.FullName == "1373926")
		              
                    try
                    {
	                    Directory.CreateDirectory(destinationFolder);
                        if (entry.FullName[entry.FullName.Length - 1] == '/')
                        {  //it's a directory let's create one
                            string fullEntryPath = Path.Combine(destinationFolder, entry.FullName);
                            fullEntryPath.Replace('/', '\\');
                            if (!Directory.Exists(fullEntryPath))
                                Directory.CreateDirectory(fullEntryPath);
                        }
                        else
                        {

	                        string outFullFileName = Path.Combine(destinationFolder, entry.FullName);
	                        string pathTo = MergeAndExtractPath(outFullFileName);
							if (pathTo.Length > 0 && !Directory.Exists(pathTo))
								Directory.CreateDirectory(pathTo);
							entry.ExtractToFile(outFullFileName, true);
                        }
                    }
                    catch (DirectoryNotFoundException dirEx)
                    {
                        // Let the user know that the directory did not exist.
                        Console.WriteLine("Directory not found: " + dirEx.Message);
                    }
                    catch
                    {
                        WriteLine("Error when extracting");
                        ret = -2;
                    }
                }
            }

            return ret;
        }

        

        //returns the number of assignments extracted
        //returns -1 if an error occurred
        private int unZipAssignments(string[] verkHoparID, string pathToZip, string destinationFolder)
        {
            tbResult.Clear();
            int ret = -1;
            using (ZipArchive archive = ZipFile.OpenRead(pathToZip))
            {
                ret = 1;
                int zipStatus = 0;
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    
                    
                     string[] path = entry.FullName.Split('/');

                   if (Array.IndexOf(verkHoparID, path[1] ) > -1 )
                   {
                       
                        WriteLine("Extracting \"" + entry.FullName + "\"");
                      
                       if (!Directory.Exists(destinationFolder + "\\" + path[0] + "\\" + path[1]))
                            Directory.CreateDirectory(destinationFolder + "\\" + path[0] + "\\" + path[1]);
                        
                        try
                        {
                            if (entry.FullName[entry.FullName.Length - 1] == '/')
                            {
                                string fullEntryPath = Path.Combine(destinationFolder, entry.FullName);
                                fullEntryPath.Replace('/', '\\');
                                if (!Directory.Exists(fullEntryPath))
                                    Directory.CreateDirectory(fullEntryPath);
                            }
                            else
                            {
                                entry.ExtractToFile(Path.Combine(destinationFolder, entry.FullName), true);
                                
                            }

                            
                            if (entry.FullName.EndsWith(".zip") )
                            {
                                DialogResult dialogResult;
                                if (zipStatus == 0)
                                {
                                    dialogResult = MessageBox.Show("There is a zipfile in at least one of the solution.\n\nDo you want to extract all zip files for all solutions?", "Zip file detected ", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                        zipStatus = 1;
                                    else
                                        zipStatus = 2;
                                }

                                if (zipStatus == 1)
                                {
                                    string zipf = Path.Combine(destinationFolder, entry.FullName);
                                    zipf = zipf.Replace('/', '\\');
                                    //string desti = zipf.Remove(zipf.LastIndexOf('\\'));
                                    string desti = zipf.Remove(zipf.Length - 4);

                                    unZipFolder(zipf, desti);
                                }
                            }//it's a zip
                        }
                        catch (DirectoryNotFoundException dirEx)
                        {
                            // Let the user know that the directory did not exist.
                            WriteLine("Directory not found: " + dirEx.Message);
                        }
                        catch
                        {
                            WriteLine("Error when extracting");
                            ret = -2;

                        }
                    }
                    /*if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }*/
                    //WriteLine(entry.FullName);
                }
            }

            return ret;
        }

        private void tbFrom_TextChanged(object sender, EventArgs e)
        {
           SetButtonStatus();
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {
            
            tmrKeyPressFileKey.Enabled = false;
            tmrKeyPressFileKey.Enabled = true;
        }

        private void tbTo_TextChanged(object sender, EventArgs e)
        {
            SetButtonStatus();
        }

        private void SetButtonStatus()
        {
            bool toExists = Directory.Exists(tbTo.Text);

            int fromType = pathToWhat(tbFrom.Text);
           
            if ( (fromType == 1 || fromType == 4) && toExists && File.Exists(tbFile.Text))
            {
                
                btnStart.Enabled = (comboHopar.Items.Count > 0 && comboHopar.SelectedIndex != -1);
            }
            else
            {
                btnStart.Enabled = false;
            }

            makeUploadFileToolStripMenuItem.Enabled =
            openDestinationToolStripMenuItem.Enabled = toExists;

            comboHopar.Enabled = btnStart.Enabled;
	        devideHandinsOntoGroupsToolStripMenuItem.Enabled = btnStart.Enabled;


        }

        private void Write(string textToAppend)
        {
            tbResult.AppendText(textToAppend);
        }
        private void WriteLine(string textToAppend)
        {
            Write(textToAppend + "\n");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.lastFile    = tbFile.Text;
            Properties.Settings.Default.lastFromDir = tbFrom.Text;
            Properties.Settings.Default.LastToDir = tbTo.Text;
            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenDest_Click(object sender, EventArgs e)
        {
            Process.Start(tbTo.Text);
         
        }

        private void EnableAllControls(Control contr, bool enable)
        {
            foreach (Control c in contr.Controls)
            {
                EnableAllControls(c, enable);
            }
            contr.Enabled = enable;
        }

        private void Read()
        {

            EnableAllControls(this, false);
            tbResult.Clear();
            WriteLine("Reading group file...");

            int ftype = pathToWhat(tbFile.Text);



            if (ftype == 3)
               arrSkil = getAssignment(tbFile.Text);
            else if (ftype == 5)
              arrSkil =  getAssignmentFromExcel(tbFile.Text);

           
            if (arrSkil == null)
            {
                WriteLine("Error opening assignment file");
                return;
            }

			//extract unique
			
			
			string[] hopar = getUnique(arrSkil, 3);
            if (hopar == null)
            {
                WriteLine("Error : Invalid Csv file");
                return;
            }

            comboHopar.Items.Clear();
            foreach (var VARIABLE in hopar)
            {
                comboHopar.Items.Add(VARIABLE);
            }
            if (comboHopar.Items.Count > 0)
                comboHopar.SelectedIndex = 0;
            SetButtonStatus();
            tbResult.Clear();
            WriteLine("Done reading group file!");
           
            EnableAllControls(this, true);
            SetButtonStatus();
        }



        //pathToWhat 
        //    returns:
        //       1 if a directory
        //       2 if a file
        //       3 if a csv file
        //       4 if a zip fie
        //       5 if a xls file
        //       5 if a xlsw file
        //       a negative number if an error occurrs
        //       -1 if path does not point to a file or a directory
        private int pathToWhat(string path)
        {
            FileAttributes attr;

            try
            {
                attr = File.GetAttributes(path);
            }
            catch (FileNotFoundException fnfe)
            {
                return -1;
            }
            catch
            {
                return -2;//all other exceptions
            }


            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return 1;

            if (path.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
                return 3;

            if (path.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase))
                return 4;

            if (path.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                return 5;

            if (path.EndsWith(".xlsw", StringComparison.CurrentCultureIgnoreCase))
                return 5;

            return 2;//a file
        }

        private void tbFile_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string [])e.Data.GetData(DataFormats.FileDrop, false);
            if (files == null)
                return;

            int ftype = pathToWhat(files[0]);
            if (ftype == 3 || ftype == 5)
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
            
        }

        private void tbFrom_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files == null)
                return;
            int ret = pathToWhat(files[0]);
            if (ret == 4 || ret == 1)
                e.Effect = DragDropEffects.All;
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tbTo_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files == null)
                return;

            if (pathToWhat(files[0]) == 1)
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tbFrom_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ret = pathToWhat(files[0]);
            if (ret == 4 || ret == 1)
                tbFrom.Text = files[0];
            SetButtonStatus();
        }

        private void tbFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int ftype = pathToWhat(files[0]);
            if (ftype == 3 || ftype == 5)
                tbFile.Text = files[0];

           

        }

        private void tbTo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (pathToWhat(files[0]) == 1)
                tbTo.Text = files[0];
            SetButtonStatus();
        }

        private void About_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void tmrKeyPressFile(object sender, EventArgs e)
        {
            tmrKeyPressFileKey.Enabled = false;

            int ftype = pathToWhat(tbFile.Text);
            if (ftype == 3 || ftype == 5)
                Read();
                
            SetButtonStatus();
        }

        private void control_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = toolTip1.GetToolTip((Control)sender);
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            statusBar1.Text = "";
        }

        private void aboutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = "Information about this application";
        }

        private void openDestinationToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = "Open the destination folder";
        }

        private void makeUploadFileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = "Create a zip file in the destination folder for uploading, containing all ??-einkunn.txt files";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void makeUploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetDirectories(tbTo.Text);
            int n;
            
            foreach (string fileName in fileEntries)
            {
                n = fileName.LastIndexOf('\\') + 1;
                string name = fileName.Substring(n, fileName.Length - n);
                ;
                if (int.TryParse(name, out n) == true) //check if it's a number
                { 
                    WriteLine(fileName);
                    zipGrades(name, tbTo.Text, tbTo.Text);
                }
                else
                {
                    WriteLine("Ignoring " + name);
                }
            }
               

           
        }

        private void zipGrades(string assignment, string assignmentParent, string destinationDir)
        {
            string zipfile = destinationDir + @"\" + assignment + "_grades.zip";

            string[] returnDirs = Directory.GetDirectories(assignmentParent + "\\" + assignment);
            //búa til archive
            int n;
            using (FileStream zipToOpen = new FileStream(zipfile, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach (var dir in returnDirs)
                    {
                       
                        n = dir.LastIndexOf('\\') + 1;
                        string dirName = dir.Substring(n, dir.Length - n);
                        string[] returnFiles = Directory.GetFiles(dir, "*einkunn.txt");
                        WriteLine(dir + "{");
                        foreach (var file in returnFiles)
                        {
                            //adda file í archive
                            n = file.LastIndexOf('\\') + 1;
                            string fileName = file.Substring(n, file.Length - n);
                            string achivePath = assignment + '/' + dirName + '/' + fileName;
                            archive.CreateEntryFromFile(file, achivePath);
                            Write(file + " ");
                        }
                        WriteLine("}");
                    }
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.guttih.com/groupmove/help.html");
            Process.Start(sInfo);
        }

        private void helpToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = "Open a webpage with help about this application";
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Text = "Exit this application";
        }

		private void devideHandinsOntoGroupsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
		{
			statusBar1.Text = "Show a suggestion on how to split handin assignments into groups";
		}

		private void devideHandinsOntoGroupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tbResult.Clear();
			WriteLine("Divide the handings onto groups!");
			var ass = new MySchoolAssignment(arrSkil);
			ass.SplitAssignments(tbResult);
		}

	}
}
