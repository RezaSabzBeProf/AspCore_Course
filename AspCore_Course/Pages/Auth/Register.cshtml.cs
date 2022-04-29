using AspCore_Course.Models;
using AspCore_Course.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspCore_Course.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        IPostService _postService;
        public RegisterModel(IPostService postService)
        {
            _postService = postService;
        }
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            
            User.CreateDate = DateTime.Now;
            User.Role = UserRole.NormalUser;
            string password = User.Password;
            password = Password_helper.EncodePassword(password);
            _postService.AddUser(User);
            return Redirect("/home/Login");
        }
    }
}
