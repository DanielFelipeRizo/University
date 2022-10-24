using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.models.dataModels
{

    public enum Level { basic, Intermediate, Advanced };

    public class Course: BaseEntity
    {
        [Required, StringLength(100)]
        public string courseName { get; set; } = string.Empty;

        [StringLength(280)]
        public string shortCourseDescription { get; set; } = string.Empty;

        [StringLength(600)]
        public string longCourseDescription { get; set; } = string.Empty;

        [StringLength(100)]
        public string targetPublic { get; set; } = string.Empty;

        [StringLength(100)]
        public string objectives { get; set; } = string.Empty;

        [StringLength(100)]
        public string Requirements { get; set; } = string.Empty;
        
        public Level Level { get; set; } = Level.basic;

        //relacionar con tabla categorias(muchos a muchos)
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        //relacion con tabla index
        [Required]
        public index index{ get; set; } = new index();
        //relacion n-m con tabla estudiantes
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
