using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace module25
{
    public class BookRepository
    {
        public List<Book> SelectAll(AppContext db)
        {
            return db.Books.ToList();
        }

        public List<Book> SelectById(AppContext db, int id)
        {
            Book book = db.Books.FirstOrDefault(book => book.Id == id);
            return db.Books.Where(b => b.Id == book.Id).ToList();
        }

        public void Add(AppContext db, Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Delete(AppContext db, Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void UpdateEmailById(AppContext db, int id, int year)
        {
            Book book = db.Books.FirstOrDefault(book => book.Id == id);
            book.Year = year;
            db.SaveChanges();
        }


        public List<Book> GetByGenreBetweenYears(AppContext db, int year1, int year2, Genre genre)
        {
            var query = from b in db.Books
            where (b.Year >= year1) && (b.Year <= year2) &&
            b.Genre == genre
            select b;
            var result = query.ToList();

            return result;            
        }

        public int CountByAuthor(AppContext db, Author author)
        {
            var query = from b in db.Books
                        where b.Author == author
                        select b;
            return query.Count();
        }

        public int CountByGenre(AppContext db, Genre genre)
        {
            var query = from b in db.Books
                        where b.Genre == genre
                        select b;
            return query.Count();
        }

        public bool CheckBook(AppContext db, string title, Author author)
        {
            var query = from b in db.Books
                        where b.Title == title && b.Author == author
                        select b;
            if (query.Count() > 0) return true;
            return false;
        }

        public bool CheckBookForUser(AppContext db, Book book, User user)
        {
            var query = from b in db.Books
                        where b == book && b.User == user
                        select b;
            if (query.Count() > 0) return true;
            return false;
        }

        public Book GetLastBook (AppContext db) 
        {
            var query = from b in db.Books
                        orderby b.Year descending
                        select b;
            return query.First();
        }

        public List<Book> GetSortedBooksByTitle(AppContext db)
        {
            return db.Books.OrderBy(b => b.Title).ToList();
        }

        public List<Book> GetSortedBooksByYear (AppContext db)
        {
            return db.Books.OrderByDescending(b => b.Year).ToList();
        }
    }
}
