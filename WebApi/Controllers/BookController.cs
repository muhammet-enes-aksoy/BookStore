using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers;
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private static List <Book> BookList = new List<Book>(){
            new Book{
                Id = 1,
                Title = "aaa",
                GenreId = 1001,
                PageCount = 300,
                PublishDate = new DateTime(2020,05,21)
            },
            new Book{
                Id = 2,
                Title = "bbb",
                GenreId = 1002,
                PageCount = 250,
                PublishDate =new DateTime(2001,08,25)
            },
            new Book{
                Id = 3,
                Title = "ccc",
                GenreId = 1001,
                PageCount = 500,
                PublishDate = new DateTime(2010,05,21)
            }
        };

        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = BookList.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id){
            var book = BookList.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook ([FromBody] Book newBook){
            var book = BookList.SingleOrDefault(x=> x.Title == newBook.Title);
            if(book is not null)
                return BadRequest();
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook){
            var book = BookList.SingleOrDefault(x=> x.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            return Ok(); 
        }
    }
