using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.models.dataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string NameCategory { get; set; } = string.Empty;

        //relacionar con tabla curso(muchos a muchos)
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
