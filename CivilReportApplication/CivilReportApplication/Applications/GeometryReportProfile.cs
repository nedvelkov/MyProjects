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
    public partial class GeometryReportProfile : Form
    {
        public List<ProfileGeometryDto> ProfileGeometry { get; set; }

        public GeometryReportProfile()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.ProfileGeometry = new List<ProfileGeometryDto>();
            AddReportInfo();
            this.Hide();
            using (ProfleReport form = new ProfleReport())
            {
                form.ProfileGeometry = this.ProfileGeometry;
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RichTextBox.Clear();
        }

        private void GeometryReportProfile_Load(object sender, EventArgs e)
        {

        }


        private void AddReportInfo()
        {
            try
            {
            var allLines = this.RichTextBox.Lines.Length;
            for (int i = 1; i < allLines; i++)
            {
                    var currentRow = this.RichTextBox.Lines[i].Split('\t');
                    var profileInfo = new ProfileGeometryDto
                    {
                        No = currentRow[0].Trim(),
                        PVI_Station = currentRow[1],
                        PVI_Elevation = currentRow[2],
                        Grade_In = currentRow[3],
                        Grade_Out = currentRow[4],
                        Grade_Change = currentRow[5],
                        Profile_Curve_Type = currentRow[6],
                        Sub_Entity_Type = currentRow[7],
                        Profile_Curve_Length = currentRow[8],
                        K_Value = currentRow[9],
                        Curve_Radius = currentRow[10],
                        Asymmetric_Length_1 = currentRow[11],
                        Asymmetric_Length_2 = currentRow[12],
                        Lock = currentRow[13]
                    };
                    this.ProfileGeometry.Add(profileInfo);
            }

            }
            catch (Exception)
            {
                MessageBox.Show("Enter valid profile geometry");
                return;
            }
        }

    }
}
