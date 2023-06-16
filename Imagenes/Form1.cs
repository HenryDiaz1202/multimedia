using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Fondos;

namespace Imagenes
{
    public partial class Form1 : Form
    {
        int posX = 0;
        int posY = 0;
        int zoom=0;
        
        int d = 0;
        Image IMG1;
        List<string> list = new List<string>();
        List<int> lista = new List<int>();
        Boolean mov;
        int MX, MY;
        Form2 for2 = new Form2();

        List<string> colores = new List<string> { "Gris","Negro","Blanco","Azul", "Defecto" };
        List<string> tamanio = new List<string> { "Center","Zoom","Stretch"};

        //####################################################################################
        public void D180_Flip_None()
        {
            IMG1 = (Image)Image.FromFile(list[d]);
            IMG1.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image = IMG1;
        }
        public void D270_Flip_None()
        {
            IMG1 = (Image)Image.FromFile(list[d]);
            IMG1.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = IMG1;
        }
        public void D90_Flip_None()
        {
            IMG1 = (Image)Image.FromFile(list[d]);
            IMG1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = IMG1;
        }
        public void None_Flip_None()
        {
            IMG1 = (Image)Image.FromFile(list[d]);
            IMG1.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            pictureBox1.Image = IMG1;
        }

        //#######################################################################################

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
           if(e.Delta > 0)
           {
               pictureBox1.Width = pictureBox1.Width + 50;
               pictureBox1.Height = pictureBox1.Height + 50;
           }
           else
           {
               pictureBox1.Width = pictureBox1.Width - 50;
               pictureBox1.Height = pictureBox1.Height - 50;
           }
        }
        public Form1(Form2 instancia)
        {
            for2 = instancia;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
                //MessageBox.Show("En el form2, tratar de hacer que pase los archivos encontrados\ny no los seleccionados, podria facilitar\ny hacer que cuando de click sobre el picturebox1 enviarlo al form1","Mensaje importante",MessageBoxButtons.OK,MessageBoxIcon.Information);
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox4.Text = comboBox4.Items[0].ToString();
            
            pictureBox1.Image = Properties.Resources.document_06_128;
            domainUpDown1.Focus();//numericUpDown1.
            pictureBox1.AllowDrop= true;

            button6.Visible = false;
            button7.Visible = false;
            comboBox2.Enabled = false;
            button2.Enabled = false;

            button7.BackColor = Color.Transparent;
            button7.Parent = pictureBox1;

            button6.BackColor = Color.Transparent;
            button6.Parent = pictureBox1;

            button13.BackColor = Color.Transparent;
            button13.Parent = pictureBox1;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            domainUpDown1.Items.Clear();            
            list.Clear();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Jpg image(*.jpg)|*.jpg|" + "Jpeg image(*.jpeg)|*.jpeg|" + "Bmp image(*.bmp)|*.bmp|" + "Png image(*.png)|*.png|" +
                "Gif image(*.gif)|*.gif|" + "Emf image(*.emf)|*.emf|" + "Exif image(*.exif)|*.exif|" + "Icon image(*.ico)|*.ico|" +
                "Wmf image(*.wmf)|*.wmf|" + "Tiff image(*.tiff)|*.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] info = openFileDialog1.FileNames;
                foreach (string s in info)
                {
                    domainUpDown1.Items.Add(Path.GetFullPath(s));
                    list.Add(s);
                    for2.lista.Add(s);
                }
            }
            if(this.openFileDialog1.FileName != string.Empty)
            {
                for2.listBox1.Items.Clear();
                domainUpDown1.Focus();
                if (list.Count != 0)
                {
                    domainUpDown1.SelectedItem = list[0].ToString();
                    pictureBox1.Image = Image.FromFile(list[0].ToString());
                    comboBox4.Text = comboBox4.Items[1].ToString();
                   // original = pictureBox1.Image;

                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = list.Count().ToString();
                    comboBox1.Enabled = true;
                    button9.Enabled = true;
                    button2.Enabled = true;

                    button6.Visible = true;
                    button7.Visible = true;

                    textBox2.Maximum = list.Count-1;
                }
                else
                {
                    comboBox1.Enabled = false ;
                    button9.Enabled = false;
                    button6.Visible = false;
                    button7.Visible = false;
                }
                if(domainUpDown1.Items.Count==1)
                {
                    //label2.SendToBack();
                    label2.Text = domainUpDown1.Items.Count.ToString() + " Elemento";

                }
                else if(domainUpDown1.Items.Count>1)

                    for (int lista = 0; lista < list.Count; lista++)
                    {
                        for2.listBox1.Items.Add(list[lista].ToString());
                    }
                //label2.SendToBack();
                label2.Text = domainUpDown1.Items.Count.ToString() + " Elementos";
            }
            else
            {}
            if(label2.Text=="1 Elemento")
            {
                /*button6.Visible = false;
                button7.Visible = false;*/
                comboBox2.Enabled = false;
            }
            else
            {
               /* button6.Visible = true;
                button7.Visible = true;*/
                comboBox2.Enabled = true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender,AsyncCompletedEventArgs e)
        {
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zoom++;
            pictureBox1.Height += zoom;
            pictureBox1.Width += zoom;
        }

