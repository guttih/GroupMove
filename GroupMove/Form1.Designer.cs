namespace GroupMove
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tbFrom = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.btnFrom = new System.Windows.Forms.Button();
			this.btnTo = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.tbFile = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFile = new System.Windows.Forms.Button();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboHopar = new System.Windows.Forms.ComboBox();
			this.tmrKeyPressFileKey = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectSpecificSolutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.makeUploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.devideHandinsOntoGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gradeAndCommentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeGradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbFrom
			// 
			this.tbFrom.AllowDrop = true;
			this.tbFrom.Location = new System.Drawing.Point(46, 134);
			this.tbFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tbFrom.Name = "tbFrom";
			this.tbFrom.Size = new System.Drawing.Size(502, 26);
			this.tbFrom.TabIndex = 2;
			this.tbFrom.TextChanged += new System.EventHandler(this.tbFrom_TextChanged);
			this.tbFrom.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFrom_DragDrop);
			this.tbFrom.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFrom_DragEnter);
			this.tbFrom.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.tbFrom.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 109);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(196, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "From: (a zip file or a folder)";
			this.label1.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.label1.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(225, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "To: (a destination group folder)";
			this.label2.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.label2.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// tbTo
			// 
			this.tbTo.AllowDrop = true;
			this.tbTo.Location = new System.Drawing.Point(46, 202);
			this.tbTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(502, 26);
			this.tbTo.TabIndex = 4;
			this.tbTo.TextChanged += new System.EventHandler(this.tbTo_TextChanged);
			this.tbTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbTo_DragDrop);
			this.tbTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbTo_DragEnter);
			this.tbTo.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.tbTo.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// btnFrom
			// 
			this.btnFrom.Location = new System.Drawing.Point(556, 129);
			this.btnFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnFrom.Name = "btnFrom";
			this.btnFrom.Size = new System.Drawing.Size(84, 38);
			this.btnFrom.TabIndex = 3;
			this.btnFrom.Text = "B&rowse";
			this.btnFrom.UseVisualStyleBackColor = true;
			this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
			this.btnFrom.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.btnFrom.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// btnTo
			// 
			this.btnTo.Location = new System.Drawing.Point(556, 198);
			this.btnTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnTo.Name = "btnTo";
			this.btnTo.Size = new System.Drawing.Size(84, 38);
			this.btnTo.TabIndex = 5;
			this.btnTo.Text = "Br&owse";
			this.btnTo.UseVisualStyleBackColor = true;
			this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
			this.btnTo.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.btnTo.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(538, 546);
			this.btnStart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(102, 38);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "&Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			this.btnStart.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.btnStart.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// tbFile
			// 
			this.tbFile.AllowDrop = true;
			this.tbFile.Location = new System.Drawing.Point(46, 65);
			this.tbFile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tbFile.Name = "tbFile";
			this.tbFile.Size = new System.Drawing.Size(502, 26);
			this.tbFile.TabIndex = 0;
			this.tbFile.TextChanged += new System.EventHandler(this.tbFile_TextChanged);
			this.tbFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFile_DragDrop);
			this.tbFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFile_DragEnter);
			this.tbFile.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.tbFile.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(46, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(179, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Groupfile: (csv file or xls)";
			this.label3.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.label3.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// btnFile
			// 
			this.btnFile.Location = new System.Drawing.Point(556, 60);
			this.btnFile.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(84, 38);
			this.btnFile.TabIndex = 1;
			this.btnFile.Text = "&Browse";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			this.btnFile.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.btnFile.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// tbResult
			// 
			this.tbResult.Location = new System.Drawing.Point(50, 271);
			this.tbResult.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.ReadOnly = true;
			this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbResult.Size = new System.Drawing.Size(589, 264);
			this.tbResult.TabIndex = 10;
			this.tbResult.TabStop = false;
			this.tbResult.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.tbResult.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(46, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "Result:";
			this.label4.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.label4.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// comboHopar
			// 
			this.comboHopar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboHopar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboHopar.FormattingEnabled = true;
			this.comboHopar.Location = new System.Drawing.Point(392, 548);
			this.comboHopar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.comboHopar.Name = "comboHopar";
			this.comboHopar.Size = new System.Drawing.Size(128, 28);
			this.comboHopar.TabIndex = 12;
			this.comboHopar.SelectedIndexChanged += new System.EventHandler(this.comboHopar_SelectedIndexChanged_1);
			this.comboHopar.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.comboHopar.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// tmrKeyPressFileKey
			// 
			this.tmrKeyPressFileKey.Interval = 250;
			this.tmrKeyPressFileKey.Tick += new System.EventHandler(this.tmrKeyPressFile);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
			this.menuStrip1.Size = new System.Drawing.Size(724, 31);
			this.menuStrip1.Stretch = false;
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDestinationToolStripMenuItem,
            this.selectSpecificSolutionsToolStripMenuItem,
            this.reloadFileToolStripMenuItem,
            this.makeUploadFileToolStripMenuItem,
            this.devideHandinsOntoGroupsToolStripMenuItem,
            this.gradeAndCommentToolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 29);
			this.toolStripMenuItem1.Text = "&Commands";
			this.toolStripMenuItem1.ToolTipText = "Commands will be grayed if the to folder does not exit.\r\n\r\nI hope you can use thi" +
    "s application";
			// 
			// openDestinationToolStripMenuItem
			// 
			this.openDestinationToolStripMenuItem.Name = "openDestinationToolStripMenuItem";
			this.openDestinationToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.openDestinationToolStripMenuItem.Text = "Open Destination";
			this.openDestinationToolStripMenuItem.Click += new System.EventHandler(this.btnOpenDest_Click);
			this.openDestinationToolStripMenuItem.MouseEnter += new System.EventHandler(this.openDestinationToolStripMenuItem_MouseEnter);
			this.openDestinationToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// selectSpecificSolutionsToolStripMenuItem
			// 
			this.selectSpecificSolutionsToolStripMenuItem.Name = "selectSpecificSolutionsToolStripMenuItem";
			this.selectSpecificSolutionsToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.selectSpecificSolutionsToolStripMenuItem.Text = "Select specific solutions";
			this.selectSpecificSolutionsToolStripMenuItem.Click += new System.EventHandler(this.selectSpecificSolutionsToolStripMenuItem_Click);
			// 
			// reloadFileToolStripMenuItem
			// 
			this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
			this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.reloadFileToolStripMenuItem.Text = "Reload file";
			this.reloadFileToolStripMenuItem.Click += new System.EventHandler(this.reloadFileToolStripMenuItem_Click);
			this.reloadFileToolStripMenuItem.MouseEnter += new System.EventHandler(this.reloadFileToolStripMenuItem_MouseEnter);
			this.reloadFileToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// makeUploadFileToolStripMenuItem
			// 
			this.makeUploadFileToolStripMenuItem.Name = "makeUploadFileToolStripMenuItem";
			this.makeUploadFileToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.makeUploadFileToolStripMenuItem.Text = "Make upload file";
			this.makeUploadFileToolStripMenuItem.Click += new System.EventHandler(this.makeUploadFileToolStripMenuItem_Click);
			this.makeUploadFileToolStripMenuItem.MouseEnter += new System.EventHandler(this.makeUploadFileToolStripMenuItem_MouseEnter);
			this.makeUploadFileToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// devideHandinsOntoGroupsToolStripMenuItem
			// 
			this.devideHandinsOntoGroupsToolStripMenuItem.Name = "devideHandinsOntoGroupsToolStripMenuItem";
			this.devideHandinsOntoGroupsToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.devideHandinsOntoGroupsToolStripMenuItem.Text = "Devide handins onto groups";
			this.devideHandinsOntoGroupsToolStripMenuItem.Click += new System.EventHandler(this.devideHandinsOntoGroupsToolStripMenuItem_Click);
			this.devideHandinsOntoGroupsToolStripMenuItem.MouseEnter += new System.EventHandler(this.devideHandinsOntoGroupsToolStripMenuItem_MouseEnter);
			this.devideHandinsOntoGroupsToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// gradeAndCommentToolStripMenuItem1
			// 
			this.gradeAndCommentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeGradesToolStripMenuItem,
            this.changeCommentsToolStripMenuItem});
			this.gradeAndCommentToolStripMenuItem1.Name = "gradeAndCommentToolStripMenuItem1";
			this.gradeAndCommentToolStripMenuItem1.Size = new System.Drawing.Size(324, 30);
			this.gradeAndCommentToolStripMenuItem1.Text = "Grade and comment";
			// 
			// changeGradesToolStripMenuItem
			// 
			this.changeGradesToolStripMenuItem.Name = "changeGradesToolStripMenuItem";
			this.changeGradesToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
			this.changeGradesToolStripMenuItem.Text = "Change grades";
			// 
			// changeCommentsToolStripMenuItem
			// 
			this.changeCommentsToolStripMenuItem.Name = "changeCommentsToolStripMenuItem";
			this.changeCommentsToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
			this.changeCommentsToolStripMenuItem.Text = "Change comments";
			this.changeCommentsToolStripMenuItem.Click += new System.EventHandler(this.changeCommentsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(324, 30);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnClose_Click);
			this.exitToolStripMenuItem.MouseEnter += new System.EventHandler(this.exitToolStripMenuItem_MouseEnter);
			this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.toolStripMenuItem2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 29);
			this.toolStripMenuItem2.Text = "&Help";
			// 
			// checkForUpdateToolStripMenuItem
			// 
			this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
			this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
			this.checkForUpdateToolStripMenuItem.Text = "&Check for update";
			this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
			this.checkForUpdateToolStripMenuItem.MouseEnter += new System.EventHandler(this.checkForUpdateToolStripMenuItem_MouseEnter);
			this.checkForUpdateToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
			this.helpToolStripMenuItem.Text = "H&elp";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			this.helpToolStripMenuItem.MouseEnter += new System.EventHandler(this.helpToolStripMenuItem_MouseEnter);
			this.helpToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.About_Click);
			this.aboutToolStripMenuItem.MouseEnter += new System.EventHandler(this.aboutToolStripMenuItem_MouseEnter);
			this.aboutToolStripMenuItem.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 598);
			this.statusBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(724, 28);
			this.statusBar1.TabIndex = 15;
			this.statusBar1.Text = "statusBar1";
			this.statusBar1.MouseEnter += new System.EventHandler(this.control_MouseEnter);
			this.statusBar1.MouseLeave += new System.EventHandler(this.control_MouseLeave);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ForeColor = System.Drawing.Color.Red;
			this.textBox1.Location = new System.Drawing.Point(51, 471);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(588, 64);
			this.textBox1.TabIndex = 17;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Warning, when pressing Start you will be using the devided version of the assignm" +
    "ents.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 626);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.comboHopar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbResult);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnTo);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.btnFrom);
			this.Controls.Add(this.tbTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbFrom);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "GroupMove - MySchool Assignments";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.Button btnFrom;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboHopar;
        private System.Windows.Forms.Timer tmrKeyPressFileKey;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ToolStripMenuItem openDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeUploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem devideHandinsOntoGroupsToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripMenuItem reloadFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectSpecificSolutionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gradeAndCommentToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem changeGradesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeCommentsToolStripMenuItem;
	}
}

