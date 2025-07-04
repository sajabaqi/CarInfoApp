namespace CarInfoApiApp.Models
{
    public class Makes
    {
        public int Make_ID { get; set; }
        public string Make_Name { get; set; }
    }

    public class MakesResponse
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<Makes> Results { get; set; }
    }
    
}
