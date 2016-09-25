namespace GroupMove
{
	partial class FormComments
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComments));
			this.comboDirs = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbText = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboResult = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCount = new System.Windows.Forms.Label();
			this.comboAncor = new System.Windows.Forms.ComboBox();
			this.comboOffset = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnRefresh = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboDirs
			// 
			this.comboDirs.BackColor = System.Drawing.SystemColors.Window;
			this.comboDirs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDirs.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboDirs.FormattingEnabled = true;
			this.comboDirs.Location = new System.Drawing.Point(52, 33);
			this.comboDirs.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboDirs.Name = "comboDirs";
			this.comboDirs.Size = new System.Drawing.Size(128, 28);
			this.comboDirs.TabIndex = 13;
			this.comboDirs.SelectedIndexChanged += new System.EventHandler(this.comboDirs_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 20);
			this.label1.TabIndex = 14;
			this.label1.Text = "Assignment:";
			// 
			// tbText
			// 
			this.tbText.AcceptsTab = true;
			this.tbText.BackColor = System.Drawing.SystemColors.Window;
			this.tbText.Font = new System.Drawing.Font("Matura MT Script Capitals", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbText.Location = new System.Drawing.Point(52, 91);
			this.tbText.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tbText.Multiline = true;
			this.tbText.Name = "tbText";
			this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbText.Size = new System.Drawing.Size(734, 318);
			this.tbText.TabIndex = 16;
			this.tbText.TabStop = false;
			this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(710, 437);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(76, 34);
			this.btnOk.TabIndex = 18;
			this.btnOk.Text = "&Run";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(56, 437);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(76, 34);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "&Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbSearch
			// 
			this.tbSearch.Location = new System.Drawing.Point(206, 35);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(265, 26);
			this.tbSearch.TabIndex = 19;
			this.tbSearch.Text = "-*-einkunn.txt";
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(202, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 20);
			this.label2.TabIndex = 20;
			this.label2.Text = "File search criteria:";
			// 
			// comboResult
			// 
			this.comboResult.BackColor = System.Drawing.SystemColors.Window;
			this.comboResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboResult.FormattingEnabled = true;
			this.comboResult.Location = new System.Drawing.Point(521, 33);
			this.comboResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboResult.Name = "comboResult";
			this.comboResult.Size = new System.Drawing.Size(265, 28);
			this.comboResult.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(517, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 20);
			this.label3.TabIndex = 20;
			this.label3.Text = "Search result:";
			// 
			// lblCount
			// 
			this.lblCount.Location = new System.Drawing.Point(570, 66);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(216, 20);
			this.lblCount.TabIndex = 21;
			this.lblCount.Text = "lblCount";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboAncor
			// 
			this.comboAncor.BackColor = System.Drawing.SystemColors.Window;
			this.comboAncor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboAncor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboAncor.FormattingEnabled = true;
			this.comboAncor.Items.AddRange(new object[] {
            "Top",
            "Bottom"});
			this.comboAncor.Location = new System.Drawing.Point(419, 437);
			this.comboAncor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboAncor.Name = "comboAncor";
			this.comboAncor.Size = new System.Drawing.Size(117, 28);
			this.comboAncor.TabIndex = 22;
			// 
			// comboOffset
			// 
			this.comboOffset.BackColor = System.Drawing.SystemColors.Window;
			this.comboOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboOffset.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboOffset.FormattingEnabled = true;
			this.comboOffset.Location = new System.Drawing.Point(573, 439);
			this.comboOffset.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboOffset.MaxDropDownItems = 10;
			this.comboOffset.Name = "comboOffset";
			this.comboOffset.Size = new System.Drawing.Size(97, 28);
			this.comboOffset.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(415, 414);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 20);
			this.label4.TabIndex = 24;
			this.label4.Text = "Append from:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(578, 414);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 20);
			this.label5.TabIndex = 25;
			this.label5.Text = "Lines from";
			// 
			// timer1
			// 
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.Location = new System.Drawing.Point(478, 33);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(37, 35);
			this.btnRefresh.TabIndex = 26;
			this.btnRefresh.Text = " ";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormComments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(837, 539);
			this.ControlBox = false;
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboOffset);
			this.Controls.Add(this.comboAncor);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboResult);
			this.Controls.Add(this.comboDirs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormComments";
			this.ShowIcon = false;
			this.Text = "Add comments";
			this.Load += new System.EventHandler(this.FormComments_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboDirs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbText;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboResult;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.ComboBox comboAncor;
		private System.Windows.Forms.ComboBox comboOffset;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnRefresh;
	}
}