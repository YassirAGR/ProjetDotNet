using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MAUI.Reader.Model;
using MAUI.Reader.Service;
using System.Windows.Input;

using CommunityToolkit.Maui.Alerts;

namespace MAUI.Reader.ViewModel
{
    public partial class DetailsBook(Book book) : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        // Une commande permet de recevoir des évènement de l'IHM
        public ICommand ReadBook2Command { get; init; } = new RelayCommand<Book>(x => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(book); });

        // Vous pouvez aussi utiliser cette forme pour définir une commande. La ligne du dessus fait strictement la même chose, choisissez une des 2 formes
        [RelayCommand]
        public void ReadBook(Book book)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(CurrentBook);
        }

        // n'oublier pas faire de faire le binding dans DetailsBook.xaml !!!!
        public Book CurrentBook { get; init; } = book;
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    public class InDesignDetailsBook : DetailsBook
    {
        public InDesignDetailsBook() : base(new Book() { Name = "Test Book" }) { }
    }
}