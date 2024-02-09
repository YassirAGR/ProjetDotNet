using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using WPF.Reader.Model;
using WPF.Reader.OpenApi;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book() { Name = "Livre 1", Author = "Auteur 1", Description = "Description 1", Content = "Contenu 1" },
            new Book() { Name = "Livre 2", Author = "Auteur 2", Description = "Description 2", Content = "Contenu 2" },
            new Book() { Name = "Livre 3", Author = "Auteur 3", Description = "Description 3", Content = "Contenu 3" },
            new Book() { Name = "Livre 4", Author = "Auteur 4", Description = "Description 4", Content = "Contenu 4" }
        };

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
        public LibraryService() {
            /*
            WPF.Reader.OpenApi.Library libraryApi = new WPF.Reader.OpenApi.Library(new HttpClient());
            */

        }

        /*
        internal static Task<IEnumerable<Book>> LoadBooksAsync()
        {
            throw new NotImplementedException();
        }
        */
    }
}
