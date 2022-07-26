using Microsoft.EntityFrameworkCore;
using MyTravelMicroservice.Model;
using System.Collections.Generic;
using System.Linq;
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
       

        // definit un middleware injection dependance
        public  TravelRepository(TravelDbContext dbContext)
        {

            this._context = dbContext;
          
                dbContext.readJsonFileAndInsertToDatabase().Wait();
            
         
        }
        
        public void CreateTravel(Travel travel)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTravelById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Retourne la liste de l'ensemble des données contenu en memoire dans InMemoryDatabase
        /// </summary>
        /// <returns></returns>
        public  List<Travel> GetAllTravel()
        {
    
      
            return _context.Travels.ToList();
        } 
       

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
