namespace geo_service.Services.Clients.DaDataClient
{
    public class Response
    {
        public List<Suggestion> Suggestions { get; set; }
    }


    public class Suggestion
    {
        public string value { get; set; }
        public string unrestricted_value { get; set; }

        public Data data { get; set; }
        
    }

    public class Data
    {
        public string country { get; set; }

        public string city { get; set; }

        public string region { get; set; }

        public string street { get; set;}

        public string house { get; set; }

        public string flat { get; set; }
    }
}