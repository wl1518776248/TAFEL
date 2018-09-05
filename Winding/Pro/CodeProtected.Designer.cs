namespace Winding.Pro
{
    partial class CodeProtected
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
            this.codeLengthTwo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codeLengthOne = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Label();
            this.codeLengthThree = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.settingEnable = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // codeLengthTwo
            // 
            this.codeLengthTwo.Location = new System.Drawing.Point(125, 108);
            this.codeLengthTwo.Name = "codeLengthTwo";
            this.codeLengthTwo.Size = new System.Drawing.Size(254, 21);
            this.codeLengthTwo.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "条码长度[2]:";
            // 
            // codeLengthOne
            // 
            this.codeLengthOne.Location = new System.Drawing.Point(125, 69);
            this.codeLengthOne.Name = "codeLengthOne";
            this.codeLengthOne.Size = new System.Drawing.Size(254, 21);
            this.codeLengthOne.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "条码长度[1]:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(10, 8);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(99, 29);
            this.Save.TabIndex = 42;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.DarkBlue;
            this.line.Location = new System.Drawing.Point(0, 44);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(449, 2);
            this.line.TabIndex = 41;
            // 
            // codeLengthThree
            // 
            this.codeLengthThree.Location = new System.Drawing.Point(125, 147);
            this.codeLengthThree.Name = "codeLengthThree";
            this.codeLengthThree.Size = new System.Drawing.Size(254, 21);
            this.codeLengthThree.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "条码长度[3]:";
            // 
            // settingEnable
            // 
            this.settingEnable.Enabled = true;
            this.settingEnable.Interval = 1000;
            this.settingEnable.Tick += new System.EventHandler(this.settingEnable_Tick);
            // 
            // CodeProtected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 264);
            this.Controls.Add(this.codeLengthThree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codeLengthTwo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeLengthOne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.line);
            this.Name = "CodeProtected";
            this.TabText = "     条码防误     ";
            this.Text = "     条码防误     ";
            this.Load += new System.EventHandler(this.CodeProtected_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeLengthTwo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeLengthOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox codeLengthThree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer settingEnable;
    }
}