using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ASP.Server.Models;

namespace ASP.Server.Controllers
{

    // Créer un model pour la création d'un livre
    public class CreateBookModel
    {
        [Required]
        public String Name { get; set; }

        [Required]

        public string Content { get; set; }
        [Required]

        public double Price { get; set; }

        [Required]

        public string Author { get; set; }

        public List<int> Genres { get; set; }
        public List<Genre> GenresList { get; set; }

        public IEnumerable<Genre> AllGenres { get; init; }
    }


    public class modifyBookModel
    {
        public long Id { get; set; }

        [Required]
        public String Name { get; set; }

        // Ajouter d'un livre
        [Required]

        public string Content { get; set; }
        [Required]

        public double Price { get; set; }

        [Required]

        public string Author { get; set; }

        public List<int> Genres { get; set; }
        public List<Genre> GenresList { get; set; }

        public IEnumerable<Genre> AllGenres { get; init; }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            var ListBooks = libraryDbContext.Books.Include(book => book.Genres).OrderBy(book => book.Id).ToList();
            return View(ListBooks);
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {

                var genres = libraryDbContext.Genres.Where(genre => book.Genres.Contains(genre.Id)).ToList();

                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book()
                {
                    Name = book.Name,
                    Author = book.Author,
                    Price = book.Price,
                    Content = book.Content,
                    Genres = genres
                });
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookModel() { AllGenres = libraryDbContext.Genres.ToList() });
        }

        public ActionResult<IEnumerable<Book>> Delete(int id)
        {
            var book = libraryDbContext.Books.Single(book => book.Id == id);
            libraryDbContext.Books.Remove(book);
            libraryDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult<modifyBookModel> Modify(modifyBookModel book, long idToModify)
        {
            var bookToModify = libraryDbContext.Books.Include(book => book.Genres).Single(book => book.Id == idToModify);            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis

            if (ModelState.IsValid)
            {
                bookToModify.Name = book.Name;
                bookToModify.Author = book.Author;
                bookToModify.Price = book.Price;
                bookToModify.Content = book.Content;

                List<Genre> genres = libraryDbContext.Genres.Where(genre => book.Genres.Contains(genre.Id)).ToList();
                bookToModify.Genres = genres;

                libraryDbContext.SaveChanges();

                return RedirectToAction("List", "Book");

            };

            return View(new modifyBookModel()
            {
                Id = bookToModify.Id,
                Name = bookToModify.Name,
                GenresList = bookToModify.Genres,
                Author = bookToModify.Author,
                Price = bookToModify.Price,
                Content = bookToModify.Content,
                AllGenres = libraryDbContext.Genres.ToList()
            });
        }
    }


    //    public class BookController(LibraryDbContext libraryDbContext, IMapper mapper) : Controller
    //    {
    //        private readonly LibraryDbContext libraryDbContext = libraryDbContext;

    //        public ActionResult<IEnumerable<Book>> List()
    //        {
    // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
    //            IEnumerable<Book> ListBooks = libraryDbContext.Books;
    //            return View(ListBooks);
    //        }

    //        public ActionResult<CreateBookViewModel> Create(CreateBookViewModel book)
    //        {
    // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
    //            if (ModelState.IsValid)
    //            {
    // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
    //                libraryDbContext.Add(new Book() {  });
    //                libraryDbContext.SaveChanges();
    //            }

    // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
    //            return View(new CreateBookViewModel() { AllGenres = libraryDbContext.Genre});
    //        }
    //    }


}
