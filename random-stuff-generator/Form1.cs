using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Random_stuff_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void pin_generator(TextBox tb)
        {
            Random r = new Random();
            int num1 = r.Next(0, 10);
            int num2 = r.Next(0, 10);
            int num3 = r.Next(0, 10);
            int num4 = r.Next(0, 10);
            bool safe = false;

            while (!safe)
            {
                if (num1 == num2)
                {
                    num1 = r.Next(0, 10);
                    num2 = r.Next(0, 10);
                }
                if (num2 == num3)
                {
                    num2 = r.Next(0, 10);
                    num3 = r.Next(0, 10);
                }
                if (num3 == num4)
                {
                    num3 = r.Next(0, 10);
                    num4 = r.Next(0, 10);
                }
                if (num1 == num3)
                {
                    num1 = r.Next(0, 10);
                    num3 = r.Next(0, 10);
                }
                if (num2 == num4)
                {
                    num2 = r.Next(0, 10);
                    num4 = r.Next(0, 10);
                }
                if (num1 == num4)
                {
                    num1 = r.Next(0, 10);
                    num4 = r.Next(0, 10);
                }
                if (num1 * num2 == num3 * 10 + num4)
                {
                    num3 = r.Next(0, 10);
                    num4 = r.Next(0, 10);
                }
                else
                {
                    if (num1 != num2 && num2 != num3 && num3 != num4 && num1 != num3 && num2 != num4)
                    {
                        safe = true;
                        tb.Text = $"{num1}{num2}{num3}{num4}";
                    }

                }
            }
        }
        void rng(TextBox txtResult, TextBox txt1, TextBox txt2, Label labelError)
        {
            Random random = new Random();
            int from, to;
            if (int.TryParse(txt1.Text, out _) && int.TryParse(txt2.Text, out _)) {
                labelError.Text = " ";
                from = Convert.ToInt32(txt1.Text);
                to = Convert.ToInt32(txt2.Text);
                if (from < to)
                {
                    txtResult.Text = random.Next(from, to+1).ToString();
                }
                else if(from == to)
                {
                    labelError.Text = "Both values cannot be equal.";
                }
                else if (from > to)
                {
                    labelError.Text = "'From' value cannot be greater than 'To'.";
                }
            }
            else if (!int.TryParse(txt1.Text, out _) && int.TryParse(txt2.Text, out _))
            {
                labelError.Text = "'From' box is empty. Please enter the value";
            }
            else if (int.TryParse(txt1.Text, out _) && !int.TryParse(txt2.Text, out _))
            {

                labelError.Text = "'To' box is empty. Please enter the value";
            }
            else if (!int.TryParse(txt1.Text, out _) && !int.TryParse(txt2.Text, out _))
            {
                labelError.Text = "Both boxes are empty please enter values";
            }
        }
        void pwd_generator(TextBox txtNum, TextBox txtPwd, Label labelError, ComboBox comboBox1)
        {
            if (int.TryParse(txtNum.Text, out _))
            {
                labelError.Text = "    ";
                int length = Int32.Parse(txtNum.Text);
                if (length >= 5 && length <= 50)
                {
                    if (string.IsNullOrEmpty(comboBox1.Text))
                    {
                        labelError.Text = "Please pick password difficulty.";
                    }
                    if (comboBox1.SelectedIndex == 0)
                    {
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                        var r = new Random();
                        txtPwd.Text = new string(Enumerable.Repeat(chars, length)
                                                                .Select(s => s[r.Next(s.Length)]).ToArray()).ToLower();

                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                        var random = new Random();
                        txtPwd.Text = new string(Enumerable.Repeat(chars, length)
                                                                .Select(s => s[random.Next(s.Length)]).ToArray());
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        string passowrd = "";
                        Random r = new Random();
                        for (int i = 0; i < length; i++)
                        {
                            passowrd += r.Next(0, 10).ToString();
                        }
                        txtPwd.Text = passowrd;
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                        var r = new Random();
                        txtPwd.Text = new string(Enumerable.Repeat(chars, length)
                                                                .Select(s => s[r.Next(s.Length)]).ToArray());
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&*-+=';:?/>.<,|";

                        var r = new Random();
                        txtPwd.Text = new string(Enumerable.Repeat(chars, length)
                                                                .Select(s => s[r.Next(s.Length)]).ToArray());
                    }
                }
                else if (length < 5)
                {
                    labelError.Text = "Password would be unsafe. Enter bigger value.";
                }
                else if (length > 50)
                {
                    labelError.Text = "Password is too long. Enter smaller value.";
                }

            }
            else
            {
                labelError.Text = "Please only input numbers.";
            }
        }
        void flip_a_coin(TextBox textBox1)
        {
            Random r = new Random();
            var i = r.Next(0, 2);
            if (i == 0) textBox1.Text = "No";
            else textBox1.Text = "Yes";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Controls.Clear();
                groupBox1.Text = "Press \"Generate\" to generate random number in range";

                Label labelFrom = new Label();
                labelFrom.Location = new Point(15, 20);
                labelFrom.Text = "From";

                Label labelTo = new Label();
                labelTo.Location = new Point(180, 20);
                labelTo.Text = "To";

                Label labelError = new Label();
                labelError.Location = new Point(100, 80);

                TextBox txt1 = new TextBox();
                txt1.Location = new Point(15, 50);
                txt1.Size = new Size(100, 22);

                TextBox txt2 = new TextBox();
                txt2.Location = new Point(180, 50);
                txt2.Size = new Size(100, 22);

                TextBox textResult = new TextBox();
                textResult.Location = new Point(15, 120);
                textResult.Size = new Size(100, 22);
                textResult.ReadOnly = true;

                Button button1 = new Button();
                button1.Location = new Point(15, 80);
                button1.Size = new Size(75, 25);
                button1.Text = "Generat";
                button1.Click += delegate (object sender2, System.EventArgs eventArgs)
                {
                    rng(textResult, txt1, txt2, labelError);
                };
                groupBox1.Controls.Add(labelFrom);
                groupBox1.Controls.Add(labelTo);
                groupBox1.Controls.Add(labelError);
                groupBox1.Controls.Add(txt1);
                groupBox1.Controls.Add(txt2);
                groupBox1.Controls.Add(textResult);
                groupBox1.Controls.Add(button1);

            }
            else if(comboBox1.SelectedIndex == 1)
            {
                List<string> listChoices = new List<string> { "Random letters (lower)", "Random letters (upper and lower)", 
                    "Random numbers", "Random letters and numbers", "Random letters, numbers and symbols" };

                groupBox1.Controls.Clear();
                groupBox1.Text = "Press \"Generate\" to generate password";

                Label labelLength = new Label();
                labelLength.Location = new Point(15, 20);
                labelLength.Text = "Enter desired password length(5-50 characters)";
                labelLength.Size = new Size(318, 17);

                Label labelDifficulty = new Label();
                labelDifficulty.Location = new Point(15, 80);
                labelDifficulty.Text = "Choose difficulty(characters will always be random)";
                labelDifficulty.Size = new Size(328, 17);

                Label labelGenerated = new Label();
                labelGenerated.Location = new Point(15, 175);
                labelGenerated.Text = "Generated password";
                labelGenerated.Size = new Size(140, 17);

                Label labelError = new Label();
                labelError.Location = new Point(70, 52);
                labelError.Text = "";
                labelError.Size = new Size(328, 17);

                TextBox txtNum = new TextBox();
                txtNum.Location = new Point(15, 50);
                txtNum.Size = new Size(40, 22);

                TextBox txtPwd = new TextBox();
                txtPwd.ReadOnly = true;
                txtPwd.Location = new Point(15, 200);
                txtPwd.Size = new Size(318, 22);

                ComboBox comboBox1 = new ComboBox();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Location = new Point(15, 105);
                comboBox1.Size = new Size(210, 24);
                foreach(string item in listChoices)
                {
                    comboBox1.Items.Add(item);
                }

                Button button1 = new Button();
                button1.Location = new Point(15, 140);
                button1.Size = new Size(75, 25);
                button1.Text = "Generat";
                button1.Click += delegate (object sender2, System.EventArgs eventArgs)
                {
                    pwd_generator(txtNum, txtPwd, labelError, comboBox1);
                };

                groupBox1.Controls.Add(labelLength);
                groupBox1.Controls.Add(labelDifficulty);
                groupBox1.Controls.Add(labelError);
                groupBox1.Controls.Add(labelGenerated);
                groupBox1.Controls.Add(txtNum);
                groupBox1.Controls.Add(txtPwd);
                groupBox1.Controls.Add(comboBox1);   //doesn't add this combobox
                groupBox1.Controls.Add(button1);    //doesn't fit in groupbox

            }
            else if(comboBox1.SelectedIndex == 2)
            {
                groupBox1.Controls.Clear();
                groupBox1.Text = "Press \"Generate\" to generate PIN";

                TextBox textBox1 = new TextBox();
                textBox1.Location = new Point(7,20);
                textBox1.Size = new Size(100, 22);
                textBox1.ReadOnly = true;

                Button button1 = new Button();
                button1.Location = new Point(7, 50);
                button1.Size = new Size(75, 25);
                button1.Text = "Generat";
                button1.Click += delegate (object sender2, System.EventArgs eventArgs)
                {
                    pin_generator(textBox1);
                };

                groupBox1.Controls.Add(textBox1);
                groupBox1.Controls.Add(button1);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Controls.Clear();
                groupBox1.Text = "Press \"Generate\" to decide yes/no for something";

                Label labelAka = new Label();
                labelAka.Location = new Point(15, 20);
                labelAka.Size = new Size(122, 17);
                labelAka.Text = "A.k.a. \"Flip a coin\"";

                Label labelPress = new Label();
                labelPress.Location = new Point(15, 50);
                labelPress.Size = new Size(198, 17);
                labelPress.Text = "Press the button to randomize";

                TextBox textBox1 = new TextBox();
                textBox1.Location = new Point(15, 120);
                textBox1.Size = new Size(100, 22);
                textBox1.ReadOnly = true;

                Button button1 = new Button();
                button1.Location = new Point(15, 80);
                button1.Size = new Size(75, 23);
                button1.Text = "Generat";
                button1.Click += delegate (object sender2, System.EventArgs eventArgs)
                {
                    flip_a_coin(textBox1);
                };
                groupBox1.Controls.Add(labelAka);
                groupBox1.Controls.Add(labelPress);
                groupBox1.Controls.Add(textBox1);
                groupBox1.Controls.Add(button1);

            }
        }
    }
}