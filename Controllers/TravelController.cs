﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        //GET: api/travel
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(Travel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            throw new NotImplementedException(travel.Message = "unable to load data");
        }
        //GET : api/Travel/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Travel> GetTravelById(int id)
        {
       
            var travelId = travel.GetTravelById(id);

            if (travelId == null)
            {

                return NotFound(travel.Message = $"Does not exist in  database");
            }
            return travelId;

        
        }
        //DELETE: api/travel/Delete/1
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Travel> Delete(int id)
        {


            var travelId = travel.DeleteTravelById(id) ;

                if (travelId == null)
                {
                    return NotFound(travel.Message = $"Does not exist in  database");
                }
           


            return Ok(travel.Message.ToString());

        }
        //POST : api/travel/Create
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<IActionResult> AddTravel(Travel newtravel)
        {
            if(travel != null)
            {
               await Task.Run(()=> travel.CreateTravel(newtravel));
                return CreatedAtAction(nameof(GetTravelById), new { id = newtravel.Id }, newtravel);
            }
           
            return BadRequest(travel.Message = $"unable to add a new item");
          
        }
        //PUT : api/travel/Update/id
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTravel(int id, Travel Updatetravel)
        {
            if (!id.Equals(Updatetravel.Id))
            {
                return BadRequest(travel.Message = "IDs are different");
            }

            await Task.Run(() => travel.UpdateTravel(id, Updatetravel));

            if (Updatetravel == null)
            {
                return NotFound(travel.Message = $"Travel with Id= {id} not found");
            }
            else
            {
                return CreatedAtAction(nameof(GetTravelById), new { id = Updatetravel.Id }, Updatetravel);
            }
        }
            
    }
}
