using AspCore_Course.Models;
using AspCore_Course.Models.DTOs;

namespace AspCore_Course.Service.Interface
{
    public interface IPostService
    {
        void AddPost(Post post);

        List<Post> GetPosts();

        Post GetPost(int id);

        void DeletePost(int id);

        void EditPost(Post post);

        User GetUserByUserName(string userName);
        
        bool Login(LoginViewModel model);

        void AddUser(User user);
    }
}
