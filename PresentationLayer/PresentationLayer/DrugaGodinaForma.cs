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
    public partial class DrugaGodinaForma : Form
    {
        private readonly PredmetBusiness predmetBusiness;

        public DrugaGodinaForma()
        {
            this.predmetBusiness = new PredmetBusiness();
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonDodajtePredmetDrugaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            p.NazivPredmeta = textBoxUnosNazivaPredmetaDrugaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneDrugaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineDrugaGodinaForma.Text);

            if (this.predmetBusiness.InsertPredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaDrugaGodinaForma.Text = "";
                textBoxUnosOceneDrugaGodinaForma.Text = "";
                textBoxUnosGodineDrugaGodinaForma.Text = "";
                MessageBox.Show("Dodavanje uspesno izvrseno!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void RefreshData()
        {
            List<Predmet> predmets = this.predmetBusiness.GetAllPredmet();
            dataGridViewDrugaGodinaForma.Rows.Clear();
            for (int i = 0; i < predmets.Count; ++i)
            {
                if (predmets[i].Godina == 2)
                    dataGridViewDrugaGodinaForma.Rows.Add(predmets[i].Id, predmets[i].NazivPredmeta, predmets[i].Ocena, predmets[i].Godina);
            }
            dataGridViewDrugaGodinaForma.Columns[0].Visible = false;

            Predmet p = new Predmet();
            p.Godina = 2;
            double srednjaVR = Math.Round(predmetBusiness.Prosek(p), 2);
            textBoxUkupanProsekDrugaGodinaForma.Text = srednjaVR.ToString();
        }

        private void buttonIzmenitePredmetDrugaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            int row = dataGridViewDrugaGodinaForma.SelectedRows[0].Index;
            p.Id = int.Parse(dataGridViewDrugaGodinaForma[0, row].Value.ToString());
            p.NazivPredmeta = textBoxUnosNazivaPredmetaDrugaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneDrugaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineDrugaGodinaForma.Text);

            if (this.predmetBusiness.UpdatePredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaDrugaGodinaForma.Text = "";
                textBoxUnosOceneDrugaGodinaForma.Text = "";
                textBoxUnosGodineDrugaGodinaForma.Text = "";
                MessageBox.Show("Uspesno izvrsena izmena!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonObrisitePredmetDrugaGodinaForma_Click(object sender, EventArgs e)
        {
            int row = dataGridViewDrugaGodinaForma.SelectedRows[0].Index;
            int Id = int.Parse(dataGridViewDrugaGodinaForma[0, row].Value.ToString());

            if (this.predmetBusiness.DeletePredmet(Id))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaDrugaGodinaForma.Text = "";
                textBoxUnosOceneDrugaGodinaForma.Text = "";
                textBoxUnosGodineDrugaGodinaForma.Text = "";
                MessageBox.Show("Uspesno brisanje!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void DrugaGodinaForma_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridViewDrugaGodinaForma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dataGridViewDrugaGodinaForma.SelectedRows[0].Index;

                textBoxUnosNazivaPredmetaDrugaGodinaForma.Text = dataGridViewDrugaGodinaForma[1, row].Value.ToString();

                textBoxUnosOceneDrugaGodinaForma.Text = dataGridViewDrugaGodinaForma[2, row].Value.ToString();
                textBoxUnosGodineDrugaGodinaForma.Text = dataGridViewDrugaGodinaForma[3, row].Value.ToString();

            }
            catch { MessageBox.Show("Ceo red mora biti selektovan!"); }
        }
    }
}
