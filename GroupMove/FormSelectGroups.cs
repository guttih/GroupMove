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
		private List<String> _notSelected;
		private List<String> _selected;
		private ToolTip toolTips;

		public List<String> Selected => GetSelected();


		public FormSelectGroups(string[][] arrSkil)
		{
			_arrSkil = arrSkil;
			_notSelected = new List<string>();
			_selected = new List<string>();
			InitializeComponent();
		}

		private List<String> GetSelected()
		{
			return _selected;
		}

		private void UpdateView()
		{
			
			lblNotSelectedCount.Text = "" + _notSelected.Count();
			lblSelectedCount.Text = "" + _selected.Count();
		}

		private void CreateContextMenu(ListBox listBox)
		{
			ContextMenu contextMenu1;
			contextMenu1 = new ContextMenu();
			MenuItem menuItem1;
			menuItem1 = new MenuItem();
			MenuItem menuItem2;
			menuItem2 = new MenuItem();
			MenuItem menuItem3;
			menuItem3 = new MenuItem();

			contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1, menuItem2 });
			menuItem1.Index = 0;
			menuItem1.Text = "Copy selected items to clipboard";
			menuItem1.Click += new EventHandler(menuItemSelected_Click);
			menuItem2.Index = 1;
			menuItem2.Text = "Copy all items to clipboard";
			menuItem2.Click += new EventHandler(menuItemAll_Click);
			

			listBox.ContextMenu = contextMenu1;
		}

		ListBox ExtractControl(object sender)
		{
			MenuItem menuItem = sender as MenuItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenu that contains this MenuItem
				ContextMenu menu = menuItem.GetContextMenu();
				if (menu != null)
				{
					Control sourceControl = menu.SourceControl;
					if (sourceControl != null)
					{
						if (sourceControl.Name == "lbNotSelected")
						{
							return (ListBox) (Control) sourceControl;
						}
						if (sourceControl.Name == "lbSelected")
						{
							return (ListBox)(Control)sourceControl;
						}
					}
				}

				// Get the control that is displaying this context menu
				
			}
			return null;
		}

		void copyItemsToClipboard(ListBox lbFrom, Boolean copyOnlySelectedItems)
		{
			if (lbFrom == null)
				return;
			string str = "";
			List<String> list;
			if (lbFrom.Items.Count < 1)
				return;
			if (copyOnlySelectedItems)
			{
				if (lbFrom.SelectedIndex == -1)
					return; //nothing selected
				list = lbFrom.SelectedItems.Cast<String>().ToList();
			}
			else {
					list = lbFrom.Items.Cast<string>().ToList();
			}

			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (i == 0)
					str = list[i];
				else
					str += ";" + list[i];
			}
			Clipboard.SetText(str);
		}

		void menuItemSelected_Click(object sender, EventArgs e)
		{
			copyItemsToClipboard(ExtractControl(sender), true);
		}
		void menuItemAll_Click(object sender, EventArgs e)
		{
			copyItemsToClipboard(ExtractControl(sender), false);
		}

		private void InitTooltips()
		{
			toolTips = new ToolTip();

			// Set up the delays for the ToolTip.
			toolTips.AutoPopDelay = 5000;
			toolTips.InitialDelay = 1000;
			toolTips.ReshowDelay = 500;
			// Force the ToolTip text to be displayed whether or not the form is active.
			toolTips.ShowAlways = true;

			// Set up the ToolTip text for the Button and Checkbox.

			toolTips.SetToolTip(this.btnRemove, "Move selected items from the \"selected\" box to the \"not selected\" box.");
			toolTips.SetToolTip(this.btnAdd,    "Move selected items from the \"not selected\" box to the \"selected\" box.");
			toolTips.SetToolTip(this.btnAddAll, "Move all items from the \"selected\" box to the \"not selected\" box.");
			toolTips.SetToolTip(this.btnRemoveAll, "Move all items from the \"not selected\" box to the \"selected\" box.");
			toolTips.SetToolTip(this.btnOk, "Start moving assignments.");
			toolTips.SetToolTip(this.btnCancel, "Cancel and close this dialog.");
		}
		private void FormSelectGroups_Load(object sender, EventArgs e)
		{
			InitTooltips();
			CreateContextMenu(lbNotSelected);
			CreateContextMenu(lbSelected);
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
			UpdateView();
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
			UpdateView();
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

		private void btnAddAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lbNotSelected.Items.Count; i++)
			{
				lbNotSelected.SetSelected(i, true);
			}
			moveItems(lbNotSelected, lbSelected);

		}

		private void btnRemoveAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lbSelected.Items.Count; i++)
			{
				lbSelected.SetSelected(i, true);
			}
			moveItems(lbSelected, lbNotSelected);
		}
	}
}
