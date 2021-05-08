﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formHtml layoutHTML = new formHtml();
            layoutHTML.ShowDialog();
        }
    }
}
