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
    public partial class PrvaGodinaForma : Form
    {
        private readonly PredmetBusiness predmetBusiness;

        public PrvaGodinaForma()
        {
            this.predmetBusiness = new PredmetBusiness();
            InitializeComponent();
            CenterToScreen();
        }

        private void RefreshData()
        {
            List<Predmet> predmets = this.predmetBusiness.GetAllPredmet();
            dataGridViewPrvaGodinaForma.Rows.Clear();
            for (int i = 0; i < predmets.Count; ++i)
            {
                if(predmets[i].Godina==1)
                dataGridViewPrvaGodinaForma.Rows.Add(predmets[i].Id,predmets[i].NazivPredmeta, predmets[i].Ocena, predmets[i].Godina);
            }
            dataGridViewPrvaGodinaForma.Columns[0].Visible = false;

            Predmet p = new Predmet();
            p.Godina = 1;
            double srednjaVR = Math.Round(predmetBusiness.Prosek(p),2) ;
            textBoxUkupanProsekPrvaGodinaForma.Text = srednjaVR.ToString();
        }

        private void buttonDodajtePredmetPrvaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            p.NazivPredmeta = textBoxUnosNazivaPredmetaPrvaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOcenePrvaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodinePrvaGodinaForma.Text);

            if (this.predmetBusiness.InsertPredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaPrvaGodinaForma.Text = "";
                textBoxUnosOcenePrvaGodinaForma.Text = "";
                textBoxUnosGodinePrvaGodinaForma.Text = "";
                MessageBox.Show("Dodavanje uspesno izvrseno!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void PrvaGodinaForma_Load(object sender, EventArgs e)
        {
            RefreshData();
            
        }

        //omogucava da klikom na podatke u dtgv se pojave u text boxovima radi izmene
        private void dataGridViewPrvaGodinaForma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dataGridViewPrvaGodinaForma.SelectedRows[0].Index;

                textBoxUnosNazivaPredmetaPrvaGodinaForma.Text = dataGridViewPrvaGodinaForma[1, row].Value.ToString();

                textBoxUnosOcenePrvaGodinaForma.Text = dataGridViewPrvaGodinaForma[2, row].Value.ToString();
                textBoxUnosGodinePrvaGodinaForma.Text = dataGridViewPrvaGodinaForma[3, row].Value.ToString();
                
            }
            catch { MessageBox.Show("Ceo red mora biti selektovan!"); }
            
        }

        private void buttonIzmenitePredmetPrvaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            int row = dataGridViewPrvaGodinaForma.SelectedRows[0].Index;
            p.Id = int.Parse(dataGridViewPrvaGodinaForma[0, row].Value.ToString());
            p.NazivPredmeta = textBoxUnosNazivaPredmetaPrvaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOcenePrvaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodinePrvaGodinaForma.Text);

            if (this.predmetBusiness.UpdatePredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaPrvaGodinaForma.Text = "";
                textBoxUnosOcenePrvaGodinaForma.Text = "";
                textBoxUnosGodinePrvaGodinaForma.Text = "";
                MessageBox.Show("Uspesno izvrsena izmena!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonObrisitePredmetPrvaGodinaForma_Click(object sender, EventArgs e)
        {
            int row = dataGridViewPrvaGodinaForma.SelectedRows[0].Index;
            int Id = int.Parse(dataGridViewPrvaGodinaForma[0, row].Value.ToString());
            
            if (this.predmetBusiness.DeletePredmet(Id))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaPrvaGodinaForma.Text = "";
                textBoxUnosOcenePrvaGodinaForma.Text = "";
                textBoxUnosGodinePrvaGodinaForma.Text = "";
                MessageBox.Show("Uspesno brisanje!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }
    }
}
