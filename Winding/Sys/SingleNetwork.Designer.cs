namespace Winding.Sys
{
    partial class SingleNetwork
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
            this.Save = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Label();
            this.txtGetProcessName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSetProcessName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GetProcessName = new System.Windows.Forms.Button();
            this.settingEnable = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(10, 8);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(99, 29);
            this.Save.TabIndex = 38;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.DarkBlue;
            this.line.Location = new System.Drawing.Point(-2, 44);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(449, 2);
            this.line.TabIndex = 37;
            // 
            // txtGetProcessName
            // 
            this.txtGetProcessName.Location = new System.Drawing.Point(156, 69);
            this.txtGetProcessName.Name = "txtGetProcessName";
            this.txtGetProcessName.Size = new System.Drawing.Size(359, 21);
            this.txtGetProcessName.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "EXCEL进程名:";
            // 
            // txtSetProcessName
            // 
            this.txtSetProcessName.Location = new System.Drawing.Point(156, 106);
            this.txtSetProcessName.Name = "txtSetProcessName";
            this.txtSetProcessName.Size = new System.Drawing.Size(359, 21);
            this.txtSetProcessName.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "EXCEL保存参数:";
            // 
            // GetProcessName
            // 
            this.GetProcessName.Location = new System.Drawing.Point(228, 8);
            this.GetProcessName.Name = "GetProcessName";
            this.GetProcessName.Size = new System.Drawing.Size(99, 29);
            this.GetProcessName.TabIndex = 51;
            this.GetProcessName.Text = "获取进程名";
            this.GetProcessName.UseVisualStyleBackColor = true;
            this.GetProcessName.Click += new System.EventHandler(this.GetProcessName_Click);
            // 
            // settingEnable
            // 
            this.settingEnable.Enabled = true;
            this.settingEnable.Interval = 1000;
            this.settingEnable.Tick += new System.EventHandler(this.settingEnable_Tick);
            // 
            // SingleNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(523, 484);
            this.Controls.Add(this.GetProcessName);
            this.Controls.Add(this.txtSetProcessName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGetProcessName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.line);
            this.Name = "SingleNetwork";
            this.TabText = "     EXCEL状态     ";
            this.Text = "     EXCEL状态     ";
            this.Load += new System.EventHandler(this.SingleNetwork_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox txtGetProcessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSetProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetProcessName;
        private System.Windows.Forms.Timer settingEnable;
    }
}