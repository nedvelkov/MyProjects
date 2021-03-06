namespace CivilReportApplication
{

    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (LayoutXml form2 = new LayoutXml())
            {
                form2.ShowDialog();

            }
            this.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AlignmentReport form3 = new AlignmentReport())
            {
                form3.ShowDialog();

            }
            this.Show();

        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            string reportType;

            using (SelectHtmlForm form = new SelectHtmlForm())
            {

                form.ShowDialog();
                reportType = form.ReportType;
            }
            switch (reportType)
            {
                case "Layout":
                    using (formHtml layoutHTML = new formHtml())
                    {

                        layoutHTML.ShowDialog();
                    }
                    break;
                case "Coridor":
                    using (CoridorHtml form = new CoridorHtml())
                    {
                        form.ShowDialog();

                    }
                    break;
                default:
                    break;
            }
            this.Show();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (GeometryReportProfile form = new GeometryReportProfile())
            {
                form.ShowDialog();
            }

            this.Show();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SurfaceProfileReport form = new SurfaceProfileReport())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (CrossSectionReport form = new CrossSectionReport())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form1 form = new Form1())
            {
                form.ShowDialog();
            }
            this.Show();
        }
    }
}
