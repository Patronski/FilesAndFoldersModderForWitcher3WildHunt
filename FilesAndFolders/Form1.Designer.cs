namespace FilesAndFolders
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonInfo = new System.Windows.Forms.Button();
            this.richTextReport = new System.Windows.Forms.RichTextBox();
            this.textBoxDownloadDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDocumentsDirectory = new System.Windows.Forms.TextBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDocumentsDirectory = new System.Windows.Forms.Button();
            this.buttonDownloadDirectory = new System.Windows.Forms.Button();
            this.buttonGameDIrectory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(340, 453);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 25);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // textBoxGameDirectory
            // 
            this.textBoxGameDirectory.Enabled = false;
            this.textBoxGameDirectory.Location = new System.Drawing.Point(45, 143);
            this.textBoxGameDirectory.Name = "textBoxGameDirectory";
            this.textBoxGameDirectory.Size = new System.Drawing.Size(340, 20);
            this.textBoxGameDirectory.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Navigate to The Witcher 3 Wild Hunt main directory:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInfo.Location = new System.Drawing.Point(45, 453);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(80, 25);
            this.buttonInfo.TabIndex = 13;
            this.buttonInfo.Text = "INFO";
            this.buttonInfo.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextReport.Location = new System.Drawing.Point(45, 253);
            this.richTextReport.Name = "richTextBox1";
            this.richTextReport.Size = new System.Drawing.Size(375, 169);
            this.richTextReport.TabIndex = 14;
            this.richTextReport.Text = "";
            // 
            // textBoxDownloadDirectory
            // 
            this.textBoxDownloadDirectory.Enabled = false;
            this.textBoxDownloadDirectory.Location = new System.Drawing.Point(45, 90);
            this.textBoxDownloadDirectory.Name = "textBoxDownloadDirectory";
            this.textBoxDownloadDirectory.Size = new System.Drawing.Size(340, 20);
            this.textBoxDownloadDirectory.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(42, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Where to download the Mod Pack:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(42, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Navigate to your Documents folder:";
            // 
            // textBoxDocumentsDirectory
            // 
            this.textBoxDocumentsDirectory.Enabled = false;
            this.textBoxDocumentsDirectory.Location = new System.Drawing.Point(45, 195);
            this.textBoxDocumentsDirectory.Name = "textBoxDocumentsDirectory";
            this.textBoxDocumentsDirectory.Size = new System.Drawing.Size(340, 20);
            this.textBoxDocumentsDirectory.TabIndex = 19;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(45, 39);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(340, 20);
            this.textBoxUrl.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(42, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Type URL link to MEGA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(42, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Action Log:";
            // 
            // buttonDocumentsDirectory
            // 
            this.buttonDocumentsDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDocumentsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDocumentsDirectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonDocumentsDirectory.Image")));
            this.buttonDocumentsDirectory.Location = new System.Drawing.Point(391, 191);
            this.buttonDocumentsDirectory.Name = "buttonDocumentsDirectory";
            this.buttonDocumentsDirectory.Size = new System.Drawing.Size(29, 27);
            this.buttonDocumentsDirectory.TabIndex = 20;
            this.buttonDocumentsDirectory.UseVisualStyleBackColor = true;
            this.buttonDocumentsDirectory.Click += new System.EventHandler(this.buttonDocumentsDirectory_Click);
            // 
            // buttonDownloadDirectory
            // 
            this.buttonDownloadDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDownloadDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadDirectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownloadDirectory.Image")));
            this.buttonDownloadDirectory.Location = new System.Drawing.Point(391, 86);
            this.buttonDownloadDirectory.Name = "buttonDownloadDirectory";
            this.buttonDownloadDirectory.Size = new System.Drawing.Size(29, 27);
            this.buttonDownloadDirectory.TabIndex = 16;
            this.buttonDownloadDirectory.UseVisualStyleBackColor = true;
            this.buttonDownloadDirectory.Click += new System.EventHandler(this.buttonDownloadDirectory_Click);
            // 
            // buttonGameDIrectory
            // 
            this.buttonGameDIrectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGameDIrectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGameDIrectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonGameDIrectory.Image")));
            this.buttonGameDIrectory.Location = new System.Drawing.Point(391, 139);
            this.buttonGameDIrectory.Name = "buttonGameDIrectory";
            this.buttonGameDIrectory.Size = new System.Drawing.Size(29, 27);
            this.buttonGameDIrectory.TabIndex = 4;
            this.buttonGameDIrectory.UseVisualStyleBackColor = true;
            this.buttonGameDIrectory.Click += new System.EventHandler(this.buttonGameDIrectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(461, 504);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDocumentsDirectory);
            this.Controls.Add(this.textBoxDocumentsDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDownloadDirectory);
            this.Controls.Add(this.textBoxDownloadDirectory);
            this.Controls.Add(this.richTextReport);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGameDirectory);
            this.Controls.Add(this.buttonGameDIrectory);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Teamy\'s Mod List Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button buttonGameDIrectory;
        private System.Windows.Forms.TextBox textBoxGameDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.RichTextBox richTextReport;
        private System.Windows.Forms.Button buttonDownloadDirectory;
        private System.Windows.Forms.TextBox textBoxDownloadDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDocumentsDirectory;
        private System.Windows.Forms.TextBox textBoxDocumentsDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label6;
    }
}

