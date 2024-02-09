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
            new Book () { Name = "Le seigneur des anneaux", Author = "J.R.R. Tolkien", Description = "Un livre sur des petits bonhommes qui marchent", Cover = "https://www.placecage.com/200/300", Content = "Un livre sur des petits bonhommes qui marchent", Price = 10 },
            new Book () { Name = "Le seigneur des anneaux 2", Author = "J.R.R. Tolkien", Description = "Un livre sur des petits bonhommes qui marchent", Cover = "https://www.placecage.com/200/300", Content = "Un livre sur des petits bonhommes qui marchent", Price = 10 },
            new Book () { Name = "Le seigneur des anneaux 3", Author = "J.R.R. Tolkien", Description = "Un livre sur des petits bonhommes qui marchent", Cover = "https://www.placecage.com/200/300", Content = "Un livre sur des petits bonhommes qui marchent", Price = 10 },
            new Book () { Name = "Le seigneur des anneaux 4", Author = "J.R.R. Tolkien", Description = "Un livre sur des petits bonhommes qui marchent", Cover = "https://www.placecage.com/200/300", Content = "Un livre sur des petits bonhommes qui marchent", Price = 10 },
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
