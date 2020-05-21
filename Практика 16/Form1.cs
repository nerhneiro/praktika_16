using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        int i = 0;
        string text1 = "";
        private int convert_to_ten (TextBox textBox1, TextBox textBox2) 
        {
            int n, ten = 0, k = 0;
            n = Convert.ToInt32(textBox1.Text);
            n = (int)Math.Abs(n);
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (n % 10 == 1) ten += (int)Math.Pow(2, k);
                k++;
                n = n / 10;
            }
            if (int.Parse(textBox1.Text) < 0) ten *= -1;
            return ten;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            string eight = "", ei;
            text1 = textBox1.Text;
            int ten = 0;
            try
            {
                if (radioButton2.Checked == true)
                {
                        for (int i = 0; i < textBox1.Text.Length; i++)
                        {
                            if (textBox1.Text[i] != '0' && textBox1.Text[i] != '1' && textBox1.Text[i] != '-') { throw new Exception(": Вы ввели не двоичное число"); }
                        }
                        ten = convert_to_ten(textBox1, textBox2);
                        textBox2.Text = "Число " + textBox1.Text + " в десятичном виде = " + ten;
                    
                }
                if (radioButton1.Checked == true)
                {
                    n = (int)Math.Abs(int.Parse(textBox1.Text));
                    while (n > 0)
                    {
                        ten = ten * 10 + n % 8;
                        n = n / 8;
                    }
                    n = 0;
                    for(int i = 0; i < textBox1.Text.Length ; i++)
                    {
                        if(ten != 0) n = n*10 + ten % 10;
                        ten = ten / 10;
                    }
                    if (int.Parse(textBox1.Text) < 0) n *= -1;
                    textBox2.Text = "Число " + textBox1.Text + " в 8 системе счисления = " + n;
                }
                if(radioButton3.Checked == true)
                {
                    n = (int)Math.Abs(convert_to_ten(textBox1, textBox2));
                    
                    while (n > 0)
                    {
                        if (n % 16 == 10) ei = "A";
                        else if (n % 16 == 11) ei = "B";
                        else if (n % 16 == 12) ei = "C";
                        else if (n % 16 == 13) ei = "D";
                        else if (n % 16 == 14) ei = "E";
                        else if (n % 16 == 15) ei = "F";
                        else ei = (n % 16).ToString();
                        eight += ei;
                        n = n / 16;
                    }
                    
                    ei = "";
                    for(int i = eight.Length - 1; i >= 0; i--)
                    {
                        ei += eight[i];
                    }
                    if (int.Parse(textBox1.Text) < 0) ei= "-" + ei;
                    textBox2.Text = "Число " + textBox1.Text + " в 16 системе счисления = " + ei;
                }
            }
            catch (Exception err)
            {
                textBox2.Text = "Неправильный формат ввода " + err.Message;
            }
            i = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (text1 != textBox1.Text) { textBox2.Text = ""; text1 = textBox1.Text; }
        }
    }   
}
