namespace Winding.Sys
{
    partial class IPv4Address
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
            this.PLCIPv4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.equipmentIPv4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // PLCIPv4
            // 
            this.PLCIPv4.Location = new System.Drawing.Point(125, 108);
            this.PLCIPv4.Name = "PLCIPv4";
            this.PLCIPv4.Size = new System.Drawing.Size(254, 21);
            this.PLCIPv4.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "PLCIPv4:";
            // 
            // equipmentIPv4
            // 
            this.equipmentIPv4.Location = new System.Drawing.Point(125, 69);
            this.equipmentIPv4.Name = "equipmentIPv4";
            this.equipmentIPv4.Size = new System.Drawing.Size(254, 21);
            this.equipmentIPv4.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "设备IPv4:";
            // 
            // settingEnable
            // 
            this.settingEnable.Enabled = true;
            this.settingEnable.Interval = 1000;
            this.settingEnable.Tick += new System.EventHandler(this.settingEnable_Tick);
            // 
            // IPv4Address
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 442);
            this.Controls.Add(this.PLCIPv4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.equipmentIPv4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.line);
            this.Name = "IPv4Address";
            this.TabText = "     IPv4地址     ";
            this.Text = "     IPv4地址     ";
            this.Load += new System.EventHandler(this.IPv4Address_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox PLCIPv4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox equipmentIPv4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer settingEnable;
    }
}