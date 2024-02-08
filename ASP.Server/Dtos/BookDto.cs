using ASP.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ASP.Server.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public List<GenreDto> Genre { get; set; }
    }

    public class GenreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }

    public class BooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<GenreDto> Genre { get; set; }
    }
}



