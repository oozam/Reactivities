namespace API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ReactivitiesDbContext context;

        public ValuesController(ReactivitiesDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values = await context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await context.Values.FindAsync(id);
            return Ok(value);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
