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

            bookDbContext.Genres.AddRange(
                SF = new Genre() {Id = 1, Name = "Science Fiction"},
                Classic = new Genre() {Id = 2, Name = "Classic"} ,
                Romance = new Genre() {Id = 3, Name = "Romance"},
                Thriller = new Genre() {Id = 4, Name = "Thriller"}
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Name = "20 000 mers", Price = 14, Author = "aa" , Content = "sous la mer ...", Genre = new() {Romance}},
                new Book() { Name = "catch", Price = 33, Author = "bb", Content = "TripleH ...", Genre = new() { SF }},
                new Book() { Name = "MBDS", Price = 2024, Author = "cc", Content = "MongoDB ...", Genre = new() {Classic, Thriller}},
                new Book() { Name = "scoot", Price = 1, Author = "dd" , Content = "azertyuiop", Genre = new() {SF, Classic}}
            );
            // Vous pouvez initialiser la BDD ici

            

            bookDbContext.SaveChanges();
        }
    }
}