using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using ASP.Server.Models;
using AutoMapper;
using ASP.Server.Dtos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Connections.Features;
using Namotion.Reflection;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController(LibraryDbContext libraryDbContext, IMapper mapper) : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext = libraryDbContext;

        private readonly IMapper mapper = mapper;

        // Methode a ajouter :


        // - GetBooks
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12
        
        public ActionResult<IEnumerable<BooksDto>> GetBooks([FromQuery] List<int> genre, int limit = 10, int offset = 0)
        {
            var books = libraryDbContext.Books
                .Include(b => b.Genre)
                .OrderBy(b => b.Id)
                .Skip(offset)
                .Take(limit)
                .ToList();

            var booksDto = mapper.Map<List<BooksDto>>(books);

            return booksDto;
        }
        
        /*
        public ActionResult<IEnumerable<BooksDto>> GetBooks([FromQuery] List<int> genre, int limit = 10, int offset = 0)
        {
            // Filtrer les livres par genre si une liste d'ID de genre est fournie
            IQueryable<Book> query = libraryDbContext.Books.Include(b => b.Genres);
            if (genre != null && genre.Any())
            {
                query = query.Where(b => b.Genres.Any(g => genre.Contains(g.Id)));
            }

            // Compter le nombre total de livres dans la requête
            int totalCount = query.Count();

            // Appliquer la pagination en sautant les premiers éléments et en prenant le nombre spécifié d'éléments
            var books = query.OrderBy(b => b.Id).Skip(offset).Take(limit).ToList();

            // Mapper les livres vers leurs DTO correspondants
            var booksDto = mapper.Map<List<BooksDto>>(books);

            // Retourner les livres DTO avec des informations supplémentaires pour la pagination
            return new ObjectResult(new
            {
                TotalCount = totalCount,
                Books = booksDto
            });
        }
        */


        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier
        //   - Erreur: 404 si le livre n'existe pas
        //   - Erreur: 400 si l'id n'est pas un nombre
        //   - Sortie:
        //      {
        //          "Id": 1, "Name": "titre", "Prix": 10.5, "Content": "contenu",
        //          "Genres": [{ "Id": 1, "Name": "Genre" }]
        //      }

        public ActionResult<BookDto> GetBook(int id)
        {
            var bookById = libraryDbContext.Books.Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
            if (bookById == null)
                return NotFound();


            var genreDto = mapper.Map<List<GenreDto>>(bookById.Genre);

            var bookDto = mapper.Map<BookDto>(bookById);
            
            bookDto.Genre = genreDto ;

            return bookDto;
        }
        
        // - GetGenres
        //   - Entrée: Rien
        //   - Sortie: Liste des genres

        
        public ActionResult<List<GenreDto>> GetGenres()
        {
            var genres = libraryDbContext.Genres;

            var genreDto = mapper.Map<List<GenreDto>>(genres);

            return genreDto;
        }
        

        // Aide:
        // Pour récupéré un objet d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.First()

        // Pour récupéré des objets d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.ToList()

        // Pour faire une requète avec filtre:
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Skip().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Take().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Where(x => x == y).<Selecteurs>

        // Pour récupérer une 2nd table depuis la base:
        //   - .Include(x => x.yyyyy)
        //     ou yyyyy est la propriété liant a une autre table a récupéré
        //
        // Exemple:
        //   - Ex: libraryDbContext.MyObjectCollection.Include(x => x.yyyyy).Where(x => x.yyyyyy.Contains(z)).Skip(i).Take(j).ToList()

        // DTOs
        // transformation "à la main":
        //      my_array.Select(item => new ItemDto() { prop1 = item.prop1, prop2 = item.prop2, ... })

        // transformation avec AutoMapper
        //      Rajouter le mapping dans MappingProfile.cs
        //      this.mapper.Map<List<ItemDto>>(my_array);

        // Je vous montre comment faire la 1er, a vous de la compléter et de faire les autres !

        /*
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            // Exemple sans dependence externe
            // return libraryDbContext.Books.Select(b => new BookDto { Id = b.Id });
            // Exemple avec AutoMapper
            // return mapper.Map<List<BookDto>>(libraryDbContext.Books);
            throw new NotImplementedException("You have to do it your self");


        }
        */
    }
}

