namespace GroupMove
{
	partial class FormGrades
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
			this.comboDirs = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboResult = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCount = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbFrom = new System.Windows.Forms.TextBox();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbNew = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// comboDirs
			// 
			this.comboDirs.BackColor = System.Drawing.SystemColors.Window;
			this.comboDirs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDirs.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboDirs.FormattingEnabled = true;
			this.comboDirs.Location = new System.Drawing.Point(52, 34);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(210, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 20);
			this.label2.TabIndex = 20;
			this.label2.Text = "From:";
			// 
			// comboResult
			// 
			this.comboResult.BackColor = System.Drawing.SystemColors.Window;
			this.comboResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboResult.FormattingEnabled = true;
			this.comboResult.Location = new System.Drawing.Point(421, 33);
			this.comboResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboResult.Name = "comboResult";
			this.comboResult.Size = new System.Drawing.Size(281, 28);
			this.comboResult.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(417, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 20);
			this.label3.TabIndex = 20;
			this.label3.Text = "Search result:";
			// 
			// lblCount
			// 
			this.lblCount.Location = new System.Drawing.Point(486, 66);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(216, 20);
			this.lblCount.TabIndex = 21;
			this.lblCount.Text = "lblCount";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// timer1
			// 
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(706, 213);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(76, 34);
			this.btnOk.TabIndex = 23;
			this.btnOk.Text = "&Run";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(52, 213);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(76, 34);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "&Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbFrom
			// 
			this.tbFrom.Location = new System.Drawing.Point(214, 32);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new System.Drawing.Size(62, 26);
			this.tbFrom.TabIndex = 24;
			this.tbFrom.Text = "1";
			this.tbFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbFrom.TextChanged += new System.EventHandler(this.tbFrom_TextChanged);
			// 
			// tbTo
			// 
			this.tbTo.Location = new System.Drawing.Point(319, 32);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(62, 26);
			this.tbTo.TabIndex = 26;
			this.tbTo.Text = "1";
			this.tbTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTo.TextChanged += new System.EventHandler(this.tbTo_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(315, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 20);
			this.label4.TabIndex = 25;
			this.label4.Text = "To:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(48, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(256, 20);
			this.label5.TabIndex = 27;
			this.label5.Text = "Change affected files to this grade:";
			// 
			// tbNew
			// 
			this.tbNew.Location = new System.Drawing.Point(43, 136);
			this.tbNew.Name = "tbNew";
			this.tbNew.Size = new System.Drawing.Size(62, 26);
			this.tbNew.TabIndex = 26;
			this.tbNew.Text = "1";
			this.tbNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbNew.TextChanged += new System.EventHandler(this.tbNew_TextChanged);
			// 
			// FormGrades
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(837, 372);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbNew);
			this.Controls.Add(this.tbTo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbFrom);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboResult);
			this.Controls.Add(this.comboDirs);
			this.Name = "FormGrades";
			this.Text = "Change grades";
			this.Load += new System.EventHandler(this.FormComments_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboDirs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboResult;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbFrom;
		private System.Windows.Forms.TextBox tbTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbNew;
	}
}