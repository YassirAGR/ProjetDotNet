using System.ComponentModel;
using MAUI.Reader.Model;

namespace MAUI.Reader.ViewModel
{
    class ReadBook(Book book) : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Book CurrentBook { get; init; } = book;
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    /*
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base()
        {
        }
    }
    */
}