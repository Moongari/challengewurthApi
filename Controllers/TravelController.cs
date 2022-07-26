using Microsoft.AspNetCore.Mvc;
using MyTravelMicroservice.Model;
using MyTravelMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private static TravelDbContext _context;
        private static ITravel travel;
        /// <summary>
        /// injection des dependances middelware
        /// </summary>
        /// <param name="context"></param>
        public  TravelController(TravelDbContext context)
        {
            _context = context;
            travel = new TravelRepository(_context);
        }

       [HttpGet]
        public  ActionResult<IEnumerable<Travel>> GetAllTravel()
        {
            if(travel != null)
            {
                return travel.GetAllTravel();
            }
            else
            {
                return NotFoundResult();
            }
        
        }

        private ActionResult<IEnumerable<Travel>> NotFoundResult()
        {
            throw new NotImplementedException("unable to load data");
        }

        [HttpGet("{id}")]
        public ActionResult<Travel> GetTravelById(int id)
        {
            var travelId = travel.GetTravelById(id);

            if (travelId == null)
            {

                return NotFound($"this id :  {travelId} not exist in database");
            }
            return travelId;

        
        }

        [HttpDelete("{id}")]
        public ActionResult<Travel> Delete(int id)
        {
            
             var travelId = travel.DeleteTravelById(id);
            if (travelId == null) { return NotFound(travel.Message); }

            return Ok(travel.Message.ToString());
        }
    }
}
