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
        /// <summary>
        /// creation d'un nouveau travel
        /// </summary>
        /// <param name="travel"></param>
        public void CreateTravel(Travel travel)
        {
            this._context.Travels.Add(travel);
            this._context.SaveChanges();

        }


        /// <summary>
        /// Suppression d'un travel par id
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
        /// Retourne un travel  en fonction de l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Travel GetTravelById(int id)
        {
   
            return _context.Travels.FirstOrDefault(t => t.Id == id);
        }


        /// <summary>
        /// Mise a jour d'un travel
        /// </summary>
        /// <param name="travel"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UpdateTravel(int id,Travel travel)
        {
            var updateTravel =  _context.Travels.Find(id);
         

            if (updateTravel != null)
            {
                updateTravel.Id = id;
                updateTravel.City = travel.City;
                updateTravel.Start_date = travel.Start_date;
                updateTravel.End_date = travel.End_date;
                updateTravel.Status = travel.Status;
                updateTravel.Price = travel.Price;
                updateTravel.Color = travel.Color;
                _context.Travels.Update(updateTravel);
                _context.SaveChanges();
             
            }
        }


       
    }
}
