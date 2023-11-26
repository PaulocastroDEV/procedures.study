using System.ComponentModel.DataAnnotations.Schema;

namespace StudyingProcedures.Models.ViewModels
{
    public class EditNameViewModel
    {
        [Column("city_name")]
        public string CityName { get; set; }
    }
}
