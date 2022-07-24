using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Predmet
    {
        public int Id { get; set; }

        public string NazivPredmeta { get; set; }

        public int Godina { get; set; }

        public int Ocena { get; set; }
    }
}
