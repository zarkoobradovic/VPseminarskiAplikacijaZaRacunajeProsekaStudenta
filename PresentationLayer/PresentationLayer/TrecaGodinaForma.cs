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
    public partial class TrecaGodinaForma : Form
    {
        private readonly PredmetBusiness predmetBusiness;

        public TrecaGodinaForma()
        {
            this.predmetBusiness = new PredmetBusiness();
            InitializeComponent();
            CenterToScreen();
        }

        private void RefreshData()
        {
            List<Predmet> predmets = this.predmetBusiness.GetAllPredmet();
            dataGridViewTrecaGodinaForma.Rows.Clear();
            for (int i = 0; i < predmets.Count; ++i)
            {
                if (predmets[i].Godina == 3)
                    dataGridViewTrecaGodinaForma.Rows.Add(predmets[i].Id, predmets[i].NazivPredmeta, predmets[i].Ocena, predmets[i].Godina);
            }
            dataGridViewTrecaGodinaForma.Columns[0].Visible = false;

            Predmet p = new Predmet();
            p.Godina = 3;
            double srednjaVR = Math.Round(predmetBusiness.Prosek(p), 2);
            textBoxUkupanProsekTrecaGodinaForma.Text = srednjaVR.ToString();
        }

        private void buttonDodajtePredmetTrecaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            p.NazivPredmeta = textBoxUnosNazivaPredmetaTrecaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneTrecaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineTrecaGodinaForma.Text);

            if (this.predmetBusiness.InsertPredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaTrecaGodinaForma.Text = "";
                textBoxUnosOceneTrecaGodinaForma.Text = "";
                textBoxUnosGodineTrecaGodinaForma.Text = "";
                MessageBox.Show("Dodavanje uspesno izvrseno!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonIzmenitePredmetTrecaGodinaForma_Click(object sender, EventArgs e)
        {
            Predmet p = new Predmet();
            int row = dataGridViewTrecaGodinaForma.SelectedRows[0].Index;
            p.Id = int.Parse(dataGridViewTrecaGodinaForma[0, row].Value.ToString());
            p.NazivPredmeta = textBoxUnosNazivaPredmetaTrecaGodinaForma.Text;
            p.Ocena = Convert.ToInt32(textBoxUnosOceneTrecaGodinaForma.Text);
            p.Godina = Convert.ToInt32(textBoxUnosGodineTrecaGodinaForma.Text);

            if (this.predmetBusiness.UpdatePredmet(p))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaTrecaGodinaForma.Text = "";
                textBoxUnosOceneTrecaGodinaForma.Text = "";
                textBoxUnosGodineTrecaGodinaForma.Text = "";
                MessageBox.Show("Uspesno izvrsena izmena!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void buttonObrisitePredmetTrecaGodinaForma_Click(object sender, EventArgs e)
        {
            int row = dataGridViewTrecaGodinaForma.SelectedRows[0].Index;
            int Id = int.Parse(dataGridViewTrecaGodinaForma[0, row].Value.ToString());

            if (this.predmetBusiness.DeletePredmet(Id))
            {
                RefreshData();
                textBoxUnosNazivaPredmetaTrecaGodinaForma.Text = "";
                textBoxUnosOceneTrecaGodinaForma.Text = "";
                textBoxUnosGodineTrecaGodinaForma.Text = "";
                MessageBox.Show("Uspesno brisanje!");
            }
            else
            {
                MessageBox.Show("Greska prilikom unosa!");
            }
        }

        private void TrecaGodinaForma_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridViewTrecaGodinaForma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = dataGridViewTrecaGodinaForma.SelectedRows[0].Index;

                textBoxUnosNazivaPredmetaTrecaGodinaForma.Text = dataGridViewTrecaGodinaForma[1, row].Value.ToString();

                textBoxUnosOceneTrecaGodinaForma.Text = dataGridViewTrecaGodinaForma[2, row].Value.ToString();
                textBoxUnosGodineTrecaGodinaForma.Text = dataGridViewTrecaGodinaForma[3, row].Value.ToString();

            }
            catch { MessageBox.Show("Ceo red mora biti selektovan!"); }
        }
    }
}
