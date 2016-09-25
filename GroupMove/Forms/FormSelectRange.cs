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
using static System.String;

namespace GroupMove
{
	public partial class FormSelectRange : Form
	{

		private readonly List<String> _list;
		private FileCollect _files;
		private ToolTip _toolTips;
		public FormSelectRange(string [] listToSelectFrom, string fromText, string toText)
		{
			InitializeComponent();

			tbFrom.Text = fromText;
			tbTo.Text = toText;
			_list = new List<string>(listToSelectFrom);
			

		}

		public string [] GetSelected()
		{
			return comboResult.Items.Cast<string>().ToArray();
		}

		private void FormComments_Load(object sender, EventArgs e)
		{
			
			InitTooltips();
			timer1.Enabled = true;

		}

		private void InitTooltips()
		{
			_toolTips = new ToolTip
			{
				AutoPopDelay = 5000,
				InitialDelay = 1000,
				ReshowDelay = 500,
				ShowAlways = true
			};

			// Set up the delays for the ToolTip.
			// Force the ToolTip text to be displayed whether or not the form is active.

			// Set up the ToolTip text for the Button and Checkbox.

		_toolTips.SetToolTip(this. btnOk       ,"Return current selection.");
		_toolTips.SetToolTip(this. btnCancel   ,"Cancel and close this form.");
		_toolTips.SetToolTip(this.tbFrom       ,"From what.");
		_toolTips.SetToolTip(this.tbTo         , "To what.");
		_toolTips.SetToolTip(this. comboResult ,"Current selection.");
	}

		private void RunQuery()
		{
			comboResult.Items.Clear();
			string from = tbFrom.Text;
			string to = tbTo.Text;
			if (from.Length == to.Length)
			{
				foreach (string item in _list)
				{
					int i = item.CompareTo(from);
					if (from.Length == item.Length && i >= 0)
					{
						i = item.CompareTo(to);
						if (i <= 0)
						{
							comboResult.Items.Add(item);
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


		private void btnOk_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("pressed", "btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			timer1.Enabled = false;
			RunQuery();
			SetButtonState();
		}

		private void SetButtonState()
		{

			Boolean bEnable = comboResult.Items.Count > 0;

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
	}
}
