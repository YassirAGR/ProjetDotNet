﻿using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MAUI.Reader.Model;
using MAUI.Reader.Service;
using System.Windows.Input;

using CommunityToolkit.Maui.Alerts;

namespace MAUI.Reader.ViewModel
{
    public partial class ListBooks : INotifyPropertyChanged
    {
        public ListBooks()
        {
            ItemSelectedCommand = new Command<Book>(OnItemSelectedCommand);
        }

        public ICommand ItemSelectedCommand { get; private set; }
        public void OnItemSelectedCommand(Book book)
        {
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book);

        }

        public ObservableCollection<Book> Book => Ioc.Default.GetRequiredService<LibraryService>().Book;

        public int Count { get; set; }

        [RelayCommand]
        public void CounterClicked()
        {
            Count++;

            Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(new Book());
        }
    }
}