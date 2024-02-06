using System;
using System.Collections.Generic;


var p = new Parking() { Niveaus = new List<Niveau>() { new Niveau(20) } };
p.Niveaus[0].VoitureEntree += (place, voiture) => Console.WriteLine($"Voiture entrée à la place {place}");
p.Niveaus[0].VoitureSortie += (place, voiture) => Console.WriteLine($"Voiture sortie de la place {place}");

p.Niveaus[0][1] = new Voiture(); // Simule l'entrée d'une voiture à la place 1

// Pour simuler la sortie, assignez null à la place occupée par une voiture
p.Niveaus[0][1] = null;



public class Parking
{
    public List<Niveau> Niveaus { get; init; }

    public Parking()
    {
        private List<Niveau> niveaus;
	public List<Niveau> Niveaus { 
		get {
			return niveaus;
		}
		init 
		{
			niveaus = value; 
		}
	}
	public Parkin()
    {
		foreach(var niveau in Niveaus)
        {
			niveau.VoitureEntree += ;
        }
    }
}

public class Niveau : Dictionary<int, Voiture>
{
    public delegate void EventVoiture(int placeNumber, Voiture voiture);
    public event EventVoiture VoitureEntree;
    public event Action<int, Voiture> VoitureSortie;

    // Correction du constructeur
    public Niveau(int size)
    {
        for (int i = 0; i < size; i++)
        {
            this.Add(i, null); // Initialise chaque place avec null
        }
    }

    public new Voiture this[int place]
    {
        get => base[place];
        set
        {
            var voitureActuelle = base[place];
            if (value != null && voitureActuelle != value)
            {
                base[place] = value;
                VoitureEntree?.Invoke(place, value);
            }
            else if (value == null && voitureActuelle != null)
            {
                VoitureSortie?.Invoke(place, voitureActuelle);
                base[place] = null;
            }
        }
    }
}

public class Voiture
{
    // Ajoutez des propriétés ou méthodes si nécessaire
}
