using Microsoft.AspNetCore.Mvc;
using MyTravelMicroservice.Model;
using MyTravelMicroservice.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private  static TravelDbContext _context;
        private static ITravel travel;

        public  TravelController(TravelDbContext context)
        {
            _context = context;
            travel = new TravelRepository(_context);
        }

       [HttpGet]
        public  ActionResult<IEnumerable<Travel>> GetAllTravel()
        {

            return  travel.GetAllTravel();
        }

        [HttpGet("{id}")]
        public ActionResult<Travel> GetTravelById(int id)
        {
            var travelId = travel.GetTravelById(id);

            if (travelId == null)
            {

                return NotFound();
            }
            return travelId;

        
        }
    }
}
