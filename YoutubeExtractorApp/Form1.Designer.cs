namespace YoutubeExtractorApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Url = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.console = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressFile = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(12, 32);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(504, 199);
            this.list.TabIndex = 2;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(357, 4);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Url
            // 
            this.Url.Location = new System.Drawing.Point(12, 6);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(339, 20);
            this.Url.TabIndex = 4;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 286);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(504, 23);
            this.progress.TabIndex = 5;
            // 
            // console
            // 
            this.console.AutoSize = true;
            this.console.Location = new System.Drawing.Point(9, 270);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(35, 13);
            this.console.TabIndex = 6;
            this.console.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // progressFile
            // 
            this.progressFile.Location = new System.Drawing.Point(12, 333);
            this.progressFile.Name = "progressFile";
            this.progressFile.Size = new System.Drawing.Size(504, 23);
            this.progressFile.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 366);
            this.Controls.Add(this.progressFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.console);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.list);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "YoutubeExtractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label console;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressFile;
    }
}

