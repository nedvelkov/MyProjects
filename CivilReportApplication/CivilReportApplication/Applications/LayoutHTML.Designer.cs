
namespace CivilReportApplication
{
    partial class formHtml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHtml));
            this.loadHtml = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.prBar1 = new System.Windows.Forms.ProgressBar();
            this.crtBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadHtml
            // 
            this.loadHtml.Location = new System.Drawing.Point(12, 27);
            this.loadHtml.Name = "loadHtml";
            this.loadHtml.Size = new System.Drawing.Size(140, 30);
            this.loadHtml.TabIndex = 1;
            this.loadHtml.Text = "Load HTML file";
            this.loadHtml.UseVisualStyleBackColor = true;
            this.loadHtml.Click += new System.EventHandler(this.LoadHtml_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(172, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 3;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 104);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(140, 30);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save location";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(172, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File name";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(172, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 20);
            this.textBox3.TabIndex = 7;
            // 
            // prBar1
            // 
            this.prBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prBar1.Location = new System.Drawing.Point(12, 205);
            this.prBar1.Name = "prBar1";
            this.prBar1.Size = new System.Drawing.Size(300, 23);
            this.prBar1.TabIndex = 8;
            // 
            // crtBtn
            // 
            this.crtBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtBtn.Location = new System.Drawing.Point(12, 156);
            this.crtBtn.Name = "crtBtn";
            this.crtBtn.Size = new System.Drawing.Size(300, 30);
            this.crtBtn.TabIndex = 9;
            this.crtBtn.Text = "Create file";
            this.crtBtn.UseVisualStyleBackColor = true;
            this.crtBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // formHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.crtBtn);
            this.Controls.Add(this.prBar1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loadHtml);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "formHtml";
            this.Text = "Surface profile HTML report for layout";
            this.Load += new System.EventHandler(this.FormHtml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadHtml;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ProgressBar prBar1;
        private System.Windows.Forms.Button crtBtn;
    }
}