
namespace CivilReportApplication
{
    partial class ProfleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfleReport));
            this.reportBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pVIStationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pVIElevationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeChangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileCurveTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subEntityTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileCurveLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curveRadiusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asymmetricLength1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asymmetricLength2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileGeometryDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileGeometryDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportBtn
            // 
            this.reportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportBtn.Location = new System.Drawing.Point(12, 376);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(1403, 30);
            this.reportBtn.TabIndex = 2;
            this.reportBtn.Text = "Create report";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(175, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1240, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alignment name";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(175, 218);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1240, 20);
            this.textBox2.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(176, 249);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1240, 101);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Project info";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Add header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(176, 357);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(75, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Add footer";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 423);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1400, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.pVIStationDataGridViewTextBoxColumn,
            this.pVIElevationDataGridViewTextBoxColumn,
            this.gradeInDataGridViewTextBoxColumn,
            this.gradeOutDataGridViewTextBoxColumn,
            this.gradeChangeDataGridViewTextBoxColumn,
            this.profileCurveTypeDataGridViewTextBoxColumn,
            this.subEntityTypeDataGridViewTextBoxColumn,
            this.profileCurveLengthDataGridViewTextBoxColumn,
            this.kValueDataGridViewTextBoxColumn,
            this.curveRadiusDataGridViewTextBoxColumn,
            this.asymmetricLength1DataGridViewTextBoxColumn,
            this.asymmetricLength2DataGridViewTextBoxColumn,
            this.lockDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.profileGeometryDtoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1400, 174);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.Width = 35;
            // 
            // pVIStationDataGridViewTextBoxColumn
            // 
            this.pVIStationDataGridViewTextBoxColumn.DataPropertyName = "PVI_Station";
            this.pVIStationDataGridViewTextBoxColumn.HeaderText = "PVI_Station";
            this.pVIStationDataGridViewTextBoxColumn.Name = "pVIStationDataGridViewTextBoxColumn";
            // 
            // pVIElevationDataGridViewTextBoxColumn
            // 
            this.pVIElevationDataGridViewTextBoxColumn.DataPropertyName = "PVI_Elevation";
            this.pVIElevationDataGridViewTextBoxColumn.HeaderText = "PVI_Elevation";
            this.pVIElevationDataGridViewTextBoxColumn.Name = "pVIElevationDataGridViewTextBoxColumn";
            // 
            // gradeInDataGridViewTextBoxColumn
            // 
            this.gradeInDataGridViewTextBoxColumn.DataPropertyName = "Grade_In";
            this.gradeInDataGridViewTextBoxColumn.HeaderText = "Grade_In";
            this.gradeInDataGridViewTextBoxColumn.Name = "gradeInDataGridViewTextBoxColumn";
            // 
            // gradeOutDataGridViewTextBoxColumn
            // 
            this.gradeOutDataGridViewTextBoxColumn.DataPropertyName = "Grade_Out";
            this.gradeOutDataGridViewTextBoxColumn.HeaderText = "Grade_Out";
            this.gradeOutDataGridViewTextBoxColumn.Name = "gradeOutDataGridViewTextBoxColumn";
            // 
            // gradeChangeDataGridViewTextBoxColumn
            // 
            this.gradeChangeDataGridViewTextBoxColumn.DataPropertyName = "Grade_Change";
            this.gradeChangeDataGridViewTextBoxColumn.HeaderText = "Grade_Change";
            this.gradeChangeDataGridViewTextBoxColumn.Name = "gradeChangeDataGridViewTextBoxColumn";
            // 
            // profileCurveTypeDataGridViewTextBoxColumn
            // 
            this.profileCurveTypeDataGridViewTextBoxColumn.DataPropertyName = "Profile_Curve_Type";
            this.profileCurveTypeDataGridViewTextBoxColumn.HeaderText = "Profile_Curve_Type";
            this.profileCurveTypeDataGridViewTextBoxColumn.Name = "profileCurveTypeDataGridViewTextBoxColumn";
            // 
            // subEntityTypeDataGridViewTextBoxColumn
            // 
            this.subEntityTypeDataGridViewTextBoxColumn.DataPropertyName = "Sub_Entity_Type";
            this.subEntityTypeDataGridViewTextBoxColumn.HeaderText = "Sub_Entity_Type";
            this.subEntityTypeDataGridViewTextBoxColumn.Name = "subEntityTypeDataGridViewTextBoxColumn";
            // 
            // profileCurveLengthDataGridViewTextBoxColumn
            // 
            this.profileCurveLengthDataGridViewTextBoxColumn.DataPropertyName = "Profile_Curve_Length";
            this.profileCurveLengthDataGridViewTextBoxColumn.HeaderText = "Profile_Curve_Length";
            this.profileCurveLengthDataGridViewTextBoxColumn.Name = "profileCurveLengthDataGridViewTextBoxColumn";
            // 
            // kValueDataGridViewTextBoxColumn
            // 
            this.kValueDataGridViewTextBoxColumn.DataPropertyName = "K_Value";
            this.kValueDataGridViewTextBoxColumn.HeaderText = "K_Value";
            this.kValueDataGridViewTextBoxColumn.Name = "kValueDataGridViewTextBoxColumn";
            // 
            // curveRadiusDataGridViewTextBoxColumn
            // 
            this.curveRadiusDataGridViewTextBoxColumn.DataPropertyName = "Curve_Radius";
            this.curveRadiusDataGridViewTextBoxColumn.HeaderText = "Curve_Radius";
            this.curveRadiusDataGridViewTextBoxColumn.Name = "curveRadiusDataGridViewTextBoxColumn";
            // 
            // asymmetricLength1DataGridViewTextBoxColumn
            // 
            this.asymmetricLength1DataGridViewTextBoxColumn.DataPropertyName = "Asymmetric_Length_1";
            this.asymmetricLength1DataGridViewTextBoxColumn.HeaderText = "Asymmetric_Length_1";
            this.asymmetricLength1DataGridViewTextBoxColumn.Name = "asymmetricLength1DataGridViewTextBoxColumn";
            // 
            // asymmetricLength2DataGridViewTextBoxColumn
            // 
            this.asymmetricLength2DataGridViewTextBoxColumn.DataPropertyName = "Asymmetric_Length_2";
            this.asymmetricLength2DataGridViewTextBoxColumn.HeaderText = "Asymmetric_Length_2";
            this.asymmetricLength2DataGridViewTextBoxColumn.Name = "asymmetricLength2DataGridViewTextBoxColumn";
            // 
            // lockDataGridViewTextBoxColumn
            // 
            this.lockDataGridViewTextBoxColumn.DataPropertyName = "Lock";
            this.lockDataGridViewTextBoxColumn.HeaderText = "Lock";
            this.lockDataGridViewTextBoxColumn.Name = "lockDataGridViewTextBoxColumn";
            // 
            // profileGeometryDtoBindingSource
            // 
            this.profileGeometryDtoBindingSource.DataSource = typeof(CivilReportApplication.DtoImportModels.ProfileGeometryDto);
            // 
            // ProfleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1450, 500);
            this.MinimumSize = new System.Drawing.Size(1450, 500);
            this.Name = "ProfleReport";
            this.Text = "Profile report";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileGeometryDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVIStationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVIElevationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeChangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileCurveTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subEntityTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileCurveLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curveRadiusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asymmetricLength1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asymmetricLength2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lockDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource profileGeometryDtoBindingSource;
    }
}