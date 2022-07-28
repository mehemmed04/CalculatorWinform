using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string Operation = string.Empty;
        bool isOperationPerfomed = false;
        bool isDarkMode = true;
        public Form1()
        {
            InitializeComponent();
            blacklinePbx.BackColor = Color.FromArgb(30, 32, 42);
            foreach (var button in ButtonsGrpBx.Controls)
            {
                if (button is Button btn)
                {
                    btn.ForeColor = Color.FromArgb(210, 76, 75);
                    btn.BackColor = Color.FromArgb(30, 32, 42);
                }
            }

        }


        private void button_click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (resultLbl.Text == "0" || isOperationPerfomed)
                {
                    resultLbl.Text = "";
                }
                isOperationPerfomed = false;
                if (btn.Text == ",")
                {
                    if (!resultLbl.Text.Contains(","))
                    {
                        resultLbl.Text += btn.Text;
                    }
                    if (resultLbl.Text.Length == 1)
                    {
                        resultLbl.Text = resultLbl.Text.Insert(0, "0");
                    }
                }
                else resultLbl.Text += btn.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            if (!isOperationPerfomed)
            {
                if (sender is Button btn)
                {
                    if (resultValue != 0)
                    {
                        equalsBtn.PerformClick();
                        Operation = btn.Text;
                        CurrentOperationLbl.Text = resultValue + " " + Operation;
                        isOperationPerfomed = true;
                    }
                    else
                    {
                        Operation = btn.Text;
                        resultValue = Double.Parse(resultLbl.Text);
                        CurrentOperationLbl.Text = resultValue + " " + Operation;
                        isOperationPerfomed = true;
                    }
                }
            }

        }

        private void CBtn_Click(object sender, EventArgs e)
        {
            resultLbl.Text = "0";
            resultValue = 0;
        }

        private void CEbtn_Click(object sender, EventArgs e)
        {
            resultLbl.Text = "0";
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            double number = Double.Parse(resultLbl.Text);
            switch (Operation)
            {
                case "+":
                    resultLbl.Text = (resultValue + number).ToString();
                    break;
                case "-":
                    resultLbl.Text = (resultValue - number).ToString();
                    break;
                case "/":
                    resultLbl.Text = (resultValue / number).ToString();
                    break;
                case "X":
                    resultLbl.Text = (resultValue * number).ToString();
                    break;
                case "%":
                    resultLbl.Text = (resultValue % number).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(resultLbl.Text);
            Operation = "";
            CurrentOperationLbl.Text = "";
        }


        private void darkmodePbx_Click(object sender, EventArgs e)
        {
            if (isDarkMode) isDarkMode = false;
            else
            {
                isDarkMode = true;
            }
            if (isDarkMode)
            {
                groupBox1.BackgroundImage = Properties.Resources.BACKGROUND;

                this.BackColor = Color.FromArgb(210, 76, 75);
                blacklinePbx.BackColor = Color.FromArgb(30, 32, 42);

                foreach (var button in ButtonsGrpBx.Controls)
                {
                    if (button is Button btn)
                    {
                        btn.ForeColor = Color.FromArgb(210, 76, 75);
                        btn.BackColor = Color.FromArgb(30, 32, 42);
                    }
                }
            }
            else
            {
                groupBox1.BackgroundImage = Properties.Resources.white;
                blacklinePbx.BackColor = Color.FromArgb(30, 32, 42);

                foreach (var button in ButtonsGrpBx.Controls)
                {
                    if (button is Button btn)
                    {
                        btn.ForeColor = Color.FromArgb(30, 32, 42);
                        btn.BackColor = Color.White;
                    }
                }
            }
        }

  

        private void button_enter(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                btn.BackColor = Color.Silver;
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (isDarkMode) btn.BackColor = Color.FromArgb(30, 32, 42);
                else btn.BackColor = Color.White;
            }
        }
    }
}
