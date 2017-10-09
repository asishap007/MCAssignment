namespace GameReserveApp
{
    partial class MainWindow
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.map_strip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.report_strip = new System.Windows.Forms.ToolStrip();
            this.reportLabel = new System.Windows.Forms.ToolStripLabel();
            this.allot_device_strip = new System.Windows.Forms.ToolStrip();
            this.allot_label = new System.Windows.Forms.ToolStripLabel();
            this.category_strip = new System.Windows.Forms.ToolStrip();
            this.category_label = new System.Windows.Forms.ToolStripLabel();
            this.sidePanel.SuspendLayout();
            this.map_strip.SuspendLayout();
            this.report_strip.SuspendLayout();
            this.allot_device_strip.SuspendLayout();
            this.category_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidePanel.Controls.Add(this.map_strip);
            this.sidePanel.Controls.Add(this.report_strip);
            this.sidePanel.Controls.Add(this.allot_device_strip);
            this.sidePanel.Controls.Add(this.category_strip);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(175, 503);
            this.sidePanel.TabIndex = 0;
            this.sidePanel.TabStop = true;
            // 
            // map_strip
            // 
            this.map_strip.AutoSize = false;
            this.map_strip.BackColor = System.Drawing.SystemColors.Highlight;
            this.map_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.map_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.map_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.map_strip.Location = new System.Drawing.Point(0, 165);
            this.map_strip.Name = "map_strip";
            this.map_strip.Size = new System.Drawing.Size(173, 62);
            this.map_strip.TabIndex = 4;
            this.map_strip.Text = "category";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(171, 50);
            this.toolStripLabel1.Text = "Locate Animals";
            this.toolStripLabel1.Click += new System.EventHandler(this.locate_Click);
            // 
            // report_strip
            // 
            this.report_strip.BackColor = System.Drawing.SystemColors.Highlight;
            this.report_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.report_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportLabel});
            this.report_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.report_strip.Location = new System.Drawing.Point(0, 110);
            this.report_strip.Name = "report_strip";
            this.report_strip.Size = new System.Drawing.Size(173, 55);
            this.report_strip.TabIndex = 3;
            this.report_strip.Text = "category";
            // 
            // reportLabel
            // 
            this.reportLabel.AutoSize = false;
            this.reportLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.reportLabel.Name = "reportLabel";
            this.reportLabel.Size = new System.Drawing.Size(171, 50);
            this.reportLabel.Text = "Report";
            this.reportLabel.Click += new System.EventHandler(this.report_Click);
            // 
            // allot_device_strip
            // 
            this.allot_device_strip.BackColor = System.Drawing.SystemColors.Highlight;
            this.allot_device_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.allot_device_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allot_label});
            this.allot_device_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.allot_device_strip.Location = new System.Drawing.Point(0, 55);
            this.allot_device_strip.Name = "allot_device_strip";
            this.allot_device_strip.Size = new System.Drawing.Size(173, 55);
            this.allot_device_strip.TabIndex = 2;
            this.allot_device_strip.Text = "category";
            // 
            // allot_label
            // 
            this.allot_label.AutoSize = false;
            this.allot_label.BackColor = System.Drawing.SystemColors.Highlight;
            this.allot_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.allot_label.Name = "allot_label";
            this.allot_label.Size = new System.Drawing.Size(171, 50);
            this.allot_label.Text = "Device Allocation";
            this.allot_label.Click += new System.EventHandler(this.allocation_Click);
            // 
            // category_strip
            // 
            this.category_strip.BackColor = System.Drawing.SystemColors.Highlight;
            this.category_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.category_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.category_label});
            this.category_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.category_strip.Location = new System.Drawing.Point(0, 0);
            this.category_strip.Name = "category_strip";
            this.category_strip.Size = new System.Drawing.Size(173, 55);
            this.category_strip.TabIndex = 0;
            this.category_strip.Text = "category";
            // 
            // category_label
            // 
            this.category_label.AutoSize = false;
            this.category_label.BackColor = System.Drawing.SystemColors.HotTrack;
            this.category_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.category_label.Name = "category_label";
            this.category_label.Size = new System.Drawing.Size(171, 50);
            this.category_label.Text = "Category";
            this.category_label.Click += new System.EventHandler(this.category_strip_click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameReserveApp.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(774, 503);
            this.Controls.Add(this.sidePanel);
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Reserve";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.map_strip.ResumeLayout(false);
            this.map_strip.PerformLayout();
            this.report_strip.ResumeLayout(false);
            this.report_strip.PerformLayout();
            this.allot_device_strip.ResumeLayout(false);
            this.allot_device_strip.PerformLayout();
            this.category_strip.ResumeLayout(false);
            this.category_strip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.ToolStrip category_strip;
        private System.Windows.Forms.ToolStripLabel category_label;
        private System.Windows.Forms.ToolStrip allot_device_strip;
        private System.Windows.Forms.ToolStripLabel allot_label;
        private System.Windows.Forms.ToolStrip report_strip;
        private System.Windows.Forms.ToolStripLabel reportLabel;
        private System.Windows.Forms.ToolStrip map_strip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

