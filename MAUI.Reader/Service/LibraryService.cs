using System.Collections.ObjectModel;
using MAUI.Reader.Model;

namespace MAUI.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Book { get; set; } = new ObservableCollection<Book>() {
            new Book () { Name = "Aventures au-delà des montagnes", Author = "Alexandre Dumas", Description = "Une quête épique à travers des terrains inexplorés.", Cover = "https://img.livraddict.com/covers/13/13991/couv65280731.jpg", Content = new string('A', 1024), Price = 15 },
            new Book () { Name = "Les mystères de l'océan", Author = "Jules Verne", Description = "Exploration sous-marine pleine de découvertes et de dangers.", Cover = "https://www.placecage.com/200/300", Content = new string('B', 1024), Price = 12 },
            new Book () { Name = "L'île mystérieuse", Author = "H.G. Wells", Description = "Survie et science-fiction se rencontrent sur une île isolée.", Cover = "https://www.placecage.com/200/300", Content = new string('C', 1024), Price = 14 },
            new Book () { Name = "Voyage au centre de la Terre", Author = "Jules Verne", Description = "Un voyage extraordinaire vers un monde inconnu sous nos pieds.", Cover = "https://www.placecage.com/200/300", Content = new string('D', 1024), Price = 16 },
            new Book () { Name = "Les guerriers de l'ombre", Author = "Robert Louis Stevenson", Description = "Une lutte entre le bien et le mal dans un royaume ancien.", Cover = "https://www.placecage.com/200/300", Content = new string('E', 1024), Price = 13 },
            new Book () { Name = "Les portes du temps", Author = "Philip K. Dick", Description = "Voyage temporel et paradoxes dans une aventure qui défie la réalité.", Cover = "https://www.placecage.com/200/300", Content = new string('F', 1024), Price = 17 },
            new Book () { Name = "Le dernier des Mohicans", Author = "James Fenimore Cooper", Description = "Un récit historique et dramatique dans l'Amérique du 18ème siècle.", Cover = "https://www.placecage.com/200/300", Content = new string('G', 1024), Price = 11 },
            new Book () { Name = "La cité perdue", Author = "Arthur Conan Doyle", Description = "Une expédition à la recherche d'une civilisation oubliée.", Cover = "https://www.placecage.com/200/300", Content = new string('H', 1024), Price = 18 },
            new Book () { Name = "Les archives de l'espace", Author = "Isaac Asimov", Description = "Conflits et découvertes dans l'immensité de l'univers.", Cover = "https://www.placecage.com/200/300", Content = new string('I', 1024), Price = 19 },
            new Book () { Name = "Le fantôme de l'opéra", Author = "Gaston Leroux", Description = "Amour, mystère et terreur dans l'enceinte d'un opéra parisien.", Cover = "https://www.placecage.com/200/300", Content = new string('J', 1024), Price = 20 }
        };

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
        public LibraryService()
        {
           
            WPF.Reader.OpenApi.Library libraryApi = new WPF.Reader.OpenApi.Library(new HttpClient());
                                    
        }
    }
}
