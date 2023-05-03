using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tutorial.Model
{
    public class devices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string Title { get; set; }
        public string Processor { get; set; }
        public float Price { get; set; }
        public int manufacturer_id { get; set; }
    }
}
