using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyingProcedures.Models
{
    public class Cities
    {

        
        [Column("id")]
        public int Id { get; set; }
        
        [Column("city_name")]
        public string CityName { get; set; }

        
        [Column("population")]
        public decimal Population { get; set; }

        

    }
}
