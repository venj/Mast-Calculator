using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using me.venj;
using System.Text.RegularExpressions;

namespace Mast_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            var db = new DataProcess();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumColumeComboBox.SelectedIndex = 0;
        }

        private bool isValidInputText(string text, bool isFloatNumber)
        {
            string pattern;
            if (isFloatNumber)
            {
                pattern = "^(\\s?\\s?\\d+(\\.\\d{0,3}){0,1}\\s?)?$"; // Negtive number is excluded.
            }
            else
            {
                pattern = "^(\\s?-?\\s?\\d+\\s?)?$";
            }
            Regex regex = new Regex(pattern);

            return regex.IsMatch(text);
        }

        private void InitialHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, true);
        }

        private void changeTextBox(TextBox textBox, bool isFloat)
        {
            string text = textBox.Text;
            text = text.Trim();
            textBox.Text = text;
            textBox.SelectionStart = textBox.Text.Length + 1;

            if (isValidInputText(text, isFloat))
            {
                textBox.BackColor = Color.White;
            }
            else
            {
                textBox.BackColor = Color.Red;
            }
        }

        private void TotalHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, true);
        }

        private void MaximumLoadTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, true);
        }

        private void HeightDeltaTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, false);
        }

        private void InitialHeightTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (double.Parse(textBox.Text) > 4.0)
            {
                textBox.BackColor = Color.Red;
                MessageBox.Show("Initial hight can not be larger than 4.0");

            }
        }
    }
}
