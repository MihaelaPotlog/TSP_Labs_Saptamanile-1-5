using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string CurrentOperator { get; set; }
        private double FirstTypedNumber { get; set; }

        private delegate double OperatorCalculation(double firstOperand, double secondOperand);
        private Dictionary<string, OperatorCalculation> OperatorsCalculationList { get; set; }

        public Form1()
        {
            InitializeComponent();
            OperatorsCalculationList = new Dictionary<string, OperatorCalculation>()
            {
                {"+", (firstNumber, secondNumber) => firstNumber + secondNumber},
                {"-", (firstNumber, secondNumber) => firstNumber - secondNumber},
                {"/", (firstNumber, secondNumber) => firstNumber / secondNumber},
                {"*", (firstNumber, secondNumber) => firstNumber * secondNumber}
            };

        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            this.InputBox.Text = "0";
            this.ResultLabel.Text = "Result";
            CurrentOperator = null;
            
        }

        private void CipherPoint_Button_Click(object sender, EventArgs e)
        {

            string pressedKeyCipher = ((Button) sender).Tag.ToString();
            
            HandleCipher(pressedKeyCipher, e);

        }

        private void HandleCipher(string pressedKeyCipher, EventArgs e)
        {
            if (this.InputBox.Text != "0")
                this.InputBox.Text = this.InputBox.Text.Insert(this.InputBox.Text.Length, pressedKeyCipher);
            else
            {
                if (pressedKeyCipher != "0")
                    this.InputBox.Text = pressedKeyCipher;
            }
        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            if(this.InputBox.Text[0] == '-')
                this.InputBox.Text = this.InputBox.Text.Substring(1);
            else
                this.InputBox.Text = this.InputBox.Text.Insert(0, "-");
        }

       

        private void Operator_Click(object sender, EventArgs e)
        {
            string number = this.InputBox.Text;
            FirstTypedNumber = double.Parse(number, System.Globalization.CultureInfo.InvariantCulture);

            this.InputBox.Text = "0";
            CurrentOperator = ((Button) sender).Tag.ToString();

        }

       

        private void EqualButton_Click(object sender, EventArgs e)
        {
            string number = this.InputBox.Text;
            this.InputBox.Text = "0";
            double secondTypedNumber = double.Parse(number, System.Globalization.CultureInfo.InvariantCulture);

            this.ResultLabel.Text = OperatorsCalculationList[CurrentOperator](FirstTypedNumber, secondTypedNumber).ToString();
        }

        


        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pressedKeyChar = e.KeyChar.ToString();
            if(Regex.IsMatch(pressedKeyChar, "[^0-9.]"))
                e.Handled = true;

            
            
            
        }
    }
}
