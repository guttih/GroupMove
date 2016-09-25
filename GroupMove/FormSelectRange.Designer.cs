namespace GroupMove
{
	partial class FormSelectRange
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
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbFrom = new System.Windows.Forms.TextBox();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboResult = new System.Windows.Forms.ComboBox();
			this.lblCount = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 20);
			this.label2.TabIndex = 20;
			this.label2.Text = "From:";
			// 
			// timer1
			// 
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(64, 235);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(76, 34);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tbFrom
			// 
			this.tbFrom.Location = new System.Drawing.Point(31, 62);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new System.Drawing.Size(107, 26);
			this.tbFrom.TabIndex = 24;
			this.tbFrom.Text = "1";
			this.tbFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbFrom.TextChanged += new System.EventHandler(this.tbFrom_TextChanged);
			// 
			// tbTo
			// 
			this.tbTo.Location = new System.Drawing.Point(179, 62);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(107, 26);
			this.tbTo.TabIndex = 26;
			this.tbTo.Text = "1";
			this.tbTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTo.TextChanged += new System.EventHandler(this.tbTo_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(175, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 20);
			this.label4.TabIndex = 25;
			this.label4.Text = "To:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbTo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbFrom);
			this.groupBox1.Location = new System.Drawing.Point(33, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(325, 112);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search boundaries";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboResult);
			this.groupBox2.Controls.Add(this.lblCount);
			this.groupBox2.Location = new System.Drawing.Point(33, 130);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(325, 87);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Selected";
			// 
			// comboResult
			// 
			this.comboResult.BackColor = System.Drawing.SystemColors.Window;
			this.comboResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboResult.FormattingEnabled = true;
			this.comboResult.Location = new System.Drawing.Point(31, 35);
			this.comboResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboResult.Name = "comboResult";
			this.comboResult.Size = new System.Drawing.Size(107, 28);
			this.comboResult.TabIndex = 13;
			// 
			// lblCount
			// 
			this.lblCount.Location = new System.Drawing.Point(175, 38);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(109, 25);
			this.lblCount.TabIndex = 21;
			this.lblCount.Text = "lblCount";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(232, 235);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(85, 34);
			this.btnOk.TabIndex = 23;
			this.btnOk.Text = "&Select";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// FormSelectRange
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 322);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSelectRange";
			this.ShowIcon = false;
			this.Text = "Select range";
			this.Load += new System.EventHandler(this.FormComments_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbFrom;
		private System.Windows.Forms.TextBox tbTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboResult;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Button btnOk;
	}
}