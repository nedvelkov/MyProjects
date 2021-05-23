
namespace CivilReportApplication
{
    partial class CodesInCrossSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodesInCrossSection));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pointFromCrossSectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.exportDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elevationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.offsetDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eastingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.northingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.slopeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointFromCrossSectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.exportDataGridViewCheckBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sideDataGridViewTextBoxColumn,
            this.elevationDataGridViewCheckBoxColumn,
            this.offsetDataGridViewCheckBoxColumn,
            this.eastingDataGridViewCheckBoxColumn,
            this.northingDataGridViewCheckBoxColumn,
            this.slopeDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.pointFromCrossSectionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(15, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pointFromCrossSectionBindingSource
            // 
            this.pointFromCrossSectionBindingSource.DataSource = typeof(CivilReportApplication.DtoImportModels.PointFromCrossSection);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(425, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(390, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(15, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(390, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add code";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exportDataGridViewCheckBoxColumn
            // 
            this.exportDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.exportDataGridViewCheckBoxColumn.DataPropertyName = "Export";
            this.exportDataGridViewCheckBoxColumn.HeaderText = "Export";
            this.exportDataGridViewCheckBoxColumn.Name = "exportDataGridViewCheckBoxColumn";
            this.exportDataGridViewCheckBoxColumn.Width = 43;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.Width = 57;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // sideDataGridViewTextBoxColumn
            // 
            this.sideDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sideDataGridViewTextBoxColumn.DataPropertyName = "Side";
            this.sideDataGridViewTextBoxColumn.HeaderText = "Side";
            this.sideDataGridViewTextBoxColumn.Name = "sideDataGridViewTextBoxColumn";
            this.sideDataGridViewTextBoxColumn.ReadOnly = true;
            this.sideDataGridViewTextBoxColumn.Width = 53;
            // 
            // elevationDataGridViewCheckBoxColumn
            // 
            this.elevationDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.elevationDataGridViewCheckBoxColumn.DataPropertyName = "Elevation";
            this.elevationDataGridViewCheckBoxColumn.HeaderText = "Elevation";
            this.elevationDataGridViewCheckBoxColumn.Name = "elevationDataGridViewCheckBoxColumn";
            this.elevationDataGridViewCheckBoxColumn.Width = 57;
            // 
            // offsetDataGridViewCheckBoxColumn
            // 
            this.offsetDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.offsetDataGridViewCheckBoxColumn.DataPropertyName = "Offset";
            this.offsetDataGridViewCheckBoxColumn.HeaderText = "Offset";
            this.offsetDataGridViewCheckBoxColumn.Name = "offsetDataGridViewCheckBoxColumn";
            this.offsetDataGridViewCheckBoxColumn.Width = 41;
            // 
            // eastingDataGridViewCheckBoxColumn
            // 
            this.eastingDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.eastingDataGridViewCheckBoxColumn.DataPropertyName = "Easting";
            this.eastingDataGridViewCheckBoxColumn.HeaderText = "Easting";
            this.eastingDataGridViewCheckBoxColumn.Name = "eastingDataGridViewCheckBoxColumn";
            this.eastingDataGridViewCheckBoxColumn.Width = 48;
            // 
            // northingDataGridViewCheckBoxColumn
            // 
            this.northingDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.northingDataGridViewCheckBoxColumn.DataPropertyName = "Northing";
            this.northingDataGridViewCheckBoxColumn.HeaderText = "Northing";
            this.northingDataGridViewCheckBoxColumn.Name = "northingDataGridViewCheckBoxColumn";
            this.northingDataGridViewCheckBoxColumn.Width = 53;
            // 
            // slopeDataGridViewCheckBoxColumn
            // 
            this.slopeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.slopeDataGridViewCheckBoxColumn.DataPropertyName = "Slope";
            this.slopeDataGridViewCheckBoxColumn.HeaderText = "Slope";
            this.slopeDataGridViewCheckBoxColumn.Name = "slopeDataGridViewCheckBoxColumn";
            this.slopeDataGridViewCheckBoxColumn.Width = 40;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 311);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(840, 350);
            this.Name = "Form2";
            this.Text = "Cross section codes";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointFromCrossSectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pointFromCrossSectionBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn exportDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn elevationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn offsetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eastingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn northingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn slopeDataGridViewCheckBoxColumn;
    }
}