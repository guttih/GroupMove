using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroupMove.Entity;

namespace GroupMove
{
	public partial class FormComments : Form
	{
		
		private readonly string _rootFolder;
		private FileCollect _files;
		private ToolTip _toolTips;
		public FormComments(string toFolder)
		{
			_rootFolder = toFolder;
			InitializeComponent();

		}

		private void FormChangeCommentsm2_Load(object sender, EventArgs e)
		{
			
		}

		private void FormComments_Load(object sender, EventArgs e)
		{
			string[] items = System.IO.Directory.GetDirectories(_rootFolder);
			foreach (string dir in items)
			{
				string str = Path.GetFileName(dir);
				if (str != null)
					comboDirs.Items.Add(str);
			}

			if (comboDirs.Items.Count > 0)
			{
				comboDirs.SelectedIndex = 0;
			}
			
			tbText.Font = new Font(FontFamily.GenericMonospace, tbText.Font.Size);
			comboOffset.IntegralHeight = false;
			for (int i = 0; i < 31; i++)
			{
				comboOffset.Items.Add(i.ToString());
			}

			comboOffset.SelectedIndex = 0;
			comboOffset.MaxDropDownItems = 9;
			comboAncor.SelectedIndex = 1;

			InitTooltips();
			timer1.Enabled = true;

		}

		private void InitTooltips()
		{
			_toolTips = new ToolTip();

			// Set up the delays for the ToolTip.
			_toolTips.AutoPopDelay = 5000;
			_toolTips.InitialDelay = 1000;
			_toolTips.ReshowDelay = 500;
			// Force the ToolTip text to be displayed whether or not the form is active.
			_toolTips.ShowAlways = true;

			// Set up the ToolTip text for the Button and Checkbox.

		_toolTips.SetToolTip(this. comboDirs   ,"Select assignment");
		_toolTips.SetToolTip(this. tbText      ,"Type the text you want to add to files.");
		_toolTips.SetToolTip(this. btnOk       ,"Add text to all files in the query result.");
		_toolTips.SetToolTip(this. btnCancel   ,"Close this form.");
		_toolTips.SetToolTip(this. tbSearch    ,"File search criteria (press enter to run the query).");
		_toolTips.SetToolTip(this. comboResult ,"Files which will be modifed when you press run.");
		_toolTips.SetToolTip(this. comboAncor  ,"Add the text to the comment area at the top or the bottom.");
		_toolTips.SetToolTip(this.comboOffset  , "Number of lines from top or button which the text will be inserted.");
		_toolTips.SetToolTip(this.btnRefresh, "Start the search and populate the \"Search result\".");
		_toolTips.SetToolTip(this.lblCount, "The number of files(assignments) in the Search result.");
		}

		private void RunQuery(ComboBox combo)
		{
			
			string searchString = tbSearch.Text;
			lblCount.Text = "0";
			comboResult.Items.Clear();
			int i = combo.SelectedIndex;
			if (i > -1)
			{
				string str = combo.Items[i].ToString();
				_files = new FileCollect(_rootFolder + "\\" + str, searchString);
				var names = _files.GetFileNames();
				if (names != null )
				{
					foreach (string name in names)
					{
						comboResult.Items.Add(name);
					}

					comboResult.SelectedIndex = 0;
					lblCount.Text = comboResult.Items.Count.ToString();
				}
			}
		}

