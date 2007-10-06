namespace pswrdgeniron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bExit = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSavesettings = new System.Windows.Forms.Button();
            this.cdAddCount = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInsertionChars = new System.Windows.Forms.TextBox();
            this.cbGencount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCaps = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMaxLength = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMinLength = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSwapSet = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btDownload = new System.Windows.Forms.Button();
            this.cbWordFiles = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(344, 540);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(136, 27);
            this.bExit.TabIndex = 0;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplay.Location = new System.Drawing.Point(12, 387);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDisplay.Size = new System.Drawing.Size(474, 147);
            this.tbDisplay.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.bSavesettings);
            this.groupBox1.Controls.Add(this.cdAddCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbInsertionChars);
            this.groupBox1.Controls.Add(this.cbGencount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbCaps);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMaxLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMinLength);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bUpdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSwapSet);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 335);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Generator Options...";
            // 
            // bSavesettings
            // 
            this.bSavesettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bSavesettings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSavesettings.Location = new System.Drawing.Point(9, 204);
            this.bSavesettings.Name = "bSavesettings";
            this.bSavesettings.Size = new System.Drawing.Size(136, 27);
            this.bSavesettings.TabIndex = 16;
            this.bSavesettings.Text = "Save settings";
            this.bSavesettings.UseVisualStyleBackColor = true;
            this.bSavesettings.Click += new System.EventHandler(this.bSavesettings_Click);
            // 
            // cdAddCount
            // 
            this.cdAddCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cdAddCount.FormattingEnabled = true;
            this.cdAddCount.Location = new System.Drawing.Point(203, 169);
            this.cdAddCount.Name = "cdAddCount";
            this.cdAddCount.Size = new System.Drawing.Size(51, 26);
            this.cdAddCount.TabIndex = 15;
            this.cdAddCount.SelectedIndexChanged += new System.EventHandler(this.cdAddCount_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Number of random inserts:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Insertion Chars:";
            // 
            // tbInsertionChars
            // 
            this.tbInsertionChars.Location = new System.Drawing.Point(128, 58);
            this.tbInsertionChars.Name = "tbInsertionChars";
            this.tbInsertionChars.Size = new System.Drawing.Size(340, 26);
            this.tbInsertionChars.TabIndex = 12;
            this.tbInsertionChars.TextChanged += new System.EventHandler(this.tbInsertionChars_TextChanged);
            // 
            // cbGencount
            // 
            this.cbGencount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGencount.FormattingEnabled = true;
            this.cbGencount.Location = new System.Drawing.Point(367, 133);
            this.cbGencount.Name = "cbGencount";
            this.cbGencount.Size = new System.Drawing.Size(51, 26);
            this.cbGencount.TabIndex = 11;
            this.cbGencount.SelectedIndexChanged += new System.EventHandler(this.cbGencount_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Passwords to generate:";
            // 
            // cbCaps
            // 
            this.cbCaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaps.FormattingEnabled = true;
            this.cbCaps.Location = new System.Drawing.Point(367, 93);
            this.cbCaps.Name = "cbCaps";
            this.cbCaps.Size = new System.Drawing.Size(51, 26);
            this.cbCaps.TabIndex = 9;
            this.cbCaps.SelectedIndexChanged += new System.EventHandler(this.cbCaps_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Capitals in password:";
            // 
            // cbMaxLength
            // 
            this.cbMaxLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxLength.FormattingEnabled = true;
            this.cbMaxLength.Location = new System.Drawing.Point(94, 133);
            this.cbMaxLength.Name = "cbMaxLength";
            this.cbMaxLength.Size = new System.Drawing.Size(51, 26);
            this.cbMaxLength.TabIndex = 7;
            this.cbMaxLength.SelectedIndexChanged += new System.EventHandler(this.cbMaxLength_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max length:";
            // 
            // cbMinLength
            // 
            this.cbMinLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinLength.FormattingEnabled = true;
            this.cbMinLength.Location = new System.Drawing.Point(94, 93);
            this.cbMinLength.Name = "cbMinLength";
            this.cbMinLength.Size = new System.Drawing.Size(51, 26);
            this.cbMinLength.TabIndex = 5;
            this.cbMinLength.SelectedIndexChanged += new System.EventHandler(this.cbMinLength_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min length:";
            // 
            // bUpdate
            // 
            this.bUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUpdate.Location = new System.Drawing.Point(332, 204);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(136, 27);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "Update settings";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "SwapSet Dict:";
            // 
            // tbSwapSet
            // 
            this.tbSwapSet.Location = new System.Drawing.Point(128, 26);
            this.tbSwapSet.Name = "tbSwapSet";
            this.tbSwapSet.Size = new System.Drawing.Size(340, 26);
            this.tbSwapSet.TabIndex = 0;
            this.tbSwapSet.TextChanged += new System.EventHandler(this.tbSwapSet_TextChanged);
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRun.Location = new System.Drawing.Point(181, 354);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(136, 27);
            this.btRun.TabIndex = 12;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btDownload
            // 
            this.btDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDownload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDownload.Location = new System.Drawing.Point(12, 540);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(236, 27);
            this.btDownload.TabIndex = 13;
            this.btDownload.Text = "Check for pswrdgen.py update";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // cbWordFiles
            // 
            this.cbWordFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWordFiles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWordFiles.FormattingEnabled = true;
            this.cbWordFiles.Location = new System.Drawing.Point(8, 25);
            this.cbWordFiles.Name = "cbWordFiles";
            this.cbWordFiles.Size = new System.Drawing.Size(352, 22);
            this.cbWordFiles.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btBrowse);
            this.groupBox2.Controls.Add(this.cbWordFiles);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 83);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Word Files in Use...";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(190, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 22);
            this.button1.TabIndex = 20;
            this.button1.Text = "Remove selected word file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBrowse.Location = new System.Drawing.Point(366, 25);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(71, 22);
            this.btBrowse.TabIndex = 19;
            this.btBrowse.Text = "Browse...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 575);
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.bExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pswrdgen - Easily generate good passwords; Your way!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSwapSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMinLength;
        private System.Windows.Forms.ComboBox cbMaxLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCaps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGencount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInsertionChars;
        private System.Windows.Forms.ComboBox cdAddCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bSavesettings;
        private System.Windows.Forms.ComboBox cbWordFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button button1;
    }
}

