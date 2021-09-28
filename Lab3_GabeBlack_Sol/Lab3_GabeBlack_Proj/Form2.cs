using System;
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
	public partial class frmCalc : Form
	{
		double wage, hoursWorked;
		string cstmWageString, fullName, hwString;
		string output;

		public frmCalc()
		{
			InitializeComponent();
		}

		private void lblFullName_Click(object sender, EventArgs e)
		{

		}

		private void txtFullName_TextChanged(object sender, EventArgs e)
		{
			fullName = txtFullName.Text;
		}

		private void frmCalc_Load(object sender, EventArgs e)
		{

		}

		private void txtNSWInput_TextChanged(object sender, EventArgs e)
		{
			cstmWageString = txtNSWInput.Text;
		}

		public void btnRunCalcs_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtFullName.Text) || isNum(txtFullName.Text))
			{
				MessageBox.Show(
					"Please only put letters in the name",
					"ERROR IN NAME INPUT",
					MessageBoxButtons.OK
					);
			}
			else if (!cbCheck())
			{
				MessageBox.Show(
					"Please select a wage",
					"Error in wage",
					MessageBoxButtons.OK
					);
			}
			else if ((String.IsNullOrEmpty(txtNSWInput.Text) || !isNum(txtNSWInput.Text)) 
					&& rbWageCustom.Checked)
			{
				MessageBox.Show(
					"Please input a number for the custom wage",
					"ERROR IN NON STANDARD WAGE INPUT",
					MessageBoxButtons.OK
					);
			}
			else if (String.IsNullOrEmpty(txtHWInput.Text) || !isNum(txtHWInput.Text))
			{
				MessageBox.Show(
					"Please input a number",
					"ERROR IN HOURS WORKED INPUT",
					MessageBoxButtons.OK
					);
			}
			else
			{
				if(rbWageCustom.Checked)
				{
					wage = Convert.ToDouble(cstmWageString);
				}

				hoursWorked = Convert.ToDouble(hwString);

				double grossWages = hoursWorked * wage;

				double taxes = grossWages * .15;

				double netWages = grossWages - taxes;

				output = String.Format("\n Name: " + fullName +
									   "\n Hours Worked: " + hoursWorked +
									   "\n Wage rate: " + wage +
									   "\n Gross wages: {0:#.00}" +
									   "\n Taxes: {1:#.00}" +
									   "\n Net wages: {2:#.00} \n",
									   grossWages,
									   taxes,
									   netWages
									   );

				frmMain parent = (frmMain)this.Owner;
				parent.SetOutput(output);

			}
		}

		private void rbWage1_CheckedChanged(object sender, EventArgs e)
		{
			wage = 8.75;
		}

		private void rbWage2_CheckedChanged(object sender, EventArgs e)
		{
			wage = 9.33;
		}

		private void rbWage3_CheckedChanged(object sender, EventArgs e)
		{
			wage = 10.00;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			wage = 11.20;
		}

		private void rbWageCustom_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void btnSuspend_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void txtHWInput_TextChanged(object sender, EventArgs e)
		{
			hwString = txtHWInput.Text;
		}

		public static bool isNum(string input)
		{
			char[] ascii = new char[input.Length];
			bool isNum = false;

			for(int i = 0; i < input.Length; i++)
			{
				ascii[i] += input.ElementAt(i);
			}

			for(int x = 0; x < ascii.Length; x++)
			{
				if(ascii[x] < 48 || ascii[x] > 57)
				{
					isNum = false;
				}
				else
				{
					isNum = true;
				}
			}

			return isNum;
		}

		public bool cbCheck()
		{
			bool areChecked;

			if (!rbWage1.Checked && !rbWage2.Checked && !rbWage3.Checked && 
				!rbWage4.Checked && !rbWageCustom.Checked)
			{
				areChecked = false;
			}
			else
			{
				areChecked = true;
			}

			return areChecked;
		}
	}
}
