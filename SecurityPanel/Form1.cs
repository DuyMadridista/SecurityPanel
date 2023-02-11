using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SecurityPanel
{
    public partial class Form1 : Form
    {
        string pass = "1234";
        string path=@"E:\text.txt";
        public Form1()
        { 
            InitializeComponent();
            ShowLog();
        }
        private void getNumber(object o, EventArgs e)
        {   if(Screen.TextLength<4)
             Screen.Text+=((Button)o).Text;
            buttonOK.Focus();
        }
        private void getPressNumber(object o, KeyPressEventArgs e)
        {
            if (Screen.TextLength<6 && e.KeyChar>='0' && e.KeyChar<='9'  )
                Screen.Text+=e.KeyChar.ToString();
            if (e.KeyChar==Convert.ToChar(Keys.Enter)) EnterPress();
            if (e.KeyChar==Convert.ToChar(Keys.Back)) { Screen.Text=""; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            EnterPress();
        }
        private void EnterPress()
        {
            if (Screen.Text==pass)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime d = DateTime.Now;
                    sw.WriteLine(d+" Login success");
                    sw.Dispose();
                }
                MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime d = DateTime.Now;
                    sw.WriteLine(d+" Login fail");
                    sw.Dispose();
                }
                MessageBox.Show("Đăng nhập thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowLog();
            Screen.Text="";
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Screen.Text="";
        }
        private void ShowLog()
        {
            listBox1.Items.Clear();
            string [] lines=File.ReadAllLines(path);
            foreach (string line in lines)
            {
                listBox1.Items.Add(line);
            }
        }
    }
}
