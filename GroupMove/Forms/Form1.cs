using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using GroupMove.Entity;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;


namespace GroupMove
{
    public partial class Form1 : Form
    {
        string[][] arrSkil = null;
	    private bool arrayHasBeenSplitup = false;
        private FolderBrowserDialog browserDlg;
        private OpenFileDialog browserFileDlg;
        ToolTip toolTip1;

        public Form1()
        {
            InitializeComponent();


			//run with parameters
			string[] args = Environment.GetCommandLineArgs();

			
			tbFile.Text = Properties.Settings.Default.lastFile;
			
			for(var i = 1; i < args.Length;i++){
				switch (args[i]){
					case "/uninstall":
						Uninstall(null);
						break;

					case "/uninstallAll":
									Uninstall(null);
									break;
					default:
						tbFile.Text = args[i];
									break;
				}
			}

			tbFrom.Text = Properties.Settings.Default.lastFromDir;
            tbTo.Text   = Properties.Settings.Default.LastToDir;

            browserDlg = new System.Windows.Forms.FolderBrowserDialog();
            browserFileDlg = new System.Windows.Forms.OpenFileDialog();

			if (tbFile.Text.Length > 0)
				browserFileDlg.InitialDirectory = Path.GetDirectoryName(tbFile.Text);


			Properties.Settings.Default.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

			//Delete files, if GroupMove previously downloaded a setup- and/or config file
	        string fileName = Path.GetTempPath() + Properties.Settings.Default.downloadSetupFileName;
	        if (File.Exists(fileName)) File.Delete(fileName);
			fileName = Path.GetTempPath() + Properties.Settings.Default.downloadConfigFileName;
			if (File.Exists(fileName)) File.Delete(fileName);
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
	        saveToRegistry();
        }

	    private void saveToRegistry()
	    {
			AppFunctions Func = new AppFunctions();
		    string str = Application.StartupPath;
		    RegistryKey key = Func.RegistryKeyOpenPath(@"HKEY_CURRENT_USER\SOFTWARE\guttih\GroupMove", true);
			Func.SetRegistryKeyValue(key, "installationPath", str);
		    str = Properties.Settings.Default.version;
			Func.SetRegistryKeyValue(key, "version", str);
		    str = Properties.Settings.Default.productCode;
			Func.SetRegistryKeyValue(key, "productCode", str);
		    key?.Close();

		    //Func.SetRegistryKeyValue(@"HKEY_CURRENT_USER\SOFTWARE\guttih\GroupMove", "ProductCode", "{12345-6789}");

		}

