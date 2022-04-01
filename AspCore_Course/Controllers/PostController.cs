using AspCore_Course.Models;
using AspCore_Course.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Course.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var model = _postService.GetPosts();
            return View(model);
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            post.CreateDate = DateTime.Now;
            post.UserId = 1;
            _postService.AddPost(post);
            return RedirectToAction("index");
        }
        public IActionResult DeletePost(int id)
        {
            
            return View(_postService.GetPost(id));
        }

        [HttpPost]
        public IActionResult DeletePost1(int deleteid)
        {
            _postService.DeletePost(deleteid);
            return RedirectToAction("index");
        }
        public IActionResult EditPost(int id)
        {
            var model = _postService.GetPost(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            _postService.EditPost(post);
            return RedirectToAction("index");
        }
        public IActionResult ShowPost(int id)
        {
            var model = _postService.GetPost(id);
            return View(model);
        }

    }
}
