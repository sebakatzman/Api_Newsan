namespace TodoApi.Models
{
    public class Tarea
    {
        public long id { get; set; }
        
        public string description { get; set; }

        public string state { get; set; }

        public string photo { get; set; }
    }
}