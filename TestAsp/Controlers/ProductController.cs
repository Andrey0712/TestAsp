using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Data;
using TestAsp.Model;

namespace TestAsp.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private EFContext _context { get; set; }
        public ProductController(EFContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPage([FromQuery] GetPageModel model)
        {
            int count = 2;
            int skip = model.Page != 0 ? (model.Page - 1) * count : 0;
           
            string search = model.Search != null ? model.Search : "";

            var returnProducts = _context.Products.Where(x => x.Name.Contains(search) || x.Description.Contains(search));
            return Ok(new
            {
                data = new
                {
                    data = returnProducts.Select(x => x).Skip(skip).Take(count).ToList(),
                    current_page = model.Page,
                    last_page = (Math.Ceiling((decimal)returnProducts.Count() / count)),
                    total = returnProducts.Count(),
                    per_page = count
                },
                search = model.Search
            });
        }
    }
}
