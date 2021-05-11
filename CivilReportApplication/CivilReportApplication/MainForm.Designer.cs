
namespace CivilReportApplication
{
    partial class MainForm
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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(635, 12);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(153, 49);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Layout file from XML";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(635, 83);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(153, 44);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Layout file from HTML";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(635, 363);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(153, 45);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create alignment report for print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(464, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 44);
            this.button3.TabIndex = 5;
            this.button3.Text = "Create profile report for print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

