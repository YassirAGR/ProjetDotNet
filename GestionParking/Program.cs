using System;

namespace GestionParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new Parking();
            parking.VoitureEntree += (sender, e) => Console.WriteLine("Une voiture est entrée.");
            parking.VoitureSortie += (sender, e) => Console.WriteLine("Une voiture est sortie.");

            // Simuler l'entrée et la sortie des voitures
            parking.EntrerVoiture();
            parking.SortirVoiture();
        }
    }
}
