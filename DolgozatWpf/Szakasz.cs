using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DolgozatWpf
{
    class Szakasz
    {
        String nev;
        double tavolsag;
        int tengerszintFeletti;
        int idoTartam;
        string nehezseg;


        public Szakasz(string sor)
        {
            var mezok = sor.Split(';');
            this.nev = mezok[0];
            this.tavolsag = double.Parse(mezok[1]);
            this.tengerszintFeletti = int.Parse(mezok[2]);
            this.idoTartam = int.Parse(mezok[3]);
        }

        public string Nev { get => nev;}
        public double Tavolsag { get => tavolsag;}
        public int TengerszintFeletti { get => tengerszintFeletti; }
        public int IdoTartam { get => idoTartam;}
        public string Nehezseg { get => nehezseg; set => nehezseg = value; }

        public static void NehezsegMegadas(List<Szakasz> lista)
        {
            foreach (var item in lista)
            {
                if (item.Tavolsag <= 5)
                {
                    item.nehezseg = "Könnyű";
                }
                else if (item.Tavolsag > 5 && item.Tavolsag < 10) 
                {
                    item.nehezseg = "Közepes";
                }
                else if (item.Tavolsag > 10)
                {
                    item.nehezseg = "Nehéz";
                }
            }
        }
    }
}
