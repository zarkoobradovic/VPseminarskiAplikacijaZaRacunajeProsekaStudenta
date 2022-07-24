using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PredmetBusiness
    {
        private readonly PredmetRepository predmetRepository;


        public PredmetBusiness()
        {
            this.predmetRepository = new PredmetRepository();
        }

        public List<Predmet> GetAllPredmet()
        {
            return this.predmetRepository.GetAllPredmet();
        }

        public bool InsertPredmet (Predmet p)
        {
            if (this.predmetRepository.InsertPredmet(p) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePredmet (Predmet p)
        {
            if (this.predmetRepository.UpdatePredmet(p) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeletePredmet (int Id)
        {
            if (this.predmetRepository.DeletePredmet(Id) > 0)
            {
                return true;
            }
            return false;
        }


        //racunanje proseka po godini
        public double Prosek (Predmet p)
        {
            double suma = 0;
            int br = 0;
            foreach (Predmet pr in GetAllPredmet())
            {
                if (pr.Godina==p.Godina)
                {
                    suma += pr.Ocena;
                    br++;
                }
            }
            return suma / br;
        }

        public double UkupanProsek(Predmet p)
        {
            double suma = 0;
            int br = 0;
            foreach (Predmet pr in GetAllPredmet())
            {
                    suma += pr.Ocena;
                    br++;
            }
            return suma / br;
        }

    }
}
