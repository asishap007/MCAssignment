namespace GameReserveApp
{
    partial class Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // reportChart
            // 
            this.reportChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportChart.BackColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "ChartArea1";
            this.reportChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.reportChart.Legends.Add(legend1);
            this.reportChart.Location = new System.Drawing.Point(206, 12);
            this.reportChart.Name = "reportChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Lime;
            series1.Name = "Count";
            this.reportChart.Series.Add(series1);
            this.reportChart.Size = new System.Drawing.Size(406, 309);
            this.reportChart.TabIndex = 0;
            this.reportChart.Text = "reportChart";
            this.reportChart.Click += new System.EventHandler(this.reportChart_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // To
            // 
            this.To.BackColor = System.Drawing.SystemColors.Control;
            this.To.Location = new System.Drawing.Point(12, 116);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(30, 19);
            this.To.TabIndex = 2;
            this.To.Text = "To";
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.generateButton.Location = new System.Drawing.Point(63, 158);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 5;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(63, 62);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(126, 20);
            this.fromDatePicker.TabIndex = 6;
            this.fromDatePicker.ValueChanged += new System.EventHandler(this.fromDatePicker_ValueChanged);
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(63, 110);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(126, 20);
            this.toDatePicker.TabIndex = 7;
            this.toDatePicker.ValueChanged += new System.EventHandler(this.toDatePicker_ValueChanged);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(612, 323);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportChart);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
    }
}