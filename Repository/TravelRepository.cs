using Microsoft.EntityFrameworkCore;
using MyTravelMicroservice.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Repository
{
    /// <summary>
    /// Cette classe Travel Repository implements l'interface ITravel
    /// qui definit l'ensemble des methodes CRUD necessaire a l'api REST 
    /// </summary>
    public class TravelRepository : ITravel

    {

        private readonly TravelDbContext _context;
        public string Message { get; set; }
        public bool isLoaded { get; set; }



        // definit un middleware injection dependance
        public  TravelRepository(TravelDbContext dbContext)
        {

            this._context = dbContext;
          
              
            
         
        }
        
        public void CreateTravel(Travel travel)
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public Travel DeleteTravelById(int id)
        {
            var travel = _context.Travels.FirstOrDefault(x => x.Id == id);
            if (travel == null)
            {
               
                return null;
            }
            else
            {
                _context.Travels.Remove(travel);
                _context.SaveChanges();
                Message = $" travel with id : {travel.Id} deleted successfully ";
            }
            return travel;
        }

        /// <summary>
        /// Retourne la liste de l'ensemble des données contenu en memoire dans InMemoryDatabase
        /// </summary>
        /// <returns></returns>
        public  List<Travel> GetAllTravel()
        {
    
      
            return _context.Travels.ToList();
        } 
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Travel GetTravelById(int id)
        {
   
     
            return _context.Travels.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTravel(Travel travel)
        {
            throw new System.NotImplementedException();
        }


       
    }
}
