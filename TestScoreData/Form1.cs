using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScoreData
{
    public partial class Form1 : Form
    {
        int[] arr = new int[20];
        int total = 0;
        int count = 0;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddScores_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    int score = Convert.ToInt32(txtScore.Text);
                    arr[i] = score;

                    total = total + arr[i];
                    count += 1;
                    int average = total / count;
                    txtScoreTotal.Text = total.ToString();
                    txtScoreCount.Text = count.ToString();
                    txtAverage.Text = average.ToString();
                    i++;
                    txtScore.Focus();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }
        public bool IsValidData()
        {
            return
            // Validate the Score text box
            IsPresent(txtScore, "Score") &&
            IsInt32(txtScore, "Score") &&
            IsWithinRange(txtScore, "Score", 01, 100);
        }
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                return false;
            }
            else
                return true;
        }
        public bool IsInt32(TextBox textBox, string name)
        {
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                return true;
            }
            else
                return false;


        }
        public bool IsWithinRange(TextBox textBox, string name,
        decimal min, decimal max)
        {
            if (Convert.ToInt32(textBox.Text) > max || Convert.ToInt32(textBox.Text) < min)
            {
                return false;
            }
            else
                return true;

        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            txtScore.Text = "";
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";
            txtScore.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDisplayScores_Click(object sender, EventArgs e)
        {
            Array.Resize(ref arr, i);
            string toDisplay = string.Join(Environment.NewLine, arr);
            MessageBox.Show(toDisplay);
        }
    }
}
