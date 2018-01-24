namespace CV_Parser_using_NLP
{
    partial class CVForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jobRequirementLabel = new System.Windows.Forms.Label();
            this.topMatchingCVsLabel = new System.Windows.Forms.Label();
            this.jobTitleLabel = new System.Windows.Forms.Label();
            this.educationalQualificationLabel = new System.Windows.Forms.Label();
            this.skillsLabel = new System.Windows.Forms.Label();
            this.experienceLabel = new System.Windows.Forms.Label();
            this.cvDirectoryLabel = new System.Windows.Forms.Label();
            this.jobTitleTextbox = new System.Windows.Forms.TextBox();
            this.educationQualificationTextbox = new System.Windows.Forms.TextBox();
            this.skillsTextbox = new System.Windows.Forms.TextBox();
            this.experienceTextBox = new System.Windows.Forms.TextBox();
            this.cvDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.matchingCVTable = new System.Windows.Forms.DataGridView();
            this.cvRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitProgressBar = new System.Windows.Forms.ProgressBar();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.WaitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matchingCVTable)).BeginInit();
            this.LoadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Trebuchet MS", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(18)))));
            this.headerLabel.Location = new System.Drawing.Point(318, 17);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(891, 111);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "CV Parser Using NLP";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(2, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1516, 4);
            this.label2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(988, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(4, 765);
            this.label4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(2, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1516, 4);
            this.label3.TabIndex = 4;
            // 
            // jobRequirementLabel
            // 
            this.jobRequirementLabel.AutoSize = true;
            this.jobRequirementLabel.Font = new System.Drawing.Font("Trebuchet MS", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobRequirementLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(110)))));
            this.jobRequirementLabel.Location = new System.Drawing.Point(248, 152);
            this.jobRequirementLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.jobRequirementLabel.Name = "jobRequirementLabel";
            this.jobRequirementLabel.Size = new System.Drawing.Size(406, 63);
            this.jobRequirementLabel.TabIndex = 5;
            this.jobRequirementLabel.Text = "Job Requirement";
            // 
            // topMatchingCVsLabel
            // 
            this.topMatchingCVsLabel.AutoSize = true;
            this.topMatchingCVsLabel.Font = new System.Drawing.Font("Trebuchet MS", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMatchingCVsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(110)))));
            this.topMatchingCVsLabel.Location = new System.Drawing.Point(1060, 152);
            this.topMatchingCVsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.topMatchingCVsLabel.Name = "topMatchingCVsLabel";
            this.topMatchingCVsLabel.Size = new System.Drawing.Size(413, 63);
            this.topMatchingCVsLabel.TabIndex = 6;
            this.topMatchingCVsLabel.Text = "Top Matching CVs";
            // 
            // jobTitleLabel
            // 
            this.jobTitleLabel.AutoSize = true;
            this.jobTitleLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTitleLabel.ForeColor = System.Drawing.Color.White;
            this.jobTitleLabel.Location = new System.Drawing.Point(70, 262);
            this.jobTitleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new System.Drawing.Size(133, 33);
            this.jobTitleLabel.TabIndex = 7;
            this.jobTitleLabel.Text = "Job Title:";
            // 
            // educationalQualificationLabel
            // 
            this.educationalQualificationLabel.AutoSize = true;
            this.educationalQualificationLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.educationalQualificationLabel.ForeColor = System.Drawing.Color.White;
            this.educationalQualificationLabel.Location = new System.Drawing.Point(70, 387);
            this.educationalQualificationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.educationalQualificationLabel.Name = "educationalQualificationLabel";
            this.educationalQualificationLabel.Size = new System.Drawing.Size(611, 33);
            this.educationalQualificationLabel.TabIndex = 8;
            this.educationalQualificationLabel.Text = "Educational Qualification (Seperate with comma)";
            // 
            // skillsLabel
            // 
            this.skillsLabel.AutoSize = true;
            this.skillsLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillsLabel.ForeColor = System.Drawing.Color.White;
            this.skillsLabel.Location = new System.Drawing.Point(70, 508);
            this.skillsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.skillsLabel.Name = "skillsLabel";
            this.skillsLabel.Size = new System.Drawing.Size(367, 33);
            this.skillsLabel.TabIndex = 9;
            this.skillsLabel.Text = "Skills (Seperate with comma)";
            // 
            // experienceLabel
            // 
            this.experienceLabel.AutoSize = true;
            this.experienceLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experienceLabel.ForeColor = System.Drawing.Color.White;
            this.experienceLabel.Location = new System.Drawing.Point(70, 635);
            this.experienceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.experienceLabel.Name = "experienceLabel";
            this.experienceLabel.Size = new System.Drawing.Size(392, 33);
            this.experienceLabel.TabIndex = 10;
            this.experienceLabel.Text = "Experience (Seperated by line)";
            // 
            // cvDirectoryLabel
            // 
            this.cvDirectoryLabel.AutoSize = true;
            this.cvDirectoryLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvDirectoryLabel.ForeColor = System.Drawing.Color.White;
            this.cvDirectoryLabel.Location = new System.Drawing.Point(70, 765);
            this.cvDirectoryLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cvDirectoryLabel.Name = "cvDirectoryLabel";
            this.cvDirectoryLabel.Size = new System.Drawing.Size(169, 33);
            this.cvDirectoryLabel.TabIndex = 11;
            this.cvDirectoryLabel.Text = "CV Directory";
            // 
            // jobTitleTextbox
            // 
            this.jobTitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobTitleTextbox.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.jobTitleTextbox.Location = new System.Drawing.Point(76, 321);
            this.jobTitleTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.jobTitleTextbox.Name = "jobTitleTextbox";
            this.jobTitleTextbox.Size = new System.Drawing.Size(488, 31);
            this.jobTitleTextbox.TabIndex = 12;
            // 
            // educationQualificationTextbox
            // 
            this.educationQualificationTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.educationQualificationTextbox.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.educationQualificationTextbox.Location = new System.Drawing.Point(76, 442);
            this.educationQualificationTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.educationQualificationTextbox.Name = "educationQualificationTextbox";
            this.educationQualificationTextbox.Size = new System.Drawing.Size(488, 31);
            this.educationQualificationTextbox.TabIndex = 13;
            this.educationQualificationTextbox.Text = "Example: Bachelor in Computer";
            // 
            // skillsTextbox
            // 
            this.skillsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skillsTextbox.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.skillsTextbox.Location = new System.Drawing.Point(76, 567);
            this.skillsTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.skillsTextbox.Name = "skillsTextbox";
            this.skillsTextbox.Size = new System.Drawing.Size(488, 31);
            this.skillsTextbox.TabIndex = 14;
            this.skillsTextbox.Text = "Skill, skill";
            // 
            // experienceTextBox
            // 
            this.experienceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.experienceTextBox.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.experienceTextBox.Location = new System.Drawing.Point(76, 674);
            this.experienceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.experienceTextBox.Multiline = true;
            this.experienceTextBox.Name = "experienceTextBox";
            this.experienceTextBox.Size = new System.Drawing.Size(488, 85);
            this.experienceTextBox.TabIndex = 15;
            this.experienceTextBox.Text = "Example: Programming, 3";
            // 
            // cvDirectoryTextbox
            // 
            this.cvDirectoryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cvDirectoryTextbox.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.cvDirectoryTextbox.Location = new System.Drawing.Point(76, 823);
            this.cvDirectoryTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.cvDirectoryTextbox.Name = "cvDirectoryTextbox";
            this.cvDirectoryTextbox.Size = new System.Drawing.Size(488, 31);
            this.cvDirectoryTextbox.TabIndex = 16;
            this.cvDirectoryTextbox.Text = "Input CV Directory";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(18)))));
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(608, 810);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(6);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(150, 62);
            this.BrowseButton.TabIndex = 17;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(18)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(804, 810);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(6);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(150, 62);
            this.SearchButton.TabIndex = 18;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // matchingCVTable
            // 
            this.matchingCVTable.AllowUserToAddRows = false;
            this.matchingCVTable.AllowUserToDeleteRows = false;
            this.matchingCVTable.AllowUserToResizeColumns = false;
            this.matchingCVTable.AllowUserToResizeRows = false;
            this.matchingCVTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.matchingCVTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchingCVTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cvRank,
            this.cvTitle});
            this.matchingCVTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.matchingCVTable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.matchingCVTable.Location = new System.Drawing.Point(1022, 254);
            this.matchingCVTable.Margin = new System.Windows.Forms.Padding(6);
            this.matchingCVTable.Name = "matchingCVTable";
            this.matchingCVTable.RowHeadersVisible = false;
            this.matchingCVTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.matchingCVTable.Size = new System.Drawing.Size(457, 617);
            this.matchingCVTable.TabIndex = 19;
            // 
            // cvRank
            // 
            this.cvRank.HeaderText = "RANK";
            this.cvRank.Name = "cvRank";
            this.cvRank.Width = 50;
            // 
            // cvTitle
            // 
            this.cvTitle.HeaderText = "CV Title";
            this.cvTitle.Name = "cvTitle";
            this.cvTitle.Width = 175;
            // 
            // InitProgressBar
            // 
            this.InitProgressBar.Location = new System.Drawing.Point(513, 185);
            this.InitProgressBar.MarqueeAnimationSpeed = 20;
            this.InitProgressBar.Name = "InitProgressBar";
            this.InitProgressBar.Size = new System.Drawing.Size(519, 42);
            this.InitProgressBar.Step = 0;
            this.InitProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.InitProgressBar.TabIndex = 20;
            this.InitProgressBar.UseWaitCursor = true;
            this.InitProgressBar.Value = 10;
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.LoadingPanel.Controls.Add(this.WaitLabel);
            this.LoadingPanel.Controls.Add(this.InitProgressBar);
            this.LoadingPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadingPanel.Location = new System.Drawing.Point(2, 320);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(1525, 304);
            this.LoadingPanel.TabIndex = 21;
            // 
            // WaitLabel
            // 
            this.WaitLabel.AutoSize = true;
            this.WaitLabel.Font = new System.Drawing.Font("Arial", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaitLabel.ForeColor = System.Drawing.Color.White;
            this.WaitLabel.Location = new System.Drawing.Point(351, 77);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.Size = new System.Drawing.Size(879, 49);
            this.WaitLabel.TabIndex = 21;
            this.WaitLabel.Text = "Please wait while we get things ready for you";
            // 
            // CVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1518, 902);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.matchingCVTable);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.cvDirectoryTextbox);
            this.Controls.Add(this.experienceTextBox);
            this.Controls.Add(this.skillsTextbox);
            this.Controls.Add(this.educationQualificationTextbox);
            this.Controls.Add(this.jobTitleTextbox);
            this.Controls.Add(this.cvDirectoryLabel);
            this.Controls.Add(this.experienceLabel);
            this.Controls.Add(this.skillsLabel);
            this.Controls.Add(this.educationalQualificationLabel);
            this.Controls.Add(this.jobTitleLabel);
            this.Controls.Add(this.topMatchingCVsLabel);
            this.Controls.Add(this.jobRequirementLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CVForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CV Parser";
            ((System.ComponentModel.ISupportInitialize)(this.matchingCVTable)).EndInit();
            this.LoadingPanel.ResumeLayout(false);
            this.LoadingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label jobRequirementLabel;
        private System.Windows.Forms.Label topMatchingCVsLabel;
        private System.Windows.Forms.Label jobTitleLabel;
        private System.Windows.Forms.Label educationalQualificationLabel;
        private System.Windows.Forms.Label skillsLabel;
        private System.Windows.Forms.Label experienceLabel;
        private System.Windows.Forms.Label cvDirectoryLabel;
        private System.Windows.Forms.TextBox jobTitleTextbox;
        private System.Windows.Forms.TextBox educationQualificationTextbox;
        private System.Windows.Forms.TextBox skillsTextbox;
        private System.Windows.Forms.TextBox experienceTextBox;
        private System.Windows.Forms.TextBox cvDirectoryTextbox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView matchingCVTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvTitle;
        private System.Windows.Forms.ProgressBar InitProgressBar;
        private System.Windows.Forms.Panel LoadingPanel;
        private System.Windows.Forms.Label WaitLabel;
    }
}

