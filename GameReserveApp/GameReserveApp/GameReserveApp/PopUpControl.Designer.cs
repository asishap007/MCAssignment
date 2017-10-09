namespace GameReserveApp
{
    partial class PopUpControl
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.popUpMessageLabel = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // popUpMessageLabel
            // 
            this.popUpMessageLabel.BackColor = System.Drawing.SystemColors.Menu;
            this.popUpMessageLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.popUpMessageLabel.Location = new System.Drawing.Point(48, 37);
            this.popUpMessageLabel.Name = "popUpMessageLabel";
            this.popUpMessageLabel.Size = new System.Drawing.Size(192, 43);
            this.popUpMessageLabel.TabIndex = 0;
            this.popUpMessageLabel.Text = "";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(165, 97);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // PopUpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 142);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.popUpMessageLabel);
            this.Name = "PopUpControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUpControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RichTextBox popUpMessageLabel;
        private System.Windows.Forms.Button okButton;

    }
}