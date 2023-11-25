using System.ComponentModel.DataAnnotations.Schema;

namespace StudyingProcedures.Models.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel(string cityName, decimal population)
        {
            CityName = cityName;
            Population = population;
        }

        [Column("city_name")]
        public string CityName { get; set; }


        [Column("population")]
        public decimal Population { get; set; }
    }
}
