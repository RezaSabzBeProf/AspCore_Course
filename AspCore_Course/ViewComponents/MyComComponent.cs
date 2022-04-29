using AspCore_Course.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Course.ViewComponents
{
    public class MyComComponent : ViewComponent
    {
        IPostService _postService;
        public MyComComponent(IPostService postService)
        {
            _postService = postService;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _postService.GetPosts();
            return Task.FromResult((IViewComponentResult)View("MyCom",model));
        }
    }
}
