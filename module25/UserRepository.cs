using Microsoft.EntityFrameworkCore;

namespace module25
{
    public class UserRepository
    {
        public List<User> SelectAll(AppContext db)
        {
            return db.Users.ToList();
        }

        public List<User> SelectById(AppContext db, int id)
        {
            User user = db.Users.FirstOrDefault(user => user.Id == id);
            return db.Users.Where(u =>  u.Id == user.Id).ToList();
        }

        public void Add(AppContext db, User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(AppContext db, User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void UpdateEmailById(AppContext db, int id, string name)
        {
            User user = db.Users.FirstOrDefault(user => user.Id == id);
            user.Name = name;
            db.SaveChanges();
        }

    }
}
