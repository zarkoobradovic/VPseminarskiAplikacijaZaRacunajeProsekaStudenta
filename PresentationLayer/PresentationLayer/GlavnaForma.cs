using BusinessLayer;
using DataLayer.Models;
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
    public partial class GlavnaForma : Form
    {
        private readonly PredmetBusiness predmetBusiness;

        public GlavnaForma()
        {
            this.predmetBusiness = new PredmetBusiness();
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonPrvaGodinaGlavnaForma_Click(object sender, EventArgs e)
        {
            PrvaGodinaForma pgf = new PrvaGodinaForma();
            pgf.ShowDialog();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            /*--------------Prva godina------------------------------------------*/
            Predmet p = new Predmet();
            p.Godina = 1;
            double srednjaVR = Math.Round(predmetBusiness.Prosek(p), 2);
            textBoxUkupanProsekPrveGodineGlavnaForma.Text = srednjaVR.ToString();
            /*---------------------------------------------------------------------*/
            /*--------------Druga godina------------------------------------------*/
            Predmet p2 = new Predmet();
            p2.Godina = 2;
            double srednjaVR2 = Math.Round(predmetBusiness.Prosek(p2), 2);
            textBoxUkupanProsekDrugeGodineGlavnaForma.Text = srednjaVR2.ToString();
            /*---------------------------------------------------------------------*/
            /*--------------Treca godina------------------------------------------*/
            Predmet p3 = new Predmet();
            p3.Godina = 3;
            double srednjaVR3 = Math.Round(predmetBusiness.Prosek(p3), 2);
            textBoxUkupanProsekTrecaGodinaGlavnaForma.Text = srednjaVR3.ToString();
            /*---------------------------------------------------------------------*/
            /*--------------Cetvrta godina------------------------------------------*/
            Predmet p4 = new Predmet();
            p4.Godina = 4;
            double srednjaVR4 = Math.Round(predmetBusiness.Prosek(p4), 2);
            textBoxUkupanProsekCetvrteGodineGlavnaForma.Text = srednjaVR4.ToString();
            /*---------------------------------------------------------------------*/

            double srednjaVRukupan = Math.Round(predmetBusiness.UkupanProsek(p), 2);
            textBoxUkupanProsekGlavnaForma.Text = srednjaVRukupan.ToString();
        }

        private void buttonDrugaGodinaGlavnaForma_Click(object sender, EventArgs e)
        {
            DrugaGodinaForma pgf2 = new DrugaGodinaForma();
            pgf2.ShowDialog();
        }

        private void buttonTrecaGodinaGlavnaForma_Click(object sender, EventArgs e)
        {
            TrecaGodinaForma pgf3 = new TrecaGodinaForma();
            pgf3.ShowDialog();
        }

        private void buttonCetvrtaGodinaGlavnaForma_Click(object sender, EventArgs e)
        {
            CetvrtaGodinaForma pgf4 = new CetvrtaGodinaForma();
            pgf4.ShowDialog();
        }
    }
}
