using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class LogovanjeForma : Form
    {
        public LogovanjeForma()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LogovanjeForma_Load(object sender, EventArgs e)
        {
            textBoxUnosKorisnickogImena.MaxLength = 12;
            textBoxUnosLozinke.PasswordChar = '*';
            textBoxUnosLozinke.MaxLength = 12;
        }

        private void buttonPrijaviSeLogovanjeForma_Click(object sender, EventArgs e)
        {
            string username = textBoxUnosKorisnickogImena.Text;
            string pass = textBoxUnosLozinke.Text;

            textBoxUnosKorisnickogImena.Text = "";
            textBoxUnosLozinke.Text = "";

            if (username.Equals("1122") && pass.Equals("1122"))
            {
                this.Hide();
                GlavnaForma gf = new GlavnaForma();
                gf.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Netacno korisnicko ime ili netacna lozinka!");
        }
    }
}
