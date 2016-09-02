using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupMove
{
	public partial class FormSelectGroups : Form
	{
		private readonly string[][] _arrSkil;
		List<String> _notSelected;
		List<String> _selected;
		/// <summary>
		/// returns an array of strings with the selected solutions
		/// </summary>
		public string [] Selected => getSelected();

		public FormSelectGroups(string[][] arrSkil)
		{
			_arrSkil = arrSkil;
			_notSelected = new List<string>();
			_selected = new List<string>();
			InitializeComponent();
		}

		string[] getSelected()
		{
			return _selected.ToArray();
		}
		private void FormSelectGroups_Load(object sender, EventArgs e)
		{
			string str;
			for (int i = 1; i < _arrSkil.Length; i++)
			{
				str = _arrSkil[i][2];
				if (str.Length > 0)
					_notSelected.Add(str);
			}
			_notSelected.Sort();
			lbNotSelected.DataSource = _notSelected;
			lbSelected.DataSource = _selected;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		
		private void moveItems(ListBox lbFrom, ListBox lbTo)
		{
			List<String> listFrom;
			List<String> listTo;
			if (lbFrom == lbNotSelected)
			{
				listFrom = _notSelected;
				listTo = _selected;
			}
			else
			{
				listFrom = _selected;
				listTo = _notSelected;
			}
			var selectedItems = lbFrom.SelectedItems;
			if (lbFrom.SelectedIndex != -1)
			{
				string str;
				int count = selectedItems.Count;
				for (int i = count - 1; i > -1; i--)
				{
					str = selectedItems[i].ToString();
					listTo.Add(str);
					listFrom.Remove(str);
				}
			}
			listFrom.Sort();
			listTo.Sort();
			lbFrom.DataSource = null;
			lbTo.DataSource = null;
			lbFrom.DataSource = listFrom;
			lbTo.DataSource = listTo;

		}

	private void btnAdd_Click(object sender, EventArgs e)
		{
			moveItems(lbNotSelected, lbSelected); 
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			moveItems(lbSelected, lbNotSelected);

		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			
		}
	}
}
