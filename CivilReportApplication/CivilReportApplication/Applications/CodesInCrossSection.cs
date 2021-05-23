using CivilReportApplication.DtoImportModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilReportApplication
{
    public partial class CodesInCrossSection : Form
    {
        public List<PointFromCrossSection> codes;
        public CodesInCrossSection()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AddCodesToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using(AddCodeToCrossSection form3=new AddCodeToCrossSection())
            {
                
                form3.listCodes = this.codes.Select(x => x.Code).ToArray();
                form3.ShowDialog();
                var pointName = form3.insertBefore;
                int indexPoint;
                if (form3.point != null)
                {
                if (form3.point.Side == "Right")
                {
                    indexPoint = this.codes.FindLastIndex(x => x.Code == pointName);
                }
                else indexPoint = this.codes.FindIndex(x => x.Code == pointName);
                if (indexPoint==-1)
                {
                    this.codes.Add(form3.point);
                }
                else
                {
                    this.codes.Insert(indexPoint, form3.point);
                }
                
                pointFromCrossSectionBindingSource.Clear();
                AddCodesToGrid();
                }
            }
            this.Show();
        }


        private void AddCodesToGrid()
        {
            foreach (var item in this.codes)
            {

                pointFromCrossSectionBindingSource.Add(item);
            }
        }
    }
}
