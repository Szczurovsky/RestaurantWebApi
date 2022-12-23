using Microsoft.AspNetCore.Mvc;
using RestaurantWebApi.Entities;

namespace RestaurantWebApi.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : Controller
    {
        private readonly RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>>GetAll()
        {
            var restaurants = _context
                .Restaurants
                .ToList();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            return Ok(restaurant);
        }
    }
}
