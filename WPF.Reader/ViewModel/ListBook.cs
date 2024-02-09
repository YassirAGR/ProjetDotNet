using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF.Reader.Model;
using WPF.Reader.Service;
using System.Windows;
using System.Collections.Generic;
using Windows.Web.Http;
using System.Threading.Tasks;
using System;

namespace WPF.Reader.ViewModel
{
    public partial class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [RelayCommand]

        public void ItemSelected(Book book)
        {
            var navigationService = Ioc.Default.GetRequiredService<NavigationService>();
            navigationService.Navigate<DetailsBook>(book); ;

        }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        


    }
}
