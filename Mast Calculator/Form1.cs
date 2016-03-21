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
        //--------------------------------
        //
        //       Form life cycle
        //
        //--------------------------------

        public Form1()
        {
            InitializeComponent();
            InitializeDataBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumColumeComboBox.SelectedIndex = 0;
        }

        //--------------------------------
        //
        //       Helper methods
        //
        //--------------------------------

        private void InitializeDataBase()
        {
            var db = new DataProcess();
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

        private void validateValueInTextBox(TextBox textBox, double preferedValue, string message)
        {
            var text = textBox.Text;
            if (text.Length == 0)
            {
                return;
            }
            if (double.Parse(text) > preferedValue)
            {
                textBox.BackColor = Color.Red;
                MessageBox.Show(message);
            }
        }
        
        //--------------------------------
        //
        //       Event Hanlders
        //
        //--------------------------------

        private void InitialHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, true);
        }
        
        private void TotalHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, true);
        }

        private void MaximumLoadTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, false);
        }

        private void HeightDeltaTextBox_TextChanged(object sender, EventArgs e)
        {
            changeTextBox((TextBox)sender, false);
        }

        private void InitialHeightTextBox_Leave(object sender, EventArgs e)
        {
            validateValueInTextBox((TextBox)sender, 4.0, "Initial hight can not be larger than 4.0");
        }

        private void TotalHeightTextBox_Leave(object sender, EventArgs e)
        {
            validateValueInTextBox((TextBox)sender, 30.0, "Total hight can not be larger than 30.0");
        }

        private void MaximumLoadTextBox_Leave(object sender, EventArgs e)
        {
            validateValueInTextBox((TextBox)sender, 300, "Total weight can not be larger than 300");
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (DefaultDataBaseRadioButton.Checked) // Revert back to default db.
            {
                ColumnData.Instance.resetDataFile();
            }
            //TODO: More...
            var initialHeight = (int)(double.Parse(InitialHeightTextBox.Text) * 1000);
            var totalHeight = (int)(double.Parse(TotalHeightTextBox.Text) * 1000);
            var maxLoad = int.Parse(InitialHeightTextBox.Text);

            // Validation
            var helper = ColumnHelper.Instance;
            helper.pistonType = DualRingRadioButton.Checked ? PistonType.Dule : PistonType.Single;
            //helper.ColumnsCount = 


        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "txt files (*.txt)|*.txt| csv files (*.csv)|*.csv)";
            openDialog.FilterIndex = 0;
            if (openDialog.ShowDialog() == DialogResult.OK) // Change to cutom db
            {
                var selectedFile = openDialog.FileName;
                DatabasePathTextBox.Text = selectedFile;
                ColumnData.Instance.resetDataFile(selectedFile);
                //TODO: Refresh UI or something else?
            }
        }

        private void dataBaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChooseButton.Enabled = ((RadioButton)sender == CustomDataBaseRadioButton);
        }
    }
}
