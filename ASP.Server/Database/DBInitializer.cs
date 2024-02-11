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

            Genre SF, Classique, Romance, Thriller, Victime, Crime ;
            bookDbContext.Genres.AddRange(
                SF = new Genre() { Name = "SF" },
                Classique = new Genre() { Name = "Classique" },
                Romance = new Genre() { Name = "Romance" },
                Thriller = new Genre() { Name = "Thriller" },
                Victime = new Genre() { Name = "Victime" },
                Crime = new Genre() { Name = "Crime" }
            );
            bookDbContext.SaveChanges();

            bookDbContext.Books.AddRange(
                new Book()
                {

                    Name = "Le Petit Prince",
                    Author = "Ouessacshova",
                    Content = "Le livre 'Le Petit Prince' est un conte philosophique écrit par Antoine de Saint-Exupéry. L'histoire raconte les aventures d'un jeune prince venu d'une planète lointaine, et aborde des thèmes tels que l'amitié, l'amour et la solitude. ",
                    Price = 10000,
                    Genres = new() { Romance }
                },

                new Book()
                {

                    Name = "Chien des Baskerville",
                    Author = "Pascal",
                    Content = "\"Le Chien des Baskerville\" est un roman de crime écrit par Sir Arthur Conan Doyle. L'histoire se déroule dans le sombre et mystérieux Dartmoor en Angleterre.",
                    Price = 999,
                    Genres = new() { Crime }

                },
                new Book()
                {

                    Name = "Les Misérables",
                    Author = "Victor Hugo",
                    Content = "L'histoire suit la vie de Jean Valjean, un ancien forçat en quête de rédemption, et d'autres personnages qui gravitent autour de lui dans la France du XIXe siècle.",
                    Price = 998,
                    Genres = new() { Classique }

                },
                new Book()
                {

                    Name = "Les Rivières pourpres",
                    Author = "Jean-Christophe",
                    Content = "L'histoire suit le commissaire Pierre Niémans et son partenaire, le lieutenant Karim Abdouf, alors qu'ils enquêtent sur une série de meurtres étranges dans les montagnes isolées des Alpes françaises.",
                    Price = 998,
                    Genres = new() { Thriller }

                })


         ;
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}