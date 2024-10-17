namespace module25
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Alice", Role = "User" };
                var user2 = new User { Name = "Bob", Role = "User" };
                var user3 = new User { Name = "Bruce", Role = "User" };

                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                var author1 = new Author { Name = "Герберт Шилдт" };
                var author2 = new Author { Name = "Станислав Лем" };
                var author3 = new Author { Name = "Ю Несбё" };
                var author4 = new Author { Name = "Александр Пушкин" }; 

                db.Authors.AddRange(author1, author2, author3);
                    db.SaveChanges();

                var genre1 = new Genre { Name = "Фантастика" };
                var genre2 = new Genre { Name = "Обучающие" };
                var genre3 = new Genre { Name = "Детектив" };
                var genre4 = new Genre { Name = "Фэнтези" };
                var genre5 = new Genre { Name = "Классика" };

                db.Genres.AddRange(genre1, genre2, genre3);
                    db.SaveChanges();

                var book1 = new Book { Title = "Полное руководство C#", Author = author1, Genre = genre1, User = user1,  Year = 2011};
                var book2 = new Book { Title = "Солярис", Author = author2, Genre = genre2, User = user2, Year = 1960};
                var book3 = new Book { Title = "Снеговик", Author = author3, Genre =genre3, User = user3, Year = 2007};

                db.Books.AddRange(book1, book2, book3);
                db.SaveChanges();

                var UR = new BookRepository();
                var a = UR.GetByGenreBetweenYears(db, 2000, 2010, genre3);
                foreach ( var item in a ) { Console.WriteLine(item.Title); }
                
            }
        }
    }
}
