using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.models.dataModels
{
    public class index: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string Chapters = string.Empty;

    }
}
