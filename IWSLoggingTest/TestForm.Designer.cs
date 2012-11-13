namespace IWSLoggingTest
{
    partial class TestForm
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
            this.pbDebug = new System.Windows.Forms.Button();
            this.pbException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbDebug
            // 
            this.pbDebug.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pbDebug.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pbDebug.Location = new System.Drawing.Point(73, 30);
            this.pbDebug.Name = "pbDebug";
            this.pbDebug.Size = new System.Drawing.Size(75, 23);
            this.pbDebug.TabIndex = 0;
            this.pbDebug.Text = "Debug";
            this.pbDebug.UseVisualStyleBackColor = false;
            this.pbDebug.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbException
            // 
            this.pbException.BackColor = System.Drawing.Color.Red;
            this.pbException.Location = new System.Drawing.Point(73, 74);
            this.pbException.Name = "pbException";
            this.pbException.Size = new System.Drawing.Size(75, 23);
            this.pbException.TabIndex = 1;
            this.pbException.Text = "Exception";
            this.pbException.UseVisualStyleBackColor = false;
            this.pbException.Click += new System.EventHandler(this.button2_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 148);
            this.Controls.Add(this.pbException);
            this.Controls.Add(this.pbDebug);
            this.Name = "TestForm";
            this.Text = "WindowingLogAppender Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pbDebug;
        private System.Windows.Forms.Button pbException;
    }
}

