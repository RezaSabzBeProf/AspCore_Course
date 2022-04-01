using AspCore_Course.Models;

namespace AspCore_Course.Service.Interface
{
    public interface IPostService
    {
        void AddPost(Post post);

        List<Post> GetPosts();

        Post GetPost(int id);

        void DeletePost(int id);

        void EditPost(Post post);
    }
}
