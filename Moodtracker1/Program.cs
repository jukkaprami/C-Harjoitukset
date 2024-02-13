using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodtracker1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Muuttujat mielialan ja kunnon tallentamiseen
            string vireysSTR;
            int vireys;
            string uniSTR;
            int uni;
            string nalkaSTR;
            int nalka;
            int moodIndex;

            Console.WriteLine("Hyvää huomenta, miltä Sinusta tuntuu tänään?");
            Console.WriteLine();
            Console.WriteLine("Arvioi vireyttäsi asteikolla 1-5 1: unelias, 5: täynnä räjähtävää energiaa");
            vireysSTR = Console.ReadLine();
            Console.WriteLine("Miten hyvin nukuit? 1: huonosti, 5: kuin tukki");
            uniSTR = Console.ReadLine();
            Console.WriteLine("Miten nälkäinen olet? 1: kaamea nälkä, 5: ei muruakaan");
            nalkaSTR = Console.ReadLine();

            // Muutetaan vastaukset numeromuotoon
            vireys = int.Parse(vireysSTR);
            uni = int.Parse(uniSTR);
            nalka = int.Parse(nalkaSTR);

            // Lasketaan mielialaindeksi
            moodIndex = vireys + uni + nalka;


            // Tulostetaan käyttäjän antamat vastaukset
            Console.WriteLine("Vireyspisteet: " + vireysSTR + ", unipisteet: " + uniSTR + " ja  nälkäpisteet: " + nalkaSTR);


            Console.WriteLine();
            Console.WriteLine("Mielialaindeksisi on: " + moodIndex);

            // pidetään konsoli ikkuna auki, kunnes painetaan <Enter>
            Console.ReadLine();
        }

    }
}
