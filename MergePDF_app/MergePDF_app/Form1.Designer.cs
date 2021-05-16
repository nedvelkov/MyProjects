
namespace MergePDF_app
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Merge = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.savePathBtn = new System.Windows.Forms.Button();
            this.nameCombinePdf = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(34, 25);
            this.input.Name = "input";
            this.input.ShortcutsEnabled = false;
            this.input.Size = new System.Drawing.Size(181, 20);
            this.input.TabIndex = 0;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(34, 63);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(181, 20);
            this.output.TabIndex = 1;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Merge
            // 
            this.Merge.Location = new System.Drawing.Point(34, 125);
            this.Merge.Name = "Merge";
            this.Merge.Size = new System.Drawing.Size(370, 32);
            this.Merge.TabIndex = 5;
            this.Merge.Text = "Merge PDF files";
            this.Merge.UseVisualStyleBackColor = true;
            this.Merge.Click += new System.EventHandler(this.Merge_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // savePathBtn
            // 
            this.savePathBtn.Location = new System.Drawing.Point(255, 55);
            this.savePathBtn.Name = "savePathBtn";
            this.savePathBtn.Size = new System.Drawing.Size(149, 34);
            this.savePathBtn.TabIndex = 11;
            this.savePathBtn.Text = "Save location combine PDF";
            this.savePathBtn.UseVisualStyleBackColor = true;
            this.savePathBtn.Click += new System.EventHandler(this.savePathBtn_Click);
            // 
            // nameCombinePdf
            // 
            this.nameCombinePdf.AutoSize = true;
            this.nameCombinePdf.Location = new System.Drawing.Point(252, 102);
            this.nameCombinePdf.Name = "nameCombinePdf";
            this.nameCombinePdf.Size = new System.Drawing.Size(117, 13);
            this.nameCombinePdf.TabIndex = 12;
            this.nameCombinePdf.Text = "Name for combine PDF";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(370, 32);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Tag = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.BackColor = System.Drawing.Color.Transparent;
            this.progress.Location = new System.Drawing.Point(186, 274);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(0, 13);
            this.progress.TabIndex = 14;
            this.progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.nameCombinePdf);
            this.Controls.Add(this.savePathBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Merge);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 250);
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "Form1";
            this.Text = "Merge PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Merge;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button savePathBtn;
        private System.Windows.Forms.Label nameCombinePdf;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label progress;
    }
}

