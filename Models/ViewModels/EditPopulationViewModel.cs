using System.ComponentModel.DataAnnotations.Schema;

namespace StudyingProcedures.Models.ViewModels
{
    public class EditPopulationViewModel
    {
        [Column("population")]
        public decimal Population { get; set; }
    }
}
