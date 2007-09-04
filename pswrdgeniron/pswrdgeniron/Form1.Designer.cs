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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(344, 469);
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
            this.tbDisplay.Location = new System.Drawing.Point(12, 238);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDisplay.Size = new System.Drawing.Size(474, 225);
            this.tbDisplay.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox1.Size = new System.Drawing.Size(474, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Generator Options...";
            // 
            // cbGencount
            // 
            this.cbGencount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGencount.FormattingEnabled = true;
            this.cbGencount.Location = new System.Drawing.Point(367, 106);
            this.cbGencount.Name = "cbGencount";
            this.cbGencount.Size = new System.Drawing.Size(51, 26);
            this.cbGencount.TabIndex = 11;
            this.cbGencount.SelectedIndexChanged += new System.EventHandler(this.cbGencount_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Passwords to generate:";
            // 
            // cbCaps
            // 
            this.cbCaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaps.FormattingEnabled = true;
            this.cbCaps.Location = new System.Drawing.Point(367, 61);
            this.cbCaps.Name = "cbCaps";
            this.cbCaps.Size = new System.Drawing.Size(51, 26);
            this.cbCaps.TabIndex = 9;
            this.cbCaps.SelectedIndexChanged += new System.EventHandler(this.cbCaps_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Capitals in password:";
            // 
            // cbMaxLength
            // 
            this.cbMaxLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxLength.FormattingEnabled = true;
            this.cbMaxLength.Location = new System.Drawing.Point(94, 101);
            this.cbMaxLength.Name = "cbMaxLength";
            this.cbMaxLength.Size = new System.Drawing.Size(51, 26);
            this.cbMaxLength.TabIndex = 7;
            this.cbMaxLength.SelectedIndexChanged += new System.EventHandler(this.cbMaxLength_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max length:";
            // 
            // cbMinLength
            // 
            this.cbMinLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinLength.FormattingEnabled = true;
            this.cbMinLength.Location = new System.Drawing.Point(94, 61);
            this.cbMinLength.Name = "cbMinLength";
            this.cbMinLength.Size = new System.Drawing.Size(51, 26);
            this.cbMinLength.TabIndex = 5;
            this.cbMinLength.SelectedIndexChanged += new System.EventHandler(this.cbMinLength_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
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
            this.bUpdate.Location = new System.Drawing.Point(169, 153);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(136, 27);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "Update Options";
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
            this.tbSwapSet.Location = new System.Drawing.Point(115, 26);
            this.tbSwapSet.Name = "tbSwapSet";
            this.tbSwapSet.Size = new System.Drawing.Size(353, 26);
            this.tbSwapSet.TabIndex = 0;
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btRun.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRun.Location = new System.Drawing.Point(181, 205);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(136, 27);
            this.btRun.TabIndex = 12;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btDownload
            // 
            this.btDownload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDownload.Location = new System.Drawing.Point(21, 469);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(236, 27);
            this.btDownload.TabIndex = 13;
            this.btDownload.Text = "Check for pswrdgen.py update";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 504);
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
    }
}

