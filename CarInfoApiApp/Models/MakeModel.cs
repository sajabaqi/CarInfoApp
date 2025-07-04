namespace CarInfoApiApp.Models
{
    public class MakeModel
    {
        public int Model_ID { get; set; }
        public string Model_Name { get; set; } = string.Empty;
        public int Make_ID { get; set; }
        public string Make_Name { get; set; } = string.Empty;
    }
    public class MakeModelResponse
    {
        public int Count { get; set; }
        public string Message { get; set; } = string.Empty;
        public string SearchCriteria { get; set; } = string.Empty;
        public List<MakeModel> Results { get; set; } = new List<MakeModel>();
    }
}
