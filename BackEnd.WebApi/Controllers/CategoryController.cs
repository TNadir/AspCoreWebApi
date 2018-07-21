using System.Threading.Tasks;
using BackEnd.Data.Domen;
using BackEnd.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAnyOrigin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }

        [HttpGet]
        [ActionName("all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.categoryService.GetCategories());
        }
         
        [HttpPost]
        [ActionName("addcategories")]
        public async Task<IActionResult> Post([FromBody]Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usr = await this.categoryService.Insert(categories);
            return Ok(usr);
        }

    }
}