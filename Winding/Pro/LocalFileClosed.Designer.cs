namespace Winding.Pro
{
    partial class LocalFileClosed
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
            this.GetFirstArticle = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetFirstArticle
            // 
            this.GetFirstArticle.Location = new System.Drawing.Point(24, 8);
            this.GetFirstArticle.Name = "GetFirstArticle";
            this.GetFirstArticle.Size = new System.Drawing.Size(158, 29);
            this.GetFirstArticle.TabIndex = 48;
            this.GetFirstArticle.Text = "本地文件已关闭";
            this.GetFirstArticle.UseVisualStyleBackColor = true;
            this.GetFirstArticle.Click += new System.EventHandler(this.GetFirstArticle_Click);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.DarkBlue;
            this.line.Location = new System.Drawing.Point(0, 44);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(509, 2);
            this.line.TabIndex = 47;
            // 
            // LocalFileClosed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 390);
            this.Controls.Add(this.GetFirstArticle);
            this.Controls.Add(this.line);
            this.Name = "LocalFileClosed";
            this.TabText = "文件关闭确认";
            this.Text = "文件关闭确认";
            this.Load += new System.EventHandler(this.LocalFileClosed_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetFirstArticle;
        private System.Windows.Forms.Label line;
    }
}