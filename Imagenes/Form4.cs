using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imagenes
{
    public partial class Form4 : Form
    {
        Image IMG1;
        public void D180_Flip_None()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image = IMG1;
        }
        //-----------------------------------------------------------
        public void D180_Flip_X()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Image = IMG1;
        }
        //-------------------------------------------------------------
        public void D180_Flip_XY()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate180FlipXY);
            pictureBox1.Image = IMG1;
        }
        //---------------------------------------------------------------
        public void D180_Flip_Y()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = IMG1;
        }
        //-----------------------------------------------------------------
        public void D270_Flip_None()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = IMG1;
        }
        //----------------------------------------------------------------
        public void D270_Flip_X()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate270FlipX);
            pictureBox1.Image = IMG1;
        }
        //--------------------------------------------------------------------
        public void D270_Flip_XY()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate270FlipXY);
            pictureBox1.Image = IMG1;
        }
        //---------------------------------------------------------------------
        public void D270_Flip_Y()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate270FlipY);
            pictureBox1.Image = IMG1;
        }
        //-----------------------------------------------------------------------
        public void D90_Flip_None()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = IMG1;
        }
        //-------------------------------------------------------------------------
        public void D90_Flip_X()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate90FlipX);
            pictureBox1.Image = IMG1;
        }
        //--------------------------------------------------------------------------
        public void D90_Flip_XY()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = IMG1;
        }
        //--------------------------------------------------------------------------
        public void D90_Flip_Y()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.Rotate90FlipY);
            pictureBox1.Image = IMG1;
        }
        //----------------------------------------------------------------------------
        public void None_Flip_None()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            pictureBox1.Image = IMG1;
        }
        //---------------------------------------------------------------------------
        public void None_Flip_X()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = IMG1;
        }
        //---------------------------------------------------------------------------
        public void None_Flip_XY()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            pictureBox1.Image = IMG1;
        }
        //----------------------------------------------------------------------------
        public void None_Flip_Y()
        {
            IMG1 = pictureBox1.Image;
            IMG1.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = IMG1;
        }
        public Form4()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    D180_Flip_None();
                    break;
                case 1:
                    D180_Flip_X();
                    break;
                case 2:
                    D180_Flip_XY();
                    break;
                case 3:
                    D180_Flip_Y();
                    break;
                case 4:
                    D270_Flip_None();
                    break;
                case 5:
                    D270_Flip_X();
                    break;
                case 6:
                    D270_Flip_XY();
                    break;
                case 7:
                    D270_Flip_Y();
                    break;
                case 8:
                    D90_Flip_None();
                    break;
                case 9:
                    D90_Flip_X();
                    break;
                case 10:
                    D90_Flip_XY();
                    break;
                case 11:
                    D90_Flip_Y();
                    break;
                case 12:
                    None_Flip_None();
                    break;
                case 13:
                    None_Flip_X();
                    break;
                case 14:
                    None_Flip_XY();
                    break;
                case 15:
                    None_Flip_Y();
                    break;
            }
        }

        string ingame;
        void cargar()
        {
            this.openFileDialog1.ShowDialog();
            ingame = openFileDialog1.FileName;
            pictureBox1.Load(ingame);

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cargar();
        }

        int inicial_width = 365;
        int inicial_heigh = 471;
        int zoo_maswidth=10;
        int zoom_masheig = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Width = inicial_width+zoo_maswidth;
            inicial_width = pictureBox1.Width;
            pictureBox1.Height =inicial_heigh+zoom_masheig;
            inicial_heigh = pictureBox1.Height;
        }
    }
}
