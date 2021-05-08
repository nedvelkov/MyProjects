
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
            this.rtnBtn = new System.Windows.Forms.Button();
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
            // rtnBtn
            // 
            this.rtnBtn.Location = new System.Drawing.Point(193, 156);
            this.rtnBtn.Name = "rtnBtn";
            this.rtnBtn.Size = new System.Drawing.Size(187, 30);
            this.rtnBtn.TabIndex = 0;
            this.rtnBtn.Text = "Return";
            this.rtnBtn.UseVisualStyleBackColor = true;
            this.rtnBtn.Click += new System.EventHandler(this.rtnBtn_Click);
            // 
            // loadHtml
            // 
            this.loadHtml.Location = new System.Drawing.Point(26, 27);
            this.loadHtml.Name = "loadHtml";
            this.loadHtml.Size = new System.Drawing.Size(150, 30);
            this.loadHtml.TabIndex = 1;
            this.loadHtml.Text = "Load HTML file";
            this.loadHtml.UseVisualStyleBackColor = true;
            this.loadHtml.Click += new System.EventHandler(this.loadHtml_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 3;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(26, 104);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 30);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save location";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(193, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(187, 20);
            this.textBox3.TabIndex = 7;
            // 
            // prBar1
            // 
            this.prBar1.Location = new System.Drawing.Point(26, 206);
            this.prBar1.Name = "prBar1";
            this.prBar1.Size = new System.Drawing.Size(357, 24);
            this.prBar1.TabIndex = 8;
            // 
            // crtBtn
            // 
            this.crtBtn.Location = new System.Drawing.Point(26, 156);
            this.crtBtn.Name = "crtBtn";
            this.crtBtn.Size = new System.Drawing.Size(150, 30);
            this.crtBtn.TabIndex = 9;
            this.crtBtn.Text = "Create file";
            this.crtBtn.UseVisualStyleBackColor = true;
            this.crtBtn.Click += new System.EventHandler(this.crtBtn_Click);
            // 
            // formHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 259);
            this.Controls.Add(this.crtBtn);
            this.Controls.Add(this.prBar1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loadHtml);
            this.Controls.Add(this.rtnBtn);
            this.Name = "formHtml";
            this.Text = "LayoutHTML";
            this.Load += new System.EventHandler(this.formHtml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rtnBtn;
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