		/// <summary>
		/// Uninstalls GroupMove
		/// </summary>
		/// 
		/// <param name="productCodeGUID">
		///		to uninstall a specific product version pass it's GUID here
		///		to un-install all previous versions, pass null
		/// </param>
		private void Uninstall(string productCodeGUID)
		{

			AppFunctions funcs = new AppFunctions();
			if (productCodeGUID != null)
			{
				funcs.UninstallIfPreviouslyInstalled(productCodeGUID);
			}
			else
			{
				string[] prodcutGuis = new[]
				{
					
					//1.4.1.1 er með bilað upgrade code
					"{EE22E925-C13B-4BC2-B9D0-EF05E1674313}" /*- Version 1.5.1.0*/,
					"{307E97EB-E6AF-44CF-9026-8D3C730BD044}" /*- Version 1.4.3.1, og 1.5.0.0*/, 
					"{09455D04-510E-4F58-B187-0B3B4B06C824}" /*- Version 1.4.2*/, /*1.4.4.1 yfirskrifar þetta sem er gott*/
					"{6A92025F-076D-4B87-88D8-CF6645C81238}" /*- Version 1.3.6.6*/,/*1.4.4.1 yfirskrifar þetta sem er gott*/
					"{73E84FB2-AC29-4EE6-B72C-81517EE0AEFB}" /*- Version 1.3.1.1*/,/*1.4.4.1 yfirskrifar þetta sem er gott*/
					"{D7F420A4-153A-4BBF-9366-4E5614ED8A6F}"  /*- Version 1.2.1.0 og Version 1.1.0.0*/,/*1.4.4.1 yfirskrifar þetta sem er gott*/
					"{9AA8BBC3-FE40-4248-994C-7FA4A82E45AF}"  /*- Version 1.0.1.0  upgrade code: {45CA6C9F-57D6-4684-828D-56843802D586}*/
				};

				//1.4.5 upgrade code before change {45CA6C9F-57D6-4684-828D-56843802D586}

				funcs.UninstallIfPreviouslyInstalled(prodcutGuis);
			}
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


        private string[][] getAssignmentFromExcel(string fullFileName)
        {

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
	        MyBook.Close();

            ///https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k(Microsoft.Office.Interop.Excel._Worksheet.Cells);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true


            return lines.ToArray();
        }

        private string[][] getAssignment(string fullFileName)
        {
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

            // ReadAssignmentFile the file and display it line by line.
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

	    private void moveAssignments(List<string> verkHopaNumbers)
	    {
			int ret = pathToWhat(tbFrom.Text);

			if (ret == 1) //directory
				moveAssignments(verkHopaNumbers.ToArray(), tbFrom.Text, tbTo.Text);
			else if (ret == 4)
				unZipAssignments(verkHopaNumbers.ToArray(), tbFrom.Text, tbTo.Text);
			else
				MessageBox.Show("Invalid value in the From textbox", "Error", MessageBoxButtons.OK);

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
	        moveAssignments(verkHoparID);


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
				WriteLine("Extracting done!");
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
	        selectSpecificSolutionsToolStripMenuItem.Enabled = btnStart.Enabled;

			ShowSplitupWarning();

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
	        string str = Properties.Settings.Default.versionDescription;

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

        private void ReadAssignmentFile()
        {

            EnableAllControls(this, false);
            tbResult.Clear();
            WriteLine("Reading group file...");

            int ftype = pathToWhat(tbFile.Text);



            if (ftype == 3) { 
               arrSkil = getAssignment(tbFile.Text);
			}
			else if (ftype == 5)
              arrSkil =  getAssignmentFromExcel(tbFile.Text);

			arrayHasBeenSplitup = false;

			if (arrSkil == null)
            {
                WriteLine("Error opening assignment file");
	            
                return;
            }

			WriteLine("Lines read : " + arrSkil.Length);
			//extract unique


			string[] hopar = getUnique(arrSkil, 3);
            if (hopar == null)
            {
                WriteLine("Error : Invalid Csv file");
                return;
            }

			WriteLine("Number of groups : " + hopar.Length);

			comboHopar.Items.Clear();
            foreach (var VARIABLE in hopar)
            {
                comboHopar.Items.Add(VARIABLE);
            }
            if (comboHopar.Items.Count > 0)
                comboHopar.SelectedIndex = 0;
            SetButtonStatus();
           
            WriteLine("Done reading group file!");

			PrintNoReturns(arrSkil);
            EnableAllControls(this, true);
            SetButtonStatus();
        }

	    private void PrintNoReturns(string[][] arr)
	    {
			Dictionary<string, HopurStats> hopar = new Dictionary<string, HopurStats>();
		    bool firstLine = true;
			WriteLine("\n - Assignment submission stats - ");//ignoring the header
			WriteLine("Data lines: " + (arr.Length - 1));//ignoring the header
			foreach (var item in arr)
		    {
			    if (!firstLine) //ignore the header
				{ 
					string hopNafn = item[3];

					if (!hopar.ContainsKey(hopNafn))
					{
						hopar.Add(item[3], new HopurStats());

					}

					if (string.IsNullOrEmpty(item[2]))
					{
						hopar[hopNafn].NotSubmitted++;
					}
					else
					{
						hopar[hopNafn].Submitted++;
					}
				}
				firstLine = false;
			}

		    HopurStats subTotal = new HopurStats();
		    foreach (var item in hopar)
		    {
				Write(item.Key+ " :\t");   
				Write("Submitts : "+item.Value.Submitted);
				Write("\tNo submitts : " + item.Value.NotSubmitted);
				WriteLine("\tTotal lines : " + (item.Value.Submitted + item.Value.NotSubmitted));
				subTotal.NotSubmitted += item.Value.NotSubmitted;
				subTotal.Submitted += item.Value.Submitted;				
			}
			WriteLine("\t- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
			Write(" Total " + " :\t");
			Write("Submitts : " + subTotal.Submitted);
			Write("\tNo submitts : " + subTotal.NotSubmitted);
			WriteLine("\tTotal lines : " + (subTotal.Submitted + subTotal.NotSubmitted));

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
            catch (FileNotFoundException)
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
                ReadAssignmentFile();
                
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
            tbResult.Clear();
            foreach (string fileName in fileEntries)
            {
                n = fileName.LastIndexOf('\\') + 1;
                string name = fileName.Substring(n, fileName.Length - n);
				string gradedZipfile = tbTo.Text + "\\" + name + "_grades.zip";

				//delete old grade file if it exists
				if (File.Exists(gradedZipfile)) File.Decrypt(gradedZipfile);
				if (int.TryParse(name, out n) == true) //check if it's a number
                { 
                    WriteLine(fileName);
                    zipGrades(name, tbTo.Text, tbTo.Text);
					WriteLine("Created the file : \"" + gradedZipfile + "\"");
				}
                else
                {
                    WriteLine("Ignoring " + name);
                }

	            if (File.Exists(gradedZipfile))
	            {
					DialogResult dialogResult;
						dialogResult = MessageBox.Show("A zip file with all grades has been created.\n\nDo you want to open the folder it is located in?", "Grades file created", MessageBoxButtons.YesNo);
						if (dialogResult == DialogResult.Yes)
							Process.Start(tbTo.Text);
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
                        
                        foreach (var file in returnFiles)
                        {
                            //adda file í archive
                            n = file.LastIndexOf('\\') + 1;
                            string fileName = file.Substring(n, file.Length - n);
                            string achivePath = assignment + '/' + dirName + '/' + fileName;
                            archive.CreateEntryFromFile(file, achivePath);
                            WriteLine(file + " ");
                        }
                       
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

	    private void ShowSplitupWarning()
	    {
		    int tbResultHeight = 173;
		    bool bShow = arrayHasBeenSplitup && btnStart.Enabled;

			devideHandinsOntoGroupsToolStripMenuItem.Enabled = !bShow;
		    if (bShow)
			    tbResultHeight = 124;

		    tbResult.Height = tbResultHeight;
	    }
		private void devideHandinsOntoGroupsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tbResult.Clear();
			WriteLine("Divide the handings onto groups!");
			var ass = new MySchoolAssignment(arrSkil);
			var splitArr = ass.SplitAssignments(tbResult);
			arrSkil = splitArr;
			arrayHasBeenSplitup = true;
			ShowSplitupWarning();
			
		}

		private void reloadFileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
		{
			statusBar1.Text = "Reload the selected file";
		}

		private void reloadFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tmrKeyPressFileKey.Enabled = true;
		}

		private void checkForUpdateToolStripMenuItem_MouseEnter(object sender, EventArgs e)
		{
			statusBar1.Text = "Check if there is a new version of GroupMove online";
		}
		private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{	
			string oldVersion = Properties.Settings.Default.version;
			GWeb web = new GWeb();
			string destPath = Path.GetTempPath();
			string onLineFolder = "http://www.guttih.com/groupmove";
			string fileNameDownloaded = destPath +  Properties.Settings.Default.downloadConfigFileName;
			string url = onLineFolder + "/download.config";
			if (!web.DownloadFile(url, fileNameDownloaded))
			{
				MessageBox.Show("Unable to get information from the server " +
				                "whether a newer version of this application exits.\n\nSearch path:\"" +url+"\".", "Unable connect to server", MessageBoxButtons.OK);
				return;
			}
			
			ReadConfigFile versionFile = new ReadConfigFile(fileNameDownloaded);
			if (versionFile.Load() && versionFile.ValuesDictionary.ContainsKey("version"))
			{
				
				string newVersion = versionFile.ValuesDictionary["version"];

				string versionDescription = "";
				if (versionFile.ValuesDictionary.ContainsKey("versionDescription"))
					versionDescription = versionFile.ValuesDictionary["versionDescription"];

				if (String.Compare(newVersion, oldVersion) > 0)
				{   //version from the version file is bigger so let's update
					DialogResult dialogResult;
					dialogResult =
							MessageBox.Show(
								"A newer version of this application exits on the server.\n\n" +
								"Description:\n\"" +
								versionDescription +
								"\"\n\nDo you want to download and run a new version of this application?",
								"A new version (" + newVersion + ")", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes) { 
						url = onLineFolder + "/" + newVersion.Replace('.', '_') + "/Setup.msi";
						//todo: what if setupfile is not "msi"? what if "exe"
						string setupFileName = destPath + Properties.Settings.Default.downloadSetupFileName;
						if (web.DownloadFile(url, setupFileName))
						{ 
							Uninstall(null);
							try
							{
								Process.Start(setupFileName);
								System.Threading.Thread.Sleep(5000);
								Application.Exit();

							}
							catch (Exception)
							{
								//eat this
							}
						}
						else
						{
							MessageBox.Show("Unable to download the setup for the new version.\n\nTried to download from:\n\"" + url + "\".", "Unable download Setup", MessageBoxButtons.OK);
						}
					}
				}
				else
				{
					DateTime localDate = DateTime.Now;
					WriteLine(localDate.ToString(new CultureInfo("en-GB")) + ": This version of the application is up to date.");
					
				}
			}
		}

		private void comboHopar_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void selectSpecificSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormSelectGroups form = new FormSelectGroups(arrSkil);
			DialogResult result = form.ShowDialog();
			
			if (result == DialogResult.OK)
			{
				var verkHoparID = form.Selected;
				verkHoparID.Sort();
				moveAssignments(verkHoparID);
				WriteLine("Assignments to extract:");
				foreach (var item in verkHoparID)
				{
					WriteLine(item);
				}
				moveAssignments(verkHoparID);

			}

		}

		private void comboHopar_SelectedIndexChanged_1(object sender, EventArgs e)
		{

		}

		private void changeCommentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormComments form = new FormComments(tbTo.Text.ToString());
			DialogResult result = form.ShowDialog();
			string str = "not ok";

			if (result == DialogResult.OK)
			{
				str = "all is ok";
			}
			str = str + ".";
		}

		private void changeGradesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormGrades form = new FormGrades(tbTo.Text.ToString());
			DialogResult result = form.ShowDialog();
			string str = "not ok";

			if (result == DialogResult.OK)
			{
				str = "all is ok";
			}
			str = str + ".";

		}
	}

	}