        private void button3_Click(object sender, EventArgs e)
        {      
            if(zoom!=0)
            {
                zoom--;
                pictureBox1.Height -= zoom;
                pictureBox1.Width -= zoom;
            }
            else { }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        D180_Flip_None();
                        break;
                    case 1:
                        D270_Flip_None();
                        break;
                    case 2:
                        D90_Flip_None();
                        break;
                    case 3:
                        None_Flip_None();
                        break;
                }
            }
            else { }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(textBox1.Text);
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            textBox1.Text = domainUpDown1.SelectedItem.ToString();
            label4.Text = domainUpDown1.SelectedItem.ToString();
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            if(this.textBox1.Text != string.Empty)
            {
                DialogResult ver;
                domainUpDown1.Focus();
                FondoPantallaClase.EstablecerFondo(this.textBox1.Text);
                ver=MessageBox.Show("Fondo de pantalla cambiado correctamente \n Ver escritorio", "***", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(ver==DialogResult.Yes)
                WindowState = FormWindowState.Minimized;
                else { }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún archivo");
            }
        }
        int pos;
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {

            }
            else
            {            
                pos = int.Parse(textBox2.Text);
                if (pos < list.Count)
                {
                    //textBox1.Text = list[pos].ToString();
                    domainUpDown1.SelectedItem = list[pos].ToString();
                    d = pos;
                    domainUpDown1.Focus();
                    label8.Text = textBox2.Text + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }             
                else
                {
                    domainUpDown1.Focus();
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //this.pictureBox1.SizeMode = this.checkBox1.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Zoom;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                if (d == list.Count - 1)
                {
                    d = 0;
                    domainUpDown1.SelectedItem = list[0].ToString();
                    domainUpDown1.Focus();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
                else
                {
                    d = d + 1;
                    domainUpDown1.SelectedItem = list[d].ToString();
                    domainUpDown1.Focus();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
            }
            else { }
           
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                if (d <= 0)
                {
                    d = list.Count - 1;
                    domainUpDown1.SelectedItem = list[d].ToString();
                    domainUpDown1.Focus();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
                else
                {
                    d = d - 1;
                    domainUpDown1.SelectedItem = list[d].ToString();
                    domainUpDown1.Focus();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
            }
            else { }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MX = e.Location.X;
            MY = e.Location.Y;
            mov = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                if (d == list.Count - 1)
                {
                    d = 0;
                    domainUpDown1.SelectedItem = list[0].ToString();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
                else
                {
                    d = d + 1;                   
                    domainUpDown1.SelectedItem = list[d].ToString();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
            }
        }
        private void button7_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                if (d <= 0)
                {
                    d = list.Count - 1;
                    domainUpDown1.SelectedItem = list[d].ToString();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
                else
                {
                    d = d - 1;
                    domainUpDown1.SelectedItem = list[d].ToString();
                    label8.Text = d.ToString() + "/" + list.Count().ToString();
                    label9.Text = d.ToString();
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            domainUpDown1.Focus();
        }
        int rep = 0;
        private void domainUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            rep++;
            if (rep == 1)
            {
                if (e.KeyCode == Keys.F7)
                {
                    if (list.Count != 0)
                    {
                        domainUpDown1.Focus();
                        timer1.Start();
                    }
                    else { }
                }
            }
            else
            {
                if (list.Count != 0)
                {
                    timer1.Stop();
                }
                else { }
                rep = 0;
            }
            
            if (list.Count != 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (d <= 0)
                    {
                        d = list.Count - 1;
                        domainUpDown1.SelectedItem = list[d].ToString();
                        label8.Text = d.ToString() + "/" + list.Count().ToString();
                        label9.Text = d.ToString();
                    }
                    else
                    {
                        d = d - 1;
                        domainUpDown1.SelectedItem = list[d].ToString();
                        label8.Text = d.ToString() + "/" + list.Count().ToString();
                        label9.Text = d.ToString();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (d == list.Count - 1)
                    {
                        d = 0;
                        domainUpDown1.SelectedItem = list[0].ToString();
                        label8.Text = d.ToString() + "/" + list.Count().ToString();
                        label9.Text = d.ToString();
                    }
                    else
                    {
                        d = d + 1;
                        domainUpDown1.SelectedItem = list[d].ToString();
                        label8.Text = d.ToString() + "/" + list.Count().ToString();
                        label9.Text = d.ToString();
                    }
                }
            }
            else { }
        }
        int contado = 0;
       
        Image xoom(Image img, Size tam)
        {
            Bitmap bmp = new Bitmap(img,img.Width+(img.Width * tam.Width/100),img.Height+(img.Height * tam.Height/100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            if(contado != list.Count-1)
            {
                contado = contado + 1;
                label9.Text = contado.ToString();
                pictureBox1.Image = Image.FromFile(list[contado].ToString());            
            }
            else
            {
                contado = 0;
                pictureBox1.Image = Image.FromFile(list[0].ToString());
                timer1.Stop();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="1 segundo")
            {
                timer1.Interval = 1000;
            }
            else if (comboBox2.Text == "2 segundos")
            {
                timer1.Interval = 2000;
            }
            else if (comboBox2.Text == "3 segundos")
            {
                timer1.Interval = 3000;
            }
            else if (comboBox2.Text == "4 segundos")
            {
                timer1.Interval = 4000;
            }
            else if (comboBox2.Text == "5 segundos")
            {
                timer1.Interval = 5000;
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Scroll;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var dato = e.Data.GetData(DataFormats.FileDrop);
            if (dato != null)
            {
                var nombrear = dato as string[];
                if(nombrear.Length>0)
                {
                    pictureBox1.Image = Image.FromFile(nombrear[0]);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                list.Clear();
                //domainUpDown1.Items.Clear();
                pictureBox1.Image = Properties.Resources.document_06_128;
                comboBox4.Text = comboBox4.Items[0].ToString();
                label4.Text = string.Empty;
                label2.Text = string.Empty;

                button6.Visible = false;
                button7.Visible = false;
                comboBox2.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
            }
            else { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
             for2.ShowDialog();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text=="Gris")
            {
                panel1.BackColor = Color.Gray;
                pictureBox1.BackColor = Color.Gray;
            }
            else  if (comboBox3.Text == "Negro")
            {
                panel1.BackColor = Color.Black;
                pictureBox1.BackColor = Color.Black;
            }
            else  if (comboBox3.Text == "Blanco")
            {
                panel1.BackColor = Color.White;
                pictureBox1.BackColor = Color.White;
            }
            else  if (comboBox3.Text == "Azul")
            {
                panel1.BackColor = Color.Blue;
                pictureBox1.BackColor = Color.DarkSlateGray;
            }
            else if (comboBox3.Text == "Defecto")
            {
                panel1.BackColor = this.BackColor;
                pictureBox1.BackColor = this.BackColor;
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox4.Text=="Stretch")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (comboBox4.Text == "Zoom")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (comboBox4.Text == "Center")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }          
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            for (int fe=0; fe < colores.Count;fe++)
            {
                comboBox3.Items.Add(""+colores[fe].ToString());
            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            for (int fe = 0; fe < tamanio.Count; fe++)
            {
                comboBox4.Items.Add("" + tamanio[fe].ToString());
            }
        }

        int casa = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();

            if (casa == list.Count - 1)
            {
                casa = 0;
                FondoPantallaClase.EstablecerFondo(this.list[casa].ToString());
            }
            else
            {
                casa = casa + 1;
                FondoPantallaClase.EstablecerFondo(this.list[casa].ToString());
            }
            }
        private void button10_Click_1(object sender, EventArgs e)
        {
            int comtim=0;
            FondoPantallaClase.EstablecerFondo(this.textBox1.Text);
            for (int tim = 0; tim <= 5000;tim++)
            {
                comtim = tim;               
            }
            if(comtim==5000)
            {
                timer2.Enabled = true;
            }
        }
        Form5 f5 = new Form5();
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            /*list.Clear();
            domainUpDown1.Items.Clear();
            f5.ShowDialog();*/
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {            
            for2.Show();
            //this.Hide();
        }

        
        private void button12_Click(object sender, EventArgs e)
        {
            int pos = int.Parse(label9.Text);
            list.RemoveAt(pos);
            /*  DialogResult respon;
            int p = int.Parse(label9.Text);*/
            string ruta = label4.Text;
           /* respon = MessageBox.Show("El archivo se borrara permanente.", "***", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(respon==DialogResult.OK)
            {
                //File.Delete(ruta);*/
                f5.dataGridView1.Rows.Add(label9.Text,ruta.ToString());
          /*  }*/
               
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {   
            if (list.Count != 0)
            {
                timer1.Stop();
            }
            else { }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {   
            if (list.Count != 0)
            {
                domainUpDown1.Focus();
                timer1.Start();
            }
            else { }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                timer1.Stop();
                contado = 0;
                pictureBox1.Image = Image.FromFile(list[contado]);
            }
            else { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
         /*   if(trackBar1.Value > 0)
            {
                pictureBox16.Image = xoom(pictureBox16.Image, new Size(trackBar1.Value, trackBar1.Value));
            }*///
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult delt;
            delt = MessageBox.Show("El archivo se eliminarà permanente, de acuerdo?", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (delt == DialogResult.Yes)
            {
                /*list.Remove(label4.Text);
                lista.Remove(int.Parse(label9.Text));
                string dl = "C:/Users/HenryDiaz/Desktop/app_design.png";
                File.Delete(dl);*/
                MessageBox.Show("Eliminado correctamente");
            }
            else { }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
           
        }
        int full = 0;

        private void button13_Click(object sender, EventArgs e)
        {
            full++;
                if (full == 1)
                {
                    panel1.Dock = DockStyle.Fill;
                    panel1.BringToFront();
                    button13.BackColor = Color.Purple;

                    if (list.Count > 1)
                    {
                        label10.Visible = true;
                        timer3.Enabled = true;
                    }
                    else { }
                }
                if (full == 2)
                {
                    panel1.Dock = DockStyle.None;
                    panel1.Width = 1234;
                    panel1.Height = 733;
                    panel1.Location = new Point(90, 28);
                    panel1.Anchor = AnchorStyles.Bottom;
                    panel1.Anchor = AnchorStyles.Left;
                    panel1.Anchor = AnchorStyles.Right;
                    panel1.Anchor = AnchorStyles.Top;
                    button13.BackColor = Color.Transparent;
                    full = 0;
                }
        }
        int apear = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            apear++;
            if (apear == 3)
            {
                label10.Visible =false;
                apear = 0;
                timer3.Stop();
            }            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
         if (e.KeyCode == Keys.Enter)
         {
             if (textBox2.Text == string.Empty)
             {

             }
             else
             {
                 pos = int.Parse(textBox2.Text);
                 if (pos < list.Count)
                 {
                     //textBox1.Text = list[pos].ToString();
                     domainUpDown1.SelectedItem = list[pos].ToString();
                     d = pos;
                     domainUpDown1.Focus();
                     label8.Text = textBox2.Text + "/" + list.Count().ToString();
                     label9.Text = d.ToString();
                 }
                 else
                 {
                     domainUpDown1.Focus();
                 }
             }
         }
         else { }    
        }
/*
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox16.Image = pictureBox1.Image;
        }
        /*
         crear numeros random
         * int num;
         *  Random rand = new Random();
         *   num = rand.Next(0, list.Count - 1);*/
    }
}
