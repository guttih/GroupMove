namespace GroupMove
{
	partial class FormSelectGroups
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbNotSelected = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.lbSelected = new System.Windows.Forms.ListBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblNotSelectedCount = new System.Windows.Forms.Label();
			this.lblSelectedCount = new System.Windows.Forms.Label();
			this.btnAddAll = new System.Windows.Forms.Button();
			this.btnRemoveAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbNotSelected
			// 
			this.lbNotSelected.AllowDrop = true;
			this.lbNotSelected.FormattingEnabled = true;
			this.lbNotSelected.ItemHeight = 20;
			this.lbNotSelected.Location = new System.Drawing.Point(34, 98);
			this.lbNotSelected.Name = "lbNotSelected";
			this.lbNotSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbNotSelected.Size = new System.Drawing.Size(159, 344);
			this.lbNotSelected.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Not selected";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(321, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Selected";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(497, 46);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "Select Student solutions you want and press the \">\" and \">>\" buttons to add them " +
    "to the selected box.";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(75, 504);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(76, 34);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(264, 223);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(40, 40);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = ">";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(218, 223);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(40, 40);
			this.btnRemove.TabIndex = 7;
			this.btnRemove.Text = "<";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// lbSelected
			// 
			this.lbSelected.FormattingEnabled = true;
			this.lbSelected.ItemHeight = 20;
			this.lbSelected.Location = new System.Drawing.Point(325, 98);
			this.lbSelected.Name = "lbSelected";
			this.lbSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbSelected.Size = new System.Drawing.Size(159, 344);
			this.lbSelected.TabIndex = 1;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(366, 504);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(76, 34);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "&Start";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// lblNotSelectedCount
			// 
			this.lblNotSelectedCount.Location = new System.Drawing.Point(34, 445);
			this.lblNotSelectedCount.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.lblNotSelectedCount.Name = "lblNotSelectedCount";
			this.lblNotSelectedCount.Size = new System.Drawing.Size(159, 23);
			this.lblNotSelectedCount.TabIndex = 8;
			this.lblNotSelectedCount.Text = "label......................";
			this.lblNotSelectedCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblSelectedCount
			// 
			this.lblSelectedCount.Location = new System.Drawing.Point(321, 445);
			this.lblSelectedCount.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.lblSelectedCount.Name = "lblSelectedCount";
			this.lblSelectedCount.Size = new System.Drawing.Size(163, 23);
			this.lblSelectedCount.TabIndex = 8;
			this.lblSelectedCount.Text = "label......................";
			this.lblSelectedCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnAddAll
			// 
			this.btnAddAll.Location = new System.Drawing.Point(264, 277);
			this.btnAddAll.Name = "btnAddAll";
			this.btnAddAll.Size = new System.Drawing.Size(40, 40);
			this.btnAddAll.TabIndex = 7;
			this.btnAddAll.Text = ">>";
			this.btnAddAll.UseVisualStyleBackColor = true;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Location = new System.Drawing.Point(218, 277);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(40, 40);
			this.btnRemoveAll.TabIndex = 7;
			this.btnRemoveAll.Text = "<<";
			this.btnRemoveAll.UseVisualStyleBackColor = true;
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// FormSelectGroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(521, 576);
			this.ControlBox = false;
			this.Controls.Add(this.lblSelectedCount);
			this.Controls.Add(this.lblNotSelectedCount);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnAddAll);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbSelected);
			this.Controls.Add(this.lbNotSelected);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSelectGroups";
			this.ShowIcon = false;
			this.Text = "Select specific solutions";
			this.Load += new System.EventHandler(this.FormSelectGroups_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbNotSelected;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.ListBox lbSelected;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblNotSelectedCount;
		private System.Windows.Forms.Label lblSelectedCount;
		private System.Windows.Forms.Button btnAddAll;
		private System.Windows.Forms.Button btnRemoveAll;
	}
}