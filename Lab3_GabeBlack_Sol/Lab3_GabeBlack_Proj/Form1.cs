﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_GabeBlack_Proj
{
	public partial class frmMain : Form
	{
		frmCalc frm;

		public frmMain()
		{
			InitializeComponent();

			frm = new frmCalc();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{

		}

		private void btnCalculator_Click(object sender, EventArgs e)
		{
			this.AddOwnedForm(frm);
			frm.ShowDialog();
		}

		private void txtResultsBox_TextChanged(object sender, EventArgs e)
		{

		}

		public void SetOutput(string output)
		{
			txtResultsBox.Text += output;
		}
	}
}
