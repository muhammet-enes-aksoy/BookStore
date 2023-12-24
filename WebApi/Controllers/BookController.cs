using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private static List <Book> BookList = new List<Book>(){
            new Book{
                Id = 1,
                Title = "aaa",
                GenerId = 1001,
                PageCount = 300
            },
            new Book{
                Id = 2,
                Title = "bbb",
                GenerId = 1002,
                PageCount = 250
            },
            new Book{
                Id = 3,
                Title = "ccc",
                GenerId = 1001,
                PageCount = 500
            }
        };
        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = BookList.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;
        }
    }
}