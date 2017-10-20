using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.IO;
using System.Runtime.InteropServices;
using MediaPlayer;

namespace Programmuzyczny
{
    public partial class Form1 : Form
    {

        WindowsMediaPlayer mjuzik = new WindowsMediaPlayer();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value != 4000)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
            }


        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        mjuzik.URL = openFileDialog1.FileName.ToString();
                        mjuzik.URL = openFileDialog1.FileName;
                        label1.Text = "Current track - " + Path.GetFileName(mjuzik.URL).ToString();

                        mjuzik.controls.play();
                        timer1.Enabled = true;

                        timer1.Start();
                        timer1.Interval = 50;
                        progressBar1.Maximum = 4000;
                        timer1.Tick += new EventHandler(timer1_Tick);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else
                try
                {
                    mjuzik.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mjuzik.controls.currentPosition -= 10;
            mjuzik.controls.previous();
        }



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            mjuzik.controls.currentPosition += 10;
            mjuzik.controls.next();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mjuzik.controls.pause();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            mjuzik.controls.stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNama.SelectedIndex = lbNama.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbNama.Items.Add(openFileDialog1.SafeFileName);
            lbSumber.Items.Add(openFileDialog1.URL);
        }

        private void lbNama_DoubleClick(object sender, EventArgs e)
        {
            mjuzik.URL= lbSumber.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbSumber.Items.Remove(lbSumber.SelectedItem);
            lbNama.Items.Remove(lbNama.SelectedItem);
        }
        
    }
}
