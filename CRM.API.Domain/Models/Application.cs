using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.API.Models
{
    [Table("Application")]
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string Text { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
    }
}
