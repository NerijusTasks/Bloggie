using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public AdminBlogPostsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // get tags from repository
            var tags = await _tagRepository.GetALLAsync();

            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.DisplayName, Value = x.Id.ToString() })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            return RedirectToAction("Add");
        }
    }
}
