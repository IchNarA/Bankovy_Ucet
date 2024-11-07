using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankovyUcetF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Banka banka = new Banka();

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = banka.GetPeniaze().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox2.Text) && !textBox2.Text.StartsWith("0")) 
            {
                int suma = int.Parse(textBox2.Text);
                banka.Vklad(suma);
                textBox1.Text = banka.GetPeniaze().ToString();
                listView1.View = View.Details;
                listView1.Items.Add("+ " + suma.ToString());
            }
            else
            {
                MessageBox.Show("Textbox je prazdny alebo sa snazis vlozit 0", "Chyba",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text) && !textBox2.Text.StartsWith("0"))
            {
                int suma = int.Parse(textBox2.Text);
                int vysledok = banka.Vyber(suma);
                if (vysledok== -1)
                {
                    MessageBox.Show("Nedostatok penazi", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    textBox1.Text = banka.GetPeniaze().ToString();
                    listView1.View = View.Details;
                    listView1.Items.Add("- " + suma.ToString());
                }     
            }
            else
            {
                MessageBox.Show("Textbox je prazdny alebo sa snazis vybrat 0", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
