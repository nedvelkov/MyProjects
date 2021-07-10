namespace CivilReportApplication
{

    using System;
    using System.Windows.Forms;

    using CivilReportApplication.DtoImportModels;

    public partial class AddCodeToCrossSection : Form
    {
        public string[] listCodes;
        public string insertBefore;
        public PointFromCrossSection point;
        public AddCodeToCrossSection()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != index)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);

            this.insertBefore = checkedListBox1.SelectedItem.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.checkedListBox1.Items.AddRange(this.listCodes);
            this.checkedListBox1.Items.Add("at end");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.point = new PointFromCrossSection();
            point.Export = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter point code");
                return;
            }
            point.Code = textBox1.Text;
            point.Name = textBox2.Text;
            try
            {
                AddSide(point);
            }
            catch (Exception)
            {

                MessageBox.Show("Select side");
                return;
            }
            var selectedItems = checkedListBox2.CheckedItems;

            foreach (var item in selectedItems)
            {
                var prop = item.ToString();
                point.GetType().GetProperty(prop).SetValue(point, true);
            }

            try
            {
                InsertBefore();
            }
            catch (Exception)
            {

                MessageBox.Show("Chose position for point");
                return;
            }

            this.Hide();

        }

        private void AddSide(PointFromCrossSection point)
        {
            if (radioButton1.Checked)
            {
                point.Side = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                point.Side = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                point.Side = radioButton3.Text;
            }
            else
            {
                throw new Exception();
            }
        }

        private void InsertBefore()
        {
            var tmp = checkedListBox1.CheckedItems;
            this.insertBefore = tmp[0].ToString();
        }
    }
}
