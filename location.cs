namespace IromDomeSystem
{
    public class Address

    {
        
        public string house_number { get; set; }
        public string road { get; set; }
        public string neighbourhood { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

    public class LocationData
    {
        public string place_id { get; set; }
        public string osm_type { get; set; }
        public string osm_id { get; set; }
        public string licence { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public List<string> boundingbox { get; set; }
        public double importance { get; set; }
        public Address address { get; set; }
    }

    
}