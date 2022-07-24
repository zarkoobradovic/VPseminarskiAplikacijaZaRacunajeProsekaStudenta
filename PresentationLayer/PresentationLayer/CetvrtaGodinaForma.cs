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
    public partial class CetvrtaGodinaForma : Form
    {
        private readonly PredmetBusiness predmetBusiness;

        public CetvrtaGodinaForma()
        {
            this.predmetBusiness = new PredmetBusiness();
            InitializeComponent();
            CenterToScreen();
        }

        private void RefreshData()
        {
            List<Predmet> predmets = this.predmetBusiness.GetAllPredmet();
            dataGridViewCetvrtaGodinaForma.Rows.Clear();
            for (int i = 0; i < predmets.Count; ++i)
            {
                if (predmets[i].Godina == 4)
                    dataGridViewCetvrtaGodinaForma.Rows.Add(predmets[i].Id, predmets[i].NazivPredmeta, predmets[i].Ocena, predmets[i].Godina);
            }
            dataGridViewCetvrtaGodinaForma.Columns[0].Visible = false;

            Predmet p = new Predmet();
            p.Godina = 4;
            double srednjaVR = Math.Round(predmetBusiness.Prosek(p), 2);
            textBoxUkupanProsekCetvrtaGodinaForma.Text = srednjaVR.ToString();
        }

        private void buttonDodajtePredmetCetvrtaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            p.NazivPredmeta = textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneCetvrtaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineCetvrtaGodinaForma.Text);

            if (this.predmetBusiness.InsertPredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text = "";
                textBoxUnosOceneCetvrtaGodinaForma.Text = "";
                textBoxUnosGodineCetvrtaGodinaForma.Text = "";
                MessageBox.Show("Dodavanje uspesno izvrseno!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonIzmenitePredmetCetvrtaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            int row = dataGridViewCetvrtaGodinaForma.SelectedRows[0].Index;
            p.Id = int.Parse(dataGridViewCetvrtaGodinaForma[0, row].Value.ToString());
            p.NazivPredmeta = textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneCetvrtaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineCetvrtaGodinaForma.Text);

            if (this.predmetBusiness.UpdatePredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text = "";
                textBoxUnosOceneCetvrtaGodinaForma.Text = "";
                textBoxUnosGodineCetvrtaGodinaForma.Text = "";
                MessageBox.Show("Uspesno izvrsena izmena!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonObrisitePredmetCetvrtaGodinaForma_Click(object sender, EventArgs e)
        {
            int row = dataGridViewCetvrtaGodinaForma.SelectedRows[0].Index;
            int Id = int.Parse(dataGridViewCetvrtaGodinaForma[0, row].Value.ToString());

            if (this.predmetBusiness.DeletePredmet(Id))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text = "";
                textBoxUnosOceneCetvrtaGodinaForma.Text = "";
                textBoxUnosGodineCetvrtaGodinaForma.Text = "";
                MessageBox.Show("Uspesno brisanje!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void CetvrtaGodinaForma_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridViewCetvrtaGodinaForma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dataGridViewCetvrtaGodinaForma.SelectedRows[0].Index;

                textBoxUnosNazivaPredmetaCetvrtaGodinaForma.Text = dataGridViewCetvrtaGodinaForma[1, row].Value.ToString();

                textBoxUnosOceneCetvrtaGodinaForma.Text = dataGridViewCetvrtaGodinaForma[2, row].Value.ToString();
                textBoxUnosGodineCetvrtaGodinaForma.Text = dataGridViewCetvrtaGodinaForma[3, row].Value.ToString();

            }
            catch { MessageBox.Show("Ceo red mora biti selektovan!"); }
        }
    }
}
