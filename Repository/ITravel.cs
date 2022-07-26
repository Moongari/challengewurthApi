using MyTravelMicroservice.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Repository
{
    /// <summary>
    /// Contrat ITraval  definissant l'ensemble des actions CRUD
    /// </summary>
    public interface ITravel
    {
        public List<Travel> GetAllTravel();
        public Travel GetTravelById(int id);


        public void CreateTravel(Travel travel);

        public void UpdateTravel(Travel travel);

        public void DeleteTravelById(int id);


    }
}
