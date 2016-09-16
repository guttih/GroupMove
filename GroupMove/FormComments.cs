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

namespace GroupMove
{
	public partial class FormComments : Form
	{
		
		private readonly string _rootFolder;
		private FileCollect _files;
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
			
		}

		private void runQuery(ComboBox combo)
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
			runQuery(combo);

		}

		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				runQuery(comboDirs);
			}
		}

		private Boolean appendToFile(string fullFileName, string stringToAppend)
		{
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");
			Encoding utf8 = Encoding.UTF8;
			byte[] utfBytes = utf8.GetBytes(stringToAppend);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
			string msg = iso.GetString(isoBytes);

			if (!File.Exists(fullFileName))
			{
				return false;
			}

			File.AppendAllText(fullFileName, msg, iso);

			return true;
		}
		private void btnOk_Click(object sender, EventArgs e)
		{
			string textToAppend = tbText.Text;
			string [] files = _files.GetFullFileNames();
			if (files != null)
			{
				foreach (string file in files)
				{
					appendToFile(file, textToAppend);
				}
			}

		}
	}
}
