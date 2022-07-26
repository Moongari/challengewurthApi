﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTravelMicroservice.Model;
using MyTravelMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public  class TravelController : ControllerBase
    {
        private static TravelDbContext _context;
        private static TravelRepository travel;
        /// <summary>
        /// injection des dependances middelware
        /// </summary>
        /// <param name="context"></param>
        public  TravelController(TravelDbContext context)
        {
            _context = context;
            travel = new TravelRepository(_context);
         
        }
        //GET: api/travels
       [HttpGet]
        public  ActionResult<IEnumerable<Travel>> GetAllTravel()
        {
           
            if (travel != null)
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
        //GET : api/Travel/1
        [HttpGet("{id}")]
        public ActionResult<Travel> GetTravelById(int id)
        {
            travel.isLoaded = true;
            var travelId = travel.GetTravelById(id);
          
          

            if (travelId == null)
            {

                return NotFound($"Does not exist in database");
            }
            return travelId;

        
        }
        //DELETE: api/travel/1
        [HttpDelete("{id}")]
        public ActionResult<Travel> Delete(int id)
        {


            var travelId = travel.DeleteTravelById(id) ;

                if (travelId == null)
                {
                    return NotFound(travel.Message = $"Does not exist in  database");
                }
           


            return Ok(travel.Message.ToString());

        }
        //POST : api/travels
        [HttpPost]
       public async  Task<IActionResult> AddTravel(Travel newtravel)
        {
            if(travel != null)
            {
               await Task.Run(()=> travel.CreateTravel(newtravel));
                return CreatedAtAction(nameof(GetTravelById), new { id = newtravel.Id }, newtravel);
            }
           
            return BadRequest($"unable to add a new item");
          
        }
        //PUT : api/travel/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTravel(int id, Travel Updatetravel)
        {
            if (!id.Equals(Updatetravel.Id))
            {
                return BadRequest("IDs are different");
            }

            await Task.Run(() => travel.UpdateTravel(id, Updatetravel));

            if (Updatetravel == null)
            {
                return NotFound($"Travel with Id= {id} not found");
            }
            else
            {
                return CreatedAtAction(nameof(GetTravelById), new { id = Updatetravel.Id }, Updatetravel);
            }
        }
            
    }
}
