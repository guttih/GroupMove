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
using System.Globalization;
using System.Runtime.Remoting.Messaging;

namespace GroupMove
{
	public partial class FormGrades : Form
	{
		
		private readonly string _rootFolder;
		private FileCollect _files;
		private ToolTip _toolTips;
		public FormGrades(string toFolder)
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
		_toolTips.SetToolTip(this. btnOk       ,"Change grades on all files in the query result.");
		_toolTips.SetToolTip(this. btnCancel   ,"Close this form.");
		_toolTips.SetToolTip(this.tbFrom, "Search for grades bigger or the same as this grade.");
		_toolTips.SetToolTip(this.tbTo, "Search for grades less or the same as this grade.");
		_toolTips.SetToolTip(this.tbNew, "Grades(Files) found in the query result will be changed to this grade.");
		_toolTips.SetToolTip(this. comboResult ,"Files which will be modifed when you press run.");
	}

		private void RunQuery(ComboBox combo)
		{
			
			double dFrom = TextToDouble(tbFrom.Text);
			double dTo = TextToDouble(tbTo.Text);
			_files = new FileCollect(_rootFolder);
			lblCount.Text = "0";
			comboResult.Items.Clear();
			int i = combo.SelectedIndex;
			if ( (i > -1) && (dFrom > -1) && (dTo > -1))
			{
				string str = combo.Items[i].ToString();
				FileCollect gradesFiles = new FileCollect(_rootFolder + "\\" + str, "*-einkunn.txt");
				
				var names = gradesFiles.GetFullFileNames();
				if (names != null )
				{
					
					foreach (string FullFilename in names)
					{
						string name = Path.GetFileName(FullFilename);

						double grade = TextToDouble(GradeFromFilename(name));
						if (grade >= 0)
						{
							if (grade >= dFrom && grade <= dTo)
							{
								_files.Add(FullFilename);
								comboResult.Items.Add(name);
							}
						}
							
						
					}

					
				}
			}
			if (comboResult.Items.Count > 0)
				comboResult.SelectedIndex = 0;
			lblCount.Text = comboResult.Items.Count.ToString();
		}

		/// <summary>
		/// Converts a string to a positive grade.
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns>
		///		On success the method will return the converted number.  On error the function will return a negative number.</returns>
		private double TextToDouble(string strNumber)
		{
			double d;
			strNumber = strNumber.Replace(",", ".");
			if (strNumber.Length < 1)
				return -1;
			try
			{
				d = Convert.ToDouble(strNumber, CultureInfo.InvariantCulture);
				if (d > 12) return -1;
				//float.Parse("41.00027357629127", CultureInfo.InvariantCulture.NumberFormat);
			}
			catch (FormatException)
			{
				d = -1;
			}

			return d;

		}

		/// <summary>
		/// Extracts a grade from a filename
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns>null if unable to extract the grade.  Otherwhise the grade string is returnd</returns>
		private string GradeFromFilename(string strNumber)
		{   //example name: "-4,3-einkunn.txt"
			
			int iEnd = strNumber.IndexOf("-einkunn.txt");
			if (iEnd < 0) return null;
			int iStart = 0;
			if (strNumber[0] == '-')
				iStart++;
			string strRet = strNumber.Substring(iStart, iEnd - iStart);
			return strRet;

		}

		private void comboDirs_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = (ComboBox)sender;
			RunQuery(combo);
		}
		/*
		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				RunQuery(comboDirs);
			}
		}*/

		private string UTF8_to_ISO_8859_1(string strIso88591)
		{
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");
			Encoding utf8 = Encoding.UTF8;
			byte[] utfBytes = utf8.GetBytes(strIso88591);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
			return iso.GetString(isoBytes);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			
			string [] files = _files.GetFullFileNames();
			int modifedFiles = 0;
			if (TextToDouble(tbNew.Text) < 0)
			{
				MessageBox.Show("New fileame", "The new grade is an invalid grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string newFileName = $"-{tbNew.Text}-einkunn.txt"; //same as = string.Format("-{0}-einkunn.txt", tbNew.Text);



			string path;
			if (files != null)
			{
				foreach (string file in files)
				{
					path = Path.GetDirectoryName(file);
					var oldFileName = Path.GetFileName(file);
					if (!newFileName.Equals(oldFileName))
					{
						modifedFiles++;
						path = path + "\\" + newFileName;
						File.Move(file, path);
					}

				}
			}
			if (modifedFiles == 0)
				MessageBox.Show("No files were modified!", "No files modified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				var str = "Changed grade on one assignment.";
				if (modifedFiles > 1)
					str = "Changed grades on " + modifedFiles.ToString() + " assignments.";
				MessageBox.Show( str, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
				
			RunQuery(comboDirs);

		}

		private void tbText_TextChanged(object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			timer1.Enabled = false;
			RunQuery(comboDirs);
			SetButtonState();
		}

		private void SetButtonState()
		{
			bool bEnable = true;

			if (_files.Count() < 1)
				bEnable = false;
			else if (TextToDouble(tbNew.Text) < 0)
			{
				bEnable = false;
			}

			this.btnOk.Enabled = bEnable;
		}


		private void tbTo_TextChanged(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			timer1.Enabled = true;
		}

		private void tbFrom_TextChanged(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			timer1.Enabled = true;
		}

		private void tbNew_TextChanged(object sender, EventArgs e)
		{
			SetButtonState();
		}
	}
}
