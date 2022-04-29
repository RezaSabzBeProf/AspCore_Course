using AspCore_Course.Models;
using AspCore_Course.Service.Interface;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult CreatePost(Post post,IFormFile imagePost)
        {
            post.FilePath = TopCoderZ.Core.Generator.NameGenerator.GenerateUniqCode() + Path.GetExtension(imagePost.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", post.FilePath);
            using(var stream = new FileStream(filePath,FileMode.Create))
            {
                imagePost.CopyTo(stream);
            }
            post.CreateDate = DateTime.Now;
            post.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var htmlSan = new HtmlSanitizer();
            string safeBody = htmlSan.Sanitize(post.Body);
            post.Body = safeBody;
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
            var htmlSan = new HtmlSanitizer();
            post.Body = htmlSan.Sanitize(post.Body);
            _postService.EditPost(post);
            return RedirectToAction("index");
        }
        public IActionResult ShowPost(int id)
        {
            var model = _postService.GetPost(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

    }
}
