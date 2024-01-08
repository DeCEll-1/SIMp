namespace SSSystemGenerator.Forms
{
    partial class Map
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
            this.pb_Map = new System.Windows.Forms.PictureBox();
            this.btn_FormSizeIncrease = new System.Windows.Forms.Button();
            this.btn_DeZoom = new System.Windows.Forms.Button();
            this.btn_ResetMapVisuals = new System.Windows.Forms.Button();
            this.btn_FormSizeDecrease = new System.Windows.Forms.Button();
            this.btn_Zoom = new System.Windows.Forms.Button();
            this.lbl_PanelInfo = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.pb_Map.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Map
            // 
            this.pb_Map.Controls.Add(this.btn_FormSizeIncrease);
            this.pb_Map.Controls.Add(this.btn_DeZoom);
            this.pb_Map.Controls.Add(this.btn_Reset);
            this.pb_Map.Controls.Add(this.btn_ResetMapVisuals);
            this.pb_Map.Controls.Add(this.btn_FormSizeDecrease);
            this.pb_Map.Controls.Add(this.btn_Zoom);
            this.pb_Map.Controls.Add(this.lbl_PanelInfo);
            this.pb_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Map.Location = new System.Drawing.Point(0, 0);
            this.pb_Map.Name = "pnl_Map";
            this.pb_Map.Size = new System.Drawing.Size(1000, 1000);
            this.pb_Map.TabIndex = 0;
            this.pb_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Map_MouseDown);
            // 
            // btn_FormSizeIncrease
            // 
            this.btn_FormSizeIncrease.Location = new System.Drawing.Point(201, 30);
            this.btn_FormSizeIncrease.Name = "btn_FormSizeIncrease";
            this.btn_FormSizeIncrease.Size = new System.Drawing.Size(20, 20);
            this.btn_FormSizeIncrease.TabIndex = 1;
            this.btn_FormSizeIncrease.Text = ">";
            this.btn_FormSizeIncrease.UseVisualStyleBackColor = true;
            this.btn_FormSizeIncrease.Click += new System.EventHandler(this.btn_FormSizeIncrease_Click);
            // 
            // btn_DeZoom
            // 
            this.btn_DeZoom.Location = new System.Drawing.Point(201, 4);
            this.btn_DeZoom.Name = "btn_DeZoom";
            this.btn_DeZoom.Size = new System.Drawing.Size(20, 20);
            this.btn_DeZoom.TabIndex = 1;
            this.btn_DeZoom.Text = "-";
            this.btn_DeZoom.UseVisualStyleBackColor = true;
            this.btn_DeZoom.Click += new System.EventHandler(this.btn_DeZoom_Click);
            // 
            // btn_ResetMapVisuals
            // 
            this.btn_ResetMapVisuals.Location = new System.Drawing.Point(175, 4);
            this.btn_ResetMapVisuals.Name = "btn_ResetMapVisuals";
            this.btn_ResetMapVisuals.Size = new System.Drawing.Size(20, 20);
            this.btn_ResetMapVisuals.TabIndex = 1;
            this.btn_ResetMapVisuals.Text = "0";
            this.btn_ResetMapVisuals.UseVisualStyleBackColor = true;
            this.btn_ResetMapVisuals.Click += new System.EventHandler(this.btn_ResetMapVisuals_Click);
            // 
            // btn_FormSizeDecrease
            // 
            this.btn_FormSizeDecrease.Location = new System.Drawing.Point(149, 30);
            this.btn_FormSizeDecrease.Name = "btn_FormSizeDecrease";
            this.btn_FormSizeDecrease.Size = new System.Drawing.Size(20, 20);
            this.btn_FormSizeDecrease.TabIndex = 1;
            this.btn_FormSizeDecrease.Text = "<";
            this.btn_FormSizeDecrease.UseVisualStyleBackColor = true;
            this.btn_FormSizeDecrease.Click += new System.EventHandler(this.btn_FormSizeDecrease_Click);
            // 
            // btn_Zoom
            // 
            this.btn_Zoom.Location = new System.Drawing.Point(149, 4);
            this.btn_Zoom.Name = "btn_Zoom";
            this.btn_Zoom.Size = new System.Drawing.Size(20, 20);
            this.btn_Zoom.TabIndex = 1;
            this.btn_Zoom.Text = "+";
            this.btn_Zoom.UseVisualStyleBackColor = true;
            this.btn_Zoom.Click += new System.EventHandler(this.btn_Zoom_Click);
            // 
            // lbl_PanelInfo
            // 
            this.lbl_PanelInfo.AutoSize = true;
            this.lbl_PanelInfo.Location = new System.Drawing.Point(227, 4);
            this.lbl_PanelInfo.Name = "lbl_PanelInfo";
            this.lbl_PanelInfo.Size = new System.Drawing.Size(72, 13);
            this.lbl_PanelInfo.TabIndex = 0;
            this.lbl_PanelInfo.Text = "Panel Values:";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(175, 30);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(20, 20);
            this.btn_Reset.TabIndex = 1;
            this.btn_Reset.Text = "*";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.pb_Map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Map";
            this.Text = "Map";
            this.pb_Map.ResumeLayout(false);
            this.pb_Map.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Map;
        private System.Windows.Forms.Label lbl_PanelInfo;
        private System.Windows.Forms.Button btn_Zoom;
        private System.Windows.Forms.Button btn_DeZoom;
        private System.Windows.Forms.Button btn_ResetMapVisuals;
        private System.Windows.Forms.Button btn_FormSizeIncrease;
        private System.Windows.Forms.Button btn_FormSizeDecrease;
        private System.Windows.Forms.Button btn_Reset;
    }
}