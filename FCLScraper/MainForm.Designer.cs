namespace FCLScraper
{
    partial class MainForm
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
            this.btnScrapeFirst = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabScraper = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.listBoxFirst = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectNone2 = new System.Windows.Forms.Button();
            this.btnSelectAll2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScrapeSecond = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabScraper.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScrapeFirst
            // 
            this.btnScrapeFirst.Location = new System.Drawing.Point(183, 551);
            this.btnScrapeFirst.Name = "btnScrapeFirst";
            this.btnScrapeFirst.Size = new System.Drawing.Size(80, 31);
            this.btnScrapeFirst.TabIndex = 0;
            this.btnScrapeFirst.Text = "Start";
            this.btnScrapeFirst.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelStatus.Location = new System.Drawing.Point(1, 631);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1016, 24);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status: ";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabScraper);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1020, 625);
            this.tabControl1.TabIndex = 2;
            // 
            // tabScraper
            // 
            this.tabScraper.Controls.Add(this.label2);
            this.tabScraper.Controls.Add(this.btnScrapeSecond);
            this.tabScraper.Controls.Add(this.label1);
            this.tabScraper.Controls.Add(this.btnSelectNone2);
            this.tabScraper.Controls.Add(this.btnSelectAll2);
            this.tabScraper.Controls.Add(this.btnSelectNone);
            this.tabScraper.Controls.Add(this.btnSelectAll);
            this.tabScraper.Controls.Add(this.listBox1);
            this.tabScraper.Controls.Add(this.listBoxFirst);
            this.tabScraper.Controls.Add(this.btnScrapeFirst);
            this.tabScraper.Location = new System.Drawing.Point(4, 22);
            this.tabScraper.Name = "tabScraper";
            this.tabScraper.Padding = new System.Windows.Forms.Padding(3);
            this.tabScraper.Size = new System.Drawing.Size(1012, 599);
            this.tabScraper.TabIndex = 0;
            this.tabScraper.Text = "Scraper";
            this.tabScraper.UseVisualStyleBackColor = true;
            this.tabScraper.Click += new System.EventHandler(this.tabScraper_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1012, 599);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // listBoxFirst
            // 
            this.listBoxFirst.FormattingEnabled = true;
            this.listBoxFirst.Location = new System.Drawing.Point(7, 53);
            this.listBoxFirst.Name = "listBoxFirst";
            this.listBoxFirst.Size = new System.Drawing.Size(170, 485);
            this.listBoxFirst.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(418, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(170, 485);
            this.listBox1.TabIndex = 1;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(7, 551);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(80, 31);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(97, 551);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(80, 31);
            this.btnSelectNone.TabIndex = 3;
            this.btnSelectNone.Text = "Select None";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            // 
            // btnSelectNone2
            // 
            this.btnSelectNone2.Location = new System.Drawing.Point(508, 551);
            this.btnSelectNone2.Name = "btnSelectNone2";
            this.btnSelectNone2.Size = new System.Drawing.Size(80, 31);
            this.btnSelectNone2.TabIndex = 5;
            this.btnSelectNone2.Text = "Select None";
            this.btnSelectNone2.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll2
            // 
            this.btnSelectAll2.Location = new System.Drawing.Point(418, 551);
            this.btnSelectAll2.Name = "btnSelectAll2";
            this.btnSelectAll2.Size = new System.Drawing.Size(80, 31);
            this.btnSelectAll2.TabIndex = 4;
            this.btnSelectAll2.Text = "Select All";
            this.btnSelectAll2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "First Scrape";
            // 
            // btnScrapeSecond
            // 
            this.btnScrapeSecond.Location = new System.Drawing.Point(594, 551);
            this.btnScrapeSecond.Name = "btnScrapeSecond";
            this.btnScrapeSecond.Size = new System.Drawing.Size(80, 31);
            this.btnScrapeSecond.TabIndex = 7;
            this.btnScrapeSecond.Text = "Start";
            this.btnScrapeSecond.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(183, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "First Scrape";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 655);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelStatus);
            this.Name = "MainForm";
            this.Text = "FLC Scraper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabScraper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScrapeFirst;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabScraper;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ListBox listBoxFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectNone2;
        private System.Windows.Forms.Button btnSelectAll2;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnScrapeSecond;
        private System.Windows.Forms.Label label2;
    }
}

