namespace CivilReportApplication
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using CivilReportApplication.DtoImportModels;

    public partial class SelectRange3DPolyline : Form
    {
        public List<ImportDataTab8> points;
        public SelectRange3DPolyline(List<string[]> tab8, List<string[]> tab5)
        {
            InitializeComponent();
            ;
            try
            {

                GetPoints(tab8, tab5);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.points.Count > 0)
            {

                radioButton3.Checked = true;
                textBox2.Text = points.Last().PointNumber;
                textBox1.Text = points.First().PointNumber;

                label3.Text = $"First point {points.First().PointNumber}";
                label4.Text = $"Last point {points.Last().PointNumber}";

                textBox4.Text = points.Last().Station.ToString();
                textBox3.Text = points.First().Station.ToString();

                label7.Text = $"Start alignment {points.First().Station.ToString()}";
                label8.Text = $"End alignment {points.Last().Station.ToString()}";

            }
            else this.Close();

            ;
        }

        private void GetPoints(List<string[]> tab8, List<string[]> tab5)
        {
            this.points = new List<ImportDataTab8>();
            int diff = 0;
            for (int i = 0; i < tab8.Count; i++)
            {
                var statonTab8 = double.Parse(tab8[i][1]);
                var statonTab5 = double.Parse(tab5[i + diff][1]);
                if (statonTab8 != statonTab5)
                {
                    while (true)
                    {
                        diff++;
                        statonTab5 = double.Parse(tab5[i + diff][1]);
                        if (statonTab8 == statonTab5) break;
                    }
                }
                ImportDataTab8 point = new ImportDataTab8();
                point.Station = statonTab5;
                point.PointNumber = tab5[i][2];
                points.Add(point);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (ChekTextBoxValue(textBox1, "point", "first")) return;
                if (ChekTextBoxValue(textBox2, "point", "last")) return;
                if (ChekRange(textBox1, textBox2, "point")) return;

                var startPoint = this.points.First(x => x.PointNumber == textBox1.Text);
                var endPoint = this.points.First(x => x.PointNumber == textBox2.Text);
                var startIndex = this.points.IndexOf(startPoint);
                var endIndex = this.points.IndexOf(endPoint) + 1;
                this.points = this.points.Skip(startIndex).Take(endIndex - startIndex).ToList();

            }
            else if (radioButton2.Checked)
            {
                if (ChekTextBoxValue(textBox3, "station", "first")) return;
                if (ChekTextBoxValue(textBox4, "station", "last")) return;
                if (ChekRange(textBox3, textBox4, "station")) return;


                var startPoint = this.points.First(x => x.Station >= double.Parse(textBox3.Text));
                var endPoint = this.points.First(x => x.Station <= double.Parse(textBox4.Text));
                var startIndex = this.points.IndexOf(startPoint);
                var endIndex = this.points.IndexOf(endPoint) + 1;
                this.points = this.points.Skip(startIndex).Take(endIndex - startIndex).ToList();
            }

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private bool ChekTextBoxValue(TextBox box, string type, string postion)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, @"^\-?[0-9]*$") == false)
            {
                MessageBox.Show("Enter only numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                switch (type)
                {
                    case "point" when (postion == "first"):
                        box.Text = points.First().PointNumber;
                        break;
                    case "point" when (postion == "last"):
                        box.Text = points.Last().PointNumber;
                        break;
                    case "station" when (postion == "first"):
                        box.Text = points.First().Station.ToString();
                        break;
                    case "station" when (postion == "last"):
                        box.Text = points.Last().Station.ToString();
                        break;
                    default:
                        break;
                }
                return true;
            }
            return false;
        }

        private bool ChekRange(TextBox box1, TextBox box2, string type)
        {
            double startPoint = double.Parse(box1.Text);
            double endPoint = double.Parse(box2.Text);

            double firstPoint;
            double lastPoint;
            switch (type)
            {
                case "station":
                    firstPoint = points.First().Station;
                    lastPoint = points.Last().Station;
                    break;
                default:
                    firstPoint = double.Parse(points.First().PointNumber);
                    lastPoint = double.Parse(points.Last().PointNumber);
                    break;
            }

            if (startPoint > endPoint)
            {
                MessageBox.Show("Start point cannot be greater than end point", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                box1.Text = points.First().PointNumber;
                return true;
            }
            if (startPoint < firstPoint)
            {
                MessageBox.Show("Start point cannot be less than first point", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                box1.Text = points.First().PointNumber;
                return true;
            }
            if (lastPoint < endPoint)
            {
                MessageBox.Show("End point cannot be greater than last point", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                box2.Text = points.Last().PointNumber;
                return true;
            }
            return false;
        }


    }
}
