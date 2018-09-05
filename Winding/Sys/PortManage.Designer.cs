namespace Winding.Sys
{
    partial class PortManage
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
            this.MesPort = new System.Windows.Forms.TextBox();
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
            // MesPort
            // 
            this.MesPort.Location = new System.Drawing.Point(125, 69);
            this.MesPort.Name = "MesPort";
            this.MesPort.Size = new System.Drawing.Size(390, 21);
            this.MesPort.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Mes接口:";
            // 
            // settingEnable
            // 
            this.settingEnable.Enabled = true;
            this.settingEnable.Interval = 1000;
            this.settingEnable.Tick += new System.EventHandler(this.settingEnable_Tick);
            // 
            // PortManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 364);
            this.Controls.Add(this.MesPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.line);
            this.Name = "PortManage";
            this.TabText = "     接口管理     ";
            this.Text = "     接口管理     ";
            this.Load += new System.EventHandler(this.PortManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox MesPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer settingEnable;
    }
}