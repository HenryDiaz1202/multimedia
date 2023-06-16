using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Imagenes
{
    public partial class Form2 : Form
    {
        int a = 1;
        int d = 0;
        public List<string> lista = new List<string>();
        int posX = 0;
        int posY = 0;
        Form3 for3 = new Form3();

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form3 insta)
        {
            for3 = insta;
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            for (int t = 0; t <= lista.Count - 1; t++)
            {
                AddNewPictureBox();          
            }
        }

        int i=0;
        int x = 0;
        int y = 15;
        public System.Windows.Forms.PictureBox AddNewPictureBox()
        {
            System.Windows.Forms.PictureBox pct = new System.Windows.Forms.PictureBox();
            this.Controls.Add(pct);
            pct.Width = 95;
            pct.Height = 109;           
            foreach (string pc in lista)
            {
                pct.Top = a * 10;
                pct.Left = 10;
                pct.Location = new Point(x=x+25,y);
            }           
                pct.SizeMode = PictureBoxSizeMode.StretchImage;
                pct.Image = Image.FromFile(lista[i++].ToString());
                a = a + 1;        return pct;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            this.Hide();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            listBox2.SelectedItems.Clear();
            pictureBox1.Image = Image.FromFile(listBox1.SelectedItem.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                listBox1.Width = 470;
                listBox1.Height = 498;
                listBox2.Width = 470;
                listBox2.Height = 498;
                pictureBox1.Visible = true;
            }
            else
            {
                listBox1.Width=709;
                listBox1.Height = 498;
                listBox2.Width = 709;
                listBox2.Height = 498;
                pictureBox1.Visible = false;


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(listBox1.SelectedItem.ToString());
            listBox2.SelectedItems.Clear();
            pictureBox1.Image = Image.FromFile(listBox1.SelectedItem.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Width = 709;
            listBox1.Height = 498;
            listBox2.Width = 709;
            listBox2.Height = 498;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void listBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(listBox2.SelectedItem.ToString());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

                //listBox2.Items.Clear();
                listBox1.SelectedItems.Clear();

                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(listBox2.SelectedItem.ToString());
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            for3.Show();
            for3.pictureBox3.Image = pictureBox1.Image;
           
        }
    }
}
