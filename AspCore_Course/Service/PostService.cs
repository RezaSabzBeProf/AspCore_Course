using AspCore_Course.Models;
using AspCore_Course.Models.DTOs;
using AspCore_Course.Service.Interface;

namespace AspCore_Course.Service
{
    public class PostService : IPostService
    {
        FarsLearnContext _context;
        public PostService(FarsLearnContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var model = GetPost(id);
            _context.Posts.Remove(model);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(p => p.UserName == userName);
        }

        public bool Login(LoginViewModel model)
        {
            bool login = _context.Users.Any(p => p.UserName == model.UserName && p.Password == Password_helper.EncodePassword(model.Password));
            return login;
        }
    }
}
