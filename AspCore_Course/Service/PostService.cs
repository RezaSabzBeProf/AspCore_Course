using AspCore_Course.Models;
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
    }
}
