using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP.Server.Models;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genres.AddRange(
                SF = new Genre() { Name = "SF" },
                Classic = new Genre() { Name = "Classic" },
                Romance = new Genre() { Name = "Romance" },
                Thriller = new Genre() { Name = "Thriller" }
            );
            bookDbContext.SaveChanges();

            bookDbContext.Books.AddRange(
                new Book()
                {

                    Name = "Titre1",
                    Author = "Yassir",
                    Content = "Hello it's me    !!!!    ",
                    Price = 10000,
                    Genres = new() { SF }
                },

                new Book()
                {

                    Name = "Titre2",
                    Author = "Aya",
                    Content = "L bekaya    !!!!    ",
                    Price = 9999999999999,
                    Genres = new() { Classic }

                },
                new Book()
                {

                    Name = "Titre3",
                    Author = "Charles",
                    Content = "Le bg    !!!!    ",
                    Price = 9999999999998,
                    Genres = new() { Romance }

                },
                new Book()
                {

                    Name = "Titre3",
                    Author = "Fabien",
                    Content = "Le bg    !!!!    ",
                    Price = 9999999999998,
                    Genres = new() { Thriller }

                })


         ;
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}