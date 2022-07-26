namespace MyTravelMicroservice.Model
{
    public class Travel
    {
        public int Id { get; set; }
        public string City { get; set; }

        public string Start_date { get; set; }
        public string End_date { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }

        public string Color { get; set; }

    }
}