		private void comboDirs_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = (ComboBox)sender;
			RunQuery(combo);
		}

		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				RunQuery(comboDirs);
			}
		}

		private string UTF8_to_ISO_8859_1(string strIso88591)
		{
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");
			Encoding utf8 = Encoding.UTF8;
			byte[] utfBytes = utf8.GetBytes(strIso88591);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
			return iso.GetString(isoBytes);
		}

		private Boolean AppendToIsoFile(string fullFileName, string stringToAppend)
		{
			
			string strAppendIso = UTF8_to_ISO_8859_1(stringToAppend);

			if (stringToAppend.Length < 1 || !File.Exists(fullFileName))
			{
				return false;
			}

			File.AppendAllText(fullFileName, strAppendIso, Encoding.GetEncoding("ISO-8859-1"));

			return true;
		}

		/// <summary>
		/// Searches a comment file and find where a comment starts and where it ends
		/// The function will give the zero-index of the the line where a comment starts
		/// and zero-index of the the line where a comment ends.
		/// </summary>
		/// <param name="reader">Must have been opened and ready to read</param>
		/// <returns>CommentFileInfo which contains information about where comments start and ends.</returns>
		public CommentFileInfo GetFileInfo(StreamReader reader )
		{
			CommentFileInfo cfi = new CommentFileInfo();

			string line;
			int counter = 1;

			while ((line = reader.ReadLine()) != null)
			{
				counter++;
				if (line.Equals("----------[Memo]----------"))
				{
					cfi.FirstCommentLineIndex = counter;
				}
			}
			cfi.LastCommentLineIndex = counter;
			return cfi;
		}

		private bool AddToFile(string fullFileName, bool fromBottom, int inOffset, string stringToAdd)
		{
			int insertIndex;
			
			if (inOffset < 0 || stringToAdd.Length < 1)
			{
				return false;
			}
			
			string  strAppendIso = UTF8_to_ISO_8859_1(stringToAdd);

			if (!File.Exists(fullFileName))
			{
				return false;
			}
			StreamReader reader = new StreamReader(
				fullFileName,
				Encoding.GetEncoding("ISO-8859-1"),
				false
			);

			CommentFileInfo cfi = GetFileInfo(reader);
			if (!cfi.IsValid())
			{
				reader.Close();
				MessageBox.Show("Error scanning file!", 
							"Could not find where teacher comments should start.\n"+
							"the file \"" + Path.GetFileName(fullFileName) +
							"\" is probably not a grading file." 
							);
				return false;
			}


			if (fromBottom)
			{	//from the bottom
				insertIndex = cfi.LastCommentLineIndex - inOffset;
				if (insertIndex < cfi.FirstCommentLineIndex)
				{   // we are not allowed to change text above the FirstCommentLineIndex.
					// so we will add the comments at the beginning of the comment section in the file.
					insertIndex = cfi.FirstCommentLineIndex; 
				}
			}
			else
			{	//from the top
				insertIndex = cfi.FirstCommentLineIndex + inOffset;
				if (insertIndex == cfi.LastCommentLineIndex)
				{
					insertIndex++;//to trigger AppendToIsoFile metod
				}
			}

			if (!cfi.HasComments() || insertIndex > cfi.LastCommentLineIndex)
			{
				//  there are no comments in this file so we will or the insertIndex is higer than the number of lines in the file (out of bounds)
				//  We will ignore all indexing and just append comments to the file
				reader.Close();
				return AppendToIsoFile(fullFileName, stringToAdd);
			}


			// Let's add the comment at a specific location
			StreamWriter writer = new StreamWriter(
				fullFileName+".temp",
				false,
				Encoding.GetEncoding("ISO-8859-1")
			);

			string line;
			int counter = 0;
			reader.DiscardBufferedData();
			reader.BaseStream.Seek(0, SeekOrigin.Begin);
			while ((line = reader.ReadLine()) != null)
			{
				counter++;
				
				if (counter == insertIndex)
				{
					writer.Write(strAppendIso);
				}
				writer.Write(line + "\n");


			}

			reader.Close();
			writer.Close();
			File.Delete(fullFileName);
			File.Move(fullFileName + ".temp", fullFileName);

			return true;
		}
		private void btnOk_Click(object sender, EventArgs e)
		{
			string textToAdd = tbText.Text;
			string [] files = _files.GetFullFileNames();
			int indexComboAncor = comboAncor.SelectedIndex;
			int indexComboOffset = comboOffset.SelectedIndex;
			int modifedFiles = 0;
			if (files != null)
			{
				foreach (string file in files)
				{
					if (indexComboAncor == 1 && indexComboOffset == 0 )
					{
						//user selected "bottom" and "0"
						if (AppendToIsoFile(file, textToAdd))
							modifedFiles++;
					}
					else
					{
						//user selected to use a line offset
						if (AddToFile(file, indexComboAncor == 1, indexComboOffset, textToAdd))
							modifedFiles++;
					}
				}
			}
			if (modifedFiles == 0)
				MessageBox.Show("No files were modified!", "No files modified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				var str = "One file was modified.";
				if (modifedFiles > 1)
					str = "There were " + modifedFiles.ToString() + " files modified.";
				MessageBox.Show( str, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
				


		}

		private void tbText_TextChanged(object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			timer1.Enabled = false;
			SetButtonState();
		}

		private void SetButtonState()
		{
			bool bEnable = true;
			if (tbText.Text.Length < 1)
				bEnable = false;
			else if (_files.Count() < 1)
				bEnable = false;
			

			this.btnOk.Enabled = bEnable;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RunQuery(comboDirs);
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			RunQuery(comboDirs);
		}
	}
}
