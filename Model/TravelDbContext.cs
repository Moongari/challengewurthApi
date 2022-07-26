using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelMicroservice.Model
{
    public class TravelDbContext :DbContext
    {
         
        private readonly string fileName = "data.json";
        private readonly string path = "data";

     
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
        {
            
        }


        public DbSet<Travel> Travels { get; set; }


       
        
        /// <summary>
        /// Permet de déserialiser le fichier data.Json
        /// cette methode est appele en mode asynchrone.
        /// On parcours ensuite le contenu du fichier que l'on charge dans context.
        /// On verifie egalement a chaque requete si le contenu est deja chargé si c'est le cas on ne fait rien.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public  void DeserializeJsonDataFile()
        {

            var options = new DbContextOptionsBuilder<TravelDbContext>()
                .UseInMemoryDatabase("MyTravelData").Options;

           
            var pathAndFile = Path.Combine(path, fileName);
            try
            {
                if (File.Exists(pathAndFile) )
                {
                  
                   
                    var dataList2 = JsonConvert.DeserializeObject<IList<Travel>>(File.ReadAllText(pathAndFile));
                    
                    foreach (var item in dataList2)
                    {
                       using(var context = new TravelDbContext(options))
                        {
                           
                            if (!context.Travels.Contains(item))
                            {
                                context.Travels.Add(item);
                                context.SaveChanges();
                                LoadFileInformation().Wait();
                            }
                            
                        }
                    }

                }

            }
            catch (FileNotFoundException ex)
            {

                throw new FileNotFoundException(ex.Message);
            }

        }


        /// <summary>
        /// appel asynchrone de la deserialisation du fichier data.json
        /// </summary>
        /// <returns></returns>
        public async Task readJsonFileAndInsertToDatabase()
        {
            await Task.Run(() => DeserializeJsonDataFile());
        }


        public async Task LoadFileInformation()
        {
            await Task.Run(() => "Loading Data in database....please waiting !");
        }



    }
}
