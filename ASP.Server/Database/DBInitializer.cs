using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            bookDbContext.Genre.AddRange(
                SF = new Genre() {Id = 1, Nom = "Science Fiction"},
                Classic = new Genre() {Id = 2, Nom = "Classic"} ,
                Romance = new Genre() {Id = 3, Nom = "Romance"},
                Thriller = new Genre() {Id = 4, Nom = "Thriller"}
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Name = "20 000 mers", Prix = 14 , Content = "sous la mer ...", Genres = new() {Romance}},
                new Book() { Name = "catch", Prix = 33, Content = "TripleH ...", Genres = new() { SF }},
                new Book() { Name = "MBDS", Prix = 2024, Content = "MongoDB ...", Genres = new() {Classic, Thriller}},
                new Book() { Name = "scoot", Prix = 1, Content = "  ", Genres = new() {SF, Classic}}
            );
            // Vous pouvez initialiser la BDD ici
            bookDbContext.SaveChanges();
        }
    }
}