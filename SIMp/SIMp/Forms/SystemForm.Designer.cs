namespace SIMp.Forms
{
    partial class SystemForm
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
            this.gb_BaseInfo = new System.Windows.Forms.GroupBox();
            this.lbl_SystemName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gb_Specials = new System.Windows.Forms.GroupBox();
            this.tb_SystemName = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.gb_BaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_BaseInfo
            // 
            this.gb_BaseInfo.Controls.Add(this.btn_Save);
            this.gb_BaseInfo.Controls.Add(this.tb_SystemName);
            this.gb_BaseInfo.Controls.Add(this.lbl_SystemName);
            this.gb_BaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_BaseInfo.Location = new System.Drawing.Point(0, 0);
            this.gb_BaseInfo.Name = "gb_BaseInfo";
            this.gb_BaseInfo.Size = new System.Drawing.Size(384, 196);
            this.gb_BaseInfo.TabIndex = 0;
            this.gb_BaseInfo.TabStop = false;
            this.gb_BaseInfo.Text = "Base Information";
            // 
            // lbl_SystemName
            // 
            this.lbl_SystemName.AutoSize = true;
            this.lbl_SystemName.Location = new System.Drawing.Point(12, 16);
            this.lbl_SystemName.Name = "lbl_SystemName";
            this.lbl_SystemName.Size = new System.Drawing.Size(78, 13);
            this.lbl_SystemName.TabIndex = 0;
            this.lbl_SystemName.Text = "System Name: ";
            // 
            // gb_Specials
            // 
            this.gb_Specials.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_Specials.Location = new System.Drawing.Point(0, 202);
            this.gb_Specials.Name = "gb_Specials";
            this.gb_Specials.Size = new System.Drawing.Size(384, 252);
            this.gb_Specials.TabIndex = 1;
            this.gb_Specials.TabStop = false;
            this.gb_Specials.Text = "Specials";
            // 
            // tb_SystemName
            // 
            this.tb_SystemName.Location = new System.Drawing.Point(12, 32);
            this.tb_SystemName.Name = "tb_SystemName";
            this.tb_SystemName.Size = new System.Drawing.Size(137, 20);
            this.tb_SystemName.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(241, 167);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(137, 23);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save System";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 454);
            this.Controls.Add(this.gb_Specials);
            this.Controls.Add(this.gb_BaseInfo);
            this.Name = "SystemForm";
            this.Text = "SystemForm";
            this.gb_BaseInfo.ResumeLayout(false);
            this.gb_BaseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_BaseInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gb_Specials;
        private System.Windows.Forms.Label lbl_SystemName;
        private System.Windows.Forms.TextBox tb_SystemName;
        private System.Windows.Forms.Button btn_Save;
    }
}